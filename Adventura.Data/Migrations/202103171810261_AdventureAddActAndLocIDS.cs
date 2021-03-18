namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdventureAddActAndLocIDS : DbMigration
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
                        ActivityLength = c.Int(nullable: false),
                        ActivityCost = c.Double(nullable: false),
                        Adventure_AdventureId = c.Int(),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Adventure", t => t.Adventure_AdventureId)
                .Index(t => t.Adventure_AdventureId);                        
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.AdventureUser", "User_Id", "dbo.User");
            DropForeignKey("dbo.AdventureUser", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.Location", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.Activity", "Adventure_AdventureId", "dbo.Adventure");
            DropIndex("dbo.AdventureUser", new[] { "User_Id" });
            DropIndex("dbo.AdventureUser", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Location", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.Activity", new[] { "Adventure_AdventureId" });
            DropTable("dbo.AdventureUser");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.User");
            DropTable("dbo.Location");
            DropTable("dbo.Adventure");
            DropTable("dbo.Activity");
        }
    }
}
