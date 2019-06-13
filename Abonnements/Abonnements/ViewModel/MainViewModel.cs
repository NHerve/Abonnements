using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region Public Properties
        public AbonnementsViewModel AbonnementViewModel { get; set; }
        public AccountViewModel AccountViewModel { get; set; }
        #endregion

        #region Ctor
        public MainViewModel()
        {
            AbonnementViewModel = new AbonnementsViewModel();
            AccountViewModel = new AccountViewModel();
        }
        #endregion
    }
}
