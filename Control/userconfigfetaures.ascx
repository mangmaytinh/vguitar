<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userconfigfetaures.ascx.cs" Inherits="userconfigfetaures" %>
<div class="containeruprofilepanel">
<div style="padding-left: 3px; padding-top: 8px; padding-bottom: 3px;">
<img src="images/tools_icon.gif" align="absmiddle" />&nbsp;<span class="content3">Cấu hình trang hồ sơ</span>
</div>
<div style="padding: 8px;">
<asp:dropdownlist id="uconfigshowhidecookbookddl" runat="server" cssClass="ddl" onmouseover="Tip('<b>Hiện</b> - Mọi người có thể<br>Nhìn thấy mục yêu thích của bạn.<br><b>Ẩn</b> - Chỉ có bạn mới nhìn thấy<br>Mục yêu thích của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" Width="154px" AutoPostBack="false">
<asp:Listitem Value="1">Hiện mục y&#234;u th&#237;ch</asp:Listitem>
<asp:Listitem Value="0">Ẩn mục y&#234;u th&#237;ch</asp:Listitem>
</asp:dropdownlist>
<asp:Button ID="Button2" runat="server" cssClass="submitadmin" OnClick="UpdateShowHideCookBook_Click" Text="Nhớ" onmouseover="Tip('<b>Hiện</b> - Mọi người có thể<br>Nhìn thấy mục yêu thích của bạn.<br><b>Ẩn</b> - Chỉ có bạn mới nhìn thấy<br>Mục yêu thích của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" />
</div>
<div style="padding: 8px;">
<asp:dropdownlist id="uconfigshowhidefriendslistddl" runat="server" cssClass="ddl" Width="154px" onmouseover="Tip('<b>Hiện</b> - Tất cả mọi người có thể<br>Nhìn thấy danh sách bạn bè của bạn.<br><b>Ẩn</b> - Chỉ có bạn mới có thể<br>Nhìn thấy danh sách bạn bè của bạn.<br>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" AutoPostBack="false">
<asp:Listitem Value="1">Hiện danh s&#225;ch bạn b&#232;</asp:Listitem>
<asp:Listitem Value="0">Ẩn danh s&#225;ch</asp:Listitem>
</asp:dropdownlist>
<asp:Button ID="Button1" runat="server" cssClass="submitadmin" OnClick="UpdateShowHideFriendsList_Click" Text="Nhớ" onmouseover="Tip('<b>Hiện</b> - Tất cả mọi người có thể<br>Nhìn thấy danh sách bạn bè của bạn.<br><b>Ẩn</b> - Chỉ có bạn mới có thể<br>Nhìn thấy danh sách bạn bè của bạn.<br>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" />
</div>
<div style="padding: 8px;">
<asp:dropdownlist id="uconfigfriendslistddl" runat="server" cssClass="ddl" onmouseover="Tip('Cấu hình có bao nhiêu người xuất hiện trên <b>Danh sách bạn bè</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" Width="154px" AutoPostBack="false">
</asp:dropdownlist>
<asp:Button ID="Sconfigbuton1" runat="server" cssClass="submitadmin" OnClick="UpdateNumRecordsFriendsList_Click" Text="Nhớ" onmouseover="Tip('Cấu hình có bao nhiêu người xuất hiện trên <b>Danh sách bạn bè</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" />
</div>
<div style="padding: 8px;">
<asp:dropdownlist id="uconfigcookbookddl" runat="server" cssClass="ddl" onmouseover="Tip('Cấu hình có bao nhiêu bài hát hợp âm trong mục<b>Yêu thích</b>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" Width="154px" AutoPostBack="false">
</asp:dropdownlist>
<asp:Button ID="Sconfigbuton2" runat="server" cssClass="submitadmin" OnClick="UpdateNumRecordsCookBook_Click" Text="Nhớ" onmouseover="Tip('Cấu hình có bao nhiêu bài hát hợp âm trong mục<b>Yêu thích</b>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')"  onmouseout="UnTip()" />
</div>
</div>
