using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Letragames.MVC.Entity
{
    public class DataInitiliazer:DropCreateDatabaseIfModelChanges<DataContext> 
    {
        public DataInitiliazer() : base("dataConnection");
	{

	}


    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }
}
}