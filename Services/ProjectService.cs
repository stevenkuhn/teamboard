using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBoard.Model;

namespace TeamBoard.Services
{
	public class ProjectService
	{

		public IList<Project> GetProjects()
		{
			return new List<Project>()
				{
					new Project(){
						Name = "TeamBoard",
						Description = "Sticky notes visualization for Team Foundation Server"
					}
				};
		}
	}
}