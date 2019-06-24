using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserConnection
    {
        public UserConnection(string mail, string password)
        {
            Mail = mail;
            Password = password;
        }
        [JsonProperty("cliMail")]
        public string Mail { get; set; }
        [JsonProperty("cliPassword")]
        public string Password { get; set; }
    }
}
