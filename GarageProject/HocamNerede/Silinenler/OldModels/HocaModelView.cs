using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class HocaModelView
	{
		public int Id { get; set; }
		[Required]
		public string HocaName { get; set; }
		[Required]
		public string HocaSurname { get; set; }
		[Required]
		public string HocaMail { get; set; }



	}
}