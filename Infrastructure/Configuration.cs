using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Services;

namespace TeamBoard.Infrastructure
{
	public class Configuration : IConfiguration
	{
		public string TeamFoundationServerName { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }
		public string Domain { get; set; }
		public bool UsePassThroughAuth { get; set; }

		#region IConfiguration Members


		public Dictionary<string, Dictionary<string, string>> WorkItemMappings { get; set; }

		#endregion
	}
}
