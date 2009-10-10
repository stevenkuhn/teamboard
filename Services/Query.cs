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
	public class Query
	{
		IList<string> _columns;
		private Dictionary<string, string> _overrides;
		private string _projectName;

		public Query(string projectName, Dictionary<string, string> overrides)
		{
			_overrides = overrides;
			_columns = new List<string>();
			_projectName = projectName;
		} 

		public void AddColumn(string columnName)
		{
			string overrideValue;
			if (_overrides.TryGetValue(columnName, out overrideValue))
				_columns.Add(overrideValue);
			else
				_columns.Add(columnName);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			foreach (string column in _columns)
			{
				sb.Append("[" + column + "],");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.AppendFormat(" FROM WorkItems WHERE [System.TeamProject] = '{0}'", _projectName);
			sb.Append(" AND [System.State] <> 'Closed'");

			return sb.ToString();
		}
	}
}
