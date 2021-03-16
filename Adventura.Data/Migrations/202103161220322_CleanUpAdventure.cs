﻿namespace Adventura.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanUpAdventure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventure", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Adventure", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adventure", "Title", c => c.String(nullable: false, maxLength: 750));
            DropColumn("dbo.Adventure", "Description");
        }
    }
}