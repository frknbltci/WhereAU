using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocamNerede.Models
{
	public class tblHvzModelView
	{
		public int HocaId { get; set; }
		public DateTime BaslangicSaati { get; set; }
		public DateTime BitisSaati { get; set; }
		public int FDersId { get; set; }
		public int FGunId { get; set; }
		public int FSınıfId { get; set; }

		public string HocaName { get; set; }
		public string  DersName { get; set; }
		public string GunName { get; set; }
		public string SınıfName { get; set; }


	}
}