using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Letragames.MVC.Identity;
using System.Data.Entity;

namespace Letragames.MVC.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        static IdentityDataContext()
        {
            Database.SetInitializer(new IdentityInitilaizer());
        }

        public IdentityDataContext() : base("dataConnection")
        {
          
        }


    }
}