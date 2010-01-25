<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" EnableViewState="false" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="lyricoftheday" Src="Control/lyricoftheday.ascx" %>
<%@ Register TagPrefix="ucl" TagName="Controllastviewedlyric" Src="Control/lastviewedlyric.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articategorylistsidemenu" Src="Control/articategorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:newestarticle id="nart" runat="server"></ucl:newestarticle>
    <br />
    <ucl:articategorylistsidemenu id="artcat" runat="server"></ucl:articategorylistsidemenu>
    <br />
    <%--<ucl:rsssidemenu id="rsscont" runat="server"></ucl:rsssidemenu>--%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="padding: 2px; text-align: left; margin-left: 40px; margin-bottom: 15px; margin-top: 16px; margin-right: 40px;">
    <asp:Image id="Myranimage" runat="server"
     Width = 107 Height = 74
     AlternateText = "Lyric Random Image" Style="float:left; padding-right: 5px;"
    />
    <span class="dLyric">
    Bạn là người thích âm nhạc, bạn là người thích đàn guitar hãy vào đây để nâng cao khả năng đó của bạn.
    </span>
    </div>
    <br />
    <br />
    <div style="padding: 2px; text-align: center; margin-left: 26px; margin-bottom: 12px; margin-right: 26px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    </div>
    <div style="text-align: center; padding-top: 3px;"><asp:Label cssClass="content2" runat="server" id="lbltotalLyric" />
    </div>
    <br />
    <div style="text-align: center;  padding-bottom: 5px;"><span style="font-family: verdana,arial; font-size: 17px; color: #CC3300;"><b>Phân loại hợp âm bài hát theo thể loại</b></span></div>
    <div class="MainCourseCat">
    <asp:DataList id="MainCourseCategory" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" HorizontalAlign="Center">
          <ItemTemplate>
         <div style="margin-left: 60px; margin-top: 3px; margin-bottom: 3px; margin-right: 10px;">  
    <span class="bluearrow">&raquo;</span> <a class="catlink" title="Xem tất cả hợp âm trong danh mục  <%# Eval("Category") %> " href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category")%></a> <span class="catcount"><i>(<%# Eval("RecordCount")%>)</i></span>
           </div>
          </ItemTemplate>
      </asp:DataList>
      </div>
      <br />
      <div style="clear:both;"></div>
      <div style="text-align: center;  padding-bottom: 5px;"><span style="font-family: verdana,arial; font-size: 17px; color: #CC3300;"><b>Phân loại hợp âm bài hát theo tác giả, ca sĩ</b></span></div>
    <div class="EthnicCat">
    <asp:DataList id="EthnicRegionalCat" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" HorizontalAlign="Center">
          <ItemTemplate>
         <div style="margin-left: 60px; margin-top: 3px; margin-bottom: 3px; margin-right: 10px;">  
    <span class="bluearrow">&raquo;</span> <a class="catlink" title="Xem tất cả hợp âm theo danh mục <%# Eval("Category") %>" href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category")%></a> <span class="catcount"><i>(<%# Eval("RecordCount")%>)</i></span>
           </div>
          </ItemTemplate>
      </asp:DataList>
      </div>
      <div style="clear:both; margin-top: 16px;"></div>
     <!--Begin Today and last 8 hours Lyric block--> 
      <div style="margin-left: 50px; margin-right: 50px; width: auto;">
    <ucl:lyricoftheday id="recday" runat="server"></ucl:lyricoftheday>
    <ucl:Controllastviewedlyric id="lastviewed" runat="server"></ucl:Controllastviewedlyric>
      </div>
       <!--End Today and last 8 hours Lyric block---> 
</asp:Content>

