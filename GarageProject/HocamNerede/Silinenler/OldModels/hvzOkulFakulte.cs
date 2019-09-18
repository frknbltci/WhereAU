using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class hvzOkulFakulteViewModel
	{
		public hvzOkulFakulteViewModel()
		{
			this.FakulteList = new List<SelectListItem>();
			FakulteList.Add(new SelectListItem { Text = "Seçiniz", Value = " " });

		}
		

		public int UniversiteId { get; set; }

		public int FakulteId { get; set; }

		public int BolumId { get; set; }


		public List<SelectListItem> UniversiteList { get; set; }

		public List<SelectListItem> FakulteList { get; set; }

		public List<SelectListItem> BolumList { get; set; }
	}


}