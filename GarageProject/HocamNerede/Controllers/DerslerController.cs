using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HocamNerede;

namespace HocamNerede.Controllers
{
    public class DerslerController : Controller
    {
        private WhereAUEntities db = new WhereAUEntities();

        // GET: Dersler
        public ActionResult Index()
        {
            return View(db.tblDersler.ToList());
        }

        // GET: Dersler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDersler tblDersler = db.tblDersler.Find(id);
            if (tblDersler == null)
            {
                return HttpNotFound();
            }
            return View(tblDersler);
        }

        // GET: Dersler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dersler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tblDersler tblDersler)
        {
            if (ModelState.IsValid)
            {
                db.tblDersler.Add(tblDersler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDersler);
        }

        // GET: Dersler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDersler tblDersler = db.tblDersler.Find(id);
            if (tblDersler == null)
            {
                return HttpNotFound();
            }
            return View(tblDersler);
        }

        // POST: Dersler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tblDersler tblDersler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDersler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDersler);
        }

        // GET: Dersler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDersler tblDersler = db.tblDersler.Find(id);
            if (tblDersler == null)
            {
                return HttpNotFound();
            }
            return View(tblDersler);
        }

        // POST: Dersler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDersler tblDersler = db.tblDersler.Find(id);
            db.tblDersler.Remove(tblDersler);
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
