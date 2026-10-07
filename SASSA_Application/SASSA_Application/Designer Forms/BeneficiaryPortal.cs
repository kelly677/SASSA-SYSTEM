using Microsoft.VisualBasic;
using SASSA_Application.Classes;
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
        private Beneficiary? currentBeneficiary;
        // Constructor passing the authenticated beneficiary
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

        private void BeneficiaryPortal_Load(object sender, EventArgs e)
        {
            cmbServiceCentre.AddRange("Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa");
            cmbServiceRequired.AddRange("New Grant application", "Existing grant enquiry", "Grant information update",
                    "Payment enquiry", "Document submission");
            cmbTimeSlot.AddRange(
        "08:00 AM", "09:30 AM", "11:00 AM", "01:30 PM", "03:00 PM"
    );
            // Load persistent bookings into BookingStore
            BookingStore.Load();

            // Setup Header / Display Name
            if (currentBeneficiary != null)
            {
                lblUserName.Text = currentBeneficiary.FullName;
                PopulateProfileData();
            }

            // Populate Dropdowns from File Storage / Classes
            PopulateDropdowns();

            // Synchronize Data Views
            RefreshAllViews();

            // Default to Dashboard view
            pnlDashboard.BringToFront();
        }



        private void pnlMyBooking_Paint(object sender, PaintEventArgs e)
        {

        }

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
            
            pnlMyBooking.BringToFront();
            RefreshMyBookings();
        }

        private void btnQueueStatus_Click(object sender, EventArgs e)
        {
            RefreshQueueStatus();
            pnlQueueStatus.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            pnlProfile.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        #region Data Population & UI Refresh Methods

        private void PopulateDropdowns()
        {
            // Populate Service Centres
            //cmbServiceCentre.Items.Clear();
            //List<ServiceCentre> centres = FileManager.LoadServiceCentres();
            //if (centres != null && centres.Count > 0)
            //{
            //    foreach (var centre in centres.Where(c => c.Status == "Active"))
            //    {
            //        cmbServiceCentre.Items.Add(centre.CentreName);
            //    }
            //}
            //else
            if (cmbServiceCentre.SelectedIndex == 0)
            {
                cmbServiceCentre.AddRange(
                    "Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa"
                );
            }
           // cmbServiceCentre.AddRange(
           //    "Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa"
           //);
            // Populate Service Types
            cmbServiceRequired.Items.Clear();
            List<ServiceType> services = FileManager.LoadServices();
            if (services != null && services.Count > 0)
            {
                foreach (var s in services.Where(s => s.Status == "Active"))
                {
                    cmbServiceRequired.Items.Add(s.ServiceName);
                }
            }
            else
            {
                cmbServiceRequired.AddRange(
                    "New Grant application", "Existing grant enquiry",
                    "Grant information update", "Payment enquiry", "Document submission"
                );
            }

            // Populate Available Time Slots
            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.AddRange(
                "08:00 AM", "09:30 AM", "11:00 AM", "01:30 PM", "03:00 PM"
            );

            dtpDate.MinDate = DateTime.Today;
        }

        private void RefreshAllViews()
        {
            RefreshDashboard();
            RefreshMyBookings();
            RefreshQueueStatus();
            PopulateProfileData();
        }

        private void RefreshDashboard()
        {
            //if (currentBeneficiary == null) return;
            string currentId = currentBeneficiary != null ? currentBeneficiary.IdNumber : "";
            // Retrieve latest booking for current user
            var latestBooking = BookingStore.Bookings
                //.Where(b => b.BeneficiaryId == currentBeneficiary.IdNumber)
                .Where(b => string.IsNullOrEmpty(currentId) || b.BeneficiaryId == currentId)
                .OrderByDescending(b => b.Date)
                .FirstOrDefault();

            if (latestBooking != null)
            {
                lblUpcomingBooking.Text = $"{latestBooking.ServiceName} on {latestBooking.Date} at {latestBooking.Time}";
                lblQueueNumber.Text = string.IsNullOrEmpty(latestBooking.QueueNumber) ? "Q-000" : latestBooking.QueueNumber;
                lblStatus.Text = string.IsNullOrEmpty(latestBooking.Status) ? "Waiting" : latestBooking.Status;
            }
            else
            {
                lblUpcomingBooking.Text = "No Upcoming Booking";
                lblQueueNumber.Text = "Q-000";
                lblQueueStatus.Text = "Waiting";
            }
        }

        private void RefreshMyBookings()
        {

            if (dgvMyBooking == null) return;
            if (BookingStore.Bookings == null)
            {
                BookingStore.Bookings = new List<Booking>();
            }
            if (BookingStore.Bookings.Count == 0)
            {
                BookingStore.Bookings.Add(new Booking
                {
                    Reference = "REF" + new Random().Next(1000, 9999),
                    //BeneficiaryId = currentBeneficiary?.IdNumber ?? "12345",
                    //BeneficiaryName = currentBeneficiary?.FullName ?? "Guest",
                    BeneficiaryId = txtIDNumber.Text.Trim(),
                    BeneficiaryName = txtFullName.Text.Trim(),
                    ServiceName = cmbServiceRequired.SelectedItem?.ToString() ?? "General",
                    CentreName = cmbServiceCentre.SelectedItem?.ToString() ?? "Johannesburg Central",
                    Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                    Time = cmbTimeSlot.SelectedItem?.ToString() ?? "09:30",
                    Status = "Booked",
                    QueueNumber = "Q-" + new Random().Next(100, 999)
                });
            }
            MessageBox.Show($"Total bookings in memory: {BookingStore.Bookings.Count}", "Debug Info");
            string currentId = currentBeneficiary?.IdNumber ?? "";

            DataTable dt = new DataTable();
            dt.Columns.Add("Reference");
            dt.Columns.Add("ServiceName");
            dt.Columns.Add("CentreName");
            dt.Columns.Add("Date");
            dt.Columns.Add("Status");

            foreach (var b in BookingStore.Bookings)
            {
                dt.Rows.Add(b.Reference, b.ServiceName, b.CentreName, b.Date, b.Status);
            }
            

            dgvMyBooking.DataSource = null;
            
            dgvMyBooking.AutoGenerateColumns = true;
                dgvMyBooking.DataSource = dt;
                
            
        }

        private void RefreshQueueStatus()
        {
            string currentId = currentBeneficiary != null ? currentBeneficiary.IdNumber : "";
            //if (currentBeneficiary == null) return;

            var activeBooking = BookingStore.Bookings
                .FirstOrDefault(b => (string.IsNullOrEmpty(currentId) || b.BeneficiaryId == currentId) && b.Status == "Checked In");

            if (activeBooking != null)
            {
                lblQueueNumber.Text = activeBooking.QueueNumber;
                lblEstimatedWaitTitle.Text = "";
                lblPeopleAhead.Text = "";
                lblQueueStatus.Text = activeBooking.Status;
            }
            else
            {
                lblQueueNumber.Text = "Q-000";
                lblEstimatedWaitTitle.Text = "0 Minutes";
                lblPeopleAhead.Text = "0";
                lblQueueStatus.Text = "Waiting";
            }
            
        }

        private void PopulateProfileData()
        {
            if (currentBeneficiary != null)
            {
                txtFullName.Text = currentBeneficiary.Name;
                txtLastName.Text = currentBeneficiary.Surname;
                txtIDNumber.Text = currentBeneficiary.IdNumber;
                txtPhoneNumber.Text = currentBeneficiary.Cell;
                txtEmailAddress.Text = currentBeneficiary.Email;
                cmbPreferredServiceCentre.Text = currentBeneficiary.PreferredCentre;

                SetProfileFieldsReadOnly(true);
            }
        }

        private void SetProfileFieldsReadOnly(bool readOnly)
        {
            txtFullName.ReadOnly = readOnly;
            txtLastName.ReadOnly = readOnly;
            txtIDNumber.ReadOnly = true; // Immutable primary key
            txtPhoneNumber.ReadOnly = readOnly;
            txtEmailAddress.ReadOnly = readOnly;
            cmbPreferredServiceCentre.Enabled = !readOnly;
            btnSaveChanges.Enabled = !readOnly;
        }

        #endregion

        #region User Actions & Event Handlers

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (cmbServiceCentre.SelectedIndex == -1 || cmbServiceRequired.SelectedIndex == -1 || cmbTimeSlot.SelectedIndex == -1)


            {
                MessageBox.Show("Please select a centre, service, and time slot.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Booking newBooking = new Booking
            {
                Reference = "REF" + new Random().Next(1000, 9999),
                //BeneficiaryId = currentBeneficiary != null ? currentBeneficiary.IdNumber : "UNKNOWN",
                //BeneficiaryName = currentBeneficiary != null ? currentBeneficiary.FullName : "Guest",
                BeneficiaryId = txtIDNumber.Text.Trim(),
                BeneficiaryName = txtFullName.Text.Trim(),
                ServiceName = cmbServiceRequired.SelectedItem?.ToString() ?? "General",
                CentreName = cmbServiceCentre.SelectedItem?.ToString() ?? "Johannesburg",
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                Time = cmbTimeSlot.SelectedItem?.ToString() ?? "09:30",
                Status = "Booked",
                QueueNumber = "Q-" + new Random().Next(100, 999)
            };

            //BookingStore.Bookings.Add(newBooking);
            //FileManager.SaveBooking(newBooking);
            List<Booking> currentBookings = FileManager.LoadBookings();
            currentBookings.Add(newBooking);
            FileManager.SaveAllBookings(currentBookings);

            MessageBox.Show($"Booking confirmed successfully! Reference: {newBooking.Reference}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            RefreshAllViews();
            pnlMyBooking.BringToFront();
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            SetProfileFieldsReadOnly(false);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (currentBeneficiary != null)
            {
                currentBeneficiary.Name = txtFullName.Text.Trim();
                currentBeneficiary.Surname = txtLastName.Text.Trim();
                currentBeneficiary.Cell = txtPhoneNumber.Text.Trim();
                currentBeneficiary.Email = txtEmailAddress.Text.Trim();
                currentBeneficiary.PreferredCentre = cmbPreferredServiceCentre.Text;

                List<Beneficiary> beneficiaries = FileManager.LoadBeneficiaries();
                int index = beneficiaries.FindIndex(b => b.IdNumber == currentBeneficiary.IdNumber);
                if (index != -1)
                {
                    beneficiaries[index] = currentBeneficiary;
                }

                MessageBox.Show("Profile details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetProfileFieldsReadOnly(true);
            }
        }

        #endregion



        //private void cmbTimeSlot_Click(object sender, EventArgs e)
        //{
        //    cmbTimeSlot.AddRange(
        //      "08:00 AM", "09:30 AM", "11:00 AM", "01:30 PM", "03:00 PM"
        //  );
        //}

        //private void cmbServiceRequired_Click(object sender, EventArgs e)
        //{
        //    cmbServiceRequired.AddRange("New Grant application", "Existing grant enquiry", "Grant information update",
        //          "Payment enquiry", "Document submission");
        //}
    }
}




