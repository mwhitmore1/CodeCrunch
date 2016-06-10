namespace CodeCrunch.API.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using CodeCrunch.API.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System;
    internal sealed class Configuration : DbMigrationsConfiguration<CodeCrunch.API.Infrastructure.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private Random random = new Random();

        protected override void Seed(UserContext context)
        {
            //  This method will be called after migrating to the latest version.



            if (!context.Users.Any(u => u.UserName == "admin@origincodeacademy.com"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                CreateBootcampCalled("Origin Code Academy", userManager, context);
                CreateBootcampCalled("DevBootcamp", userManager, context);
                CreateBootcampCalled("Learn Academy", userManager, context);
                CreateBootcampCalled("HackReactor", userManager, context);
                CreateBootcampCalled("DevFoundry", userManager, context);
                CreateBootcampCalled("Flat Iron School", userManager, context);
            }
        }

        private void CreateBootcampCalled(string name, UserManager<User> userManager, UserContext context)
        {
            string email = "admin@" + string.Join("", name.Split(' ')).ToLower().Trim() + ".com";

            var newBootcamp = new Bootcamp
            {
                BootcampName = name,
                UserName = email,
                Email = email,
                BootcampState = "California"
            };
            userManager.Create(newBootcamp, "Password123_");

            var track = new Track
            {
                Bootcamp = newBootcamp,
                Description = "Lorem ipsum",
                TrackName = (random.Next(0, 1) == 1 ? "Prework" : "Postwork") + " for " + newBootcamp.BootcampName
            };

            int numberOfModules = random.Next(5, 10);

            for (int i = 0; i < numberOfModules; i++)
            {
                var module = new Module
                {
                    Bootcamp = newBootcamp,
                    ModuleDescription = "Ipsum dulor",
                    ModuleName = "Module " + (i + 1)
                };

                int numberOfChapters = random.Next(3, 12);

                for (int j = 0; j < numberOfChapters; j++)
                {
                    var chapter = new Chapter
                    {
                        ChapterDescription = "Chapter Description",
                        ChapterName = "Chapter " + (j + 1),
                        Likes = random.Next(12, 120)
                    };

                    module.Chapters.Add(chapter);
                }

                track.Modules.Add(module);
            }

            newBootcamp.Tracks.Add(track);

            context.Entry(newBootcamp).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}
