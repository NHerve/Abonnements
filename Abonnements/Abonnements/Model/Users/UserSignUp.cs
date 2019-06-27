using Abonnements.Validations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserSignUp
    {
        public UserSignUp()
        {
                
        }

        public UserSignUp(string mail, string password, string firstName, string lastName, string phone)
        {
            Mail = mail;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
        
        [JsonProperty("cliId")]
        public int Id { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("cliMail")]
        public string Mail { get; set; }

        [JsonProperty("cliPassword")]
        public string Password { get; set; }

        [JsonProperty("cliPrenom")]
        public string FirstName { get; set; }

        [JsonProperty("cliNom")]
        public string LastName { get; set; }

        [JsonProperty("cliPhone")]
        public string Phone { get; set; }

        [JsonProperty("cliAuthKey")]
        public string AuthKey { get; set; }
    }
}
