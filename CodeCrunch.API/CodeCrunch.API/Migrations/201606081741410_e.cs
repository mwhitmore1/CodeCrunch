namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BootcampLanguage", newName: "LanguageBootcamp");
            RenameTable(name: "dbo.CompletedChapterStudent", newName: "CompletedChapters");
            RenameColumn(table: "dbo.LanguageBootcamp", name: "Bootcamp_Id", newName: "BootcampId");
            RenameColumn(table: "dbo.LanguageBootcamp", name: "Language_LanguageId", newName: "LanguageId");
            RenameIndex(table: "dbo.LanguageBootcamp", name: "IX_Bootcamp_Id", newName: "IX_BootcampId");
            RenameIndex(table: "dbo.LanguageBootcamp", name: "IX_Language_LanguageId", newName: "IX_LanguageId");
            DropColumn("dbo.Track", "StudentId");
            DropColumn("dbo.Track", "CreatorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "CreatorName", c => c.String());
            AddColumn("dbo.Track", "StudentId", c => c.String());
            RenameIndex(table: "dbo.LanguageBootcamp", name: "IX_LanguageId", newName: "IX_Language_LanguageId");
            RenameIndex(table: "dbo.LanguageBootcamp", name: "IX_BootcampId", newName: "IX_Bootcamp_Id");
            RenameColumn(table: "dbo.LanguageBootcamp", name: "LanguageId", newName: "Language_LanguageId");
            RenameColumn(table: "dbo.LanguageBootcamp", name: "BootcampId", newName: "Bootcamp_Id");
            RenameTable(name: "dbo.CompletedChapters", newName: "CompletedChapterStudent");
            RenameTable(name: "dbo.LanguageBootcamp", newName: "BootcampLanguage");
        }
    }
}
