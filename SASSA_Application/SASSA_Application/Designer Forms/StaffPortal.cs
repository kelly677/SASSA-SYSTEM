using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SASSA_Application.Designer_Forms
{
    public partial class StaffPortal : Form
    {
        private List<Booking> allBookings = new List<Booking>();
        //private List<StaffMember> staff = new List<StaffMember>();
        private string staffCentre;
        public StaffPortal(string currentCentre)
        {
            InitializeComponent();
            this.staffCentre =string.IsNullOrWhiteSpace(currentCentre) ? "Johannesburg Central" : currentCentre;
        }
        public StaffPortal()
        {
            InitializeComponent();
            this.staffCentre = "Johannesburg Central";
        }

        
        private void LoadQueue()
        {
            allBookings = FileManager.LoadBookings();
            flpQueue.SuspendLayout();
            flpQueue.Controls.Clear();

            int cardWidth = flpQueue.ClientSize.Width - 25;
            var activeStatuses = new[] { "Booked", "Checked In", "Waiting", "Serving" };

            var queueGroup = allBookings
                .Where(b => b.CentreName != null && 
            b.CentreName.Equals(staffCentre, StringComparison.OrdinalIgnoreCase) &&
            activeStatuses.Any(s => s.Equals(b.Status, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            foreach (Booking b in queueGroup)
            {
                QueueCard card = new QueueCard(b.Reference,
                    b.BeneficiaryName,
                    b.ServiceName,
                    b.Time,
                    b.QueueNumberText,
                    b.Status
                    );
                card.Width = cardWidth;
                flpQueue.Controls.Add(card);
            }
            flpQueue.ResumeLayout();
            
        }
        private void btnCallNext_Click(object sender, EventArgs e)
        {
            allBookings = FileManager.LoadBookings();

            var currentServing = allBookings.FirstOrDefault(b => b.Status == "Serving");

            if (currentServing != null) currentServing.Status = "Completed";

            var nextInLine = allBookings.FirstOrDefault(b => b.Status == "Waiting" || b.Status == "Checked In");
            if (nextInLine != null)
            {
                nextInLine.Status = "Serving";
                MessageBox.Show($"Now calling ticket {nextInLine.QueueNumberText}: {nextInLine.BeneficiaryName}", "Call Next", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There are no beneficiaries currently waiting in queue.", "Queue Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FileManager.SaveAllBookings(allBookings);
            RefreshDashboardData();
            LoadQueue();
        }
        // Panel Navigation & Search Handlers
        private void btnQManagement_Click(object sender, EventArgs e)
        {
            pnlQManagement.BringToFront();
            LoadQueue();
        }
        private void btnStaffDashboard_Click(object sender, EventArgs e)
        {
            pnlStaffDash.BringToFront();
            RefreshDashboardData();
        }
        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
            LoadBookingsTable();
        }
        private void btnSearch_Click_Tab(object sender, EventArgs e)
        {
            pnlSearch.BringToFront();
        }
        private void pnlBookings_Paint(object sender, PaintEventArgs e) { }

        //private void pnlBookings_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void StaffPortal_Load(object sender, EventArgs e)
        {

            RefreshDashboardData();
            LoadQueue();
            LoadBookingsTable();
        }

        private void RefreshDashboardData()
        {
            allBookings = FileManager.LoadBookings();
            var centreBookings = allBookings
                .Where(b => b.CentreName != null && b.CentreName.StartsWith(staffCentre.Split(' ')[0],
                StringComparison.OrdinalIgnoreCase))
                .ToList();

   if (lblBookedCount != null) lblBookedCount.Text = centreBookings.Count(b => b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase)).ToString();
   if (lblCheckedInCount != null) lblCheckedInCount.Text = centreBookings.Count(b => b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)).ToString();
     if (lblWaitingCount != null) lblWaitingCount.Text = centreBookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)).ToString();
    if (lblServingCount != null) lblServingCount.Text = centreBookings.Count(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)).ToString();
   if (lblCompletedCount != null) lblCompletedCount.Text = centreBookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).ToString();
  if (lblNoShowCount != null) lblNoShowCount.Text = centreBookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase)).ToString();
            var currentServing = centreBookings.FirstOrDefault(b => b.Status == "Serving");
            if (currentServing != null)
            {
                if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = currentServing.QueueNumberText;
                if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = currentServing.BeneficiaryName;
            }
            else
            {
                if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = "Q-000";
                if (lblQueueNumberNowServing != null) lblQueueNumberNowServing.Text = "None";
            }
            var nextWaiting = centreBookings.FirstOrDefault(b => b.Status == "Waiting" || b.Status == "Checked In");
            if (nextWaiting != null)
            {
                if (lblQueueNumberAndBeneficiaryNameNowServing != null)
                    lblQueueNumberAndBeneficiaryNameNowServing.Text = $"{nextWaiting.QueueNumberText} - {nextWaiting.BeneficiaryName}";
            }
            else
            {
                if (lblQueueNumberAndBeneficiaryNameNowServing != null) lblQueueNumberAndBeneficiaryNameNowServing.Text = "No one Waiting";
            }

        }
        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearching == null) return;
            string query = txtSearching.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                LoadBookingsTable();
                //    MessageBox.Show("Please enter a booking reference or beneficiary name", "Search Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            allBookings = FileManager.LoadBookings();
            var searchResults = allBookings.Where(b =>
            (b.Reference != null && b.Reference.Equals(query, StringComparison.OrdinalIgnoreCase)) ||
            (b.BeneficiaryName != null && b.BeneficiaryName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (b.BeneficiaryId != null && b.BeneficiaryId.Equals(query, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            if (searchResults.Count > 0)
            {
                pnlBookings.BringToFront();
                LoadBookingsTable(searchResults);
            }
            else
            {
                MessageBox.Show("No matching bookings found", "Not found", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void LoadBookingsTable(List<Booking> listToDisplay = null)
        {
            allBookings = FileManager.LoadBookings();

            var displayList = listToDisplay ?? allBookings;

            if (dgvTotalBookings != null)
            {
                dgvTotalBookings.DataSource = null;
                dgvTotalBookings.DataSource = displayList;
            }


        }

        
    }
}

