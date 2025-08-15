using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Question2 : System.Web.UI.Page
    {
        int laptopPrice = 55000;
        int phonePrice = 25000;
        int tabPrice = 15000;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                ddlProducts.Items.Add(new ListItem("Select a Product", ""));
                ddlProducts.Items.Add(new ListItem("Laptop", "Laptop.jpg"));
                ddlProducts.Items.Add(new ListItem("Smartphone", "Phone.jpg"));
                ddlProducts.Items.Add(new ListItem("Tablet", "Tab.jpg"));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedValue != "")
            {
                imgProduct.ImageUrl = "~/" + ddlProducts.SelectedValue;
            }
            else
            {
                imgProduct.ImageUrl = "";
            }

            lblPrice.Text = "";
        }


        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedItem.Text;

            if (selected == "Laptop")
            {
                lblPrice.Text = "Price: " + laptopPrice;
            }
            else if (selected == "Smartphone")
            {
                lblPrice.Text = "Price: " + phonePrice;
            }
            else if (selected == "Tablet")
            {
                lblPrice.Text = "Price: " + tabPrice;
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}