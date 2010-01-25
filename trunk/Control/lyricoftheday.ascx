<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lyricoftheday.ascx.cs" Inherits="lyricoftheday" EnableViewState="false"%>
  <div class="hpleft">
<span class="corange5">Bài hát trong ngày</span>
<br />
<asp:Label cssClass="cmaron12" runat="server" id="lbrecname" />
<br />
<span class="content8"><b>Hợp âm:</b></span>
<br />
<asp:Label cssClass="content8" runat="server" id="lbingred" />
<br />
<span class="content8"><b>Ghi chú:</b></span>
<br />
<asp:Label cssClass="content8" runat="server" id="lbinstruct" EnableViewState="false" />
<br />
<span class="content8">Chủ đề:</span>&nbsp;<asp:HyperLink id="RanCat" cssClass="dt2" runat="server" EnableViewState="false" />
<br />
<span class="content8">Đánh giá:&nbsp;<asp:Image id="rateimage" runat="server" ImageAlign="absmiddle" EnableViewState="false" />&nbsp;(<asp:Label cssClass="cgr" runat="server" id="lblrating" EnableViewState="false" />)&nbsp;votes&nbsp;<asp:Label cssClass="cyel" runat="server" id="lbvotes" EnableViewState="false" /></span>
<br />
<span class="content8">Sô lần xem:</span> <asp:Label cssClass="cmaron2" runat="server" id="lbhits" EnableViewState="false" />
<br />
<asp:HyperLink id="rdetails" cssClass="dt2" runat="server" EnableViewState="false" />
  </div>
