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
    public class HocalarController : Controller
    {
        private WhereAUEntities db = new WhereAUEntities();

        // GET: Hocalar
        public ActionResult Index()
        {
            return View(db.tblHocalar.ToList());
        }

        // GET: Hocalar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocalar tblHocalar = db.tblHocalar.Find(id);
            if (tblHocalar == null)
            {
                return HttpNotFound();
            }
            return View(tblHocalar);
        }

        // GET: Hocalar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hocalar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HocaID,HocaName,HocaSurname,HocaMail")] tblHocalar tblHocalar)
        {
            if (ModelState.IsValid)
            {
                db.tblHocalar.Add(tblHocalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblHocalar);
        }

        // GET: Hocalar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocalar tblHocalar = db.tblHocalar.Find(id);
            if (tblHocalar == null)
            {
                return HttpNotFound();
            }
            return View(tblHocalar);
        }

        // POST: Hocalar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HocaID,HocaName,HocaSurname,HocaMail")] tblHocalar tblHocalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblHocalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblHocalar);
        }

        // GET: Hocalar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocalar tblHocalar = db.tblHocalar.Find(id);
            if (tblHocalar == null)
            {
                return HttpNotFound();
            }
            return View(tblHocalar);
        }

        // POST: Hocalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblHocalar tblHocalar = db.tblHocalar.Find(id);
            db.tblHocalar.Remove(tblHocalar);
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
