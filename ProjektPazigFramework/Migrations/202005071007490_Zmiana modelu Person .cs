namespace ProjektPazigFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianamodeluPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debtors",
                c => new
                    {
                        DebtorId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        ExpenseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DebtorId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NrIndexInGroup = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropIndex("dbo.People", new[] { "GroupId" });
            DropTable("dbo.People");
            DropTable("dbo.Groups");
            DropTable("dbo.Expenses");
            DropTable("dbo.Debtors");
        }
    }
}
