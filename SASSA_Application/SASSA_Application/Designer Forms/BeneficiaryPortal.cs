using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class BeneficiaryPortal : Form
    {
        public BeneficiaryPortal()
        {
            InitializeComponent();
        }

        private void BeneficiaryPortal_Load(object sender, EventArgs e)
        {
            cmbServiceCentre.AddRange("Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa");
            cmbServiceRequired.AddRange("New Grant application", "Existing grant enquiry", "Grant information update",
                    "Payment enquiry", "Document submission");
        }

        private void pnlMyBooking_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlDashboard.BringToFront();
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            pnlNewBooking.BringToFront();
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            pnlMyBooking.BringToFront();
        }

        private void btnQueueStatus_Click(object sender, EventArgs e)
        {
            pnlQueueStatus.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlProfile.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}
