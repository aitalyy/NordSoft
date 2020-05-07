namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Disk", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Disk", "Name", c => c.String(maxLength: 1000));
        }
    }
}
