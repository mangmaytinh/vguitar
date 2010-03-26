<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Control.Login" %>
<div class="loginerrmsgwrapper">
<asp:Label runat="server" CssClass="InvalidCred" id="Lblinvalidcredential" Visible="False" EnableViewState="False" Text="Thông tin đăng nhập không đúng.<br>Hãy kiểm tra lại" />
 <asp:RequiredFieldValidator id="RequiredFieldValidatorUnameMain"
      controltovalidate="uname"
      CssClass="InvalidCred"
      validationgroup="LoginGroup"
      errormessage="Tài khoản không được để rỗng"
      runat="Server"></asp:requiredfieldvalidator>
     <asp:RequiredFieldValidator id="RequiredFieldValidatorUPassMain"
      controltovalidate="upass"
      CssClass="InvalidCred"
      validationgroup="LoginGroup"
      errormessage="Mật khẩu không được để rỗng"
      runat="Server"></asp:requiredfieldvalidator>
</div>
<asp:Panel ID="loginpanel" runat="server" Width="329px">
<div class="loginboxlabelwrapper">
    <table border="0">
        <tr>
            <td style="width: 100px;">
                <span class="content2">Tài khoản</span></td>
            <td style="width: 100px;">
                <span class="content2">Mật khẩu</span></td>
            <td style="width: 189px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
<asp:TextBox ID="uname" cssClass="textboxsearch" TextMode=SingleLine Width="104px" Text="" runat="server" ToolTip="Enter username" /></td>
            <td style="width: 100px">
                <asp:TextBox ID="upass" cssClass="textboxsearch" TextMode=Password Text="password" Width="104px" runat="server" ToolTip="Enter password" /></td>
            <td style="width: 189px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px; text-align: right">
                <asp:Button ID="usubmit" runat="server" OnClick="Login_Click" cssClass="submitadmin" Text="Đăng nhập" causesvalidation="true" validationgroup="LoginGroup" /></td>
            <td style="width: 189px">
            </td>
        </tr>
        <tr>
            <td colspan="3">
<input type="checkbox" name="rememberme" id="rememberme" value="1" checked runat="server" /><span class="content2"> Nhớ mật khẩu? &nbsp;<a href="forgotpassword.aspx" title="Nhấn vào để yêu cầu lấy lại mật khẩu." onmouseover="Tip('Nếu bạn quên mật khẩu,<br>Thì nhấn vào đây để lấy lại.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db', ABOVE, true)" onmouseout="UnTip()">Quên mật khẩu</a>&nbsp;|&nbsp;<a href="registration.aspx" title="Nhấn vào đây để đăng ký." onmouseover="Tip('Nếu bạn chưa đăng ký tài khoản,<br>Nhấn vào đây để đăng ký là một thành viên.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db', ABOVE, true)" onmouseout="UnTip()">Đăng ký</a></span>
            </td>
        </tr>
    </table>
</div>
<div class="contrememberme">
    &nbsp;</div>
</asp:Panel>
<asp:Panel Visible="false" ID="DisplayUserInfo" runat="server" style="margin-top: 30px;">
<asp:Label cssClass="content01" runat="server" Visible="false" id="lblnewfriendalert" /><asp:Label cssClass="content01" runat="server" Visible="false" id="lblPrivateMessageAlert" /><asp:Label cssClass="content12" runat="server" id="lblusername" />&nbsp;&nbsp;<asp:Button ID="Buttonlogout" runat="server" OnClick="Logout_Click" cssClass="submitadmin" Text="Thoát" /></asp:Panel>
