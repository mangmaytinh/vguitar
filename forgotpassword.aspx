<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="forgotpassword" Title="Lấy lại mật khẩu" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
<ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-bottom: 12px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Trang chủ</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang ở mục: Lấy lại mật khẩu</span>
    </div> 
    <div style="margin-left: 15px;">   
    <table border="0" cellpadding="2" align="left" cellspacing="2" width="75%">
      <tr>
    <td width="68%">
    <fieldset><legend><asp:Label runat="server" id="passrecoveryheader" EnableViewState="false" /></legend>
     <div style="padding-top: 1px;">
     <div style="margin-top: 18px; margin-bottom: 8px;">
     <span class="content12">
     Nếu bạn quên mật khẩu của bạn, hãy nhập địa chỉ email bạn sử dụng khi bạn đăng ký để phục hồi nó.
     <br />
     Chúng tôi sẽ gửi cho bạn một email có chứa tên người dùng và mật khẩu của bạn.
     </span>
     </div>
     <span class="content12">Email:</span>
     <input type="text" id="useremailrecoverpass" name="useremailrecoverpass" onkeyup="LostPassKeyDown()" class="txtinput" size="30" runat="server" />&nbsp;<input type="button" id="passsubbutton" value="Chấp nhận" disabled="disabled" class="submitadmin" onClick="sendRequestLostPasswordTextPost()" />
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldEmail" ControlToValidate="useremailrecoverpass" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập địa chỉ email."
          display="Dynamic"> </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator id="RegularExpressionLostPassEmail" runat="server"
            ControlToValidate="useremailrecoverpass" SetFocusOnError="true"
            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Display="Static"
            cssClass="cred2">
 Địa chỉ email không hợp lệ. Địa chỉ email phải là một định dạng hợp lệ.
 </asp:RegularExpressionValidator>
     <div style="margin-top: 12px; margin-bottom: 2px;">
     <div id="idforresultslostpass"></div>
     </div>
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

