using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Letragames.MVC.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Letragames.MVC.Identity
{
    public class IdentityInitilaizer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        
        protected override void Seed(IdentityDataContext context)
        {


            //Role

            if(!context.Roles.Any(i => i.Name == "Admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "Admin", Description = "Yönetici rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "User"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "User", Description = "Müşteri rolü" };
                manager.Create(role);
            }

            //User
            if (!context.Users.Any(i => i.UserName == "burak.bel19@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() {Name="Burak",Surname="Bellioglu",Email="burak.bel19@gmail.com",UserName= "burak.bel19@gmail.com" };
                manager.Create(user,"1234567");

                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "User");
            }

            context.SaveChanges();
            base.Seed(context); 
        }

    }
}