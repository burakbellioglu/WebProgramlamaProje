using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Letragames.MVC.Entity
{
    public class DataInitiliazer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Mobil", Description = "Mobil uyumlu dijital oyunlar"},
                new Category(){Name="Bilgisayar", Description = "Bilgisayar windows işletim sistemi uyumlu dijital oyunlar"},
                new Category(){Name="Konsol", Description = "Konsol PS4 / PS5 uyumlu dijital oyunlar"},
                new Category(){Name="VR", Description = "VR Windows uyumlu dijital oyunlar"},
                new Category(){Name="Oyuncak", Description = "Sağlığa zararsız el yapımı oyuncaklar"},
                new Category(){Name="Masa oyunu", Description = "Birden fazla kişi ile oynanabilecek oyunlar"},
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name="Silver Way",Description="Ortaçağ temalı 2D platformer dövüş oyunu",Price=10,Stock=1000,CategoryId=1, isHome=true, Image="1.jpg"},
                new Product(){Name="Trader Sim",Description="2D İzometrik ticaret simülasyonu oyunu",Price=15,Stock=1000,CategoryId=1, isHome=true, Image="2.jpg"},
                new Product(){Name="Chibi Fighter",Description="3D hyper casual koşu oyunu",Price=10,Stock=1000,CategoryId=1, Image="3.jpg"},
                new Product(){Name="LiChess",Description="Sıra tabanlı santranç oyunu",Price=15,Stock=1000,CategoryId=1, Image="4.jpg"},

                new Product(){Name="GTA 5",Description="Ortaçağ temalı 2D platformer dövüş oyunu",Price=10,Stock=1000,CategoryId=2,isHome=true, Image="5.jpg"},
                new Product(){Name="Among Us",Description="2D İzometrik ticaret simülasyonu oyunu",Price=15,Stock=1000,CategoryId=2, Image="6.jpg"},
                new Product(){Name="Battlefield",Description="3D hyper casual koşu oyunu",Price=10,Stock=1000,CategoryId=2, Image="7.jpg"},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}