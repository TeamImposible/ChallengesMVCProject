namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testvane1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Title", c => c.String(nullable: false, maxLength: 72));
            DropColumn("dbo.Tasks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Name", c => c.String(nullable: false, maxLength: 72));
            AlterColumn("dbo.Tasks", "Title", c => c.String());
        }
    }
}
