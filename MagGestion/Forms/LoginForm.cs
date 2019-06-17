using System;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void BTQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTConnection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBLogin.Text) && !string.IsNullOrEmpty(TBPassword.Text))
            {
                new MainForm().Show();
                this.Close();
            }
        }
    }
}
