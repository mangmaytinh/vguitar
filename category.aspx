<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" EnableViewState="false" AutoEventWireup="true" CodeFile="category.aspx.cs" Inherits="recipecategory" Title="Untitled Page" %>

<%@ Register Src="Control/categorylistsidemenuEng.ascx" TagName="categorylistsidemenuEng"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sortoptionlinks" Src="Control/sortoptionlinks.ascx" %>
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
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Quay lại trang chủ"><% = Resources.lang.Home %></a>&nbsp;<span class="bluearrow">�</span>&nbsp;<asp:Label cssClass="content10" runat="server" id="lblcatname2" EnableViewState="false" /> <span class="content2"><asp:Label cssClass="content2" id="lblcount" runat="server" EnableViewState="false" /></span>
    <asp:Label cssClass="content2" id="lblsortname" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    <div style="padding: 2px; margin-bottom: 14px; margin-top: 12px; margin-left: 16px; margin-right: 26px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    <br />
    </div>
    <!--Begin Center Container-->
    <div style="margin-left: 5px; margin-right: 5px;">
    <!--Begin sort category links-->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td align="left" style="width: 79%">
    <ucl:sortoptionlinks id="opt1" runat="server"></ucl:sortoptionlinks>
    </td>
        <td width="20%" align="right">
        <div style="margin-right: 20px;">
    <asp:label ID="lblRecpagetop" runat="server" cssClass="content2" EnableViewState="false" />
    </div>
    </td>
      </tr>
    </table>
    <!--End sort category links-->
    <div style="float: right; text-align: right; margin-right: 18px;">
    <asp:Panel ID="PanelDropdownOptionTopNotPreferred" Visible="false" runat="server">
    <select name="urllayout" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=SelectedValuePrefLayout%>
    </option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=1"><%=Resources.lang.Rows %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=2"><%=Resources.lang.Grid_2_Columns %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=3"><%=Resources.lang.Grid_3_Columns %></option>
    </select>
    <select name="url" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " " + Resources.lang.Records_Page%>
    </option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=10&layout=<%=pLayout%>">10 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=20&layout=<%=pLayout%>">20 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=30&layout=<%=pLayout%>">30 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=40&layout=<%=pLayout%>">40 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=50&layout=<%=pLayout%>">50 <%=Resources.lang.Records_Page %></option>
    </select>
    </asp:Panel>
    <asp:Panel ID="PanelDropdownOptionTopPreferred" Visible="false" runat="server">
    <select name="urllayoutlogin" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=SelectedValuePrefLayout%>
    </option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=L&playout=1"><%=Resources.lang.Rows %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=L&playout=2"><%=Resources.lang.Grid_2_Columns %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=L&playout=3"><%=Resources.lang.Grid_3_Columns %></option>
    </select>
    <select name="urlpagesizelogin" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " " + Resources.lang.Records_Page%>
    </option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=10">10 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=20">20 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=30">30 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=40">40 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=50">50 <%=Resources.lang.Records_Page %></option>
    </select>
    </asp:Panel>
    </div>
    <div style="margin-bottom: 10px; border-top: solid 1px #D5E6FF; margin-right: 18px; margin-left: 4px;"></div>
    <div style="clear: both;"></div>
    <!--Begin repeater center content-->
    <asp:DataList id="LyricCat" OnItemDataBound="RecipeCatItemDataBound" RepeatDirection="Horizontal" runat="server" EnableViewState="false">
          <ItemTemplate>
        <div class="divwrap5">
           <div class="divhd">
    <img src="images/arrow7.gif" alt="" />
    <a class="dtcat" onmouseover="Tip('<%# Eval("LyricName") %>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()" href='<%# Eval("ID", "lyricdetail.aspx?id={0}") %>'><%# Eval("LyricName") %></a>
    <asp:Label ID="lblpopular" cssClass="hot" runat="server" EnableViewState="false" /> <asp:Image ID="newimg" runat="server" EnableViewState="false" /><asp:Image id="thumbsup" runat="server" AlternateText = "Thumsb up" EnableViewState="false" /> 
    </div> 
    <div class="divbd">
    <%=Resources.lang.Category %>:&nbsp;<a class="dt2" title="Go to <%# Eval("Category") %> category" href='javascript:void(0)'><%# Eval("Category") %></a>
    <br />
    Tác giả:&nbsp;<img src="images/user-icon.gif" />&nbsp;<a href="findalllyricbyauthor.aspx?author=<%# Eval("Author") %>" onmouseover="Tip('View all recipe submitted by <b><%# Eval("Author") %></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%# Eval("Author") %></a>
    <br />
    Người đăng bài:&nbsp;<img src="images/user-icon.gif" />&nbsp;<a href="findalllyricbycreateby.aspx?author=<%# Eval("CreateBy") %>" onmouseover="Tip('Xem tất cả những bài đăng bởi <b><%# Eval("CreateBy") %></b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')" onmouseout="UnTip()"><%# Eval("CreateBy") %></a>
    <br />
    <%=Resources.lang.Rating %>:&nbsp;<img src="images/<%# Eval("Rating", "{0:0.0}")%>.gif" align="absmiddle" />&nbsp;(<span class="cgr"><%# Eval("Rating", "{0:0.0}")%></span>) votes <span class="cyel"><%# Eval("NoRates")%></span>
    <br />
    <%=Resources.lang.Added %>: <span class="cyel"><%# CustomDateFormat(Eval("Date"))%></span>
    <br />
    <%=Resources.lang.Hits %>: <span class="cmaron3"><%# Eval("Hits", "{0:#,###}")%></span>
        </div>
    </div>
    <div style="margin: 15px;"></div>
          </ItemTemplate>
      </asp:DataList>
      </div>
      <!--Begin repeater center content-->
    <!--End Center Container-->
    <!--Begin Record count,page count and paging link-->
    <div style="margin-left: 12px; margin-top: 22px;">
    <asp:label ID="lblRecpage" runat="server" cssClass="content2" EnableViewState="false" /><asp:label ID="lbps" runat="server" cssClass="content2" EnableViewState="false" />
    <div style="margin-top: 10px;">
    <asp:Label cssClass="content2" id="lbPagerLink" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    </div>
    <!--End Record count,page count and paging link-->
    <div style="clear:both;"></div>
    <div style="margin-left: 12px; margin-top: 8px;">
    <span class="content2"><%=Resources.lang.Pagesize %>:</span>&nbsp;<asp:Panel ID="PanelDropdownOptionBottomPreferred" Visible="false" runat="server">
    <select name="urlpagesizeloginbottom" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " " + Resources.lang.Records_Page%>
    </option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=10">10 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=20">20 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=30">30 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=40">40 <%=Resources.lang.Records_Page %></option>
    <option value="confirmlayoutchange.aspx?ReturnURL=<%=ReturnURL%>&mode=P&psize=50">50 <%=Resources.lang.Records_Page %></option>
    </select>
</asp:Panel>
<asp:Panel ID="PanelDropdownOptionBottomNotPreferred" Visible="false" runat="server">
<select name="url2" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " " + Resources.lang.Records_Page%>
    </option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=10&layout=<%=pLayout%>" >10 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=20&layout=<%=pLayout%>">20 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=30&layout=<%=pLayout%>">30 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=40&layout=<%=pLayout%>">40 <%=Resources.lang.Records_Page %></option>
    <option value="category.aspx?catid=<%=psCatId%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=50&layout=<%=pLayout%>">50 <%=Resources.lang.Records_Page %></option>
    </select>
</asp:Panel>
</div>
</asp:Content>

