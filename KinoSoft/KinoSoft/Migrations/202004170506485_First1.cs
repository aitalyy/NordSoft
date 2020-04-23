namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "DateId", "dbo.MovieDate");
            DropForeignKey("dbo.Movie", "DescriptionId", "dbo.MovieDescription");
            DropIndex("dbo.Movie", new[] { "DescriptionId" });
            DropIndex("dbo.Movie", new[] { "DateId" });
            AddColumn("dbo.Movie", "Description", c => c.String());
            AddColumn("dbo.Movie", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movie", "DescriptionId");
            DropColumn("dbo.Movie", "DateId");
            DropTable("dbo.MovieDate");
            DropTable("dbo.MovieDescription");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieDescription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieDate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "DateId", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "DescriptionId", c => c.Int(nullable: false));
            DropColumn("dbo.Movie", "Date");
            DropColumn("dbo.Movie", "Description");
            CreateIndex("dbo.Movie", "DateId");
            CreateIndex("dbo.Movie", "DescriptionId");
            AddForeignKey("dbo.Movie", "DescriptionId", "dbo.MovieDescription", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movie", "DateId", "dbo.MovieDate", "Id", cascadeDelete: true);
        }
    }
}
