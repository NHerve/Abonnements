using Abonnements.DataServices;
using Abonnements.Helpers;
using Abonnements.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        #region PrivateProperty
        private readonly UserDataService _userDataService;
        private ValidatableObject<string> _userMail;
        private ValidatableObject<string> _userPassword;
        private bool _isValid;
        private bool _isEnabled;
        #endregion
        #region PublicProperty
        public ValidatableObject<string> UserMail
        {
            get
            {
                return _userMail;
            }
            set
            {
                _userMail = value;
                RaisePropertyChanged(() => UserMail);
            }
        }

        public ValidatableObject<string> UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                RaisePropertyChanged(() => UserPassword);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        #endregion

        #region Ctor
        public LoginViewModel(UserDataService userDataService)
        {
            _userDataService = userDataService;
            _userMail = new ValidatableObject<string>();
            _userPassword = new ValidatableObject<string>();
            AddValidations();
        }
        #endregion

        #region Command
        public ICommand SignInCommand => new Command(SignInAsync);

        public ICommand GoToSignUpCommand => new Command(GoToSignUp);

        public ICommand ValidateCommand
        {
            get { return new Command(() => Enable()); }
        }

        #endregion
        #region Private Function
        private async void SignInAsync()
        {
            IsBusy = true;
            IsValid = true;
            bool isValid = Validate();
            bool isAuthenticated = false;

            if (isValid)
            {
                try
                {
                    using(DialogService.LoadingAlert("Connexion en cours", true, Acr.UserDialogs.MaskType.Black))
                    {

                    //isAuthenticated = await _authenticationService.LoginAsync(UserMail.Value, Password.Value);
                    Settings.CurrentUser =_userDataService.Login(new Model.Users.UserConnection(_userMail.Value, _userPassword.Value));
                    if(Settings.CurrentUser != null)
                    {
                        isAuthenticated = true;
                    }
                    else
                    {
                        await DialogService.ShowAlertAsync("Erreur lors de la connection", "Erreur de connection", "Ok");
                    }
                    }
                }
                catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
                {
                    await DialogService.ShowAlertAsync("Invalid credentials", "Login failure", "Try again");
                    Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                    await DialogService.ShowAlertAsync("Communication error", "Error", "Ok");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                }
            }
            else
            {
                IsValid = false;
            }

            if (isAuthenticated)
            {
                await NavigationService.NavigateToAsync<MainViewModel>();
            }

            IsBusy = false;
        }

        private async void GoToSignUp()
        {
            await NavigationService.NavigateToAsync<SignUpViewModel>();
        }

        private bool Validate()
        {
            bool isValidUser = _userMail.Validate();
            bool isValidPassword = _userPassword.Validate();

            return isValidUser && isValidPassword;
        }

        private void Enable()
        {
            IsEnabled = !string.IsNullOrEmpty(UserMail.Value) &&
                !string.IsNullOrEmpty(UserPassword.Value);
        }

        private void AddValidations()
        {
            _userMail.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "L'émail ne doit pas être vide" });
            _userPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le mots de passe ne doit pas être vide" });
        }
        #endregion

        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
        #endregion
    }
}
