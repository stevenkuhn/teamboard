using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamBoard.Model
{
	public class WorkItem
	{

		public WorkItem()
		{

		}
		public string Summary { get; set; }
		public string Description { get; set; }
		public int Priority { get; set; }
		public Project Project { get; set; }
	}
}
