namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfilePicture", "ImageUrl", c => c.String());
            DropColumn("dbo.Module", "TrackId");
            DropColumn("dbo.ProfilePicture", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfilePicture", "Image", c => c.Binary());
            AddColumn("dbo.Module", "TrackId", c => c.Int(nullable: false));
            DropColumn("dbo.ProfilePicture", "ImageUrl");
        }
    }
}
