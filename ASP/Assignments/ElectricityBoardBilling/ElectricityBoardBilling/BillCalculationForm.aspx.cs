using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBoardBilling
{
    public partial class BillCalculationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack && ViewState["BillCount"] != null)
            {
                int count = (int)ViewState["BillCount"];
                GenerateInputFields(count);
            } 
        }

        protected void btnGenerateInputs_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(txtBillsToBeAdded.Text);
            ViewState["BillCount"] = count;
            GenerateInputFields(count);
        }

        private void GenerateInputFields(int count)
        {
            phBillInputs.Controls.Clear();

            for (int i = 1; i <= count; i++)
            {
                phBillInputs.Controls.Add(new Literal { Text = "<br/>Bill " + i + "<br/>" });

                phBillInputs.Controls.Add(new Literal { Text = "Consumer Number: &nbsp;&nbsp;&nbsp;" });

                TextBox txtConsumerNumber = new TextBox();
                txtConsumerNumber.ID = "txtConsumerNumber" + i;
                phBillInputs.Controls.Add(txtConsumerNumber);
                phBillInputs.Controls.Add(new Literal { Text = "<br/>" });

                phBillInputs.Controls.Add(new Literal { Text = "Consumer Name: &nbsp;&nbsp;&nbsp;&nbsp;" });
                TextBox txtConsumerName = new TextBox();
                txtConsumerName.ID = "txtConsumerName" + i;
                phBillInputs.Controls.Add(txtConsumerName);
                phBillInputs.Controls.Add(new Literal { Text = "<br/>" });

                phBillInputs.Controls.Add(new Literal { Text = "Units Consumed: &nbsp;&nbsp;&nbsp;&nbsp" });
                TextBox txtUnitsConsumed = new TextBox();
                txtUnitsConsumed.ID = "txtUnitsConsumed" + i;
                phBillInputs.Controls.Add(txtUnitsConsumed);
                phBillInputs.Controls.Add(new Literal { Text = "<br/><br/>" });
            }
        }

        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            try 
            {
                lblOutput.Text = "";  

                int count = (int)ViewState["BillCount"];
                ElectricityBoard electricityBoard = new ElectricityBoard();

                for (int i = 1; i <= count; i++)
                {
                    TextBox txtConsumerNumber = (TextBox)phBillInputs.FindControl("txtConsumerNumber" + i);
                    TextBox txtConsumerName = (TextBox)phBillInputs.FindControl("txtConsumerName" + i);
                    TextBox txtUnitsConsumed = (TextBox)phBillInputs.FindControl("txtUnitsConsumed" + i);

                    ElectricityBill eb = new ElectricityBill();
                    eb.ConsumerNumber = txtConsumerNumber.Text;
                    eb.ConsumerName = txtConsumerName.Text;
                    eb.UnitsConsumed = Convert.ToInt32(txtUnitsConsumed.Text);
                    eb.BillAmount = electricityBoard.CalculateBill(eb.UnitsConsumed);

                    string msg = electricityBoard.AddBill(eb);

                    if (msg != "Record Inserted Successfully..")
                    {
                        lblOutput.Text = msg;
                        return;
                    }

                    lblOutput.Text += msg + "<br/>";

                    lblOutput.Text += eb.ConsumerNumber + " " + eb.ConsumerName + " " +
                                      eb.UnitsConsumed + " Bill Amount : " + eb.BillAmount + "<br/>";
                }

                int n = Convert.ToInt32(txtLast_N_Bills.Text);
                var bills = electricityBoard.Generate_N_BillDetails(n);

                lblLastNBills.Text = "Details of last 'N' bills:<br/>";
                foreach (var b in bills)
                {
                    lblLastNBills.Text += "EB Bill for " + b.ConsumerName + " is " + b.BillAmount + "<br/>";
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}