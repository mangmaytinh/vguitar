﻿<%@ Import namespace="Resources"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchtab.ascx.cs" Inherits="searchtab"  EnableViewState="false"%>
<!--Begin Search-->
<div style="margin-left: 10px; margin-right: 12px;">
<div class="toproundbluesearchtab">
<div class="toproundbluesearchtabheader"><span class="content3" style="color: #fff;"><asp:Label ID="lblAmount" runat="server" Text="<%$ Resources:lang, Song_Search %>"></asp:Label></span></div>
</div>
<div id="basic" class="tbcont">
<div style="padding-top: 5px; color: #000;">
<img src="images/search.gif" border="0" alt="Search recipe" align="absmiddle" />
<input type="text" name="find" id="find" class="textboxsearch" size="40" value="Từ khóa..." onfocus="if(this.value=='Từ khóa...')value='';" onblur="if(this.value=='')value='Từ khóa...';" runat="server" /> <%=Resources.lang.In %> 
<asp:dropdownlist id="SDropName" runat="server" cssClass="ddlsearch" AutoPostBack="false"></asp:dropdownlist>
<asp:Button ID="Sbuton" runat="server" cssClass="submitadmin" OnClick="SearchButton_Click" Text="Bắt đầu tìm" />
</div>
</div>
</div>
<!--End Search-->

