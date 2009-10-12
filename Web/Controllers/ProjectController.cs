using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TeamBoard.Web.Model;
using TeamBoard.Services;

namespace TeamBoard.Web.Controllers
{
	public class ProjectController : Controller
	{
		public ProjectController(ProjectService projectService)
		{
			ProjectService = projectService;
		}

		public ProjectService ProjectService { get; private set; }

		public ActionResult Index(string projectName)
		{
			var project = ProjectService.GetProject(projectName);

			var model = new ProjectView()
			{
				Project = project
			};

			return View(model);
		}
	}
}
