using MagGestion.Presenter;
using System;

namespace MagGestion.View.Interface
{
    public interface IClientView
    {
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
