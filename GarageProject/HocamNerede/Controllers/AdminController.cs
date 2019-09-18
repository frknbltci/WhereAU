using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace HocamNerede.Controllers
{
	public class AdminController : Controller
	{
        WhereAUEntities db = new WhereAUEntities();
		// GET: Admin
		public ActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Login(LoginModel model)
		{
			
			if (!ModelState.IsValid)
			{
				return View("index",model);
			}


			var db = new WhereAUEntities();
			var user =db.tblAdminLogin.FirstOrDefault(x => x.kullaniciAdi == model.UserName && x.password == model.Password);
			if (user!=null)
			{
				return RedirectToAction("Index", "Home");

			}


			return View("index");
		}
	} 
}