namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapter", "BootcampId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Chapter", "BootcampId");
            AddForeignKey("dbo.Chapter", "BootcampId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapter", "BootcampId", "dbo.AspNetUsers");
            DropIndex("dbo.Chapter", new[] { "BootcampId" });
            DropColumn("dbo.Chapter", "BootcampId");
        }
    }
}
