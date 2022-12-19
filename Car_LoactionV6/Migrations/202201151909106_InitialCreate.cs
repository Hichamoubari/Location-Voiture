namespace Car_LoactionV6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        IdCar = c.Int(nullable: false, identity: true),
                        Matriculation = c.String(nullable: false, maxLength: 100),
                        DateCirculation = c.DateTime(nullable: false, storeType: "date"),
                        TypeCarburant = c.String(nullable: false, maxLength: 100),
                        Prix = c.Double(nullable: false),
                        Image = c.String(maxLength: 100),
                        Idcategory = c.Int(nullable: false),
                        IdModel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCar)
                .ForeignKey("dbo.Categories", t => t.Idcategory, cascadeDelete: true)
                .ForeignKey("dbo.Modeles", t => t.IdModel, cascadeDelete: true)
                .Index(t => t.Idcategory)
                .Index(t => t.IdModel);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Idcategory = c.Int(nullable: false, identity: true),
                        NomCategory = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Idcategory);
            
            CreateTable(
                "dbo.Modeles",
                c => new
                    {
                        IdModel = c.Int(nullable: false, identity: true),
                        NomMarque = c.String(nullable: false, maxLength: 100),
                        NomSerie = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdModel);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        IdRental = c.Int(nullable: false, identity: true),
                        TypeLocation = c.String(nullable: false, maxLength: 100),
                        DateDebut = c.DateTime(nullable: false, storeType: "date"),
                        DateFin = c.DateTime(nullable: false, storeType: "date"),
                        UID = c.Int(nullable: false),
                        IdCar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRental)
                .ForeignKey("dbo.Cars", t => t.IdCar, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UID, cascadeDelete: true)
                .Index(t => t.UID)
                .Index(t => t.IdCar);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100),
                        AdresseMail = c.String(nullable: false, maxLength: 100),
                        TypeUser = c.String(nullable: false, maxLength: 100),
                        MotDePasse = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false, maxLength: 20),
                        DateNaissance = c.DateTime(nullable: false, storeType: "date"),
                        Cin = c.String(maxLength: 100),
                        PermisConduire = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.UID)
                .Index(t => t.AdresseMail, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "UID", "dbo.Users");
            DropForeignKey("dbo.Rentals", "IdCar", "dbo.Cars");
            DropForeignKey("dbo.Cars", "IdModel", "dbo.Modeles");
            DropForeignKey("dbo.Cars", "Idcategory", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "AdresseMail" });
            DropIndex("dbo.Rentals", new[] { "IdCar" });
            DropIndex("dbo.Rentals", new[] { "UID" });
            DropIndex("dbo.Cars", new[] { "IdModel" });
            DropIndex("dbo.Cars", new[] { "Idcategory" });
            DropTable("dbo.Users");
            DropTable("dbo.Rentals");
            DropTable("dbo.Modeles");
            DropTable("dbo.Categories");
            DropTable("dbo.Cars");
        }
    }
}
