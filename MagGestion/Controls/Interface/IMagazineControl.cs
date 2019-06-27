using MagGestion.Presenter;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls.Interface
{
    public interface IMagazineControl : IControl
    {
        MagazineControlPresenter Presenter { set; }
        DataGridView DataGridViewMagazine { get; set; }

        Button BTMag { get; set; }
        event EventHandler MagazineSelected;
        event EventHandler OnShowMagazineForm;
    }
}
