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
	public class WorkItemQuery
	{
		IList<string> _columns;
		Dictionary<string, string> _sorts;
		IList<Criterion> _criteria;
		private Dictionary<string, string> _overrides;
		private string _projectName;

		public WorkItemQuery(string projectName, Dictionary<string, string> overrides)
		{
			_overrides = overrides;
			_columns = new List<string>();
			_sorts = new Dictionary<string, string>();
			_criteria = new List<Criterion>();
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

		public void AddSort(string columnName, string order)
		{
			string overrideValue;
			if (_overrides.TryGetValue(columnName, out overrideValue))
				_sorts.Add(overrideValue, order);
			else
				_sorts.Add(columnName, order);
		}

		public void AddCriterion(string columnName, string oper, string val)
		{
			string overrideValue;
			if (_overrides.TryGetValue(columnName, out overrideValue))
				_criteria.Add(new Criterion(overrideValue, oper, val));
			else
				_criteria.Add(new Criterion(columnName, oper, val));
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			foreach (string column in _columns)
			{
				sb.Append(String.Format("[{0}],", column));
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append(" FROM WorkItems");
			sb.AppendFormat(" WHERE [System.TeamProject] = '{0}'", _projectName);

			if(_criteria.Count > 0)
			{
				sb.Append(" AND ");
				foreach (var criterion in _criteria)
        {
					sb.Append(String.Format("[{0}] {1} '{2}' AND ", criterion.Column, criterion.Operator, criterion.Value));
        }
				sb.Remove(sb.Length - 5, 5);
			}

			if(_sorts.Count > 0)
			{
				sb.Append(" ORDER BY ");
				foreach (var sort in _sorts)
				{
					sb.Append(String.Format("[{0}] {1},", sort.Key, sort.Value));
				}
				sb.Remove(sb.Length - 1, 1);
			}
			
			return sb.ToString();
		}
	}
}
