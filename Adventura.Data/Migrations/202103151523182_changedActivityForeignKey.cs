namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedActivityForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "LocationId", "dbo.Location");
            DropIndex("dbo.Activity", new[] { "LocationId" });
            AddColumn("dbo.Activity", "AdventureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activity", "AdventureId");
            AddForeignKey("dbo.Activity", "AdventureId", "dbo.Adventure", "AdventureId", cascadeDelete: true);
            DropColumn("dbo.Activity", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activity", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Activity", "AdventureId", "dbo.Adventure");
            DropIndex("dbo.Activity", new[] { "AdventureId" });
            DropColumn("dbo.Activity", "AdventureId");
            CreateIndex("dbo.Activity", "LocationId");
            AddForeignKey("dbo.Activity", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
        }
    }
}
