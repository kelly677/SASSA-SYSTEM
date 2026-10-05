using SASSA_Application.Designer_Forms;

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
            register.FormClosed += (s, args) => this.Show();   // when it closes, the login form comes back
            register.Show();
            this.Hide();
        }
    }
}
