﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models
{
    public class Jurk
    {
        public String Stijl { get; set; }
        public String Neklijn { get; set; }
        public String Silhouette { get; set; }
        public String Materiaal { get; set; }

        [Key]
        public int ArtikelnummerId { get; set; }  
        [ForeignKey("Artikelnummer")]
        public virtual Kleding Kleding { get; set; }
    }
}
