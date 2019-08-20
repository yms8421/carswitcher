namespace BilgeAdam.CardSwitcher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Player1Id = c.Guid(nullable: false),
                        Player2Id = c.Guid(nullable: false),
                        Winner = c.Int(nullable: false),
                        GamePoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Player1Id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Player2Id, cascadeDelete: false)
                .Index(t => t.Player1Id)
                .Index(t => t.Player2Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 64),
                        RecordDate = c.DateTime(nullable: false),
                        Point = c.Int(nullable: false),
                        DrawCount = c.Int(nullable: false),
                        WinCount = c.Int(nullable: false),
                        LooseCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Player2Id", "dbo.Users");
            DropForeignKey("dbo.Games", "Player1Id", "dbo.Users");
            DropIndex("dbo.Games", new[] { "Player2Id" });
            DropIndex("dbo.Games", new[] { "Player1Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Games");
        }
    }
}
