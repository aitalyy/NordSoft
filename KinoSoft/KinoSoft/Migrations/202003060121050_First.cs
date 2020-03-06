﻿namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SecondName = c.String(),
                        PassportId = c.Int(),
                        PhoneNumber = c.String(),
                        InBalckList = c.Boolean(),
                        Login = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passport", t => t.PassportId)
                .Index(t => t.PassportId);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCountry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieDisk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        DiskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disk", t => t.DiskId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.DiskId);
            
            CreateTable(
                "dbo.Disk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiskOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiskId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.DiskId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Disk", t => t.DiskId, cascadeDelete: true)
                .Index(t => t.DiskId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Passport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        number = c.Int(nullable: false),
                        series = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieProducer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ProducerId);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "EmployeeId", "dbo.Person");
            DropForeignKey("dbo.Person", "PassportId", "dbo.Passport");
            DropForeignKey("dbo.MovieProducer", "ProducerId", "dbo.Person");
            DropForeignKey("dbo.MovieProducer", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.MovieDisk", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.DiskOrder", "DiskId", "dbo.Disk");
            DropForeignKey("dbo.DiskOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "ClientId", "dbo.Person");
            DropForeignKey("dbo.DiskOrder", "DiskId", "dbo.Movie");
            DropForeignKey("dbo.MovieDisk", "DiskId", "dbo.Disk");
            DropForeignKey("dbo.MovieCountry", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCountry", "CountryId", "dbo.Country");
            DropForeignKey("dbo.MovieActor", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "ActorId", "dbo.Person");
            DropIndex("dbo.Report", new[] { "EmployeeId" });
            DropIndex("dbo.MovieProducer", new[] { "ProducerId" });
            DropIndex("dbo.MovieProducer", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.Order", new[] { "ClientId" });
            DropIndex("dbo.DiskOrder", new[] { "OrderId" });
            DropIndex("dbo.DiskOrder", new[] { "DiskId" });
            DropIndex("dbo.MovieDisk", new[] { "DiskId" });
            DropIndex("dbo.MovieDisk", new[] { "MovieId" });
            DropIndex("dbo.MovieCountry", new[] { "CountryId" });
            DropIndex("dbo.MovieCountry", new[] { "MovieId" });
            DropIndex("dbo.MovieActor", new[] { "ActorId" });
            DropIndex("dbo.MovieActor", new[] { "MovieId" });
            DropIndex("dbo.Person", new[] { "PassportId" });
            DropTable("dbo.Report");
            DropTable("dbo.MovieProducer");
            DropTable("dbo.Genre");
            DropTable("dbo.MovieGenre");
            DropTable("dbo.Passport");
            DropTable("dbo.Order");
            DropTable("dbo.DiskOrder");
            DropTable("dbo.Disk");
            DropTable("dbo.MovieDisk");
            DropTable("dbo.Country");
            DropTable("dbo.MovieCountry");
            DropTable("dbo.Movie");
            DropTable("dbo.MovieActor");
            DropTable("dbo.Person");
        }
    }
}
