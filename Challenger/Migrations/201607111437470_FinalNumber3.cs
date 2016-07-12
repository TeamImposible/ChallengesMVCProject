namespace Challenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalNumber3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
