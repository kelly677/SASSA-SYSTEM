using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SASSA_Application.Classes;

namespace SASSA_Application.Designer_Forms
{
    public partial class StaffPortal : Form
    {
        public StaffPortal()
        {
            InitializeComponent();
        }
        private void LoadQueue()
        {
            flpQueue.SuspendLayout();
            flpQueue.Controls.Clear();

            string[] order = { "Booked", "Checked In", "Waiting", "Called", "Being Served", "Completed" };
            int cardWidth = flpQueue.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;

            foreach (string status in order)
            {
                var group = BookingStore.Bookings.Where(b => b.Status == status).ToList();
                if (group.Count == 0) continue;

                flpQueue.Controls.Add(new Label
                {
                    Text = status + "   " + group.Count,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(11, 74, 162),
                    AutoSize = true,
                    Margin = new Padding(0, 10, 0, 6)
                });

                foreach (Booking b in group)
                {
                    QueueCard card = new QueueCard(b.Reference, b.BeneficiaryName, b.ServiceName,
                                                   b.Time, b.QueueNumberText, b.Status);
                    card.Width = cardWidth;
                    flpQueue.Controls.Add(card);
                }
            }

            flpQueue.ResumeLayout();
        }
        private void pnlBookings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffPortal_Load(object sender, EventArgs e)
        {

        }

        private void btnQManagement_Click(object sender, EventArgs e)
        {
            pnlQManagement.BringToFront();
            LoadQueue();
        }

        private void btnStaffDashboard_Click(object sender, EventArgs e)
        {
            pnlStaffDash.BringToFront();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlSearch.BringToFront();
        }
    }
}
