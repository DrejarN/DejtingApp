namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendReqTestDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        FriendRequestId = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(),
                        RecieverId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendRequestId)
                .ForeignKey("dbo.Profiles", t => t.RecieverId)
                .ForeignKey("dbo.Profiles", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.RecieverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.FriendRequests", "RecieverId", "dbo.Profiles");
            DropIndex("dbo.FriendRequests", new[] { "RecieverId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropTable("dbo.FriendRequests");
        }
    }
}
