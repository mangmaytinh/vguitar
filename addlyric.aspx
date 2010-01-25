<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="addlyric.aspx.cs" Inherits="addlyric" Title="Chia sẻ lời bài hát" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <!-- TinyMCE -->
<script type="text/javascript" src="tinymce_editor/tiny_mce.js"></script>
<script type="text/javascript">
	tinyMCE.init({
		// General options
		editor_deselector : "mceNoEditor",
		mode : "textareas",
		theme : "advanced",
		plugins : "safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,inlinepopups",

		// Theme options
		theme_advanced_buttons1 : "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
		theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
		theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
		theme_advanced_buttons4 : "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
		theme_advanced_toolbar_location : "top",
		theme_advanced_toolbar_align : "left",
		theme_advanced_statusbar_location : "bottom",
		theme_advanced_resizing : true,

		// Example word content CSS (should be your site CSS) this one removes paragraph margins
		content_css : "CSS/word.css",

		// Drop lists for link/image/media/template dialogs
		template_external_list_url : "lists/template_list.js",
		external_link_list_url : "lists/link_list.js",
		external_image_list_url : "lists/image_list.js",
		media_external_list_url : "lists/media_list.js",

		// Replace values for the template plugin
		template_replace_values : {
			username : "Some User",
			staffid : "991234"
		}
	});
</script>
<!-- /TinyMCE -->
<!--[if gte IE 5]>
<style>
.textboxsearch {height: 17px;}
.contrememberme {margin-top: 0px;}
#b2 ul a {height: 1.2em;}
#b2 li {float: left; clear: both; width: 100%;}
fieldset {background: #ffffff;}
</style>
<![endif]-->

    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:newestarticle id="nart" runat="server"></ucl:newestarticle>
    <br />
    <ucl:rsssidemenu id="rsscont" runat="server"></ucl:rsssidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Quay lại trang chủ"><%=Resources.lang.Home %></a>&nbsp;<span class="bluearrow">»</span>&nbsp;<a href="submitrecipecategory.aspx" class="dsort" title="Back to recipe submit category listing">Thêm mới hợp âm bài hát</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">Bạn đang ở mục chia sẻ hợp âm,lời bài hát</span>
    </div>
    <div style="margin-left: 10px; margin-top: 20px;">
    <!--Begin Insert Lyric Form-->
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="98%">
      <tr>
    <td width="68%">
    <div style="padding: 2px; text-align: left; margin-left: 1px; margin-right: 26px;">
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" /> 
    </div>
    <fieldset><legend>Hãy nhập thông tin về bài hát</legend>
     <div style="margin-top: 20px;">
     <asp:Label ID="lblwarning" runat="server" cssClass="content12" Visible="false" EnableViewState="false" />
     <asp:Panel ID="Panel3" runat="server">
         <div style="padding: 2px; margin-bottom: 15px; margin-left: 1px; margin-right: 26px;">
        <span class="content2">Những mục có giấu (<span class="cred2">*</span>) là bắt buộc phải có.</span> 
    </div>
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="76%"> 
     <tr>
        <td width="4%"><span class="content12">Tên tài khoản:</span></td>
        <td width="102%">
    <input type="hidden" id="Author" name="Author" size="25" class="textbox" runat="server" />
    <asp:Label ID="lblusername" runat="server" cssClass="cmaron" EnableViewState="false" />
    </td>
      </tr>
      <tr>
        <td width="26%"><span class="content12">Phân loại:</span></td>
        <td width="74%">
<asp:dropdownlist id="CategoryID" runat="server" cssClass="cselect" AutoPostBack="false"></asp:dropdownlist>
    </td>
      </tr>
      <tr>
        <td width="26%"><div style="margin-top: 8px;"><span class="content12">Tên bài hát:</span><span class="cred2">*</span></div></td>
        <td width="74%">
        <div style="margin-top: 8px;">
    <input type="text" id="Name" name="Name" class="txtinput" size="50" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="Recipename" ControlToValidate="Name"
            cssClass="cred2" errormessage="* Nhập tên bài hát vào:<br />"
            display="Dynamic" />
            </div>
    </td>
      </tr>
      <tr>
        <td width="26%" valign="top"><div style="margin-top: 8px;"><span class="content12">Hợp âm /lời bài hát:</span><span class="cred2">*</span></div></td>
        <td width="74%">
        <div style="margin-top: 8px;">
    <textarea runat="server" id="Ingredients" class="textbox" textmode="multiline" cols="75" rows="30" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="RecIngred" ControlToValidate="Ingredients"
            cssClass="cred2" errormessage="* Hãy nhập nội dung hợp âm vào đây:<br />"
            display="Dynamic" />
            </div>
    </td>
      </tr>
      <tr>
        <td width="26%" valign="top"><div style="margin-top: 12px;"><span class="content12">Ghi chú:</span><span class="cred2">*</span></div></td>
        <td width="74%">
        <div style="margin-top: 8px;">
    <textarea runat="server" id="Instructions" class="textbox" textmode="multiline" cols="75" rows="32" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="RecInstruc" ControlToValidate="Instructions"
            cssClass="cred2" errormessage="* Hãy nhập ghi chú của bạn vào đây:<br />"
            display="Dynamic" />
            </div>
    </td>
      </tr>
        <tr>
        <td width="26%" valign="top"><span class="content12">Ảnh:<br />(Không bắt buộc)</span></td>
        <td width="74%">
    <asp:FileUpload ID="RecipeImageFileUpload" runat="server" />&nbsp;<span class="content2"><br />Kích thước tối đa của ảnh là 200 x 200 và không lớn hơn 20,000 bytes.</span>
    </td>
      </tr>
      <tr>
        <td width="26%"></td>
        <td width="74%" align="left">
    <input type="text" class="textbox" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <div style="text-align: left;">
    <asp:Button runat="server" Text="Chia sẻ hợp âm / lời bài hát" id="AddComments" cssClass="submitadmin" OnClick="Add_Recipe" />
    </div> 
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
    <script type="text/javascript" src="js/wz_tooltip.js"></script>
</asp:Content>

