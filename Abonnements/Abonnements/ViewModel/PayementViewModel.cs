using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.ViewModel
{
    public class PayementViewModel : ViewModelBase
    {
        #region Private Properties
        private string _titre;
        private int _cardNumber;
        private int _cardMonth;
        private int _cardYear;
        private decimal _amount;
        #endregion
        #region Public Properties
        public string Titre
        {
            get
            {
                return _titre;
            }
            set
            {
                _titre = value;
                RaisePropertyChanged(() => Titre);
            }
        }
        public int CardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                _cardNumber= value;
                RaisePropertyChanged(() => CardNumber);
            }
        }
        public int CardMonth
        {
            get
            {
                return _cardMonth;
            }
            set
            {
                _cardMonth= value;
                RaisePropertyChanged(() => CardMonth);
            }
        }
        public int CardYear
        {
            get
            {
                return _cardYear;
            }
            set
            {
                _cardYear= value;
                RaisePropertyChanged(() => CardYear);
            }
        }
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                RaisePropertyChanged(() => Amount);
            }
        }
        #endregion

        #region ctor
        public PayementViewModel()
        {

        }
        #endregion

        #region Command

        #endregion
    }
}
