using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class UniversityModel
	{
		
		public int Id { get; set; }
		public string UniName  { get; set; }
	
		
	}


	public class UniversityViewModel
	{
		public List<UniversityModel> Universiteler { get; set; }
		public List<SelectListItem> UniversiteList{ get; set; }
	}

}