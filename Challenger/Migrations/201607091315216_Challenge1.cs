namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Challenge1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "Assignee_Id" });
            DropIndex("dbo.Tasks", new[] { "Challenger_Id" });
            AlterColumn("dbo.Tasks", "Title", c => c.String(nullable: false, maxLength: 72));
            AlterColumn("dbo.Tasks", "Assignee_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tasks", "Challenger_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tasks", "Assignee_Id");
            CreateIndex("dbo.Tasks", "Challenger_Id");
            AddForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Tasks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Name", c => c.String(nullable: false, maxLength: 72));
            DropForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "Challenger_Id" });
            DropIndex("dbo.Tasks", new[] { "Assignee_Id" });
            AlterColumn("dbo.Tasks", "Challenger_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Assignee_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Title", c => c.String());
            CreateIndex("dbo.Tasks", "Challenger_Id");
            CreateIndex("dbo.Tasks", "Assignee_Id");
            AddForeignKey("dbo.Tasks", "Challenger_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
