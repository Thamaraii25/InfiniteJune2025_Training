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
    public partial class BookTicket : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();   
        public static SqlCommand cmd;
        public int userId;

        public BookTicket()
        {
            InitializeComponent();
        }
        public BookTicket(int usrId,string trainCode, string source, string destination, DateTime journeyDate)
        {
            InitializeComponent();
            this.userId = usrId;
            txtTrainCode.Text = trainCode;
            txtSource.Text = source;
            txtDestination.Text = destination;
            txtJourneyDate.Text = journeyDate.ToString();
            LoadClassIfSeatsAvailable();
        }

        private void BookTicket_Load(object sender, EventArgs e)
        {

        }

        public void LoadClassIfSeatsAvailable()
        {
            try
            {
                con.Open();
                string query = "select distinct s.Class from Seats s join Train t on s.TrainId = t.TrainId where t.TrainCode = @TrainCode and s.AvailableSeats > 0";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                List<string> classes = new List<string>();
                while (dr.Read())
                {
                    classes.Add(dr["Class"].ToString());
                }
                dr.Close();
                cmbClass.DataSource = classes;
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
            try
            {
                con.Open();

                cmd = new SqlCommand("select TrainId from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                int trainId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("select StationId from Station where StationName = @SourceName", con);
                cmd.Parameters.AddWithValue("@SourceName", txtSource.Text);
                int sourceId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("select StationId from Station where StationName = @DestName", con);
                cmd.Parameters.AddWithValue("@DestName", txtDestination.Text);
                int destId = Convert.ToInt32(cmd.ExecuteScalar());

                int passengerCount = 0;
                foreach (DataGridViewRow row in dgwAddPassengers.Rows)
                {
                    if (row.Cells["PassengerName"].Value != null)
                    {
                        passengerCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                MessageBox.Show(userId.ToString());

                string insertReservation = "insert into Reservation(UserId, TrainId, SourceStationId, DestinationStationId, JourneyDate, PassengerCount, Status) " +
                                           "values(@UserId,@TrainId, @SourceId, @DestId, @JourneyDate, @PassengerCount, @Status); " +
                                           "select scope_identity()";

                SqlCommand cmdReservation = new SqlCommand(insertReservation, con);
                cmdReservation.Parameters.AddWithValue("@UserId", userId);
                cmdReservation.Parameters.AddWithValue("@TrainId", trainId);
                cmdReservation.Parameters.AddWithValue("@SourceId", sourceId);
                cmdReservation.Parameters.AddWithValue("@DestId", destId);
                cmdReservation.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));
                cmdReservation.Parameters.AddWithValue("@PassengerCount", passengerCount);
                cmdReservation.Parameters.AddWithValue("@Status", "Booked");

                int reservationId = Convert.ToInt32(cmdReservation.ExecuteScalar());

                SqlCommand cmdTotalSeats = new SqlCommand("select TotalSeats from Seats where TrainId = @TrainId and Class = @Class", con);
                cmdTotalSeats.Parameters.AddWithValue("@TrainId", trainId);
                cmdTotalSeats.Parameters.AddWithValue("@Class", cmbClass.SelectedItem.ToString());
                int totalSeats = Convert.ToInt32(cmdTotalSeats.ExecuteScalar());

                string bookedSeatsQuery = "select p.AllottedBerth from Passenger p join Reservation r on p.ReservationId = r.ReservationId " +
                                          "where r.TrainId = @TrainId and p.AllottedBerth like @ClassPrefix and r.JourneyDate = @JourneyDate and r.Status = 'Booked'";

                SqlCommand cmdBookedSeats = new SqlCommand(bookedSeatsQuery, con);
                cmdBookedSeats.Parameters.AddWithValue("@TrainId", trainId);
                cmdBookedSeats.Parameters.AddWithValue("@ClassPrefix", cmbClass.SelectedItem.ToString() + "%");
                cmdBookedSeats.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));

                SqlDataReader drBooked = cmdBookedSeats.ExecuteReader();
                List<int> bookedSeatNumbers = new List<int>();
                while (drBooked.Read())
                {
                    string berth = drBooked.GetString(0);
                    string seatNumStr = berth.Substring(cmbClass.SelectedItem.ToString().Length);
                    int seatNum = 0;
                    int.TryParse(seatNumStr, out seatNum);
                    if (seatNum > 0)
                        bookedSeatNumbers.Add(seatNum);
                }
                drBooked.Close();

                string cancelledSeatsQuery = "select p.AllottedBerth from Passenger p join Reservation r on p.ReservationId = r.ReservationId " +
                                             "where r.TrainId = @TrainId and p.AllottedBerth like @ClassPrefix and r.JourneyDate = @JourneyDate and r.Status = 'Cancelled'";

                SqlCommand cmdCancelledSeats = new SqlCommand(cancelledSeatsQuery, con);
                cmdCancelledSeats.Parameters.AddWithValue("@TrainId", trainId);
                cmdCancelledSeats.Parameters.AddWithValue("@ClassPrefix", cmbClass.SelectedItem.ToString() + "%");
                cmdCancelledSeats.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));

                SqlDataReader drCancelled = cmdCancelledSeats.ExecuteReader();
                Queue<int> cancelledSeatNumbers = new Queue<int>();
                while (drCancelled.Read())
                {
                    string berth = drCancelled.GetString(0);
                    string seatNumStr = berth.Substring(cmbClass.SelectedItem.ToString().Length);
                    int seatNum = 0;
                    int.TryParse(seatNumStr, out seatNum);
                    if (seatNum > 0)
                        cancelledSeatNumbers.Enqueue(seatNum);
                }
                drCancelled.Close();

                int seatToAssign = 1;

                foreach (DataGridViewRow row in dgwAddPassengers.Rows)
                {
                    var cellValue = row.Cells["PassengerName"].Value;
                    if (cellValue == null)
                    {
                        break;
                    }
                    int seatNumber = 0;

                    if (cancelledSeatNumbers.Count > 0)
                    {
                        seatNumber = cancelledSeatNumbers.Dequeue();
                    }
                    else
                    {
                        while (bookedSeatNumbers.Contains(seatToAssign) && seatToAssign <= totalSeats)
                        {
                            seatToAssign++;
                        }

                        if (seatToAssign > totalSeats)
                        {
                            MessageBox.Show("No seats available in this class.");
                            break;
                        }
                        seatNumber = seatToAssign;
                        seatToAssign++;
                    }

                    string berth = cmbClass.SelectedItem.ToString() + seatNumber.ToString();

                    SqlCommand cmdInsertPassenger = new SqlCommand("insert into Passenger(ReservationId, Name, Age, Gender, AllottedBerth) " +
                                                                   "values(@ReservationId, @Name, @Age, @Gender, @Berth)", con);
                    cmdInsertPassenger.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmdInsertPassenger.Parameters.AddWithValue("@Name", row.Cells["PassengerName"].Value.ToString());
                    cmdInsertPassenger.Parameters.AddWithValue("@Age", Convert.ToInt32(row.Cells["Age"].Value));
                    cmdInsertPassenger.Parameters.AddWithValue("@Gender", row.Cells["Gender"].Value.ToString());
                    cmdInsertPassenger.Parameters.AddWithValue("@Berth", berth);
                    cmdInsertPassenger.ExecuteNonQuery();

                    bookedSeatNumbers.Add(seatNumber); 
                }

                SqlCommand cmdUpdateSeats = new SqlCommand("update Seats set AvailableSeats = AvailableSeats - @Count where TrainId = @TrainId and Class = @Class", con);
                cmdUpdateSeats.Parameters.AddWithValue("@Count", passengerCount);
                cmdUpdateSeats.Parameters.AddWithValue("@TrainId", trainId);
                cmdUpdateSeats.Parameters.AddWithValue("@Class", cmbClass.SelectedItem.ToString());
                cmdUpdateSeats.ExecuteNonQuery();

                Payment payment = new Payment(userId, reservationId,trainId,sourceId,destId,cmbClass.SelectedItem.ToString(),passengerCount);
                payment.Show();
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
