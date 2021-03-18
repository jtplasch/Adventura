namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeychange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.Location", "Adventure_AdventureId", "dbo.Adventure");
            DropIndex("dbo.Activity", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.Location", new[] { "Adventure_AdventureId" });
            RenameColumn(table: "dbo.Activity", name: "Adventure_AdventureId", newName: "AdventureId");
            RenameColumn(table: "dbo.Location", name: "Adventure_AdventureId", newName: "AdventureId");
            AlterColumn("dbo.Activity", "AdventureId", c => c.Int(nullable: false));
            AlterColumn("dbo.Location", "AdventureId", c => c.Int(nullable: true));
            CreateIndex("dbo.Activity", "AdventureId");
            CreateIndex("dbo.Location", "AdventureId");
            AddForeignKey("dbo.Activity", "AdventureId", "dbo.Adventure", "AdventureId", cascadeDelete: true);
            AddForeignKey("dbo.Location", "AdventureId", "dbo.Adventure", "AdventureId", cascadeDelete: true);
            DropColumn("dbo.Adventure", "LocationId");
            DropColumn("dbo.Adventure", "ActivityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adventure", "ActivityId", c => c.Int(nullable: false));
            AddColumn("dbo.Adventure", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Location", "AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.Activity", "AdventureId", "dbo.Adventure");
            DropIndex("dbo.Location", new[] { "AdventureId" });
            DropIndex("dbo.Activity", new[] { "AdventureId" });
            AlterColumn("dbo.Location", "AdventureId", c => c.Int());
            AlterColumn("dbo.Activity", "AdventureId", c => c.Int());
            RenameColumn(table: "dbo.Location", name: "AdventureId", newName: "Adventure_AdventureId");
            RenameColumn(table: "dbo.Activity", name: "AdventureId", newName: "Adventure_AdventureId");
            CreateIndex("dbo.Location", "Adventure_AdventureId");
            CreateIndex("dbo.Activity", "Adventure_AdventureId");
            AddForeignKey("dbo.Location", "Adventure_AdventureId", "dbo.Adventure", "AdventureId");
            AddForeignKey("dbo.Activity", "Adventure_AdventureId", "dbo.Adventure", "AdventureId");
        }
    }
}
