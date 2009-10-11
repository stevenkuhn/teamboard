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
	public class Criterion
	{

		public Criterion()
		{

		}

		public Criterion(string columnName, string oper, string val)
		{
			this.Column = columnName;
			this.Operator = oper;
			this.Value = val;
		}

		public string Column { get; set; }
		public string Operator { get; set; }
		public string Value { get; set; }

	}
}
