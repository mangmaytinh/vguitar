<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="editlyric.aspx.cs" Inherits="editlyric" Title="Sửa hợp âm" %>
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
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Home</a><span class="bluearrow">»</span>&nbsp;<span class="content2">You are here: Editting Lyric Form</span>
    </div>
    <div style="margin-left: 10px;">
    <!--Begin Insert Lyric Form-->
        <%--<asp:PlaceHolder id="PlaceHolder1" runat="server">--%>
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="100%">
      <tr>
    <td style="width: 66%">
    <div style="padding: 2px; text-align: left; margin-left: 1px; margin-right: 26px;">
    <br />
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" /> 
    </div>
    <fieldset><legend>Editing a Lyric</legend>
     <div style="padding-top: 20px;">
     <asp:Label runat="server" id="lblyouarenotlogin" Visible="false" CssClass="content12" EnableViewState="false" />
     <asp:Panel ID="HideContentIfNotLogin" Visible="false" runat="server" Width="935px">
     <div style="padding: 2px; margin-bottom: 15px; margin-left: 1px; margin-right: 26px;">
        <span class="content2">Fields mark with red asterisk (<span class="cred2">*</span>) are required.</span> 
    </div>
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="90%">
     <tr>
        <td style="width: 200px"><span class="content12">Người đăng bài:</span></td>
        <td style="width: 60%">
    <input type="hidden" id="Author" name="Author" size="25" class="textbox" runat="server" />
    <input type="hidden" id="Hits" name="Hits" size="25" class="textbox" runat="server" />
    <asp:Label ID="lblusername" runat="server" cssClass="cmaron" EnableViewState="false" />
    </td>
      </tr>
      <tr>
        <td style="width: 200px"><span class="content12">Chuyên mục:</span></td>
        <td style="width: 60%">
   <asp:dropdownlist id="CategoryID" runat="server" cssClass="cselect" AutoPostBack="false"></asp:dropdownlist>&nbsp;<img src="images/help.gif" align="absmiddle" border="0" onmouseover="Tip('<b>Note:</b> If you dont want to change category, do not select anything.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" />
    </td>
      </tr>
      <tr>
        <td style="width: 200px; height: 29px;"><div style="margin-top: 8px;"><span class="content12">Tên bài hát:</span><span class="cred2">*</span></div></td>
        <td style="width: 60%; height: 29px;">
        <div style="margin-top: 8px;">
    <input type="text" id="Name" name="Name" class="txtinput" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" style="width: 375px" />
          <asp:RequiredFieldValidator runat="server"
            id="Recipename" ControlToValidate="Name"
            cssClass="cred2" errormessage="* Lyric Name:<br />"
            display="Dynamic" />
            </div>
    </td>
      </tr>
        <tr>
            <td style="width: 200px">
                <span style="font-size: 9pt; color: #595959; font-family: Verdana">Đường dẫn nhạc:</span></td>
            <td style="width: 60%"><input type="text" id="UrlMusic" name="UrlMusic" class="txtinput" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" style="width: 375px" /></td>
        </tr>
        <tr>
            <td style="width: 200px">
                <span style="font-size: 9pt; color: #595959; font-family: Verdana">Đường dẫn Chacha:</span></td>
            <td style="width: 60%"><input type="text" id="UrlChacha" class="UrlChacha" size="45" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" style="width: 375px" /></td>
        </tr>
        <tr>
            <td style="width: 200px">
                <span style="font-size: 9pt; color: #595959; font-family: Verdana">Đường dẫn Zing:</span></td>
            <td style="width: 60%"><input type="text" id="UrlZing" name="Name" class="txtinput" size="45" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" style="width: 375px" /></td>
        </tr>
        <tr>
            <td style="width: 200px">
                <span style="font-size: 9pt; color: #595959; font-family: Verdana">Đường dẫn Youtube:</span></td>
            <td style="width: 60%"><input type="text" id="UrlYoutube" class="txtinput" size="45" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" style="width: 375px" /></td>
        </tr>
      <tr>
        <td valign="top" style="width: 200px"><div style="margin-top: 8px;"><span class="content12">Ingredients:</span><span class="cred2">*</span></div></td>
        <td style="width: 60%">
        <div style="margin-top: 8px;">
    <textarea runat="server" id="Ingredients" class="textbox" cols="80" rows="30" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="RecIngred" ControlToValidate="Ingredients"
            cssClass="cred2" errormessage="* Ingredients:<br />"
            display="Dynamic" />
            </div>
    </td>
      </tr>
      <tr>
        <td valign="top" style="width: 200px"><div style="margin-top: 12px;"><span class="content12">Instructions:</span><span class="cred2">*</span></div></td>
        <td style="width: 60%">
        <div style="margin-top: 12px;">
    <textarea runat="server" id="Instructions" class="textbox" cols="80" rows="32" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />&nbsp;
            </div>
    </td>
      </tr>
              <tr>
        <td valign="top" style="width: 200px"></td>
        <td style="width: 60%">
<img src="<%=strRecipeImage%>" style="margin-top: 12px; border: solid 1px #A0BEE2; padding: 1px;" width="150" height="120" />
    </td>
      </tr>
        <tr>
        <td valign="top" style="width: 200px"><span class="content12">Photo:<br />(Optional)</span></td>
        <td style="width: 60%">
    <asp:FileUpload ID="RecipeImageFileUpload" runat="server" />&nbsp;<span class="content2"><br />Maximum Image size is 200 x 200 and less than 20,000 bytes.
    <br />Note: If you don't want to update the photo, just leave it blank.</span>
    </td>
      </tr>
      <tr>
        <td style="width: 200px"></td>
        <td style="width: 60%">
    <input type="text" class="textbox" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <br />
    <asp:Button runat="server" Text="Update" id="UpdateRec" cssClass="submitadmin" OnClick="Update_Recipe" />   
    </td>
      </tr>
    </table>
  </asp:Panel>
     </div>
    </fieldset>
    </td>
      </tr>
    </table>
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    </asp:PlaceHolder>
    </div>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    <!--End Insert Lyric Form-->
    <script type="text/javascript" src="js/wz_tooltip.js"></script>
</asp:Content>

