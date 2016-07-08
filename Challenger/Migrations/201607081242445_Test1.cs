namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Password");
        }
    }
}
