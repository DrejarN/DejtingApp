namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileView_and_Image : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileViews",
                c => new
                    {
                        ProfileViewId = c.Int(nullable: false, identity: true),
                        SendClickId = c.Int(),
                        RecieveClickId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileViewId)
                .ForeignKey("dbo.Profiles", t => t.RecieveClickId)
                .ForeignKey("dbo.Profiles", t => t.SendClickId)
                .Index(t => t.SendClickId)
                .Index(t => t.RecieveClickId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileViews", "SendClickId", "dbo.Profiles");
            DropForeignKey("dbo.ProfileViews", "RecieveClickId", "dbo.Profiles");
            DropIndex("dbo.ProfileViews", new[] { "RecieveClickId" });
            DropIndex("dbo.ProfileViews", new[] { "SendClickId" });
            DropTable("dbo.ProfileViews");
        }
    }
}
