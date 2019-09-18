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
    public class FakultelerController : Controller
    {
        private WhereAUEntities db = new WhereAUEntities();

        // GET: tblFakultelers
        public ActionResult Index()
        {
            return View(db.tblFakulteler.ToList());
        }

        // GET: tblFakultelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFakulteler tblFakulteler = db.tblFakulteler.Find(id);
            if (tblFakulteler == null)
            {
                return HttpNotFound();
            }
            return View(tblFakulteler);
        }

        // GET: tblFakultelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblFakultelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] tblFakulteler tblFakulteler)
        {
            if (ModelState.IsValid)
            {
                db.tblFakulteler.Add(tblFakulteler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFakulteler);
        }

        // GET: tblFakultelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFakulteler tblFakulteler = db.tblFakulteler.Find(id);
            if (tblFakulteler == null)
            {
                return HttpNotFound();
            }
            return View(tblFakulteler);
        }

        // POST: tblFakultelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] tblFakulteler tblFakulteler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFakulteler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFakulteler);
        }

        // GET: tblFakultelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFakulteler tblFakulteler = db.tblFakulteler.Find(id);
            if (tblFakulteler == null)
            {
                return HttpNotFound();
            }
            return View(tblFakulteler);
        }

        // POST: tblFakultelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFakulteler tblFakulteler = db.tblFakulteler.Find(id);
            db.tblFakulteler.Remove(tblFakulteler);
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
