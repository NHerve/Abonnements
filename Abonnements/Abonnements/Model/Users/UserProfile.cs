using Abonnements.Validations;
using Newtonsoft.Json;
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
        [JsonProperty("cliAuth")]
        public string Auth_key { get; set; }
        [JsonProperty("cliId")]
        public int Id { get; set; }
        [JsonProperty("cliNom")]
        public string FirstName { get => _firstName; set => _firstName = value; }
        [JsonProperty("cliPrenom")]
        public string LastName { get => _lastName; set => _lastName = value; }
        [JsonProperty("cliMail")]
        public ValidatableObject<string> Mail { get => _mail; set => _mail = value; }
        [JsonProperty("cliPhone")]
        public ValidatableObject<string> Phone { get => _phone; set => _phone = value; }
        [JsonProperty("cliDateNaissance")]
        public DateTime BirthDay { get => _birthDay; set => _birthDay = value; }
        [JsonProperty("cliLieuNaissance")]
        public ValidatableObject<string> BirthLocation { get => _birthLocation; set => _birthLocation = value; }
        [JsonProperty("cliCCV")]
        public ValidatableObject<string> Ccv { get => _ccv; set => _ccv = value; }
        [JsonProperty("cliNumCart")]
        public ValidatableObject<string> CardNumber { get => _cardNumber; set => _cardNumber = value; }
        [JsonProperty("cliExpiCarte")]
        public ValidatableObject<string> ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
        [JsonProperty("cliPassword")]
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

        public UserProfile(UserSignUp userSignUp)
        {
            Id = userSignUp.Id;
            FirstName = userSignUp.FirstName;
            LastName = userSignUp.LastName;
            Phone = new ValidatableObject<string>() { Value = userSignUp.Phone };
            Mail = new ValidatableObject<string>() { Value = userSignUp.Mail };
        }
        //Add validation
        #endregion
    }
}
