using MagGestion.Presenter;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls.Interface
{
    public interface IClientControl : IControl
    {

        ClientControlPresenter Presenter { set; }
        DataGridView DataGridViewClient { get; set; }

        Button ButtonClient { get; set; }
        event EventHandler ClientSelected;
        event EventHandler OnShowClientForm;
    }
}
