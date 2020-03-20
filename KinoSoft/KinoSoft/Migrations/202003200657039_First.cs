namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Person", "Password", c => c.String());
            AddColumn("dbo.Person", "RoleId", c => c.Int());
            CreateIndex("dbo.Person", "RoleId");
            AddForeignKey("dbo.Person", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "RoleId", "dbo.Role");
            DropIndex("dbo.Person", new[] { "RoleId" });
            DropColumn("dbo.Person", "RoleId");
            DropColumn("dbo.Person", "Password");
            DropTable("dbo.Role");
        }
    }
}
