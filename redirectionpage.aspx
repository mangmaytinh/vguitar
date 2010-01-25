<%@ Page Language="C#" AutoEventWireup="true" CodeFile="redirectionpage.aspx.cs" Inherits="redirectionpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Trang liên kết</title>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
       <style type="text/css">
      body
      {
         font-family: Verdana, Arial, Serif;
         font-size: 12px;
      }
   </style>
</head>
<body>
<!--Begin Header-->
<div class="headerwrap">
<table border="0" cellpadding="0" cellspacing="0" width="97%">
  <tr>
   <td width="50%" rowspan="2" valign="top"><a title="thlb.biz" href="default.aspx"><img src="images/vguitar.jpg" border="0" alt="Thlb.biz" /></a></td>
    <td width="50%" align="right" valign="top">

</td>
  </tr>
  <tr>
    <td width="50%" align="right"><span class="chdate"><%=DateTime.Now.ToString("f")%></span></td>
  </tr>
</table>
</div>
<!--End Header-->
    <form id="form1" runat="server">
    <asp:Panel ID="PanelWelcomeBack" Visible="false" runat="server">
       <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
       <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #FF9900; font-size:x-large; margin-bottom: 10px; padding-bottom: 1px;"><asp:Label ID="lblwelcomeusername" runat="server" /></h1>
       Chúc bạn có những phút giây vui vẻ và bổ ích.
       <br />
       <br />
       Bạn hãy đợi 3 giây hệ thống sẽ tự động quay lại trang hiện thời.
       <br />
       <br />
       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="default.aspx" cssClass="content12">Quay lại trang chủ</asp:HyperLink>
       </div>
   </asp:Panel>
   <asp:Panel ID="PanelThankYouLogout" Visible="false" runat="server">
       <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
       <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #FF9900; font-size:x-large; margin-bottom: 10px; padding-bottom: 1px;">Cảm ơn bạn đã tham gia vào hệ thống</h1>
       Chúc bạn có những phút giây vui vẻ và bổ ích.
       <br />
       <br />
        Bạn hãy đợi 3 giây hệ thống sẽ tự động quay lại trang hiện thời.
       <br />
       <br />
       <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="default.aspx" cssClass="content12">Go to home page</asp:HyperLink>
       </div>
   </asp:Panel>
   <asp:Panel ID="PanelForJoining" Visible="false" runat="server">
        <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
        <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #FF9900; font-size:x-large; margin-bottom: 10px; padding-bottom: 1px;"><asp:Label ID="lblheader" runat="server" /></h1>
        <div style="margin-top: 10px;">
        <asp:Label cssClass="content12" ID="lblsuccess" runat="server" />
        <br />
        <br />
        <asp:Label cssClass="content12" ID="lblwait" runat="server" Visible="false" />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="default.aspx" cssClass="content12">Quay lại trang chủ</asp:HyperLink>
        </div>
        </div>
   </asp:Panel>
   <asp:Panel ID="PanelAccountSuspended" Visible="false" runat="server">
       <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
       <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #CC3300; font-size:x-large; margin-bottom: 8px; padding-bottom: 1px;">Đăng nhập thất bại - Tài khoản bị treo</h1>
       Tài khoản của bạn đã bị treo do vi phạm các điều khoản và thỏa thuận của chúng tôi.
       <br />
       Liên hệ với các trang web quản trị phục hồi tài khoản của bạn.
       <br />
       <br />
       Xin vui lòng chờ đợi, bạn sẽ được trở lại trang chủ trong 12 giây.
       <br />
       <br />
       <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="default.aspx" cssClass="content12">Quay lại trang chủ</asp:HyperLink>
       </div>
   </asp:Panel>
   <asp:Panel ID="PanelAccountNotActivated" Visible="false" runat="server">
       <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
       <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #CC3300; font-size:x-large; margin-bottom: 8px; padding-bottom: 1px;">Đăng nhập thất bại</h1>
       Tài khoản của bạn chưa được kích hoạt. Chúng tôi đã gửi cho bạn một email có chứa đường dẫn kích hoạt sau khi bạn đăng ký tài khoản mới.
       <br />
       Hãy kiểm tra email của bạn hoặc <a title="Gửi lại email của tôi kích hoạt." href="resendactivationemail.aspx">bấm vào đây</a> để gửi lại email kích hoạt của bạn.
       <br />
       nếu bạn vẫn không nhận được email kích hoạt, xin vui lòng liên hệ với các trang web của Administrator.
       <br />
       <br />
       Xin vui lòng chờ đợi, bạn sẽ được trở lại trang chủ trong 12 giây.
       <br />
       <br />
       <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="default.aspx" cssClass="content12">Quay lại trang chủ</asp:HyperLink>
        </div>
   </asp:Panel>
   <asp:Panel ID="PanelProfileUpdateSuccess" Visible="false" runat="server">
        <div style="margin-left: auto; margin-right: auto; width: 600px; border: solid 1px #ABD8FC; padding: 10px; margin-top: 100px;">
        <h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #FF9900; font-size:x-large; margin-bottom: 10px; padding-bottom: 1px;"><asp:Label ID="lblheaderupdateprofilesuccess" runat="server" /></h1>
        <div style="margin-top: 10px;">
        <asp:Label cssClass="content12" ID="lblupdateprofilemsg" runat="server" />
        <br />
        <br />
        <asp:Label cssClass="content12" ID="lblupdateprofilewait" runat="server" Visible="false" />
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="default.aspx" cssClass="content12">Quay lại trang chủ</asp:HyperLink>
        </div>
        </div> 
   </asp:Panel>
    </form>
</body>
</html>
