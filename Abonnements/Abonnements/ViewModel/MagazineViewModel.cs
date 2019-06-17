using Abonnements.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.ViewModel
{
    public class MagazineViewModel : ViewModelBase
    {
        #region Private Properties
        private Magazine _magazine;
        #endregion

        #region Public Properties
        public Magazine Magazine
        {
            get
            {
                return _magazine;
            }
            set
            {
                _magazine = value;
                RaisePropertyChanged(() => Magazine);
            }
        }
        #endregion

        #region Ctor
        public MagazineViewModel()
        {
            _magazine = new Magazine{ Titre = "Le monde", Description = "Courte description d'un magazine pas super connu", NbVolumeAnnee = 12, PrixAnnuel = 36.00m};
        }
        #endregion
    }
}
