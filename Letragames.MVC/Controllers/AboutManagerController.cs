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
    [Authorize(Roles = "Admin")]
    public class AboutManagerController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AboutManager
        public ActionResult Index()
        {
            return View(db.Kaynaklar.ToList());
        }

        // GET: AboutManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynak kaynak = db.Kaynaklar.Find(id);
            if (kaynak == null)
            {
                return HttpNotFound();
            }
            return View(kaynak);
        }

        // GET: AboutManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Link")] Kaynak kaynak)
        {
            if (ModelState.IsValid)
            {
                db.Kaynaklar.Add(kaynak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaynak);
        }

        // GET: AboutManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynak kaynak = db.Kaynaklar.Find(id);
            if (kaynak == null)
            {
                return HttpNotFound();
            }
            return View(kaynak);
        }

        // POST: AboutManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Link")] Kaynak kaynak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaynak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaynak);
        }

        // GET: AboutManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynak kaynak = db.Kaynaklar.Find(id);
            if (kaynak == null)
            {
                return HttpNotFound();
            }
            return View(kaynak);
        }

        // POST: AboutManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kaynak kaynak = db.Kaynaklar.Find(id);
            db.Kaynaklar.Remove(kaynak);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
