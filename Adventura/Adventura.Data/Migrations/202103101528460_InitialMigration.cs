namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventure", "Title", c => c.String(nullable: false, maxLength: 750));
            AddColumn("dbo.Adventure", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adventure", "CreatedUtc");
            DropColumn("dbo.Adventure", "Title");
        }
    }
}
