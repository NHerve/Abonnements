using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonnements.Model
{
    public class Error
    {
        public Error(string description)
        {
            Description = description;
            Date = DateTime.Now;
        }

        [JsonProperty("logDescription")]
        public string Description { get; set; }

        [JsonProperty("logDate")]
        public DateTime Date { get; set; }
    }
}
