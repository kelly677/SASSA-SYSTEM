using SASSA_Application.Classes;

namespace SASSA_Application.Designer_Forms
{
    partial class StaffPortal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPortal));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblUserName = new Label();
            label15 = new Label();
            pictureBox1 = new PictureBox();
            pcLogo = new PictureBox();
            pnlSidePanel = new Panel();
            btnLogout = new RoundedButton();
            btnQManagement = new RoundedButton();
            btnBookings = new RoundedButton();
            btnSearch = new RoundedButton();
            btnStaffDashboard = new RoundedButton();
            pnlStaffDash = new Panel();
            curvedCornerPanel9 = new CurvedCornerPanel();
            label19 = new Label();
            label22 = new Label();
            curvedCornerPanel8 = new CurvedCornerPanel();
            label16 = new Label();
            label11 = new Label();
            label13 = new Label();
            label9 = new Label();
            roundedButton2 = new RoundedButton();
            roundedButton1 = new RoundedButton();
            curvedCornerPanel7 = new CurvedCornerPanel();
            lblNoShowCount = new Label();
            label20 = new Label();
            curvedCornerPanel6 = new CurvedCornerPanel();
            lblCompletedCount = new Label();
            label18 = new Label();
            curvedCornerPanel5 = new CurvedCornerPanel();
            lblServingCount = new Label();
            label14 = new Label();
            curvedCornerPanel4 = new CurvedCornerPanel();
            lblWaitingCount = new Label();
            label12 = new Label();
            curvedCornerPanel3 = new CurvedCornerPanel();
            lblCheckInTotal = new Label();
            label10 = new Label();
            curvedCornerPanel2 = new CurvedCornerPanel();
            lblBookedTotal = new Label();
            label17 = new Label();
            label7 = new Label();
            label8 = new Label();
            pnlQManagement = new Panel();
            flpQueue = new FlowLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            pnlBookings = new Panel();
            curvedCornerPanel10 = new CurvedCornerPanel();
            dgvTotalBookings = new DataGridView();
            Reference = new DataGridViewTextBoxColumn();
            Beneficiary = new DataGridViewTextBoxColumn();
            Service = new DataGridViewTextBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            QueueNumber = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label4 = new Label();
            pnlSearch = new Panel();
            curvedCornerPanel1 = new CurvedCornerPanel();
            btnSerchingBooking = new RoundedButton();
            txtSearching = new RoundedTextBox();
            label1 = new Label();
            label3 = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcLogo).BeginInit();
            pnlSidePanel.SuspendLayout();
            pnlStaffDash.SuspendLayout();
            curvedCornerPanel9.SuspendLayout();
            curvedCornerPanel8.SuspendLayout();
            curvedCornerPanel7.SuspendLayout();
            curvedCornerPanel6.SuspendLayout();
            curvedCornerPanel5.SuspendLayout();
            curvedCornerPanel4.SuspendLayout();
            curvedCornerPanel3.SuspendLayout();
            curvedCornerPanel2.SuspendLayout();
            pnlQManagement.SuspendLayout();
            pnlBookings.SuspendLayout();
            curvedCornerPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTotalBookings).BeginInit();
            pnlSearch.SuspendLayout();
            curvedCornerPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(26, 70, 130);
            pnlTop.Controls.Add(lblUserName);
            pnlTop.Controls.Add(label15);
            pnlTop.Controls.Add(pictureBox1);
            pnlTop.Controls.Add(pcLogo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1458, 91);
            pnlTop.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = SystemColors.GradientActiveCaption;
            lblUserName.Location = new Point(1261, 34);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(153, 28);
            lblUserName.TabIndex = 10;
            lblUserName.Text = " 👤(UserName)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.Location = new Point(1284, 62);
            label15.Name = "label15";
            label15.Size = new Size(121, 28);
            label15.TabIndex = 9;
            label15.Text = "Staff Portal";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(133, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pcLogo
            // 
            pcLogo.Image = (Image)resources.GetObject("pcLogo.Image");
            pcLogo.Location = new Point(12, 3);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(115, 81);
            pcLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pcLogo.TabIndex = 0;
            pcLogo.TabStop = false;
            // 
            // pnlSidePanel
            // 
            pnlSidePanel.Controls.Add(btnLogout);
            pnlSidePanel.Controls.Add(btnQManagement);
            pnlSidePanel.Controls.Add(btnBookings);
            pnlSidePanel.Controls.Add(btnSearch);
            pnlSidePanel.Controls.Add(btnStaffDashboard);
            pnlSidePanel.Dock = DockStyle.Left;
            pnlSidePanel.Location = new Point(0, 91);
            pnlSidePanel.Name = "pnlSidePanel";
            pnlSidePanel.Size = new Size(297, 619);
            pnlSidePanel.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Firebrick;
            btnLogout.HoverColor = Color.Empty;
            btnLogout.Location = new Point(29, 542);
            btnLogout.Name = "btnLogout";
            btnLogout.PressedColor = Color.Empty;
            btnLogout.Size = new Size(217, 52);
            btnLogout.TabIndex = 5;
            btnLogout.Text = " \u23fb Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnQManagement
            // 
            btnQManagement.BackColor = Color.FromArgb(26, 70, 130);
            btnQManagement.FlatAppearance.BorderSize = 0;
            btnQManagement.FlatStyle = FlatStyle.Flat;
            btnQManagement.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnQManagement.ForeColor = Color.LightGray;
            btnQManagement.HoverColor = Color.Empty;
            btnQManagement.Location = new Point(12, 102);
            btnQManagement.Name = "btnQManagement";
            btnQManagement.PressedColor = Color.Empty;
            btnQManagement.Size = new Size(265, 50);
            btnQManagement.TabIndex = 3;
            btnQManagement.Text = "⏱️ Queue Management";
            btnQManagement.UseVisualStyleBackColor = false;
            btnQManagement.Click += btnQManagement_Click;
            // 
            // btnBookings
            // 
            btnBookings.BackColor = Color.FromArgb(26, 70, 130);
            btnBookings.FlatAppearance.BorderSize = 0;
            btnBookings.FlatStyle = FlatStyle.Flat;
            btnBookings.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnBookings.ForeColor = Color.LightGray;
            btnBookings.HoverColor = Color.Empty;
            btnBookings.Location = new Point(12, 182);
            btnBookings.Name = "btnBookings";
            btnBookings.PressedColor = Color.Empty;
            btnBookings.Size = new Size(265, 50);
            btnBookings.TabIndex = 2;
            btnBookings.Text = "📋Bookings";
            btnBookings.UseVisualStyleBackColor = false;
            btnBookings.Click += btnBookings_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(26, 70, 130);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSearch.ForeColor = Color.LightGray;
            btnSearch.HoverColor = Color.Empty;
            btnSearch.Location = new Point(12, 262);
            btnSearch.Name = "btnSearch";
            btnSearch.PressedColor = Color.Empty;
            btnSearch.Size = new Size(265, 50);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnStaffDashboard
            // 
            btnStaffDashboard.BackColor = Color.FromArgb(26, 70, 130);
            btnStaffDashboard.FlatAppearance.BorderSize = 0;
            btnStaffDashboard.FlatStyle = FlatStyle.Flat;
            btnStaffDashboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnStaffDashboard.ForeColor = Color.LightGray;
            btnStaffDashboard.HoverColor = Color.Empty;
            btnStaffDashboard.Location = new Point(12, 22);
            btnStaffDashboard.Name = "btnStaffDashboard";
            btnStaffDashboard.PressedColor = Color.Empty;
            btnStaffDashboard.Size = new Size(265, 50);
            btnStaffDashboard.TabIndex = 0;
            btnStaffDashboard.Text = "🏠 Dashboard";
            btnStaffDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnStaffDashboard.UseVisualStyleBackColor = false;
            btnStaffDashboard.Click += btnStaffDashboard_Click;
            // 
            // pnlStaffDash
            // 
            pnlStaffDash.BackColor = SystemColors.GradientActiveCaption;
            pnlStaffDash.Controls.Add(curvedCornerPanel9);
            pnlStaffDash.Controls.Add(curvedCornerPanel8);
            pnlStaffDash.Controls.Add(label9);
            pnlStaffDash.Controls.Add(roundedButton2);
            pnlStaffDash.Controls.Add(roundedButton1);
            pnlStaffDash.Controls.Add(curvedCornerPanel7);
            pnlStaffDash.Controls.Add(curvedCornerPanel6);
            pnlStaffDash.Controls.Add(curvedCornerPanel5);
            pnlStaffDash.Controls.Add(curvedCornerPanel4);
            pnlStaffDash.Controls.Add(curvedCornerPanel3);
            pnlStaffDash.Controls.Add(curvedCornerPanel2);
            pnlStaffDash.Controls.Add(label7);
            pnlStaffDash.Controls.Add(label8);
            pnlStaffDash.Dock = DockStyle.Fill;
            pnlStaffDash.Location = new Point(0, 0);
            pnlStaffDash.Name = "pnlStaffDash";
            pnlStaffDash.Size = new Size(1458, 710);
            pnlStaffDash.TabIndex = 3;
            // 
            // curvedCornerPanel9
            // 
            curvedCornerPanel9.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel9.Controls.Add(label19);
            curvedCornerPanel9.Controls.Add(label22);
            curvedCornerPanel9.Location = new Point(859, 485);
            curvedCornerPanel9.Name = "curvedCornerPanel9";
            curvedCornerPanel9.Size = new Size(405, 161);
            curvedCornerPanel9.TabIndex = 27;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = SystemColors.GradientActiveCaption;
            label19.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.FromArgb(26, 70, 130);
            label19.Location = new Point(14, 55);
            label19.Name = "label19";
            label19.Size = new Size(236, 28);
            label19.TabIndex = 27;
            label19.Text = "Q-000-Beneficiary Name";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label22.Location = new Point(3, 8);
            label22.Name = "label22";
            label22.Size = new Size(136, 28);
            label22.TabIndex = 13;
            label22.Text = "Waiting Now";
            // 
            // curvedCornerPanel8
            // 
            curvedCornerPanel8.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel8.Controls.Add(label16);
            curvedCornerPanel8.Controls.Add(label11);
            curvedCornerPanel8.Controls.Add(label13);
            curvedCornerPanel8.Location = new Point(330, 485);
            curvedCornerPanel8.Name = "curvedCornerPanel8";
            curvedCornerPanel8.Size = new Size(357, 161);
            curvedCornerPanel8.TabIndex = 26;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = SystemColors.GradientActiveCaption;
            label16.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.FromArgb(26, 70, 130);
            label16.Location = new Point(17, 109);
            label16.Name = "label16";
            label16.Size = new Size(172, 28);
            label16.TabIndex = 27;
            label16.Text = "Beneficiary Name";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(26, 70, 130);
            label11.Location = new Point(14, 55);
            label11.Name = "label11";
            label11.Size = new Size(138, 54);
            label11.TabIndex = 12;
            label11.Text = "Q-000";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.Location = new Point(3, 8);
            label13.Name = "label13";
            label13.Size = new Size(134, 28);
            label13.TabIndex = 13;
            label13.Text = "Now Serving";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12.3F);
            label9.ForeColor = SystemColors.GrayText;
            label9.Location = new Point(347, 432);
            label9.Name = "label9";
            label9.Size = new Size(507, 30);
            label9.TabIndex = 25;
            label9.Text = "Want to check someone in? Use Queue Management";
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.FromArgb(26, 70, 130);
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            roundedButton2.ForeColor = Color.LightGray;
            roundedButton2.HoverColor = Color.Empty;
            roundedButton2.Location = new Point(344, 367);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.PressedColor = Color.Empty;
            roundedButton2.Size = new Size(510, 62);
            roundedButton2.TabIndex = 24;
            roundedButton2.Text = "⏱️ \r\nQueue Management";
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(26, 70, 130);
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            roundedButton1.ForeColor = Color.LightGray;
            roundedButton1.HoverColor = Color.Empty;
            roundedButton1.Location = new Point(1215, 367);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.PressedColor = Color.Empty;
            roundedButton1.Size = new Size(231, 62);
            roundedButton1.TabIndex = 23;
            roundedButton1.Text = "🔍 \r\nSearch Booking\r\n";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // curvedCornerPanel7
            // 
            curvedCornerPanel7.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel7.Controls.Add(lblNoShowCount);
            curvedCornerPanel7.Controls.Add(label20);
            curvedCornerPanel7.Location = new Point(1279, 209);
            curvedCornerPanel7.Name = "curvedCornerPanel7";
            curvedCornerPanel7.Size = new Size(167, 125);
            curvedCornerPanel7.TabIndex = 22;
            // 
            // lblNoShowCount
            // 
            lblNoShowCount.AutoSize = true;
            lblNoShowCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoShowCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblNoShowCount.Location = new Point(53, 50);
            lblNoShowCount.Name = "lblNoShowCount";
            lblNoShowCount.Size = new Size(57, 54);
            lblNoShowCount.TabIndex = 12;
            lblNoShowCount.Text = "0 ";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label20.Location = new Point(3, 8);
            label20.Name = "label20";
            label20.Size = new Size(99, 28);
            label20.TabIndex = 13;
            label20.Text = "No-Show";
            // 
            // curvedCornerPanel6
            // 
            curvedCornerPanel6.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel6.Controls.Add(lblCompletedCount);
            curvedCornerPanel6.Controls.Add(label18);
            curvedCornerPanel6.Location = new Point(1097, 209);
            curvedCornerPanel6.Name = "curvedCornerPanel6";
            curvedCornerPanel6.Size = new Size(167, 125);
            curvedCornerPanel6.TabIndex = 21;
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblCompletedCount.Location = new Point(53, 50);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(57, 54);
            lblCompletedCount.TabIndex = 12;
            lblCompletedCount.Text = "0 ";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label18.Location = new Point(3, 8);
            label18.Name = "label18";
            label18.Size = new Size(114, 28);
            label18.TabIndex = 13;
            label18.Text = "Completed";
            // 
            // curvedCornerPanel5
            // 
            curvedCornerPanel5.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel5.Controls.Add(lblServingCount);
            curvedCornerPanel5.Controls.Add(label14);
            curvedCornerPanel5.Location = new Point(915, 209);
            curvedCornerPanel5.Name = "curvedCornerPanel5";
            curvedCornerPanel5.Size = new Size(167, 125);
            curvedCornerPanel5.TabIndex = 20;
            // 
            // lblServingCount
            // 
            lblServingCount.AutoSize = true;
            lblServingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServingCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblServingCount.Location = new Point(53, 50);
            lblServingCount.Name = "lblServingCount";
            lblServingCount.Size = new Size(57, 54);
            lblServingCount.TabIndex = 12;
            lblServingCount.Text = "0 ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.Location = new Point(3, 8);
            label14.Name = "label14";
            label14.Size = new Size(84, 28);
            label14.TabIndex = 13;
            label14.Text = "Serving";
            // 
            // curvedCornerPanel4
            // 
            curvedCornerPanel4.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel4.Controls.Add(lblWaitingCount);
            curvedCornerPanel4.Controls.Add(label12);
            curvedCornerPanel4.Location = new Point(727, 209);
            curvedCornerPanel4.Name = "curvedCornerPanel4";
            curvedCornerPanel4.Size = new Size(167, 125);
            curvedCornerPanel4.TabIndex = 19;
            // 
            // lblWaitingCount
            // 
            lblWaitingCount.AutoSize = true;
            lblWaitingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaitingCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblWaitingCount.Location = new Point(53, 50);
            lblWaitingCount.Name = "lblWaitingCount";
            lblWaitingCount.Size = new Size(57, 54);
            lblWaitingCount.TabIndex = 12;
            lblWaitingCount.Text = "0 ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.Location = new Point(3, 8);
            label12.Name = "label12";
            label12.Size = new Size(86, 28);
            label12.TabIndex = 13;
            label12.Text = "Waiting";
            // 
            // curvedCornerPanel3
            // 
            curvedCornerPanel3.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel3.Controls.Add(lblCheckInTotal);
            curvedCornerPanel3.Controls.Add(label10);
            curvedCornerPanel3.Location = new Point(536, 209);
            curvedCornerPanel3.Name = "curvedCornerPanel3";
            curvedCornerPanel3.Size = new Size(167, 125);
            curvedCornerPanel3.TabIndex = 18;
            // 
            // lblCheckInTotal
            // 
            lblCheckInTotal.AutoSize = true;
            lblCheckInTotal.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCheckInTotal.ForeColor = Color.FromArgb(26, 70, 130);
            lblCheckInTotal.Location = new Point(53, 50);
            lblCheckInTotal.Name = "lblCheckInTotal";
            lblCheckInTotal.Size = new Size(57, 54);
            lblCheckInTotal.TabIndex = 12;
            lblCheckInTotal.Text = "0 ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(3, 8);
            label10.Name = "label10";
            label10.Size = new Size(115, 28);
            label10.TabIndex = 13;
            label10.Text = "Checked In";
            // 
            // curvedCornerPanel2
            // 
            curvedCornerPanel2.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel2.Controls.Add(lblBookedTotal);
            curvedCornerPanel2.Controls.Add(label17);
            curvedCornerPanel2.Location = new Point(344, 207);
            curvedCornerPanel2.Name = "curvedCornerPanel2";
            curvedCornerPanel2.Size = new Size(167, 125);
            curvedCornerPanel2.TabIndex = 17;
            // 
            // lblBookedTotal
            // 
            lblBookedTotal.AutoSize = true;
            lblBookedTotal.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedTotal.ForeColor = Color.FromArgb(26, 70, 130);
            lblBookedTotal.Location = new Point(53, 50);
            lblBookedTotal.Name = "lblBookedTotal";
            lblBookedTotal.Size = new Size(57, 54);
            lblBookedTotal.TabIndex = 12;
            lblBookedTotal.Text = "0 ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label17.Location = new Point(3, 8);
            label17.Name = "label17";
            label17.Size = new Size(83, 28);
            label17.TabIndex = 13;
            label17.Text = "Booked";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label7.Location = new Point(330, 110);
            label7.Name = "label7";
            label7.Size = new Size(194, 46);
            label7.TabIndex = 16;
            label7.Text = "DashBoard";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12.3F);
            label8.ForeColor = SystemColors.GrayText;
            label8.Location = new Point(330, 156);
            label8.Name = "label8";
            label8.Size = new Size(219, 30);
            label8.TabIndex = 15;
            label8.Text = "(Name Service Centre)";
            // 
            // pnlQManagement
            // 
            pnlQManagement.BackColor = SystemColors.GradientActiveCaption;
            pnlQManagement.Controls.Add(flpQueue);
            pnlQManagement.Controls.Add(label5);
            pnlQManagement.Controls.Add(label6);
            pnlQManagement.Dock = DockStyle.Fill;
            pnlQManagement.Location = new Point(0, 0);
            pnlQManagement.Name = "pnlQManagement";
            pnlQManagement.Padding = new Padding(317, 240, 20, 20);
            pnlQManagement.Size = new Size(1458, 710);
            pnlQManagement.TabIndex = 4;
            // 
            // flpQueue
            // 
            flpQueue.AutoScroll = true;
            flpQueue.Dock = DockStyle.Fill;
            flpQueue.FlowDirection = FlowDirection.TopDown;
            flpQueue.Location = new Point(317, 240);
            flpQueue.Name = "flpQueue";
            flpQueue.Size = new Size(1121, 450);
            flpQueue.TabIndex = 17;
            flpQueue.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label5.Location = new Point(336, 110);
            label5.Name = "label5";
            label5.Size = new Size(345, 46);
            label5.TabIndex = 16;
            label5.Text = "Queue Management";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12.3F);
            label6.ForeColor = SystemColors.GrayText;
            label6.Location = new Point(344, 156);
            label6.Name = "label6";
            label6.Size = new Size(811, 30);
            label6.TabIndex = 15;
            label6.Text = "Today's floor. Check beneficiaries in, call the next person, and keep the queue moving.";
            // 
            // pnlBookings
            // 
            pnlBookings.BackColor = SystemColors.GradientActiveCaption;
            pnlBookings.Controls.Add(curvedCornerPanel10);
            pnlBookings.Controls.Add(label2);
            pnlBookings.Controls.Add(label4);
            pnlBookings.Dock = DockStyle.Fill;
            pnlBookings.Location = new Point(0, 0);
            pnlBookings.Name = "pnlBookings";
            pnlBookings.Size = new Size(1458, 710);
            pnlBookings.TabIndex = 4;
            pnlBookings.Paint += pnlBookings_Paint;
            // 
            // curvedCornerPanel10
            // 
            curvedCornerPanel10.BackColor = Color.White;
            curvedCornerPanel10.Controls.Add(dgvTotalBookings);
            curvedCornerPanel10.Location = new Point(317, 209);
            curvedCornerPanel10.Name = "curvedCornerPanel10";
            curvedCornerPanel10.Padding = new Padding(10);
            curvedCornerPanel10.Size = new Size(1138, 413);
            curvedCornerPanel10.TabIndex = 13;
            // 
            // dgvTotalBookings
            // 
            dgvTotalBookings.AllowUserToAddRows = false;
            dgvTotalBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTotalBookings.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvTotalBookings.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(26, 70, 130);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTotalBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTotalBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTotalBookings.Columns.AddRange(new DataGridViewColumn[] { Reference, Beneficiary, Service, Time, QueueNumber, Status });
            dgvTotalBookings.Dock = DockStyle.Fill;
            dgvTotalBookings.EnableHeadersVisualStyles = false;
            dgvTotalBookings.GridColor = SystemColors.GradientActiveCaption;
            dgvTotalBookings.Location = new Point(10, 10);
            dgvTotalBookings.Name = "dgvTotalBookings";
            dgvTotalBookings.ReadOnly = true;
            dgvTotalBookings.RowHeadersVisible = false;
            dgvTotalBookings.RowHeadersWidth = 51;
            dgvTotalBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotalBookings.Size = new Size(1118, 393);
            dgvTotalBookings.TabIndex = 1;
            // 
            // Reference
            // 
            Reference.HeaderText = "Reference";
            Reference.MinimumWidth = 6;
            Reference.Name = "Reference";
            Reference.ReadOnly = true;
            // 
            // Beneficiary
            // 
            Beneficiary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Beneficiary.HeaderText = "Beneficiary";
            Beneficiary.MinimumWidth = 6;
            Beneficiary.Name = "Beneficiary";
            Beneficiary.ReadOnly = true;
            // 
            // Service
            // 
            Service.HeaderText = "Service";
            Service.MinimumWidth = 6;
            Service.Name = "Service";
            Service.ReadOnly = true;
            // 
            // Time
            // 
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.ReadOnly = true;
            // 
            // QueueNumber
            // 
            QueueNumber.HeaderText = "Queue Number";
            QueueNumber.MinimumWidth = 6;
            QueueNumber.Name = "QueueNumber";
            QueueNumber.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label2.Location = new Point(317, 110);
            label2.Name = "label2";
            label2.Size = new Size(386, 46);
            label2.TabIndex = 12;
            label2.Text = "Today's Total Bookings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.3F);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(317, 156);
            label4.Name = "label4";
            label4.Size = new Size(672, 30);
            label4.TabIndex = 11;
            label4.Text = "Everyone booked at this centre today, including those still on their way.";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = SystemColors.GradientActiveCaption;
            pnlSearch.Controls.Add(curvedCornerPanel1);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Controls.Add(label3);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1458, 710);
            pnlSearch.TabIndex = 4;
            // 
            // curvedCornerPanel1
            // 
            curvedCornerPanel1.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel1.Controls.Add(btnSerchingBooking);
            curvedCornerPanel1.Controls.Add(txtSearching);
            curvedCornerPanel1.Location = new Point(303, 212);
            curvedCornerPanel1.Name = "curvedCornerPanel1";
            curvedCornerPanel1.Size = new Size(1062, 125);
            curvedCornerPanel1.TabIndex = 15;
            // 
            // btnSerchingBooking
            // 
            btnSerchingBooking.BackColor = Color.FromArgb(26, 70, 130);
            btnSerchingBooking.FlatAppearance.BorderSize = 0;
            btnSerchingBooking.FlatStyle = FlatStyle.Flat;
            btnSerchingBooking.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSerchingBooking.ForeColor = Color.White;
            btnSerchingBooking.HoverColor = Color.Empty;
            btnSerchingBooking.Location = new Point(860, 45);
            btnSerchingBooking.Name = "btnSerchingBooking";
            btnSerchingBooking.PressedColor = Color.Empty;
            btnSerchingBooking.Size = new Size(188, 38);
            btnSerchingBooking.TabIndex = 1;
            btnSerchingBooking.Text = "Search";
            btnSerchingBooking.UseVisualStyleBackColor = false;
            // 
            // txtSearching
            // 
            txtSearching.BackColor = Color.White;
            txtSearching.Font = new Font("Segoe UI", 10F);
            txtSearching.Location = new Point(27, 45);
            txtSearching.Name = "txtSearching";
            txtSearching.PlaceholderText = "Search for a booking";
            txtSearching.Size = new Size(827, 46);
            txtSearching.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label1.Location = new Point(317, 110);
            label1.Name = "label1";
            label1.Size = new Size(284, 46);
            label1.TabIndex = 14;
            label1.Text = "Search Bookings";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.3F);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(317, 156);
            label3.Name = "label3";
            label3.Size = new Size(349, 30);
            label3.TabIndex = 13;
            label3.Text = "Find a booking by reference number";
            // 
            // StaffPortal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1458, 710);
            Controls.Add(pnlSidePanel);
            Controls.Add(pnlTop);
            Controls.Add(pnlBookings);
            Controls.Add(pnlQManagement);
            Controls.Add(pnlStaffDash);
            Controls.Add(pnlSearch);
            Name = "StaffPortal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffPortal";
            Load += StaffPortal_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcLogo).EndInit();
            pnlSidePanel.ResumeLayout(false);
            pnlStaffDash.ResumeLayout(false);
            pnlStaffDash.PerformLayout();
            curvedCornerPanel9.ResumeLayout(false);
            curvedCornerPanel9.PerformLayout();
            curvedCornerPanel8.ResumeLayout(false);
            curvedCornerPanel8.PerformLayout();
            curvedCornerPanel7.ResumeLayout(false);
            curvedCornerPanel7.PerformLayout();
            curvedCornerPanel6.ResumeLayout(false);
            curvedCornerPanel6.PerformLayout();
            curvedCornerPanel5.ResumeLayout(false);
            curvedCornerPanel5.PerformLayout();
            curvedCornerPanel4.ResumeLayout(false);
            curvedCornerPanel4.PerformLayout();
            curvedCornerPanel3.ResumeLayout(false);
            curvedCornerPanel3.PerformLayout();
            curvedCornerPanel2.ResumeLayout(false);
            curvedCornerPanel2.PerformLayout();
            pnlQManagement.ResumeLayout(false);
            pnlQManagement.PerformLayout();
            pnlBookings.ResumeLayout(false);
            pnlBookings.PerformLayout();
            curvedCornerPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTotalBookings).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            curvedCornerPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblUserName;
        private Label label15;
        private PictureBox pictureBox1;
        private PictureBox pcLogo;
        private Panel pnlSidePanel;
        private Classes.RoundedButton btnLogout;
        private RoundedButton btnQManagement;
        private RoundedButton btnBookings;
        private Classes.RoundedButton btnProfile;
        private Classes.RoundedButton btnNewBooking;
        private Classes.RoundedButton btnMyBookings;
        private Classes.RoundedButton btnQueueStatus;
        private RoundedButton btnSearch;
        private Classes.RoundedButton btnStaffDashboard;
        private Panel pnlStaffDash;
        private Panel pnlQManagement;
        private Panel pnlBookings;
        private Panel pnlSearch;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label label3;
        private Classes.CurvedCornerPanel curvedCornerPanel1;
        private Classes.RoundedButton btnSerchingBooking;
        private Classes.RoundedTextBox txtSearching;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Classes.CurvedCornerPanel curvedCornerPanel2;
        private Label lblBookedTotal;
        private Label label17;
        private Classes.CurvedCornerPanel curvedCornerPanel4;
        private Label lblWaitingCount;
        private Label label12;
        private Classes.CurvedCornerPanel curvedCornerPanel3;
        private Label lblCheckInTotal;
        private Label label10;
        private Classes.CurvedCornerPanel curvedCornerPanel6;
        private Label lblCompletedCount;
        private Label label18;
        private Classes.CurvedCornerPanel curvedCornerPanel5;
        private Label lblServingCount;
        private Label label14;
        private Classes.CurvedCornerPanel curvedCornerPanel7;
        private Label lblNoShowCount;
        private Label label20;
        private Classes.RoundedButton roundedButton1;
        private Classes.RoundedButton roundedButton2;
        private Classes.CurvedCornerPanel curvedCornerPanel8;
        private Label label11;
        private Label label13;
        private Label label9;
        private Classes.CurvedCornerPanel curvedCornerPanel9;
        private Label label19;
        private Label label22;
        private Label label16;
        private Classes.CurvedCornerPanel curvedCornerPanel10;
        private DataGridView dgvTotalBookings;
        private DataGridViewTextBoxColumn Reference;
        private DataGridViewTextBoxColumn Beneficiary;
        private DataGridViewTextBoxColumn Service;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn QueueNumber;
        private DataGridViewTextBoxColumn Status;
        private FlowLayoutPanel flpQueue;
    }
}