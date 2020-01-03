namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUser_Id_Id", newName: "AppUser_Id");
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUser_Id_Id", newName: "IX_AppUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Profiles", name: "IX_AppUser_Id", newName: "IX_ApplicationUser_Id_Id");
            RenameColumn(table: "dbo.Profiles", name: "AppUser_Id", newName: "ApplicationUser_Id_Id");
        }
    }
}
