using CodeCrunch.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeCrunch.API.Infrastructure
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext()
            : base("CodeCrunch")
        {

        }
        public IDbSet<Bootcamp> Bootcamps { get; set; }
        public IDbSet<Chapter> Chapters { get; set; }
        public IDbSet<Module> Modules { get; set; }
        public IDbSet<ProfilePicture> ProfilePictures { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Bootcamp>()
                .HasMany(b => b.Languages)
                .WithMany(l => l.Bootcamps)
                .Map(bl =>
                {
                    bl.MapLeftKey("BootcampId");
                    bl.MapRightKey("LanguageId");
                    bl.ToTable("BootcampLanguage");
                });

            modelBuilder.Entity<Bootcamp>()
                .HasMany(b => b.Perks)
                .WithOptional(p => p.Bootcamp)
                .HasForeignKey(p => p.BootcampId);

            modelBuilder.Entity<ProfilePicture>()
                .HasRequired(pp => pp.User);

            modelBuilder.Entity<Bootcamp>()
                .HasMany(b => b.Tracks)
                .WithRequired(t => t.Bootcamp)
                .HasForeignKey(t => t.BootcampId);

            modelBuilder.Entity<Bootcamp>()
               .HasMany(b => b.Modules)
               .WithOptional(m => m.Bootcamp)
               .HasForeignKey(m => m.BootcampId);

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Tracks)
                .WithMany(t => t.Modules)
                .Map(tm =>
                {
                    tm.MapLeftKey("ModuleId");
                    tm.MapRightKey("TrackId");
                    tm.ToTable("TrackModule");
                });

//////////// Discussion forum

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Questions)
                .WithRequired(q => q.Module)
                .HasForeignKey(q => q.ModuleId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Questions)
                .WithRequired(q => q.User)
                .HasForeignKey(q => q.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Answers)
                .WithRequired(q => q.User)
                .HasForeignKey(q => q.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ModuleQuestion>()
                .HasMany(q => q.ModuleAnswers)
                .WithRequired(a => a.ModuleQuestion)
                .HasForeignKey(a => a.ModuleQuestionId);

////////////

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Chapters)
                .WithRequired(c => c.Module)
                .HasForeignKey(c => c.ModuleId);

            modelBuilder.Entity<Student>()   
               .HasMany(s => s.EnrolledTracks)
               .WithMany(t => t.EnrolledStudents)
               .Map(ts =>
               {
                   ts.MapLeftKey("StudentId");
                   ts.MapRightKey("TrackId");
                   ts.ToTable("Enrollment");
               });

            modelBuilder.Entity<Bootcamp>()
                .HasMany(b => b.Languages)
                .WithMany(l => l.Bootcamps)
                .Map(bl =>
                {
                    bl.MapLeftKey("BootcampId");
                    bl.MapRightKey("LanguageId");
                    bl.ToTable("LanguageBootcamp");
                });

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Student>()
               .HasMany(s => s.CompletedChapters)
               .WithMany(c => c.CompletedChapterStudents)
               .Map(cs =>
               {
                   cs.MapLeftKey("StudentId");
                   cs.MapRightKey("CompletedChapterId");
                   cs.ToTable("CompletedChapters");
               });

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CodeCrunch.API.Models.ModuleQuestion> ModuleQuestions { get; set; }

        public System.Data.Entity.DbSet<CodeCrunch.API.Models.ModuleAnswer> ModuleAnswers { get; set; }
    }
}