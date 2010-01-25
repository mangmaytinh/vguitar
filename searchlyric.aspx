﻿<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" EnableViewState="false" AutoEventWireup="true" CodeFile="searchlyric.aspx.cs" Inherits="searchlyric" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sortoptionlinks" Src="Control/sortoptionlinks.ascx" %>
<%@ Register TagPrefix="ucl" TagName="categorylistsidemenu" Src="Control/categorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:categorylistsidemenu id="catlistcont" runat="server"></ucl:categorylistsidemenu>
    <br />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Quay lại trang chủ">Home</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2"><asp:Label cssClass="content2" id="lblcount" runat="server" /></span>
    <asp:Label cssClass="content2" id="lblsortname" runat="server" Font-Bold="True" />
    </div>
    <div style="padding: 2px; margin-bottom: 14px; margin-top: 12px; margin-left: 16px; margin-right: 26px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    <br />
    </div>
    <!--Begin Center Container-->
    <div style="margin-left: 5px; margin-right: 5px;">
    <!--Begin sort search links-->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td align="left" style="width: 79%">
    <ucl:sortoptionlinks id="opt1" runat="server"></ucl:sortoptionlinks>
    </td>
        <td width="20%" align="right">
        <div style="margin-right: 20px;">
    <asp:label ID="lblRecpagetop" runat="server" cssClass="content2" />
    </div>
    </td>
      </tr>
    </table>
    <!--End sort search links-->
    <div style="margin-bottom: 10px; border-top: solid 1px #D5E6FF; margin-right: 18px; margin-left: 4px;"></div>
    <asp:Label cssClass="content2" id="lblNorecordFound" Visible="false" runat="server" Font-Bold="True" />
    <!--Begin repeater center content-->
    <asp:Repeater id="LyricCat" OnItemDataBound="LyricCat_ItemDataBound" runat="server">
          <ItemTemplate>
        <div class="divwrap">
           <div class="divhd">
    <img src="images/arrow7.gif" alt="" />
    <a onmouseover="Tip('<img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" class="dtcat" title="Xem hợp âm <%# Eval("LyricName")%>" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'><%# Eval("LyricName") %></a>
    <asp:Label ID="lblpopular" cssClass="hot" runat="server" EnableViewState="false" /> <asp:Image ID="newimg" runat="server" EnableViewState="false" /><asp:Image id="thumbsup" runat="server" AlternateText = "Thumsb up" EnableViewState="false" /> 
    </div> 
    <div class="divbd">
    Chuyên mục:&nbsp;<a class="dt2" title="Go to <%# Eval("Category") %> category" href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category") %></a>
    <br />
    Đăng bởi:&nbsp;<img src="images/user-icon.gif" />&nbsp;<a href="findalllyricbyauthor.aspx?author=<%# Eval("Author") %>" onmouseover="Tip('Xem tất cả những hợp âm đăng bởi <b><%# Eval("Author") %></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%# Eval("Author") %></a>
    <br />
    Đánh giá:&nbsp;<img src="images/<%# Eval("Rating", "{0:0.0}")%>.gif" align="absmiddle" />&nbsp;(<span class="cgr"><%# Eval("Rating", "{0:0.0}")%></span>) votes <span class="cyel"><%# Eval("NoRates")%></span>
    <br />
    Thêm vào ngày: <span class="cyel"><%# CustomDateFormat(Eval("Date"))%></span>
    <br />
    Số lần xem: <span class="cmaron3"><%# Eval("Hits", "{0:#,###}")%></span>
        </div>
    </div>
    <div style="margin: 15px;"></div>
          </ItemTemplate>
      </asp:Repeater>
      </div>
      <!--Begin repeater center content-->
    <!--End Center Container-->
    <!--Begin Record count,page count and paging link-->
    <div style="margin-left: 12px; margin-top: 22px;">
    <asp:label ID="lblRecpage"
      Runat="server"
      cssClass="content2" EnableViewState="false" />
    <div style="margin-top: 10px;">
    <asp:Label cssClass="content2" id="lbPagerLink" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    </div>
    <!--End Record count,page count and paging link-->
</asp:Content>

