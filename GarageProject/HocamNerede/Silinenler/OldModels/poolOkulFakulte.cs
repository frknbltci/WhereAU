using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class OkulViewModel
	{	
		public OkulViewModel()
		{

		}
		public string OkulName { get; set; }

	
		[Display(Name = "Fakülteler")]
		[Required (ErrorMessage ="Lütfen seçim yapın.")]
		public int FakulteId { get; set; }

		public int OkulId { get; set; }

		public  List<SelectListItem> FakultelerList;

		
	
		public IEnumerable<SelectListItem> FakultelerItems
		{
			get { return FakultelerList.AsEnumerable(); }
		}

		public List<FakultelerViewModel> OkulFakulteleri { get; set; }

	}

	public class FakultelerViewModel
	{
		public string Name { get; set; }
		public int Id { get; set; }
	}

 
	
}