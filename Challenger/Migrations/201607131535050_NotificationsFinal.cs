namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationsFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "CreationDate");
        }
    }
}
