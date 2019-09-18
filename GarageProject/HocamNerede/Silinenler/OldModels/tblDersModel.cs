using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class tblDersModel
	{
		public tblDersModel()
		{
			
		}
		public int BolumId { get; set; }
		public int DersId { get; set; }

	//	public string BolumName { get; set; }
	//	public string DersName { get; set; }

		public List<SelectListItem> BolumList { get; set; }
		public List<SelectListItem> DersList { get; set; }

	}
}