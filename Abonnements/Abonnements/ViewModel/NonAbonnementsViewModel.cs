using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Abonnements.DataServices;
using Abonnements.Helpers;
using Abonnements.Model;
using Abonnements.Services;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class NonAbonnementsViewModel : ViewModelBase
    {
        #region Private Properties
        private ObservableCollection<Magazine> _magazines;
        #endregion

        #region Public Properties
        public ObservableCollection<Magazine> Magazines
        {
            get
            {
                return _magazines;
            }
            set
            {
                _magazines = value;
                RaisePropertyChanged(() => Magazines);
            }
        }
        #endregion

        #region Ctor
        public NonAbonnementsViewModel()
        {
            try
            {
                AbonnementDataService abonnementDataService = new AbonnementDataService(Serializer, ErrorLogger, DialogService);

                _magazines = new ObservableCollection<Magazine>(abonnementDataService.GetNonAbonnements(Settings.CurrentUser.Id));//Settings.UserId

            }
            catch (Exception ex)
            {
                //_abonnements = new ObservableCollection<Abonnement>();
                //_abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "le monde" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(2) });
                //_abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Gorafi" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddYears(2) });
                //_abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Parisien" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(8) });
                //_abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "La Provence" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddDays(7) });
                //_abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le canard enchaîné" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(1) });
            }

        }
        #endregion

        #region Command
        public ICommand GoToMagazine => new Command<Magazine>(GoToMagazineAsync);
        #endregion
        #region Private Function
        private async void GoToMagazineAsync(Magazine magazine)
        {
            await NavigationService.NavigateToAsync<MagazineViewModel>(magazine);
        }
        #endregion
    }
}
