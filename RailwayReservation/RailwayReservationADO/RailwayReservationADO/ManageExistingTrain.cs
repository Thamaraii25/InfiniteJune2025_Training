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
    public partial class ManageExistingTrain : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public ManageExistingTrain()
        {
            InitializeComponent();
            LoadTrain();
        }

        public void LoadTrain()
        {
            con.Open();
            string query = "select t.TrainCode, t.TrainName, ss.StationName as [Source], sd.StationName as [Destination], " +
                           "sum(seat.TotalSeats) as [Total Seats], sum(seat.AvailableSeats) as [AvailableSeats] " +
                           "from Train t " +
                           "join Station ss on t.SourceStationId = ss.StationId " +
                           "join Station sd on t.DestinationStationId = sd.StationId " +
                           "join Seats seat on t.TrainId = seat.TrainId " +
                           "where seat.JourneyDate = @JourneyDate " +
                           "group by t.TrainCode, t.TrainName, ss.StationName, sd.StationName";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@JourneyDate", dtpJourneyDate.Value.Date);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvManageExistingTrain.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            ManageTrain manageTrain = new ManageTrain();
            manageTrain.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            LoadTrain();
        }
    }
}
