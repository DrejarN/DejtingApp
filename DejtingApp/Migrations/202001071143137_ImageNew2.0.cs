namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageNew20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImgPath = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Images", new[] { "ProfileId" });
            DropTable("dbo.Images");
        }
    }
}
