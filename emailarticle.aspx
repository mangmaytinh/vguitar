﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="emailarticle.aspx.cs" Inherits="emailarticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gửi bài viết <%=Request.QueryString["n"]%> đến bạn bè</title>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" Width="400">
<table align="center" cellspacing="0" cellpadding="0" width="100%">
<tr><td>
<br />
<div align="center"><h2>Đang gửi bài viết <%=Request.QueryString["n"]%> đến bạn bè</h2></div>
<table border="0" cellspacing="1" cellpadding="1" width="100%">
  <tr>
    <td valign="top" align="right" class="content6"><b><%= Resources.lang.Your_Name %>:</b></td>
    <td>
      <asp:TextBox id="txtFromName" width="180" cssClass="txtinput" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validNameRequired" ControlToValidate="txtFromName"
        cssClass="cred2" errormessage="* Chưa có:<br />"
        display="Dynamic" />
    </td>
  </tr>
  <tr>
    <td valign="top" align="right" class="content6"><b><%= Resources.lang.Your_Email %>:</b></td>
    <td>
      <asp:TextBox id="txtFromEmail" width="180" cssClass="txtinput" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validFromEmailRequired" ControlToValidate="txtFromEmail"
        cssClass="cred2" errormessage="* Chưa có:<br />"
        display="Dynamic" />
      <asp:RegularExpressionValidator runat="server"
        id="validFromEmailRegExp" ControlToValidate="txtFromEmail"
        ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$"
        cssClass="cred2" errormessage="không đúng định dạng"
        Display="Dynamic" />    
    </td>
  </tr>
<tr>
    <td valign="top" align="right" class="content6"><b>Tên của bạn bè:</b></td>
    <td>
      <asp:TextBox id="toname" width="180" cssClass="txtinput" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validFriendNameRequired" ControlToValidate="toname"
        cssClass="cred2" errormessage="* Chưa có:<br />"
        display="Dynamic" />
    </td>
  </tr>
  <tr>
    <td valign="top" align="right" class="content6"><b>Email bạn bè:</b></td>
    <td>
      <asp:TextBox id="txtToEmail" width="180" cssClass="txtinput" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validToEmailRequired" ControlToValidate="txtToEmail"
        cssClass="cred2" errormessage="* Chưa có:<br />"
        display="Dynamic" />
      <asp:RegularExpressionValidator runat="server"
        id="validToEmailRegExp" ControlToValidate="txtToEmail"
        ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil|biz)$"
        cssClass="cred2" errormessage="Không đúng định dạng:"
        Display="Dynamic" /> 
        <br />
        <asp:Button runat="server" Text="Bắt đầu gửi" id="Sendrec" cssClass="submit" OnClick="SendingArticle" /> 
    </td>
  </tr>
</table>
</td></tr>
</table>
</asp:Panel>
<br />
<br />
<asp:Label cssClass="content2" id="lblsentmsg" runat="server" />
    </div>
    </form>
</body>
</html>