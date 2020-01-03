namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _do : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUser_Id", newName: "ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Profiles", name: "IX_ApplicationUserId", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Profiles", name: "ApplicationUserId", newName: "ApplicationUserId");
        }
    }
}
