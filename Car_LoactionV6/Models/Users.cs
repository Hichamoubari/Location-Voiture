using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_LoactionV6.Models
{
    public class Users
    {
        [Key]
        public int UID { get; set; }

        [Required]
        [MinLength(4), MaxLength(100)]
        [DisplayName("Nom Complet")]
        public string Nom { get; set; }


        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [EmailAddress]
        [DisplayName("Email")]
        public string AdresseMail { get; set; }



        [Required]
        [MaxLength(100)]
        public string TypeUser { get; set; }


        [Required]
        [MaxLength(100)]
        [DisplayName("Mot de passe")]
        public string MotDePasse { get; set; }

        


        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }




        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Date de Naissance")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateNaissance { get; set; }



        [MaxLength(100)]
        public string Cin { get; set; }

        [NotMapped]
        [DisplayName("CIN")]
        public HttpPostedFileBase CinFile { get; set; }


        [MaxLength(100)]
        public string PermisConduire { get; set; }



        [NotMapped]
        [DisplayName("Permis de Conduire")]
        public HttpPostedFileBase PermisConduireFile { get; set; }
    }
}