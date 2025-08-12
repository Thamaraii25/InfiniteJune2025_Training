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

    public partial class Payment : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public static SqlCommand cmd;
        public int ReservationId, TrainId, SourceId, DestinationId,TotalPassenger,UserId;
        public string Class;

        public Payment()
        {
            InitializeComponent();
        }

        public Payment(int userId, int reserveId, int trainId, int scrId, int descId,string cl,int TotPassenger)
        {
            InitializeComponent();
            this.UserId = userId;
            this.ReservationId = reserveId;
            this.TrainId = trainId;
            this.SourceId = scrId;
            this.DestinationId = descId;
            this.Class = cl;
            this.TotalPassenger = TotPassenger;
            txtTotalFare.Text = CalculateFare().ToString();
        }

        public float CalculateFare()
        {
            con.Open();
            cmd = new SqlCommand("select RouteOrder from TrainRoute where TrainId = @TrainId and StationId = @StationId", con);
            cmd.Parameters.AddWithValue("@TrainId", TrainId);
            cmd.Parameters.AddWithValue("@StationId", SourceId);
            int StartingRoute = (int)cmd.ExecuteScalar();

            cmd = new SqlCommand("select RouteOrder from TrainRoute where TrainId = @TrainId and StationId = @StationId", con);
            cmd.Parameters.AddWithValue("@TrainId", TrainId);
            cmd.Parameters.AddWithValue("@StationId", DestinationId);
            int EndingRoute = (int)cmd.ExecuteScalar();

            MessageBox.Show($"TrainId: {TrainId}, Class: {Class}, SourceId: {SourceId}, DestinationId: {DestinationId},");

            string query = "select Sum(f.FareAmount) from FareDetails f " +
                "join TrainRoute r1 on f.FromStationId = r1.StationId and f.TrainId = r1.TrainId " +
                "join TrainRoute r2 on f.ToStationId = r2.StationId and f.TrainId = r2.TrainId " +
                "where f.TrainId = @TrainId and f.Class = @Class " +
                "and r1.RouteOrder >= @StartingRoute " +
                "and r2.RouteOrder = r1.RouteOrder + 1 " +
                "and r2.RouteOrder <= @EndingRoute";

            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@TrainId", TrainId);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.Parameters.AddWithValue("@StartingRoute", StartingRoute);
            cmd.Parameters.AddWithValue("@EndingRoute", EndingRoute);

            object result = cmd.ExecuteScalar();
            float TotalFare = 0;

            if (result != null && result != DBNull.Value)
            {
                TotalFare = Convert.ToSingle(result);
            }
            con.Close();
            return (TotalFare * TotalPassenger);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into Payment(ReservationId,UPI_Id,Amount) values(@ReservationId,@UPI_Id,@Amount)", con);
                cmd.Parameters.AddWithValue("@ReservationId", ReservationId);
                cmd.Parameters.AddWithValue("@UPI_Id", txtUPI.Text);
                cmd.Parameters.AddWithValue("@Amount", txtTotalFare.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Reservation Successfull...");
                TicketConfirmationReport ticketConfirmationReport = new TicketConfirmationReport(UserId);
                ticketConfirmationReport.Show();
                this.Hide();

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
    }
}
