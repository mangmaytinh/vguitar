#region XD World Lyric V 3
// FileName: AjaxRequest.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.BL;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using VGuitar.BL.Providers.User;
using VGuitar.BL.Providers.PrivateMessages;
using VGuitar.BL.Providers.Events;

public partial class AjaxRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.Clear();

        if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
        {
            string mode = Request.QueryString["mode"];

            switch (mode)
            {
                case "checkusername":
                    CheckIfUserNameExists();
                    break;

                case "checkemail":
                    CheckIfEmailExists();
                    break;

                case "recoverpass":
                    RecoverLostPassword();
                    break;

                case "markpmold":
                    MarkPrivateMessageAsOldMessage();
                    break;

                case "markpmoldIconImg":
                    MarkPMAsOldMessageOnImageIconClick();
                    break;

                case "movetotrash":
                    MovePrivateMessageToTrash();
                    break;

                case "movetoinbox":
                    MovePrivateMessageBackToInbox();
                    break;

                case "delcookbook":
                    DeleteUserRecipeInCookBook();
                    break;

                case "delfriend":
                    DeleteAFriend();
                    break;

                case "delinboxpm":
                    DeleteInBoxPM();
                    break;

                case "delsentpm":
                    DeleteSentPM();
                    break;

                case "emptytrash":
                    EmptyPMTrash();
                    break;

                case "pubeventdetails":
                    GetPublicEventDetails();
                    break;
            }
        }

        Response.End();
    }

    private void CheckIfEmailExists()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["email"]) && Utility.IsQueryStringSecure(Request.QueryString["email"]))
        {
            string Email;
            Email = Request.QueryString["email"];

            if (Blogic.IsEmailExists(Email))
            {
                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/takenuname.gif'> " + Email + " đã được sử dụng.</span>");
            }
            else
            {
                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/availuname.gif'> " + Email + " có thể sử dụng.</span>");
            }
        }
        else
        {
            Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/takenuname.gif'> không đúng định dạng.</span>");
        }
    }

    private void CheckIfUserNameExists()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["uname"]) && Utility.IsQueryStringSecure(Request.QueryString["uname"]))
        {
            string Username;
            Username = Request.QueryString["uname"];

            if (Blogic.IsUsernameAvailable(Username))
            {
                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/availuname.gif'> " + Username + " có thể sử dụng.</span>");
            }
            else
            {
                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/takenuname.gif'> " + Username + " không thể sử dụng.</span>");
            }
        }
        else
        {
            Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'><img src='images/takenuname.gif'> không đúng định dạng.</span>");
        }
    }

    private void RecoverLostPassword()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["email"]) && Utility.IsQueryStringSecure(Request.QueryString["email"]))
        {
            string Email;
            Email = Request.QueryString["email"];

            if (Blogic.IsEmailExists(Email))
            {
                EmailTemplate SendCredential = new EmailTemplate();

                lostpassword.GetUserCredential(Email);

                SendCredential.SendPassword(Email, lostpassword.GetFirstname, lostpassword.GetUserName, Encryption.Decrypt(lostpassword.GetUserPass));

                SendCredential = null;

                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 6px;'><img src='images/takenuname.gif'> Thông tin đăng nhập của bạn đã được gửi đến " + Email + ".</span>");
            }
            else
            {
                Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 6px;'><img src='images/takenuname.gif'> Không có tài khoản nào ứng với email " + Email + ".</span>");
            }
        }
        else
        {
            Response.Write("<span class='content12' style='border: solid 1px #800000; padding: 3px;'>Email không đúng định dạng.</span>");
        }
    }

    private void MarkPrivateMessageAsOldMessage()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["pmid"]))
            {
                Blogic.ActionProcedureDataProvider.MarkPMasOldMsgViaAjax(int.Parse(Request.QueryString["pmid"]), UserIdentity.UserID);

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void MarkPMAsOldMessageOnImageIconClick()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && !string.IsNullOrEmpty(Request.QueryString["uid"]) && !string.IsNullOrEmpty(Request.QueryString["val"]))
            {
                if (Utility.IsNumeric(Request.QueryString["uid"]) && Utility.IsNumeric(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["val"]))
                {
                    Blogic.MarkMessageUnreadOrRead(int.Parse(Request.QueryString["uid"]), int.Parse(Request.QueryString["pmid"]), int.Parse(Request.QueryString["val"]));
                }

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void MovePrivateMessageToTrash()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["pmid"]))
            {
                Blogic.MovePMToTrash(UserIdentity.UserID, int.Parse(Request.QueryString["pmid"]));

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void MovePrivateMessageBackToInbox()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["pmid"]))
            {
                Blogic.MovePMBackToInbox(UserIdentity.UserID, int.Parse(Request.QueryString["pmid"]));

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void DeleteInBoxPM()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["pmid"]))
            {
                PrivateMessageRepository Message = new PrivateMessageRepository();
                Message.LyricUserID = UserIdentity.UserID;
                Message.ID = int.Parse(Request.QueryString["pmid"]);

                Message.Delete(Message);

                Message = null;

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void DeleteSentPM()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pmid"]) && Utility.IsNumeric(Request.QueryString["pmid"]))
            {
                PrivateMessageRepository SentMessage = new PrivateMessageRepository();
                SentMessage.SenderUserID = UserIdentity.UserID;
                SentMessage.ID = int.Parse(Request.QueryString["pmid"]);

                SentMessage.DeleteSentPM(SentMessage);

                SentMessage = null;

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Not Authorized.");
        }
    }

    private void EmptyPMTrash()
    {
        if (Authentication.IsUserAuthenticated)
        {
            Blogic.DeleteAllPMInTrash(UserIdentity.UserID);

            Response.Write(" ");
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void DeleteUserRecipeInCookBook()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["rid"]) && Utility.IsNumeric(Request.QueryString["rid"]))
            {
                Blogic.DeleteIndividualLyricInFavorite(UserIdentity.UserID, int.Parse(Request.QueryString["rid"]));

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền");
        }
    }

    private void DeleteAFriend()
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["fid"]) && Utility.IsNumeric(Request.QueryString["fid"]))
            {
                Blogic.DeleteFriend(UserIdentity.UserID, int.Parse(Request.QueryString["fid"]));

                Response.Write(" ");
            }
        }
        else
        {
            Response.Write("Không có quyền.");
        }
    }

    private void GetPublicEventDetails()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Utility.IsNumeric(Request.QueryString["id"]))
        {
            int ID = int.Parse(Request.QueryString["id"]);

            ProviderGetPublicEventDetail PubEventDetail = new ProviderGetPublicEventDetail();
            PubEventDetail.FillUp(ID);

            int NumDaysDiff = Utility.DateDiff(PubEventDetail.StartDate, PubEventDetail.EndDate);

            StringBuilder mySB = new StringBuilder();

            if (NumDaysDiff > 1)
            {
                mySB.Append("<div style='padding: 4px; background-color: #88B5FF;'>");
                mySB.Append("<span style='font-size: 14px; color: #fff;'>");
                mySB.Append("<b>");
                mySB.Append(Utility.GetDayNameAbbrev(PubEventDetail.StartDate.DayOfWeek.ToString()));
                mySB.Append(", " + Utility.GetMonthNameOrAbbrev(int.Parse(PubEventDetail.StartDate.Month.ToString()), true));
                mySB.Append(" " + int.Parse(PubEventDetail.StartDate.Day.ToString()));
                mySB.Append(" - " + Utility.GetDayNameAbbrev(PubEventDetail.EndDate.DayOfWeek.ToString()));
                mySB.Append(", " + Utility.GetMonthNameOrAbbrev(int.Parse(PubEventDetail.EndDate.Month.ToString()), true));
                mySB.Append(" " + int.Parse(PubEventDetail.EndDate.Day.ToString()));
                mySB.Append("</b>");
                mySB.Append("</span>");
                mySB.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("<a title='close' href='javascript: closeEvent()' style='color: #fff;'>");
                mySB.Append("Close");
                mySB.Append("</a>");
                mySB.Append("</div>");
            }
            else
            {
                mySB.Append("<div style='padding: 4px; background-color: #88B5FF;'>");
                mySB.Append("<span style='font-size: 14px; color: #fff;'>");
                mySB.Append("<b>");
                mySB.Append(Utility.GetDayNameAbbrev(PubEventDetail.StartDate.DayOfWeek.ToString()));
                mySB.Append(", " + Utility.GetMonthNameOrAbbrev(int.Parse(PubEventDetail.StartDate.Month.ToString()), true));
                mySB.Append(" " + int.Parse(PubEventDetail.StartDate.Day.ToString()));
                mySB.Append("</b>");
                mySB.Append("</span>");
                mySB.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("<a title='close' href='javascript: closeEvent()' style='color: #fff;'>");
                mySB.Append("Close");
                mySB.Append("</a>");
                mySB.Append("</div>");
            }

            mySB.Append("<div style='clear:both;'></div>");
            mySB.Append("<div style='margin: 6px; line-height: 17px;''>");
            mySB.Append("<span style='font-size: 16px;'>");
            mySB.Append("<b>" + PubEventDetail.EventTitle + "</b>");
            mySB.Append("</span><br>");
            mySB.Append("<b>Kiểu:</b>&nbsp;");
            mySB.Append(PubEventDetail.EventType);

            if (PubEventDetail.EventType == "Appointment" || PubEventDetail.EventType == "Meeting")
            {
                mySB.Append("<br>");
                mySB.Append("<b>Thời gian:</b>&nbsp;");
                mySB.Append(PubEventDetail.AppMeetingStartTime);
                mySB.Append(" - ");
                mySB.Append(PubEventDetail.AppMeetingEndTime);
            }

            mySB.Append("</div>");
            mySB.Append("<div style='margin: 6px'>");
            mySB.Append(PubEventDetail.EventDetails.ToString());
            mySB.Append("<br><br>");
            mySB.Append("<b>By:</b>&nbsp;");
            mySB.Append("<a title='Xem hồ sơ' style='color: #007AF4;' href=userprofile.aspx?uid=" + PubEventDetail.UID + ">" + PubEventDetail.UserName + "</a>");
            mySB.Append("</div>");

            if (Authentication.IsUserAuthenticated && (PubEventDetail.UID == UserIdentity.UserID))
            {
                mySB.Append("<div style='margin: 8px; text-align: left;'>");
                mySB.Append("<a title='Sửa sự kiện' href='editevent.aspx' style='color: #007AF4;'>");
                mySB.Append("Edit");
                mySB.Append("</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                mySB.Append("<a title='Xóa sự kiện' href='deleteevent.aspx' style='color: #007AF4;'>");
                mySB.Append("Delete");
                mySB.Append("</a>");
                mySB.Append("</div");
            }

            mySB.Append("<div style='margin: 8px; text-align: left;'>");
            mySB.Append("<a title='close' href='javascript: closeEvent()' style='font-size: 10px; color: #007AF4;'>");
            mySB.Append("Close");
            mySB.Append("</a>");
            mySB.Append("</div");

            Response.Write(mySB);

            mySB = null;
            PubEventDetail = null;
        }
    }
}
