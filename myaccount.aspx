<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="myaccount.aspx.cs" Inherits="myaccount" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="usersearchtab" Src="Control/usersearchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="userconfigfetaures" Src="Control/userconfigfetaures.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
<ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<ucl:usersearchtab id="searchusercont" runat="server"></ucl:usersearchtab>
    <div style="margin-left: 10px; margin-bottom: 12px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage"><%=Resources.lang.Home %></a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang trong mục: Tài khoản</span>
    </div>
    <div style="margin-left: 15px;"> 
    <table border="0" cellpadding="2" align="left" cellspacing="2" width="75%">
      <tr>
    <td width="68%">
    <fieldset><legend><asp:Label runat="server" id="lblusernameheader" EnableViewState="false" /></legend>
     <div style="padding-top: 8px; margin-bottom: 20px;">
     <asp:Label runat="server" id="lblyouarenotlogin" Visible="false" CssClass="content12" EnableViewState="false" />
     <asp:Panel ID="HideContentIfNotLogin" runat="server">
         <div style="margin-top: 5px; margin-bottom: 25px; margin-right: 25px;">
         <span class="content12">Chào mừng đến với quản lý tài khoản của bạn và bảng điều khiển thiết lập. Từ đây bạn có thể chỉnh sửa và điều khiển các thiết lập trang hồ sơ của bạn.</span>
         <asp:Label runat="server" CssClass="content12" id="lbllastactivitymsg" EnableViewState="false" />
         </div>
         <div style="margin-top: 2px; margin-bottom: 4px; margin-right: 25px;">
          <asp:Label runat="server" CssClass="content12" id="lblupdatesettingsmsg" Visible="false" EnableViewState="false" />
         </div>
         <div style="margin-top: 5px;">
