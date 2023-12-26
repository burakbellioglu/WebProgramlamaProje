using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Letragames.MVC.Entity;
using Letragames.MVC.Models;

namespace Letragames.MVC.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        public ActionResult Index()
        {
            return View(_context.Products.Where(i => i.isHome).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }

        public ActionResult List(int? id)
        {
            if (id != null)
            {
                return View(_context.Products.Where(i => i.CategoryId == id).ToList());
            }
            else
                return View(_context.Products.ToList());

        }

        public PartialViewResult Kategoriler()
        {
            return PartialView(_context.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}