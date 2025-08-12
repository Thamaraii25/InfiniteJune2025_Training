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
        public int userId;

        public BookingHistory(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            try
            {
                con.Open();

                string query = "select p.PassengerId, p.Name, r.ReservationId, r.TrainId, r.Status, r.PassengerCount, pay.Amount as FareAmount, f.Class " +
                               "from Passenger p " +
                               "join Reservation r on p.ReservationId = r.ReservationId " +
                               "left join FareDetails f on r.TrainId = f.TrainId and r.SourceStationId = f.FromStationId and r.DestinationStationId = f.ToStationId " +
                               "left join Payment pay on pay.ReservationId = r.ReservationId " +
                               "where r.UserId = @UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                dgvBookingHistory.DataSource = dt;
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
            double refundAmount = fareAmount * 0.5;

            try
            {
                con.Open();

                string getCount = "select PassengerCount from Reservation where ReservationId = @ReservationId";
                SqlCommand cmdGetCount = new SqlCommand(getCount, con);
                cmdGetCount.Parameters.AddWithValue("@ReservationId", reservationId);
                int currentCount = Convert.ToInt32(cmdGetCount.ExecuteScalar());

                if (currentCount == 1)
                {
                    string deletePassenger = "delete from Passenger where PassengerId = @PassengerId";
                    SqlCommand cmd1 = new SqlCommand(deletePassenger, con);
                    cmd1.Parameters.AddWithValue("@PassengerId", passengerId);
                    cmd1.ExecuteNonQuery();

                    string updateStatus = "update Reservation set Status = 'Cancelled' where ReservationId = @ReservationId";
                    SqlCommand cmd2 = new SqlCommand(updateStatus, con);
                    cmd2.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    string deletePassenger = "delete from Passenger where PassengerId = @PassengerId";
                    SqlCommand cmd1 = new SqlCommand(deletePassenger, con);
                    cmd1.Parameters.AddWithValue("@PassengerId", passengerId);
                    cmd1.ExecuteNonQuery();

                    string updateCount = "update Reservation set PassengerCount = PassengerCount - 1, Status = 'Partially Cancelled' where ReservationId = @ReservationId";
                    SqlCommand cmd2 = new SqlCommand(updateCount, con);
                    cmd2.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd2.ExecuteNonQuery();
                }

                string updateSeats = "update Seats set AvailableSeats = AvailableSeats + 1 where TrainId = @TrainId and Class = @Class";
                SqlCommand cmd3 = new SqlCommand(updateSeats, con);
                cmd3.Parameters.AddWithValue("@TrainId", trainId);
                cmd3.Parameters.AddWithValue("@Class", Class);
                cmd3.ExecuteNonQuery();

                string insertCancel = "insert into Cancellation (ReservationId, AmountRefund) values (@ReservationId, @AmountRefund)";
                SqlCommand cmd4 = new SqlCommand(insertCancel, con);
                cmd4.Parameters.AddWithValue("@ReservationId", reservationId);
                cmd4.Parameters.AddWithValue("@AmountRefund", refundAmount);
                cmd4.ExecuteNonQuery();

                MessageBox.Show("Ticket cancelled successfully. Refund Amount: " + refundAmount);
                con.Close();
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
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
            this.Hide();
        }
    }
}
