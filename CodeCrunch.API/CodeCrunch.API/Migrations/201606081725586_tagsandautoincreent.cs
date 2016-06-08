namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsandautoincreent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Track_TrackId = c.Int(),
                    })
                .PrimaryKey(t => t.LanguageId)
                .ForeignKey("dbo.Track", t => t.Track_TrackId)
                .Index(t => t.Track_TrackId);
            
            CreateTable(
                "dbo.Perk",
                c => new
                    {
                        PerkId = c.Int(nullable: false, identity: true),
                        BootcampId = c.String(maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PerkId)
                .ForeignKey("dbo.AspNetUsers", t => t.BootcampId)
                .Index(t => t.BootcampId);
            
            CreateTable(
                "dbo.BootcampLanguage",
                c => new
                    {
                        Bootcamp_Id = c.String(nullable: false, maxLength: 128),
                        Language_LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bootcamp_Id, t.Language_LanguageId })
                .ForeignKey("dbo.AspNetUsers", t => t.Bootcamp_Id)
                .ForeignKey("dbo.Language", t => t.Language_LanguageId)
                .Index(t => t.Bootcamp_Id)
                .Index(t => t.Language_LanguageId);
            
            AddColumn("dbo.AspNetUsers", "BootcampAddress", c => c.String());
            AddColumn("dbo.Chapter", "Likes", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "BootcampId");
            DropColumn("dbo.AspNetUsers", "Perks");
            DropColumn("dbo.AspNetUsers", "StudentId");
            DropColumn("dbo.AspNetUsers", "LinkedIn1");
            DropColumn("dbo.AspNetUsers", "Blog1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Blog1", c => c.String());
            AddColumn("dbo.AspNetUsers", "LinkedIn1", c => c.String());
            AddColumn("dbo.AspNetUsers", "StudentId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Perks", c => c.String());
            AddColumn("dbo.AspNetUsers", "BootcampId", c => c.Int());
            DropForeignKey("dbo.Perk", "BootcampId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "Track_TrackId", "dbo.Track");
            DropForeignKey("dbo.BootcampLanguage", "Language_LanguageId", "dbo.Language");
            DropForeignKey("dbo.BootcampLanguage", "Bootcamp_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BootcampLanguage", new[] { "Language_LanguageId" });
            DropIndex("dbo.BootcampLanguage", new[] { "Bootcamp_Id" });
            DropIndex("dbo.Perk", new[] { "BootcampId" });
            DropIndex("dbo.Language", new[] { "Track_TrackId" });
            DropColumn("dbo.Chapter", "Likes");
            DropColumn("dbo.AspNetUsers", "BootcampAddress");
            DropTable("dbo.BootcampLanguage");
            DropTable("dbo.Perk");
            DropTable("dbo.Language");
        }
    }
}
