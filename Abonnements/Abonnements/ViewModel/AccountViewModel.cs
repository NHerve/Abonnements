using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Abonnements.DataServices;
using Abonnements.Helpers;
using Abonnements.Model.Users;
using Abonnements.Validations;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        #region PrivateProperties
        private readonly UserDataService _userDataService;
        private UserProfile _profile;
        private ValidatableObject<string> _mail;
        private ValidatableObject<string> _phone;
        private ValidatableObject<DateTime> _birthDay;
        private ValidatableObject<string> _birthLocation;
        private ValidatableObject<string> _ccv;
        private ValidatableObject<string> _cardNumber;
        private ValidatableObject<string> _expirationDate;
        private ValidatableObject<string> _password;

        private ValidatableObject<string> _passwordConfirmation;
        #endregion
        #region PublicProperties
        public UserProfile Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                RaisePropertyChanged(() => Profile);
            }
        }
        public ValidatableObject<string> Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged(() => Mail);
            }
        }
        public ValidatableObject<string> Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                RaisePropertyChanged(() => Phone);
            }
        }
        public ValidatableObject<DateTime> BirthDay
        {
            get
            {
                return _birthDay;
            }
            set
            {
                _birthDay = value;
                RaisePropertyChanged(() => BirthDay);
            }
        }
        public ValidatableObject<string> BirthLocation
        {
            get
            {
                return _birthLocation;
            }
            set
            {
                _birthLocation = value;
                RaisePropertyChanged(() => BirthLocation);
            }
        }
        public ValidatableObject<string> Ccv
        {
            get
            {
                return _ccv;
            }
            set
            {
                _ccv = value;
                RaisePropertyChanged(() => Ccv);
            }
        }
        public ValidatableObject<string> CardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                _cardNumber = value;
                RaisePropertyChanged(() => CardNumber);
            }
        }
        public ValidatableObject<string> ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                _expirationDate = value;
                RaisePropertyChanged(() => ExpirationDate);
            }
        }
        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        public ValidatableObject<string> PasswordConfirmation
        {
            get
            {
                return _passwordConfirmation;
            }
            set
            {
                _passwordConfirmation = value;
                RaisePropertyChanged(() => PasswordConfirmation);
            }
        }

        #endregion

        #region Ctor
        public AccountViewModel(UserDataService userDataService)
        {
            _userDataService = userDataService;
            _profile = Settings.CurrentUser;

            _mail = new ValidatableObject<string>() { Value = Profile.Mail };
            _phone = new ValidatableObject<string>() { Value = Profile.Phone };
            _birthDay = new ValidatableObject<DateTime>() { Value = Profile.BirthDay ?? DateTime.Now.AddYears(-70) };
            _birthLocation = new ValidatableObject<string>() { Value = Profile.BirthLocation };
            _ccv = new ValidatableObject<string>() { Value = Profile.Ccv };
            _cardNumber = new ValidatableObject<string>() { Value = Profile.CardNumber };
            _expirationDate = new ValidatableObject<string>() { Value = Profile.ExpirationDate };
            _password = new ValidatableObject<string>();
            _passwordConfirmation = new ValidatableObject<string>();

            AddValidations();
        }
        #endregion

        #region Command
        public ICommand LogoutCommand => new Command(Logout);

        public ICommand EditCommand => new Command(Edit);

        #endregion

        #region Private Function
        private async void Logout()
        {
            var result = await DialogService.ConfirmAsync("Souhaitez-vous réellement vous déconnectez ?","","Oui", "Non");
            if (result)
            {
                //Logout
                Settings.CurrentUser = null;
                await NavigationService.NavigateToAsync<LoginViewModel>();

            }
        }
        private void AddValidations()
        {
            _mail.Validations.Add(new EmailRule<string> { ValidationMessage = "L'émail doit être un émail" });
            _mail.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "L'émail ne doit pas être vide" });
        }

        private async void Edit()
        {
            //Check if data are valid
            bool result = await DialogService.ConfirmAsync("Souhaitez-vous réellement éditez vos données?", "", "Oui", "Non");
            if (result)
            {
                try
                {
                    AddDynamicValidations();
                    //Edit
                    if (!string.IsNullOrEmpty(_mail.Value) && _profile.Mail != _mail.Value)
                        _profile.Mail = _mail.Value;

                    if (!string.IsNullOrEmpty(_phone.Value) && _profile.Phone != _phone.Value)
                        _profile.Phone = _phone.Value;

                    if (!string.IsNullOrEmpty(_expirationDate.Value) && _profile.ExpirationDate != _expirationDate.Value)
                        _profile.ExpirationDate = _expirationDate.Value;

                    if (!string.IsNullOrEmpty(_ccv.Value) && _profile.Ccv != _ccv.Value)
                        _profile.Ccv = _ccv.Value;

                    if (!string.IsNullOrEmpty(_cardNumber.Value) && _profile.CardNumber != _cardNumber.Value)
                        _profile.CardNumber = _cardNumber.Value;

                    if (_profile.BirthDay?.Equals(_birthDay.Value) == false)
                        _profile.BirthDay = _birthDay.Value;

                    if (!string.IsNullOrEmpty(_birthLocation.Value) && _profile.BirthLocation != _birthLocation.Value)
                        _profile.BirthLocation = _birthLocation.Value;

                    _userDataService.Update(_profile);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
        }

        private void AddDynamicValidations()
        {
            if (_passwordConfirmation.Validations
                .Any(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>))))
            {
                var validation = _passwordConfirmation.Validations.First(v => v.GetType().Equals(typeof(RepeatPasswordRule<string>)));
                _passwordConfirmation.Validations.Remove(validation);
            }

            _passwordConfirmation.Validations.Add(new RepeatPasswordRule<string> { ValidationMessage = "The passwords do not match", Password = _password.Value });
        }
        #endregion

    }
}
