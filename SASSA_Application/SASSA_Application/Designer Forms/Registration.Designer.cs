namespace SASSA_Application.Designer_Forms
{
    partial class Registration
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
            lblHeading = new Label();
            label1 = new Label();
            lblServiceCentre = new Label();
            txtFullName = new SASSA_Application.Classes.RoundedTextBox();
            txtLastName = new SASSA_Application.Classes.RoundedTextBox();
            label2 = new Label();
            roundedTextBox1 = new SASSA_Application.Classes.RoundedTextBox();
            label3 = new Label();
            roundedTextBox2 = new SASSA_Application.Classes.RoundedTextBox();
            label4 = new Label();
            roundedTextBox3 = new SASSA_Application.Classes.RoundedTextBox();
            label5 = new Label();
            label6 = new Label();
            cmbServiceCentre = new SASSA_Application.Classes.RoundedComboBox();
            roundedButton1 = new SASSA_Application.Classes.RoundedButton();
            roundedButton2 = new SASSA_Application.Classes.RoundedButton();
            txtPassword = new SASSA_Application.Classes.RoundedTextBox();
            label7 = new Label();
            roundedTextBox5 = new SASSA_Application.Classes.RoundedTextBox();
            label8 = new Label();
            lblShowPassword = new Label();
            SuspendLayout();
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            lblHeading.Location = new Point(239, 21);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(263, 46);
            lblHeading.TabIndex = 9;
            lblHeading.Text = "Create Account";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 70, 130);
            label1.Location = new Point(239, 67);
            label1.Name = "label1";
            label1.Size = new Size(237, 28);
            label1.TabIndex = 10;
            label1.Text = "Book your visit. Save time.";
            // 
            // lblServiceCentre
            // 
            lblServiceCentre.AutoSize = true;
            lblServiceCentre.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblServiceCentre.Location = new Point(177, 120);
            lblServiceCentre.Name = "lblServiceCentre";
            lblServiceCentre.Size = new Size(97, 25);
            lblServiceCentre.TabIndex = 11;
            lblServiceCentre.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(307, 120);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Enter Your Full Name";
            txtFullName.Size = new Size(312, 45);
            txtFullName.TabIndex = 12;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(307, 182);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Enter Your Last Name";
            txtLastName.Size = new Size(312, 45);
            txtLastName.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label2.Location = new Point(173, 180);
            label2.Name = "label2";
            label2.Size = new Size(101, 25);
            label2.TabIndex = 13;
            label2.Text = "Last Name";
            // 
            // roundedTextBox1
            // 
            roundedTextBox1.BackColor = Color.White;
            roundedTextBox1.Font = new Font("Segoe UI", 10F);
            roundedTextBox1.Location = new Point(307, 243);
            roundedTextBox1.MaxLength = 13;
            roundedTextBox1.Name = "roundedTextBox1";
            roundedTextBox1.PlaceholderText = "Enter South African ID";
            roundedTextBox1.Size = new Size(312, 45);
            roundedTextBox1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label3.Location = new Point(169, 239);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 15;
            label3.Text = "ID Number";
            // 
            // roundedTextBox2
            // 
            roundedTextBox2.BackColor = Color.White;
            roundedTextBox2.Font = new Font("Segoe UI", 10F);
            roundedTextBox2.Location = new Point(307, 307);
            roundedTextBox2.MaxLength = 10;
            roundedTextBox2.Name = "roundedTextBox2";
            roundedTextBox2.PlaceholderText = "e.g.0725576865";
            roundedTextBox2.Size = new Size(312, 45);
            roundedTextBox2.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label4.Location = new Point(134, 301);
            label4.Name = "label4";
            label4.Size = new Size(140, 25);
            label4.TabIndex = 17;
            label4.Text = "Phone Number";
            // 
            // roundedTextBox3
            // 
            roundedTextBox3.BackColor = Color.White;
            roundedTextBox3.Font = new Font("Segoe UI", 10F);
            roundedTextBox3.Location = new Point(307, 370);
            roundedTextBox3.Name = "roundedTextBox3";
            roundedTextBox3.PlaceholderText = "e.g Sassa@gmail.com";
            roundedTextBox3.Size = new Size(312, 45);
            roundedTextBox3.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label5.Location = new Point(143, 362);
            label5.Name = "label5";
            label5.Size = new Size(131, 25);
            label5.TabIndex = 19;
            label5.Text = "Email Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label6.Location = new Point(58, 435);
            label6.Name = "label6";
            label6.Size = new Size(216, 25);
            label6.TabIndex = 21;
            label6.Text = "Preferred service centre";
            // 
            // cmbServiceCentre
            // 
            cmbServiceCentre.BackColor = Color.White;
            cmbServiceCentre.Font = new Font("Segoe UI", 10F);
            cmbServiceCentre.ForeColor = Color.FromArgb(30, 30, 30);
            cmbServiceCentre.Location = new Point(307, 435);
            cmbServiceCentre.Name = "cmbServiceCentre";
            cmbServiceCentre.PlaceholderText = "Select a centre";
            cmbServiceCentre.Size = new Size(312, 45);
            cmbServiceCentre.TabIndex = 22;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(26, 70, 130);
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            roundedButton1.ForeColor = SystemColors.GradientActiveCaption;
            roundedButton1.HoverColor = Color.Empty;
            roundedButton1.Location = new Point(102, 629);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.PressedColor = Color.Empty;
            roundedButton1.Size = new Size(307, 50);
            roundedButton1.TabIndex = 23;
            roundedButton1.Text = "Register";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = SystemColors.GradientActiveCaption;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            roundedButton2.ForeColor = Color.FromArgb(26, 70, 130);
            roundedButton2.HoverColor = Color.Empty;
            roundedButton2.Location = new Point(511, 629);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.PressedColor = Color.Empty;
            roundedButton2.Size = new Size(108, 50);
            roundedButton2.TabIndex = 24;
            roundedButton2.Text = "↩️ Back";
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(307, 493);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "minimum of 6 characters";
            txtPassword.Size = new Size(312, 45);
            txtPassword.TabIndex = 26;
            txtPassword.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label7.Location = new Point(177, 493);
            label7.Name = "label7";
            label7.Size = new Size(92, 25);
            label7.TabIndex = 25;
            label7.Text = "Password";
            // 
            // roundedTextBox5
            // 
            roundedTextBox5.BackColor = Color.White;
            roundedTextBox5.Font = new Font("Segoe UI", 10F);
            roundedTextBox5.Location = new Point(307, 556);
            roundedTextBox5.Name = "roundedTextBox5";
            roundedTextBox5.PlaceholderText = "confirm Password";
            roundedTextBox5.Size = new Size(312, 45);
            roundedTextBox5.TabIndex = 28;
            roundedTextBox5.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label8.Location = new Point(102, 556);
            label8.Name = "label8";
            label8.Size = new Size(165, 25);
            label8.TabIndex = 27;
            label8.Text = "Confirm Password";
            // 
            // lblShowPassword
            // 
            lblShowPassword.AutoSize = true;
            lblShowPassword.ForeColor = Color.FromArgb(26, 70, 130);
            lblShowPassword.Location = new Point(625, 511);
            lblShowPassword.Name = "lblShowPassword";
            lblShowPassword.Size = new Size(66, 20);
            lblShowPassword.TabIndex = 29;
            lblShowPassword.Text = "👁️Show";
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(753, 710);
            Controls.Add(lblShowPassword);
            Controls.Add(roundedTextBox5);
            Controls.Add(label8);
            Controls.Add(txtPassword);
            Controls.Add(label7);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(cmbServiceCentre);
            Controls.Add(label6);
            Controls.Add(roundedTextBox3);
            Controls.Add(label5);
            Controls.Add(roundedTextBox2);
            Controls.Add(label4);
            Controls.Add(roundedTextBox1);
            Controls.Add(label3);
            Controls.Add(txtLastName);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(lblHeading);
            Controls.Add(label1);
            Controls.Add(lblServiceCentre);
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            Load += Registration_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeading;
        private Label label1;
        private Label lblServiceCentre;
        private Classes.RoundedTextBox txtFullName;
        private Classes.RoundedTextBox txtLastName;
        private Label label2;
        private Classes.RoundedTextBox roundedTextBox1;
        private Label label3;
        private Classes.RoundedTextBox roundedTextBox2;
        private Label label4;
        private Classes.RoundedTextBox roundedTextBox3;
        private Label label5;
        private Label label6;
        private Classes.RoundedComboBox cmbServiceCentre;
        private Classes.RoundedButton roundedButton1;
        private Classes.RoundedButton roundedButton2;
        private Classes.RoundedTextBox txtPassword;
        private Label label7;
        private Classes.RoundedTextBox roundedTextBox5;
        private Label label8;
        private Label lblShowPassword;
    }
}