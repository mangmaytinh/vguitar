﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tìm từ khoá không tìm thấy</title>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--Begin Header-->
<a name="Top"></a>
<div class="headerwrap">
<table border="0" cellpadding="0" cellspacing="0" width="97%">
  <tr>
   <td width="50%" rowspan="2" valign="top"><a title="VGuitar.net" href="default.aspx"><img src="images/vguitar.jpg"  border="0" alt="vguitar.thlb.biz" /></a></td>
    <td width="50%" align="right" valign="top">
<span class="content2">
<a class="dt" title="About" href="javascript:void(0)" onClick="window.open('about.aspx','','width=530,height=345,status=no');">Giấy thiệu</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="Giấy thiệu về chúng tôi" href="http://thlb.biz">Liên hệ</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="Site Map" href="http://thlb.biz">Sơ đồ website</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="D" href="http://thlb.biz">Thiết kế</a>
</span>
</td>
  </tr>
  <tr>
    <td width="50%" align="right"><span class="chdate"><%=DateTime.Now.ToString("f")%></span></td>
  </tr>
</table>
</div>
<!--End Header-->
<br />
<div style="text-align: left; margin-top: 35px; width: 450px; margin-left: auto; margin-right:auto;">
<h1 style="font-family: verdana, arial, helvetica, sans-serif; font-weight: bold; color: #CC3300; font-size: 14px; margin-bottom: 1px; padding-bottom: 1px;">Xin lỗi, không tìm thấy mục bạn đang tìm kiếm.</h1>
<span class="drecipe">
Bạn tìm kiếm từ khóa (<%=Request.QueryString["keyword"].ToString() %>) không có kết quả nào.</span>
<br /><br />
<a class="dt" href="javascript:history.go(-1)">Quay lại trang trước</a>&nbsp;<span class="content2">|</span>&nbsp;<a class="dt" href="default.aspx">Quay lại trang chủ</a>
</div>          
    </div>
    </form>
</body>
</html>
