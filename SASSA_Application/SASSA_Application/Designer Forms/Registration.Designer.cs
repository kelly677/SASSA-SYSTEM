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
            components = new System.ComponentModel.Container();
            lblHeading = new Label();
            label1 = new Label();
            lblServiceCentre = new Label();
            txtFullName = new SASSA_Application.Classes.RoundedTextBox();
            txtLastName = new SASSA_Application.Classes.RoundedTextBox();
            label2 = new Label();
            txtIDNumber = new SASSA_Application.Classes.RoundedTextBox();
            label3 = new Label();
            txtPhoneNumber = new SASSA_Application.Classes.RoundedTextBox();
            label4 = new Label();
            txtEmail = new SASSA_Application.Classes.RoundedTextBox();
            label5 = new Label();
            label6 = new Label();
            cmbServiceCentre = new SASSA_Application.Classes.RoundedComboBox();
            btnRegisterAccount = new SASSA_Application.Classes.RoundedButton();
            btnBack = new SASSA_Application.Classes.RoundedButton();
            txtPassword = new SASSA_Application.Classes.RoundedTextBox();
            label7 = new Label();
            txtConfirmPassword = new SASSA_Application.Classes.RoundedTextBox();
            label8 = new Label();
            lblShowPassword = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            txtLastName.Location = new Point(307, 181);
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
            // txtIDNumber
            // 
            txtIDNumber.BackColor = Color.White;
            txtIDNumber.Font = new Font("Segoe UI", 10F);
            txtIDNumber.Location = new Point(307, 243);
            txtIDNumber.MaxLength = 13;
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.PlaceholderText = "Enter South African ID";
            txtIDNumber.Size = new Size(312, 45);
            txtIDNumber.TabIndex = 16;
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
            // txtPhoneNumber
            // 
            txtPhoneNumber.BackColor = Color.White;
            txtPhoneNumber.Font = new Font("Segoe UI", 10F);
            txtPhoneNumber.Location = new Point(307, 307);
            txtPhoneNumber.MaxLength = 10;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "e.g.0725576865";
            txtPhoneNumber.Size = new Size(312, 45);
            txtPhoneNumber.TabIndex = 18;
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
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(307, 371);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "e.g Sassa@gmail.com";
            txtEmail.Size = new Size(312, 45);
            txtEmail.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label5.Location = new Point(143, 363);
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
            cmbServiceCentre.Click += cmbServiceCentre_TextChanged;
            // 
            // btnRegisterAccount
            // 
            btnRegisterAccount.BackColor = Color.FromArgb(26, 70, 130);
            btnRegisterAccount.FlatAppearance.BorderSize = 0;
            btnRegisterAccount.FlatStyle = FlatStyle.Flat;
            btnRegisterAccount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegisterAccount.ForeColor = SystemColors.GradientActiveCaption;
            btnRegisterAccount.HoverColor = Color.Empty;
            btnRegisterAccount.Location = new Point(102, 629);
            btnRegisterAccount.Name = "btnRegisterAccount";
            btnRegisterAccount.PressedColor = Color.Empty;
            btnRegisterAccount.Size = new Size(307, 51);
            btnRegisterAccount.TabIndex = 23;
            btnRegisterAccount.Text = "Register";
            btnRegisterAccount.UseVisualStyleBackColor = false;
            btnRegisterAccount.Click += btnRegisterAccount_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.GradientActiveCaption;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(26, 70, 130);
            btnBack.HoverColor = Color.Empty;
            btnBack.Location = new Point(511, 629);
            btnBack.Name = "btnBack";
            btnBack.PressedColor = Color.Empty;
            btnBack.Size = new Size(107, 51);
            btnBack.TabIndex = 24;
            btnBack.Text = "↩️ Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
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
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(307, 556);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "confirm Password";
            txtConfirmPassword.Size = new Size(312, 45);
            txtConfirmPassword.TabIndex = 28;
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
            lblShowPassword.Click += lblShowPassword_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(753, 709);
            Controls.Add(lblShowPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label8);
            Controls.Add(txtPassword);
            Controls.Add(label7);
            Controls.Add(btnBack);
            Controls.Add(btnRegisterAccount);
            Controls.Add(cmbServiceCentre);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label4);
            Controls.Add(txtIDNumber);
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
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private Classes.RoundedTextBox txtIDNumber;
        private Label label3;
        private Classes.RoundedTextBox txtPhoneNumber;
        private Label label4;
        private Classes.RoundedTextBox txtEmail;
        private Label label5;
        private Label label6;
        private Classes.RoundedComboBox cmbServiceCentre;
        private Classes.RoundedButton btnRegisterAccount;
        private Classes.RoundedButton btnBack;
        private Classes.RoundedTextBox txtPassword;
        private Label label7;
        private Classes.RoundedTextBox txtConfirmPassword;
        private Label label8;
        private Label lblShowPassword;
        private ErrorProvider errorProvider1;
    }
}