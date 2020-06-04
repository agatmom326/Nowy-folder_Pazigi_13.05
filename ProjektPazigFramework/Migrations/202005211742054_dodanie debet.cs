namespace ProjektPazigFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniedebet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Debets",
                c => new
                    {
                        DebetId = c.Int(nullable: false, identity: true),
                        WhoId = c.Int(nullable: false),
                        ForWhoId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DebetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Debets");
        }
    }
}
