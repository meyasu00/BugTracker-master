namespace BugTracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
           new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }
            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }
            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "meyasu@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "meyasu@coderfoundry.com",
                    Email = "meyasu@coderfoundry.com",
                    FirstName = "Mekuanent",
                    LastName = "Eyasu",
                }, "Abc&123");
            }

            var userId = userManager.FindByEmail("meyasu@coderfoundry.com").Id;
            userManager.AddToRole(userId, "Admin");
            //////////////////////////////////////////////////////
            if (!context.Users.Any(u => u.Email == "user@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "user@coderfoundry.com",
                    Email = "user@coderfoundry.com",
                    FirstName = "Project",
                    LastName = "Manager",
                }, "password1");
            }

            var pmuserId = userManager.FindByEmail("user@coderfoundry.com").Id;
            userManager.AddToRole(pmuserId, "Project Manager");

            ///////////////////////////////////////////////////
            if (!context.Users.Any(u => u.Email == "user1@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "user1@coderfoundry.com",
                    Email = "user1@coderfoundry.com",
                    FirstName = "Project",
                    LastName = "Develper",
                }, "password1");
            }

            var duserId = userManager.FindByEmail("user1@coderfoundry.com").Id;
            userManager.AddToRole(duserId, "Developer");
            /////////////////////////////////////////////////////

            if (!context.Users.Any(u => u.Email == "user2@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "user2@coderfoundry.com",
                    Email = "user2@coderfoundry.com",
                    FirstName = "project",
                    LastName = "Submitter",
                }, "password1");
            }

            var suserId = userManager.FindByEmail("user2@coderfoundry.com").Id;
            userManager.AddToRole(suserId, "Submitter");
            ///////////////////////////////////////////

            /* Seeding the Priority table with lookup values */
            if (!context.Priorities.Any(p => p.Name == "High"))
            {
                Models.Priority priority = new Models.Priority();
                priority.Name = "High";
                context.Priorities.Add(priority);
            }

            if (!context.Priorities.Any(p => p.Name == "Medium"))
            {
                Models.Priority priority = new Models.Priority();
                priority.Name = "Medium";
                context.Priorities.Add(priority);
            }

            if (!context.Priorities.Any(p => p.Name == "Low"))
            {
                Models.Priority priority = new Models.Priority();
                priority.Name = "Low";
                context.Priorities.Add(priority);
            }

            /* Seeding the Status table with lookup values */
            if (!context.Statuses.Any(s => s.Name == "Open"))
            {
                Models.Status status = new Models.Status();
                status.Name = "Open";
                context.Statuses.Add(status);
            }

            if (!context.Statuses.Any(s => s.Name == "Pending"))
            {
                Models.Status status = new Models.Status();
                status.Name = "Pending";
                context.Statuses.Add(status);
            }

            if (!context.Statuses.Any(s => s.Name == "Resolved"))
            {
                Models.Status status = new Models.Status();
                status.Name = "Resolved";
                context.Statuses.Add(status);
            }

            if (!context.Statuses.Any(s => s.Name == "Closed"))
            {
                Models.Status status = new Models.Status();
                status.Name = "Closed";
                context.Statuses.Add(status);
            }

            /* Seeding the Type table with lookup values */
            if (!context.Types.Any(t => t.Name == "Bug"))
            {
                Models.Type type = new Models.Type();
                type.Name = "Bug";
                context.Types.Add(type);
            }

            if (!context.Types.Any(t => t.Name == "Feature Request"))
            {
                Models.Type type = new Models.Type();
                type.Name = "Feature Request";
                context.Types.Add(type);
            }

            if (!context.Types.Any(t => t.Name == "Documentation"))
            {
                Models.Type type = new Models.Type();
                type.Name = "Documentation";
                context.Types.Add(type);
            }



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
