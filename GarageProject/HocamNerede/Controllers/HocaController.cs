using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede.Controllers
{

	public class HocaController : Controller
	{
		WhereAUEntities db = new WhereAUEntities();
		// GET: Hoca
		public ActionResult Index()
		{
           
			return View(db.tblHocalar);

			
		}


		public ActionResult Olustur()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Olustur(tblHocalar model)
		{
			WhereAUEntities db = new WhereAUEntities();
			db.tblHocalar.Add(model);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			
			tblHocalar hoca = db.tblHocalar.Find(id);
			db.tblHocalar.Remove(hoca);
			db.SaveChanges();

			return RedirectToAction("Index");

		}

		
		
	}

	// hoca arat
}