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
    public partial class BookingHistory : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public static SqlCommand cmd;
        public int userId;

        public BookingHistory(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            con.Open();
            LoadBookingHistory();
            con.Close();
        }

        private string GetClassFromBerth(string allottedBerth)
        {
            if (allottedBerth.StartsWith("Sitting"))
                return "Sitting";
            else if (allottedBerth.StartsWith("Sleeper"))
                return "Sleeper";
            else if (allottedBerth.StartsWith("AC"))
                return "AC";
            else
                return "Unknown Class";
        }

        private void LoadBookingHistory()
        {
            try
            {
                string query = "select p.PassengerId, p.Name, p.Status [Passenger Status], r.ReservationId, r.TrainId, t.TrainName, r.Status [Reservation Status], r.PassengerCount, pay.Amount as FareAmount, p.AllottedBerth " +
                               "from Passenger p " +
                               "join Reservation r on p.ReservationId = r.ReservationId " +
                               "join Payment pay on pay.ReservationId = r.ReservationId " +
                               "join Train t on r.TrainId = t.TrainId " +
                               "where r.UserId = @UserId";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.Columns.Add("Class", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string berth = row["AllottedBerth"].ToString();
                    row["Class"] = GetClassFromBerth(berth);
                }

                dgvBookingHistory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnCancelTicket_Click(object sender, EventArgs e)
        {
            if (dgvBookingHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a ticket to cancel.");
                return;
            }

            DataGridViewRow row = dgvBookingHistory.SelectedRows[0];
            string Class = row.Cells["Class"].Value.ToString();
            int passengerId = Convert.ToInt32(row.Cells["PassengerId"].Value);
            int reservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
            int trainId = Convert.ToInt32(row.Cells["TrainId"].Value);
            double fareAmount = Convert.ToDouble(row.Cells["FareAmount"].Value);
            int passengerCount = Convert.ToInt32(row.Cells["PassengerCount"].Value);
            
            try
            {
                con.Open();

                string query = "select JourneyDate from Reservation where ReservationId = @ReservationId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                DateTime journeyDate = (DateTime)cmd.ExecuteScalar();

                TimeSpan timeDiff = journeyDate.Date - DateTime.Now.Date;
                double refundAmount = 0;

                if (timeDiff.TotalDays >= 1)
                {
                    refundAmount = (fareAmount * 0.5) / passengerCount;
                }

                query = "update Passenger set Status = 'Cancelled' where PassengerId = @PassengerId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PassengerId", passengerId);
                cmd.ExecuteNonQuery();

                if (passengerCount == 1)
                {
                    query = "update Reservation set Status = 'Cancelled' where ReservationId = @ReservationId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    query = "update Reservation set PassengerCount = PassengerCount - 1, Status = 'Partially Cancelled' where ReservationId = @ReservationId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd.ExecuteNonQuery();
                }


                query= "update Seats set AvailableSeats = AvailableSeats + 1 where TrainId = @TrainId and Class = @Class and JourneyDate = @JourneyDate";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@Class", Class);
                cmd.Parameters.AddWithValue("@JourneyDate", journeyDate);
                cmd.ExecuteNonQuery();

                query = "insert into Cancellation (ReservationId, AmountRefund) values (@ReservationId, @AmountRefund)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                cmd.Parameters.AddWithValue("@AmountRefund", refundAmount);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Ticket cancelled successfully...Refund Amount: " + refundAmount);
                LoadBookingHistory();
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
            UserDashboard userDashboard = new UserDashboard(userId);
            userDashboard.Show();
            this.Hide();
        }
    }
}
