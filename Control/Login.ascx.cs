#region XD World Lyric V 2.8

// FileName: Login.ascx.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net

#endregion

using System;
using System.Web.UI;
using VGuitar.BL;
using VGuitar.BL.Providers.User;
using VGuitar.Security;

namespace Control
{
    public partial class Login : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowHideLoginControl(Authentication.Authenticate);
        }

        public void Login_Click(object sender, EventArgs e)
        {
            //Autheticate the username and password against the database record.
            if (Authentication.Validate(uname.Text, Encryption.Encrypt(upass.Text)))
            {
                //Check if the account has been activated through activation link.
                //If the user did not click the activation link sent through the email, then redirect to remind him/her to activate.
                if (!Blogic.IsUserActivated(uname.Text, Encryption.Encrypt(upass.Text)))
                {
                    Context.Response.Redirect("redirectionpage.aspx?mode=notactive&ReturnURL=" +
                                              Context.Request.Url.PathAndQuery);
                }

                //After the user is authenticated and activated, check if the user is not suspended.
                //If the user status is 0, that means the user is suspended due to site policy violation or other reasons.
                //We also have to get rid of any cookie in the users machine to prevent looping 
                //back to the previous page when we redirect the user.
                if (!Blogic.IsUserActive(uname.Text, Encryption.Encrypt(upass.Text)))
                {
                    CookieLoginHelper.RemoveCookie();
                    CookieLoginHelper.RemoveLoginSession();

                    Context.Response.Redirect("redirectionpage.aspx?mode=suspended&ReturnURL=" +
                                              Context.Request.Url.PathAndQuery);
                }

                if ((rememberme.Checked))
                {
                    if ((Request.Browser.Cookies))
                    {
                        CookieLoginHelper.CreateLoginCookie(uname.Text, upass.Text);
                    }
                    else
                    {
                        //If the users browser does not support cookie, use session instead.
                        CookieLoginHelper.CreateLoginSession(uname.Text, upass.Text);
                    }
                }
                else
                {
                    //If the users did not check the remember me checkbox, store login credential in session.
                    CookieLoginHelper.CreateLoginSession(uname.Text, upass.Text);
                }

                Context.Response.Redirect("redirectionpage.aspx?mode=welcome&username=" + uname.Text +
                                          "&ReturnURL=" + Context.Request.Url.PathAndQuery);
            }
            else
            {
                ShowInvalidErrorMsg();
            }
        }

        public void Logout_Click(object sender, EventArgs e)
        {
            CookieLoginHelper.RemoveCookie();
            CookieLoginHelper.RemoveLoginSession();

            loginpanel.Visible = true;
            DisplayUserInfo.Visible = false;

            Context.Response.Redirect("redirectionpage.aspx?mode=thankyoulogout&ReturnURL=" +
                                      Context.Request.Url.PathAndQuery);
        }

        private void ShowInvalidErrorMsg()
        {
            uname.Text = "";
            upass.Text = "";
            Lblinvalidcredential.Visible = true;
        }

        private void ShowHideLoginControl(bool isUserPassValidation)
        {
            if (!isUserPassValidation) return;
            ShowPrivateMessageAlert();
            ShowUnApprovedNewFriendAlert();
            loginpanel.Visible = false;
            DisplayUserInfo.Visible = true;
            lblusername.Text = "<a href='myaccount.aspx'>" + UserIdentity.UserName + "</a>";
            lblusername.Attributes.Add("onmouseover",
                                       "Tip('<a class=content12 href=userprofile.aspx?uid=" + UserIdentity.UserID +
                                       ">Xem hồ sơ</a><br><a class=content12 href=myaccount.aspx>Xem mục tài khoản</a><br><a class=content12 href=pmview.aspx>Xem hòm thư</a><br><a class=content12 href=myfavorite.aspx>Xem mục yêu thích</a><br><a class=content12 href=myfriendslist.aspx>Xem danh sách bạn bè</a><br><a class=content12 href=members.aspx>Xem thành thành viên hệ thống</a>', WIDTH, 200, false, '', false, true, FADEIN, 300, FADEOUT, 300, STICKY, 1, false, true, CLICKCLOSE, true)");
            lblusername.Attributes.Add("onmouseout", "UnTip()");
        }

        private void ShowPrivateMessageAlert()
        {
            int countNewMsg = Blogic.GetUserNewPrivateMessageCount(UserIdentity.UserID);

            if (countNewMsg == 0)
            {
                lblPrivateMessageAlert.Visible = true;
                lblPrivateMessageAlert.Text = "(" + countNewMsg +
                                              ") <img src='images/oldmsg_icon2.gif' border='0' align='absmiddle'>&nbsp;&nbsp;";
                lblPrivateMessageAlert.Attributes.Add("onmouseover",
                                                      "Tip('Chào <b>" + UserIdentity.UserName + "</b> Bạn có (<b>" +
                                                      countNewMsg +
                                                      "</b>) tin nhắn mới trong hộp thư.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db', ABOVE, true)");
                lblPrivateMessageAlert.Attributes.Add("onmouseout", "UnTip()");
            }
            else
            {
                lblPrivateMessageAlert.Visible = true;
                lblPrivateMessageAlert.Text = "(" + countNewMsg +
                                              ") <a href='pmview.aspx'><img src='images/newmsg_icon.gif' border='0' align='absmiddle'></a>&nbsp;&nbsp;";
                lblPrivateMessageAlert.Attributes.Add("onmouseover",
                                                      "Tip('Chào <b>" + UserIdentity.UserName + "</b> bạn có (<b>" +
                                                      countNewMsg +
                                                      "</b>) tin nhắn mới<br>trong hòm thư. Nhấn vào đây để xem<br>hòm thư của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db', ABOVE, true)");
                lblPrivateMessageAlert.Attributes.Add("onmouseout", "UnTip()");
            }
        }

        private void ShowUnApprovedNewFriendAlert()
        {
            int countUnApprovedNewFriends = Blogic.GetCountUnApprovedFriends(UserIdentity.UserID);

            if (countUnApprovedNewFriends == 0) return;
            lblnewfriendalert.Visible = true;
            lblnewfriendalert.Text = "(" + countUnApprovedNewFriends +
                                     ") <a href='viewunapprovedfriends.aspx'><img src='images/friendlisticon-_smll3.gif' border='0' align='absmiddle'></a>&nbsp;&nbsp;";
            lblnewfriendalert.Attributes.Add("onmouseover",
                                             "Tip('Bạn có (<b>" + countUnApprovedNewFriends +
                                             "</b>) bạn muốn làm bạn.<br>Nhấn vào đây để chấp nhận hoặc từ chối.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblnewfriendalert.Attributes.Add("onmouseout", "UnTip()");
        
        }
    }
}