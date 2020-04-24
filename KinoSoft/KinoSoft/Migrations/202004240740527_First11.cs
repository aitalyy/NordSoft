namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Cost");
        }
    }
}
