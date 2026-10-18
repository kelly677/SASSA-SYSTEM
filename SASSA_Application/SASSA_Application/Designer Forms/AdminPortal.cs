using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class AdminPortal : Form
    {
        private string loggedInName;

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
            LoadProvinces();
            LoadCentresGrid();
            LoadBookingsGrid();
            LoadServicesGrid();
            ApplySidebarStyle();
            LoadCentresForSlotsDropdown();
            LoadSlotsGrid();
            RefreshAdminDashboardData();
        }

        // ============================================================
        // LOAD HELPERS
        // ============================================================
        private void LoadCentresDropdown()
        {
            cmbCentre.Items.Clear();

            if (!File.Exists("Centres.txt")) return;

            foreach (string line in File.ReadAllLines("Centres.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 3) continue;
                cmbCentre.Items.Add(parts[0]);
            }
        }

        private void LoadProvinces()
        {
            cmbProvinces.Items.Clear();
            cmbProvinces.AddRange(new object[]
            {
                "Eastern Cape",
                "Free State",
                "Gauteng",
                "KwaZulu-Natal",
                "Limpopo",
                "Mpumalanga",
                "North West",
                "Northern Cape",
                "Western Cape"
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

                dgvCentres.Rows.Add(parts[0], parts[1], parts[2]);
            }
        }
        private void LoadSlotsGrid()
        {
            dgvCentres.Rows.Clear();
            if (!File.Exists("Slots.txt")) return;

            foreach (string line in File.ReadAllLines("Slots.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 6) continue;
                {
                    dgvCentres.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                }
            }
        }
 
        private void LoadCentresForSlotsDropdown()
        {
            cmbSlotCentre.Items.Clear();
            cmbSlotCentre.Items.Add("Morning (08:00 - 12:00)");
            cmbSlotCentre.Items.Add("Afternoon (13:00 - 16:00)");
            cmbSlotCentre.Items.Add("Full Day");

            cmbCapacity.Items.Clear();
            cmbCapacity.Items.Add("50");
            cmbCapacity.Items.Add("100");
            cmbCapacity.Items.Add("150");
            cmbCapacity.Items.Add("200");
            cmbCapacity.Items.Add("500");
          

            //if (!File.Exists("Centres.txt")) return;

            //foreach  (string line in File.ReadAllLines("Centres.txt") )
            //{
            //    if (string.IsNullOrWhiteSpace(line)) continue;
            //    string[] parts = line.Split('|');
            //    if(parts.Length >= 1)
            //    {
            //        cmbSlotCentre.Items.Add(parts[0].Trim());
            //    }
            //}
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

                // File format: ServiceId|ServiceName|Description|Status
                dgvServices.Rows.Add(parts[1], parts[2], parts[3]);
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
            LoadServicesGrid();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            pnlStaff.BringToFront();
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
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            pnlServices.BringToFront();
            LoadServicesGrid();
        }

        // ============================================================
        // ADD STAFF
        // ============================================================
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();

            string centre = cmbCentre.SelectedItem != null
                            ? cmbCentre.SelectedItem.ToString()
                            : "";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(centre))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate 13-digit staff number
            Random rnd = new Random();
            string staffNumber = "";
            for (int i = 0; i < 13; i++)
            {
                staffNumber += rnd.Next(0, 10).ToString();
            }

            // Save to Staff.txt : Name|StaffNumber|Centre|Email
            string line = name + "|" + staffNumber + "|" + centre + "|" + email;
            File.AppendAllText("Staff.txt", line + Environment.NewLine);

            // Add to grid
            dgvStaffMembers.Rows.Add(name, staffNumber, centre, email);

            MessageBox.Show("Staff member added!\n\n" +
                            "Full Name: " + name + "\n" +
                            "Staff Number: " + staffNumber + "\n" +
                            "Centre: " + centre + "\n" +
                            "Email (password): " + email,
                            "Staff Added",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtName.Text = "";
            txtEmail.Text = "";
            cmbCentre.SelectedItem = null;
        }

        // ============================================================
        // ADD CENTRE
        // ============================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNameCentre.Text))
            {
                string centreName = txtNameCentre.Text.Trim();
                string address = txtAddress.Text.Trim();

                string province = cmbProvinces.SelectedItem != null
                        ? cmbProvinces.SelectedItem.ToString()
                                  : "";

                if (string.IsNullOrWhiteSpace(centreName) ||
                    string.IsNullOrWhiteSpace(province) ||
                    string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate
                if (File.Exists("Centres.txt"))
                {
                    foreach (string line in File.ReadAllLines("Centres.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length >= 1 && parts[0].Equals(centreName, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("A centre with this name already exists.",
                                            "Duplicate Centre",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Save
                string newLine = centreName + "|" + province + "|" + address;
                File.AppendAllText("Centres.txt", newLine + Environment.NewLine);

                // Update grid + dropdown immediately
                dgvCentres.Rows.Add(centreName, province, address, "-", "-", "-");
                cmbCentre.Items.Add(centreName);

                MessageBox.Show("Centre added successfully!", "Saved",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNameCentre.Text = "";
                cmbProvinces.SelectedItem = null;
                txtAddress.Text = "";
            }
            if (cmbCentre.SelectedItem != null)
            {
                string centre =  cmbCentre.SelectedItem.ToString();
                string capacityStr = cmbCapacity.SelectedItem != null ? cmbCapacity.SelectedItem.ToString() : "";
                string slotdate = dtpDate.Value.ToString("dd/MM/yyyy");
                string slot = cmbSlotCentre.SelectedItem != null ? cmbSlotCentre.SelectedItem.ToString() : "";

                if (string.IsNullOrWhiteSpace(centre) || string.IsNullOrWhiteSpace(slot) || string.IsNullOrWhiteSpace(capacityStr))
                {
                    MessageBox.Show("Please select a centre, slot and capacity from the dropdown.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int capacity = int.Parse(capacityStr);
                string slotSelected = slot;
                int booked = 0;
                int available = capacity;

                string slotLine = centre + "|" + slotSelected + "|" + capacity + "|" + slotdate + "|" + booked + "|" + available;
                File.AppendAllText("Slots.txt", slotLine + Environment.NewLine);

                dgvCentres.Rows.Add(centre, "-", "-", slotSelected, capacity, slotdate);

                MessageBox.Show("Slot added successfully!", "Saved",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbCentre.SelectedItem = null;
                cmbSlotCentre.SelectedItem = null;
                cmbCapacity.SelectedItem = null;
                dtpDate.Value = DateTime.Now;
                return;

                MessageBox.Show("Please fill in centre details or slots before saving", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
        }
        // ============================================================
        // ADD SERVICE
        // ============================================================
        private void btnAddService_Click(object sender, EventArgs e)
        {
            string serviceName = txtService.Text.Trim();
            string description = txtDescribe.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate
            if (File.Exists("Services.txt"))
            {
                foreach (string line in File.ReadAllLines("Services.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length >= 2 &&
                        parts[1].Trim().Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("A service with this name already exists.",
                                        "Duplicate Service",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Save with full 4-field format: ServiceId|ServiceName|Description|Status
            string serviceId = "S" + new Random().Next(1000, 9999);
            string newLine = serviceId + "|" + serviceName + "|" + description + "|Active";
            File.AppendAllText("Services.txt", newLine + Environment.NewLine);

            // Update grid immediately
            dgvServices.Rows.Add(serviceName, description, "Active");

            MessageBox.Show("Service added successfully!", "Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtService.Text = "";
            txtDescribe.Text = "";
        }

        // ============================================================
        // SEARCH BOOKINGS
        // ============================================================
        private void btnSearchB_Click(object sender, EventArgs e)
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

        // ============================================================
        // DASHBOARD REFRESH
        // ============================================================
        private void RefreshAdminDashboardData()
        {
            List<Booking> allBookings = FileManager.LoadBookings();

            lblBookedTotal.Text = allBookings.Count(b =>
                b.Status.Equals("Booked", StringComparison.OrdinalIgnoreCase) ||
                b.Status.Equals("Checked In", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblOnQue.Text = allBookings.Count(b =>
                b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase) ||
                b.Status.Equals("Serving", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblCompleted.Text = allBookings.Count(b =>
                b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)
            ).ToString();

            lblNoshow.Text = allBookings.Count(b =>
                b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase) ||
                b.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase)
            ).ToString();
        }

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

        // ============================================================
        // EMPTY STUBS (keep if wired in Designer)
        // ============================================================
        private void pnlReports_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            List<Booking> bookings = FileManager.LoadBookings();
            int total = bookings.Count;
            int completed = bookings.Count(b => b.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase));
            int waiting = bookings.Count(b => b.Status.Equals("Waiting", StringComparison.OrdinalIgnoreCase) ||
                                        b.Status.Equals("In Queue", StringComparison.OrdinalIgnoreCase));
            int noShow = bookings.Count(b => b.Status.Equals("No-Show", StringComparison.OrdinalIgnoreCase));

            int barX = 220, barY = 50, barWidth = 35, maxHeight = 100;

            //int grantApps = bookings.Count(b => b.ServiceName != null  && 
            //b.ServiceName.IndexOf("Grant", StringComparison.OrdinalIgnoreCase) >=0);
            //int enquiries = bookings.Count(b => b.ServiceName != null &&
            //b.ServiceName.IndexOf("Enquiry", StringComparison.OrdinalIgnoreCase) >= 0);

            int grantApps = bookings.Count(b => b.ServiceName != null &&
                  b.ServiceName.IndexOf("Grant", StringComparison.OrdinalIgnoreCase) >= 0);
            int enquiries = bookings.Count(b => b.ServiceName != null &&
            b.ServiceName.IndexOf("Enquiry", StringComparison.OrdinalIgnoreCase) >= 0);
            int maxVal = Math.Max(1, Math.Max(grantApps, enquiries));
            DrawChartBar(g, "Grant Apps", grantApps, maxVal, barX, barY, barWidth, maxHeight,
                         Color.FromArgb(0, 122, 255));
            DrawChartBar(g, "Enquiries", enquiries, maxVal, barX + 50, barY, barWidth, maxHeight,
                         Color.FromArgb(52, 199, 89));

            // Draw Doughnut Chart (Bookings Overview)
            int pieX = 220, pieY = 60, pieSize = 140, holeSize = 70;
            int safeTotal = Math.Max(1, total);
            float angleCompleted = (completed / (float)safeTotal) * 360f;
            float angleWaiting = (waiting / (float)safeTotal) * 360f;

            using (Brush b1 = new SolidBrush(Color.FromArgb(0, 122, 255)))
                g.FillPie(b1, pieX, pieY, pieSize, pieSize, 0, angleCompleted);
            using (Brush b2 = new SolidBrush(Color.FromArgb(255, 149, 0)))
                g.FillPie(b2, pieX, pieY, pieSize, pieSize, angleCompleted, angleWaiting);

            using (Brush centerBrush = new SolidBrush(Color.White))
                g.FillEllipse(centerBrush,
                    pieX + (pieSize - holeSize) / 2,
                    pieY + (pieSize - holeSize) / 2,
                    holeSize, holeSize);

        }
        private void DrawChartBar(Graphics g, string label, int value, int maxValue, int x, int y,
            int width, int maxHeight, Color color)
        {
            int barHeight = maxValue > 0? (int)((float)value / maxValue * maxHeight) :0;
            //int barHeight = (int)((float)value / Math.Max(1, maxValue) * maxHeight);
            //using (Brush brush = new SolidBrush(color))
            if (barHeight > 0)
            {
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, x, y + (maxHeight - barHeight), width, barHeight);
                }
                using (Font font = new Font("SegoE UI", 9))
                using (Brush textBrush = new SolidBrush(Color.Black))
                {

                    g.DrawString(value.ToString(), font, textBrush, x + 8, y + (maxHeight - barHeight) - 15);
                    g.DrawString(label, font, textBrush, x - 5, y + maxHeight + 5);
                }
            }
        }
        private void ApplySidebarStyle()
        {
            btnAdminDashboard.Text = "       🏠     Dashboard";
            btnServices.Text = "       ⚙️    Services";
            btnStaff.Text = "       👥     Staff";
            btnCentres.Text = "       📍     Centres and Slots";
            btnBookings.Text = "       📅     Bookings";
            btnReports.Text = "       📊     Reports";
            btnLogout.Text = "       🚪     Logout";

            Button[] navButtons =
            {
        btnAdminDashboard, btnServices, btnStaff, btnCentres,
        btnBookings, btnReports, btnLogout
    };
            btnAdminDashboard.BackColor = Color.FromArgb(255, 193, 7);
            btnServices.BackColor = Color.FromArgb(40, 167, 69);
            btnStaff.BackColor = Color.FromArgb(0, 123, 255);
            btnCentres.BackColor = Color.FromArgb(23, 162, 184);
            btnBookings.BackColor = Color.FromArgb(255, 193, 7);
            btnReports.BackColor = Color.FromArgb(40, 167, 69);
            btnLogout.BackColor = Color.FromArgb(0, 123, 255);

            //foreach (Button btn in navButtons)
            //{
            //    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            //    btn.ForeColor = Color.White;
            //    btn.BackColor = Color.FromArgb(0, 51, 102);
            //    btn.FlatStyle = FlatStyle.Flat;
            //    btn.FlatAppearance.BorderSize = 0;
            //}
        }
        private void label17_Click(object sender, EventArgs e) { }
        private void cmbServiceCentre_Click(object sender, EventArgs e) { }

        private void pnlAdminDashboard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}