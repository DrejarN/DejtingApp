namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appUser : DbMigration
    {
        public override void Up()
        {
                        CreateTable(
                "dbo.Profiles",
                c => new
                {
                    ProfileId = c.Int(nullable: false, identity: true),
                    Förnamn = c.String(),
                    Efternamn = c.String(),
                    Födelseår = c.DateTime(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Description = c.String(),
                    ImagePath = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
        
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropTable("dbo.Profiles");
        }
    }
}
