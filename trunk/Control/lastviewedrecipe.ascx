<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lastviewedrecipe.ascx.cs" Inherits="Controllastviewedrecipe" EnableViewState="false"%>
    <div class="hpright">
    <span class="hdgr">Những hợp âm được xem cách đây <asp:Label cssClass="hdgr" runat="server" id="lbgethour" /> Giờ</span>
    <br />
    <asp:Repeater id="lastview" runat="server" OnItemDataBound="lastview_ItemDataBound" EnableViewState="false">
   <ItemTemplate>
<div class="dcnt2">
<asp:Label ID="lbseqnumber" cssClass="cgr2" runat="server"></asp:Label> <a class="dt" onmouseover="Tip('<b>Category: </b><%# Eval("Category") %><br><b>X: </b><%# Eval("Hits") %><br><b>Lần xem cuối:</b><br>(<%# Eval("Hours") %> Giờ(s)., <%# Eval("Minutes") %> Phút.) trước đây.<br><b>Ảnh:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'>
<%# Eval("LyricName") %></a>
<br />
</div>
      </ItemTemplate>
  </asp:Repeater>
  </div>
