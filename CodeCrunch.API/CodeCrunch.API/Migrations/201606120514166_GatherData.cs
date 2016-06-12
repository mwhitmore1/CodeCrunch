namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GatherData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "ChapterContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapter", "ChapterContent");
        }
    }
}
