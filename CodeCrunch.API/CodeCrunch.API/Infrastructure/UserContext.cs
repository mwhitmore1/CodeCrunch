using CodeCrunch.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CodeCrunch.API.Infrastructure
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext()
            : base("CodeCrunch")
        {

        }

        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Bootcamp> Bootcamps { get; set; }
        public IDbSet<ProfilePicture> ProfilePictures { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Student)
                .WithRequiredPrincipal(u => u.User);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Bootcamp)
                .WithRequiredPrincipal(u => u.User);

            base.OnModelCreating(modelBuilder);
               
        }
    }
}