namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testvane : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "ChallengerID");
            DropColumn("dbo.Tasks", "AssigneeID");
            DropColumn("dbo.AspNetUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "AssigneeID", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "ChallengerID", c => c.Int(nullable: false));
        }
    }
}
