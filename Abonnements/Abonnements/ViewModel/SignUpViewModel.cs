using Abonnements.DataServices;
using Abonnements.Helper;
using Abonnements.Helpers;
using Abonnements.Model.Users;
using Abonnements.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        #region PrivateProperties
        private readonly UserDataService _userDataService;
        private ValidatableObject<string> _userMail;
        private ValidatableObject<string> _userPhone;

        private ValidatableObject<string> _userPassword;
        private ValidatableObject<string> _userPasswordConfirmation;
        private ValidatableObject<string> _userFirstname;
        private ValidatableObject<string> _userLastname;
        private bool _isValid;
        private bool _isEnabled;
        #endregion

        #region PublicProperties
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
        public ValidatableObject<string> UserPhone
        {
            get
            {
                return _userPhone;
            }
            set
            {
                _userPhone = value;
                RaisePropertyChanged(() => UserPhone);
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
        public ValidatableObject<string> UserPasswordConfirmation
        {
            get
            {
                return _userPasswordConfirmation;
            }
            set
            {
                _userPasswordConfirmation = value;
                RaisePropertyChanged(() => UserPasswordConfirmation);
            }
        }
        public ValidatableObject<string> UserFirstName
        {
            get
            {
                return _userFirstname;
            }
            set
            {
                _userFirstname = value;
                RaisePropertyChanged(() => UserFirstName);
            }
        }
        public ValidatableObject<string> UserLastName
        {
            get
            {
                return _userLastname;
            }
            set
            {
                _userLastname = value;
                RaisePropertyChanged(() => UserLastName);
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
        public SignUpViewModel(UserDataService userDataService)
        {
            _userDataService = userDataService;
            _userMail = new ValidatableObject<string>();
            _userPassword = new ValidatableObject<string>();
            _userLastname = new ValidatableObject<string>();
            _userPhone = new ValidatableObject<string>();
            _userPasswordConfirmation = new ValidatableObject<string>();
            _userFirstname = new ValidatableObject<string>();

            AddValidations();

        }
        #endregion

        #region Command

        public ICommand SignUpCommand => new Command(SignUpAsync);

        public ICommand ValidateCommand
        {
            get { return new Command(() => Enable()); }
        }


        #endregion

        #region Private Function

        private async void SignUpAsync()
        {
            IsBusy = true;
            IsValid = true;
            bool isValid = Validate();
            bool isRegistered = false;

            if (isValid)
            {
                try
                {
                    UserSignUp userSignUp = new UserSignUp(_userMail.Value, SaltPassword.GetPasswordHash(_userPassword.Value), _userFirstname.Value, _userLastname.Value, _userPhone.Value);
                    userSignUp = _userDataService.SignUp(userSignUp);
                    if(userSignUp != null && userSignUp.Id > 0)
                    {
                        Settings.CurrentUser = new UserProfile(userSignUp);
                        isRegistered = true;
                    }
                    else
                    {
                        await DialogService.ShowAlertAsync("Erreur lors de l'inscription", "Inscription raté", "Réessayer");
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

            if (isRegistered)
            {
                DialogService.ToastAlert("Inscription réussie");
                await NavigationService.NavigateToAsync<MainViewModel>();
            }

            IsBusy = false;
        }

        private bool Validate()
        {
            AddDynamicValidations();

            bool isValidMail = _userMail.Validate();
            bool isValidPassword = _userPassword.Validate();
            bool isValidPasswordConfirmation = _userPasswordConfirmation.Validate();
            bool isValidePhone = _userPhone.Validate();
            bool isValidFirstname = _userFirstname.Validate();
            bool isValidLastname = _userLastname.Validate();

            return isValidMail && isValidPassword && isValidLastname && isValidFirstname && isValidPasswordConfirmation && isValidePhone;
        }

        private void Enable()
        {
            IsEnabled = !string.IsNullOrEmpty(UserMail.Value) &&
                !string.IsNullOrEmpty(UserPassword.Value) &&
                !string.IsNullOrEmpty(UserPasswordConfirmation.Value) &&
                !string.IsNullOrEmpty(UserLastName.Value) &&
                !string.IsNullOrEmpty(UserFirstName.Value) &&
                !string.IsNullOrEmpty(UserPhone.Value);
        }

        private void AddValidations()
        {
            _userMail.Validations.Add(new EmailRule<string> { ValidationMessage = "L'émail doit être un émail" });
            _userMail.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "L'émail ne doit pas être vide" });

            _userPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le mots de passe ne doit pas être vide" });
            _userPasswordConfirmation.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le mots de passe ne doit pas être vide" });

            _userFirstname.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le prénom ne doit pas être vide" });
            _userLastname.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le nom ne doit pas être vide" });

            UserPhone.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Le téléphone ne doit pas être vide" });
        }

        private void AddDynamicValidations()
        {
            if (_userPasswordConfirmation.Validations
                .Any(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>))))
            {
                var validation = _userPasswordConfirmation.Validations.First(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>)));
                _userPasswordConfirmation.Validations.Remove(validation);
            }

            _userPasswordConfirmation.Validations.Add(new RepeatPasswordRule<string> { ValidationMessage = "The passwords do not match", Password = _userPassword.Value });
        }
        #endregion
    }
}
