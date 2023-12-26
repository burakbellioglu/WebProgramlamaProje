using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Letragames.MVC.Identity;



namespace Letragames.MVC.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitiliazer());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Kaynak> Kaynaklar { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }


    }
    
       


       
   
}