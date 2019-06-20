using MagGestion.DataServices.Interface;
using MagGestion.Forms.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class LoginForm : Form, ILoginView
    {
        #region Private Property
        private readonly IFormOpener _formOpener;
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;
        #endregion

        public LoginForm(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer, IFormOpener formOpener)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            _formOpener = formOpener;
            InitializeComponent();
            this.CenterToScreen();
        }

        #region Public Property
        public event EventHandler ConnectionRequested;
        public event EventHandler CloseRequested;

        public LoginPresenter Presenter { private get; set; }
        public string Login { get => TBLogin.Text; set => this.TBLogin.Text = value; }
        public string Password { get => TBPassword.Text; set => TBPassword.Text = value; }
        #endregion

        private void BTQuit_Click(object sender, EventArgs e)
        {
            CloseRequested(this, EventArgs.Empty);
        }

        private void BTConnection_Click(object sender, EventArgs e)
        {
            ConnectionRequested(this, EventArgs.Empty);
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            Presenter = new LoginPresenter(this, _formOpener, _cache, _errorLogger, _serializer);
            //Presenter.PopulateDataBase();
        }
    }
}
