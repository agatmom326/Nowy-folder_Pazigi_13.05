namespace ProjektPazigFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modyfikacjaDebet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debets", "WhoName", c => c.String());
            AddColumn("dbo.Debets", "ForWhoName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Debets", "ForWhoName");
            DropColumn("dbo.Debets", "WhoName");
        }
    }
}
