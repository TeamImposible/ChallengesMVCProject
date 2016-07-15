namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationsFinal1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Notifications", "ChallengeID");
            AddForeignKey("dbo.Notifications", "ChallengeID", "dbo.Tasks", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ChallengeID", "dbo.Tasks");
            DropIndex("dbo.Notifications", new[] { "ChallengeID" });
        }
    }
}
