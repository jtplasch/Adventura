namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Location", "AdventureId", "dbo.Adventure");
            DropIndex("dbo.Activity", new[] { "LocationId" });
            DropIndex("dbo.Location", new[] { "AdventureId" });
            RenameColumn(table: "dbo.Location", name: "AdventureId", newName: "Adventure_AdventureId");
            CreateTable(
                "dbo.AdventureUser",
                c => new
                    {
                        Adventure_AdventureId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Adventure_AdventureId, t.User_Id })
                .ForeignKey("dbo.Adventure", t => t.Adventure_AdventureId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Adventure_AdventureId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Activity", "Adventure_AdventureId", c => c.Int());
            AddColumn("dbo.Adventure", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Adventure", "ActivityId", c => c.Int(nullable: false));
            AddColumn("dbo.Adventure", "user_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Location", "Adventure_AdventureId", c => c.Int());
            CreateIndex("dbo.Activity", "Adventure_AdventureId");
            CreateIndex("dbo.Location", "Adventure_AdventureId");
            AddForeignKey("dbo.Activity", "Adventure_AdventureId", "dbo.Adventure", "AdventureId");
            AddForeignKey("dbo.Location", "Adventure_AdventureId", "dbo.Adventure", "AdventureId");
            DropColumn("dbo.Activity", "LocationId");
            DropColumn("dbo.Adventure", "Location");
            DropColumn("dbo.Adventure", "Activities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adventure", "Activities", c => c.String(maxLength: 750));
            AddColumn("dbo.Adventure", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Activity", "LocationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Location", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.AdventureUser", "User_Id", "dbo.User");
            DropForeignKey("dbo.AdventureUser", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.Activity", "Adventure_AdventureId", "dbo.Adventure");
            DropIndex("dbo.AdventureUser", new[] { "User_Id" });
            DropIndex("dbo.AdventureUser", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.Location", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.Activity", new[] { "Adventure_AdventureId" });
            AlterColumn("dbo.Location", "Adventure_AdventureId", c => c.Int(nullable: false));
            DropColumn("dbo.Adventure", "user_Id");
            DropColumn("dbo.Adventure", "ActivityId");
            DropColumn("dbo.Adventure", "LocationId");
            DropColumn("dbo.Activity", "Adventure_AdventureId");
            DropTable("dbo.AdventureUser");
            RenameColumn(table: "dbo.Location", name: "Adventure_AdventureId", newName: "AdventureId");
            CreateIndex("dbo.Location", "AdventureId");
            CreateIndex("dbo.Activity", "LocationId");
            AddForeignKey("dbo.Location", "AdventureId", "dbo.Adventure", "AdventureId", cascadeDelete: true);
            AddForeignKey("dbo.Activity", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
        }
    }
}
