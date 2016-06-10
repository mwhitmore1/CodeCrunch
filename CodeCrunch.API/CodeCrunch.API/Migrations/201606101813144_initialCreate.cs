namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProfilePictureId = c.Int(),
                        Description = c.String(),
                        LinkedIn = c.String(),
                        Blog = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        BootcampName = c.String(),
                        BootcampSite = c.String(),
                        BootcampCity = c.String(),
                        BootcampState = c.String(),
                        BootcampAddress = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Interests = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.ModuleAnswer",
                c => new
                    {
                        ModuleAnswerId = c.Int(nullable: false, identity: true),
                        ModuleQuestionId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpVote = c.Int(nullable: false),
                        DownVote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleAnswerId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.ModuleQuestion", t => t.ModuleQuestionId, cascadeDelete: true)
                .Index(t => t.ModuleQuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ModuleQuestion",
                c => new
                    {
                        ModuleQuestionId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpVote = c.Int(nullable: false),
                        DownVote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleQuestionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        BootcampId = c.String(maxLength: 128),
                        ModuleName = c.String(),
                        ModuleDescription = c.String(),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.AspNetUsers", t => t.BootcampId)
                .Index(t => t.BootcampId);
            
            CreateTable(
                "dbo.Chapter",
                c => new
                    {
                        ChapterId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        CurrentChapter = c.Boolean(nullable: false),
                        ChapterName = c.String(),
                        ChapterDescription = c.String(),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChapterId)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        TrackName = c.String(),
                        Description = c.String(),
                        BootcampId = c.String(nullable: false, maxLength: 128),
                        SearchBootcamp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.AspNetUsers", t => t.BootcampId, cascadeDelete: true)
                .Index(t => t.BootcampId);
            
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
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProfilePicture",
                c => new
                    {
                        ProfilePictureId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ImageUrl = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProfilePictureId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CompletedChapters",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        CompletedChapterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CompletedChapterId })
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.Chapter", t => t.CompletedChapterId)
                .Index(t => t.StudentId)
                .Index(t => t.CompletedChapterId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.TrackId })
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .ForeignKey("dbo.Track", t => t.TrackId)
                .Index(t => t.StudentId)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.TrackModule",
                c => new
                    {
                        ModuleId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModuleId, t.TrackId })
                .ForeignKey("dbo.Module", t => t.ModuleId)
                .ForeignKey("dbo.Track", t => t.TrackId)
                .Index(t => t.ModuleId)
                .Index(t => t.TrackId);
            
            CreateTable(
                "dbo.LanguageBootcamp",
                c => new
                    {
                        BootcampId = c.String(nullable: false, maxLength: 128),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BootcampId, t.LanguageId })
                .ForeignKey("dbo.AspNetUsers", t => t.BootcampId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .Index(t => t.BootcampId)
                .Index(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Track", "BootcampId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Perk", "BootcampId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Module", "BootcampId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LanguageBootcamp", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.LanguageBootcamp", "BootcampId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ModuleAnswer", "ModuleQuestionId", "dbo.ModuleQuestion");
            DropForeignKey("dbo.TrackModule", "TrackId", "dbo.Track");
            DropForeignKey("dbo.TrackModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.ModuleQuestion", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Chapter", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.ProfilePicture", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ModuleQuestion", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ModuleAnswer", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollment", "TrackId", "dbo.Track");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "Track_TrackId", "dbo.Track");
            DropForeignKey("dbo.CompletedChapters", "CompletedChapterId", "dbo.Chapter");
            DropForeignKey("dbo.CompletedChapters", "StudentId", "dbo.AspNetUsers");
            DropIndex("dbo.LanguageBootcamp", new[] { "LanguageId" });
            DropIndex("dbo.LanguageBootcamp", new[] { "BootcampId" });
            DropIndex("dbo.TrackModule", new[] { "TrackId" });
            DropIndex("dbo.TrackModule", new[] { "ModuleId" });
            DropIndex("dbo.Enrollment", new[] { "TrackId" });
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.CompletedChapters", new[] { "CompletedChapterId" });
            DropIndex("dbo.CompletedChapters", new[] { "StudentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Perk", new[] { "BootcampId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ProfilePicture", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Language", new[] { "Track_TrackId" });
            DropIndex("dbo.Track", new[] { "BootcampId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Chapter", new[] { "ModuleId" });
            DropIndex("dbo.Module", new[] { "BootcampId" });
            DropIndex("dbo.ModuleQuestion", new[] { "UserId" });
            DropIndex("dbo.ModuleQuestion", new[] { "ModuleId" });
            DropIndex("dbo.ModuleAnswer", new[] { "UserId" });
            DropIndex("dbo.ModuleAnswer", new[] { "ModuleQuestionId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.LanguageBootcamp");
            DropTable("dbo.TrackModule");
            DropTable("dbo.Enrollment");
            DropTable("dbo.CompletedChapters");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Perk");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ProfilePicture");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Language");
            DropTable("dbo.Track");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Chapter");
            DropTable("dbo.Module");
            DropTable("dbo.ModuleQuestion");
            DropTable("dbo.ModuleAnswer");
            DropTable("dbo.AspNetUsers");
        }
    }
}
