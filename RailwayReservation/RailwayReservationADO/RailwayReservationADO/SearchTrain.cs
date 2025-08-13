using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RailwayReservationADO
{
    public partial class SearchTrain : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        List<string> listOfStation = new List<string>();
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public int UserId;

        public SearchTrain()
        {
            InitializeComponent();
            LoadStationName();
        }

        public SearchTrain(int userId)
        {
            InitializeComponent();
            LoadStationName();
            this.UserId = userId;    
        }

        public void LoadStationName()
        {
            con.Open();
            cmd = new SqlCommand("Select StationName from Station", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listOfStation.Add(dr["StationName"].ToString());
            }
            cmbSource.DataSource = new List<string>(listOfStation);
            cmbDestination.DataSource = new List<string>(listOfStation);
            con.Close();
        }

        private int GetStationId(string stationName)
        {
            int stationId = 0;
            try
            {
                cmd = new SqlCommand("select StationId from Station where StationName = @StationName", con);
                cmd.Parameters.AddWithValue("@StationName", stationName);
                stationId = (int) cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stationId;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (cmbSource.SelectedItem.ToString() == cmbDestination.SelectedItem.ToString())
                {
                    MessageBox.Show("Source and Destination cannot be the same.");
                    return;
                }

                if (dtpJourneyDate.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Try Using UpComing Journey date");

                }

                int sourceId = GetStationId(cmbSource.SelectedItem.ToString());
                int destId = GetStationId(cmbDestination.SelectedItem.ToString());
                DateTime journeyDate = dtpJourneyDate.Value.Date; ;
                
                string query =
                    "select t.TrainCode, t.TrainName, r1.DepartureTime as [Start Time], r2.ArrivalTime as [Reach Time], sum(s.AvailableSeats) as [Available Seats]  " +
                    "from Train t " +
                    "join TrainRoute r1 on t.TrainId = r1.TrainId and r1.StationId = @sourceId " +
                    "join TrainRoute r2 on t.TrainId = r2.TrainId and r2.StationId = @destId " +
                    "join TrainRunningDays d on t.TrainId = d.TrainId " +
                    "join Seats s on t.TrainId = s.TrainId and s.JourneyDate = @journeydate " +
                    "where r1.RouteOrder < r2.RouteOrder " +
                    "and dayofweek = case datepart(weekday, @journeydate) when 1 then 0 when 2 then 1" +
                    "when 3 then 2 when 4 then 3 when 5 then 4 when 6 then 5 when 7 then 6 end " +
                    "group by t.TrainCode, t.TrainName, r1.DepartureTime, r2.ArrivalTime";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sourceid", sourceId);
                cmd.Parameters.AddWithValue("@destid", destId);
                cmd.Parameters.AddWithValue("@journeydate", journeyDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSearchResult.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            if (dgvSearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a train to book...");
                return;
            }

            DataGridViewRow selectedRow = dgvSearchResult.SelectedRows[0];

            string trainCode = selectedRow.Cells["TrainCode"].Value.ToString();
            string source = cmbSource.SelectedItem.ToString();
            string destination = cmbDestination.SelectedItem.ToString();
            DateTime journeyDate = dtpJourneyDate.Value.Date;

            MessageBox.Show(UserId.ToString());

            BookTicket bookTicket = new BookTicket(UserId, trainCode, source, destination, journeyDate);
            bookTicket.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard(UserId);
            userDashboard.Show();
            this.Hide();
        }
    }
}
