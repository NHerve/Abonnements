using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class ClientForm : Form
    {
        private Control _control;
        public ClientForm(Control control)
        {
            InitializeComponent();
            _control = control;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void BTQuit_click(object sender, System.EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;

            this.Close();
        }
    }
}
