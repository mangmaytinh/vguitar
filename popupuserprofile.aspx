<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupuserprofile.aspx.cs" Inherits="popupuserprofile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thông tin cá nhân</title>
    <script type="text/javascript" src="js/rcipejs.js"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/CheckUserNameEmailAjax.js"></script>
    <script type="text/javascript" src="js/validator.js"></script>
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="js/alertbox.js"></script>
    <script type="text/javascript" src="js/thickbox-compressed.js"></script>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" /> 
   <link href="CSS/thickbox.css" rel="stylesheet" type="text/css" />
</head>
<body>
<script type="text/javascript" src="js/wz_tooltip.js"></script>
    <form id="form1" runat="server">
    <div style="margin-left: 25px; margin-right: 25px; margin-top: 15px;">
    <asp:Label runat="server" CssClass="content12" id="lbladdfriendsuccessmsg" Visible="false" EnableViewState="false" />
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="97%">
      <tr>
    <td width="68%">
    <fieldset><legend><asp:Label runat="server" id="lblusernameheader" EnableViewState="false" /></legend>
     <div style="padding-top: 1px;">
     <asp:Label runat="server" id="lblyouarenotauthorizedtoview" Visible="false" CssClass="content12" EnableViewState="false" />
     <asp:Panel ID="PanelIsProfilePublicOrPrivate" Visible="false" runat="server">
    <table border="0" cellpadding="4" align="left" cellspacing="2" width="60%">
      <tr>
        <td width="40%" valign="top">
        <div style="margin-top: 9px;">
        <asp:Image ID="userimage" Width="180" Height="130" runat="server"/>
        </div>
        <div style="margin-top: 15px; margin-bottom:12px;">
        <img src="images/iconaddfriend.gif" alt="add" />&nbsp;<asp:Label runat="server" CssClass="content2" Visible="false" id="lbladdtofriendslist" EnableViewState="false" /><asp:LinkButton id="LinkButtonAddfriendLogin" runat="server" CssClass="content2" Visible="false" OnClick="Add_Friend" EnableViewState="false" />
        </div> 
        
        <asp:Panel ID="MyFriendsListPanel" runat="server" Visible="false">     
        <div style="margin-top: 15px; margin-bottom:22px;">
        <img src="images/iconuser.gif" alt="user" /> <span class="content12" style="color:Black;"><b>Bạn bè của bạn</b> <asp:Label runat="server" CssClass="content2" ForeColor="#000000" id="lblmyfriendscount" EnableViewState="false" /></span>
        <br />
        <asp:Label runat="server" CssClass="content2" id="lblnofriends" EnableViewState="false" />
        <asp:Repeater id="MyFriendsList" runat="server" EnableViewState="false">
       <ItemTemplate>
        <div class="dcnt2">
        <span class="cyel">&raquo;</span> <a class="content2" title="Xem thông tin cá nhân của <%# Eval("Username") %>." onmouseover="Tip('<b>Tên tài khoản:</b> <%# Eval("Username") %><br><b>Tên đầy đủ:</b> <%# Eval("LastName") %> <%# Eval("FirstName") %> <br><b>Quốc tịch:</b> <%# Eval("Country") %><br><b>Số lần xem:</b> (<%# Eval("Hits") %>)<br><b>Ngày tạo:</b> <%# Eval("DateJoined", "{0:M/d/yyyy}")%><br><b>Lần ghé thăm cuối:</b> (<%# Eval("LastVisit") %>)<br>Added to Friends List on: <%# Eval("Date", "{0:M/d/yyyy}")%><br><b>Photo:</b><br><img src=&quot;UserImages/<%# Eval("Photo")%>&quot; width=&quot;160&quot; height=&quot;140&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("FriendID", "popupuserprofile.aspx?uid={0}") %>'><%# Eval("Username")%></a>
        </div>
       </ItemTemplate>
      </asp:Repeater>
        </div> 
        </asp:Panel> 
        
        <asp:Panel ID="MyCookBookPanel" runat="server" Visible="false">   
        <div style="margin-top: 18px;">
        <img src="images/cookbook.gif" alt="user" /> <span class="content12" style="color:Black;"><b>Mục yêu thích</b> <asp:Label runat="server" CssClass="content2" ForeColor="#000000" id="lblmycookbookcount" EnableViewState="false" /></span>
        <br />
        <asp:Label runat="server" CssClass="content2" id="lblnosavedrecipe" EnableViewState="false" />
        <asp:Repeater id="SavedUserCookBookProfile" runat="server" EnableViewState="false">
       <ItemTemplate>
        <div class="dcnt2">
        <span class="cyel">&raquo;</span> <a class="content2" title="View <%# Eval("LyricName") %> recipe" onmouseover="Tip('<b>Tên bài hát:</b> <%# Eval("LyricName") %><br><b>Tác giả:</b> <%# Eval("Author") %><br><b>Chuyên mục:</b> <%# Eval("Category") %><br><b>Số lần xem:</b> (<%# Eval("Hits") %>)<br><b>Đánh giá:</b> (<%# Eval("Rating") %>)<br><b>Lời bình:</b> (<%# Eval("Comments") %>)<br>Thêm vào mục yêu thích ngày: <%# Eval("Date", "{0:M/d/yyyy}")%><br><b>Photo:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("RecipeID", "printlyric.aspx?id={0}") %>'><%# Eval("LyricName")%></a>
        </div>
       </ItemTemplate>
      </asp:Repeater>
        </div>
        </asp:Panel>
        
        </td>
        <td width="60%" valign="top">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Tài khoản:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblusername" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Ngày đăng ký:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lbljoined" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Tên đầy đủ:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblfullname" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Ngày sinh:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lbldob" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Tỉnh/Thành phố:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblcity" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Vùng/Miền:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblstate" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Quốc Tịch:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblcountry" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Số lần xem:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblprofileviews" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Lần đăng nhập cuối:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lbllastlogin" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Lần cập nhật cuối:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lbllastupdate" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Bài hát chia sẻ:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblpostedrecipecount" EnableViewState="false" /></div></td>
    </tr>
        <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="contentpro"><b>Bài viết chia sẻ:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblpostedarticlecount" EnableViewState="false" /></div></td>
    </tr>
     <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Lời bình bài hát:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblcommentedrecipe" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Bài hát yêu thích 1:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblfavfood1" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Bài hát yêu thích 2:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblfavfood2" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Bài hát yêu thích 3:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblfavfood3" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Website:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblwebsite" EnableViewState="false" /></div></td>
    </tr>
    <tr>
        <td width="35%"><div style="margin-top: 9px;"><span class="content12"><b>Giấy thiệu bản thân:</b></span></div></td>
        <td width="60%" align="left"><div style="margin-top: 9px;"><asp:Label runat="server" CssClass="content12" id="lblaboutme" EnableViewState="false" /></div></td>
    </tr>

  </tr>
</table>
        </td>
</tr>
    </table>
    </asp:Panel>
     </div>
    </fieldset>
    </td>
      </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
