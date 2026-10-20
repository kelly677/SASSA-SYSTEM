using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

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

            // 1. Update the top counters
            lblBookedCount.Text = allBookings.Count(b => b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase)).ToString();
            lblCheckedInCount.Text = allBookings.Count(b => b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)).ToString();
            lblWaitingCount.Text = allBookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase)).ToString();
            lblServingCount.Text = allBookings.Count(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)).ToString();
            lblCompletedCount.Text = allBookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).ToString();
            lblNoShowCount.Text = allBookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase)).ToString();

            // ============================================================
            // 2. Update the "Now Serving" Label
            // ============================================================
            Booking currentServing = allBookings.FirstOrDefault(b => b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase));

            if (currentServing != null)
            {
                // Show Queue Number and Name
                lblQueueNumberNowServing.Text = currentServing.QueueNumber + "\n" + currentServing.BeneficiaryName;
            }
            else
            {
                // Clear the box if no one is being served
                lblQueueNumberNowServing.Text = "None";
            }

            // ============================================================
            // 3. Update the "Waiting Now" Label
            // ============================================================
            Booking nextWaiting = allBookings.FirstOrDefault(b =>
                b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase) ||
                b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase));

            if (nextWaiting != null)
            {
                // Show Queue Number and Name
                lblQueueNumberAndBeneficiaryNameNowServing.Text = nextWaiting.QueueNumber + " - " + nextWaiting.BeneficiaryName;
            }
            else
            {
                // Clear the box if no one is waiting
                lblQueueNumberAndBeneficiaryNameNowServing.Text = "No one waiting";
            }
        }

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

            List<Booking> bookings = FileManager.LoadBookings();

            // Clear both grids so results don't mix with old data
            dgvTotalBookings.Rows.Clear();

            bool found = false;

            foreach (Booking b in bookings)
            {
                bool match = string.IsNullOrEmpty(query)
                    || b.Reference.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryName.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryId.Contains(query)
                    || b.ServiceName.ToLower().Contains(query.ToLower())
                    || b.Status.ToLower().Contains(query.ToLower());

                if (match)
                {
                    dgvTotalBookings.Rows.Add(b.Reference, b.BeneficiaryName, b.ServiceName,
                                               b.CentreName, b.Date, b.Status);
                    found = true;
                }
            }

            // Show the Bookings panel where the grid lives
            pnlBookings.BringToFront();

            if (!found)
            {
                MessageBox.Show("No matching bookings found.", "Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                    // --- NEW QUEUE NUMBER LOGIC ---
                    int queueCount = 0;
                    foreach (Booking b in bookings)
                    {
                        if (b.CentreName == bookings[i].CentreName &&
                            b.Date == bookings[i].Date &&
                            (b.Status == "Checked In" || b.Status == "Waiting" || b.Status == "Serving"))
                        {
                            queueCount++;
                        }
                    }

                    // Assign next number (Q-001, Q-002, etc.)
                    bookings[i].QueueNumber = "Q-" + (queueCount + 1).ToString("D3");
                    bookings[i].Status = "Checked In";
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                FileManager.SaveAllBookings(bookings);

                // --- EMAIL SENDING LOGIC ---
                // Find the booking we just updated to get their name, ID, and Queue Number
                Booking checkedInBooking = bookings.Find(b => b.Reference == reference);

                if (checkedInBooking != null)
                {
                    string beneficiaryEmail = "";

                    // Look up their email in Beneficiaries.txt
                    if (File.Exists("Beneficiaries.txt"))
                    {
                        foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
                        {
                            string[] parts = line.Split('|');
                            // Format: Name|Surname|ID|Phone|Email|Centre|Password
                            if (parts.Length >= 5 && parts[2] == checkedInBooking.BeneficiaryId)
                            {
                                beneficiaryEmail = parts[4]; // Email is at index 4
                                break;
                            }
                        }
                    }

                    // If we found an email, send the Q-Number!
                    if (!string.IsNullOrWhiteSpace(beneficiaryEmail))
                    {
                        SendQueueEmail(beneficiaryEmail, checkedInBooking.BeneficiaryName, checkedInBooking.QueueNumber);
                    }
                    else
                    {
                        MessageBox.Show("Beneficiary checked in, but no email address was found on their profile.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

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
        private void SendQueueEmail(string recipientEmail, string beneficiaryName, string queueNumber)
        {
            try
            {
               
                string senderEmail = "sassaapplication642@gmail.com";      
                string appPassword = "nlxqkdlfveelxumu";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, "SASSA Queue Booking");
                mail.To.Add(recipientEmail);
                mail.Subject = "Your SASSA Queue Number";
                mail.Body = $"Hello {beneficiaryName},\n\n" +
                            $"You have been successfully checked in at the service centre.\n\n" +
                            $"Your Queue Number is: {queueNumber}\n\n" +
                            "Please keep an eye on the screen for your number to be called.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                smtp.Send(mail);

                // Show a confirmation to the staff member
                MessageBox.Show($"Beneficiary checked in successfully.\nQueue number {queueNumber} has been emailed to them.",
                                "Success & Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beneficiary checked in, but failed to send email.\nError: " + ex.Message,
                                "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
    }
}