using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class AdminPortal : Form
    {
        public AdminPortal()
        {
            InitializeComponent();
        }

        private void pnlReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            pnlStaff.BringToFront();
        }

        private void btnCentres_Click(object sender, EventArgs e)
        {
            pnlCentres.BringToFront();

        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            pnlServices.BringToFront();

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            pnlCentres.BringToFront();

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            pnlReports.BringToFront();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
