namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationEdits : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Location", "EditUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "EditUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
