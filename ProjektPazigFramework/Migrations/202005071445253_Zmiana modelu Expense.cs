namespace ProjektPazigFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianamodeluExpense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "Name");
        }
    }
}
