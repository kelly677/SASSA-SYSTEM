using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class BeneficiaryPortal : Form
    {
        private Beneficiary currentBeneficiary;

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
            PopulateDropdowns();

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
        // POPULATE DROPDOWNS
        // ============================================================
        private void PopulateDropdowns()
        {
            cmbServiceCentre.Items.Clear();
            if (File.Exists("Centres.txt"))
            {
                foreach (string line in File.ReadAllLines("Centres.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length < 3) continue;
                    cmbServiceCentre.Items.Add(parts[0]);
                }
            }

            cmbServiceRequired.Items.Clear();
            List<ServiceType> services = FileManager.LoadServices();
            if (services != null && services.Count > 0)
            {
                foreach (ServiceType s in services)
                {
                    if (s.Status == "Active")
                        cmbServiceRequired.Items.Add(s.ServiceName);
                }
            }
            else
            {
                // call AddRange on the control (RoundedComboBox), not on Items
                cmbServiceRequired.AddRange(
                    "New Grant application",
                    "Existing grant enquiry",
                    "Grant information update",
                    "Payment enquiry",
                    "Document submission"
                );
            }

            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.AddRange(
                "08:00 AM", "09:30 AM", "11:00 AM", "01:30 PM", "03:00 PM"
            );

            dtpDate.MinDate = DateTime.Today;
        }

        // ============================================================
        // DASHBOARD
        // ============================================================
        private void RefreshDashboard()
        {
            if (currentBeneficiary == null)
            {
                lblUpcomingBooking.Text = "No Upcoming Booking";
                lblQueueNumber.Text = "Q-000";
                lblQueueStatus.Text = "Waiting";
                return;
            }

            List<Booking> bookings = FileManager.LoadBookings();

            Booking latestBooking = null;
            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber)
                {
                    if (latestBooking == null || string.Compare(b.Date, latestBooking.Date) > 0)
                    {
                        latestBooking = b;
                    }
                }
            }

            if (latestBooking != null)
            {
                lblUpcomingBooking.Text = latestBooking.ServiceName + " on " +
                                          latestBooking.Date + " at " + latestBooking.Time;
                lblQueueNumber.Text = string.IsNullOrEmpty(latestBooking.QueueNumber)
                                      ? "Q-000" : latestBooking.QueueNumber;
                lblQueueStatus.Text = string.IsNullOrEmpty(latestBooking.Status)
                                      ? "Booked" : latestBooking.Status;
            }
            else
            {
                lblUpcomingBooking.Text = "No Upcoming Booking";
                lblQueueNumber.Text = "Q-000";
                lblQueueStatus.Text = "Waiting";
            }
        }

        // ============================================================
        // MY BOOKINGS
        // ============================================================
        private void LoadMyBookings()
        {
            dgvMyBookings.Rows.Clear();

            if (currentBeneficiary == null) return;

            List<Booking> bookings = FileManager.LoadBookings();

            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber)
                {
                    dgvMyBookings.Rows.Add(b.Reference, b.ServiceName, b.CentreName,
                                           b.Time, b.Date, b.Status);
                }
            }
        }
        // ============================================================
        // CHECK IF BENEFICIARY ALREADY HAS A BOOKING ON THIS DATE
        // ============================================================
        private bool HasBookingOnDate(string date)
        {
            if (currentBeneficiary == null) return false;

            List<Booking> bookings = FileManager.LoadBookings();

            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber &&
                    b.Date == date &&
                    (b.Status == "Booked" || b.Status == "Checked In" || b.Status == "Waiting"))
                {
                    return true;
                }
            }
            return false;
        }

        // ============================================================
        // CHECK IF SLOT IS FULL (max 5 per slot per centre)
        // ============================================================
        private bool IsSlotFull(string centre, string date, string time)
        {
            const int MAX_PER_SLOT = 5;
            int count = 0;

            List<Booking> bookings = FileManager.LoadBookings();

            foreach (Booking b in bookings)
            {
                if (b.CentreName == centre && b.Date == date && b.Time == time &&
                    (b.Status == "Booked" || b.Status == "Checked In" || b.Status == "Waiting"))
                {
                    count++;
                }
            }
            return count >= MAX_PER_SLOT;
        }

        // ============================================================
        // QUEUE STATUS
        // ============================================================
        private void RefreshQueueStatus()
        {
            if (currentBeneficiary == null)
            {
                lblQueueNumber.Text = "Q-000";
                lblEstimatedWaitTitle.Text = "0 Minutes";
                lblPeopleAhead.Text = "0";
                lblQueueStatus.Text = "Waiting";
                return;
            }

            List<Booking> bookings = FileManager.LoadBookings();

            Booking active = null;
            foreach (Booking b in bookings)
            {
                if (b.BeneficiaryId == currentBeneficiary.IdNumber &&
                    (b.Status == "Checked In" || b.Status == "Waiting" || b.Status == "Serving"))
                {
                    active = b;
                    break;
                }
            }

            if (active != null)
            {
                lblQueueNumber.Text = active.QueueNumber;
                lblEstimatedWaitTitle.Text = "";
                lblPeopleAhead.Text = "";
                lblQueueStatus.Text = active.Status;
            }
            else
            {
                lblQueueNumber.Text = "Q-000";
                lblEstimatedWaitTitle.Text = "0 Minutes";
                lblPeopleAhead.Text = "0";
                lblQueueStatus.Text = "Waiting";
            }
        }

        // ============================================================
        // PROFILE
        // ============================================================
        private void PopulateProfileData()
        {
            if (currentBeneficiary == null) return;

            txtFullName.Text = currentBeneficiary.Name;
            txtLastName.Text = currentBeneficiary.Surname;
            txtIDNumber.Text = currentBeneficiary.IdNumber;
            txtPhoneNumber.Text = currentBeneficiary.Cell;
            txtEmailAddress.Text = currentBeneficiary.Email;
            cmbPreferredServiceCentre.Text = currentBeneficiary.PreferredCentre;

            SetProfileFieldsReadOnly(true);
        }

        private void SetProfileFieldsReadOnly(bool readOnly)
        {
            txtFullName.ReadOnly = readOnly;
            txtLastName.ReadOnly = readOnly;
            txtIDNumber.ReadOnly = true;
            txtPhoneNumber.ReadOnly = readOnly;
            txtEmailAddress.ReadOnly = readOnly;
            cmbPreferredServiceCentre.Enabled = !readOnly;
            btnSaveChanges.Enabled = !readOnly;
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            SetProfileFieldsReadOnly(false);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (currentBeneficiary == null) return;

            currentBeneficiary.Name = txtFullName.Text.Trim();
            currentBeneficiary.Surname = txtLastName.Text.Trim();
            currentBeneficiary.Cell = txtPhoneNumber.Text.Trim();
            currentBeneficiary.Email = txtEmailAddress.Text.Trim();
            currentBeneficiary.PreferredCentre = cmbPreferredServiceCentre.Text;

            List<Beneficiary> beneficiaries = FileManager.LoadBeneficiaries();
            int index = -1;
            for (int i = 0; i < beneficiaries.Count; i++)
            {
                if (beneficiaries[i].IdNumber == currentBeneficiary.IdNumber)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                beneficiaries[index] = currentBeneficiary;
                FileManager.SaveBeneficiaries(beneficiaries);

                MessageBox.Show("Profile details updated successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblUserName.Text = "👤 " + currentBeneficiary.FullName;
            }

            SetProfileFieldsReadOnly(true);
        }

        // ============================================================
        // CREATE BOOKING
        // ============================================================
        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            // 1. Must be logged in
            if (currentBeneficiary == null)
            {
                MessageBox.Show("You must be logged in to make a booking.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Must have selected all three fields
            if (cmbServiceCentre.SelectedItem == null ||
                cmbServiceRequired.SelectedItem == null ||
                cmbTimeSlot.SelectedItem == null)
            {
                MessageBox.Show("Please select a centre, service, and time slot.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Read the selected values (safe now)
            string selectedCentre = cmbServiceCentre.SelectedItem.ToString();
            string selectedService = cmbServiceRequired.SelectedItem.ToString();
            string selectedTime = cmbTimeSlot.SelectedItem.ToString();
            string selectedDate = dtpDate.Value.ToString("yyyy-MM-dd");

            // 4. Block double-booking on the same day
            if (HasBookingOnDate(selectedDate))
            {
                MessageBox.Show("You already have a booking on this date.",
                                "Duplicate Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Block if the slot is full
            if (IsSlotFull(selectedCentre, selectedDate, selectedTime))
            {
                MessageBox.Show("This time slot is fully booked. Please choose another slot or date.",
                                "Slot Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Create + save the booking
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
                QueueNumber = "Q-" + new Random().Next(100, 999)
            };

            FileManager.SaveBooking(newBooking);

            MessageBox.Show("Booking confirmed!\n\nReference: " + newBooking.Reference +
                            "\nQueue Number: " + newBooking.QueueNumber,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 7. Clear selections
            cmbServiceCentre.SelectedItem = null;
            cmbServiceRequired.SelectedItem = null;
            cmbTimeSlot.SelectedItem = null;

            // 8. Refresh views
            LoadMyBookings();
            pnlMyBooking.BringToFront();
        }

        // ============================================================
        // NAVIGATION
        // ============================================================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
            pnlDashboard.BringToFront();
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            pnlNewBooking.BringToFront();
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            LoadMyBookings();
            pnlMyBooking.BringToFront();
        }

        private void btnQueueStatus_Click(object sender, EventArgs e)
        {
            RefreshQueueStatus();
            pnlQueueStatus.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            PopulateProfileData();
            pnlProfile.BringToFront();
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

        private void pnlMyBooking_Paint(object sender, PaintEventArgs e) { }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking from the list first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reference = dgvMyBookings.SelectedRows[0].Cells[0].Value.ToString();
            string currentStatus = dgvMyBookings.SelectedRows[0].Cells[5].Value.ToString();

            if (currentStatus == "Completed" || currentStatus == "Serving" || currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking cannot be rescheduled.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Booking> bookings = FileManager.LoadBookings();
            Booking target = null;

            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Reference == reference)
                {
                    target = bookings[i];
                    break;
                }
            }

            if (target == null) return;

            // Old booking → Cancelled
            target.Status = "Cancelled";

            // New booking → same service + centre, new date/time
            Booking newBooking = new Booking
            {
                Reference = "REF" + new Random().Next(1000, 9999),
                BeneficiaryId = currentBeneficiary.IdNumber,
                BeneficiaryName = currentBeneficiary.FullName,
                ServiceName = target.ServiceName,
                CentreName = target.CentreName,
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                Time = cmbTimeSlot.SelectedItem != null
                       ? cmbTimeSlot.SelectedItem.ToString()
                       : target.Time,
                Status = "Booked",
                QueueNumber = "Q-" + new Random().Next(100, 999)
            };

            bookings.Add(newBooking);
            FileManager.SaveAllBookings(bookings);

            MessageBox.Show("Rescheduled!\n\nOld reference: " + reference +
                            "\nNew reference: " + newBooking.Reference,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadMyBookings();
            RefreshDashboard();
            pnlNewBooking.BringToFront();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a booking from the list first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reference = dgvMyBookings.SelectedRows[0].Cells[0].Value.ToString();
            string currentStatus = dgvMyBookings.SelectedRows[0].Cells[5].Value.ToString();

            if (currentStatus == "Completed" || currentStatus == "Serving" || currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking cannot be cancelled.", "Not Allowed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show("Cancel booking " + reference + "?",
                                                   "Confirm Cancel", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            List<Booking> bookings = FileManager.LoadBookings();

            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Reference == reference)
                {
                    bookings[i].Status = "Cancelled";
                    break;
                }
            }

            FileManager.SaveAllBookings(bookings);

            MessageBox.Show("Booking cancelled.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadMyBookings();
            RefreshDashboard();
        }
    }
}