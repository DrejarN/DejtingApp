namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
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
                        ApplicationUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser)
                .Index(t => t.ApplicationUser);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                .ForeignKey("dbo.Profiles", t => t.RecieverId)
                .ForeignKey("dbo.Profiles", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.RecieverId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Interests", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Images", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.ProfileViews", "SendClickId", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "SenderId", "dbo.Profiles");
            DropForeignKey("dbo.Messages", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.FriendRequests", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "RecieverId", "dbo.Profiles");
            DropForeignKey("dbo.Friends", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProfileViews", "RecieveClickId", "dbo.Profiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profiles", "ApplicationUser", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Interests", new[] { "ProfileId" });
            DropIndex("dbo.Images", new[] { "ProfileId" });
            DropIndex("dbo.Messages", new[] { "RecieverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.Friends", new[] { "CategoryId" });
            DropIndex("dbo.Friends", new[] { "RecieverId" });
            DropIndex("dbo.Friends", new[] { "SenderId" });
            DropIndex("dbo.ProfileViews", new[] { "RecieveClickId" });
            DropIndex("dbo.ProfileViews", new[] { "SendClickId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Profiles", new[] { "ApplicationUser" });
            DropIndex("dbo.FriendRequests", new[] { "RecieverId" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Interests");
            DropTable("dbo.Images");
            DropTable("dbo.Messages");
            DropTable("dbo.Friends");
            DropTable("dbo.ProfileViews");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Profiles");
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Categories");
        }
    }
}
