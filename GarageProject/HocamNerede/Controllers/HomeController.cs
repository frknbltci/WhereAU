
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace HocamNerede.Controllers
{
	public class HomeController : Controller
	{

		WhereAUEntities db = new WhereAUEntities();
		// GET: Home
		/*	public ActionResult Index()
			{
				var db = new WhereAUEntities();
				UniversityViewModel model = new UniversityViewModel();


				List<tblOkullar> okulList = db.tblOkullar.OrderBy(x => x.OkulName).ToList();
				List<poolOkulFakulte> okulunFakulteList = db.poolOkulFakulte.OrderBy(f => f.FFakulteID).ToList();
				//		List<poolFakulteBolum> fakulteninBolumList = db.poolFakulteBolum.OrderBy(k => k.FBolumID).ToList();
				List<tblFakulteler> fakulteList = db.tblFakulteler.OrderBy(k => k.Id).ToList();

				model.UniversiteList = (from s in okulList
										select new SelectListItem
										{
											Text = s.OkulName,
											Value = s.Id.ToString()
										}).ToList();
				model.UniversiteList.Insert(0, new SelectListItem { Value = " ", Text = "Seçiniz", Selected = true });


				return View(model);

			}
			*/


		public ActionResult Anasayfa()
		{
			WhereAUEntities db = new WhereAUEntities();

			var model = new HomePageViewModel();

			
			model.Universiteler = db.tblOkullar.Select(x => new SelectListItem() { Text = x.OkulName, Value = x.Id.ToString() }).ToList();

			return View(model);
		}
	
		//Dropdown'a fakultenin basıldığı yer
		[HttpPost]
		public ActionResult Anasayfa(HomePageViewModel model)
		{
			WhereAUEntities db = new WhereAUEntities();
			var i = db.poolOkulFakulte.FirstOrDefault(); //Gereklimim kontro et ?
			
			model.Fakulteleri = db.poolOkulFakulte.OrderBy(x => x.tblFakulteler.Name).Where(x => x.FOkulID == model.SelectedUniId).Select(x => new SelectListItem()
			{
				Text = x.tblFakulteler.Name,
				Value = x.FFakulteID.ToString()

			}).ToList();

			

			return PartialView("OkulFakulteleriPartial", model);
		}

		[HttpPost]
		public ActionResult Fakulte(HomePageViewModel model)
		{
			var i = db.poolFakulteBolum.FirstOrDefault();
			model.Bolumleri = db.poolFakulteBolum.OrderBy(x => x.tblBolumler.Name).Where(x => x.FpoolokulfalulteID == model.FakulteId)
				.Select(x => new SelectListItem
				{

					Value = x.tblBolumler.Id.ToString(),
					Text = x.tblBolumler.Name


				}).ToList();


			return PartialView("FakulteBolumleriPartial", model);
		}

		/*	[HttpPost]
			public JsonResult FakulteList(String id)
			{

				var _id = int.Parse(id);
				WhereAUEntities db = new WhereAUEntities();
				//List<tblFakulteler> fakulteList = db.tblFakulteler.Where(f=>f.==id).OrderBy(k => k.Name).ToList();
				var itemList = db.poolOkulFakulte.Where(f => f.FOkulID == _id).OrderBy(f => f.tblFakulteler.Name)
					.Select(x => new SelectListItem()
					{
						Text = x.tblFakulteler.Name,
						Value = x.FFakulteID.ToString()

					}).ToList();



				return Json(itemList, JsonRequestBehavior.AllowGet);
			}



			[HttpGet]
			public ActionResult Edit()
			{
				return View("Edit");
			}

			[HttpPost]
			public ActionResult Edit(tblHocalar std)
			{
				var child = new tblHocalar
				{
					HocaName = std.HocaName,
					HocaSurname = std.HocaMail,
					HocaMail = std.HocaMail
				};

				return RedirectToAction("Index");
			}*/
	}
}