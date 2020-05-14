namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "Category_Id", "dbo.MovieCategory");
            DropIndex("dbo.Movie", new[] { "Category_Id" });
            AddColumn("dbo.Movie", "Category", c => c.String());
            DropColumn("dbo.Movie", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Category_Id", c => c.Int());
            DropColumn("dbo.Movie", "Category");
            CreateIndex("dbo.Movie", "Category_Id");
            AddForeignKey("dbo.Movie", "Category_Id", "dbo.MovieCategory", "Id");
        }
    }
}
