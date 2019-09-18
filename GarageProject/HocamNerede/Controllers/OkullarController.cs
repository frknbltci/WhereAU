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
			var r = new UniversityViewModel();

			r.Universiteler = db.tblOkullar.Select(x => new UniversityModel() { UniName = x.OkulName, Id = x.Id }).ToList();

			return View(r);
        }

        // GET: Okullar/Details/5
        public ActionResult UniDetaylar(int? id)
        {
			var r = new FakulteViewModel();


			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tblOkullar okul = db.tblOkullar.Find(id);
			if (okul == null)
			{
				return HttpNotFound();
			}

			r.Fakulteler = db.tblFakulteler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			r.Fakuteleri = okul.poolOkulFakulte.Select(x => new FakulteModel() { Name = x.tblFakulteler.Name, Id = x.Id }).ToList();
			r.UniName = okul.OkulName;
			r.UniId = okul.Id;

			return View(r);
		}

		[HttpPost]
		public ActionResult UniDetaylar(FakulteViewModel model)
		{

			db.poolOkulFakulte.Add(new poolOkulFakulte() { FFakulteID = model.FakulteId, FOkulID = model.UniId });
			db.SaveChanges();
			return RedirectToAction("UniDetaylar", new { id = model.UniId });

		}


		[HttpPost]
		public ActionResult FakulteDetay(BolumViewModel model) {

			db.poolFakulteBolum.Add(new poolFakulteBolum() { FBolumID = model.BolumId, FpoolokulfalulteID = model.FakulteId });
			db.SaveChanges();

			return RedirectToAction("FakulteDetay", new { id = model.FakulteId });
		}


		public ActionResult FakulteDetay(int id)
		{
			var model = new BolumViewModel();
			var fakultepool = db.poolOkulFakulte.Find(id);

			model.FakulteName = fakultepool.tblFakulteler.Name;
			model.FakulteId = id;
			model.Bolumler = db.tblBolumler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			model.Bolumleri = fakultepool.poolFakulteBolum.Select(x => new BolumModel() { Id = x.Id, Name = x.tblBolumler.Name }).ToList();

			return View(model);
		}

		public ActionResult DersDetay(int id)
		{

			var model = new DersViewModel();

			var derspool = db.poolFakulteBolum.Find(id);
			model.Dersler = db.tblDersler.Select(x => new SelectListItem()
			{
				Text = x.Name,
				Value = x.Id.ToString(),
				Selected=true
			}).ToList();

			model.BolumName = derspool.tblBolumler.Name;
			model.BolumId = id;

			model.Hocalar = db.tblHocalar.Select(x => new SelectListItem()
			{

				Text = x.HocaName + x.HocaSurname,
				Value = x.HocaID.ToString()

			}).ToList();

			model.Dersleri = derspool.poolBolumDers.Select(x => new DersModel()
			{
				Id = x.Id,
				DersName = x.tblDersler.Name,
				HocaName = $"{x.tblHocalar.HocaName} {x.tblHocalar.HocaSurname}",
				Sınıf = x.Sınıf
				
			//	DersSaatleri = new DersSaatModel().GetDersSaat(x.tblHvz.ToList())
			    
				

			}).ToList();
			
			return View(model); 

		}

		[HttpPost]
		public ActionResult DersDetay(DersViewModel model)
		{
			db.poolBolumDers.Add(new poolBolumDers()
			{

				FHocaID = model.HocaId,
				FDersID = model.DersId,
				Sınıf = model.Sınıf,
				VideoUrl =model.VideoUrl,
				FpoolfakultebolumID = model.BolumId



			});
			db.SaveChanges();
			return RedirectToAction("DersDetay", new { ıd = model.BolumId });

		}

		public ActionResult DersinDetayı(int id)
		{
			var poolDers = db.poolBolumDers.Find(id);

			var model = new DersinDetayViewModel();
			model.Id = poolDers.Id;
			model.DersDayList = poolDers.tblHvz.Select(x => new DersinDetayıModel() { BaslangicSaati = x.BaslangicSaati, BitisSaati = x.BitisSaati, FGunID = x.FGunID, ID = x.ID, FpoolBolumdersID = x.FpoolBolumdersID }).ToList();
			model.DersName = poolDers.tblDersler.Name;

			

		
			return View(model);
		}
	
		
		[HttpPost]
		public ActionResult DersinDetayı(DersinDetayViewModel model)
		{
			db.tblHvz.Add(new tblHvz() { BaslangicSaati = TimeSpan.Parse(model.Begin), BitisSaati = TimeSpan.Parse(model.End), FGunID = model.DayId, FpoolBolumdersID = model.Id });
			db.SaveChanges();

			return RedirectToAction("DersinDetayı",new {id=model.Id });
		}
		//SORUNLU PARAMETRE GÖNDEREMİYORUM
		public ActionResult silFakulte(int id)
		{
			var r = new FakulteViewModel();
			var fakulte = db.poolOkulFakulte.Find(id);
			tblOkullar okul = db.tblOkullar.Find(fakulte.tblOkullar.Id);
			db.poolOkulFakulte.Remove(fakulte);
			db.SaveChanges();


			r.UniId = fakulte.FOkulID; //Okulu Biliyor
			r.Fakulteler = db.tblFakulteler.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
			r.Fakuteleri = okul.poolOkulFakulte.Select(x => new FakulteModel() { Name = x.tblFakulteler.Name, Id = x.Id }).ToList();
		
			r.UniName = okul.OkulName;
		

			return View("UniDetaylar",r.UniId); //Okulu gönderiyor ama UniDetaylar başka Id alıyor
		}

		public ActionResult SilBolum(int id)
		{
			
			
			var a = db.poolFakulteBolum.Find(id);
			var i = a.poolOkulFakulte.Id;

			db.poolFakulteBolum.Remove(a);
			db.SaveChanges();

			return RedirectToAction("FakulteDetay",new { id=i });
		}
		

		public ActionResult SilDers(int  id)
		{
			var a=db.poolBolumDers.Find(id);
			var i = a.poolFakulteBolum.Id;
			db.poolBolumDers.Remove(a);
			db.SaveChanges();


			return RedirectToAction("DersDetay", new { id = i });
		}
		public ActionResult silDersinZamani(int id)
		{
			var a = db.tblHvz.Find(id);
			var model = new DersinDetayViewModel();
			//tamamlanacak

			return RedirectToAction("DersinDetayı",new {id=model.Id });
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
/*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
