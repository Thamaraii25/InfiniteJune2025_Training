using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class ASP_Assignment_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Response.Write("Welcome...");
            }
            else
            {
                Response.Write("Please Correct the form details..");
            }
        }
    }
}