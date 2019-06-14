using MagGestion.Controls;
using MagGestion.Model.Enum;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Exit();
        }

        private void DoStuff(EnumAction action)
        {
            try
            {
                switch (action)
                {
                    case EnumAction.ShowClient:
                        MainPanel.Controls.Clear();
                        MainPanel.Controls.Add(new ClientsControl());
                        break;
                    case EnumAction.ShowHistorique:
                        MainPanel.Controls.Clear();
                        MainPanel.Controls.Add(new HistoriqueControl());
                        break;
                    case EnumAction.ManageMagasine:
                        MainPanel.Controls.Clear();
                        MainPanel.Controls.Add(new MagazineControl());
                        break;
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DoStuff(EnumAction.ShowClient);
        }

        private void historiqueToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DoStuff(EnumAction.ShowHistorique);

        }

        private void magasinesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DoStuff(EnumAction.ManageMagasine);

        }
    }
}
