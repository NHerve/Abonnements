using MagGestion.Controls;
using MagGestion.Forms.Interface;
using MagGestion.View.Interface;
using System;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IFormOpener _formOpener;

        public MainPresenter(IMainView view, IFormOpener formOpener)
        {
            _view = view;
            _formOpener = formOpener;
            view.ShowClient += OnShowClient;
            view.ShowMagazine += OnShowMagazine;
            view.ShowHistorique += OnShowHistorique;
            view.CloseRequested += OnClosing;
        }

        private void OnShowClient(object sender, EventArgs e)
        {
            _view.MainPanel.Controls.Clear();
            _view.MainPanel.Controls.Add(_formOpener.CreateNewControl<ClientsControl>());
        }
        private void OnShowMagazine(object sender, EventArgs e)
        {
            _view.MainPanel.Controls.Clear();
            _view.MainPanel.Controls.Add(_formOpener.CreateNewControl<MagazineControl>());
        }
        private void OnShowHistorique(object sender, EventArgs e)
        {
            _view.MainPanel.Controls.Clear();
            _view.MainPanel.Controls.Add(_formOpener.CreateNewControl<HistoriqueControl>());
        }
        private void OnClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
