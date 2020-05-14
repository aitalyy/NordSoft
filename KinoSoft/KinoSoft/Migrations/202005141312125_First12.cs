namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "CategoryId", "dbo.MovieCategory");
            DropIndex("dbo.Movie", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Movie", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Movie", "Category_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Category_Id");
            AddForeignKey("dbo.Movie", "Category_Id", "dbo.MovieCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Category_Id", "dbo.MovieCategory");
            DropIndex("dbo.Movie", new[] { "Category_Id" });
            AlterColumn("dbo.Movie", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Movie", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Movie", "CategoryId");
            AddForeignKey("dbo.Movie", "CategoryId", "dbo.MovieCategory", "Id", cascadeDelete: true);
        }
    }
}
