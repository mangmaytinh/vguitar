<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sidemenu.ascx.cs" Inherits="sidemenu" EnableViewState="false"%>
<!--Begin Navigation Menu-->
<div class="toproundbluesidemenu">
<div class="toproundbluesidemenuheader"><span class="content3">Danh mục chính</span></div>
</div>
<div style="padding-top: 0px; padding-left: 0px;">
<div id="b2">
<asp:Panel ID="PanelSideMenuShowUsersLinks" runat="server">
<ul>
<li><a href="default.aspx"><%=Resources.lang.Home %></a></li>
    <li><a  href="myaccount.aspx"><%=Resources.lang.My_Account %></a></li>
    <li><a href="pmview.aspx"><%=Resources.lang.My_PM_Inbox %></a></li>
    <li><a href="myfavorite.aspx"><%=Resources.lang.My_Song %></a></li>
    <%--<li><a href="myfriendslist.aspx"><%=Resources.lang.My_Friends_List %></a></li>--%>
    <%--<li><a href="members.aspx"><%=Resources.lang.Browse_Members %></a></li>--%>
    <%--<li><a href="events.aspx"><%=Resources.lang.Events_Calendar %></a></li>--%>
    <li><a href="sort.aspx?sid=4"><%=Resources.lang.Newest_Songs %></a></li>
    <li><a href="sort.aspx?sid=1"><%=Resources.lang.Most_Popular_Songs %></a></li>
    <li><a href="sort.aspx?sid=2"><%=Resources.lang.Highest_Rated_Songs %></a></li>        
    <li><a href="addlyric.aspx"><%=Resources.lang.Submit_a_Song %></a></li>
    <li><a href="addarticle.aspx"><%=Resources.lang.Publish_an_Article %></a></li>    
</ul>
</asp:Panel>
<asp:Panel ID="PanelSideMenuShowAdminLoginLink" runat="server">
<ul>
<li><a href="default.aspx"><%=Resources.lang.Home %></a></li>
    <li><a title="XD Portal Administrator Login" href="admin/adminlogin.aspx"><%=Resources.lang.Admin_Login %></a></li>
    <li><a  href="myaccount.aspx"><%=Resources.lang.My_Account %></a></li>
    <li><a href="pmview.aspx"><%=Resources.lang.My_PM_Inbox %></a></li>
    <li><a href="myfavorite.aspx"><%=Resources.lang.My_Song %></a></li>
    <%--<li><a href="myfriendslist.aspx"><%=Resources.lang.My_Friends_List %></a></li>--%>
    <%--<li><a href="members.aspx"><%=Resources.lang.Browse_Members %></a></li>--%>
    <%--<li><a href="events.aspx"><%=Resources.lang.Events_Calendar %></a></li>--%>
    <li><a href="sort.aspx?sid=4"><%=Resources.lang.Newest_Songs %></a></li>
    <li><a href="sort.aspx?sid=1"><%=Resources.lang.Most_Popular_Songs %></a></li>
    <li><a href="sort.aspx?sid=2"><%=Resources.lang.Highest_Rated_Songs %></a></li>        
    <li><a href="addlyric.aspx"><%=Resources.lang.Submit_a_Song %></a></li>
    <li><a href="addarticle.aspx"><%=Resources.lang.Publish_an_Article %></a></li> 
</ul>
</asp:Panel>
<asp:Panel ID="PanelSideMenuHideUsersLinks" runat="server">
<ul>
<li><a title="Back to hompeage" href="default.aspx"><%=Resources.lang.Home %></a></li>
    <li><a href="sort.aspx?sid=4"><%=Resources.lang.Newest_Songs %></a></li>
    <li><a href="sort.aspx?sid=1"><%=Resources.lang.Most_Popular_Songs %></a></li>
    <li><a href="sort.aspx?sid=2"><%=Resources.lang.Highest_Rated_Songs %></a></li>        
    <%--<li><a href="members.aspx"><%=Resources.lang.Browse_Members %></a></li>--%>
    <%--<li><a href="events.aspx"><%=Resources.lang.Events_Calendar %></a></li>--%>
    <li><a title="XD Portal Administrator Login" href="admin/adminlogin.aspx"><%=Resources.lang.Admin_Login %></a></li>
    <li><a href="addlyric.aspx"><%=Resources.lang.Submit_a_Song %></a></li>
    <li><a href="addarticle.aspx"><%=Resources.lang.Publish_an_Article %></a></li> 
    
</ul>
</asp:Panel>
</div>
</div>
<div style="clear:both;">&nbsp;</div>
<!--End Navigation Menu-->