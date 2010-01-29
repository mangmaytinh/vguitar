<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" EnableViewState="false" AutoEventWireup="true" CodeFile="lyricdetail.aspx.cs" Inherits="lyricdetail" Title="Untitled Page" %>

<%@ Register Src="Control/categorylistsidemenuEng.ascx" TagName="categorylistsidemenuEng"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="categorylistsidemenu" Src="Control/categorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:categorylistsidemenu id="catlistcont" runat="server"></ucl:categorylistsidemenu>
    <br />
    <uc1:categorylistsidemenuEng ID="CategorylistsidemenuEng1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="text-align: left; margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-bottom: 10px;">&nbsp;
                            <a class="dsort" title="Quay lại trang chủ" href="default.aspx">Home</a>
                           <span class="bluearrow">»</span>
                         <a class="dsort" href="category.aspx?catid=<%=RecCatId%>" title="Xem mục <%=strCName%>"><%=strCName%></a>
                       <span class="bluearrow">»</span>&nbsp;<span class="content10"><%=strRName%></span>
                      </div>
    <div style="padding: 2px; margin-bottom: 14px; margin-top: 12px; margin-left: 16px; margin-right: 6px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    </div>
    <!--Begin header User option-->
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <div style="margin-left: 10px; margin-right: 10px;">
    <div class="divheaddetail">
    <img src="images/tlcorner.gif" alt="" align="top">
    <asp:Image ImageUrl="images/save_icon.gif" ID="saveicon" ImageAlign="AbsMiddle" runat="server" />&nbsp;<asp:Label runat="server" CssClass="content12" id="addtoCookBook" EnableViewState="false" /><asp:LinkButton id="LinkButtonAddtoCookBookLogin" CausesValidation="false" runat="server" CssClass="content12" Visible="false" OnClick="Add_CookBook" EnableViewState="false" />&nbsp;&nbsp;
    <asp:Image ID="CommentImg" ImageUrl="images/discuss_icon.gif" AlternateText="Discuss <%=strRName%> Lyric" ImageAlign="AbsMiddle" runat="server" />&nbsp;<asp:HyperLink ID="CommentLink" NavigateUrl="#DIS" ToolTip="Lời bình cho bài hát này" runat="server" cssClass="dt" />&nbsp;&nbsp;
    <img src="images/print_icon.gif" align="absmiddle" alt="Print <%=strRName%> Lyric"> 
    <a class="thickbox dt" title="In hợp âm bài hát <%=strRName%>" href="printlyric.aspx?id=<%=Request.QueryString["id"]%>&keepThis=true&TB_iframe=true&height=600&width=750" onmouseover="Tip('In hợp âm bài <%=strRName%>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()">In hợp âm</a>&nbsp;&nbsp;
    <img src="images/email_icon.gif" align="absmiddle" alt="Gửi hợp âm bài hát <%=strRName%> cho bạn bè"> 
    <a class="thickbox dt" title="Gửi Email hợp âm bài <%=strRName%> cho bạn bè" href="emaillyric.aspx?id=<%=Request.QueryString["id"]%>&amp;n=<%=strRName%>&c=<%=strCName%>&keepThis=true&TB_iframe=true&height=220&width=400" onmouseover="Tip('Gửi Email hợp âm bài hát <%=strRName%> cho bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()">Gửi email</a>&nbsp;&nbsp;
    <img src="images/save_icon.gif" align="absmiddle" alt="Ghi nhớ hợp âm bài <%=strRName%> vào mục yêu thích của bạn">
    <a class="dt" title="Ghi nhớ hợp âm bài hát <%=strRName%> vào trình duyệt của bạn" href="javascript:bookmark('<%=strRName%> Lyric', '<%=strBookmarkURL%>')" onmouseover="Tip('Nhớ hợp âm bài  <%=strRName%> vào trình duyệt của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()">Nhớ vào trình duyệt</a>
    </div>
    <!--End header User option-->
    <table cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td valign="top" align="left" width="35%">
    <div style="background: #fff url(images/rbg1.gif) repeat-x;">
    <div style="padding-top: 8px;">
    &nbsp;&nbsp;<asp:Label cssClass="cmaron4" runat="server" id="lblname" EnableViewState="false" /> <asp:Label runat="server" id="lblpopular" cssClass="hot" EnableViewState="false" /> <asp:Image id="thumbsup" runat="server" AlternateText = "Thumsb up" EnableViewState="false" /><asp:Image id="newimg" runat="server" AlternateText = "New image" EnableViewState="false" />
    </div>
    <div>
    &nbsp;&nbsp;<span class="content2">Chủ đề:</span>
    <a class="dt" href="category.aspx?catid=<%=RecCatId%>" title="Xem danh mục <%=strCName%>" onmouseover="Tip('Xem tất cả bài hát trong chủ đề <%=strCName%> .', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%=strCName%></a>&nbsp;&nbsp;<asp:Label cssClass="content2" runat="server" id="lbluid" EnableViewState="false" />
    </div>
    <div>
    &nbsp;&nbsp;<span class="content2">Tác giả:</span>
    <img src="images/user-icon.gif" />&nbsp;<img src="images/user-icon.gif" />&nbsp;<a href="findalllyricbycreateby.aspx?author=<%=strCreateBy %>" onmouseover="Tip('Xem bài hát của tác giả <b><%=strCName%></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%=strCName%></a>
    </div>
    <div>    
    &nbsp;&nbsp;<span class="content2">Người đăng bài:</span>&nbsp;<img src="images/user-icon.gif" />&nbsp;<a href="findalllyricbycreateby.aspx?author=<%=strCreateBy %>" onmouseover="Tip('Xem tất cả những bài đăng bởi <b><%=strCreateBy%></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%=strCreateBy %></a>
    </div>
    <div>
    &nbsp;&nbsp;<span class="content2">Ngày viết bài:</span>
    <asp:Label runat="server" id="lbldate" cssClass="cyel" EnableViewState="false" />
    </div>
    <div>
    &nbsp;&nbsp;<span class="content2">Số lần xem:</span>
    <asp:Label ID="lblhits" runat="server" cssClass="cmaron3" EnableViewState="false" />
    </div>
    <div style="margin-bottom: 1px;">
    &nbsp;&nbsp;<span class="content2">Đánh giá:&nbsp;<asp:Image id="starimage" runat="server" />&nbsp;(<asp:Label cssClass="cgr" runat="server" id="lblrating" EnableViewState="false" />) Bầu trọn <asp:Label cssClass="cyel" runat="server" id="lblvotescount" EnableViewState="false" /></span> 
    </div>
    <div style="margin-bottom: 16px;">
    <asp:Panel ID="Panel2" runat="server" Height="50px" Width="220px">
    &nbsp;&nbsp;<b><span id="link<%=Request.QueryString["id"]%>" class="cgr">Đánh giá bài hát</span></b>
    <ul class="srating">
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Tồi - 1 sao'"  onmouseout="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Đánh giá bài hát này'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["id"]%>&amp;rateval=1&amp;wp=<%=LyricSection%>';" title='Bầu chọn: Không chắc chắn - 1 sao' class='onestar'>1</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Bình thường - 2 sao'" onmouseout="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Đánh giá bài hát này'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["id"]%>&amp;rateval=2&amp;wp=<%=LyricSection%>';" title='Bầu chọn: Bình thường - 2 sao' class='twostars'>2</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Thú vị - 3 sao'" onmouseout="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Đánh giá bài hát này'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["id"]%>&amp;rateval=3&amp;wp=<%=LyricSection%>';" title='Bầu chọn: Thú vị - 3 sao' class='threestars'>3</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Tốt - 4 sao'" onmouseout="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Đánh giá bài hát này'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["id"]%>&amp;rateval=4&amp;wp=<%=LyricSection%>';" title='Bầu chọn: Rất tốt - 4 sao' class='fourstars'>4</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Tuyệt vời - 5 sao'" onmouseout="document.getElementById('link<%=Request.QueryString["id"]%>').innerHTML='Đánh giá bài hát này'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["id"]%>&amp;rateval=5&amp;wp=<%=LyricSection%>';" title='Bầu chọn: Tuyệt vời - 5 sao' class='fivestars'>5</a></li>
    </ul>
    </asp:Panel>
     </div>
    </div>
    </td>
        <td valign="top" align="left" width="65%" style="background: #fff url(images/rbg1.gif) repeat-x;">
     <div style="background: #fff url(images/rbg1.gif) repeat-x;">
     <asp:Image ID="Lyricimage" CssClass="Lyricimage" BorderColor="#A0BEE2" BorderWidth="1" Width="150" Height="120" runat="server"/>
     </div>
    </td>
      </tr>
    </table>
     <div style="margin: 6px;">
     <fieldset><legend>Nghe nhạc / xem video hướng dẫn</legend>
      <div style="padding-top: 12px; padding-right: 12px; line-height: 20px;">
      
     </div>
    </fieldset>
    </div>
    <div style="margin: 6px;">
     <fieldset><legend>Hợp âm bài hát</legend>
     <div style="padding-top: 12px; padding-right: 12px; line-height: 20px;">
      <asp:Label cssClass="drecipe" ID="lblIngredients" runat="server" EnableViewState="false" />
     </div>
    </fieldset>
    </div>
    <div style="margin: 6px;">
     <fieldset><legend>Hướng dẫn chi tiết, chú thích</legend>
      <div style="padding-top: 12px; padding-right: 12px; line-height: 20px;">
      <asp:Label cssClass="drecipe" ID="lblInstructions" runat="server" EnableViewState="false" />
     </div>
    </fieldset>
    </div>
    <div style="margin-left: 6px; margin-right: 6px;  margin-bottom: 22px;">
    <fieldset><legend>Các bài hát liên quan chủ đề&nbsp;<asp:Label runat="server" id="lblcategorytop" EnableViewState="false" />&nbsp;bạn cần quan tâm</legend>
    <div style="margin-top: 6px;">
       <asp:Repeater id="RelatedLyrics" runat="server" EnableViewState="false">
       <ItemTemplate>
    <span class="ora2">&raquo;</span>
    <a class="dt" title="Danh mục (<%# Eval("Category")%>) - Số lần xem (<%# Eval("Hits")%>)" onmouseover="Tip('<b>Danh mục: </b><%# Eval("Category") %><br><b>Hits: </b><%# Eval("Hits") %><br><b>Ảnh:</b><br><img src=&quot;LyricImageUpload/<%# Eval("LyricImage")%>&quot; width=&quot;150&quot; height=&quot;120&quot;>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'>
    <%# Eval("LyricName")%></a>
    <br />
          </ItemTemplate>
      </asp:Repeater>
    </div>
    </fieldset>
    </div>
    </div>
    </asp:PlaceHolder>
    <asp:Panel ID="Panel1" runat="server" Width="727px">
    <!--Begin Display Comments-->
    <div style="margin-left: 40px; margin-right: 40px; margin-top: 20px;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td width="100%" height="18" BgColor="#F4F9FF" style="-moz-border-radius: 8px; border-radius: px;"><span class="content6">Hiện tại có&nbsp;(<asp:Label id="lbcountcomment" cssClass="content6" runat="server" EnableViewState="false" />)&nbsp;lời bình</span></td>
      </tr>
      <tr>
        <td width="100%">
    <asp:Repeater id="RecComments" runat="server" EnableViewState="false">
          <ItemTemplate>
        <div class="divwrap2" style="-moz-border-radius: 8px; border-radius: px;">
    <div class="divbd6" style="padding: 6px;">
    Lời bình được viết vào <%#Request.QueryString["id"]%> bởi <img src="images/user-icon.gif" />&nbsp;<a class="content2" title="Xem hồ sơ của <%#RecCatId%> ." href='<%# Eval("UID", "userprofile.aspx?uid={0}") %>'><%#RecCatId%></a>
    <div style="margin-top: 6px;">
    <%#strCName%>
         </div>
        </div>
       </div>
     </ItemTemplate>
    </asp:Repeater>
    </td>
      </tr>
    </table>
    </div>
    <!--End Display Comments-->
    <!--Begin Comment Field-->
   
    <div style="margin-left: 40px; margin-right: 40px;">
    <fieldset><legend>Viết một lời bình</legend>
             
    <table border="0" cellpadding="2" cellspacing="2" style="width: 80%">
      <tr>
        <td width="100%" colspan="2"><a style="text-decoration: none; color: #336699;" name="DIS"></a>        
        <asp:Label ID="lbllogintocomment" runat="server" cssClass="content12" Visible="false" EnableViewState="false" />
            
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" />
    <br />
    <span class="content12">Những mục có hoa thị mầu đỏ(<span class="cred3">*</span>) là bắt buộc.</span></td>
      </tr>
      <asp:Panel ID="Panel3" runat="server">
      <tr>
        <td width="200px" class="content2"><span class="content12">Tài khoản:</span></td>
        <td >
    <input type="hidden" id="AUTHOR" name="AUTHOR" Class="textbox" runat="server" />
    <asp:Label ID="lblUsernameComment" runat="server" cssClass="content12" EnableViewState="false" />
    </td>
      </tr>
      <tr>
        <td width="200px" class="content2"><span class="content12">Hòm thư:</span></td>
        <td >
    <input type="hidden" id="EMAIL" name="EMAIL" Class="textbox" runat="server" />
    <asp:Label ID="lbluserCommentEmail" runat="server" cssClass="content12" EnableViewState="false" />
    </td>
      </tr>
      <tr>
        <td width="200px" valign="top" class="content2"><span class="content12">Lời bình:</span><span class="cred2">*</span>
    <br />
    <br />
    <span class="catcntsml">Chỉ cho phép 350 ký tự</span>
    </td>
        <td>
          <asp:RequiredFieldValidator runat="server"
          id="RequiredFieldComment" ControlToValidate="COMMENTS" SetFocusOnError="true"
          cssClass="cred2"
          ValidationGroup="CommentGroup"
          ErrorMessage = "Phải viết lời bình và"
          display="Dynamic"> </asp:RequiredFieldValidator>
        <textarea id="COMMENTS" name="COMMENTS" Class="textbox" cols="55" rows="7" onKeyDown="textCounter(350);" onKeyUp="textCounter(350);" onFocus="this.style.backgroundColor='#FFF9EC'" onBlur="this.style.backgroundColor='#ffffff'"  runat="server" /> 
    <input class="textbox" type="text" name="remLen" id="remLem" size="3" maxlength="3" value="350" readonly> <span class="catcntsml">Char count</span>
    <br />

    <asp:Label cssClass="cred2" runat="server" id="lblcomcharlimit" visible="false" />
    <input type="hidden" value="<%=Request.QueryString["id"]%>" ID="ID" name="ID">
    <input type="text" class="textbox" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <br />
    <span class="content2">Mã bảo mật:</span>&nbsp;<asp:RequiredFieldValidator runat="server"
          id="RequiredFieldSecCode" ControlToValidate="txtsecfield" SetFocusOnError="true"
          cssClass="cred2"
          ValidationGroup="CommentGroup"
          ErrorMessage = "Bạn phải viết mã bảo mật vào đây"
          display="Dynamic"> </asp:RequiredFieldValidator>
    <br />
    <img height="30" alt="" src="imgsecuritycode.aspx" width="80"> 
    <br />
      <asp:Label ID="lblinvalidsecode" cssClass="cred2" runat="server" visible="false" />
     <asp:TextBox ID="txtsecfield" CssClass="textbox" runat="server" Width="70"></asp:TextBox>
    <br />
<asp:ValidationSummary
ID="ValidationSummary1"
runat="server"
EnableClientScript="true"
ValidationGroup="CommentGroup"
ShowMessageBox="true"
ShowSummary="false"
HeaderText="Những mục sau cần phải được quan tâm:" />
<br />
    <asp:Button runat="server" Text="Submit" id="AddComments" cssClass="submitadmin" OnClick="Add_Comment" ValidationGroup="CommentGroup" />

          </td>
        </tr>
        </asp:Panel>
       </table>           
    </fieldset>
    </div>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    <!--End Comment Field-->
    </asp:Panel>
   
</asp:Content>

