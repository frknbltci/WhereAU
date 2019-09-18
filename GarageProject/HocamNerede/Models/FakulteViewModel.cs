using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class FakulteModel
	{
		public int Id { get; set; }

		public string Name { get; set; }


	}

	public class FakulteViewModel
	{
		public List<FakulteModel> Fakuteleri { get; set; }

		public int UniId { get; set; }
		public  string UniName { get; set; }

		public List<SelectListItem> Fakulteler { get; set; }
		public int FakulteId { get; set; }

	}

}