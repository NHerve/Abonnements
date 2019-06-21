using Abonnements.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserProfile
    {
        #region PrivateProperties
        private string _firstName;
        private string _lastName;
        private ValidatableObject<string> _mail = new ValidatableObject<string>();
        private ValidatableObject<string> _phone = new ValidatableObject<string>();
        private DateTime _birthDay;
        private ValidatableObject<string> _birthLocation = new ValidatableObject<string>();
        private ValidatableObject<string> _ccv = new ValidatableObject<string>();
        private ValidatableObject<string> _cardNumber = new ValidatableObject<string>();
        private ValidatableObject<string> _expirationDate = new ValidatableObject<string>();
        private ValidatableObject<string> _password = new ValidatableObject<string>();
        private ValidatableObject<string> _passwordConfirmation= new ValidatableObject<string>();

        #endregion

        #region PublicProperties
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public ValidatableObject<string> Mail { get => _mail; set => _mail = value; }
        public ValidatableObject<string> Phone { get => _phone; set => _phone = value; }
        public DateTime BirthDay { get => _birthDay; set => _birthDay = value; }
        public ValidatableObject<string> BirthLocation { get => _birthLocation; set => _birthLocation = value; }
        public ValidatableObject<string> Ccv { get => _ccv; set => _ccv = value; }
        public ValidatableObject<string> CardNumber { get => _cardNumber; set => _cardNumber = value; }
        public ValidatableObject<string> ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
        public ValidatableObject<string> Password { get => _password; set => _password = value; }
        public ValidatableObject<string> PasswordConfirmation { get => _passwordConfirmation; set => _passwordConfirmation = value; }
        #endregion

        #region Ctor
        public UserProfile()
        {

        }
        public UserProfile(string firstName, string lastName, string mail, string phone, DateTime birthDay, string birthLocation, string ccv, string cardNumber, string expirationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Mail.Value = mail;
            Phone.Value = phone;
            BirthDay = birthDay;
            BirthLocation.Value = birthLocation;
            Ccv.Value = ccv;
            CardNumber.Value = cardNumber;
            ExpirationDate.Value = expirationDate;
        }
        //Add validation
        #endregion
    }
}
