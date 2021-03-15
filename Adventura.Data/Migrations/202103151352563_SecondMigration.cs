namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "ActivityLength", c => c.Int(nullable: false));
            AddColumn("dbo.Location", "EditUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Activity", "ActivtyLength");
            DropColumn("dbo.Activity", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activity", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Activity", "ActivtyLength", c => c.Int(nullable: false));
            DropColumn("dbo.Location", "EditUtc");
            DropColumn("dbo.Activity", "ActivityLength");
        }
    }
}
