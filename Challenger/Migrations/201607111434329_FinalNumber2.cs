namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalNumber2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CreationDate");
        }
    }
}
