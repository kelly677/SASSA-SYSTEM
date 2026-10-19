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
                if (parts.Length < 3) continue;

                dgvCentres.Rows.Add(parts[0], parts[1], parts[2], "-", "-", "-");
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
            if (isEditing)
            {
                string newName = txtNameCentre.Text.Trim();
                string newAddress = txtAddress.Text.Trim();
                string newProvince = cmbProvinces.SelectedItem != null ? cmbProvinces.SelectedItem.ToString() : "";
                string newGridDate = dtpDate.Value.ToString("dd/MM/yyyy");
                string newFileDate = dtpDate.Value.ToString("yyyy-MM-dd");
                string newSlot = cmbTimeSlot.SelectedItem != null ? cmbTimeSlot.SelectedItem.ToString() : "-";
                string newCapacity = cmbCapacity.SelectedItem != null ? cmbCapacity.SelectedItem.ToString() : "-";

                if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newProvince) || string.IsNullOrWhiteSpace(newAddress))
                {
                    MessageBox.Show("Please fill in all text fields to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string oldName = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();

                dgvCentres.SelectedRows[0].Cells[0].Value = newName;
                dgvCentres.SelectedRows[0].Cells[1].Value = newProvince;
                dgvCentres.SelectedRows[0].Cells[2].Value = newAddress;
                dgvCentres.SelectedRows[0].Cells[3].Value = newGridDate;
                dgvCentres.SelectedRows[0].Cells[4].Value = newSlot;
                dgvCentres.SelectedRows[0].Cells[5].Value = newCapacity;

                if (File.Exists("Centres.txt"))
                {
                    string[] lines = File.ReadAllLines("Centres.txt");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split('|');
                        if (parts.Length >= 1 && parts[0] == oldName)
                        {
                            lines[i] = newName + "|" + newProvince + "|" + newAddress;
                            break;
                        }
                    }
                    File.WriteAllLines("Centres.txt", lines);
                }

                if (File.Exists("Slots.txt") && newSlot != "-")
                {
                    string[] slotLines = File.ReadAllLines("Slots.txt");
                    bool slotUpdated = false;

                    for (int i = 0; i < slotLines.Length; i++)
                    {
                        string[] parts = slotLines[i].Split('|');
                        if (parts.Length >= 6 && parts[0] == oldName)
                        {
                            int capacityInt = int.Parse(newCapacity);
                            int booked = int.Parse(parts[4]);
                            parts[0] = newName; parts[1] = newSlot; parts[2] = newCapacity; parts[3] = newFileDate;
                            parts[5] = (capacityInt - booked).ToString();
                            slotLines[i] = string.Join("|", parts);
                            slotUpdated = true;
                            break;
                        }
                    }

                    if (!slotUpdated)
                    {
                        int capacityInt = int.Parse(newCapacity);
                        File.AppendAllText("Slots.txt", newName + "|" + newSlot + "|" + newCapacity + "|" + newFileDate + "|0|" + capacityInt + Environment.NewLine);
                    }
                    else { File.WriteAllLines("Slots.txt", slotLines); }
                }

                if (oldName != newName)
                {
                    int index = cmbCentre.Items.IndexOf(oldName);
                    if (index != -1) cmbCentre.Items[index] = newName;
                    if (cmbCentreName.Items.IndexOf(oldName) != -1) cmbCentreName.Items[cmbCentreName.Items.IndexOf(oldName)] = newName;
                }

                MessageBox.Show("Centre updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Text = "💾 Save";
                isEditing = false;
                txtNameCentre.Text = ""; cmbProvinces.SelectedItem = null; txtAddress.Text = "";
                cmbTimeSlot.SelectedItem = null; cmbCapacity.SelectedItem = null;
                dtpDate.Value = DateTime.Now;
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtNameCentre.Text))
            {
                string centreName = txtNameCentre.Text.Trim();
                string address = txtAddress.Text.Trim();
                string province = cmbProvinces.SelectedItem != null ? cmbProvinces.SelectedItem.ToString() : "";
                string gridDate = dtpDate.Value.ToString("dd/MM/yyyy");
                string slot = cmbTimeSlot.SelectedItem != null ? cmbTimeSlot.SelectedItem.ToString() : "-";
                string capacity = cmbCapacity.SelectedItem != null ? cmbCapacity.SelectedItem.ToString() : "-";

                if (string.IsNullOrWhiteSpace(centreName) || string.IsNullOrWhiteSpace(province) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please fill in all fields to create a centre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (File.Exists("Centres.txt"))
                {
                    foreach (string line in File.ReadAllLines("Centres.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length >= 1 && parts[0].Equals(centreName, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("A centre with this name already exists.", "Duplicate Centre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                File.AppendAllText("Centres.txt", centreName + "|" + province + "|" + address + Environment.NewLine);

                dgvCentres.Rows.Add(centreName, province, address, gridDate, slot, capacity);

                cmbCentre.Items.Add(centreName);
                if (cmbCentreName != null) cmbCentreName.Items.Add(centreName);
                cmbServiceCentre.Items.Add(centreName);

                MessageBox.Show("Centre added successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNameCentre.Text = ""; cmbProvinces.SelectedItem = null; txtAddress.Text = "";
                return;
            }

            if (cmbCentre.SelectedItem != null)
            {
                if (dtpDate.Value.DayOfWeek == DayOfWeek.Saturday || dtpDate.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("You cannot create slots for weekends.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string centre = cmbCentre.SelectedItem.ToString();
                string slot = cmbTimeSlot.SelectedItem != null ? cmbTimeSlot.SelectedItem.ToString() : "";
                string capacityStr = cmbCapacity.SelectedItem != null ? cmbCapacity.SelectedItem.ToString() : "";
                string fileDate = dtpDate.Value.ToString("yyyy-MM-dd");
                string gridDate = dtpDate.Value.ToString("dd/MM/yyyy");

                if (string.IsNullOrWhiteSpace(centre) || string.IsNullOrWhiteSpace(slot) || string.IsNullOrWhiteSpace(capacityStr))
                {
                    MessageBox.Show("Please select a centre, time slot and capacity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int capacity = int.Parse(capacityStr);
                File.AppendAllText("Slots.txt", centre + "|" + slot + "|" + capacity + "|" + fileDate + "|0|" + capacity + Environment.NewLine);

                dgvCentres.Rows.Add(centre, "-", "-", gridDate, slot, capacity);

                MessageBox.Show("Slot added successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbCentre.SelectedItem = null; cmbTimeSlot.SelectedItem = null; cmbCapacity.SelectedItem = null;
                return;
            }

            MessageBox.Show("Please enter a new centre name OR select an existing centre to add a slot.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvCentres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a centre from the grid to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string centreName = dgvCentres.SelectedRows[0].Cells[0].Value?.ToString();
            string province = dgvCentres.SelectedRows[0].Cells[1].Value?.ToString();
            string address = dgvCentres.SelectedRows[0].Cells[2].Value?.ToString();
            string gridDate = dgvCentres.SelectedRows[0].Cells[3].Value?.ToString();
            string slot = dgvCentres.SelectedRows[0].Cells[4].Value?.ToString();
            string capacity = dgvCentres.SelectedRows[0].Cells[5].Value?.ToString();

            txtNameCentre.Text = centreName;
            txtAddress.Text = address;

            if (province != "-") cmbProvinces.SelectedItem = province;

            if (gridDate != "-")
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(gridDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                    dtpDate.Value = parsedDate;
            }

            if (slot != "-") cmbTimeSlot.SelectedItem = slot;
            if (capacity != "-") cmbCapacity.SelectedItem = capacity;

            btnSave.Text = "💾 Update";
            isEditing = true;

            MessageBox.Show("You can now edit the details in the boxes above and click 'Update' to save.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCentres.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a centre from the grid to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string centreToDelete = dgvCentres.SelectedRows[0].Cells[0].Value.ToString();

            if (MessageBox.Show("Are you sure you want to delete '" + centreToDelete + "'?\n\nThis will also remove all its time slots from the system.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (File.Exists("Centres.txt"))
                {
                    List<string> centreLines = new List<string>();
                    foreach (string line in File.ReadAllLines("Centres.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        if (line.Split('|')[0] != centreToDelete) centreLines.Add(line);
                    }
                    File.WriteAllLines("Centres.txt", centreLines);
                }

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

                dgvCentres.Rows.Remove(dgvCentres.SelectedRows[0]);
                cmbCentre.Items.Remove(centreToDelete);
                if (cmbCentreName != null) cmbCentreName.Items.Remove(centreToDelete);
                if (cmbServiceCentre != null) cmbServiceCentre.Items.Remove(centreToDelete);

                MessageBox.Show("Centre and its slots deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isEditing)
                {
                    isEditing = false; btnSave.Text = "💾 Save";
                    txtNameCentre.Text = ""; cmbProvinces.SelectedItem = null; txtAddress.Text = "";
                    cmbTimeSlot.SelectedItem = null; cmbCapacity.SelectedItem = null;
                }
            }
        }

        // ============================================================
        // ADD & DELETE SERVICE
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
    }
}