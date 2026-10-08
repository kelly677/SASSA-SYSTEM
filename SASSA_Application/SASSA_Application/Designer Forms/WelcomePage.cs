using SASSA_Application.Designer_Forms;
using SASSA_Application.Classes;
using System;
using System.IO;
using System.Windows.Forms;

namespace SASSA_Application
{
    public partial class frmWelcomePage : Form
    {
        public frmWelcomePage()
        {
            InitializeComponent();
        }

        // ============================================================
        // FORM LOAD — hide password initially
        // ============================================================
        private void frmWelcomePage_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            lblShowPassword.Text = "👁️ Show";
        }

        // ============================================================
        // CREATE ACCOUNT BUTTON
        // ============================================================
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Registration register = new Registration();
            register.FormClosed += (s, args) => this.Show();
            register.Show();
            this.Hide();
        }

        // ============================================================
        // SHOW / HIDE PASSWORD
        // ============================================================
        //private void lblShowPassword_Click(object sender, EventArgs e)
        //{
        //    if (txtPassword.PasswordChar == '*')
        //    {
        //        txtPassword.PasswordChar = '\0';
        //        lblShowPassword.Text = "🙈 Hide";
        //    }
        //    else
        //    {
        //        txtPassword.PasswordChar = '*';
        //        lblShowPassword.Text = "👁️ Show";
        //    }
        //}

        // ============================================================
        // LOGIN BUTTON
        // ============================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your ID and password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ============================================================
            // STAFF LOGIN — password is an email
            // ============================================================
            if (password.Contains("@") && password.Contains("."))
            {
                if (File.Exists("Staff.txt"))
                {
                    foreach (string line in File.ReadAllLines("Staff.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split('|');
                        if (parts.Length < 4) continue;

                        string staffName = parts[0];
                        string savedStaffNumber = parts[1];
                        string savedCentre = parts[2];
                        string savedEmail = parts[3];

                        if (savedStaffNumber == id && savedEmail == password)
                        {
                            MessageBox.Show("Welcome " + staffName + "!", "Staff Login",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            StaffPortal staff = new StaffPortal(staffName, savedCentre);
                            staff.Show();
                            this.Hide();
                            return;
                        }
                    }
                }

                MessageBox.Show("Invalid staff number or email.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ============================================================
            // ADMIN / BENEFICIARY LOGIN
            // ============================================================
            if (!File.Exists("Beneficiaries.txt"))
            {
                MessageBox.Show("No accounts registered yet.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 7) continue;

                string savedName = parts[0];
                string savedSurname = parts[1];
                string savedId = parts[2];
                string savedPassword = parts[6];

                if (savedId == id && savedPassword == password)
                {
                    if (savedPassword.Contains("Admin"))
                    {
                        string adminFullName = savedName + " " + savedSurname;
                        AdminPortal admin = new AdminPortal(adminFullName);
                        admin.Show();
                    }
                    else
                    {
                        // Build the full Beneficiary object and pass it in
                        Beneficiary loggedIn = new Beneficiary
                        {
                            Name = savedName,
                            Surname = savedSurname,
                            IdNumber = savedId,
                            Cell = parts[3],
                            Email = parts[4],
                            PreferredCentre = parts[5],
                            Password = savedPassword
                        };

                        BeneficiaryPortal bene = new BeneficiaryPortal(loggedIn);
                        bene.Show();
                    }

                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Invalid ID number or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ============================================================
        // FORGOT PASSWORD
        // ============================================================
        //private void lblForgotPassword_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Please contact your nearest SASSA service centre to reset your password.",
        //                    "Forgot Password",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void lblShowPassword_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                lblShowPassword.Text = "🙈 Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                lblShowPassword.Text = "👁️ Show";
            }
        }

        private void lblForgotPassword_Click_1(object sender, EventArgs e)
        {
            ForgotPasswordForm form = new ForgotPasswordForm();
            form.ShowDialog();
        }
    }
}