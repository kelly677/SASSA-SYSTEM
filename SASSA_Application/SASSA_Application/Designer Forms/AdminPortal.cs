using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SASSA_Application.Designer_Forms
{
    public partial class AdminPortal : Form
    {
        private string loggedInName;
        private bool isEditing = false;
        private bool isEditingCentre = false;
        private bool isEditingSlot = false;

        public AdminPortal(string name)
        {
            InitializeComponent();
            this.loggedInName = name;
        }

        public AdminPortal()
        {
            InitializeComponent();
            this.loggedInName = "Guest";
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private void AdminPortal_Load_1(object sender, EventArgs e)
        {
            lblUserName.Text = "👤 " + loggedInName;
            pnlAdminDashboard.BringToFront();

            LoadCentresDropdown();
            LoadCentresIntoServiceDropdown();
            LoadProvinces();
            LoadCentresGrid();
            LoadBookingsGrid();
            LoadServicesGrid();
            LoadCentresForSlotsDropdown();
            LoadSlotsGrid();

            RefreshAdminDashboardData();
        }
        private void LoadDemandChart()
        {
            // 1. Clear the chart and any default dummy data
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; // Optional: removes vertical grid lines
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // 2. Create a new series for the bars
            Series series = new Series("Demand");
            series.ChartType = SeriesChartType.Column; // Use Column for vertical bars
            series.IsValueShownAsLabel = true;         // Shows the number on top of the bar
            series.LabelForeColor = Color.Black;
            series.Color = Color.FromArgb(37, 99, 235); // SASSA Blue

            // 3. Read the bookings from the file
            List<Booking> allBookings = FileManager.LoadBookings();

            // 4. Group by service and count them
            var serviceCounts = allBookings
                .GroupBy(b => b.ServiceName)
                .Select(g => new { Service = g.Key, Count = g.Count() })
                .ToList();

            // 5. Add the data to the chart
            if (serviceCounts.Count == 0)
            {
                series.Points.AddXY("No Data", 0);
            }
            else
            {
                foreach (var item in serviceCounts)
                {
                    series.Points.AddXY(item.Service, item.Count);
                }
            }

            // 6. Add the series back to the chart
            chart1.Series.Add(series);
        }

        // ============================================================
        // LOAD HELPERS
        // ============================================================
        private void LoadCentresDropdown()
        {
            cmbCentre.Items.Clear();
            cmbServiceCentre.Items.Clear();

            if (!File.Exists("Centres.txt")) return;

            foreach (string line in File.ReadAllLines("Centres.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 3) continue;

                cmbCentre.Items.Add(parts[0]);
                cmbServiceCentre.Items.Add(parts[0]);
            }
        }

        private void LoadCentresIntoServiceDropdown()
        {
            if (cmbCentreName == null) return;

            cmbCentreName.Items.Clear();
            if (!File.Exists("Centres.txt")) return;

            foreach (string line in File.ReadAllLines("Centres.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 1) cmbCentreName.Items.Add(parts[0]);
            }
        }

        private void LoadProvinces()
        {
            cmbProvinces.Items.Clear();
            cmbProvinces.AddRange(new object[]
            {
                "Eastern Cape", "Free State", "Gauteng", "KwaZulu-Natal",
                "Limpopo", "Mpumalanga", "North West", "Northern Cape", "Western Cape"
            });
        }

        private void LoadCentresGrid()
        {
            dgvCentres.Rows.Clear();
            if (!File.Exists("Centres.txt")) return;

            foreach (string line in File.ReadAllLines("Centres.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');

                // Format: Name|Province|Address
                if (parts.Length >= 3)
                {
                    dgvCentres.Rows.Add(parts[0], parts[1], parts[2]);
                }
            }
        }
        private void LoadSlotsGrid()
        {
            dgvSlots.Rows.Clear();
            if (!File.Exists("Slots.txt")) return;

            foreach (string line in File.ReadAllLines("Slots.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');

                // Format: Centre|Date|TimeSlot|Capacity|Booked
                if (parts.Length >= 5)
                {
                    // Convert yyyy-MM-dd to dd/MM/yyyy for display
                    DateTime parsedDate;
                    string gridDate = DateTime.TryParseExact(parts[1], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate)
                                      ? parsedDate.ToString("dd/MM/yyyy")
                                      : parts[1];

                    dgvSlots.Rows.Add(parts[0], gridDate, parts[2], parts[3]);
                }
            }
        }

        private void LoadCentresForSlotsDropdown()
        {
            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.AddRange(new object[] {
                "08:00 AM - 09:00 AM", "09:00 AM - 10:00 AM", "10:00 AM - 11:00 AM",
                "11:00 AM - 12:00 PM", "12:00 PM - 01:00 PM", "01:00 PM - 02:00 PM", "02:00 PM - 03:00 PM"
            });

            cmbCapacity.Items.Clear();
            cmbCapacity.AddRange(new object[] { "5", "10", "15", "20", "25" });
        }

        private void LoadBookingsGrid()
        {
            dgvTotalBookings.Rows.Clear();
            List<Booking> bookings = FileManager.LoadBookings();

            foreach (Booking b in bookings)
            {
                dgvTotalBookings.Rows.Add(b.Reference, b.BeneficiaryName, b.ServiceName,
                                           b.CentreName, b.Date, b.Status);
            }
        }

        private void LoadStaff()
        {
            dgvStaffMembers.Rows.Clear();
            if (!File.Exists("Staff.txt")) return;

            foreach (string line in File.ReadAllLines("Staff.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 4) continue;
                dgvStaffMembers.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
            }
        }

        private void LoadServicesGrid()
        {
            dgvServices.Rows.Clear();
            if (!File.Exists("Services.txt")) return;

            foreach (string line in File.ReadAllLines("Services.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 4) continue;

                // Format: Centre|Service|Description|Status
                dgvServices.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
            }
        }

        // ============================================================
        // SIDEBAR NAVIGATION
        // ============================================================
        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            pnlAdminDashboard.BringToFront();
            RefreshAdminDashboardData();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            pnlServices.BringToFront();
            LoadCentresIntoServiceDropdown();
            LoadServicesGrid();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            pnlStaff.BringToFront();
            LoadCentresDropdown();
            LoadStaff();
        }

        private void btnCentres_Click(object sender, EventArgs e)
        {
            pnlCentres.BringToFront();
            LoadCentresGrid();
            LoadCentresForSlotsDropdown();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
            LoadBookingsGrid();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlReports.BringToFront();
            LoadDemandChart();
        }

        // ============================================================
        // ADD STAFF
        // ============================================================
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string centre = cmbCentre.SelectedItem != null ? cmbCentre.SelectedItem.ToString() : "";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(centre))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();
            string staffNumber = "";
            for (int i = 0; i < 13; i++) staffNumber += rnd.Next(0, 10).ToString();

            string line = name + "|" + staffNumber + "|" + centre + "|" + email;
            File.AppendAllText("Staff.txt", line + Environment.NewLine);

            dgvStaffMembers.Rows.Add(name, staffNumber, centre, email);

            MessageBox.Show("Staff member added!\n\nFull Name: " + name + "\nStaff Number: " + staffNumber + "\nCentre: " + centre + "\nEmail: " + email, "Staff Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtName.Text = "";
            txtEmail.Text = "";
            cmbCentre.SelectedItem = null;
        }

        // ============================================================
        // ADD/EDIT CENTRE
        // ============================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditingCentre)
            {
                string oldName = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();
                string newName = txtNameCentre.Text.Trim();
                string newProv = cmbProvinces.SelectedItem.ToString();
                string newAddr = txtAddress.Text.Trim();

                // 1. Update Centres.txt
                string[] lines = File.ReadAllLines("Centres.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    if (parts[0] == oldName)
                    {
                        lines[i] = newName + "|" + newProv + "|" + newAddr;
                        break;
                    }
                }
                File.WriteAllLines("Centres.txt", lines);

                // 2. If the name changed, update Slots.txt too
                if (oldName != newName && File.Exists("Slots.txt"))
                {
                    string[] slotLines = File.ReadAllLines("Slots.txt");
                    for (int i = 0; i < slotLines.Length; i++)
                    {
                        string[] parts = slotLines[i].Split('|');
                        if (parts[0] == oldName)
                        {
                            parts[0] = newName;
                            slotLines[i] = string.Join("|", parts);
                        }
                    }
                    File.WriteAllLines("Slots.txt", slotLines);
                }

                // 3. Update the Grid and UI
                dgvCentres.SelectedRows[0].Cells[0].Value = newName;
                dgvCentres.SelectedRows[0].Cells[1].Value = newProv;
                dgvCentres.SelectedRows[0].Cells[2].Value = newAddr;

                btnSave.Text = "💾 Save Centre";
                isEditingCentre = false;
                txtNameCentre.Text = ""; cmbProvinces.SelectedItem = null; txtAddress.Text = "";

                MessageBox.Show("Centre updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Stop here so it doesn't create a new one
            }
            // ... the rest of your normal Save Centre code ...
            string name = txtNameCentre.Text.Trim();
            string province = cmbProvinces.SelectedItem?.ToString() ?? "";
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all Centre details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate centre
            if (File.Exists("Centres.txt"))
            {
                foreach (string line in File.ReadAllLines("Centres.txt"))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 1 && parts[0].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This centre already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Save to text file
            File.AppendAllText("Centres.txt", name + "|" + province + "|" + address + Environment.NewLine);

            // Update Left Grid
            dgvCentres.Rows.Add(name, province, address);

            // Update Dropdowns (Only add if it's not there)
            if (!cmbCentre.Items.Contains(name)) cmbCentre.Items.Add(name);
            if (cmbCentreName != null && !cmbCentreName.Items.Contains(name)) cmbCentreName.Items.Add(name);
            if (!cmbServiceCentre.Items.Contains(name)) cmbServiceCentre.Items.Add(name);

            MessageBox.Show("Centre saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear fields
            txtNameCentre.Text = "";
            cmbProvinces.SelectedItem = null;
            txtAddress.Text = "";



        }

        // ============================================================
        // DASHBOARD REFRESH
        // ============================================================
        private void RefreshAdminDashboardData()
        {
            List<Booking> allBookings = FileManager.LoadBookings();

            lblBookedTotal.Text = allBookings.Count(b => b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)).ToString();
            lblOnQue.Text = allBookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)).ToString();
            lblCompleted.Text = allBookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).ToString();
            lblNoshow.Text = allBookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase) || b.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase)).ToString();
        }

        // ============================================================
        // LOGOUT & STUBS
        // ============================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new frmWelcomePage().Show();
                this.Close();
            }
        }

        private void pnlReports_Paint(object sender, PaintEventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void cmbServiceCentre_Click(object sender, EventArgs e) { }
        private void pnlAdminDashboard_Paint(object sender, PaintEventArgs e) { }

        // ============================================================
        // EDIT & DELETE CENTRE
        // ============================================================
        private void btnEditSlots_Click(object sender, EventArgs e)
        {

            // --- EDIT A CENTRE ---
            if (dgvCentres.SelectedRows.Count > 0)
            {
                // Load the data from the left grid into the left textboxes
                txtNameCentre.Text = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();
                cmbProvinces.SelectedItem = dgvCentres.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dgvCentres.SelectedRows[0].Cells[2].Value.ToString();

                btnSave.Text = "Update Centre";
                isEditingCentre = true;
                isEditingSlot = false;
            }
            // --- EDIT A SLOT ---
            else if (dgvSlots.SelectedRows.Count > 0)
            {
                // Load the data from the right grid into the right dropdowns
                cmbTimeSlot.SelectedItem = dgvSlots.SelectedRows[0].Cells[2].Value.ToString();
                cmbCapacity.SelectedItem = dgvSlots.SelectedRows[0].Cells[3].Value.ToString();

                // Load the date
                DateTime parsedDate;
                if (DateTime.TryParse(dgvSlots.SelectedRows[0].Cells[1].Value.ToString(), out parsedDate))
                {
                    dtpDate.Value = parsedDate;
                }

                btnAddSlot.Text = "Update Slot";
                isEditingSlot = true;
                isEditingCentre = false;
            }
            else
            {
                MessageBox.Show("Please select a Centre or a Slot from the grids to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            // ============================================================
            // 1. DELETE A CENTRE (From the Left Grid)
            // ============================================================
            if (dgvCentres.SelectedRows.Count > 0)
            {
                string centreToDelete = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the Centre '{centreToDelete}'?\n\nThis will also delete ALL its time slots.",
                                                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    // Remove from Centres.txt
                    if (File.Exists("Centres.txt"))
                    {
                        List<string> lines = new List<string>();
                        foreach (string line in File.ReadAllLines("Centres.txt"))
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            if (line.Split('|')[0] != centreToDelete) lines.Add(line);
                        }
                        File.WriteAllLines("Centres.txt", lines);
                    }

                    // Remove from Slots.txt (Clean up orphaned slots)
                    if (File.Exists("Slots.txt"))
                    {
                        List<string> slotLines = new List<string>();
                        foreach (string line in File.ReadAllLines("Slots.txt"))
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            if (line.Split('|')[0] != centreToDelete) slotLines.Add(line);
                        }
                        File.WriteAllLines("Slots.txt", slotLines);
                    }

                    // Remove from both grids
                    dgvCentres.Rows.Remove(dgvCentres.SelectedRows[0]);
                    for (int i = dgvSlots.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dgvSlots.Rows[i].Cells[0].Value.ToString() == centreToDelete)
                            dgvSlots.Rows.RemoveAt(i);
                    }

                    MessageBox.Show("Centre and its slots deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // ============================================================
            // 2. DELETE A SLOT (From the Right Grid)
            // ============================================================
            else if (dgvSlots.SelectedRows.Count > 0)
            {
                string centre = dgvSlots.SelectedRows[0].Cells[0].Value.ToString();
                string gridDate = dgvSlots.SelectedRows[0].Cells[1].Value.ToString();
                string slotToDelete = dgvSlots.SelectedRows[0].Cells[2].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Delete the {slotToDelete} slot for {centre}?",
                                                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    // Remove from Slots.txt
                    if (File.Exists("Slots.txt"))
                    {
                        List<string> lines = new List<string>();
                        foreach (string line in File.ReadAllLines("Slots.txt"))
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            string[] parts = line.Split('|');
                            // We match by Centre and TimeSlot to avoid date format mismatch issues
                            if (!(parts[0] == centre && parts[2] == slotToDelete))
                            {
                                lines.Add(line);
                            }
                        }
                        File.WriteAllLines("Slots.txt", lines);
                    }

                    // Remove from Grid
                    dgvSlots.Rows.Remove(dgvSlots.SelectedRows[0]);

                    MessageBox.Show("Slot deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // ============================================================
            // 3. NOTHING SELECTED
            // ============================================================
            else
            {
                MessageBox.Show("Please click on a row in either grid to select what you want to delete.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // ============================================================
        // ADD  SERVICE
        // ============================================================
        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cmbCentreName == null || cmbCentreName.SelectedItem == null)
            {
                MessageBox.Show("Please select the Centre this service belongs to.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCentre = cmbCentreName.SelectedItem.ToString();
            string serviceName = txtService.Text.Trim();
            string description = txtDescribe.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter both a Service Name and a Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (File.Exists("Services.txt"))
            {
                foreach (string line in File.ReadAllLines("Services.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length >= 2 && parts[0] == selectedCentre && parts[1].Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This centre already offers this service.", "Duplicate Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            File.AppendAllText("Services.txt", selectedCentre + "|" + serviceName + "|" + description + "|Active" + Environment.NewLine);
            dgvServices.Rows.Add(selectedCentre, serviceName, description, "Active");

            MessageBox.Show("Service added successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtService.Text = "";
            txtDescribe.Text = "";
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0) return;

            string selectedCentre = dgvServices.SelectedRows[0].Cells[0].Value.ToString();
            string serviceName = dgvServices.SelectedRows[0].Cells[1].Value.ToString();

            if (MessageBox.Show($"Delete {serviceName} at {selectedCentre}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dgvServices.Rows.Remove(dgvServices.SelectedRows[0]);

                if (File.Exists("Services.txt"))
                {
                    List<string> newLines = new List<string>();
                    foreach (string line in File.ReadAllLines("Services.txt"))
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length >= 2 && !(parts[0] == selectedCentre && parts[1] == serviceName))
                        {
                            newLines.Add(line);
                        }
                    }
                    File.WriteAllLines("Services.txt", newLines);
                }
            }
        }

        private void btnUnavailable_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service from the grid first.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Get the details of the selected service
            string selectedCentre = dgvServices.SelectedRows[0].Cells[0].Value.ToString();
            string serviceName = dgvServices.SelectedRows[0].Cells[1].Value.ToString();
            string currentStatus = dgvServices.SelectedRows[0].Cells[3].Value.ToString();

            // 3. If it's already inactive, don't do anything
            if (currentStatus == "Inactive")
            {
                MessageBox.Show("This service is already marked as inactive.", "Notice",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Update the UI Grid
            dgvServices.SelectedRows[0].Cells[3].Value = "Inactive";

            // 5. Update the text file
            if (File.Exists("Services.txt"))
            {
                string[] lines = File.ReadAllLines("Services.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    // Format: 0=Centre, 1=ServiceName, 2=Description, 3=Status
                    if (parts.Length >= 4 && parts[0] == selectedCentre && parts[1] == serviceName)
                    {
                        parts[3] = "Inactive";
                        lines[i] = string.Join("|", parts);
                        break;
                    }
                }
                File.WriteAllLines("Services.txt", lines);
            }

            MessageBox.Show("Service marked as inactive. Beneficiaries will no longer see it in their dropdown.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearchB_Click(object sender, EventArgs e)
        {
            string query = txtSearching.Text.Trim();

            dgvTotalBookings.Rows.Clear();

            List<Booking> bookings = FileManager.LoadBookings();
            bool found = false;

            foreach (Booking b in bookings)
            {
                // Matches Reference, Name, ID, Service, Centre, or Status
                bool match = string.IsNullOrEmpty(query)
                    || b.Reference.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryName.ToLower().Contains(query.ToLower())
                    || b.BeneficiaryId.Contains(query)
                    || b.ServiceName.ToLower().Contains(query.ToLower())
                    || b.CentreName.ToLower().Contains(query.ToLower())
                    || b.Status.ToLower().Contains(query.ToLower());

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
        }

        private void pnlCentres_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Booking> allBookings = FileManager.LoadBookings();

            // Update the top cards (Existing code)
            lblTotalBooked.Text = allBookings.Count.ToString();
            lblComplete.Text = allBookings.Count(b => b.Status == "Completed").ToString();
            lblNshow.Text = allBookings.Count(b => b.Status == "No-Show").ToString();
            lblCanceled.Text = allBookings.Count(b => b.Status == "Cancelled").ToString();

            // Update the chart (New code)
            LoadDemandChart();
        }

        private void btnAddSlot_Click(object sender, EventArgs e)
        {

            if (isEditingSlot)
            {
                // Renamed variables to avoid conflict with the rest of the method
                string editCentre = dgvSlots.SelectedRows[0].Cells[0].Value.ToString();
                string editOldDate = dgvSlots.SelectedRows[0].Cells[1].Value.ToString();
                string editOldSlot = dgvSlots.SelectedRows[0].Cells[2].Value.ToString();

                string editNewDate = dtpDate.Value.ToString("yyyy-MM-dd");
                string editNewGridDate = dtpDate.Value.ToString("dd/MM/yyyy");
                string editNewSlot = cmbTimeSlot.SelectedItem.ToString();
                string editNewCap = cmbCapacity.SelectedItem.ToString();

                // 1. Update Slots.txt
                string[] editLines = File.ReadAllLines("Slots.txt");
                for (int i = 0; i < editLines.Length; i++)
                {
                    string[] parts = editLines[i].Split('|');

                    // We have to match the old Date as dd/MM/yyyy to the file's yyyy-MM-dd format
                    // To keep it simple, let's just match the Centre and the Old Slot name
                    if (parts[0] == editCentre && parts[2] == editOldSlot)
                    {
                        // Keep the existing booked count (parts[4])
                        editLines[i] = editCentre + "|" + editNewDate + "|" + editNewSlot + "|" + editNewCap + "|" + parts[4];
                        break;
                    }
                }
                File.WriteAllLines("Slots.txt", editLines);

                // 2. Update the Grid and UI
                dgvSlots.SelectedRows[0].Cells[1].Value = editNewGridDate;
                dgvSlots.SelectedRows[0].Cells[2].Value = editNewSlot;
                dgvSlots.SelectedRows[0].Cells[3].Value = editNewCap;

                btnAddSlot.Text = "➕ Add Slot";
                isEditingSlot = false;
                cmbTimeSlot.SelectedItem = null;
                cmbCapacity.SelectedItem = null;

                MessageBox.Show("Slot updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Stop here so it doesn't create a duplicate
            }
            // 1. Check if a Centre is selected in the left grid
            if (dgvCentres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click on a Centre in the left grid first to select it.", "No Centre Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate Date, Time, and Capacity
            if (cmbTimeSlot.SelectedItem == null || cmbCapacity.SelectedItem == null)
            {
                MessageBox.Show("Please select a Time Slot and Capacity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Block weekends
            if (dtpDate.Value.DayOfWeek == DayOfWeek.Saturday || dtpDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("You cannot create slots for weekends.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Get the Centre Name from the selected row in the grid
            string centre = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();

            string timeSlot = cmbTimeSlot.SelectedItem.ToString();
            string capacity = cmbCapacity.SelectedItem.ToString();
            string fileDate = dtpDate.Value.ToString("yyyy-MM-dd");
            string gridDate = dtpDate.Value.ToString("dd/MM/yyyy");

            // 5. Check for duplicates in Slots.txt
            if (File.Exists("Slots.txt"))
            {
                foreach (string line in File.ReadAllLines("Slots.txt"))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 4 && parts[0] == centre && parts[1] == fileDate && parts[2] == timeSlot)
                    {
                        MessageBox.Show("This exact slot already exists for this centre.", "Duplicate Slot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // 6. Save to Slots.txt (Format: Centre|Date|TimeSlot|Capacity|Booked)
            File.AppendAllText("Slots.txt", centre + "|" + fileDate + "|" + timeSlot + "|" + capacity + "|0" + Environment.NewLine);

            // 7. Update Right Grid
            dgvSlots.Rows.Add(centre, gridDate, timeSlot, capacity);

            MessageBox.Show("Slot added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 8. Clear only time and capacity (keep the row selected so you can add the next slot quickly!)
            cmbTimeSlot.SelectedItem = null;
            cmbCapacity.SelectedItem = null;
        }

        private void brnDeleteStaff_Click(object sender, EventArgs e)
        {
        
            // 1. Make sure a row is selected
            if (dgvStaffMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff member from the grid to delete.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Get the Staff Number and Name from the selected row
            // (Assuming Column 0 is Name and Column 1 is Staff Number based on your screenshot)
            string staffName = dgvStaffMembers.SelectedRows[0].Cells[0].Value.ToString();
            string staffNumber = dgvStaffMembers.SelectedRows[0].Cells[1].Value.ToString();

            // 3. Ask for confirmation
            DialogResult answer = MessageBox.Show($"Are you sure you want to delete the account for {staffName}?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                // 4. Remove from Staff.txt
                if (File.Exists("Staff.txt"))
                {
                    List<string> newLines = new List<string>();
                    foreach (string line in File.ReadAllLines("Staff.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split('|');
                        // parts[1] is the Staff Number. Keep the line ONLY if it doesn't match.
                        if (parts.Length >= 2 && parts[1] != staffNumber)
                        {
                            newLines.Add(line);
                        }
                    }
                    File.WriteAllLines("Staff.txt", newLines);
                }

                // 5. Remove from the DataGridView
                dgvStaffMembers.Rows.Remove(dgvStaffMembers.SelectedRows[0]);

                MessageBox.Show("Staff account deleted successfully.", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }
}