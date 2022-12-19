using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_LoactionV6.Models
{
    public class Modele
    {
        [Key]
        public int IdModel { get; set; }


        [Required]
        [MaxLength(100)]
        public string NomMarque { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomSerie { get; set; }
    }
}