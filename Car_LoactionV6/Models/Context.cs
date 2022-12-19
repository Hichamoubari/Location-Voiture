using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Car_LoactionV6.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=Test_Context") { }
        public DbSet<Users> users { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Modele> modeles { get; set; }

        public System.Data.Entity.DbSet<Car_LoactionV6.Models.Cars> Cars { get; set; }

        public System.Data.Entity.DbSet<Car_LoactionV6.Models.Rental> Rentals { get; set; }
    }
}