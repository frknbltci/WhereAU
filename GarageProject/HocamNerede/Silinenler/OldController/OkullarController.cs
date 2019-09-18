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
    public class OkullarController : Controller
    {
        private WhereAUEntities db = new WhereAUEntities();

        // GET: Okullar
        public ActionResult Index()
        {
            return View(db.tblOkullar.ToList());
        }

        // GET: Okullar/Details/5
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

			r.FakultelerList = db.tblFakulteler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			r.OkulFakulteleri = okul.poolOkulFakulte.ToList().Select(x => new FakultelerViewModel() { Name = x.tblFakulteler.Name, Id = x.Id }).ToList();
			r.OkulName = okul.OkulName;
			r.OkulId = okul.Id;

			return View(r);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(OkulViewModel model)
		{
			var r = new OkulViewModel();

			db.poolOkulFakulte.Add(new poolOkulFakulte() { FFakulteID = model.FakulteId, FOkulID = model.OkulId });
			db.SaveChanges();

			tblOkullar okul = db.tblOkullar.Find(model.OkulId);
			if (okul == null)
			{
				return HttpNotFound();
			}

			r.FakultelerList = db.tblFakulteler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			r.OkulFakulteleri = db.poolOkulFakulte.Where(x => x.FOkulID == model.OkulId).Select(x => new FakultelerViewModel() { Name = x.tblFakulteler.Name, Id = x.Id }).ToList();
			//Burada Id doldurup viewde @html.actionlink ile o ıd yi vermem gerek
			r.OkulName = okul.OkulName;
			r.OkulId = okul.Id;


			return View(r);

		}
		//GET
		public ActionResult silFakulte(int id)
		{
			var r = new OkulViewModel();
			var fakulte = db.poolOkulFakulte.Find(id);
			tblOkullar okul = db.tblOkullar.Find(fakulte.tblOkullar.Id);
			db.poolOkulFakulte.Remove(fakulte);
			db.SaveChanges();


			r.OkulId = fakulte.tblOkullar.Id;
			r.FakultelerList = db.tblFakulteler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			r.OkulFakulteleri = okul.poolOkulFakulte.Select(x => new FakultelerViewModel() { Name = x.tblFakulteler.Name, Id = x.Id }).ToList();
			//Burada Id doldurup viewde @html.actionlink ile o ıd yi vermem gerek
			r.OkulName = okul.OkulName;


			return View("Details",r);
		}

		
		// GET: Okullar/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Okullar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OkulName")] tblOkullar tblOkullar)
        {
            if (ModelState.IsValid)
            {
                db.tblOkullar.Add(tblOkullar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOkullar);
        }

        // GET: Okullar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOkullar tblOkullar = db.tblOkullar.Find(id);
            if (tblOkullar == null)
            {
                return HttpNotFound();
            }
            return View(tblOkullar);
        }

        // POST: Okullar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OkulName")] tblOkullar tblOkullar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOkullar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOkullar);
        }

        // GET: Okullar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOkullar tblOkullar = db.tblOkullar.Find(id);
            if (tblOkullar == null)
            {
                return HttpNotFound();
            }
            return View(tblOkullar);
        }

        // POST: Okullar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOkullar tblOkullar = db.tblOkullar.Find(id);
            db.tblOkullar.Remove(tblOkullar);
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
