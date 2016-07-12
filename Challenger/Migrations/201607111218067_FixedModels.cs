namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "Assignee_Id" });
            DropIndex("dbo.Tasks", new[] { "Challenger_Id" });
            DropIndex("dbo.Notifications", new[] { "Sender_Id" });
            DropIndex("dbo.Notifications", new[] { "Recipient_Id" });
            AlterColumn("dbo.Tasks", "Assignee_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tasks", "Challenger_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Notifications", "Sender_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Notifications", "Recipient_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tasks", "Assignee_Id");
            CreateIndex("dbo.Tasks", "Challenger_Id");
            CreateIndex("dbo.Notifications", "Sender_Id");
            CreateIndex("dbo.Notifications", "Recipient_Id");
            AddForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "Recipient_Id" });
            DropIndex("dbo.Notifications", new[] { "Sender_Id" });
            DropIndex("dbo.Tasks", new[] { "Challenger_Id" });
            DropIndex("dbo.Tasks", new[] { "Assignee_Id" });
            AlterColumn("dbo.Notifications", "Recipient_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Notifications", "Sender_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Challenger_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Assignee_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Notifications", "Recipient_Id");
            CreateIndex("dbo.Notifications", "Sender_Id");
            CreateIndex("dbo.Tasks", "Challenger_Id");
            CreateIndex("dbo.Tasks", "Assignee_Id");
            AddForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
