namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
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
            
            CreateTable(
                "dbo.Adventure",
                c => new
                    {
                        AdventureId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        LocationId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        user_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdventureId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        EditUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Adventure_AdventureId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Adventure", t => t.Adventure_AdventureId)
                .Index(t => t.Adventure_AdventureId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
