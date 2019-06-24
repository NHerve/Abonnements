using Abonnements.Helpers;
using Abonnements.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Abonnements.DataServices;

namespace Abonnements.ViewModel
{
    public class AbonnementsViewModel : ViewModelBase
    {
        #region Private Properties
        private ObservableCollection<Abonnement> _abonnements;
        #endregion

        #region Public Properties
        public ObservableCollection<Abonnement> Abonnements
        {
            get
            {
                return _abonnements;
            }
            set
            {
                _abonnements = value;
                RaisePropertyChanged(() => Abonnements);
            }
        }
        #endregion

        #region Ctor
        public AbonnementsViewModel()
        {
            try
            {
                AbonnementDataService abonnementDataService = new AbonnementDataService(Serializer, ErrorLogger, DialogService);
                MagazineDataService magazineDataService = new MagazineDataService(Serializer, ErrorLogger, DialogService);
                _abonnements = new ObservableCollection<Abonnement>(abonnementDataService.GetAbonnements(1));//Settings.UserId
                foreach (var abo in _abonnements)
                {
                    abo.Magazine = magazineDataService.GetMagazine(abo.IdMagazine) ?? new Magazine();
                }

            }
            catch (Exception ex)
            {
                _abonnements = new ObservableCollection<Abonnement>();
                _abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "le monde" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(2) });
                _abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Gorafi" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddYears(2) });
                _abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le Parisien" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(8) });
                _abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "La Provence" }, DateExpiration = new DateTime(DateTime.Now.Ticks).AddDays(7) });
                _abonnements.Add(new Abonnement { Magazine = new Magazine { Titre = "Le canard enchaîné" } , DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(1) });
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
