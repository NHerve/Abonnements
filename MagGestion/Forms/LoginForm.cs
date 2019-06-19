using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Forms.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Employe;
using RestSharp.Deserializers;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IFormOpener _formOpener;
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public LoginForm(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer, IFormOpener formOpener)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            _formOpener = formOpener;
            InitializeComponent();
            this.CenterToScreen();
            //Initialize();
        }

        private void BTQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTConnection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBLogin.Text) && !string.IsNullOrEmpty(TBPassword.Text))
            {
                string savedPasswordHash = new EmployeDataService(_cache, _serializer, _errorLogger).GetEmploye(TBLogin.Text)?.Password ?? "";
                if (SaltPassword.ComparePassword(savedPasswordHash, TBPassword.Text))
                {
                    _formOpener.ShowModalForm<MainForm>();
                    this.Close();
                }
            }
        }

        private void Initialize()
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
