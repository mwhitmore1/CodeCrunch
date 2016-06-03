namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bootcamp",
                c => new
                    {
                        BootcampId = c.Int(nullable: false, identity: true),
                        BootcampName = c.String(),
                        BootcampSite = c.String(),
                        BootcampCity = c.String(),
                        BootcampState = c.String(),
                        Perks = c.String(),
                        LinkedIn = c.String(),
                        Blog = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BootcampId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        BootcampId = c.Int(),
                        ModuleName = c.String(),
                        ModuleDescription = c.String(),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Bootcamp", t => t.BootcampId)
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
                    })
                .PrimaryKey(t => t.ChapterId)
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                        Interests = c.String(),
                        LinkedIn = c.String(),
                        Blog = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        TrackName = c.String(),
                        Description = c.String(),
                        StudentId = c.String(),
                        ModuleId = c.Int(nullable: false),
                        BootcampId = c.Int(nullable: false),
                        CreatorName = c.String(),
                        SearchBootcamp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Bootcamp", t => t.BootcampId, cascadeDelete: true)
                .Index(t => t.BootcampId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                        Image = c.Binary(),
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CompletedChapterStudent",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CompletedChapterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CompletedChapterId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Chapter", t => t.CompletedChapterId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CompletedChapterId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.TrackId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
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
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Track", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bootcamp", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Track", "BootcampId", "dbo.Bootcamp");
            DropForeignKey("dbo.Module", "BootcampId", "dbo.Bootcamp");
            DropForeignKey("dbo.TrackModule", "TrackId", "dbo.Track");
            DropForeignKey("dbo.TrackModule", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Chapter", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Student", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProfilePicture", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollment", "TrackId", "dbo.Track");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.CompletedChapterStudent", "CompletedChapterId", "dbo.Chapter");
            DropForeignKey("dbo.CompletedChapterStudent", "StudentId", "dbo.Student");
            DropIndex("dbo.TrackModule", new[] { "TrackId" });
            DropIndex("dbo.TrackModule", new[] { "ModuleId" });
            DropIndex("dbo.Enrollment", new[] { "TrackId" });
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.CompletedChapterStudent", new[] { "CompletedChapterId" });
            DropIndex("dbo.CompletedChapterStudent", new[] { "StudentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ProfilePicture", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Track", new[] { "BootcampId" });
            DropIndex("dbo.Student", new[] { "User_Id" });
            DropIndex("dbo.Chapter", new[] { "ModuleId" });
            DropIndex("dbo.Module", new[] { "BootcampId" });
            DropIndex("dbo.Bootcamp", new[] { "User_Id" });
            DropTable("dbo.TrackModule");
            DropTable("dbo.Enrollment");
            DropTable("dbo.CompletedChapterStudent");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ProfilePicture");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Track");
            DropTable("dbo.Student");
            DropTable("dbo.Chapter");
            DropTable("dbo.Module");
            DropTable("dbo.Bootcamp");
        }
    }
}
