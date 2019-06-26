using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.Model.Employe
{
    public class Employe
    {
        public Employe()
        {
                
        }
        public Employe(string login, string password)
        {
            Login = login;
            Password = password;
        }

        [JsonProperty("empId")]
        public int Id { get; set; }

        [JsonProperty("empAuthKey")]
        public string AuthKey { get; set; }

        [JsonProperty("empLogin")]
        public string Login { get; set; }

        [JsonProperty("empPassword")]
        public string Password { get; set; }
    }
}
