using MagGestion.Presenter;
using System;

namespace MagGestion.View.Interface
{
    public interface ILoginView
    {
        LoginPresenter Presenter { set; }
        string Login { get; set; }
        string Password { get; set; }

        event EventHandler ConnectionRequested;
        event EventHandler CloseRequested;

        void Close();
    }
}
