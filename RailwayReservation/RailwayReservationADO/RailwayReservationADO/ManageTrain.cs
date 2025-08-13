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

                cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                cmd.Parameters.AddWithValue("@StationName", cmbDestination.SelectedItem.ToString());
                int descId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("insert into Train(TrainCode,TrainName,SourceStationId,DestinationStationId,Status) values(@TrainCode,@TrainName,@SourceStationId,@DestinationStationId,@Status)", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                cmd.Parameters.AddWithValue("@TrainName", txtTrainName.Text);
                cmd.Parameters.AddWithValue("@SourceStationId", srcId);
                cmd.Parameters.AddWithValue("@DestinationStationId", descId);
                cmd.Parameters.AddWithValue("@Status", "Active");
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Select TrainId from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                int trainId = (int)cmd.ExecuteScalar();

                List<int> runningDays = new List<int>();
                foreach (int i in clbRunningDays.CheckedIndices)
                {
                    int dayOfWeek = i; 
                    runningDays.Add(dayOfWeek);

                    cmd = new SqlCommand("insert into TrainRunningDays(TrainId,DayOfWeek) values(@TrainId,@DayOfWeek)", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    cmd.ExecuteNonQuery();
                }

                int totalRows = dgvRoutes.Rows.Count;

                for (int i = 0; i < totalRows; i++)
                {
                    DataGridViewRow row = dgvRoutes.Rows[i];
                    if(row.Cells["txtStationName"].Value == null)
                    {
                        break;
                    }
                    cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                    cmd.Parameters.AddWithValue("@StationName", row.Cells["txtStationName"].Value.ToString());
                    int stnId = (int)cmd.ExecuteScalar();

                    cmd = new SqlCommand("insert into TrainRoute(TrainId,StationId,RouteOrder,ArrivalTime,DepartureTime) " +
                                         "values(@TrainId,@StationId,@RouteOrder,@ArrivalTime,@DepartureTime)", con);

                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@StationId", stnId);
                    cmd.Parameters.AddWithValue("@RouteOrder", row.Cells["RouteOrder"].Value);

                    if (i == 0)
                    {
                        cmd.Parameters.AddWithValue("@ArrivalTime", DBNull.Value);
                        cmd.Parameters.AddWithValue("@DepartureTime", row.Cells["DepartureTime"].Value);
                    }
                    else if (i == totalRows - 2)
                    {
                        cmd.Parameters.AddWithValue("@ArrivalTime", row.Cells["ArrivalTime"].Value);
                        cmd.Parameters.AddWithValue("@DepartureTime", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ArrivalTime", row.Cells["ArrivalTime"].Value);
                        cmd.Parameters.AddWithValue("@DepartureTime", row.Cells["DepartureTime"].Value);
                    }

                    cmd.ExecuteNonQuery();
                }


                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(30);

                foreach (DataGridViewRow row in dgvSeats.Rows)
                {
                    var cellValue = row.Cells["txtClass"].Value;
                    if (cellValue == null)
                    { 
                        break; 
                    }

                    string className = row.Cells["txtClass"].Value.ToString();
                    int seatPerCoach = Convert.ToInt32(row.Cells["txtSeatCount"].Value);
                    int coachCount = Convert.ToInt32(row.Cells["txtCoachCount"].Value);
                    int totalSeats = seatPerCoach * coachCount;

                    for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                    {
                        int Day = (int)date.DayOfWeek; 
                        if (runningDays.Contains(Day))
                        {
                            cmd = new SqlCommand("insert into Seats (TrainId, Class, TotalSeats, AvailableSeats, CoachCount, JourneyDate) values (@TrainId, @Class, @TotalSeats, @AvailableSeats, @CoachCount, @JourneyDate)", con);
                            cmd.Parameters.AddWithValue("@TrainId", trainId);
                            cmd.Parameters.AddWithValue("@Class", className);
                            cmd.Parameters.AddWithValue("@TotalSeats", totalSeats);
                            cmd.Parameters.AddWithValue("@AvailableSeats", totalSeats);
                            cmd.Parameters.AddWithValue("@CoachCount", coachCount);
                            cmd.Parameters.AddWithValue("@JourneyDate", date);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Train details saved successfully...");
                ManageExistingTrain manageExistingTrain = new ManageExistingTrain();
                manageExistingTrain.Show();
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

        private void btnCancelTrain_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Select TrainId from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Train not found.");
                    return;
                }

                int trainId = (int)result;

                cmd = new SqlCommand("select count(*) from Passenger p join Reservation r on p.ReservationId = r.ReservationId " +
                    "where r.TrainId = @TrainId and p.Status = 'Booked'", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                int totalBookings = (int)cmd.ExecuteScalar();

                if (totalBookings > 0)
                {
                    DialogResult IsconfirmCancel = MessageBox.Show("Passengers are already booked this train..", "Still..Do u want to cancel..", MessageBoxButtons.YesNo);

                    if (IsconfirmCancel == DialogResult.No)
                    {
                        MessageBox.Show("Train cancellation aborted.");
                        return;
                    }

                    cmd = new SqlCommand("update Passenger set Status = 'Train Cancelled-Refund Pending' " +
                                         "where ReservationId in (select ReservationId from Reservation where TrainId = @TrainId and Status = 'Booked')", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("update Reservation set Status = 'Cancelled' " +
                                         "where TrainId = @TrainId and Status = 'Booked'", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    DialogResult confirm = MessageBox.Show("No bookings found for this train. Do you still want to cancel it?", "Confirm Cancel", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.No)
                    {
                        MessageBox.Show("Train cancellation aborted.");
                        return;
                    }
                }

                cmd = new SqlCommand("update Train set Status = 'InActive' where TrainId = @TrainId", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Train cancelled successfully.");
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

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string trainCode = txtTrainCode.Text;

                SqlCommand cmd = new SqlCommand("select TrainId, Status from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", trainCode);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int trainId = Convert.ToInt32(dr["TrainId"]);
                    string status = dr["Status"].ToString();
                    dr.Close();

                    if (status == "Active")
                    {
                        MessageBox.Show("This train is already active.");
                        return;
                    }

                    cmd= new SqlCommand("update Train set Status = 'Active' where TrainId = @TrainId", con);
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Train activated successfully.");
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Train not found.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
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