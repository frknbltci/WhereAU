using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HocamNerede
{
	public class DersSaatModel
	{
		public string DersSaati { get; set; }
		public string DersGunu { get; set; }

		public DersSaatModel()
		{

		}

		public string GetDersSaat(List<tblHvz> list)
		{

			var s = new StringBuilder();
			foreach (var i in list)
			{
				s.Append($"Saatler:{i.BaslangicSaati }- {i.BitisSaati} Günü: {Enum.GetName(typeof(DayOfWeek), i.FGunID)} <br />");
				
			}
			return s.ToString();

		}
	}
}