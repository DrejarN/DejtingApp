namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendTestDb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendshipId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(),
                        RecieverId = c.Int(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendshipId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.RecieverId)
                .ForeignKey("dbo.Profiles", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.RecieverId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Friends", new[] { "CategoryId" });
            DropIndex("dbo.Friends", new[] { "RecieverId" });
            DropIndex("dbo.Friends", new[] { "SenderId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Friends");
        }
    }
}
