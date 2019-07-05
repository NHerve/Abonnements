using Abonnements.DataServices;
using Abonnements.Model;
using Abonnements.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Abonnements.ViewModel
{
    public class PayementViewModel : ViewModelBase
    {
        #region Private Properties
        private readonly PaiementDataService _paiementDataService;
        private string _titre;
        private ValidatableObject<string> _cardNumber;
        private ValidatableObject<string> _cardMonth;
        private ValidatableObject<string> _cardYear;
        private decimal _amount;
        #endregion
        #region Public Properties
        public int IdMagazine { get; set; }
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
        public ValidatableObject<string> CardNumber
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
        public ValidatableObject<string> CardMonth
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
        public ValidatableObject<string> CardYear
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
        public PayementViewModel(PaiementDataService paiementDataService)
        {
            _paiementDataService = paiementDataService;
            CardNumber = new ValidatableObject<string>();
            CardMonth = new ValidatableObject<string>();
            CardYear = new ValidatableObject<string>();
            AddValidations();
        }
        #endregion

        #region Command
        public ICommand PayementCommand => new Command(Payement);
        #endregion

        #region Private Function
        private bool Validate()
        {
            bool isValidCardMonth = _cardMonth.Validate();
            bool isValidCardYear = _cardYear.Validate();
            return isValidCardMonth && isValidCardYear;
        }


        private void Payement()
        {
            IsBusy = true;
            bool isValid = Validate();
            if (isValid)
            {
                if (_paiementDataService.RequestPaiement(new Paiement(CardNumber.Value, CardMonth.Value, CardYear.Value, Amount), IdMagazine))
                {
                    DialogService.ShowAlertAsync("Paiement effectué, en attente de validation par le service", "", "Ok");
                }
            }

        }

        private void AddValidations()
        {
            _cardMonth.Validations.Add(new CardMonthRule<string>() { ValidationMessage = "Le mois doit être supérieur à 00 et inférieur à 12" });
            _cardYear.Validations.Add(new CardYearRule<string>() { ValidationMessage = "L'année doit être supérieur à celle d'aujourd'hui et l'écart inférieur à 5 ans" });

        }

        #endregion
        #region Initialize
        public override Task InitializeAsync(object navigationData)
        {
            Paiement paiement = (Paiement)navigationData;
            Titre = paiement.Titre;
            Amount = paiement.amount;
            IdMagazine = paiement.IdMagazine;
            return Task.FromResult(false);
        }
        #endregion
    }
}
