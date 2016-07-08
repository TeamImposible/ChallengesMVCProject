namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialHierarchy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        RecipientID = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        Sender_Id = c.String(maxLength: 128),
                        Recipient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Recipient_Id);
            
            AddColumn("dbo.Tasks", "Title", c => c.String());
            AddColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "DueDate", c => c.String());
            AddColumn("dbo.Tasks", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompletedChallenges", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "Recipient_Id" });
            DropIndex("dbo.Notifications", new[] { "Sender_Id" });
            DropColumn("dbo.AspNetUsers", "CompletedChallenges");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "Level");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.Tasks", "Description");
            DropColumn("dbo.Tasks", "Quantity");
            DropColumn("dbo.Tasks", "DueDate");
            DropColumn("dbo.Tasks", "Status");
            DropColumn("dbo.Tasks", "Title");
            DropTable("dbo.Notifications");
        }
    }
}
