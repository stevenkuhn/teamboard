using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamBoard.Services;

namespace TeamBoard.Web.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Mockup()
		{
			//var service = new WorkItemService();
			//var items = service.GetWorkItems("TeamBoard");

			return View();
		}
	}
}
