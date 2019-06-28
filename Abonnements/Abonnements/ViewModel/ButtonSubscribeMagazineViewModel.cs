using Abonnements.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class ButtonSubscribeMagazineViewModel : ViewModelBase
    {
        #region PrivateProperties
        private Paiement _paiement;
        #endregion

        #region PublicProperties
        public Paiement Paiement
        {
            get
            {
                return _paiement;
            }
            set
            {
                _paiement = value;
                RaisePropertyChanged(() => Paiement);
            }
        }
        #endregion
        #region Ctor
        public ButtonSubscribeMagazineViewModel()
        {

        }
        #endregion
        #region Command
        public ICommand SubscribeCommand => new Command(Subscribe);


        private async void Subscribe()
        {
            await NavigationService.NavigateToAsync<PayementViewModel>(Paiement);
        }
        #endregion

        #region Initialize

        #endregion
    }
}
