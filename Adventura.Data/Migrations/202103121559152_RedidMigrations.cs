namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RedidMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ActivityType = c.Int(nullable: false),
                        ActivityDescription = c.String(nullable: false, maxLength: 100),
                        ActivtyLength = c.Int(nullable: false),
                        ActivityCost = c.Double(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        AdventureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Adventure", t => t.AdventureId, cascadeDelete: true)
                .Index(t => t.AdventureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Location", "AdventureId", "dbo.Adventure");
            DropIndex("dbo.Location", new[] { "AdventureId" });
            DropIndex("dbo.Activity", new[] { "LocationId" });
            DropTable("dbo.Location");
            DropTable("dbo.Activity");
        }
    }
}
