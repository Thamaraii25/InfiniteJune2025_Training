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
    public partial class ManageStation : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        int selectedStationId = 0;
        public ManageStation()
        {
            InitializeComponent();
            con.Open();
            LoadStationName();
            con.Close();
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Station(StationName) values(@StationName)",con);
                cmd.Parameters.AddWithValue("@StationName", txtStationName.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertion Successfull..");
                LoadStationName();
                txtStationName.Clear();
                selectedStationId = 0;
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

        private void LoadStationName()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Station",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvManageStations.DataSource = ds.Tables[0];
        }

        private void btnUpdateStationName_Click(object sender, EventArgs e)
        {
            if(selectedStationId == 0)
            {
                MessageBox.Show("Select Data to Update...");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Station set StationName = @StationName where StationId = @StationId ", con);
                cmd.Parameters.AddWithValue("@StationName", txtStationName.Text);
                cmd.Parameters.AddWithValue("@StationId", selectedStationId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updation Successfull..");
                LoadStationName();
                txtStationName.Clear();
                selectedStationId = 0;
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

        private void btnDeleteStationName_Click(object sender, EventArgs e)
        {
            if (selectedStationId == 0)
            {
                MessageBox.Show("Select Data to delete...");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Station where StationId = @StationId ", con);
                cmd.Parameters.AddWithValue("@StationId", selectedStationId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deletion Successfull..");
                LoadStationName();
                txtStationName.Clear();
                selectedStationId = 0;
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

        private void dgvManageStations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvManageStations.Rows[e.RowIndex];
                selectedStationId = Convert.ToInt32(row.Cells["StationId"].Value);
                txtStationName.Text = row.Cells["StationName"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            adminDashBoard.Show();
            this.Hide();
        }
    }
}
