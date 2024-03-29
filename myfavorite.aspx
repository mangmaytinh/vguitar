﻿<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="myfavorite.aspx.cs" Inherits="myfavorite" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
<ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-bottom: 12px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Quay lại trang chủ"><%=Resources.lang.Home %></a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang trong mục: Yêu thích</span>
    </div> 
    <div style="margin-left: 15px;">   
    <table border="0" cellpadding="2" align="left" cellspacing="2" width="75%">
      <tr>
    <td width="68%">
    <fieldset><legend><span class="sortcat"><%=Resources.lang.Sort_Option%>:</span>&nbsp;<span class="content2">
<asp:HyperLink id="SortLinkRecipeName" cssClass="dsort" runat="server" />&nbsp;<asp:Image id="ArrowImage2" runat="server" />&nbsp;|&nbsp;
<asp:HyperLink id="SortLinkHits" cssClass="dsort" runat="server" />&nbsp;<asp:Image id="ArrowImage1" runat="server" />&nbsp;|&nbsp;
<asp:HyperLink id="SortLinkRating" cssClass="dsort" runat="server" />&nbsp;<asp:Image id="ArrowImage4" runat="server" />&nbsp;|&nbsp;
<asp:HyperLink id="SortLinkDateAdded" cssClass="dsort" runat="server" />&nbsp;<asp:Image id="ArrowImage5" runat="server" />
</span></legend>
     <div style="padding-top: 8px;">
     <asp:Label runat="server" id="lblyouarenotlogin" Visible="false" CssClass="content12" EnableViewState="false" />
     <asp:Panel ID="HideContentIfNotLogin" runat="server">
     <div style="margin-top: 5px; margin-bottom: 16px;">
         <div style="margin-left: 5px; margin-bottom: 12px;">
         <asp:Label runat="server" style="font-family:Verdana, Arial; color: #336699; font-size: 14px; font-weight:bold;" id="lblusernameheader" EnableViewState="false" /><br />
         </div>
         <div>
         <asp:Label runat="server" id="lblcounter" CssClass="content12" EnableViewState="false" />
         </div>
     </div>
        <asp:Label runat="server" CssClass="content2" id="lblnosavedrecipe" EnableViewState="false" />
        <asp:Repeater id="SavedRecipeInCookBook" runat="server" OnItemDataBound="SavedRecipeInCookBook_ItemDataBound">
       <ItemTemplate>
        <div class="dcnt2" style="margin-top: 6px;">
        <asp:Label ID="lblDelete" runat="server" CssClass="thickbox" EnableViewState="false" />&nbsp;&nbsp;<a href="emaillyric.aspx?id=<%# Eval("itemID") %>&n=<%# Eval("LyricName") %>&c=<%# Eval("Category") %>&keepThis=true&TB_iframe=true&height=220&width=400" class="thickbox" title="Chia sẻ bài hát" onmouseover="Tip('Gửi bài hát <b><%# Eval("LyricName")%></b> cho bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><img src="images/send_icon.gif" alt="Gửi Email" border="0" align="absmiddle" /></a>&nbsp;&nbsp;
        <a href='<%# Eval("RecipeID", "lyricdetail.aspx?id={0}") %>' onmouseover="Tip('Xem chi tiết bài hát <b><%# Eval("LyricName")%></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><img src="images/detail_icon.gif" alt="xem chi tiết trang" align="absmiddle" border="0" /></a>&nbsp;&nbsp;<a class="thickbox content12" title="Xem bài hát" onmouseover="Tip('<b>Tên bài hát:</b> <%# Eval("LyricName") %><br><b>Tác giả:</b> <%# Eval("Author") %><br><b>Chủ đề:</b> <%# Eval("Category") %><br><b>Số lần xem:</b> (<%# Eval("Hits") %>)<br><b>Đánh giá:</b> (<%# Eval("Rating") %>)<br><b>Bình luận:</b> (<%# Eval("Comments") %>)<br>Thêm vào ngày: <%# Eval("Date", "{0:M/d/yyyy}")%><br><b>Ảnh chi tiết:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;300&quot; height=&quot;200&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='printlyric.aspx?id=<%# Eval("RecipeID") %>&keepThis=true&TB_iframe=true&height=600&width=750'><%# Eval("LyricName")%></a>
        </div>
         
          <div id="confirmModal<%# Eval("itemID")%>" style="display:none;">
            <div class="confirm">
                <div class="message">
                 <img src="images/icon_confirm.gif" alt="confirm icon" style="float: left; margin-right: 10px;" /> Bạn đã chắc chắn mốn xóa bài hát <span style="color:#266B91"><b><%# Eval("LyricName") %></b></span> Ra khỏi mục yêu thích của bạn không?
                </div>
                <div class="commands" style="text-align: center;">
                    <input type="button" value="Yes" class="submitpopupmodal" onclick="sendRequestDeleteUserRecipeInCookBook('<%# Eval("itemID")%>')">&nbsp;&nbsp;<input type="button" value="No" class="submitpopupmodal" onclick="tb_remove(); return false;">
                </div>
            </div>
        </div>
        
       </ItemTemplate>
      </asp:Repeater>
      </asp:Panel>
     </div>
    <!--Begin Record count,page count and paging link-->
    <div style="margin-left: 4px; margin-top: 22px;">
    <asp:label ID="lblRecpage"
      Runat="server"
      cssClass="content2" EnableViewState="false" />
    <div style="margin-top: 10px;">
    <asp:Label cssClass="content2" id="lbPagerLink" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    </div>
    <!--End Record count,page count and paging link-->
    </fieldset>
    </td>
      </tr>
    </table>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