<table cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="33%">
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containermylinks" style="line-height: 21px;">
            <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/link_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Liên kết của bạn</span>
            </div>
            <div style="padding-right: 8px; padding-left: 8px; padding-top: 2px; line-height: 18px">
                <asp:Label runat="server" CssClass="content12" id="lblmyprofilelink" EnableViewState="false" /><br />
                <asp:Label runat="server" CssClass="content12" id="lbleditmyprofile" EnableViewState="false" /><br />
                <asp:Label runat="server" CssClass="content12" id="lblmycookbooklink" EnableViewState="false" /><br />
                <asp:Label runat="server" CssClass="content12" id="lblmyfriendslistlink" EnableViewState="false" /><br />
                <asp:Label runat="server" CssClass="content12" id="lblmypminbox" EnableViewState="false" /><br />    
                <asp:Label runat="server" CssClass="content12" id="lblviewallmysubmittedrecipe" EnableViewState="false" /><br />
                <asp:Label runat="server" CssClass="content12" id="lblviewallmypublishedarticle" EnableViewState="false" />             
            </div>
       </div>
     </div>

       <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containermylinks">
            <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/friendlisticon_myaccount.gif" align="absmiddle" />&nbsp;<span class="content3">5 thành viên muốn làm bạn gần đây</span>
            </div>
            <div style="padding-right: 8px; padding-left: 8px; padding-top: 2px;">
            <asp:Label cssClass="content2" runat="server" id="lblcountwhoaddmeinfriendslist" />
            <asp:Repeater id="WhoAddsMe" runat="server">
               <ItemTemplate>
                <div class="dcnt2">
                <img src="images/user-icon.gif" />&nbsp;<a class="content2" onmouseover="Tip('<b><%# Eval("Username")%> </b> muốn bạn là bạn của họ<br>on:</b> <%# Eval("Date", "{0:M/d/yyyy}")%>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='userprofile.aspx?uid=<%# Eval("FriendID") %>'><%# Eval("Username")%></a>
                </div>
               </ItemTemplate>
          </asp:Repeater>
     </div>
       </div>
     </div>              
    </td>
    <td width="33%">
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
           <div class="containersitestat">
    <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
    <img src="images/stats_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Thống kê</span>
    </div>
    <div style="padding-right: 8px; padding-left: 8px; padding-top: 2px; line-height: 17px;">
     <asp:Label runat="server" id="lbltotalrecipe" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotalarticle" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotalrecipecomments" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotalarticlecomments" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotalsavedrecipeincookbook" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotaluserswhousecookbook" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotaluserswhousefriendslist" EnableViewState="false" /><br />
     <asp:Label runat="server" id="lbltotalprivatemessage" EnableViewState="false" />
    </div>
  </div>
        </div>
        
       <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containersitestat">
            <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/stats_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Thống kê thành viên</span>
            </div>
            <div style="padding-right: 8px; padding-left: 8px; padding-top: 2px; line-height: 18px;">
            <asp:Label runat="server" id="lbltotalRegisteredUsers" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lbltotaluserjoinedtoday" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lbltotaluserjoininaweek" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lbltotaluserjoinedinamonth" EnableViewState="false" /><br />
            </div>
       </div>
     </div> 
    </td>
    <td width="34%">
     <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <ucl:userconfigfetaures id="uprofilepanelconfig" runat="server"></ucl:userconfigfetaures>
     </div>
     
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containeruprofilepanel">
            <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/tools_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Cấu hình hiển thị</span>
            </div>
            <div style="padding-right: 8px; padding-left: 8px; padding-top: 2px;">
                <div style="padding: 7px;">
                    <asp:dropdownlist id="uconfigturnonofflayoutpagesize" runat="server" cssClass="ddl" Width="180px" AutoPostBack="false" >
                    <asp:Listitem Value="1">Cho ph&#233;p</asp:Listitem>
                    <asp:Listitem Value="0">Kh&#244;ng cho ph&#233;p</asp:Listitem>
                    </asp:dropdownlist>
                </div>
                <div style="padding: 7px;">
                    <asp:dropdownlist id="uconfigpreflayout" runat="server" cssClass="ddl" Width="180px" AutoPostBack="false">
                    <asp:Listitem Value="1">Hiển thị theo h&#224;ng</asp:Listitem>
                    <asp:Listitem Value="2">Hiển thị - 2 cột</asp:Listitem>
                    <asp:Listitem Value="3">Hiển thị - 3 cột</asp:Listitem>
                    </asp:dropdownlist>
                </div>
                <div style="padding: 7px;">
                    <asp:dropdownlist id="uconfigprefpagesize" runat="server" cssClass="ddl" Width="180px" AutoPostBack="false">
                    <asp:Listitem Value="10">10 b&#224;i h&#225;t một trang</asp:Listitem>
                    <asp:Listitem Value="20">20 b&#224;i h&#225;t một trang</asp:Listitem>
                    <asp:Listitem Value="30">30 b&#224;i h&#225;t một trang</asp:Listitem>
                    <asp:Listitem Value="40">40 b&#224;i h&#225;t một trang</asp:Listitem>
                    <asp:Listitem Value="50">50 b&#224;i h&#225;t một trang</asp:Listitem>
                    </asp:dropdownlist>
                </div>
                <div style="padding: 5px;">
                  <asp:Button ID="Sconfigbutonlayout" runat="server" cssClass="submitadmin" OnClick="UpdatePreferredLayoutPageSize_Click" Text="Nhớ cấu hình"  />&nbsp;<a class="thickbox content2" href="images/grid2columns_large.gif?keepThis=true&TB_iframe=true&height=600&width=750" target="_blank">Xem qua</a>
                </div>
            </div>
       </div>
     </div> 
    </td>
  </tr>
   <tr>
    <td width="33%">
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containermylinks" style="line-height: 21px;">
           <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/cookbookicon_smll2.gif" align="absmiddle" />&nbsp;<span class="content3">5 thành viên gần đây thêm bài hát bạn đăng vào mục yêu thích</span>
            </div>
            <div style="padding-left: 3px; padding-top: 3px; padding-bottom: 2px;">
            <asp:Label cssClass="content2" runat="server" id="lblcountuserswhosavedmyrecipe" />
            <asp:Repeater id="Last5UsersWhoSavedMyRecipe" runat="server">
               <ItemTemplate>
                <div class="dcnt2">
                    <img src="images/user-icon.gif" />&nbsp;
                    <a class="content2 thickbox" href="popupviewuserssavedlyricpublishedbyme.aspx?uid=<%# Eval("UID")%>&keepThis=true&TB_iframe=true&height=360&width=400" onmouseover="Tip('<b><%# Eval("Username")%> </b> added one of your published recipe<br>on:</b> <%# Eval("Date", "{0:M/d/yyyy}")%>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" ><%# Eval("Username")%></a>
                </div>
               </ItemTemplate>
          </asp:Repeater>
            </div>
       </div>
     </div>
    </td>
    <td width="33%">
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
           <div class="containersitestat">
            <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
                <img src="images/stats_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Thống kê bộ đếm</span>
            </div>
    <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <asp:Label runat="server" id="lblcountmysavedrecipe" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lblcountmyfriends" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lblpostedrecipecount" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lblpostedarticlecount" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lblcommentedrecipe" EnableViewState="false" /><br />
            <asp:Label runat="server" id="lblcommentarticle" EnableViewState="false" /><br />
  </div>
  </div>
  </div>
    </td>
    <td width="34%">
        <div style="margin-top: 5px; margin-left: 6px; margin-bottom: 16px;">
        <div class="containeruprofilepanel">
                    <div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
            <img src="images/tools_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Cấu hình tùy chọn tin nhắn</span>
            </div>
            <div style="padding-left: 3px; padding-top: 1px; padding-bottom: 3px;">
                <div style="padding: 7px;">
                    <asp:dropdownlist id="uconfigreceivepm" runat="server" cssClass="ddl" Width="154px" AutoPostBack="false" onmouseover="Tip('<b>Nhận tin nhắn</b> - Nếu bạn chọn cho phép, mọi người có thể gửi tin nhắn cho bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()">
                    <asp:Listitem Value="1">Cho ph&#233;p</asp:Listitem>
                    <asp:Listitem Value="0">Kh&#244;ng cho ph&#233;p</asp:Listitem>
                    </asp:dropdownlist>
                    <asp:Button ID="btnreceivepm" runat="server" cssClass="submitadmin" OnClick="UpdateReceivePM_Click" Text="Nhớ" onmouseover="Tip('<b>Nhận tin nhắn</b> - Nếu bạn chọn cho phép, mọi người có thể gửi tin nhắn cho bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" />
                </div>
                <div style="padding: 7px;">
                    <asp:dropdownlist id="uconfigreceivepmemailalert" runat="server" cssClass="ddl" Width="154px" AutoPostBack="false" onmouseover="Tip('<b>Thông báo khi có tin nhắn qua email</b> - Nếu bạn chọn cho phép,bạn sẽ<br>nhận được một email thông báo khi có một ai đó nhắn tin cho bạn', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()">
                    <asp:Listitem Value="1">Cho ph&#233;p</asp:Listitem>
                    <asp:Listitem Value="0">Kh&#244;ng cho ph&#233;p</asp:Listitem>
                    </asp:dropdownlist>
                    <asp:Button ID="btnepmmailalert" runat="server" cssClass="submitadmin" OnClick="UpdateReceivePMEmailAlert_Click" Text="Nhớ" onmouseover="Tip('<b>Thông báo khi có tin nhắn qua email</b> - Nếu bạn chọn cho phép,bạn sẽ<br>nhận được một email thông báo khi có một ai đó nhắn tin cho bạn', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" /></div>
       </div>
       </div>
     </div> 
    </td>
  </tr>
</table>
         </div>
      </asp:Panel>
     </div>
    </fieldset>
    </td>
      </tr>
    </table>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

