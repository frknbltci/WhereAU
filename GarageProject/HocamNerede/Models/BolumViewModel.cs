using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class BolumModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

	}

	public class BolumViewModel
	{
		public List<BolumModel> Bolumleri { get; set; }
		public List<SelectListItem> Bolumler { get; set; }
		public string FakulteName { get; set; }
		public int FakulteId { get; set; }
		public int BolumId { get; set; }

	}
}