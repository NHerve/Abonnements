using Abonnements.Validations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserProfile
    {
        #region PublicProperties
        [JsonProperty("cliAuthKey")]
        public string Auth_key { get; set; }
        [JsonProperty("cliId")]
        public int Id { get; set; }
        [JsonProperty("cliNom")]
        public string FirstName { get; set; }
        [JsonProperty("cliPrenom")]
        public string LastName { get; set; }
        [JsonProperty("cliMail")]
        public string Mail { get; set; }
        [JsonProperty("cliPhone")]
        public string Phone { get; set ; }
        [JsonProperty("cliDateNaissance")]
        public DateTime? BirthDay { get; set; }
        [JsonProperty("cliLieuNaissance")]
        public string BirthLocation { get; set; }
        [JsonProperty("cliCCV")]
        public string Ccv { get; set; }
        [JsonProperty("cliNumCart")]
        public string CardNumber { get; set; }
        [JsonProperty("cliExpiCarte")]
        public string ExpirationDate { get;  set; }
        [JsonProperty("cliPassword")]
        public string Password { get; set; }
        
        public string PasswordConfirmation { get; set; }
        #endregion

        #region Ctor
        public UserProfile()
        {

        }
        public UserProfile(string firstName, string lastName, string mail, string phone, DateTime birthDay, string birthLocation, string ccv, string cardNumber, string expirationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Phone= phone;
            BirthDay = birthDay;
            BirthLocation = birthLocation;
            Ccv= ccv;
            CardNumber= cardNumber;
            ExpirationDate= expirationDate;
        }

        public UserProfile(UserSignUp userSignUp)
        {
            Id = userSignUp.Id;
            FirstName = userSignUp.FirstName;
            LastName = userSignUp.LastName;
            Phone =userSignUp.Phone;
            Mail = userSignUp.Mail;
        }
        //Add validation
        #endregion
    }
}
