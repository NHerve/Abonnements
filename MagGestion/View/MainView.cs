using MagGestion.Forms.Interface;
using MagGestion.Presenter;
using MagGestion.View.Interface;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MainView : Form, IMainView
    {
        private readonly IFormOpener _formOpener;

        public MainView(IFormOpener formOpener)
        {
            InitializeComponent();
            _formOpener = formOpener;
            this.CenterToScreen();
        }

        public MainPresenter Presenter { private get; set; }

        Panel IMainView.MainPanel => MainPanel;

        public event EventHandler ShowClient;
        public event EventHandler ShowMagazine;
        public event EventHandler ShowHistorique;
        public event EventHandler CloseRequested;


        protected override void OnClosing(CancelEventArgs e)
        {
            CloseRequested(this, EventArgs.Empty);
        }



        private void clientsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowClient(this, EventArgs.Empty);
        }

        private void historiqueToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowHistorique(this, EventArgs.Empty);
        }

        private void magasinesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowMagazine(this, EventArgs.Empty);

        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Presenter = new MainPresenter(this, _formOpener);
        }
    }
}
