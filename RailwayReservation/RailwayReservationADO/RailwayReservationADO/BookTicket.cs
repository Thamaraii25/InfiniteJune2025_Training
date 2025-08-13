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

                cmd = new SqlCommand("select Status from Train where TrainId = @TrainId", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                string status = cmd.ExecuteScalar().ToString();

                if (status != "Active")
                {
                    MessageBox.Show("Booking is not allowed... This train is currently inactive or cancelled...");
                    return;
                }

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
                        passengerCount++;
                    else
                        break;
                }

                MessageBox.Show(userId.ToString());

                string insertReservation = "insert into Reservation(UserId, TrainId, SourceStationId, DestinationStationId, JourneyDate, PassengerCount, Status) " +
                                           "values(@UserId,@TrainId, @SourceId, @DestId, @JourneyDate, @PassengerCount, @Status); select scope_identity()";

                cmd = new SqlCommand(insertReservation, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@SourceId", sourceId);
                cmd.Parameters.AddWithValue("@DestId", destId);
                cmd.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));
                cmd.Parameters.AddWithValue("@PassengerCount", passengerCount);
                cmd.Parameters.AddWithValue("@Status", "Booked");
                int reservationId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("select TotalSeats from Seats where TrainId = @TrainId and Class = @Class and JourneyDate = @JourneyDate", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@Class", cmbClass.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));
                int totalSeats = Convert.ToInt32(cmd.ExecuteScalar());

                string classPrefix = cmbClass.SelectedItem.ToString();

                List<string> bookedBerths = new List<string>();
                cmd = new SqlCommand("select p.AllottedBerth from Passenger p join Reservation r on p.ReservationId = r.ReservationId " +
                    "where r.TrainId = @TrainId and p.AllottedBerth like @ClassPrefix and r.JourneyDate = @JourneyDate " +
                    "and r.Status in ('Booked', 'Partially Cancelled') and p.Status = 'Booked'", con);

                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@ClassPrefix", classPrefix + "%");
                cmd.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bookedBerths.Add(dr["AllottedBerth"].ToString());
                }
                dr.Close();

                List<int> bookedSeatNumbers = new List<int>();
                foreach (string berth in bookedBerths)
                {
                    string numberPart = berth.Substring(classPrefix.Length);
                    int num = Convert.ToInt32(numberPart);
                    bookedSeatNumbers.Add(num);
                }

                List<string> cancelledBerths = new List<string>();
                cmd = new SqlCommand("select p.AllottedBerth from Passenger p join Reservation r on p.ReservationId = r.ReservationId " +
                                     "where r.TrainId = @TrainId and p.AllottedBerth like @ClassPrefix and r.JourneyDate = @JourneyDate and p.Status = 'Cancelled'", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@ClassPrefix", classPrefix + "%");
                cmd.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cancelledBerths.Add(dr["AllottedBerth"].ToString());
                }
                dr.Close();

                SortedSet<int> cancelledSeatNumbers = new SortedSet<int>();
                foreach (string berth in cancelledBerths)
                {
                    string numberPart = berth.Substring(classPrefix.Length).Trim();
                    int num = Convert.ToInt32(numberPart);
                    cancelledSeatNumbers.Add(num); 
                }

                int seatToAssign = 1;
                if (bookedSeatNumbers.Count > 0)
                {
                    seatToAssign = bookedSeatNumbers.Max() + 1;
                }

                foreach (DataGridViewRow row in dgwAddPassengers.Rows)
                {
                    if (row.Cells["PassengerName"].Value == null)
                        break;

                    int seatNumber;

                    if (cancelledSeatNumbers.Count > 0)
                    {
                        seatNumber = cancelledSeatNumbers.Min();          
                        cancelledSeatNumbers.Remove(seatNumber);
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

                    string berth = classPrefix + seatNumber;

                    cmd = new SqlCommand("insert into Passenger(ReservationId, Name, Age, Gender, AllottedBerth,Status) " +
                                          "values(@ReservationId, @Name, @Age, @Gender, @Berth, @Status)", con);
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    cmd.Parameters.AddWithValue("@Name", row.Cells["PassengerName"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(row.Cells["Age"].Value));
                    cmd.Parameters.AddWithValue("@Gender", row.Cells["Gender"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Berth", berth);
                    cmd.Parameters.AddWithValue("@Status", "Booked");
                    cmd.ExecuteNonQuery();

                    bookedSeatNumbers.Add(seatNumber);
                }

                cmd = new SqlCommand("update Seats set AvailableSeats = AvailableSeats - @Count where TrainId = @TrainId and Class = @Class and JourneyDate = @JourneyDate", con);
                cmd.Parameters.AddWithValue("@Count", passengerCount);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@Class", classPrefix);
                cmd.Parameters.AddWithValue("@JourneyDate", DateTime.Parse(txtJourneyDate.Text));
                cmd.ExecuteNonQuery();

                Payment payment = new Payment(userId, reservationId, trainId, sourceId, destId, classPrefix, passengerCount);
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


        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard(userId);
            userDashboard.Show();
            this.Hide();
        }
    }
}
