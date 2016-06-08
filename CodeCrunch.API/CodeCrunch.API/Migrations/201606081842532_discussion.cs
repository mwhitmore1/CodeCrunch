namespace CodeCrunch.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discussion : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuleAnswer", "ModuleQuestionId", "dbo.ModuleQuestion");
            DropForeignKey("dbo.ModuleQuestion", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.ModuleQuestion", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ModuleAnswer", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ModuleQuestion", new[] { "UserId" });
            DropIndex("dbo.ModuleQuestion", new[] { "ModuleId" });
            DropIndex("dbo.ModuleAnswer", new[] { "UserId" });
            DropIndex("dbo.ModuleAnswer", new[] { "ModuleQuestionId" });
            DropTable("dbo.ModuleQuestion");
            DropTable("dbo.ModuleAnswer");
        }
    }
}
