using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Letragames.MVC.Entity;

namespace Letragames.MVC.Kaynakca
{
    public class AboutInitilaizer: CreateDatabaseIfNotExists<DataContext>
    {

        protected override void Seed(DataContext context)
        {

            var kaynaklar = new List<Kaynak>()
            {
                new Kaynak(){Name="Silver Way",Link="https://store.steampowered.com/?l=turkish"}
               
            };

            foreach (var kaynak in kaynaklar)
            {
                context.Kaynaklar.Add(kaynak);
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}