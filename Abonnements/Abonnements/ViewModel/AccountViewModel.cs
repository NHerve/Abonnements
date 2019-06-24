using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Abonnements.DataServices;
using Abonnements.Helpers;
using Abonnements.Model.Users;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        #region PrivateProperties
        private readonly UserDataService _userDataService;
        private UserProfile _profile;
        #endregion

        #region Ctor
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
        #endregion

        #region Ctor
        public AccountViewModel(UserDataService userDataService)
        {
            _userDataService = userDataService;
            //Todo : Uncomment below comment when login will work
            _profile = Settings.CurrentUser;
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
            }
        }

        private void Edit()
        {
            //Check if data are valid
            var result = DialogService.ConfirmAsync("Souhaitez-vous réellement éditez vos données?", "", "Oui", "Non");
            if (result.Result)
            {
                //Edit
                _userDataService.Update(_profile);
            }
        }

        //Todo : Add Validation if field is not empty. (Dynamic Validation)
        #endregion

    }
}
