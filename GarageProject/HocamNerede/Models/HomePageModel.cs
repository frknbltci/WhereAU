using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class HomePageModel
	{
		public int Id { get; set; }
		public string OkulName { get; set; }

	}

	public class HomePageViewModel
	{
		
		public int SelectedUniId { get; set; }
		public List<SelectListItem> Universiteler { get; set; }


		public List<SelectListItem> Fakulteleri { get; set; }
		public int FakulteId { get; set; }

		public List<SelectListItem> Bolumleri { get; set; }
		public int BolumId { get; set; }

	}
}