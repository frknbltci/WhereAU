using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class DersModel: poolBolumDers
	{
		public string DersName { get; set; }
		public string HocaName { get; set; }
		public string DersSaatleri { get; set; }
	

	}
	public class DersViewModel
	{
		public List<DersModel> Dersleri { get; set; }
		public int DersId { get; set; }

		public List<SelectListItem> Dersler { get; set; }

		public string BolumName { get; set; }
		public int BolumId { get; set; }

		public int HocaId { get; set; }
		public List<SelectListItem> Hocalar { get; set; }

		public string VideoUrl { get; set; }
		public string Sınıf { get; set; }

		



	}
}