namespace KinoSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "PhoneNumber1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "PhoneNumber1");
        }
    }
}
