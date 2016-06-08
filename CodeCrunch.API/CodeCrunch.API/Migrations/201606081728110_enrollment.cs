namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentTrack", newName: "Enrollment");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Enrollment", newName: "StudentTrack");
        }
    }
}
