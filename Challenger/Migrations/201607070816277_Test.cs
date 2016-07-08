namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "Assignee_Id" });
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Task_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Task_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_ID, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Task_ID);
            
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Tasks", "AssigneeID");
            DropColumn("dbo.Tasks", "Assignee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Assignee_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tasks", "AssigneeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserTasks", "Task_ID", "dbo.Tasks");
            DropForeignKey("dbo.UserTasks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserTasks", new[] { "Task_ID" });
            DropIndex("dbo.UserTasks", new[] { "User_Id" });
            DropColumn("dbo.Tasks", "Description");
            DropTable("dbo.UserTasks");
            CreateIndex("dbo.Tasks", "Assignee_Id");
            AddForeignKey("dbo.Tasks", "Assignee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
