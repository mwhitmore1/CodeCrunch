namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveModuleIdFromTrack : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Track", "ModuleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "ModuleId", c => c.Int(nullable: false));
        }
    }
}
