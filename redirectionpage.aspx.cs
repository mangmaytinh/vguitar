#region XD World Lyric V 2.8
// FileName: redirectionpage.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.BL;

public partial class redirectionpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Multi purpose redirection page.

        string strRedirectToHomePage = "default.aspx";

        if (!string.IsNullOrEmpty(Request.QueryString["mode"]) && !string.IsNullOrEmpty(Request.QueryString["ReturnURL"]))
        {
            string mode = Request.QueryString["mode"];
            string strURLRedirect = Request.QueryString["ReturnURL"];

            switch (mode)
            {
                //Greetings during login
                case "welcome":
                    PanelWelcomeBack.Visible = true;
                    lblwelcomeusername.Text = "Chào mừng " + Request.QueryString["username"] + " đã quay lại với chúng tôi";
                    Response.AppendHeader("Refresh", "3; url=" + strURLRedirect);
                    break;

                //Thank you after logout
                case "thankyoulogout":
                    PanelThankYouLogout.Visible = true;
                    Response.AppendHeader("Refresh", "3; url=" + strURLRedirect);
                    break;

                //Display suspended message
                case "suspended":
                    PanelAccountSuspended.Visible = true;
                    Response.AppendHeader("Refresh", "12; url=" + strURLRedirect);
                    break;

                //Display not active - account has not been activated yet.
                case "notactive":
                    PanelAccountNotActivated.Visible = true;
                    Response.AppendHeader("Refresh", "12; url=" + strURLRedirect);
                    break;
            }
        }

        //New user registration
        if (!string.IsNullOrEmpty(Request.QueryString["email"]))
        {
            PanelForJoining.Visible = true;

            lblheader.Text = "Cảm ơn Bạn đã Tham gia " + constant.DomainName;
            lblsuccess.Text = "Đường dẫn kích hoạt đã được gửi tới ( " + Request.QueryString["email"] + " ).<br>Bạn sẽ nhận được một email trong vài giây có chứa các liên kết kích hoạt.<br>Vào email của bạn và nhấp vào liên kết kích hoạt để kích hoạt tài khoản của bạn.";
            lblwait.Text = "Xin vui lòng chờ đợi, bạn sẽ được trở lại trang chủ trong 12 giây.";

            Response.AppendHeader("Refresh", "12; url=" + strRedirectToHomePage);
        }

        //Profile update
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]) && !string.IsNullOrEmpty(Request.QueryString["uname"]) && !string.IsNullOrEmpty(Request.QueryString["logout"]))
        {
            string strURLRedirectProfileUpdate = "";
            string strLogUser = Request.QueryString["logout"];

            PanelProfileUpdateSuccess.Visible = true;

            switch (strLogUser)
            {
                case "Yes":
                    lblheaderupdateprofilesuccess.Text = "Hồ Sơ Cập nhật thành công. Bạn đã thoát khỏi hệ thống";
                    lblupdateprofilemsg.Text = "<b>" + Request.QueryString["uname"] + "'s</b> thông tin đã được cập nhật thành công. Bây giờ bạn thoát ra khỏi hệ thống và đăng nhập lại.";
                    lblupdateprofilewait.Text = "Xin vui lòng chờ đợi, bạn sẽ được trở lại trang chủ trong 12 giây.";
                    strURLRedirectProfileUpdate = "default.aspx";
                    break;

                case "No":
                    lblheaderupdateprofilesuccess.Text = "Hồ Sơ Cập nhật thành công.";
                    lblupdateprofilemsg.Text = "<b>" + Request.QueryString["uname"] + "'s</b> thông tin đã được cập nhật thành công.";
                    lblupdateprofilewait.Text = "Xin vui lòng chờ đợi, bạn sẽ được trở lại trang chủ trong 3 giây.";
                    strURLRedirectProfileUpdate = "userprofile.aspx?uid=" + Request.QueryString["uid"];
                    break;
            }

            Response.AppendHeader("Refresh", "3; url=" + strURLRedirectProfileUpdate);

        }
    }

}
