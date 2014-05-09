using MvcAppLS.Models;
using System.Data.Entity.Migrations;


namespace MvcAppLS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();

            context.Posts.AddOrUpdate(p => p.Title,
               new Post
               {
                   Title = "Post1",
                   Author = "Lene S�rensen",
                   Category = "News",
                   Description = "Dette er post1",
                   PostedDate = DateTime.Today
               },
                new Post
                {
                    Title = "Post2",
                    Author = "Hans Hansen",
                    Category = "News",
                    Description = "Dette er post2",
                    PostedDate = DateTime.Today
                },
                new Post
                {
                    Title = "Post3",
                    Author = "Ole Olsen",
                    Category = "News",
                    Description = "Dette er post3",
                    PostedDate = DateTime.Today
                }
                );
       
        }


        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;


            var newUser = new ApplicationUser()
            {
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@x.dk"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
