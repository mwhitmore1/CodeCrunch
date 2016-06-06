namespace CodeCrunch.API.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeCrunch.API.Infrastructure.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeCrunch.API.Infrastructure.UserContext context)
        {
            /*
            UserManager<User> manager = new UserManager<User>(new UserStore<User>(new UserContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new UserContext()));
            var user = new User()
            {
                Email = "fake@email.com",
                UserName = "SuperUser",
            };

            manager.Create(user, "Pass");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Student" });
                roleManager.Create(new IdentityRole { Name = "Bootcamp" });
            }

            User admin = manager.FindByName("SuperUser");

            manager.AddToRole(admin.Id, "Admin");
            */
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
    }
    }
}
