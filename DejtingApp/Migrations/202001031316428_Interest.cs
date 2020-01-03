namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        InterestName = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Interests", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.FriendRequests", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "RecieverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.FriendRequests", new[] { "RecieverId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropIndex("dbo.Friends", new[] { "CategoryId" });
            DropIndex("dbo.Friends", new[] { "RecieverId" });
            DropIndex("dbo.Friends", new[] { "SenderId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Profiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Interests", new[] { "ProfileId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Categories");
            DropTable("dbo.Friends");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Profiles");
            DropTable("dbo.Interests");
        }
    }
}
