using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Client;
using System.Net;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TfsProject = Microsoft.TeamFoundation.WorkItemTracking.Client.Project;
using BoardProject = TeamBoard.Model.Project;

namespace TeamBoard.Services
{
	public class ProjectService
	{
		private IConfiguration _config;
		/// <summary>
		/// Initializes a new instance of the ProjectService class.
		/// </summary>
		public ProjectService(IConfiguration config)
		{
			_config = config;
		}

		public IList<BoardProject> GetProjects()
		{
			List<BoardProject> projects = new List<BoardProject>();
			using (var tfs = GetServer())
			{
				tfs.EnsureAuthenticated();
				var workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
				foreach (TfsProject project in workItemStore.Projects)
				{
					var item = new BoardProject { Name = project.Name, Description = "" };
					projects.Add(item);
				}
			}

			return projects;
		}

		private TeamFoundationServer GetServer()
		{
			return new TeamFoundationServer(_config.TeamFoundationServerName,
							new NetworkCredential(_config.Login, _config.Password, _config.Domain));
		}
	}
}