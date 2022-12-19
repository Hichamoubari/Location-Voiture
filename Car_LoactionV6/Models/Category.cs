using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car_LoactionV6.Models
{
    public class Category
    {
        [Key]
        public int Idcategory { get; set; }


        [Required]
        [MaxLength(100)]
        public string NomCategory { get; set; }



    }
}