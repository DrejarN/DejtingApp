namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageTet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        MessageCreated = c.DateTime(nullable: false),
                        SenderId = c.Int(),
                        RecieverId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ProfilePages", t => t.RecieverId)
                .ForeignKey("dbo.ProfilePages", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.RecieverId);
            
            AddColumn("dbo.ProfilePages", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProfilePages", "ProfileId");
            AddForeignKey("dbo.ProfilePages", "ProfileId", "dbo.Profiles", "ProfileID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.ProfilePages");
            DropForeignKey("dbo.Messages", "RecieverId", "dbo.ProfilePages");
            DropForeignKey("dbo.ProfilePages", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Messages", new[] { "RecieverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.ProfilePages", new[] { "ProfileId" });
            DropColumn("dbo.ProfilePages", "ProfileId");
            DropTable("dbo.Messages");
        }
    }
}
