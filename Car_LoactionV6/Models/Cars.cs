using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_LoactionV6.Models
{
    public class Cars
    {

        [Key]
        public int IdCar { get; set; }

        [Required]
        [MaxLength(100)]
        public string Matriculation { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Date de Circulation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCirculation { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeCarburant { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Prix { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Image of car")]
        public HttpPostedFileBase ImageFile { get; set; }

        [ForeignKey("Category")]
        public int Idcategory { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Modele")]
        public int IdModel { get; set; }
        public Modele Modele { get; set; }


    }
}