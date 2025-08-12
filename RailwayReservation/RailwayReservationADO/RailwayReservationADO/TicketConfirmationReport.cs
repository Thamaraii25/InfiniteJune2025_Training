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
    public partial class TicketConfirmationReport : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public static SqlCommand cmd;
        private int UserId;

        public TicketConfirmationReport(int userId)
        {
            InitializeComponent();
            UserId = userId;
            LoadReservation();
            LoadPassengers();
        }

        public void LoadReservation()
        {
            try
            {
                con.Open();
                string query = "select ss.StationName as [Source], sd.StationName as [Destination], " +
                               "r.JourneyDate, r.Status, r.PassengerCount " +
                               "from Reservation r " +
                               "join Station ss ON ss.StationId = r.SourceStationId " +
                               "join Station sd ON sd.StationId = r.DestinationStationId " +
                               "where r.UserId = @UserId";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", UserId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReport.DataSource = dt;
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
        public void LoadPassengers()
        {
            try
            {
                con.Open();
                string query = "select p.Name, p.Age, p.Gender, p.AllottedBerth " +
                               "from Passenger p " +
                               "join Reservation r ON r.ReservationId = p.ReservationId " +
                               "where r.UserId = @UserId";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", UserId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPassengers.DataSource = dt;
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

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
            this.Hide();
        }
    }
}
