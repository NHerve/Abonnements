using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class UserConnection
    {
        [JsonProperty("cliMail")]
        public string Mail { get; set; }
        [JsonProperty("cliPassword")]
        public string Password { get; set; }
    }
}
