using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamBoard.Model;

namespace TeamBoard.Web.Model
{
	public class WorkItemsView : ProjectView
	{
		public IEnumerable<WorkItem> WorkItems { get; set; }
	}
}
