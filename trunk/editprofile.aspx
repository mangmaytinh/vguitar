<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="editprofile.aspx.cs" Inherits="editprofile" Title="Sửa thông tin cá nhân" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="CalendarDatePicker" Src="Control/DatePicker.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Trang chủ</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang ở trang: Sửa thông tin cá nhân</span>
    </div>
    <div style="margin-left: 15px;">
    <!--Begin Insert Lyric Form-->
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="95%">
      <tr>
    <td width="68%">
    <div style="padding: 2px; text-align: left; margin-left: 1px; margin-right: 26px;">
    <br />
    <span class="content2">Các trường đánh dấu bằng dấu hoa thị đỏ (*) là bắt buộc</span>
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" /> 
    </div>
    <fieldset><legend><asp:Label ID="lbllegendheader" runat="server" EnableViewState="false" /></legend>
     <div style="padding-top: 1px;">
     <asp:Label ID="lblWarningMessage" runat="server" CssClass="content12" Visible="true" EnableViewState="false" />
     <asp:Panel ID="HideFormIfLogin" runat="server">
     <div style="margin-bottom: 16px; margin-top: 12px;"><span class="content2"><b>Chú thích:</b>&nbsp;Nếu bạn không muốn thay đổi mật khẩu của bạn hoặc địa chỉ email. Chỉ cần để lại giá trị mặc định về mật khẩu và email.</span></div>
    <table border="0" cellpadding="2" align="left" cellspacing="2" width="80%">
            <tr>
        <td width="15%" valign="top"><span class="content12">Mật khẩu:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Password1" name="Password1" class="txtinput" size="20" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
           <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldPassword1" ControlToValidate="Password1" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập mật khẩu."
          display="Dynamic"> </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator id="RegularExpressionPassword1" runat="server"
            ControlToValidate="Password1" SetFocusOnError="true"
            ValidationExpression="\w{6,12}"
            Display="Static"
            cssClass="cred2">
 Mật khẩu phải có ít nhất 6 ký tự và lớn nhất 12 ký tự, và nên chứa chữ số.
 </asp:RegularExpressionValidator>  
    </td>
      </tr>
      
             <tr>
        <td width="15%" valign="top"><span class="content12">Nhập lại mật khẩu:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Password2" name="Password2" class="txtinput" size="20" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
               <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldPassword2" ControlToValidate="Password2" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập lại mật khẩu."
          display="Dynamic"> </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator id="RegularExpressionPassword2" runat="server"
            ControlToValidate="Password2" SetFocusOnError="true"
            ValidationExpression="\w{6,12}"
            Display="Static"
            cssClass="cred2">
 Mật khẩu phải có ít nhất 6 ký tự và lớn nhất 12 ký tự, và nên chứa chữ số..
 </asp:RegularExpressionValidator> 
    </td>
      </tr>
      
               <tr>
        <td width="15%" valign="top"><span class="content12">Email:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Email" name="Email" class="txtinput" size="25" runat="server" onkeyup="EmailKeyDown()" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;&nbsp;<span id="progressemail"></span>&nbsp;<span id="idforresultsemail"></span>
        <br />
    <input type="button" id="subbutemail" value="Kiểm tra email" title="Kiểm tra nếu email đã có trong sử dụng. Không thể sử dụng cùng một thư điện tử." disabled="disabled" class="submitadmin" onClick="sendRequestEmailTextPost()" />&nbsp;
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldEmail" ControlToValidate="Email" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập địa chỉ Email vào."
          display="Dynamic"> </asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator id="RegularExpressionEmail" runat="server"
            ControlToValidate="Email" SetFocusOnError="true"
            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Display="Static"
            cssClass="cred2">
 Địa chỉ email không hợp lệ. Địa chỉ email phải là một định dạng hợp lệ.
 </asp:RegularExpressionValidator>
 <div style="margin-top: 12px;"></div>
    </td>
      </tr>
      
                   <tr>
        <td width="15%" valign="top"><span class="content12">Tên:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Firstname" name="Firstname" class="txtinput" size="20" runat="server" onkeypress="return LetterOnly(event)" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldFirstname" ControlToValidate="Firstname" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập tên của bạn vào."
          display="Dynamic"> </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="RegularExpressionFirstname" runat="server"
            ControlToValidate="Firstname" SetFocusOnError="true"
            ValidationExpression="^[a-zA-Z ]+$"
            Display="Static"
            cssClass="cred2">
 Tên phải được nhập từ bảng chữ cái, và không chứa ký tự đặc biệt
 </asp:RegularExpressionValidator> 
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><span class="content12">Họ và tên đệm:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Lastname" name="Lastname" class="txtinput" size="20" runat="server" onkeypress="return LetterOnly(event)" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
              <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldLastname" ControlToValidate="Lastname" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Hãy nhập họ và tên đệm vào."
          display="Dynamic"> </asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator id="RegularExpressionLastname" runat="server"
            ControlToValidate="Lastname" SetFocusOnError="true"
            ValidationExpression="^[a-zA-Z ]+$"
            Display="Static"
            cssClass="cred2">
 Tên họ và đệm phải được nhập từ bảng chữ cái, và không có ký tự nào đặc biệt.
 </asp:RegularExpressionValidator> 
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><span class="content12">Tỉnh/Thành phố:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="City" name="City" class="txtinput" size="20" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    <br /><br />
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><span class="content12">Vùng/Miền:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="State" name="State" class="txtinput" size="20" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    <br /><br />
    </td>
      </tr>
      
       <tr>
        <td width="15%" valign="top"><span class="content12">Quốc tịch:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <asp:DropDownList id="Country" runat="server" cssClass="ddl" AutoPostBack="false">
    </asp:DropDownList>
    <br /><br />
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><span class="content12">Ngày sinh:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
        <ucl:CalendarDatePicker ID="Date1" runat="server" />
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><span class="content2">Bài hát yêu thích 1:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="FavoriteFoods1" name="FavoriteFoods1" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    <br /><br />
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><span class="content12">Bài hát yêu thích 2:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="FavoriteFoods2" name="FavoriteFoods2" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    <br /><br />
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><span class="content12">Bài hát yêu thích 3:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="FavoriteFoods3" name="FavoriteFoods3" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    <br /><br />
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><span class="content12">Bản tin:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <asp:dropdownlist id="Newsletter" runat="server" cssClass="ddl" AutoPostBack="false">
    <asp:Listitem Value="1" selected>Có nhận bản tin</asp:Listitem>
    <asp:Listitem Value="0">Không nhận bản tin</asp:Listitem>
    </asp:dropdownlist>
    <br /><br />
    </td>
      </tr>
      
       <tr>
        <td width="15%" valign="top"><span class="content12">Liên lạc:</span><span class="cred2">*</span></td>
        <td width="74%" valign="top">
    <asp:dropdownlist id="ContactMe" runat="server" cssClass="ddl" AutoPostBack="false">
    <asp:Listitem Value="1" selected>Cho phép mọi người email tới bạn</asp:Listitem>
    <asp:Listitem Value="0">Không cho phép mọi người email tới bạn</asp:Listitem>
    </asp:dropdownlist>
    <br /><br />
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><span class="content12">Website:</span></td>
        <td width="74%" valign="top">
    <input type="text" id="Website" name="Website" class="txtinput" size="35" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </td>
      </tr>
          
      <tr>
        <td width="15%" valign="top"><span class="content2">Giấy thiệu về bản thân:</span></td>
        <td width="74%" valign="top">
    <textarea runat="server" id="AboutMe" class="textbox" textmode="multiline" cols="60" rows="10" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
    </td>
      </tr>

        <tr>
        <td width="15%"><span class="content12">Ảnh cá nhân:<br />(Không cần thiết)</span></td>
        <td width="74%">
        <div style="margin-top: 9px;">
        <asp:Image ID="userimageedit" Width="180" Height="130" runat="server"/>
        </div>
    <asp:FileUpload ID="UserImageFileUpload" runat="server" />&nbsp;<span class="content2"><br />Hình kích thước tối đa là 200 x 200 và ít hơn 20.000 byte.
    <b> Lưu ý: </ b> Nếu bạn không muốn cập nhật ảnh của bạn, chỉ cần bỏ trống.
    </span>
    </td>
      </tr>
      <tr>
        <td width="15%"></td>
        <td width="74%">
    <input type="text" class="txtinput" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <br />
    <asp:Button runat="server" Text="Submit" id="AddComments" cssClass="submitadmin" OnClick="Update_User" />
    </td>
      </tr>
    </table>
    </asp:Panel>
     </div>
    </fieldset>
    </td>
      </tr>
    </table>
    </asp:PlaceHolder>
    </div>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    <!--End Insert Lyric Form-->
</asp:Content>

