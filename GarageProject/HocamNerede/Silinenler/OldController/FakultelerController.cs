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

        // GET: Fakulteler
        public ActionResult Index()
        {
            return View(db.tblFakulteler.ToList());
        }

        // GET: Fakulteler/Details/5
        public ActionResult Details(int? id)
        {
			var r = new OkulViewModel();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOkullar okul = db.tblOkullar.Find(id);
            if (okul == null)
            {
                return HttpNotFound();
            }

			r.FakultelerList = okul.poolOkulFakulte.Select(x => new SelectListItem() { Text = x.tblFakulteler.Name, Value = x.tblFakulteler.Id.ToString() }).ToList();
				


            return View(r);
        }
		// Benim oluşturduğum
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(OkulViewModel model)
		{
			
			


			return View();

		}

        // GET: Fakulteler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakulteler/Create
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

        // GET: Fakulteler/Edit/5
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

        // POST: Fakulteler/Edit/5
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
               // return RedirectToAction("Index");
				ViewBag.Mesaj = "İşembaşarılı";
				
				return View(tblFakulteler);
			}
            return View(tblFakulteler);
        }

        // GET: Fakulteler/Delete/5
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

        // POST: Fakulteler/Delete/5
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
