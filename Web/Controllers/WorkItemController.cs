using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TeamBoard.Model;
using TeamBoard.Services;

namespace TeamBoard.Web.Controllers
{
	public class WorkItemController : Controller
	{
		public WorkItemController(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; private set; }

		private IEnumerable<WorkItem> GetWorkItems()
		{
			var list = new List<WorkItem>();
			list.Add(new WorkItem()
			{
				Id = "1000", 
				Summary = "Create database", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.",
				Priority = 3,
				ProjectName = "TeamBuild"
			});
			list.Add(new WorkItem()
			{
				Id = "1251", 
				Summary = "Add notifications for users", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.",
				Priority = 2,
				ProjectName = "TeamBuild"
			});
			list.Add(new WorkItem()
			{
				Id = "1145", 
				Summary = "Import tickets", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.",
				Priority = 5,
				ProjectName = "TeamBuild"
			});
			list.Add(new WorkItem()
			{
				Id = "1385", 
				Summary = "Users should be able to add attachments", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.",
				Priority = 4,
				ProjectName = "TeamBuild"
			});
			list.Add(new WorkItem()
			{
				Id = "984", 
				Summary = "Tickets should not appear on for given system", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.",
				Priority = 1,
				ProjectName = "TeamBuild"
			});

			return list;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult List(string projectName)
		{
			var service = new WorkItemService(Configuration);
			var items = from item in service.GetWorkItems(projectName) orderby item.Priority select item;

			ViewData.Model = items;
			ViewData["ProjectName"] = projectName;

			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult UpdatePriorities(string projectName, string[] orderedWorkItems)
		{
			var workItemIds = from workItem in orderedWorkItems select workItem.Substring(workItem.IndexOf("_") + 1);

			var service = new WorkItemService(Configuration);
			service.UpdatePriorities(projectName, workItemIds.ToList());

			return new EmptyResult();
		}
	}
}
