using MagGestion.Controls;
using MagGestion.DataServices.Interface;
using MagGestion.Forms.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Model.Enum;
using RestSharp.Deserializers;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MainForm : Form
    {
        private readonly IFormOpener _formOpener;
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public MainForm(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer, IFormOpener formOpener)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            _formOpener = formOpener;
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
                        MainPanel.Controls.Add(_formOpener.CreateNewControl<ClientsControl>());
                        break;
                    case EnumAction.ShowHistorique:
                        MainPanel.Controls.Clear();
                        MainPanel.Controls.Add(new HistoriqueControl(_cache, _errorLogger, _serializer));
                        break;
                    case EnumAction.ManageMagasine:
                        MainPanel.Controls.Clear();
                        MainPanel.Controls.Add(new MagazineControl(_cache, _errorLogger, _serializer));
                        break;
                }
            }
            catch (System.Exception)
            {
                
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
