using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Abonnements.DataServices;
using Abonnements.Model;
using Abonnements.Services;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    class NonAbonnementsViewModel : ViewModelBase
    {
        #region Private Properties
        private ObservableCollection<Magazine> _magazines;
        private ObservableCollection<Abonnement> _abonnements;
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
                MagazineDataService magazineDataService = new MagazineDataService(Serializer, ErrorLogger, DialogService);

                _abonnements = new ObservableCollection<Abonnement>(abonnementDataService.GetNonAbonnements(1));//Settings.UserId
                foreach (var abo in _abonnements)
                {
                    abo.Magazine = magazineDataService.GetMagazine(abo.IdMagazine) ?? new Magazine();
                }

            }
            catch (Exception ex)
            {
                //_magazines = new ObservableCollection<Abonnement>();
                //_magazines.Add(new Abonnement { Magazine = new Magazine { Titre = "le monde" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(2) });
                //_magazines.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Gorafi" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddYears(2) });
                //_magazines.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Parisien" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(8) });
                //_magazines.Add(new Abonnement { Magazine = new Magazine { Titre = "La Provence" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddDays(7) });
                //_magazines.Add(new Abonnement { Magazine = new Magazine { Titre = "Le canard enchaîné" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(1) });
            }

        }
        #endregion

        #region Command
        public ICommand GoToMagazine => new Command<Abonnement>(GoToMagazineAsync);
        #endregion
        #region Private Function
        private async void GoToMagazineAsync(Abonnement abonnement)
        {
            await NavigationService.NavigateToAsync<MagazineViewModel>(abonnement.IdMagazine);
        }
        #endregion
    }
}
