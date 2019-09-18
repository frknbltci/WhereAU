using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocamNerede
{
	public static class MyExtensions
	{
		public static MvcHtmlString Button(this HtmlHelper helper, string id, string typ, string text)
		{
			string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2} </button>", id, typ, text);

			return MvcHtmlString.Create(html);
		}

		public static MvcHtmlString Video(this HtmlHelper helper, string url)
		{
			string html = $"<video width='200' height='170' controls> <source src ='/videos/{url}' type = 'video/mp4' > </ video >";

			return MvcHtmlString.Create(html);
		}
		
		
	}
}