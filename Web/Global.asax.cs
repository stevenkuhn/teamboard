using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Mvc;
using Ninject;
using System.Reflection;
using Ninject.Modules;
using TeamBoard.Services;
using TeamBoard.Infrastructure;
using System.Configuration;

namespace TeamBoard.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : NinjectHttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("favicon.ico");

			routes.MapRoute(
				 "Default",                                              // Route name
				 "{controller}/{action}/{id}",                           // URL with parameters
				 new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected override void OnApplicationStarted()
		{
			RegisterRoutes(RouteTable.Routes);
			RegisterAllControllersIn(Assembly.GetExecutingAssembly());
		}

		protected override IKernel CreateKernel()
		{
			return new StandardKernel(new DefaultModule());
		}
	}

	internal class DefaultModule : NinjectModule
	{
		public override void Load()
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

			Bind<IConfiguration>().ToConstant(config);
		}
	}
}