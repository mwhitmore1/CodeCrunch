namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "BootcampName1");
            DropColumn("dbo.AspNetUsers", "BootcampSite1");
            DropColumn("dbo.AspNetUsers", "BootcampCity1");
            DropColumn("dbo.AspNetUsers", "BootcampState1");
            DropColumn("dbo.AspNetUsers", "BootcampAddress1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BootcampAddress1", c => c.String());
            AddColumn("dbo.AspNetUsers", "BootcampState1", c => c.String());
            AddColumn("dbo.AspNetUsers", "BootcampCity1", c => c.String());
            AddColumn("dbo.AspNetUsers", "BootcampSite1", c => c.String());
            AddColumn("dbo.AspNetUsers", "BootcampName1", c => c.String());
        }
    }
}