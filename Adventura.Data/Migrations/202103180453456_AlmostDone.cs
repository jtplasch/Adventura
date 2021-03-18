namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostDone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdventureUser", "Adventure_AdventureId", "dbo.Adventure");
            DropForeignKey("dbo.AdventureUser", "User_Id", "dbo.User");
            DropIndex("dbo.AdventureUser", new[] { "Adventure_AdventureId" });
            DropIndex("dbo.AdventureUser", new[] { "User_Id" });
            DropColumn("dbo.Adventure", "user_Id");
            DropTable("dbo.User");
            DropTable("dbo.AdventureUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdventureUser",
                c => new
                    {
                        Adventure_AdventureId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Adventure_AdventureId, t.User_Id });
            
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
            
            AddColumn("dbo.Adventure", "user_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AdventureUser", "User_Id");
            CreateIndex("dbo.AdventureUser", "Adventure_AdventureId");
            AddForeignKey("dbo.AdventureUser", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdventureUser", "Adventure_AdventureId", "dbo.Adventure", "AdventureId", cascadeDelete: true);
        }
    }
}
