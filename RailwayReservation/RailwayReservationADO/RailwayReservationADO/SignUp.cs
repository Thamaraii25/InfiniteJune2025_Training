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
    public partial class SignUp : Form
    {
        SqlConnection con = GetSQLConnection.getConnection();
        public static SqlCommand cmd;

        public SignUp()
        {
            InitializeComponent();
        }

        private void btnAdminSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password Not Match!!!");
                return;
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into Admin(FullName,Password,Email,PhoneNumber) values(@FullName,@Password,@Email,@PhoneNumber)", con);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);

                cmd.ExecuteNonQuery();
              
                MessageBox.Show("Sign Up Successfull...Redirecting to Login Page....!!!");

                Home home = new Home();
                home.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                con.Close();
            }
        }

        private void btnUserSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password Not Match!!!");
                return;
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into UserTable(FullName,Password,Email,PhoneNumber) values(@FullName,@Password,@Email,@PhoneNumber)",con);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sign Up Successfull...Redirecting to Login Page....!!!");

                Home home = new Home();
                home.Show();
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
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
