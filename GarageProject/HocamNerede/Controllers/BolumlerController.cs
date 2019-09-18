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
    public class BolumlerController : Controller
    {
        private WhereAUEntities db = new WhereAUEntities();

        // GET: Bolumler
        public ActionResult Index()
        {
            return View(db.tblBolumler.ToList());
        }

        // GET: Bolumler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolumler tblBolumler = db.tblBolumler.Find(id);
            if (tblBolumler == null)
            {
                return HttpNotFound();
            }
            return View(tblBolumler);
        }

        // GET: Bolumler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bolumler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tblBolumler tblBolumler)
        {
            if (ModelState.IsValid)
            {
                db.tblBolumler.Add(tblBolumler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblBolumler);
        }

        // GET: Bolumler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolumler tblBolumler = db.tblBolumler.Find(id);
            if (tblBolumler == null)
            {
                return HttpNotFound();
            }
            return View(tblBolumler);
        }

        // POST: Bolumler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tblBolumler tblBolumler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBolumler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblBolumler);
        }

        // GET: Bolumler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBolumler tblBolumler = db.tblBolumler.Find(id);
            if (tblBolumler == null)
            {
                return HttpNotFound();
            }
            return View(tblBolumler);
        }

        // POST: Bolumler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBolumler tblBolumler = db.tblBolumler.Find(id);
            db.tblBolumler.Remove(tblBolumler);
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
