namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppDbContect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestName = c.String(),
                        ProfilePageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfilePages", t => t.ProfilePageId, cascadeDelete: true)
                .Index(t => t.ProfilePageId);
            
            CreateTable(
                "dbo.ProfilePages",
                c => new
                    {
                        ProfilePageId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProfilePageId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        Förnamn = c.String(),
                        Efternamn = c.String(),
                        Födelseår = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interests", "ProfilePageId", "dbo.ProfilePages");
            DropIndex("dbo.Interests", new[] { "ProfilePageId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.ProfilePages");
            DropTable("dbo.Interests");
        }
    }
}
