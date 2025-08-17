using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBoardBilling
{
    public partial class ElectricityLoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            if (login.ValidateLogin(txtEmail.Text, txtPassword.Text))
            {
                Response.Redirect("~/BillCalculationForm.aspx");
            }
            else
            {
                Response.Write("Invalid Login Credentials...");
            }
        }
    }
}