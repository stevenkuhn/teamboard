using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TeamBoard.Model;
using TeamBoard.Services;
using TeamBoard.Web.Model;

namespace TeamBoard.Web.Controllers
{
	public class WorkItemController : Controller
	{
		public WorkItemController(
			ProjectService projectService,
			WorkItemService workItemService,
			IConfiguration configuration)
		{
			ProjectService = projectService;
			WorkItemService = workItemService;
			Configuration = configuration;
		}

		public ProjectService ProjectService { get; private set; }
		public WorkItemService WorkItemService { get; private set; }
		public IConfiguration Configuration { get; private set; }

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult List(string projectName)
		{
			var project = ProjectService.GetProject(projectName);
			var items = from item in WorkItemService.GetWorkItems(projectName) orderby item.Priority select item;

			var model = new WorkItemsView();
			model.WorkItems = items;
			model.Project = project;

			ViewData.Model = model;

			return View();
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult UpdatePriorities(string projectName, string[] orderedWorkItems)
		{
			var workItemIds = from workItem in orderedWorkItems select workItem.Substring(workItem.IndexOf("_") + 1);

			WorkItemService.UpdatePriorities(projectName, workItemIds.ToList());

			return new EmptyResult();
		}
	}
}
