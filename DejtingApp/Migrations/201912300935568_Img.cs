namespace DejtingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePages", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfilePages", "ImagePath");
        }
    }
}
