namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Disk", "cost", c => c.Int(nullable: false));
            AddColumn("dbo.Disk", "format", c => c.String());
            AddColumn("dbo.Disk", "copy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Disk", "copy");
            DropColumn("dbo.Disk", "format");
            DropColumn("dbo.Disk", "cost");
        }
    }
}
