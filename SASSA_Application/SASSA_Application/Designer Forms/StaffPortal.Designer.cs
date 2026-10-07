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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            lblQueueNumberAndBeneficiaryNameNowServing = new Label();
            lblWaitingNowTiltle = new Label();
            curvedCornerPanel8 = new CurvedCornerPanel();
            lblBeneficiaryNameNowServing = new Label();
            lblQueueNumberNowServing = new Label();
            lblNowServingTitle = new Label();
            label9 = new Label();
            btnQueueManagement = new RoundedButton();
            btnSearchBooking = new RoundedButton();
            curvedCornerPanel7 = new CurvedCornerPanel();
            lblNoShowCount = new Label();
            lblNoShowTitle = new Label();
            curvedCornerPanel6 = new CurvedCornerPanel();
            lblCompletedCount = new Label();
            lblCompletedTitle = new Label();
            curvedCornerPanel5 = new CurvedCornerPanel();
            lblServingCount = new Label();
            lblServingTitle = new Label();
            curvedCornerPanel4 = new CurvedCornerPanel();
            lblWaitingCount = new Label();
            lblWaitingTitle = new Label();
            curvedCornerPanel3 = new CurvedCornerPanel();
            lblCheckedInCount = new Label();
            lblCheckedInTitle = new Label();
            curvedCornerPanel2 = new CurvedCornerPanel();
            lblBookedCount = new Label();
            lblBookedTitle = new Label();
            label7 = new Label();
            lblNameServiceCentre = new Label();
            pnlQManagement = new Panel();
            btnCallNext = new RoundedButton();
            flpQueue = new FlowLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            pnlBookings = new Panel();
            curvedCornerPanel10 = new CurvedCornerPanel();
            dgvTotalBookings = new DataGridView();
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
            pnlTop.Margin = new Padding(3, 2, 3, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1226, 68);
            pnlTop.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = SystemColors.GradientActiveCaption;
            lblUserName.Location = new Point(1103, 26);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(122, 21);
            lblUserName.TabIndex = 10;
            lblUserName.Text = " 👤(UserName)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label15.Location = new Point(1124, 46);
            label15.Name = "label15";
            label15.Size = new Size(96, 21);
            label15.TabIndex = 9;
            label15.Text = "Staff Portal";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(116, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(164, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pcLogo
            // 
            pcLogo.Image = (Image)resources.GetObject("pcLogo.Image");
            pcLogo.Location = new Point(10, 2);
            pcLogo.Margin = new Padding(3, 2, 3, 2);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(101, 61);
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
            pnlSidePanel.Location = new Point(0, 68);
            pnlSidePanel.Margin = new Padding(3, 2, 3, 2);
            pnlSidePanel.Name = "pnlSidePanel";
            pnlSidePanel.Size = new Size(260, 464);
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
            btnLogout.Location = new Point(25, 406);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.PressedColor = Color.Empty;
            btnLogout.Size = new Size(190, 39);
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
            btnQManagement.Location = new Point(10, 76);
            btnQManagement.Margin = new Padding(3, 2, 3, 2);
            btnQManagement.Name = "btnQManagement";
            btnQManagement.PressedColor = Color.Empty;
            btnQManagement.Size = new Size(232, 38);
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
            btnBookings.Location = new Point(10, 136);
            btnBookings.Margin = new Padding(3, 2, 3, 2);
            btnBookings.Name = "btnBookings";
            btnBookings.PressedColor = Color.Empty;
            btnBookings.Size = new Size(232, 38);
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
            btnSearch.Location = new Point(10, 196);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.PressedColor = Color.Empty;
            btnSearch.Size = new Size(232, 38);
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
            btnStaffDashboard.Location = new Point(10, 16);
            btnStaffDashboard.Margin = new Padding(3, 2, 3, 2);
            btnStaffDashboard.Name = "btnStaffDashboard";
            btnStaffDashboard.PressedColor = Color.Empty;
            btnStaffDashboard.Size = new Size(232, 38);
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
            pnlStaffDash.Controls.Add(btnQueueManagement);
            pnlStaffDash.Controls.Add(btnSearchBooking);
            pnlStaffDash.Controls.Add(curvedCornerPanel7);
            pnlStaffDash.Controls.Add(curvedCornerPanel6);
            pnlStaffDash.Controls.Add(curvedCornerPanel5);
            pnlStaffDash.Controls.Add(curvedCornerPanel4);
            pnlStaffDash.Controls.Add(curvedCornerPanel3);
            pnlStaffDash.Controls.Add(curvedCornerPanel2);
            pnlStaffDash.Controls.Add(label7);
            pnlStaffDash.Controls.Add(lblNameServiceCentre);
            pnlStaffDash.Dock = DockStyle.Fill;
            pnlStaffDash.Location = new Point(0, 0);
            pnlStaffDash.Margin = new Padding(3, 2, 3, 2);
            pnlStaffDash.Name = "pnlStaffDash";
            pnlStaffDash.Size = new Size(1226, 532);
            pnlStaffDash.TabIndex = 3;
            // 
            // curvedCornerPanel9
            // 
            curvedCornerPanel9.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel9.Controls.Add(lblQueueNumberAndBeneficiaryNameNowServing);
            curvedCornerPanel9.Controls.Add(lblWaitingNowTiltle);
            curvedCornerPanel9.Location = new Point(752, 364);
            curvedCornerPanel9.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel9.Name = "curvedCornerPanel9";
            curvedCornerPanel9.Size = new Size(354, 121);
            curvedCornerPanel9.TabIndex = 27;
            // 
            // lblQueueNumberAndBeneficiaryNameNowServing
            // 
            lblQueueNumberAndBeneficiaryNameNowServing.AutoSize = true;
            lblQueueNumberAndBeneficiaryNameNowServing.BackColor = SystemColors.GradientActiveCaption;
            lblQueueNumberAndBeneficiaryNameNowServing.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQueueNumberAndBeneficiaryNameNowServing.ForeColor = Color.FromArgb(26, 70, 130);
            lblQueueNumberAndBeneficiaryNameNowServing.Location = new Point(12, 41);
            lblQueueNumberAndBeneficiaryNameNowServing.Name = "lblQueueNumberAndBeneficiaryNameNowServing";
            lblQueueNumberAndBeneficiaryNameNowServing.Size = new Size(188, 21);
            lblQueueNumberAndBeneficiaryNameNowServing.TabIndex = 27;
            lblQueueNumberAndBeneficiaryNameNowServing.Text = "Q-000-Beneficiary Name";
            // 
            // lblWaitingNowTiltle
            // 
            lblWaitingNowTiltle.AutoSize = true;
            lblWaitingNowTiltle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWaitingNowTiltle.Location = new Point(3, 6);
            lblWaitingNowTiltle.Name = "lblWaitingNowTiltle";
            lblWaitingNowTiltle.Size = new Size(110, 21);
            lblWaitingNowTiltle.TabIndex = 13;
            lblWaitingNowTiltle.Text = "Waiting Now";
            // 
            // curvedCornerPanel8
            // 
            curvedCornerPanel8.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel8.Controls.Add(lblBeneficiaryNameNowServing);
            curvedCornerPanel8.Controls.Add(lblQueueNumberNowServing);
            curvedCornerPanel8.Controls.Add(lblNowServingTitle);
            curvedCornerPanel8.Location = new Point(289, 364);
            curvedCornerPanel8.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel8.Name = "curvedCornerPanel8";
            curvedCornerPanel8.Size = new Size(312, 121);
            curvedCornerPanel8.TabIndex = 26;
            // 
            // lblBeneficiaryNameNowServing
            // 
            lblBeneficiaryNameNowServing.AutoSize = true;
            lblBeneficiaryNameNowServing.BackColor = SystemColors.GradientActiveCaption;
            lblBeneficiaryNameNowServing.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBeneficiaryNameNowServing.ForeColor = Color.FromArgb(26, 70, 130);
            lblBeneficiaryNameNowServing.Location = new Point(15, 82);
            lblBeneficiaryNameNowServing.Name = "lblBeneficiaryNameNowServing";
            lblBeneficiaryNameNowServing.Size = new Size(137, 21);
            lblBeneficiaryNameNowServing.TabIndex = 27;
            lblBeneficiaryNameNowServing.Text = "Beneficiary Name";
            // 
            // lblQueueNumberNowServing
            // 
            lblQueueNumberNowServing.AutoSize = true;
            lblQueueNumberNowServing.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQueueNumberNowServing.ForeColor = Color.FromArgb(26, 70, 130);
            lblQueueNumberNowServing.Location = new Point(12, 41);
            lblQueueNumberNowServing.Name = "lblQueueNumberNowServing";
            lblQueueNumberNowServing.Size = new Size(111, 45);
            lblQueueNumberNowServing.TabIndex = 12;
            lblQueueNumberNowServing.Text = "Q-000";
            // 
            // lblNowServingTitle
            // 
            lblNowServingTitle.AutoSize = true;
            lblNowServingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNowServingTitle.Location = new Point(3, 6);
            lblNowServingTitle.Name = "lblNowServingTitle";
            lblNowServingTitle.Size = new Size(109, 21);
            lblNowServingTitle.TabIndex = 13;
            lblNowServingTitle.Text = "Now Serving";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12.3F);
            label9.ForeColor = SystemColors.GrayText;
            label9.Location = new Point(304, 324);
            label9.Name = "label9";
            label9.Size = new Size(417, 23);
            label9.TabIndex = 25;
            label9.Text = "Want to check someone in? Use Queue Management";
            // 
            // btnQueueManagement
            // 
            btnQueueManagement.BackColor = Color.FromArgb(26, 70, 130);
            btnQueueManagement.FlatAppearance.BorderSize = 0;
            btnQueueManagement.FlatStyle = FlatStyle.Flat;
            btnQueueManagement.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnQueueManagement.ForeColor = Color.LightGray;
            btnQueueManagement.HoverColor = Color.Empty;
            btnQueueManagement.Location = new Point(301, 275);
            btnQueueManagement.Margin = new Padding(3, 2, 3, 2);
            btnQueueManagement.Name = "btnQueueManagement";
            btnQueueManagement.PressedColor = Color.Empty;
            btnQueueManagement.Size = new Size(446, 46);
            btnQueueManagement.TabIndex = 24;
            btnQueueManagement.Text = "⏱️ \r\nQueue Management";
            btnQueueManagement.UseVisualStyleBackColor = false;
            btnQueueManagement.Click += btnQManagement_Click;
            // 
            // btnSearchBooking
            // 
            btnSearchBooking.BackColor = Color.FromArgb(26, 70, 130);
            btnSearchBooking.FlatAppearance.BorderSize = 0;
            btnSearchBooking.FlatStyle = FlatStyle.Flat;
            btnSearchBooking.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSearchBooking.ForeColor = Color.LightGray;
            btnSearchBooking.HoverColor = Color.Empty;
            btnSearchBooking.Location = new Point(895, 275);
            btnSearchBooking.Margin = new Padding(3, 2, 3, 2);
            btnSearchBooking.Name = "btnSearchBooking";
            btnSearchBooking.PressedColor = Color.Empty;
            btnSearchBooking.Size = new Size(202, 46);
            btnSearchBooking.TabIndex = 23;
            btnSearchBooking.Text = "🔍 \r\nSearch Booking\r\n";
            btnSearchBooking.UseVisualStyleBackColor = false;
            btnSearchBooking.Click += btnSearch_Click_Tab;
            // 
            // curvedCornerPanel7
            // 
            curvedCornerPanel7.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel7.Controls.Add(lblNoShowCount);
            curvedCornerPanel7.Controls.Add(lblNoShowTitle);
            curvedCornerPanel7.Location = new Point(1047, 157);
            curvedCornerPanel7.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel7.Name = "curvedCornerPanel7";
            curvedCornerPanel7.Size = new Size(134, 94);
            curvedCornerPanel7.TabIndex = 22;
            // 
            // lblNoShowCount
            // 
            lblNoShowCount.AutoSize = true;
            lblNoShowCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoShowCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblNoShowCount.Location = new Point(46, 38);
            lblNoShowCount.Name = "lblNoShowCount";
            lblNoShowCount.Size = new Size(47, 45);
            lblNoShowCount.TabIndex = 12;
            lblNoShowCount.Text = "0 ";
            // 
            // lblNoShowTitle
            // 
            lblNoShowTitle.AutoSize = true;
            lblNoShowTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNoShowTitle.Location = new Point(12, 8);
            lblNoShowTitle.Name = "lblNoShowTitle";
            lblNoShowTitle.Size = new Size(81, 21);
            lblNoShowTitle.TabIndex = 13;
            lblNoShowTitle.Text = "No-Show";
            // 
            // curvedCornerPanel6
            // 
            curvedCornerPanel6.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel6.Controls.Add(lblCompletedCount);
            curvedCornerPanel6.Controls.Add(lblCompletedTitle);
            curvedCornerPanel6.Location = new Point(895, 157);
            curvedCornerPanel6.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel6.Name = "curvedCornerPanel6";
            curvedCornerPanel6.Size = new Size(146, 94);
            curvedCornerPanel6.TabIndex = 21;
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblCompletedCount.Location = new Point(46, 38);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(47, 45);
            lblCompletedCount.TabIndex = 12;
            lblCompletedCount.Text = "0 ";
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.AutoSize = true;
            lblCompletedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCompletedTitle.Location = new Point(3, 8);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(94, 21);
            lblCompletedTitle.TabIndex = 13;
            lblCompletedTitle.Text = "Completed";
            // 
            // curvedCornerPanel5
            // 
            curvedCornerPanel5.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel5.Controls.Add(lblServingCount);
            curvedCornerPanel5.Controls.Add(lblServingTitle);
            curvedCornerPanel5.Location = new Point(743, 157);
            curvedCornerPanel5.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel5.Name = "curvedCornerPanel5";
            curvedCornerPanel5.Size = new Size(146, 94);
            curvedCornerPanel5.TabIndex = 20;
            // 
            // lblServingCount
            // 
            lblServingCount.AutoSize = true;
            lblServingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServingCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblServingCount.Location = new Point(46, 38);
            lblServingCount.Name = "lblServingCount";
            lblServingCount.Size = new Size(47, 45);
            lblServingCount.TabIndex = 12;
            lblServingCount.Text = "0 ";
            // 
            // lblServingTitle
            // 
            lblServingTitle.AutoSize = true;
            lblServingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblServingTitle.Location = new Point(3, 6);
            lblServingTitle.Name = "lblServingTitle";
            lblServingTitle.Size = new Size(69, 21);
            lblServingTitle.TabIndex = 13;
            lblServingTitle.Text = "Serving";
            // 
            // curvedCornerPanel4
            // 
            curvedCornerPanel4.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel4.Controls.Add(lblWaitingCount);
            curvedCornerPanel4.Controls.Add(lblWaitingTitle);
            curvedCornerPanel4.Location = new Point(591, 157);
            curvedCornerPanel4.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel4.Name = "curvedCornerPanel4";
            curvedCornerPanel4.Size = new Size(146, 94);
            curvedCornerPanel4.TabIndex = 19;
            // 
            // lblWaitingCount
            // 
            lblWaitingCount.AutoSize = true;
            lblWaitingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaitingCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblWaitingCount.Location = new Point(46, 38);
            lblWaitingCount.Name = "lblWaitingCount";
            lblWaitingCount.Size = new Size(47, 45);
            lblWaitingCount.TabIndex = 12;
            lblWaitingCount.Text = "0 ";
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.AutoSize = true;
            lblWaitingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWaitingTitle.Location = new Point(3, 6);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(70, 21);
            lblWaitingTitle.TabIndex = 13;
            lblWaitingTitle.Text = "Waiting";
            // 
            // curvedCornerPanel3
            // 
            curvedCornerPanel3.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel3.Controls.Add(lblCheckedInCount);
            curvedCornerPanel3.Controls.Add(lblCheckedInTitle);
            curvedCornerPanel3.Location = new Point(436, 157);
            curvedCornerPanel3.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel3.Name = "curvedCornerPanel3";
            curvedCornerPanel3.Size = new Size(135, 94);
            curvedCornerPanel3.TabIndex = 18;
            // 
            // lblCheckedInCount
            // 
            lblCheckedInCount.AutoSize = true;
            lblCheckedInCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCheckedInCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblCheckedInCount.Location = new Point(46, 38);
            lblCheckedInCount.Name = "lblCheckedInCount";
            lblCheckedInCount.Size = new Size(47, 45);
            lblCheckedInCount.TabIndex = 12;
            lblCheckedInCount.Text = "0 ";
            // 
            // lblCheckedInTitle
            // 
            lblCheckedInTitle.AutoSize = true;
            lblCheckedInTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCheckedInTitle.Location = new Point(3, 6);
            lblCheckedInTitle.Name = "lblCheckedInTitle";
            lblCheckedInTitle.Size = new Size(94, 21);
            lblCheckedInTitle.TabIndex = 13;
            lblCheckedInTitle.Text = "Checked In";
            // 
            // curvedCornerPanel2
            // 
            curvedCornerPanel2.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel2.Controls.Add(lblBookedCount);
            curvedCornerPanel2.Controls.Add(lblBookedTitle);
            curvedCornerPanel2.Location = new Point(277, 157);
            curvedCornerPanel2.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel2.Name = "curvedCornerPanel2";
            curvedCornerPanel2.Size = new Size(146, 94);
            curvedCornerPanel2.TabIndex = 17;
            // 
            // lblBookedCount
            // 
            lblBookedCount.AutoSize = true;
            lblBookedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookedCount.ForeColor = Color.FromArgb(26, 70, 130);
            lblBookedCount.Location = new Point(46, 38);
            lblBookedCount.Name = "lblBookedCount";
            lblBookedCount.Size = new Size(47, 45);
            lblBookedCount.TabIndex = 12;
            lblBookedCount.Text = "0 ";
            // 
            // lblBookedTitle
            // 
            lblBookedTitle.AutoSize = true;
            lblBookedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBookedTitle.Location = new Point(3, 6);
            lblBookedTitle.Name = "lblBookedTitle";
            lblBookedTitle.Size = new Size(68, 21);
            lblBookedTitle.TabIndex = 13;
            lblBookedTitle.Text = "Booked";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label7.Location = new Point(289, 82);
            label7.Name = "label7";
            label7.Size = new Size(157, 37);
            label7.TabIndex = 16;
            label7.Text = "DashBoard";
            // 
            // lblNameServiceCentre
            // 
            lblNameServiceCentre.AutoSize = true;
            lblNameServiceCentre.Font = new Font("Segoe UI", 12.3F);
            lblNameServiceCentre.ForeColor = SystemColors.GrayText;
            lblNameServiceCentre.Location = new Point(289, 117);
            lblNameServiceCentre.Name = "lblNameServiceCentre";
            lblNameServiceCentre.Size = new Size(180, 23);
            lblNameServiceCentre.TabIndex = 15;
            lblNameServiceCentre.Text = "(Name Service Centre)";
            // 
            // pnlQManagement
            // 
            pnlQManagement.BackColor = SystemColors.GradientActiveCaption;
            pnlQManagement.Controls.Add(btnCallNext);
            pnlQManagement.Controls.Add(flpQueue);
            pnlQManagement.Controls.Add(label5);
            pnlQManagement.Controls.Add(label6);
            pnlQManagement.Dock = DockStyle.Fill;
            pnlQManagement.Location = new Point(0, 0);
            pnlQManagement.Margin = new Padding(3, 2, 3, 2);
            pnlQManagement.Name = "pnlQManagement";
            pnlQManagement.Padding = new Padding(277, 180, 18, 15);
            pnlQManagement.Size = new Size(1226, 532);
            pnlQManagement.TabIndex = 4;
            // 
            // btnCallNext
            // 
            btnCallNext.BackColor = Color.FromArgb(0, 84, 166);
            btnCallNext.FlatAppearance.BorderSize = 0;
            btnCallNext.FlatStyle = FlatStyle.Flat;
            btnCallNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCallNext.ForeColor = Color.White;
            btnCallNext.HoverColor = Color.Empty;
            btnCallNext.Location = new Point(858, 143);
            btnCallNext.Name = "btnCallNext";
            btnCallNext.PressedColor = Color.Empty;
            btnCallNext.Size = new Size(134, 28);
            btnCallNext.TabIndex = 18;
            btnCallNext.Text = "Call Next";
            btnCallNext.UseVisualStyleBackColor = false;
            btnCallNext.Click += btnCallNext_Click;
            // 
            // flpQueue
            // 
            flpQueue.AutoScroll = true;
            flpQueue.Dock = DockStyle.Fill;
            flpQueue.FlowDirection = FlowDirection.TopDown;
            flpQueue.Location = new Point(277, 180);
            flpQueue.Margin = new Padding(3, 2, 3, 2);
            flpQueue.Name = "flpQueue";
            flpQueue.Size = new Size(931, 337);
            flpQueue.TabIndex = 17;
            flpQueue.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label5.Location = new Point(294, 82);
            label5.Name = "label5";
            label5.Size = new Size(277, 37);
            label5.TabIndex = 16;
            label5.Text = "Queue Management";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12.3F);
            label6.ForeColor = SystemColors.GrayText;
            label6.Location = new Point(301, 117);
            label6.Name = "label6";
            label6.Size = new Size(665, 23);
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
            pnlBookings.Margin = new Padding(3, 2, 3, 2);
            pnlBookings.Name = "pnlBookings";
            pnlBookings.Size = new Size(1226, 532);
            pnlBookings.TabIndex = 4;
            pnlBookings.Paint += pnlBookings_Paint;
            // 
            // curvedCornerPanel10
            // 
            curvedCornerPanel10.BackColor = Color.White;
            curvedCornerPanel10.Controls.Add(dgvTotalBookings);
            curvedCornerPanel10.Location = new Point(277, 157);
            curvedCornerPanel10.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel10.Name = "curvedCornerPanel10";
            curvedCornerPanel10.Padding = new Padding(9, 8, 9, 8);
            curvedCornerPanel10.Size = new Size(996, 310);
            curvedCornerPanel10.TabIndex = 13;
            // 
            // dgvTotalBookings
            // 
            dgvTotalBookings.AllowUserToAddRows = false;
            dgvTotalBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTotalBookings.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvTotalBookings.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(26, 70, 130);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTotalBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTotalBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTotalBookings.Dock = DockStyle.Fill;
            dgvTotalBookings.EnableHeadersVisualStyles = false;
            //dgvTotalBookings.GridColor = SystemColors.GradientActiveCaption;
            dgvTotalBookings.Location = new Point(9, 8);
            dgvTotalBookings.Margin = new Padding(3, 2, 3, 2);
            dgvTotalBookings.Name = "dgvTotalBookings";
            dgvTotalBookings.ReadOnly = true;
            dgvTotalBookings.RowHeadersVisible = false;
            dgvTotalBookings.RowHeadersWidth = 51;
            dgvTotalBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotalBookings.Size = new Size(978, 294);
            dgvTotalBookings.TabIndex = 1;
            //dgvTotalBookings.CellContentClick += dgvTotalBookings_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label2.Location = new Point(277, 82);
            label2.Name = "label2";
            label2.Size = new Size(313, 37);
            label2.TabIndex = 12;
            label2.Text = "Today's Total Bookings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.3F);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(277, 117);
            label4.Name = "label4";
            label4.Size = new Size(553, 23);
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
            pnlSearch.Margin = new Padding(3, 2, 3, 2);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1226, 532);
            pnlSearch.TabIndex = 4;
            // 
            // curvedCornerPanel1
            // 
            curvedCornerPanel1.BackColor = SystemColors.InactiveCaption;
            curvedCornerPanel1.Controls.Add(btnSerchingBooking);
            curvedCornerPanel1.Controls.Add(txtSearching);
            curvedCornerPanel1.Location = new Point(265, 159);
            curvedCornerPanel1.Margin = new Padding(3, 2, 3, 2);
            curvedCornerPanel1.Name = "curvedCornerPanel1";
            curvedCornerPanel1.Size = new Size(929, 94);
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
            btnSerchingBooking.Location = new Point(752, 34);
            btnSerchingBooking.Margin = new Padding(3, 2, 3, 2);
            btnSerchingBooking.Name = "btnSerchingBooking";
            btnSerchingBooking.PressedColor = Color.Empty;
            btnSerchingBooking.Size = new Size(164, 28);
            btnSerchingBooking.TabIndex = 1;
            btnSerchingBooking.Text = "Search";
            btnSerchingBooking.UseVisualStyleBackColor = false;
            btnSerchingBooking.Click += btnSearch_Click;
            // 
            // txtSearching
            // 
            txtSearching.BackColor = Color.White;
            txtSearching.Font = new Font("Segoe UI", 10F);
            txtSearching.Location = new Point(24, 34);
            txtSearching.Margin = new Padding(3, 2, 3, 2);
            txtSearching.Name = "txtSearching";
            txtSearching.PlaceholderText = "Search for a booking";
            txtSearching.Size = new Size(724, 34);
            txtSearching.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label1.Location = new Point(277, 82);
            label1.Name = "label1";
            label1.Size = new Size(228, 37);
            label1.TabIndex = 14;
            label1.Text = "Search Bookings";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.3F);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(277, 117);
            label3.Name = "label3";
            label3.Size = new Size(287, 23);
            label3.TabIndex = 13;
            label3.Text = "Find a booking by reference number";
            // 
            // StaffPortal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 532);
            Controls.Add(pnlSidePanel);
            Controls.Add(pnlTop);
            Controls.Add(pnlBookings);
            Controls.Add(pnlQManagement);
            Controls.Add(pnlStaffDash);
            Controls.Add(pnlSearch);
            Margin = new Padding(3, 2, 3, 2);
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
        private Label lblNameServiceCentre;
        private Classes.CurvedCornerPanel curvedCornerPanel2;
        private Label lblBookedCount;
        private Label lblBookedTitle;
        private Classes.CurvedCornerPanel curvedCornerPanel4;
        private Label lblWaitingCount;
        private Label lblWaitingTitle;
        private Classes.CurvedCornerPanel curvedCornerPanel3;
        private Label lblCheckedInCount;
        private Label lblCheckedInTitle;
        private Classes.CurvedCornerPanel curvedCornerPanel6;
        private Label lblCompletedCount;
        private Label lblCompletedTitle;
        private Classes.CurvedCornerPanel curvedCornerPanel5;
        private Label lblServingCount;
        private Label lblServingTitle;
        private Classes.CurvedCornerPanel curvedCornerPanel7;
        private Label lblNoShowCount;
        private Label lblNoShowTitle;
        private Classes.RoundedButton btnSearchBooking;
        private Classes.RoundedButton btnQueueManagement;
        private Classes.CurvedCornerPanel curvedCornerPanel8;
        private Label lblQueueNumberNowServing;
        private Label lblNowServingTitle;
        private Label label9;
        private Classes.CurvedCornerPanel curvedCornerPanel9;
        private Label lblQueueNumberAndBeneficiaryNameNowServing;
        private Label lblWaitingNowTiltle;
        private Label lblBeneficiaryNameNowServing;
        private Classes.CurvedCornerPanel curvedCornerPanel10;
        private DataGridView dgvTotalBookings;
        private FlowLayoutPanel flpQueue;
        private RoundedButton btnCallNext;
    }
}