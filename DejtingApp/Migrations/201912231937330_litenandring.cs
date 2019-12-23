namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class litenandring : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.Profiles", "ProfileId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Profiles", "ProfileId");
            DropColumn("dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.Profiles", "ProfileId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Profiles", "Id");
        }
    }
}
