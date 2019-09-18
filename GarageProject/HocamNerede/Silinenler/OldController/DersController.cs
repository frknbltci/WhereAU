using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede.Controllers
{
	public class DersController : Controller
	{
		public ActionResult Dersler()
		{
			WhereAUEntities db = new WhereAUEntities();
			tblDersModel model = new tblDersModel();
			List<tblBolumler> BolumList = db.tblBolumler.OrderBy(x => x.Name).ToList();

			model.BolumList = (from s in BolumList
							   select new SelectListItem
							   {

								   Text = s.Name,
								   Value = s.Id.ToString(),
								   


							   }).ToList();
			List<tblDersler> fakulteDersleri = new List<tblDersler>();

			return View(model);
		}
		[HttpPost]
		public ActionResult Dersler(tblDersModel model)
		{



			WhereAUEntities db = new WhereAUEntities();
			//model.BolumId= Bolum Id hep sıfır geliyor neden ? 


			model.BolumList = db.tblBolumler.OrderBy(x => x.Name).Select(x =>
			new SelectListItem() {
				Text = x.Name,
				Value = x.Id.ToString(),
				Selected = model.BolumId == x.Id ? true : false,

			}).ToList();

			model.DersList = db.poolBolumDers.Where(x => x.FpoolfakultebolumID == model.BolumId).OrderBy(x => x.tblDersler.Name)
			   .Select(x => new SelectListItem()
			   {
				   Text = x.tblDersler.Name,
				   Value = x.tblDersler.Id.ToString(),
			   }).ToList();



			return View(model);
		}
	}
}