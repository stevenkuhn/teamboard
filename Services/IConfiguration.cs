using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Model;

namespace TeamBoard.Services
{
	public interface IConfiguration
	{
		string TeamFoundationServerName { get; set; }
		string Login { get; set; }
		string Password { get; set; }
		string Domain { get; set; }
    bool UsePassThroughAuth { get; set; }
		Dictionary<string, Dictionary<string, string>> WorkItemMappings { get; set; }
	}
}
