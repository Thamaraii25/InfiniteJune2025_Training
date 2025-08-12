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
    public partial class Home : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public Home()
        {
            InitializeComponent();
        }

     
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Admin where Email = @email and Password = @password",con);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Admin Login Successful");
                    AdminDashBoard adminDashBoard = new AdminDashBoard();
                    adminDashBoard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Admin Credentials");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                con.Close();
            }
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select UserId from UserTable where Email = @email and Password = @password",con);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                int userId = (int)cmd.ExecuteScalar();
                if (userId != 0)
                {
                    MessageBox.Show("User Login Successful");
                    UserDashboard userDashboard = new UserDashboard(userId);
                    userDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid User Credentials");
                }

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

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SignUp signUp = new SignUp();
                signUp.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
