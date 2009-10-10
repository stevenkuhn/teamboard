<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TeamBuild Mockup
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <ul id="workItemList">
		<li class="ui-state-default">
			1
		</li>
		<li class="ui-state-default">
			2
		</li>
		<li class="ui-state-default">
			3
		</li>
		<li class="ui-state-default">
			4
		</li>
		<li class="ui-state-default">
			5
		</li>
		<li class="ui-state-default">
			6
		</li>
   </ul>
   <script type="text/javascript" language="javascript">
   	$(function() {
   		$("#workItemList")
   			.sortable()
   			.disableSelection();
   	});
   </script>
   
   <!-- 
    <div>
		teambuild / supportnet / sprint 0
    </div>
    
    <div class="item">
		<h2>Create database</h2>
		<div class="content">
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.
		</div>
    </div>
    
    <div class="item">
		<h2>Add notifications for users</h2>
		<div class="content">
			Donec molestie odio ac metus elementum interdum. Phasellus convallis mollis tincidunt. Nulla auctor vulputate sem, sed consequat tortor laoreet eget. Vivamus ac scelerisque leo. In sit amet orci non enim faucibus dictum. Aenean bibendum lorem in eros egestas eleifend scelerisque neque ultricies. Praesent ut tortor non erat
		</div>
    </div>
    
    <div class="item">
		<h2>Import tickets</h2>
		<div class="content">
			Ut rutrum ultricies tortor vitae aliquam. Curabitur ac nulla a diam scelerisque molestie ac in augue. Etiam id justo eget lorem eleifend ultricies. Nulla leo est, aliquet vitae semper vel, blandit nec urna. Integer urna ipsum, lacinia vel pellentesque et, tincidunt nec eros. Integer dolor ipsum, viverra id dignissim ac, varius eget
		</div>
    </div>
    
    <div class="item">
		<h2>Users should be able to add attachments</h2>
		<div class="content">
			Vivamus non sem id velit venenatis varius. Donec nisl magna, hendrerit at rutrum id, imperdiet quis neque. Sed nibh diam, faucibus pretium pellentesque vitae, semper at lacus. Nunc vitae purus a justo varius fringilla in sed massa. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fermentum pellentesque ipsum, sit amet
		</div>
    </div>
    
    <div class="item">
		<h2>Add origin</h2>
		<div class="content">
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.
		</div>
    </div>
    
    <div class="item">
		<h2>Tickets should not appear on for given system</h2>
		<div class="content">
			Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla bibendum congue mi, eget iaculis magna ornare nec. Nulla eu elit quis ipsum varius malesuada. Maecenas a sem leo. Aliquam magna turpis, pretium a lobortis tristique, interdum auctor odio. Cras purus augue, cursus in imperdiet in, feugiat sit amet diam.
		</div>
    </div>
    
    
    <!--
    <div class="note">
		<h2>
			item summary
		</h2>
		<div class="content">
			Lorem ipsum dolor sit amet, consectetur adipiscing 
			elit. Sed nulla arcu, mattis a blandit eleifend, 
			pretium at nunc. In fringilla risus vitae est 
			tincidunt sagittis. Lorem ipsum dolor sit amet,
			consectetur adipiscing elit. Proin dignissim 
			scelerisque lacus sed ultricies. Nam suscipit 
			ligula posuere.
		</div>
    </div>
    
    <div class="note">
		<h2>
			another item
		</h2>
		<div class="content">
			Lorem ipsum dolor sit amet, consectetur adipiscing 
			elit. Sed nulla arcu, mattis a blandit eleifend, 
			pretium at nunc. In fringilla risus vitae est 
			tincidunt sagittis. Lorem ipsum dolor sit amet,
			consectetur adipiscing elit. Proin dignissim 
			scelerisque lacus sed ultricies. Nam suscipit 
			ligula posuere.
		</div>
    </div>-->
</asp:Content>
