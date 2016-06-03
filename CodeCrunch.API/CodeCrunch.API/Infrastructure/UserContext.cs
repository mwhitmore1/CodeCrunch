using CodeCrunch.API.Models;
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

            modelBuilder.Entity<Student>()
                .HasRequired(s => s.User)
                .WithOptional(u => u.Student);

            modelBuilder.Entity<Bootcamp>()
                .HasRequired(b => b.User)
                .WithOptional(u => u.Bootcamp);

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

            modelBuilder.Entity<Student>()
               .HasMany(s => s.CompletedChapters)
               .WithMany(c => c.CompletedChapterStudents)
               .Map(cs =>
               {
                   cs.MapLeftKey("StudentId");
                   cs.MapRightKey("CompletedChapterId");
                   cs.ToTable("CompletedChapterStudent");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}