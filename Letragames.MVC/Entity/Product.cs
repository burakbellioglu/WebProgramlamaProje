using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Letragames.MVC.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün İsmi")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Görsel ismi")]
        public string Image { get; set; }
        [DisplayName("Stok Miktari")]
        public double Stock { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Vitrin")]
        public bool isHome { get; set; }

        public Category Category { get; set; }




    }
}