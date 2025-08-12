using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationADO
{
    public partial class AdminDashBoard : Form
    {
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void btnManageStation_Click(object sender, EventArgs e)
        {
            ManageStation manageStation = new ManageStation();
            manageStation.Show();
            this.Hide();
        }

        private void btnManageTrain_Click(object sender, EventArgs e)
        {
            ManageTrain manageTrain = new ManageTrain();
            manageTrain.Show();
            this.Hide();
        }

        private void btnManageFare_Click(object sender, EventArgs e)
        {
            FareDetails fareDetails = new FareDetails();
            fareDetails.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
