using MagGestion.Presenter;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls.Interface
{
    public interface IHistoriqueControl : IControl
    {
        HistoriqueControlPresenter Presenter { set; }
        DataGridView DataGridViewHistorique { get; set; }

        Button ButtonClient { get; set; }
        event EventHandler HistoriqueSelected;
        event EventHandler OnShowClientForm;
    }
}
