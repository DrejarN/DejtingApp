namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "ApplicationUser_Id");
            AddForeignKey("dbo.Profiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Profiles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Profiles", "ApplicationUser_Id");
        }
    }
}
