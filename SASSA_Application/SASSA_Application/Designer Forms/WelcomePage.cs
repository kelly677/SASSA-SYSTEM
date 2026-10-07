using SASSA_Application.Designer_Forms;
using System.IO;

namespace SASSA_Application
{
    public partial class frmWelcomePage : Form
    {
        public frmWelcomePage()
        {
            InitializeComponent();
        }

        private void lblSlogan_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Registration register = new Registration();
            register.FormClosed += (s, args) => this.Show();
            register.Show();
            this.Hide();
        }

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

            string filepath = Path.Combine(Application.StartupPath, "Users.txt");
            if (!File.Exists(filepath))
            {
                MessageBox.Show("No, accounts registered yet", "Login failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            string[] lines = File.ReadAllLines(filepath);
            bool isAuthenticated = false;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 8) continue;

                string savedIdNum = parts[2].Trim();//SA ID
                string savedUserCode = parts[3].Trim();//beneficiary
                string savedEmail = parts[5].Trim();
                string savedPassword = parts[7].Trim();

                bool idMatches = id.Equals(savedIdNum, StringComparison.OrdinalIgnoreCase) ||
                                 id.Equals(savedUserCode, StringComparison.OrdinalIgnoreCase) ||
                                 id.Equals(savedEmail, StringComparison.OrdinalIgnoreCase);

                bool passMatches = password.Equals(savedPassword);
                if (idMatches && passMatches)
                {
                    isAuthenticated = true;
                    if (savedPassword.Contains("Admin") || savedUserCode.StartsWith("ADMIN", StringComparison.OrdinalIgnoreCase))
                    {
                        AdminPortal admin = new AdminPortal();
                        admin.Show();
                    }
                    else if (savedUserCode.StartsWith("STAFF", StringComparison.OrdinalIgnoreCase))
                        // || savedIdNum.Length == 13 && !savedUserCode.StartsWith("BENEFICIARY", StringComparison.OrdinalIgnoreCase))
                    {
                        StaffPortal staff = new StaffPortal();
                        staff.Show();
                    }
                    else
                    {
                        BeneficiaryPortal beneficiary = new BeneficiaryPortal();
                        beneficiary.Show();
                    }
                    this.Hide();
                    return;
                }
            }
            if (!isAuthenticated)
            {
                MessageBox.Show("Invalid credentials.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
    

