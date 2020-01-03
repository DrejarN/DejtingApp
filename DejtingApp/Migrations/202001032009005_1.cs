namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUser_Id", newName: "ApplicationUser_Id_Id");
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUser_Id_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUser_Id_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUser_Id_Id", newName: "ApplicationUser_Id");
        }
    }
}
