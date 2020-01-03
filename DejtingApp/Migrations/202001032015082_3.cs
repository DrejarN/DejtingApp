namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "AppUser_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.Profiles", name: "IX_AppUser_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUser", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUser", newName: "AppUser_Id");
        }
    }
}
