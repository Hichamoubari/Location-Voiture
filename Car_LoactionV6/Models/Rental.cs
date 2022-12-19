using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_LoactionV6.Models
{
    public class Rental
    {
        [Key]
        public int IdRental { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeLocation { get; set; }

        [Required]
        [MaxLength(100)]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Date de Debut")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDebut { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Date de Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateFin { get; set; }

        [ForeignKey("Users")]
        public int UID { get; set; }
        public Users Users { get; set; }

        [ForeignKey("Cars")]
        public int IdCar { get; set; }
        public Cars Cars { get; set; }

        
    }
}