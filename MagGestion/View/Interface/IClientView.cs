using MagGestion.Presenter;
using System;

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

        ClientPresenter Presenter { set; }

        event EventHandler CloseRequested;
        event EventHandler CreationHistoriqueRequested;
        void Close();

    }
}
