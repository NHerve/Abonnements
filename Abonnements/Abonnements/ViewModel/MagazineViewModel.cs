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
        private readonly MagazineDataService _magazineDataService;
        private string _titre;
        private string _description;
        private string _numeroAnnee;
        private string _prixAnnuel;

        #endregion

        #region Public Properties
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
        public string PrixAnnuel
        {
            get { return _prixAnnuel; }
            set { _prixAnnuel = value; RaisePropertyChanged(() => PrixAnnuel); }
        }
        #endregion

        #region Ctor
        public MagazineViewModel(MagazineDataService magazineDateService)
        {
            _magazineDataService = magazineDateService;
        }
        #endregion

        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            Magazine mag;
            if (navigationData is Magazine)
            {
                mag = (Magazine)navigationData;
            }
            else
            {
                int magId = (int)navigationData;
                mag = _magazineDataService.GetMagazine(magId);
            }
            Titre = mag.Titre;
            Description = mag.Description;
            NumeroAnnee = mag.NumeroAnnee.ToString();
            PrixAnnuel = mag.PrixAnnuel.ToString();
            return Task.FromResult(false);
        }
        #endregion
    }
}
