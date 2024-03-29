#region XD World Lyric V 3
// FileName: EmailTemplates.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

namespace VGuitar.BL
{
    /// <summary>
    /// Object in this class generate the email template
    /// </summary>
    public class EmailTemplate : Email
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EmailTemplate()
        {
        }

        private string GetAdminToEmail
        {
            get { return SiteConfiguration.GetConfiguration.AdminToEmail; }
        }

        private string GetAdminFromEmail
        {
            get { return SiteConfiguration.GetConfiguration.AdminFromEmail; }
        }

        /// <summary>
        /// Send exception error notification.
        /// </summary>
        public int SendExceptionErrorNotification(string strURL, string ExceptionError)
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = "Thông báo lỗi từ VGuitar";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào quản trị:");
            mySB.Append("<br><br>");
            mySB.Append("Lỗi này đã được nhớ vào cơ sở dữ liệu.");
            mySB.Append("<br><br>");
            mySB.Append("<b>Chi tiết lỗi:</b>");
            mySB.Append("<br>");
            mySB.Append(ExceptionError);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(GetAdminToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send comment posting email notification to the Webmaster
        /// </summary>
        public int SendEmailLyricCommentNotify()
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "lyricdetail.aspx?id=" + ItemID;

            string Subject = "Một lời bình cho bài hát được thêm vào";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào quản trị:");
            mySB.Append("<br><br>");
            mySB.Append("Ai đó đã được đăng một bình luận cho bài hát. Nhấp vào liên kết bên dưới để xem xét.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(ItemName);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(GetAdminToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send comment posting email notification to the Webmaster
        /// </summary>
        public int SendEmailArticleCommentNotify()
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "articledetail.aspx?aid=" + ItemID;

            string Subject = "Một bài bình luận cho bài viết được đưa lên";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào quản trị:");
            mySB.Append("<br><br>");
            mySB.Append("Có người đã đăng một bài bình luận. Nhấp vào liên kết bên dưới để xem xét.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(ItemName);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(GetAdminToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send comment posting email notification to the Webmaster
        /// </summary>
        public int SendEmailAddRecipeNotify()
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = "Bài hát được thêm vào tại " + constant.DomainName;

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào quản trị:");
            mySB.Append("<br><br>");
            mySB.Append("Một ai đó đã đưa thêm một bài hát mới.");
            mySB.Append("<br>");
            mySB.Append("Tên bài hát:");
            mySB.Append("&nbsp;");
            mySB.Append(ItemName);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(GetAdminToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send email recipe to a friend
        /// </summary>
        public int SendEmailRecipeToAFriend()
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = SenderName + " Gửi tới bạn một bài hát hay";

            string strURL = BaseUrl.GetBaseUrl + "lyricdetail.aspx?id=" + ItemID;

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào bạn ");
            mySB.Append(LyricName);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(SenderName);
            mySB.Append(",&nbsp;");
            mySB.Append("gửi tới bạn một bài hát ");
            mySB.Append("<b>" + ItemName + "</b>");
            mySB.Append("&nbsp;trong chủ đề ");
            mySB.Append("<b>" + Category + "</b>");
            mySB.Append(".");
            mySB.Append("<br><br>");
            mySB.Append("Nhấp vào liên kết bên dưới hoặc sao chép nó vào URL của trình duyệt để xem/nghe bài hát đó.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("<br><br><br>");
            mySB.Append("Email này được gửi đến cho bạn bởi ");
            mySB.Append("<b>" + SenderName + "</b>");
            mySB.Append("&nbsp;");
            mySB.Append(SenderEmail);
            mySB.Append("&nbsp;<br>thông qua người bạn chia sẻ một bài hát hay tại ");
            mySB.Append(constant.DomainName);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(LyricEmail, SenderEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send email article to a friend
        /// </summary>
        public int SendEmailArticleToAFriend()
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = SenderName + " đã gửi đến bạn một bài viết hay";

            string strURL = BaseUrl.GetBaseUrl + "articledetail.aspx?aid=" + ItemID;

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hello");
            mySB.Append("&nbsp;");
            mySB.Append(LyricName);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(SenderName);
            mySB.Append(",&nbsp;");
            mySB.Append("đã gửi đến bạn một bài viết hay.");
            mySB.Append("<br><br><b>Tiêu đề bài viết:</b> ");
            mySB.Append("<b>" + ItemName + "</b>");
            mySB.Append("<br><br>");
            mySB.Append("Nhấp vào liên kết bên dưới hoặc sao chép nó vào URL của trình duyệt để xem bài viết đó.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("<br><br><br>");
            mySB.Append("Bài viết được gửi cho bạn bởi ");
            mySB.Append("<b>" + SenderName + "</b>");
            mySB.Append("&nbsp;");
            mySB.Append(SenderEmail);
            mySB.Append("&nbsp;<br>thông qua một người bạn chia sẻ bài viết từ ");
            mySB.Append(constant.DomainName);
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(LyricEmail, SenderEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Email new account activation link
        /// </summary>
        public int SendActivationLink(string Username, string strGUID)
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "activation.aspx?guid=" + strGUID;

            string Subject = "Kích hoạt tài khoản tại " + constant.DomainName;

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Hi ");
            mySB.Append(Username + ":");
            mySB.Append("<br><br>");
            mySB.Append("Bạn đã đăng ký một tài khoản tại ");
            mySB.Append(constant.DomainName);
            mySB.Append("<br>");
            mySB.Append("Hãy nhấn vào liên kết sau để kích hoạt tài khoản của bạn.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<b>");
            mySB.Append("Dường dẫn kích hoạt: ");
            mySB.Append("</b>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(LyricEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }


        /// <summary>
        /// Email a suspension notification
        /// </summary>
        public int SendAccountSuspensionReinstateEmail(string ToEmail, string Username, string Type, int flag)
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = "";
            string Subject = "";

            //flag = 1 - Suspension email notice
            if (flag == 1)
            {
                strURL = BaseUrl.GetBaseUrl + "contactus.aspx";

                Subject = constant.DomainName + " Thông báo đình chỉ tài khoản";

                mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left>");
                mySB.Append("<font size=2 color=black face=verdana>");
                mySB.Append("Chào bạn ");
                mySB.Append(Username + ":");
                mySB.Append("<br><br>");
                mySB.Append("Tài khoản của bạn ở ");
                mySB.Append(constant.DomainName);
                mySB.Append(" đã bị đình chỉ hoạt động.");
                mySB.Append("<br><br>");
                mySB.Append("<b>Lý do:</b> ");
                mySB.Append(Type);
                mySB.Append("<br><br>");
                mySB.Append("Nhấn vào liên kết dưới đây để liên hệ với quản trị khôi phục tài khoản của bạn.");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left><br>");
                mySB.Append("<font size=2 face=verdana>");
                mySB.Append("<b>");
                mySB.Append("Đường dẫ liên hệ: ");
                mySB.Append("</b>");
                mySB.Append("<a target=_new href=");
                mySB.Append(strURL);
                mySB.Append(">");
                mySB.Append(strURL);
                mySB.Append("</a>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("</table>");
            }

            //flag = 2 - Account reinstate email notice.
            if (flag == 2)
            {
                strURL = BaseUrl.GetBaseUrl;

                Subject = constant.DomainName + " thông báo phục hồi tài khoản";

                mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left>");
                mySB.Append("<font size=2 color=black face=verdana>");
                mySB.Append("Chào bạn ");
                mySB.Append(Username + ":");
                mySB.Append("<br><br>");
                mySB.Append("Tài khoản của bạn tại ");
                mySB.Append(constant.DomainName);
                mySB.Append(" đã được phục hồi.");
                mySB.Append("<br><br>");
                mySB.Append("Nhấn vào liên kết dưới đây để đăng nhập vào hệ thống.");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left><br>");
                mySB.Append("<font size=2 face=verdana>");
                mySB.Append("<a target=_new href=");
                mySB.Append(strURL);
                mySB.Append(">");
                mySB.Append(strURL);
                mySB.Append("</a>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("</table>");
            }

            int Err = EmailHelper.SendEmail(ToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Email notification to the user
        /// </summary>
        public int SendDeleteAccountNotification(string ToEmail, string Username, string Reason)
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = constant.DomainName + " thông báo xóa tài khoản";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào bạn ");
            mySB.Append(Username + ":");
            mySB.Append("<br><br>");
            mySB.Append("Tài khoản của bạn tại ");
            mySB.Append(constant.DomainName);
            mySB.Append(" đã bị xóa.");
            mySB.Append("<br><br>");
            mySB.Append("<b>Lý do:</b> ");
            mySB.Append(Reason);
            mySB.Append("<br><br>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(ToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Send email article to a friend
        /// </summary>
        public int SendEmailPrivateMessageAlert(string FromUserName, string ToUserName, string ToEmailAddress, string PMSubject)
        {
            StringBuilder mySB = new StringBuilder("");

            string Subject = constant.DomainName + " thông báo tin nhắn";

            string strURL = BaseUrl.GetBaseUrl + "pmview.aspx";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chà bạn");
            mySB.Append("&nbsp;");
            mySB.Append(ToUserName);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(FromUserName);
            mySB.Append("&nbsp;");
            mySB.Append("đã gửi cho bạn một lời nhắn.");
            mySB.Append("<br><br><b>Tiêu đề:</b>");
            mySB.Append("&nbsp;");
            mySB.Append(PMSubject);
            mySB.Append("<br><br>");
            mySB.Append("Nhấn vào liên kết sau hoặc coppy liên kết đó và dán vào trình duyệt của bạn để xem nội dung tin nhắn.");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("<br><br>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(ToEmailAddress, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Email new account activation link
        /// </summary>
        public int SendPassword(string ToEmail, string ToName, string Username, string Password)
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl;

            string Subject = constant.DomainName + " - yêu cầu lấy lại mật khẩu";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào bạn ");
            mySB.Append(ToName);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append("Bạn đã nhận được email này bởi vì bạn (hoặc một ai đó) yêu cầu gửi lại mật khẩu của mình tại ");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(constant.DomainName);
            mySB.Append("</a>");
            mySB.Append("<br><br>");
            mySB.Append("Tài khoản của bạn là: ");
            mySB.Append(Username);
            mySB.Append("<br>");
            mySB.Append("Mật khẩu của bạn là: ");
            mySB.Append(Password);
            mySB.Append("<br>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("Nhấn vào liên kết dưới đây dể đăng nhập vào trang web. ");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(ToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Add a friend email notification
        /// </summary>
        public int AddAFriendEmailNotification(string ToEmail, string ToUserName, string FromUsername)
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "myfriendslist.aspx";

            string Subject = constant.DomainName + " - thông báo kết bạn mới";

            mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left>");
            mySB.Append("<font size=2 color=black face=verdana>");
            mySB.Append("Chào bạn ");
            mySB.Append(ToUserName);
            mySB.Append(":");
            mySB.Append("<br><br>");
            mySB.Append(FromUsername);
            mySB.Append(", ");
            mySB.Append("thêm bạn là người bạn và đang chờ phê duyệt của bạn. Xin vui lòng bấm vào liên kết dưới đây để chấp nhận hoặc từ chối các yêu cầu.");
            mySB.Append("<br>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("<tr>");
            mySB.Append("<td align=left><br>");
            mySB.Append("<font size=2 face=verdana>");
            mySB.Append("<a target=_new href=");
            mySB.Append(strURL);
            mySB.Append(">");
            mySB.Append(strURL);
            mySB.Append("</a>");
            mySB.Append("</font>");
            mySB.Append("</td></tr>");
            mySB.Append("</table>");

            int Err = EmailHelper.SendEmail(ToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }

        /// <summary>
        /// Declined add friend email notification
        /// </summary>
        public int ApprovedOrDeclineAddAFriendEmailNotification(string ToEmail, string ToUserName, string FromUsername, bool IsApproved)
        {
            StringBuilder mySB = new StringBuilder("");

            string strURL = BaseUrl.GetBaseUrl + "myfriendslist.aspx";

            string Subject = "";

            if (IsApproved)
            {
                Subject = constant.DomainName + " - thông báo phê duyệt một ai đó kết bạn với bạn";

                mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left>");
                mySB.Append("<font size=2 color=black face=verdana>");
                mySB.Append("Chào ");
                mySB.Append(ToUserName);
                mySB.Append(":");
                mySB.Append("<br><br>");
                mySB.Append(FromUsername);
                mySB.Append(", ");
                mySB.Append("đã chấp thuận yêu cầu của bạn để thêm vào như một người bạn. Xin vui lòng bấm vào liên kết dưới đây để truy cập vào Danh sách Bạn bè của bạn.");
                mySB.Append("<br>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left><br>");
                mySB.Append("<font size=2 face=verdana>");
                mySB.Append("<a target=_new href=");
                mySB.Append(strURL);
                mySB.Append(">");
                mySB.Append(strURL);
                mySB.Append("</a>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("</table>");
            }
            else
            {
                Subject = constant.DomainName + " - Thông báo từ chối kết bạn";

                mySB.Append("<table cellpadding=0 cellspacing=0 width=800 align=left>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left>");
                mySB.Append("<font size=2 color=black face=verdana>");
                mySB.Append("Chào bạn ");
                mySB.Append(ToUserName);
                mySB.Append(":");
                mySB.Append("<br><br>");
                mySB.Append(FromUsername);
                mySB.Append(", ");
                mySB.Append("đã từ chối yêu cầu của bạn để thêm vào như một người bạn. Xin vui lòng bấm vào liên kết dưới đây để truy cập vào Danh sách Bạn bè của bạn.");
                mySB.Append("<br>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("<tr>");
                mySB.Append("<td align=left><br>");
                mySB.Append("<font size=2 face=verdana>");
                mySB.Append("<a target=_new href=");
                mySB.Append(strURL);
                mySB.Append(">");
                mySB.Append(strURL);
                mySB.Append("</a>");
                mySB.Append("</font>");
                mySB.Append("</td></tr>");
                mySB.Append("</table>");
            }

            int Err = EmailHelper.SendEmail(ToEmail, GetAdminFromEmail, Subject, mySB.ToString());

            return Err;
        }
    }
}