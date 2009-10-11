<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<IEnumerable<WorkItem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>List</h2>
    
    <ul id="workItemList">
    <% foreach (var item in Model) { %>
		<li class="ui-widget ui-state-default" id="workItem_<%= item.Id %>" >
			<%= item.Summary %>
		</li>
    <% } %>
    </ul>
     <script type="text/javascript" language="javascript">
     	$(function() {
     		$("#workItemList")
   			.sortable({
     				update: function(event, ui) {
     					$.post('/WorkItem/UpdatePriorities',
     					{
     						projectName: '<%= ViewData["ProjectName"] %>',
     						orderedWorkItems: $(this).sortable('toArray') 
     					});
   				}
   			})
   			.disableSelection();
     	});
   </script>
</asp:Content>
