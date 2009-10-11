using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Model;
using Microsoft.TeamFoundation.Client;
using System.Net;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TfsWorkItem = Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem;
using BoardWorkItem = TeamBoard.Model.WorkItem;

namespace TeamBoard.Services
{
	public class WorkItemService
	{
		private IConfiguration _config;
		public WorkItemService(IConfiguration config)
		{
			_config = config;
		}

		private IList<BoardWorkItem> GetWorkItems(WorkItemQuery query, Dictionary<string, string> workItemMappings)
		{
			var workItems = new List<BoardWorkItem>();

			using (var tfs = GetServer())
			{
				tfs.EnsureAuthenticated();
				var workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));

				WorkItemCollection results = workItemStore.Query(query.ToString());
				foreach (TfsWorkItem
					item in results)
				{
					var newWorkItem = ConvertToBoardWorkItem(item, workItemMappings);
					workItems.Add(newWorkItem);
				}
			}

			return workItems;
		}

		public IList<BoardWorkItem> GetWorkItems(string projectName, string iterationPath)
		{
			var workItemMappings = _config.WorkItemMappings[projectName];

			WorkItemQuery query = new WorkItemQuery(projectName, workItemMappings);
			query.AddColumn("Id");
			query.AddColumn("Summary");
			query.AddColumn("Description");
			query.AddColumn("Priority");

			query.AddCriterion("System.IterationPath", "Under", iterationPath);

			query.AddSort("Priority", "ASC");

			return GetWorkItems(query, workItemMappings);
		}

		public IList<BoardWorkItem> GetWorkItems(string projectName)
		{
			var workItemMappings = _config.WorkItemMappings[projectName];

			WorkItemQuery query = new WorkItemQuery(projectName, workItemMappings);
			query.AddColumn("Id");
			query.AddColumn("Summary");
			query.AddColumn("Description");
			query.AddColumn("Priority");

			query.AddSort("Priority", "ASC");

			return GetWorkItems(query, workItemMappings);
		}

		private static BoardWorkItem ConvertToBoardWorkItem(TfsWorkItem item, Dictionary<string, string> workItemMappings)
		{
			int priority;
			if (!Int32.TryParse(item.Fields[workItemMappings["Priority"]].Value.ToString(), out priority))
				priority = 0;

			var newWorkItem = new BoardWorkItem()
									{
										Summary = item.Title,
										Description = item.Description,
										Id = item.Id.ToString(),
										Priority = priority
									};
			return newWorkItem;
		}

		public void Update(BoardWorkItem workItem)
		{
			using (var tfs = GetServer())
			{
				tfs.EnsureAuthenticated();

				var workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));

				var workItemMappings = _config.WorkItemMappings[workItem.ProjectName];

				var tfsWorkItem = workItemStore.GetWorkItem(Convert.ToInt32(workItem.Id));
				tfsWorkItem.Fields[workItemMappings["Priority"]].Value = workItem.Priority;
				tfsWorkItem.Fields[workItemMappings["Summary"]].Value = workItem.Summary;
				tfsWorkItem.Fields[workItemMappings["Description"]].Value = workItem.Description;
				tfsWorkItem.Fields[workItemMappings["Id"]].Value = Convert.ToInt32(workItem.Id);

				tfsWorkItem.Save();
			}
		}

		public void UpdatePriorities(string projectName, IList<string> orderedWorkItemIds)
		{
			var workItemMappings = _config.WorkItemMappings[projectName];
			using (var tfs = GetServer())
			{
				tfs.EnsureAuthenticated();
				int priority = 1;
				var workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
				foreach (string workItemId in orderedWorkItemIds)
				{
					var workItem = workItemStore.GetWorkItem(Convert.ToInt32(workItemId));
					workItem.Fields[workItemMappings["Priority"]].Value = priority;
					workItem.Save();

					priority++;
				}
			}
		}

		private TeamFoundationServer GetServer()
		{
			return new TeamFoundationServer(_config.TeamFoundationServerName,
							new NetworkCredential(_config.Login, _config.Password, _config.Domain));
		}
	}
}
