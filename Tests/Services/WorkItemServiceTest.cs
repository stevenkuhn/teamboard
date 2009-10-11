using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Services;
using TeamBoard.Infrastructure;
using Xunit;
using System.Configuration;

namespace TeamBoard.Tests.Services
{
	public class WorkItemServiceTest
	{
		[Fact]
		public void CanGetWorkItemsForProject()
		{
			var config = new TeamBoard.Infrastructure.Configuration();
			config.TeamFoundationServerName = "https://tfs06.codeplex.com:443";
			config.Login = ConfigurationManager.AppSettings["tfsUserName"];
			config.Password = ConfigurationManager.AppSettings["tfsPassword"];
			config.Domain = "snd";
			config.WorkItemMappings = new Dictionary<string, Dictionary<string, string>>();
			config.WorkItemMappings.Add("teamboard", new Dictionary<string, string>(){
						{"Id","System.Id"},
						{"Summary", "System.Title"},
						{"Description", "System.Description"},
						{"Priority", "CodePlex.Custom"}
					});
			var projectService = new WorkItemService(config);

			var list = projectService.GetWorkItems("teamboard");
			Assert.Equal(list.Count, 1);
		}

		[Fact]
		public void CanQueryByIteration()
		{
			var config = new TeamBoard.Infrastructure.Configuration();
			config.TeamFoundationServerName = "https://tfs06.codeplex.com:443";
			config.Login = ConfigurationManager.AppSettings["tfsUserName"];
			config.Password = ConfigurationManager.AppSettings["tfsPassword"];
			config.Domain = "snd";
			config.WorkItemMappings = new Dictionary<string, Dictionary<string, string>>();
			config.WorkItemMappings.Add("teamboard", new Dictionary<string, string>(){
						{"Id","System.Id"},
						{"Summary", "System.Title"},
						{"Description", "System.Description"},
						{"Priority", "CodePlex.Custom"}
					});
			var projectService = new WorkItemService(config);

			var list = projectService.GetWorkItems("teamboard", "teamboard");
			Assert.Equal(list.Count, 1);
		}
	}
}
