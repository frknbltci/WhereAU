using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HocamNerede
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı adı  giriniz.")]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		

	}
}