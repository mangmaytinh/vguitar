<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newesttolyrics.ascx.cs" Inherits="newesttolyrics" EnableViewState="false"%>

<div id="MyCookBookSideMenuContainer" runat="server" style="margin-bottom: 20px;">
<div class="toproundbluesidemenu">
<div class="toproundbluesidemenuheader"><span class="content3"><%=Resources.lang.My_Song_Quick_View %></span></div>
</div>
<div class="contentdisplay">
<div class="contentdis5">
<asp:Label runat="server" id="lblcounter" CssClass="content2" EnableViewState="false" />
<br />
<asp:Repeater id="MyFavoriteSideMenuRepeater" runat="server" EnableViewState="false">
   <ItemTemplate>
<div style="margin-top: 3px; margin-bottom: 3px;">
<span class="cyel">&raquo;</span>&nbsp;<a class="content12" title="View <%# Eval("LyricName") %> recipe" onmouseover="Tip('<b>Tên bài hát:</b> <%# Eval("LyricName") %><br><b>Người đăng:</b> <%# Eval("Author") %><br><b>Danh mục:</b> <%# Eval("Category") %><br><b>Số lần xem:</b> (<%# Eval("Hits") %>)<br><b>Đánh giá:</b> (<%# Eval("Rating") %>)<br><b>Ý kiến:</b> (<%# Eval("Comments") %>)<br><b>Ngày đăng bài:</b> <%# Eval("Date", "{0:M/d/yyyy}")%><br><b>Lời:</b><br><%# Eval("Comments") %>, BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("RecipeID", "lyricdetail.aspx?id={0}") %>'><%# Eval("LyricName")%></a>
</div>
   </ItemTemplate>
  </asp:Repeater>
</div>
</div>
</div>
<!--Begin Random Lyric-->
<div class="toproundbluesidemenu">
<div class="toproundbluesidemenuheader"><span class="content3"><%=Resources.lang.Featured %><asp:Label ID="lblrancatname" cssClass="content3" runat="server" EnableViewState="false" /></span></div>
</div>
<div class="contentdisplayblue">
<div class="contentdis5">
<span class="bluearrow">&raquo;</span>
<asp:HyperLink id="LinkRanName" cssClass="dt" runat="server" EnableViewState="false" />
<br />
<span class="content8"><%=Resources.lang.Category %>:</span> <asp:HyperLink id="LinkRanCat" cssClass="dt2" runat="server" EnableViewState="false" />
<br />
<span class="content8"><%=Resources.lang.Rating %>:&nbsp;<asp:Image id="ranrateimage" runat="server" ImageAlign="absmiddle" EnableViewState="false" />&nbsp;<%=Resources.lang.Votes %>&nbsp;<asp:Label cssClass="cgr" runat="server" id="lblvotes" EnableViewState="false" /></span>
<br />
<span class="content8"><%=Resources.lang.Hits %>:</span> <asp:Label cssClass="cmaron2" runat="server" id="lblranhits" EnableViewState="false" />
</div>
</div>	
<!--End Random Lyric-->
<br />
<!--Begin 15 Newest Recipes-->
<div class="toproundgreen">
<div class="toproundgreenheader"><span class="content3"><asp:Label ID="lbTopCnt" cssClass="content3" runat="server" EnableViewState="false" />&nbsp;<asp:Label ID="lblcatname" cssClass="content3" runat="server" EnableViewState="false" /><%=Resources.lang.Newest_Songs %></span></div>
</div>
<div class="contentdisplaygreen">
<div class="contentbggreen">
<asp:Repeater id="LyricNew" runat="server" OnItemDataBound="RecipeNew_ItemDataBound" EnableViewState="false">
   <ItemTemplate>
<div class="dcnt2">
<span class="arrowgr">&raquo;</span>
<a class="dt" onmouseover="Tip('<b>Danh mục: </b><%# Eval("Category") %><br><b>Số lần xem: </b><%# Eval("Hits") %><b><br>Ngày viết bài: </b><%# Eval("Date", "{0:M/d/yyyy}")%><br><b>Ảnh:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'>
<%# Eval("LyricName") %></a>
<br />
<span class="content2"><asp:Label cssClass="content2" ID="lblgetdate" runat="server" EnableViewState="false" /></span>
</div>
      </ItemTemplate>
  </asp:Repeater>
</div>
</div>
<!--End 15 Newest Recipes-->
<br />
<!--Begin 15 Most Popular-->
<div class="toproundgreen">
<div class="toproundgreenheader"><span class="content3"><asp:Label ID="lblcatnamepop" cssClass="content3" runat="server" EnableViewState="false" /><asp:Label ID="lblpopcounter" cssClass="content3" runat="server" EnableViewState="false" /></span></div>
</div>
<div class="contentdisplaygreen">
<div class="contentbggreen">
<asp:Repeater id="TopLyric" runat="server" OnItemDataBound="TopRecipe_ItemDataBound" EnableViewState="false">
   <ItemTemplate>
<div class="dcnt2">
<asp:Label ID="lbseqnumber" cssClass="cyel2" runat="server" EnableViewState="false" /> <a class="dt" onmouseover="Tip('<b>Danh mục: </b><%# Eval("Category") %><br><b>Lượt xem: </b><%# Eval("Hits") %><br><b>Ảnh:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'>
<%# Eval("LyricName")%></a>
</div>
      </ItemTemplate>
  </asp:Repeater>
</div>
</div>
<!--End 15 Most Popular-->
