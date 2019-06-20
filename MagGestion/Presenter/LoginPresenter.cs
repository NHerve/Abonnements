using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms;
using MagGestion.Forms.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Employe;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class LoginPresenter : BasePresenter
    {
        private readonly ILoginView _view;

        public LoginPresenter(ILoginView view, IFormOpener formOpener, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(formOpener, cache, errorLogger, serializer)
        {
            _view = view;
            view.CloseRequested += OnCloseRequested;
            view.ConnectionRequested += OnConnectionRequested;
        }

        private void OnCloseRequested(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnConnectionRequested(object sender, EventArgs e)
        {
            if (_view.Login == "demo")
            {
                _view.Close();
                _formOpener.ShowModalForm<MainView>();

            }
            else if (!string.IsNullOrEmpty(_view.Login) && !string.IsNullOrEmpty(_view.Password))
            {

                string savedPasswordHash = new EmployeDataService(_cache, _serializer, _errorLogger).GetEmploye(_view.Login)?.Password ?? "";
                if (SaltPassword.ComparePassword(savedPasswordHash, _view.Password))
                {
                    _formOpener.ShowModalForm<MainView>();
                    _view.Close();
                }
            }
        }
        public void PopulateDataBase()
        {
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test", SaltPassword.GetPasswordHash("test")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test2", SaltPassword.GetPasswordHash("test2")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test3", SaltPassword.GetPasswordHash("test3")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test3", SaltPassword.GetPasswordHash("test4")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test4", SaltPassword.GetPasswordHash("test5")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test5", SaltPassword.GetPasswordHash("test6")));
            new EmployeDataService(_cache, _serializer, _errorLogger).PostEmploye(new Employe("Test6", SaltPassword.GetPasswordHash("test7")));

        }
    }
}
