using MagGestion.Presenter;
using System;
using System.Windows.Forms;

namespace MagGestion.View.Interface
{
    public interface IClientView
    {
        int Id { set; get; }
        string Motif { get;}
        string Nom { set; }
        string Prenom { set; }
        string Telephone { set; }
        string Mail { set; }
        string BirthDay { set; }

        DataGridView DataGridViewHistorique { get; set; }

        DataGridView DataGridViewClientAbonnement { get; set; }


        ClientPresenter Presenter { set; }

        event EventHandler CloseRequested;
        event EventHandler CreationHistoriqueRequested;

        event EventHandler OnSuspendAbonnement;
        event EventHandler OnRepayAbonnement;

        void Close();

    }
}
