using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model.Users
{
    public class AuthenticationRequest
    {
        public string UserMail { get; set; }

        public string Credentials { get; set; }

        public string GrantType { get; set; }
    }
}
