using Abonnements.DataServices;
using Abonnements.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.ViewModel
{
    public class MagazineViewModel : ViewModelBase
    {
        #region Private Properties
        private ButtonSubscribedMagazineViewModel _subscribed;
        private ButtonSubscribeMagazineViewModel _subscribe;
        private readonly MagazineDataService _magazineDataService;
        private string _titre;
        private string _description;
        private string _numeroAnnee;
        private decimal _prixAnnuel;
        private bool _isAbonnement;
        private bool _isNonAbonnement;

        #endregion

        #region Public Properties

        public ButtonSubscribedMagazineViewModel Subscribed { get { return _subscribed; } set { _subscribed = value; RaisePropertyChanged(() => Subscribed); } }
        public ButtonSubscribeMagazineViewModel Subscribe { get { return _subscribe; } set { _subscribe = value; RaisePropertyChanged(() => Subscribe); } }
        
        public string Titre
        {
            get { return _titre; }
            set { _titre = value; RaisePropertyChanged(() => Titre); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(() => Description); }
        }
        public string NumeroAnnee
        {
            get { return _numeroAnnee; }
            set { _numeroAnnee = value; RaisePropertyChanged(() => NumeroAnnee); }
        }
        public decimal PrixAnnuel
        {
            get { return _prixAnnuel; }
            set { _prixAnnuel = value; RaisePropertyChanged(() => PrixAnnuel); }
        }
        public bool IsAbonnement
        {
            get { return _isAbonnement; }
            set { _isAbonnement = value; RaisePropertyChanged(() => IsAbonnement); }
        }
        public bool IsNonAbonnement
        {
            get { return _isNonAbonnement; }
            set { _isNonAbonnement = value; RaisePropertyChanged(() => IsNonAbonnement); }
        }
        #endregion

        #region Ctor
        public MagazineViewModel(MagazineDataService magazineDateService, ButtonSubscribedMagazineViewModel subscribed, ButtonSubscribeMagazineViewModel subscribe)
        {
            _magazineDataService = magazineDateService;
            _subscribe = subscribe;
            _subscribed = subscribed;
        }
        #endregion

        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            Magazine mag;
            if (navigationData is Magazine)
            {
                mag = (Magazine)navigationData;
                IsAbonnement = false;
                IsNonAbonnement = true;
            }
            else
            {
                int magId = (int)navigationData;
                mag = _magazineDataService.GetMagazine(magId);
                IsAbonnement = true;
                IsNonAbonnement = false;
            }
            Titre = mag.Titre;
            Description = mag.Description;
            NumeroAnnee = mag.NumeroAnnee.ToString();
            PrixAnnuel = mag.PrixAnnuel;
            _subscribe.Paiement = new Paiement { Titre = _titre, amount = _prixAnnuel, IdMagazine = mag.Id };

            return Task.FromResult(false);
        }
        #endregion
    }
}
