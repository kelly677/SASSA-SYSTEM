using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class StaffPortal : Form
    {
        private List<Booking> allBookings = new List<Booking>();
        private string staffCentre;
        private string loggedInName;

        public StaffPortal(string name, string currentCentre)
        {
            InitializeComponent();
            this.loggedInName = name;
            this.staffCentre = string.IsNullOrWhiteSpace(currentCentre) ? "Johannesburg Central" : currentCentre;
        }

        public StaffPortal()
        {
            InitializeComponent();
            this.loggedInName = "Guest";
            this.staffCentre = "Johannesburg Central";
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void StaffPortal_Load(object sender, EventArgs e)
        {
           
            lblUserName.Text = "👤 " + loggedInName;
            RefreshStaffDashboardData();
            LoadAllBookings();
            //RefreshStaffDashboardData();
        }

        // ============================================================
        // LOAD ALL BOOKINGS — Bookings panel
        // ============================================================
        private void LoadAllBookings()
        {
            dgvTotalBookings.Rows.Clear();

            allBookings = FileManager.LoadBookings();

            foreach (Booking b in allBookings)
            {
                dgvTotalBookings.Rows.Add(b.Reference, b.BeneficiaryName, b.ServiceName,
                                           b.CentreName, b.Date, b.Status);
            }
        }

        // ============================================================
        // LOAD ACTIVE QUEUE — Queue Management panel
        // ============================================================
        private void LoadActiveQueue()
        {
            dgvQueue.Rows.Clear();

            allBookings = FileManager.LoadBookings();

            foreach (Booking b in allBookings)
            {
                if (b.Status == "Booked" || b.Status == "Checked In" ||
                    b.Status == "Waiting" || b.Status == "Serving")
                {
                    dgvQueue.Rows.Add(b.Reference, b.BeneficiaryName, b.ServiceName,
                                       b.CentreName, b.Date, b.Status);
                }
            }
        }

        // ============================================================
        // DASHBOARD REFRESH
        // ============================================================
        //private void RefreshDashboardData()
        //{
        //    //allBookings = FileManager.LoadBookings();
        //    List<Booking> allBookings = FileManager.LoadBookings();

        //    //var centreBookings = allBookings.Where(b =>
        //    //                    b.CentreName != null && (
        //    //                    string.IsNullOrWhiteSpace(staffCentre) ||
        //    //                    b.CentreName.Contains(staffCentre.Split(' ')[0], StringComparison.OrdinalIgnoreCase) ||
        //    //                    staffCentre.Contains(b.CentreName, StringComparison.OrdinalIgnoreCase)
        //    //                    )
        //    //                    ).ToList();
        //    //lblBookedCount.Text = centreBookings.Count(b => b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase)).ToString();
        //    //lblCheckedInCount.Text = centreBookings.Count(b => b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)).ToString();
        //    //lblWaitingCount.Text = centreBookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)).ToString();
        //    //lblServingCount.Text = centreBookings.Count(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)).ToString();
        //    //lblCompletedCount.Text = centreBookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).ToString();
        //    //lblNoShowCount.Text = centreBookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase)).ToString();

        //    //var currentServing = centreBookings.FirstOrDefault(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase));
        //    //lblQueueNumberNowServing.Text = currentServing != null
        //    //    ?$"{currentServing.QueueNumber} - {currentServing.BeneficiaryName}"
        //    //   : "None";

        //    //var nextWaiting = centreBookings.FirstOrDefault(b => b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)
        //    //|| b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase));

        //    //lblQueueNumberAndBeneficiaryNameNowServing.Text = nextWaiting != null
        //    //    ?$"{nextWaiting.QueueNumber} - {nextWaiting.BeneficiaryName}"
        //    //   : "No one waiting";
        //    var centreBookings = allBookings
        //      .Where(b => b.CentreName != null && b.CentreName.StartsWith(staffCentre.Split(' ')[0],
        //      StringComparison.OrdinalIgnoreCase))
        //      .ToList();

        //    if (lblBookedCount != null) lblBookedCount.Text = centreBookings.Count(b => b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase)).ToString();
        //    if (lblCheckedInCount != null) lblCheckedInCount.Text = centreBookings.Count(b => b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)).ToString();
        //    if (lblWaitingCount != null) lblWaitingCount.Text = centreBookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)).ToString();
        //    if (lblServingCount != null) lblServingCount.Text = centreBookings.Count(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)).ToString();
        //    if (lblCompletedCount != null) lblCompletedCount.Text = centreBookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).ToString();
        //    if (lblNoShowCount != null) lblNoShowCount.Text = centreBookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase)).ToString();
        //    var currentServing = centreBookings.FirstOrDefault(b => b.Status == "Serving");
        //    if (currentServing != null)
        //    {
        //        if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = currentServing.QueueNumberText;
        //        if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = currentServing.BeneficiaryName;
        //    }
        //    else
        //    {
        //        if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = "Q-000";
        //        if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = "None";
        //    }
        //    var nextWaiting = centreBookings.FirstOrDefault(b => b.Status == "Waiting" || b.Status == "Checked In");
        //    if (nextWaiting != null)
        //    {
        //        if (lblQueueNumberAndBeneficiaryNameNowServing != null)
        //            lblQueueNumberAndBeneficiaryNameNowServing.Text = $"{nextWaiting.QueueNumberText} - {nextWaiting.BeneficiaryName}";
        //    }
        //    else
        //    {
        //        if (lblQueueNumberAndBeneficiaryNameNowServing != null) lblQueueNumberAndBeneficiaryNameNowServing.Text = "No one Waiting";
        //    }



        //    //    .Where(b => b.CentreName != null &&
        //    //           b.CentreName.StartsWith(staffCentre.Split(' ')[0], StringComparison.OrdinalIgnoreCase))
        //    //    .ToList();

        //    //lblBookedCount.Text = centreBookings.Count(b => b.Status == "Booked").ToString();
        //    //lblCheckedInCount.Text = centreBookings.Count(b => b.Status == "Checked In").ToString();
        //    //lblWaitingCount.Text = centreBookings.Count(b => b.Status == "Waiting").ToString();
        //    //lblServingCount.Text = centreBookings.Count(b => b.Status == "Serving").ToString();
        //    //lblCompletedCount.Text = centreBookings.Count(b => b.Status == "Completed").ToString();
        //    //lblNoShowCount.Text = centreBookings.Count(b => b.Status == "No-Show").ToString();

        //    //var currentServing = centreBookings.FirstOrDefault(b => b.Status == "Serving");
        //    //lblQueueNumberNowServing.Text = currentServing != null
        //    //    ? currentServing.QueueNumber + " - " + currentServing.BeneficiaryName
        //    //    : "None";

        //    //var nextWaiting = centreBookings.FirstOrDefault(b => b.Status == "Checked In" || b.Status == "Waiting");
        //    //lblQueueNumberAndBeneficiaryNameNowServing.Text = nextWaiting != null
        //    //    ? nextWaiting.QueueNumber + " - " + nextWaiting.BeneficiaryName
        //    //    : "No one waiting";
        //}

        // ============================================================
        // CALL NEXT
        // ============================================================

        // ============================================================
        // SIDEBAR BUTTONS
        // ============================================================
        private void btnQManagement_Click(object sender, EventArgs e)
        {
            pnlQManagement.BringToFront();
            LoadActiveQueue();
            
        }

        private void btnStaffDashboard_Click(object sender, EventArgs e)
        {
            pnlStaffDash.BringToFront();
            RefreshStaffDashboardData();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
            LoadAllBookings();
            

        }
        private void RefreshStaffDashboardData()
        {
            List<Booking> allBookings = FileManager.LoadBookings();

            lblBookedCount.Text = allBookings.Count(b =>
                b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblWaitingCount.Text = allBookings.Count(b =>
                b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblCheckedInCount.Text = allBookings.Count(b =>
    b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)
).ToString();

            lblWaitingCount.Text = allBookings.Count(b =>
    b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)
).ToString();
            lblServingCount.Text = allBookings.Count(b =>
    b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)
).ToString();

            lblCompletedCount.Text = allBookings.Count(b =>
                b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblNoShowCount.Text = allBookings.Count(b =>
                b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase)
            ).ToString();
        }




        // ============================================================
        // SEARCH BUTTON
        // ============================================================


        // ============================================================
        // LOGOUT
        // ============================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to log out?",
                                                   "Logout", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                frmWelcomePage welcome = new frmWelcomePage();
                welcome.Show();
                this.Close();
            }
        }

        private void pnlBookings_Paint(object sender, PaintEventArgs e) { }
        private void pnlTop_Paint(object sender, PaintEventArgs e) { }




        private void btnMarkServed_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reference = dgvQueue.SelectedRows[0].Cells[0].Value.ToString();

            List<Booking> bookings = FileManager.LoadBookings();
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Reference == reference)
                {
                    bookings[i].Status = "Completed";
                    break;
                }
            }

            FileManager.SaveAllBookings(bookings);
            LoadActiveQueue();
            RefreshStaffDashboardData();
        }

        private void btnNoShow_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reference = dgvQueue.SelectedRows[0].Cells[0].Value.ToString();

            List<Booking> bookings = FileManager.LoadBookings();
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Reference == reference)
                {
                    bookings[i].Status = "No-Show";
                    break;
                }
            }

            FileManager.SaveAllBookings(bookings);
            LoadActiveQueue();
            RefreshStaffDashboardData();
        }

        private void btnSerchingBooking_Click(object sender, EventArgs e)
        {
            string query = txtSearching.Text.Trim();

            dgvTotalBookings.Rows.Clear();

            List<Booking> bookings = FileManager.LoadBookings();
            bool found = false;

            foreach (Booking b in bookings)
            {
                bool match = string.IsNullOrEmpty(query)
                    || b.Reference.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryName.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryId.Contains(query);

                if (match)
                {
                    dgvTotalBookings.Rows.Add(b.Reference, b.BeneficiaryName, b.ServiceName,
                                               b.CentreName, b.Date, b.Status);
                    found = true;
                }
            }

            if (!found && !string.IsNullOrEmpty(query))
            {
                MessageBox.Show("No matching bookings found.", "Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pnlBookings.BringToFront();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking from the queue first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reference = dgvQueue.SelectedRows[0].Cells[0].Value.ToString();

            List<Booking> bookings = FileManager.LoadBookings();
            bool updated = false;

            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Reference == reference)
                {
                    if (bookings[i].Status != "Booked")
                    {
                        MessageBox.Show("Only 'Booked' items can be checked in.",
                                        "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bookings[i].Status = "Checked In";
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                FileManager.SaveAllBookings(bookings);
                MessageBox.Show("Beneficiary checked in.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveQueue();
                RefreshStaffDashboardData();
            }
        }

        private void btnCallNext_Click(object sender, EventArgs e)
        {
            List<Booking> bookings = FileManager.LoadBookings();

            // Complete whoever is currently serving
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Status == "Serving")
                {
                    bookings[i].Status = "Completed";
                }
            }

            // Find the next person waiting
            Booking next = null;
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Status == "Checked In" || bookings[i].Status == "Waiting")
                {
                    next = bookings[i];
                    break;
                }
            }

            if (next != null)
            {
                next.Status = "Serving";
                MessageBox.Show("Now serving " + next.QueueNumber + " - " + next.BeneficiaryName,
                                "Call Next", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No one waiting in the queue.", "Queue Empty",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FileManager.SaveAllBookings(bookings);
            //LoadActiveQueue();
            RefreshStaffDashboardData();
            LoadActiveQueue();
        }

        //private void pnlStaffDash_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}