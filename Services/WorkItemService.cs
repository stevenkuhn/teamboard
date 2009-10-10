using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Model;

namespace TeamBoard.Services
{
	public class WorkItemService
	{

		public WorkItemService()
		{

		}

		public IList<WorkItem> GetWorkItems(string projectName)
		{
			if(projectName != "TeamBoard")
				return new List<WorkItem>();

			return new List<WorkItem>()
				{
					new WorkItem()
					{
						Summary = "Work Item 1",
						Description = "Make it work",
						Priority = 1,
						Project = new Project() {Name = "TeamBoard"}
					}
				};
		}
	}
}
