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
    public partial class UserDashboard : Form
    {
        public int UserId;
        public UserDashboard()
        {
            InitializeComponent();
        }

        public UserDashboard(int usrId)
        {
            InitializeComponent();
            this.UserId = usrId;

        }


        private void btnSearchTrain_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UserId.ToString());
            SearchTrain searchTrain = new SearchTrain(UserId);
            searchTrain.Show();
            this.Hide();
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            BookTicket bookTicket = new BookTicket();
            bookTicket.Show();
            this.Hide();
        }

        private void btnBookingHistory_Click(object sender, EventArgs e)
        {
            BookingHistory bookingHistory = new BookingHistory(UserId);
            bookingHistory.Show();
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
