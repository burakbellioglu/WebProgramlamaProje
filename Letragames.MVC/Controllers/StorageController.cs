using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Letragames.MVC.Entity;


namespace Letragames.MVC.Controllers
{
    public class StorageController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult Index()
        {
            return View(db.Storages.ToList());
        }
    }
}