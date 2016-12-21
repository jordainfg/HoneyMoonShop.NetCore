﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class Kleur
    {
        public int KleurId { get; set; }
        public String Artikelnummer { get; set; }
        public String Hexacode { get; set; }
        public String KleurNaam { get; set; }

        public List<JurkKleur> JurkKleuren { get; set; }
        public List<PakKleur> PakKleuren { get; set; }
    }
}