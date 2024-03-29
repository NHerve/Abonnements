﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Model
{
    public class Magazine
    {
        public Magazine()
        {

        }

        [JsonProperty("magId")]
        public int Id { get; set; }
        [JsonProperty("magTitre")]
        public string Titre { get; set; }

        [JsonProperty("magDescription")]
        public string Description { get; set; }

        [JsonProperty("magPrixAnnuel")]
        public decimal PrixAnnuel { get; set; }

        [JsonProperty("magNbVolumeAnnee")]
        public int NumeroAnnee { get; set; }

        [JsonProperty("magPhoto")]
        public string PhotoCouverture { get; set; }
    }
}
