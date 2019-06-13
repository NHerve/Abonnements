using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Abonnements.Model
{
    public class Abonnement
    {

        public int IdMagazine { get; set; }

        public string Nom { get; set; }

        public DateTime DateExpiration { get; set; }

        public Color StatusColor => DateTime.Now.Month - DateExpiration.Month <= 2 ? Color.FromHex("ef5350") : Color.Default;

    }
}
