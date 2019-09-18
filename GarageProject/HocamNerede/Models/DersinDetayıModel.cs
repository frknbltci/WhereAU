using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public class DersinDetayıModel : tblHvz
	{
		public string GunName {
			get { return Enum.GetName(typeof(DayOfWeek), this.FGunID); }
				
				}
	}

    public class DersinDetayViewModel
	{
		public DersinDetayViewModel()
		{
			this.DayList = new List<SelectListItem>()
			{
				new SelectListItem(){ Text="Pazartesi", Value="1"},
				new SelectListItem(){ Text="Salı", Value="2"},
				new SelectListItem(){ Text="Çarşamba", Value="3"},
				new SelectListItem(){ Text="Perşembe", Value="4"},
				new SelectListItem(){ Text="Cuma", Value="5"},
				new SelectListItem(){ Text="Cumartesi", Value="6"},
				new SelectListItem(){ Text="Pazar", Value="7"}

			};
		}


		public string Begin { get; set; }
		public string End { get; set; }

		public List<SelectListItem> DayList  { get; set; }
		public int DayId { get; set; }

		public int Id { get; set; }
		public string DersName { get; set; }

		public List<DersinDetayıModel> DersDayList { get; set; }


	}
}