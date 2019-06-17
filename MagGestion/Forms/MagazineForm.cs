using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MagazineForm : Form
    {
        private Control _control;
        public MagazineForm(Control control)
        {
            InitializeComponent();
            _control = control;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void BTQuit_Click(object sender, EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;

            this.Close();
        }
    }
}
