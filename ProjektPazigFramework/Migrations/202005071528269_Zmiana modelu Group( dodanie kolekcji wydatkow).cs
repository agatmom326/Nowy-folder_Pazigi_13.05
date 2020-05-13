namespace ProjektPazigFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianamodeluGroupdodaniekolekcjiwydatkow : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Expenses", "GroupId");
            AddForeignKey("dbo.Expenses", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "GroupId", "dbo.Groups");
            DropIndex("dbo.Expenses", new[] { "GroupId" });
        }
    }
}
