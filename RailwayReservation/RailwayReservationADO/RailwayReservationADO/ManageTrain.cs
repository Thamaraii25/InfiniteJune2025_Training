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
    public partial class ManageTrain : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        List<string> listOfStation = new List<string>();
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public ManageTrain()
        {
            InitializeComponent();
            LoadStationName();
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

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                cmd.Parameters.AddWithValue("@StationName", cmbSource.SelectedItem.ToString());
                int srcId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("Select StationId from Station where StationName = @StationName",con);
                cmd.Parameters.AddWithValue("@StationName", cmbDestination.SelectedItem.ToString());
                int descId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("insert into Train(TrainCode,TrainName,SourceStationId,DestinationStationId) values(@TrainCode,@TrainName,@SourceStationId,@DestinationStationId)",con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                cmd.Parameters.AddWithValue("@TrainName", txtTrainName.Text);
                cmd.Parameters.AddWithValue("@SourceStationId", srcId);
                cmd.Parameters.AddWithValue("@DestinationStationId", descId);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Select TrainId from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                int trainId = (int)cmd.ExecuteScalar();

                foreach (int i in clbRunningDays.CheckedIndices)
                {
                    cmd = new SqlCommand("insert into TrainRunningDays(TrainId,DayOfWeek) values(@TrainId,@DayOfWeek)", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@DayOfWeek", i + 1);
                    cmd.ExecuteNonQuery();
                }

                foreach (DataGridViewRow row in dgvRoutes.Rows)
                {
                    var cellValue = row.Cells["txtStationName"].Value;
                    if (cellValue == null)
                    {
                        break;
                    }
                    string stationName = cellValue.ToString();
                    cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                    cmd.Parameters.AddWithValue("@StationName", stationName);
                    int stnId = (int) cmd.ExecuteScalar();

                    cmd = new SqlCommand("insert into TrainRoute(TrainId,StationId,RouteOrder,ArrivalTime,DepartureTime) values(@TrainId,@StationId,@RouteOrder,@ArrivalTime,@DepartureTime)", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@StationId", stnId);
                    cmd.Parameters.AddWithValue("@RouteOrder", row.Cells["RouteOrder"].Value);
                    cmd.Parameters.AddWithValue("@ArrivalTime", row.Cells["ArrivalTime"].Value);
                    cmd.Parameters.AddWithValue("@DepartureTime", row.Cells["DepartureTime"].Value);
                    cmd.ExecuteNonQuery();
                }

                foreach (DataGridViewRow row in dgvSeats.Rows)
                {
                    var cellValue = row.Cells["txtClass"].Value;
                    if (cellValue == null)
                    {
                        break;
                    }

                    cmd = new SqlCommand("insert into Seats(TrainId,Class,TotalSeats,AvailableSeats,CoachCount) values(@TrainId,@Class,@TotalSeats,@AvailableSeats,@CoachCount)", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@Class", row.Cells["txtClass"].Value);
                    int SeatCount = Convert.ToInt32(row.Cells["txtSeatCount"].Value);
                    int CoachCount = Convert.ToInt32(row.Cells["txtCoachCount"].Value);
                    int total = SeatCount * CoachCount;
                    cmd.Parameters.AddWithValue("@AvailableSeats", total);
                    cmd.Parameters.AddWithValue("@TotalSeats", total);
                    cmd.Parameters.AddWithValue("@CoachCount", CoachCount);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Train Details saved successfully....");
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

        private void btnManageFare_Click(object sender, EventArgs e)
        {
            FareDetails fareDetails = new FareDetails();
            fareDetails.Show();
            this.Hide();
        }

        private void btnManageExistingTrain_Click(object sender, EventArgs e)
        {
            ManageExistingTrain manageExistingTrain = new ManageExistingTrain();
            manageExistingTrain.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.Show();
            this.Hide();
        }
    }
}