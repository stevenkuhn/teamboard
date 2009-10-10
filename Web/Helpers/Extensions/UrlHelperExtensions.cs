using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamBoard.Infrastructure;

namespace TeamBoard.Web.Helpers
{
	public static class UrlHelperExtensions
	{
		public static string Image(this UrlHelper helper, string fileName)
		{
			return helper.Content("~/Content/Images/{0}".FormatWith(fileName));
		}

		public static string Stylesheet(this UrlHelper helper, string fileName)
		{
			return helper.Content("~/Content/{0}".FormatWith(fileName));
		}

		public static string Javascript(this UrlHelper helper, string fileName)
		{
			return helper.Content("~/Scripts/{0}".FormatWith(fileName));
		}

		public static string JQueryUI(this UrlHelper helper, string themeName)
		{
			return helper.Stylesheet("jquery-ui/{0}/jquery-ui.css".FormatWith(themeName));
		}
	}
}
