using MagGestion.Presenter;
using System;
using System.IO;
using System.Windows.Forms;

namespace MagGestion.View.Interface
{
    public interface IMagazineView
    {
        int Id { set; get; }
        string Titre { get; set; }
        string URLPhoto { set; get; }
        decimal PrixAnnee{ set; get; }
        string Description { set; get; }
        int NumeroAnnee { set; get; }

        MagazineViewPresenter Presenter { set; }
        event EventHandler SaveMagazine;
        event EventHandler CreateMagazine;
        void Close();
    }
}
