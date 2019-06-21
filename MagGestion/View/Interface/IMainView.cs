using MagGestion.Presenter;
using System;
using System.Windows.Forms;

namespace MagGestion.View.Interface
{
    public interface IMainView
    {
        MainPresenter Presenter { set; }

        Panel MainPanel { get; }

        event EventHandler ShowClient;
        event EventHandler ShowMagazine;
        event EventHandler ShowHistorique;
        event EventHandler CloseRequested;
    }
}
