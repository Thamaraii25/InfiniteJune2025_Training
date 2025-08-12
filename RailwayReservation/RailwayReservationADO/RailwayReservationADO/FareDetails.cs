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
    public partial class FareDetails : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        List<string> listOfStation = new List<string>();
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public int srcId,descId,trainId;
        public FareDetails()
        {
            InitializeComponent();
            LoadStationName();
            LoadFareDetails();
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
            cmbFromSN.DataSource = new List<string>(listOfStation);
            cmbToSN.DataSource = new List<string>(listOfStation);
            con.Close();
        }

        private void LoadFareDetails()
        {
            string query = "select t.TrainCode, sf.StationName as [From Station], st.StationName as [To Station], f.Class, f.FareAmount " +
                           "from FareDetails f " +
                           "join Station sf on f.FromStationId = sf.StationId " +
                           "join Station st on f.ToStationId = st.StationId " +
                           "join Train t on f.TrainId = t.TrainId";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvFare.DataSource = ds.Tables[0];
        }

        private void btnAddFare_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                cmd.Parameters.AddWithValue("@StationName", cmbFromSN.SelectedItem.ToString());
                srcId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("Select StationId from Station where StationName = @StationName", con);
                cmd.Parameters.AddWithValue("@StationName", cmbToSN.SelectedItem.ToString());
                descId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("Select TrainId from Train where TrainCode = @TrainCode", con);
                cmd.Parameters.AddWithValue("@TrainCode", txtTrainCode.Text);
                trainId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("insert into FareDetails(TrainId,FromStationId,ToStationId,Class,FareAmount) values(@TrainId,@FromStationId,@ToStationId,@Class,@FareAmount)", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@FromStationId", srcId);
                cmd.Parameters.AddWithValue("@ToStationId", descId);
                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                cmd.Parameters.AddWithValue("@FareAmount", txtFareAmount.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inserted SuccessFully...");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                con.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateFare_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("update FareDetails set FromStationId=@FromStationId, ToStationId=@ToStationId, Class=@Class, FareAmount=@FareAmount where TrainId=@TrainId and Class=@Class", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@FromStationId", srcId);
                cmd.Parameters.AddWithValue("@ToStationId", descId);
                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                cmd.Parameters.AddWithValue("@FareAmount", txtFareAmount.Text);
                cmd.ExecuteNonQuery();

                LoadFareDetails();
                MessageBox.Show("Updated Successfully...");

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

        private void btnDeleteFare_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("delete from FareDetails where TrainId=@TrainId and Class=@Class", con);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                cmd.ExecuteNonQuery();

                LoadFareDetails();
                MessageBox.Show("Deleted Successfully...");
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
