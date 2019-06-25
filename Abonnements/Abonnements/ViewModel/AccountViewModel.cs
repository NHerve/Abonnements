using System;
using System.Collections.Generic;
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
        public ValidatableObject<DateTime> Birthday
        {
            get
            {
                return _birthDay;
            }
            set
            {
                _birthDay = value;
                RaisePropertyChanged(() => Birthday);
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
            _birthDay = new ValidatableObject<DateTime>() { Value = Profile.BirthDay ?? new DateTime() };
            _ccv = new ValidatableObject<string>() { Value = Profile.Ccv };
            _expirationDate = new ValidatableObject<string>() { Value = Profile.ExpirationDate };
            _password = new ValidatableObject<string>();
            _passwordConfirmation = new ValidatableObject<string>();

            //Todo : Uncomment below comment when login will work
           // _profile = new UserProfile("Hervé", "Aymes", "ha@gmail.com", "", DateTime.Now, "", "874", "69465464985", "0529");
        }
        #endregion

        #region Command
        public ICommand LogoutCommand => new Command(Logout);

        public ICommand EditCommand => new Command(Edit);

        #endregion

        #region Private Function
        private void Logout()
        {
            var result = DialogService.ConfirmAsync("Souhaitez-vous réellement vous déconnectez ?","","Oui", "Non");
            if (result.Result)
            {
                //Logout
                Settings.CurrentUser = null;
                NavigationService.NavigateToAsync<LoginViewModel>();

            }
        }

        private async void Edit()
        {
            //Check if data are valid
            bool result = await DialogService.ConfirmAsync("Souhaitez-vous réellement éditez vos données?", "", "Oui", "Non");
            if (result)
            {
                //Edit
                _userDataService.Update(_profile);
            }
        }

        //Todo : Add Validation if field is not empty. (Dynamic Validation)
        #endregion

    }
}
