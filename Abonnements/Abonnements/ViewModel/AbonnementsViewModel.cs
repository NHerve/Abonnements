using Abonnements.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
            _abonnements = new ObservableCollection<Abonnement>();
            _abonnements.Add(new Abonnement { Nom = "Le monde", DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(2) });
            _abonnements.Add(new Abonnement { Nom = "Le Gorafi", DateExpiration = new DateTime(DateTime.Now.Ticks).AddYears(2) });
            _abonnements.Add(new Abonnement { Nom = "Le Parisien", DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(8) });
            _abonnements.Add(new Abonnement { Nom = "La Provence", DateExpiration = new DateTime(DateTime.Now.Ticks).AddDays(7) });
            _abonnements.Add(new Abonnement { Nom = "Le canard enchaîné", DateExpiration = new DateTime(DateTime.Now.Ticks).AddMonths(1) });
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
