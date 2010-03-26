<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="popupviewuserssavedlyricpublishedbyme.aspx.cs" Inherits="popupviewuserssavedlyricpublishedbyme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>25 bài hát tiêu biểu đã được bạn chia sẻ và nhớ vào mục yêu thích</title>
        <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label runat="server" id="lblyouarenotlogin" Visible="false" CssClass="content12" EnableViewState="false" />
     <asp:Panel ID="HideContentIfNotLogin" runat="server">
        <div style="margin-bottom: 8px; margin-top: 8px;">
        <span class="content2"><b>T25 bài hát tiêu biểu đã được bạn chia sẻ và nhớ vào mục yêu thích</b></span>
     </div>
        <asp:Repeater id="UserSavedRecipeCookBookPublishedByme" runat="server">     
        <ItemTemplate>
            <div class="dcnt2" style="margin-top: 2px;">
             <span class="content2"><a title="View this recipe" href="lyricdetail.aspx?id=<%# Eval("RecipeID")%>" class="content2" target="_blank"><%# Eval("LyricName")%></a> thêm vào mục yêu thích ngày: <%# Eval("Date", "{0:M/d/yyyy}")%></span>
            </div>         
       </ItemTemplate>
    </asp:Repeater>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
