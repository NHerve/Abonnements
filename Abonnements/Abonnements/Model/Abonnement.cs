using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Abonnements.Model
{
    public class Abonnement
    {
        [JsonProperty("aboFKMag")]
        public int IdMagazine { get; set; }

        public Magazine Magazine { get; set; }

        [JsonProperty("aboDateFin")]
        public DateTime DateExpiration { get; set; }

        public Color StatusColor { get {
                if(DateTime.Now.Year == DateExpiration.Year)
                {
                    return DateTime.Now.Month - DateExpiration.Month <= 2 ? Color.FromHex("ef5350") : Color.Default;
                }
                else if(DateTime.Now.Year == DateExpiration.Year && DateTime.Now.Month > DateExpiration.Month)
                {
                    return Color.FromHex("696969");
                }else if(DateTime.Now.Year > DateExpiration.Year)
                {
                    return Color.FromHex("ef5350");
                }
                else
                {
                    return Color.FromHex("6B8E23");
                }
            } } 

    }
}
