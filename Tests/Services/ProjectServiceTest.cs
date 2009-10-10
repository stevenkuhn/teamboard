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
	public class ProjectServiceTest
	{
		[Fact]
		public void CanCallGetProjects()
		{
			var config = new TeamBoard.Infrastructure.Configuration();
			config.TeamFoundationServerName = "https://tfs06.codeplex.com:443";
			config.Login = ConfigurationManager.AppSettings["tfsUserName"];
			config.Password = ConfigurationManager.AppSettings["tfsPassword"];
			config.Domain = "snd";
			var projectService = new ProjectService(config);

			var list = projectService.GetProjects();
			Assert.Equal(list.Count, 1);
		}

	}
}