using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace SASSA_Application.Designer_Forms
{
    public partial class BeneficiaryPortal : Form
    {
        private Beneficiary currentBeneficiary;
        private string currentProfilePicPath = "";

        public BeneficiaryPortal(Beneficiary beneficiary)
        {
            InitializeComponent();
            currentBeneficiary = beneficiary;
        }

        public BeneficiaryPortal()
        {
            InitializeComponent();
            currentBeneficiary = null;
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void BeneficiaryPortal_Load(object sender, EventArgs e)
        {
            LoadCentres();

            if (currentBeneficiary != null)
            {
                lblUserName.Text = "👤 " + currentBeneficiary.FullName;
                PopulateProfileData();
            }

            RefreshDashboard();
            LoadMyBookings();
            pnlDashboard.BringToFront();
        }

        // ============================================================
        // LOAD CENTRES (Runs on load)
        // ============================================================
        private void LoadCentres()
        {
            cmbServiceCentre.Items.Clear();
            if (File.Exists("Centres.txt"))
            {
                foreach (string line in File.ReadAllLines("Centres.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length >= 3) cmbServiceCentre.Items.Add(parts[0]);
                }
            }
        }

        // ============================================================
        // DYNAMIC LOADING: When Centre or Date changes
        // ============================================================
        private void cmbServiceCentre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServicesForCentre();
            LoadAvailableSlots();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableSlots();
        }

        private void LoadServicesForCentre()
        {
            cmbServiceRequired.Items.Clear();
            if (cmbServiceCentre.SelectedItem == null) return;

            string selectedCentre = cmbServiceCentre.SelectedItem.ToString();

            if (File.Exists("Services.txt"))
            {
                foreach (string line in File.ReadAllLines("Services.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    // parts: 0=Centre, 1=ServiceName, 2=Desc, 3=Status
                    if (parts.Length >= 4 && parts[0] == selectedCentre && parts[3] == "Active")
                    {
                        cmbServiceRequired.Items.Add(parts[1]);
                    }
                }
            }
        }

        private void LoadAvailableSlots()
        {
            cmbTimeSlot.Items.Clear();
            if (cmbServiceCentre.SelectedItem == null) return;

            // Block weekends
            DayOfWeek selectedDay = dtpDate.Value.DayOfWeek;
            if (selectedDay == DayOfWeek.Saturday || selectedDay == DayOfWeek.Sunday) return;

            string selectedCentre = cmbServiceCentre.SelectedItem.ToString();
            string selectedDate = dtpDate.Value.ToString("yyyy-MM-dd");

            if (!File.Exists("Slots.txt")) return;

            foreach (string line in File.ReadAllLines("Slots.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');

                // NEW FORMAT: 0=Centre, 1=Date, 2=Slot, 3=Capacity, 4=Booked
                if (parts.Length >= 5)
                {
                    string centre = parts[0];
                    string date = parts[1];
                    string slot = parts[2];
                    int capacity = int.Parse(parts[3]);
                    int booked = int.Parse(parts[4]);
                    int available = capacity - booked;

                    if (centre == selectedCentre && date == selectedDate && available > 0)
                    {
                        cmbTimeSlot.Items.Add(slot + " (" + available + " spots left)");
                    }
                }
            }
        }

        // ============================================================
        // CREATE BOOKING
        // ============================================================
        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (currentBeneficiary == null)
            {
                MessageBox.Show("You must be logged in to make a booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbServiceCentre.SelectedItem == null || cmbServiceRequired.SelectedItem == null || cmbTimeSlot.SelectedItem == null)
            {
                MessageBox.Show("Please select a centre, service, and time slot.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DayOfWeek selectedDay = dtpDate.Value.DayOfWeek;
            if (selectedDay == DayOfWeek.Saturday || selectedDay == DayOfWeek.Sunday)
            {
                MessageBox.Show("SASSA service centres are closed on weekends.", "Closed on Weekends", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCentre = cmbServiceCentre.SelectedItem.ToString();
            string selectedService = cmbServiceRequired.SelectedItem.ToString();
            string selectedTime = cmbTimeSlot.SelectedItem.ToString().Split('(')[0].Trim();
            string selectedDate = dtpDate.Value.ToString("yyyy-MM-dd");

            // Block double-booking on the same day
            if (HasBookingOnDate(selectedDate))
            {
                MessageBox.Show("You already have a booking on this date.", "Duplicate Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deduct capacity from Slots.txt
            string[] slotLines = File.ReadAllLines("Slots.txt");
            for (int i = 0; i < slotLines.Length; i++)
            {
                string[] parts = slotLines[i].Split('|');

                // NEW FORMAT: 0=Centre, 1=Date, 2=Slot, 3=Capacity, 4=Booked
                if (parts.Length >= 5 && parts[0] == selectedCentre && parts[1] == selectedDate && parts[2] == selectedTime)
                {
                    int newBooked = int.Parse(parts[4]) + 1;
                    slotLines[i] = parts[0] + "|" + parts[1] + "|" + parts[2] + "|" + parts[3] + "|" + newBooked;
                    break;
                }
            }
            File.WriteAllLines("Slots.txt", slotLines);

            // Create + save the booking
            Booking newBooking = new Booking
            {
                Reference = "REF" + new Random().Next(1000, 9999),
                BeneficiaryId = currentBeneficiary.IdNumber,
                BeneficiaryName = currentBeneficiary.FullName,
                ServiceName = selectedService,
                CentreName = selectedCentre,
                Date = selectedDate,
                Time = selectedTime,
                Status = "Booked",
                QueueNumber = "Pending"
            };

            FileManager.SaveBooking(newBooking);

            MessageBox.Show("Booking confirmed!\n\nReference: " + newBooking.Reference + "\n\nYour queue number will be assigned when you arrive.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cmbServiceCentre.SelectedItem = null;
            cmbServiceRequired.SelectedItem = null;
            cmbTimeSlot.SelectedItem = null;

            RefreshDashboard();
            LoadMyBookings();
            pnlMyBooking.BringToFront();
        }

        // ============================================================
        // DASHBOARD & QUEUE
        // ============================================================
        private void RefreshDashboard()
        {
            if (currentBeneficiary == null) return;
            List<Booking> bookings = FileManager.LoadBookings();
            Booking latestBooking = null;

            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber && (b.Status == "Booked" || b.Status == "Checked In" || b.Status == "Waiting" || b.Status == "Serving"))
                {
                    if (latestBooking == null || string.Compare(b.Date, latestBooking.Date) > 0) latestBooking = b;
                }
            }

            if (latestBooking != null)
            {
                lblUpcomingBooking.Text = latestBooking.ServiceName + " on " + latestBooking.Date + " at " + latestBooking.Time;
                lblQueueNumber.Text = (string.IsNullOrEmpty(latestBooking.QueueNumber) || latestBooking.QueueNumber == "Pending") ? "Not Checked In" : latestBooking.QueueNumber;
                lblQueueStatus.Text = string.IsNullOrEmpty(latestBooking.Status) ? "Booked" : latestBooking.Status;
            }
            else
            {
                lblUpcomingBooking.Text = "No Upcoming Booking";
                lblQueueNumber.Text = "Q-000";
                lblQueueStatus.Text = "Waiting";
            }
        }

        private void RefreshQueueStatus()
        {
            if (currentBeneficiary == null) return;
            List<Booking> bookings = FileManager.LoadBookings();
            Booking active = null;

            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber && (b.Status == "Checked In" || b.Status == "Waiting" || b.Status == "Serving"))
                {
                    active = b;
                    break;
                }
            }

            if (active != null)
            {
                lblQueueNumber.Text = active.QueueNumber;
                lblStatus.Text = active.Status;

                int totalInQueue = 0;
                int myPosition = 0;
                foreach (Booking b in bookings)
                {
                    if (b.CentreName == active.CentreName && b.Date == active.Date && (b.Status == "Checked In" || b.Status == "Waiting" || b.Status == "Serving"))
                    {
                        totalInQueue++;
                        if (b.Reference == active.Reference) myPosition = totalInQueue;
                    }
                }

                int peopleAhead = myPosition - 1;
                if (peopleAhead < 0) peopleAhead = 0;
                lblEstimatedWait.Text = active.Status == "Serving" ? "0 Minutes (You are next!)" : "~" + (peopleAhead * 10) + " Minutes";
                lblPeopleAhead.Text = active.Status == "Serving" ? "0" : peopleAhead.ToString();
            }
            else
            {
                lblQueueNumber.Text = "Not Checked In";
                lblEstimatedWait.Text = "-";
                lblPeopleAhead.Text = "-";
                lblStatus.Text = "Booked";
            }
        }

        private void LoadMyBookings()
        {
            dgvMyBookings.Rows.Clear();
            if (currentBeneficiary == null) return;
            foreach (Booking b in FileManager.LoadBookings())
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber)
                    dgvMyBookings.Rows.Add(b.Reference, b.ServiceName, b.CentreName, b.Time, b.Date, b.Status);
            }
        }

        private bool HasBookingOnDate(string date)
        {
            if (currentBeneficiary == null) return false;
            foreach (Booking b in FileManager.LoadBookings())
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber && b.Date == date && (b.Status == "Booked" || b.Status == "Checked In" || b.Status == "Waiting")) return true;
            }
            return false;
        }

        // ============================================================
        // PROFILE & UI NAVIGATION (Keep your existing methods)
        // ============================================================
        private void PopulateProfileData()
        {
            if (currentBeneficiary == null) return;
            txtFullName.Text = currentBeneficiary.Name;
            txtLastName.Text = currentBeneficiary.Surname;
            txtIDNumber.Text = currentBeneficiary.IdNumber;
            txtPhoneNumber.Text = currentBeneficiary.Cell;
            txtEmailAddress.Text = currentBeneficiary.Email;

            cmbPreferredServiceCentre.Items.Clear();
            if (File.Exists("Centres.txt"))
            {
                foreach (string line in File.ReadAllLines("Centres.txt"))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 3) cmbPreferredServiceCentre.Items.Add(parts[0]);
                }
            }
            cmbPreferredServiceCentre.SelectedItem = currentBeneficiary.PreferredCentre;

            string folderPath = Path.Combine(Application.StartupPath, "ProfilePictures");
            string expectedPath = Path.Combine(folderPath, currentBeneficiary.IdNumber + ".jpg");
            if (picProfile.Image != null) { picProfile.Image.Dispose(); picProfile.Image = null; }
            if (File.Exists(expectedPath)) { using (FileStream fs = new FileStream(expectedPath, FileMode.Open, FileAccess.Read)) { picProfile.Image = Image.FromStream(fs); } }
            SetProfileFieldsReadOnly(true);
        }

        private void SetProfileFieldsReadOnly(bool readOnly)
        {
            txtFullName.ReadOnly = readOnly; txtLastName.ReadOnly = readOnly; txtIDNumber.ReadOnly = true;
            txtPhoneNumber.ReadOnly = readOnly; txtEmailAddress.ReadOnly = readOnly;
            cmbPreferredServiceCentre.Enabled = !readOnly; btnSaveChanges.Enabled = !readOnly;
        }

        private void btnEditDetails_Click(object sender, EventArgs e) { SetProfileFieldsReadOnly(false); }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (currentBeneficiary == null) return;
            currentBeneficiary.Name = txtFullName.Text.Trim();
            currentBeneficiary.Surname = txtLastName.Text.Trim();
            currentBeneficiary.Cell = txtPhoneNumber.Text.Trim();
            currentBeneficiary.Email = txtEmailAddress.Text.Trim();
            currentBeneficiary.PreferredCentre = cmbPreferredServiceCentre.SelectedItem?.ToString() ?? "";

            List<Beneficiary> beneficiaries = FileManager.LoadBeneficiaries();
            int index = beneficiaries.FindIndex(b => b.IdNumber == currentBeneficiary.IdNumber);
            if (index != -1)
            {
                beneficiaries[index] = currentBeneficiary;
                FileManager.SaveBeneficiaries(beneficiaries);
                MessageBox.Show("Profile updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserName.Text = "👤 " + currentBeneficiary.FullName;
            }
            SetProfileFieldsReadOnly(true);
        }

        private void btnDashboard_Click(object sender, EventArgs e) { RefreshDashboard(); pnlDashboard.BringToFront(); }
        private void btnNewBooking_Click(object sender, EventArgs e) { pnlNewBooking.BringToFront(); }
        private void btnMyBookings_Click(object sender, EventArgs e) { LoadMyBookings(); pnlMyBooking.BringToFront(); }
        private void btnQueueStatus_Click(object sender, EventArgs e) { RefreshQueueStatus(); pnlQueueStatus.BringToFront(); }
        private void btnProfile_Click(object sender, EventArgs e) { PopulateProfileData(); pnlProfile.BringToFront(); }
        private void lblUserName_Click(object sender, EventArgs e) { pnlProfile.BringToFront(); }
        private void btnChatWithAssistant_Click(object sender, EventArgs e) { new ChatBotForm().Show(); }
        private void pnlMyBooking_Paint(object sender, PaintEventArgs e) { }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new frmWelcomePage().Show(); this.Close();
            }
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count == 0) return;
            string reference = dgvMyBookings.SelectedRows[0].Cells[0].Value.ToString();
            List<Booking> bookings = FileManager.LoadBookings();
            Booking target = bookings.Find(b => b.Reference == reference);

            if (target != null && target.Status != "Completed" && target.Status != "Serving")
            {
                target.Status = "Cancelled";
                Booking newBooking = new Booking
                {
                    Reference = "REF" + new Random().Next(1000, 9999),
                    BeneficiaryId = currentBeneficiary.IdNumber,
                    BeneficiaryName = currentBeneficiary.FullName,
                    ServiceName = target.ServiceName,
                    CentreName = target.CentreName,
                    Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                    Time = cmbTimeSlot.SelectedItem?.ToString() ?? target.Time,
                    Status = "Booked",
                    QueueNumber = "Pending"
                };
                bookings.Add(newBooking);
                FileManager.SaveAllBookings(bookings);
                MessageBox.Show("Rescheduled!", "Success");
                LoadMyBookings(); RefreshDashboard(); pnlMyBooking.BringToFront();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count == 0) return;
            string reference = dgvMyBookings.SelectedRows[0].Cells[0].Value.ToString();
            if (MessageBox.Show("Cancel " + reference + "?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<Booking> bookings = FileManager.LoadBookings();
                Booking target = bookings.Find(b => b.Reference == reference);
                if (target != null) { target.Status = "Cancelled"; FileManager.SaveAllBookings(bookings); LoadMyBookings(); RefreshDashboard(); }
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            if (currentBeneficiary == null) return;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string folder = Path.Combine(Application.StartupPath, "ProfilePictures");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string dest = Path.Combine(folder, currentBeneficiary.IdNumber + ".jpg");
                if (picProfile.Image != null) { picProfile.Image.Dispose(); picProfile.Image = null; }
                if (File.Exists(dest)) File.Delete(dest);
                using (Image newImage = Image.FromFile(openFileDialog1.FileName)) { newImage.Save(dest, System.Drawing.Imaging.ImageFormat.Jpeg); }
                using (FileStream fs = new FileStream(dest, FileMode.Open, FileAccess.Read)) { picProfile.Image = Image.FromStream(fs); }
            }
        }
    }
}