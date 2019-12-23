namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.Profiles", "ProfileId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Profiles", "ProfileId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.Profiles", "ProfileId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Profiles", "ProfileId");
        }
    }
}
