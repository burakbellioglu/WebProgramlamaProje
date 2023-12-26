using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Letragames.MVC.Entity
{
    public class Category
    {

        public int Id { get; set; }
        [DisplayName("Kategori İsmi")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }


    }
}