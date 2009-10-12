<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WorkItemsView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Project.Name %>
	- Team Build
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<ul id="workItemList">
		<% foreach (var item in Model.WorkItems) { %>
		<li style="" class="ui-widget ui-state-default ui-corner-all" id="workItem_<%= item.Id %>">
			<div class="" style="float: right;">
				<a href="javascript:$('#dialog').dialog('open');"><span class="ui-icon ui-icon-pencil"></span></a>
			</div>
			<div class="header">
				<%= item.Id %></div>
			<div class="content">
				<%= item.Summary %></div>
		</li>
		<% } %>
	</ul>
	


	<script type="text/javascript" language="javascript">
		$(function() {
			//$("#dialog").dialog({
			//	autoOpen: false,
			//	bgiframe: true,
			//	modal: true 
			//});

			$("#workItemList")
   				.sortable({
   					placeholder: 'ui-state-highlight ui-corner-all',
   					update: function(event, ui) {
   						$.post('/WorkItem/UpdatePriorities',
     						{
     							projectName: '<%= Model.Project.Name %>',
     							orderedWorkItems: $(this).sortable('toArray')
     						});

   						setWorkItemOpacity();
   					}
   				})
   				.disableSelection();

			setWorkItemOpacity();
		});

		function setWorkItemOpacity() {
			var list = $("#workItemList li");
			var count = list.size();
			list.each(function() {
				$(this).opacity((100 - ((list.index($(this)) / count) * 50)) / 100);
			});
		}
	</script>

</asp:Content>
