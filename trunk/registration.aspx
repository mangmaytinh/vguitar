<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" Title="Đăng ký tài khoản" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="CalendarDatePicker" Src="Control/DatePicker.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Trang chủ</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang trong mục: Đăng ký tài khoản sử dụng</span>
    </div>
    <div style="margin-left: 15px;">
    <!--Begin Insert Lyric Form-->
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="95%">
      <tr>
    <td width="68%">
    <div style="padding: 2px; text-align: left; margin-left: 1px; margin-right: 26px;">
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" /> 
    </div>
    <fieldset><legend>Đăng ký tài khoản</legend>
     <div style="padding-top: 25px;">
     <asp:Label ID="lblWarningMessage" runat="server" CssClass="content12" Visible="false" EnableViewState="false" />
     <asp:Panel ID="HideFormIfLogin" runat="server">
     <div style="margin-top: 1px; margin-bottom: 20px;">
    <span class="content2">Các trường có dấu hoa thị đỏ (<span class="cred2">*</span>) là bắt buộc phải có</span>
    </div>
    <table border="0" cellpadding="2" align="left" cellspacing="2" width="80%">
      <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Tài khoản:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">  
    <input type="text" id="Username" name="Username" class="txtinput" size="20" runat="server" onkeypress="return LetterNumberDashUnderscoreOnly(event)" onkeyup="UnameKeyDown()" onmouseover="Tip('Tên người dùng phải có ít nhất 6 ký tự và lớn nhất 15 ký tự <br>, và nên chỉ <br> chứa các chữ cái, số, gạch ngang hoặc gạch dưới.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFBE1'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;<span id="idforresults"></span>
    <br />
    <input type="button" id="subbutton" value="Kiểm tra tính sẵn sàng" title="Kiểm tra nếu tên người dùng có sẵn." disabled="disabled" class="submitadmin" onClick="sendRequestTextUsernamePost()" />&nbsp;
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldUname" ControlToValidate="Username" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Tên đăng nhập không có"
          display="Dynamic"></asp:RequiredFieldValidator>
          </div>
    </td>
      </tr>
      
            <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Mật khẩu:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="password" id="Password1" name="Password1" class="txtinput" size="20" runat="server" onclick="ValUsername()" onkeyup="PassKeyDown()" onmouseover="Tip('Mật khẩu phải có ít nhất 6 ký tự và lớn nhất 12 ký tự <br>, và nên chỉ <br> chứa các chữ cái Bảng chữ cái và số.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFBE1'" onBlur="this.style.backgroundColor='#ffffff', ValPassword1()" />&nbsp;<span id="passwordval"></span>
           <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldPassword1" ControlToValidate="Password1" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Mật khẩu không có"
          display="Dynamic"> </asp:RequiredFieldValidator>
   </div>
    </td>
      </tr>
      
             <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Nhập lại mật khẩu:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="password" id="Password2" name="Password2" class="txtinput" size="20" runat="server" onkeyup="PassKeyDown()" onmouseover="Tip('Mật khẩu phải có ít nhất 6 ký tự và lớn nhất 12 ký tự <br>, và nên chỉ <br> chứa các chữ cái Bảng chữ cái và số.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFBE1'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;<span id="repeatpass"></span>
               <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldPassword2" ControlToValidate="Password2" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Mât khẩu nhập lại chưa có"
          display="Dynamic"> </asp:RequiredFieldValidator>
          </div>
    </td>
      </tr>
      
               <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Email:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="Email" name="Email" class="txtinput" size="30" runat="server" onclick="CheckIfPasswordMatch()" onkeyup="EmailKeyDown()" onmouseover="Tip('Email không được vượt quá 45 ký tự.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;<span id="idforresultsemail"></span>
        <br />
    <input type="button" id="subbutemail" value="Xác nhận Email" title="Kiểm tra nếu email đã có trong sử dụng. Không thể sử dụng cùng một thư điện tử." disabled="disabled" class="submitadmin" onClick="sendRequestEmailTextPost()" />&nbsp;
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldEmail" ControlToValidate="Email" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Email chưa có"
          display="Dynamic"> </asp:RequiredFieldValidator>
     </div>
    </td>
      </tr>
      
       <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Tên bạn:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="Firstname" name="Firstname" class="txtinput" size="20" runat="server" onkeypress="return LetterOnly(event)" onkeyup="FirstLastnameKeyDown()" onclick="ValEmail()" onmouseover="Tip('Tên của bạn nên chứa các chữ cái <br> và không thể chứa số.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;<span id="resultfirstname"></span>
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldFirstname" ControlToValidate="Firstname" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Tên bạn chưa có"
          display="Dynamic"> </asp:RequiredFieldValidator>
 </div>
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Tên họ,tên đệm:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="Lastname" name="Lastname" class="txtinput" size="20" runat="server" onkeypress="return LetterOnly(event)" onkeyup="FirstLastnameKeyDown()" onclick="ValFirstname()" onmouseover="Tip('Tên họ của bạn nên chứa các chữ cái <br> và không thể chứa số..', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;<span id="resultlastname"></span>
              <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldLastname" ControlToValidate="Lastname" SetFocusOnError="true"
          cssClass="cred2"
          ErrorMessage = "Tên họ chưa có"
          display="Dynamic"> </asp:RequiredFieldValidator>
 </div>
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Tỉnh/Thành phố:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="City" name="City" class="txtinput" size="20" onclick="ValLastname()" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Vùng/Miền:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="State" name="State" class="txtinput" size="20" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
       <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Country:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <asp:DropDownList id="Country" runat="server" onchange="ValLastname()" cssClass="ddl" AutoPostBack="false">
        <asp:Listitem Value="none" Selected=True>Chọn một Quốc Tịch</asp:Listitem>
    </asp:DropDownList>
              <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldCountry" ControlToValidate="Country" SetFocusOnError="true"
          cssClass="cred2"
          InitialValue="none"
          ErrorMessage = "Quốc tịch chưa chọn"
          display="Dynamic"> </asp:RequiredFieldValidator>
    </div>
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Ngày sinh:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
        <ucl:CalendarDatePicker ID="Date1" runat="server" />
        </div>
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Bài hát yêu thích 1:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="FavoriteFoods1" name="FavoriteFoods1" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Bài hát yêu thích 2:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="FavoriteFoods2" name="FavoriteFoods2" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
         <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Bài hát yêu thích 3:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="FavoriteFoods3" name="FavoriteFoods3" class="txtinput" size="25" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Bản tin:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <asp:dropdownlist id="Newsletter" runat="server" cssClass="ddl" AutoPostBack="false">
    <asp:Listitem Value="1" selected>Nhận bản tin</asp:Listitem>
    <asp:Listitem Value="0">Không nhận bản tin</asp:Listitem>
    </asp:dropdownlist>
    </div>
    </td>
      </tr>
      
       <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Liên hệ:</span><span class="cred2">*</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <asp:dropdownlist id="ContactMe" runat="server" cssClass="ddl" AutoPostBack="false">
    <asp:Listitem Value="1" selected>Cho phép liên hệ qua email</asp:Listitem>
    <asp:Listitem Value="0">Không cho phép liên hệ qua email</asp:Listitem>
    </asp:dropdownlist>
    </div>
    </td>
      </tr>
      
        <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Website:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <input type="text" id="Website" name="Website" class="txtinput" size="35" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
    </div>
    </td>
      </tr>
      
      
      <tr>
        <td width="15%" valign="top"><div style="margin-bottom: 6px"><span class="content12">Giấy thiệu bản thân:</span></div></td>
        <td width="74%" valign="top">
        <div style="margin-bottom: 6px">
    <textarea runat="server" id="AboutMe" class="textbox" textmode="multiline" cols="60" rows="10" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
    </div>
    </td>
      </tr>

        <tr>
        <td width="15%"><span class="content12">Ảnh hồ sơ:<br />(Không bắt buộc)</span></td>
        <td width="74%">
    <asp:FileUpload ID="UserImageFileUpload" runat="server" />&nbsp;<span class="content2"><br />Kích thước của ảnh tối đa là 200 x 200 và ít hơn 20.000 byte.</span>
    </td>
      </tr>
      <tr>
        <td width="15%"></td>
        <td width="74%">
    <input type="text" class="txtinput" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <br />
    <span class="content2">Mã bảo mật:</span>
    <br />
    <img height="30" alt="" src="imgsecuritycode.aspx" width="80"> 
    <br />
      <asp:Label ID="lblinvalidsecode" cssClass="cred2" runat="server" visible="false" />
     <asp:TextBox ID="txtsecfield" Cssclass="txtinput" runat="server" Width="70"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server"
          id="reqSec" ControlToValidate="txtsecfield"
          cssClass="cred2"
          ErrorMessage = "Chưa nhập mã bảo mật"
          display="Dynamic"> </asp:RequiredFieldValidator>
    <br /><br />
<asp:ValidationSummary
ID="ValidationSummary1"
runat="server"
EnableClientScript="true"
ShowMessageBox="true"
ShowSummary="false"
HeaderText="Các lĩnh vực sau đây cần được quan tâm:" />
    <asp:Button runat="server" Text="Đăng ký" id="AddComments" cssClass="submitadmin" OnClick="Add_User" />
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

