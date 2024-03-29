#region XD World Lyric V 2.8

// FileName: myaccount.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net

#endregion

using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VGuitar.BL;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;
using VGuitar.BL.Providers.User;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using VGuitar.UI;

public partial class myaccount : BasePage
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            HideContentIfNotLogin.Visible = true;

            int UserID = UserIdentity.UserID;
            string Username = UserIdentity.UserName;

            Blogic.UpdateUserLastLogin(UserID);

            lblusernameheader.Text = "Tài khoản:" + Username;

            ProviderUserDetails user = new ProviderUserDetails();

            user.FillUp(UserID);

            lbllastactivitymsg.Text = " Hoạt động lần cuối vào lúc: (<span style='color: #800000'>" +
                                      string.Format("{0:g}", user.LastLogin) + "</span>)";
            lblmyprofilelink.Text = "<img src='images/user1_icon.gif'>&nbsp;<a href=userprofile.aspx?uid=" + UserID +
                                    ">Hồ sơ của bạn</a>";
            lbleditmyprofile.Text =
                "<img src='images/editsmall.gif'>&nbsp;<a href='editprofile.aspx'>Sửa hồ sơ</a>";
            lblmycookbooklink.Text =
                "<img src='images/cookbookicon_smll.gif'>&nbsp;<a href='myfavorite.aspx'>Mục yêu thích</a>";
            lblmyfriendslistlink.Text =
                "<img src='images/friendlisticon_smll.gif'>&nbsp;<a href='myfriendslist.aspx'>Danh sách bạn bè</a>";
            lblmypminbox.Text = "<img src='images/newmsg_icon_smll2.gif'>&nbsp;<a href='pmview.aspx'>Hộp thư</a>";
            lblmyprofilelink.Attributes.Add("onmouseover",
                                            "Tip('Xem hồ sơ của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblmyprofilelink.Attributes.Add("onmouseout", "UnTip()");
            lbleditmyprofile.Attributes.Add("onmouseover",
                                            "Tip('Cập nhật thông tin, thay đổi mật khẩu, email và ảnh.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lbleditmyprofile.Attributes.Add("onmouseout", "UnTip()");
            lblmycookbooklink.Attributes.Add("onmouseover",
                                             "Tip('Xem mục yêu thích của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblmycookbooklink.Attributes.Add("onmouseout", "UnTip()");
            lblmyfriendslistlink.Attributes.Add("onmouseover",
                                                "Tip('Xem danh sách bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblmyfriendslistlink.Attributes.Add("onmouseout", "UnTip()");
            lblmypminbox.Attributes.Add("onmouseover",
                                        "Tip('Xem hòm thư của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblmypminbox.Attributes.Add("onmouseout", "UnTip()");

            GetMetaTitleTagKeywords(Username);
            GetMyStatisticsCounter(user);
            GetCounters(user);
            GetUserWhoAddMeInFriendsList(UserID);
            GetLast5UsersWhoSavedMyRecipeInCookBook(UserID);
            GetDDLSelectedValue();
            GetStatisticsCounters();
            GetReturnFromUpdateMsg();

            user = null;
        }
        else
        {
            GetMetaTitleTagKeywords("Không cho phép xem");
            HideContentIfNotLogin.Visible = false;
            lblyouarenotlogin.Visible = true;
            lblusernameheader.Text = "Tài khoản của bạn bị từ chối xem";
            lblyouarenotlogin.Text =
                "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Bạn không được phép vào trang Tài khoản của tôi. Xin vui lòng đăng nhập để xem tài khoản của bạn.</div>";
        }
    }

    private void GetStatisticsCounters()
    {
        ProviderSiteStatistics Statistics = new ProviderSiteStatistics();
        Statistics.fillup();

        lbltotalrecipe.Text = "Hợp âm: " + string.Format("{0:#,###}", Statistics.TotalLyric);
        lbltotalarticle.Text = "Bài viết: " + Statistics.TotalArticle;
        lbltotalrecipecomments.Text = "Lời bình hợp âm: " + Statistics.TotalRecipeComments;
        lbltotalarticlecomments.Text = "Lời bình bài viết : " + Statistics.TotalArticleComments;
        lbltotalsavedrecipeincookbook.Text = "Mục yêu thích: " + Statistics.TotalSavedRecipesInCookBook;
        lbltotaluserswhousecookbook.Text = "Thành viên trong mục yêu thích: " + Statistics.TotalUsersWhoUseCookBook;
        lbltotaluserswhousefriendslist.Text = "Bạn bè: " + Statistics.TotalUsersWhoUseFriendsList;
        lbltotalprivatemessage.Text = "Tin nhắn: " + Statistics.TotalPrivateMessage;
        lbltotalRegisteredUsers.Text = "Số thành viên: <a href='members.aspx'>" + Statistics.TotalMembers + "</a>";
        lbltotalRegisteredUsers.Attributes.Add("onmouseover",
                                               "Tip('Nhấn vào đây xem thành viên của website.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
        lbltotalRegisteredUsers.Attributes.Add("onmouseout", "UnTip()");
        lbltotaluserjoinedtoday.Text = "Thành viên ngày hôm nay: " + Statistics.TotalUsersJoinedToday;
        lbltotaluserjoininaweek.Text = "Thành viên 7 ngày gần đây: " + Statistics.TotalUsersJoinedInAWeek;
        lbltotaluserjoinedinamonth.Text = "Thành viên 30 ngày gần đây: " + Statistics.TotalUsersJoinedInAMonth;

        Statistics = null;
    }

    private void GetMyStatisticsCounter(ProviderUserDetails user)
    {
        lblcountmysavedrecipe.Text = "Yêu thích: " + user.SavedrecipeCount;
        lblcountmyfriends.Text = "Bạn bè: " + user.FriendsCount;
        lblcommentedrecipe.Text = "Lời bình hợp âm: " + user.CommentRecipeCount;
        lblpostedrecipecount.Text = "Hợp âm: " + user.PostedRecipeCount;
        lblpostedarticlecount.Text = "Bài viết: " + user.PostedArticleCount;
        lblcommentarticle.Text = "Lời bình bài viết: " + user.CommentArticleCount;

        if (user.SavedrecipeCount != 0)
        {
            lblcountmysavedrecipe.Text = "Yêu thích:&nbsp;<a href='myfavorite.aspx'>" + user.SavedrecipeCount + "</a>";
            lblcountmysavedrecipe.Attributes.Add("onmouseover",
                                                 "Tip('Xem mục yêu thích của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcountmysavedrecipe.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.FriendsCount != 0)
        {
            lblcountmyfriends.Text = "Bạn bè:&nbsp;<a href='myfriendslist.aspx'>" + user.FriendsCount + "</a>";
            lblcountmyfriends.Attributes.Add("onmouseover",
                                             "Tip('Xem danh sách bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcountmyfriends.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.PostedRecipeCount != 0)
        {
            lblpostedrecipecount.Text = "Hợp âm của bạn:&nbsp;<a href=" + "findalllyricbyauthor.aspx?author=" +
                                        user.Username + ">" + user.PostedRecipeCount + "</a>";
            lblpostedrecipecount.Attributes.Add("onmouseover",
                                                "Tip('Xem những bài hát hợp âm bạn chia sẻ.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblpostedrecipecount.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.PostedArticleCount != 0)
        {
            lblpostedarticlecount.Text = "Bài viết của:&nbsp;<a href=" + "findallarticlebyauthor.aspx?author=" +
                                         user.Username + ">" + user.PostedArticleCount + "</a>";
            lblpostedarticlecount.Attributes.Add("onmouseover",
                                                 "Tip('Xem tất cả bài viết bạn đã chia sẻ.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblpostedarticlecount.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.CommentRecipeCount != 0)
        {
            lblcommentedrecipe.Text = "Lời bình hợp âm:&nbsp;<a href=" +
                                      "findalllyriccommentedbyuser.aspx?commentauthor=" + user.Username + ">" +
                                      user.CommentRecipeCount + "</a>";
            lblcommentedrecipe.Attributes.Add("onmouseover",
                                              "Tip('Xem tất cả lời bình cho các hợp âm của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcommentedrecipe.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.CommentArticleCount != 0)
        {
            lblcommentarticle.Text = "Lời bình bài viết:&nbsp;<a href=" + "findallarticlecommentbyuser.aspx?author=" +
                                     user.Username + ">" + user.CommentArticleCount + "</a>";
            lblcommentarticle.Attributes.Add("onmouseover",
                                             "Tip('Xem tất cả lời bình cho các bài viết của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcommentarticle.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void GetUserWhoAddMeInFriendsList(int UserID)
    {
        //Get all users who add me in their Friends List.
        //This gives user some info who are the user added him/her in Friends list.
        ProvidersListOfUserWhoAddedMe Who = new ProvidersListOfUserWhoAddedMe(UserID);

        WhoAddsMe.DataSource = Who.GetUsers();
        WhoAddsMe.DataBind();

        int CountUsers = Blogic.GetCountUserWhoAddMeInFriendsList(UserID);

        if (CountUsers != 0)
        {
            lblcountwhoaddmeinfriendslist.Text = "Có tất cả (" + CountUsers + ") thành viên.";
        }
        else
        {
            lblcountwhoaddmeinfriendslist.Text = "Không có thành viên nào thêm bạn vào danh sách bạn bè của họ.";
        }

        Who = null;
    }

    private void GetLast5UsersWhoSavedMyRecipeInCookBook(int UserID)
    {
        ProviderLast5UsersWhoSavedMyRecipe WhoSavedMyRecipe = new ProviderLast5UsersWhoSavedMyRecipe(UserID);

        Last5UsersWhoSavedMyRecipe.DataSource = WhoSavedMyRecipe.GetUsers();
        Last5UsersWhoSavedMyRecipe.DataBind();

        int CountUsers = Blogic.GetCountUsersWhoSavedMyLyricInFavorite(UserID);

        if (CountUsers != 0)
        {
            lblcountuserswhosavedmyrecipe.Text = "Có tất cả (" + CountUsers + ") thành viên.";
        }
        else
        {
            lblcountuserswhosavedmyrecipe.Text = "Không có thành viên nào thêm hợp âm bạn chia sẻ vào danh sách yêu thích của họ.";
        }

        WhoSavedMyRecipe = null;
    }

    private void GetDDLSelectedValue()
    {
        UserFeaturesConfiguration.Fetch(UserIdentity.UserID);

        int layout = UserFeaturesConfiguration.GetUserPreferredLayout;
        int pagesize = UserFeaturesConfiguration.GetUserPreferredPageSize;

        if ((UserFeaturesConfiguration.IsUserChoosePreferredLayoutPageSize))
        {
            uconfigturnonofflayoutpagesize.Items.Insert(0, new ListItem("Cho phép", "1"));
        }
        else
        {
            uconfigturnonofflayoutpagesize.Items.Insert(0, new ListItem("Không cho phép", "0"));
        }

        switch (layout)
        {
            case 1:
                uconfigpreflayout.Items.Insert(0, new ListItem("Hiển thị - Hàng", layout.ToString()));
                break;

            case 2:
                uconfigpreflayout.Items.Insert(0, new ListItem("Hiển thị - 2 cột", layout.ToString()));
                break;

            case 3:
                uconfigpreflayout.Items.Insert(0, new ListItem("Hiển thị - 3 cột", layout.ToString()));
                break;
        }

        if (UserFeaturesConfiguration.IsUserChooseToReceivePM)
        {
            uconfigreceivepm.Items.Insert(0, new ListItem("Nhận Tin nhắn - Cho phép", "1"));
        }
        else
        {
            uconfigreceivepm.Items.Insert(0, new ListItem("Nhận Tin nhắn - Không cho phép", "0"));
        }

        if (UserFeaturesConfiguration.IsUserChooseToReceiveEmailAlertReceivePM)
        {
            uconfigreceivepmemailalert.Items.Insert(0, new ListItem("Nhận thông báo Email - Cho phép", "1"));
        }
        else
        {
            uconfigreceivepmemailalert.Items.Insert(0, new ListItem("Nhận thông báo Email - Không cho phép", "0"));
        }

        uconfigprefpagesize.Items.Insert(0, new ListItem(pagesize + " Bản ghi trên trang", pagesize.ToString()));
    }

    private void GetCounters(ProviderUserDetails user)
    {
        if (user.PostedRecipeCount != 0)
        {
            lblviewallmysubmittedrecipe.Text = "<img src='images/editsmall.gif'>&nbsp;<a href=" +
                                               "findalllyricbyauthor.aspx?author=" + user.Username +
                                               ">Sửa hợp âm</a>";
            lblviewallmysubmittedrecipe.Attributes.Add("onmouseover",
                                                       "Tip('Bạn đã chia sẻ với chúng tôi (" + user.PostedRecipeCount +
                                                       ") bài hợp âm.<br>Nhấn vào đây để xem hoặc chỉnh sửa tất cả các bài hợp âm được bạn chia sẻ với chúng tôi.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblviewallmysubmittedrecipe.Attributes.Add("onmouseout", "UnTip()");
        }
        else
        {
            lblviewallmysubmittedrecipe.Text =
                "<img src='images/editsmall.gif'>&nbsp;<a href='javascript:void(0)'>Sửa những bài hợp âm của bạn</a>";
            lblviewallmysubmittedrecipe.Attributes.Add("onmouseover",
                                                       "Tip('Bạn không chia se bài hợp âm nào.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblviewallmysubmittedrecipe.Attributes.Add("onmouseout", "UnTip()");
        }

        if (user.PostedArticleCount != 0)
        {
            lblviewallmypublishedarticle.Text = "<img src='images/editsmall.gif'>&nbsp;<a href=" +
                                                "findallarticlebyauthor.aspx?author=" + user.Username +
                                                ">Sửa bài viết</a>";
            lblviewallmypublishedarticle.Attributes.Add("onmouseover",
                                                        "Tip('Bạn đã chia sẻ (" + user.PostedArticleCount +
                                                        ") bài viết.<br>Nhấn vào xem hoặc sửa các bài viết của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblviewallmypublishedarticle.Attributes.Add("onmouseout", "UnTip()");
        }
        else
        {
            lblviewallmypublishedarticle.Text =
                "<img src='images/editsmall.gif'>&nbsp;<a href='javascript:void(0)'>Sửa bài viết</a>";
            lblviewallmypublishedarticle.Attributes.Add("onmouseover",
                                                        "Tip('Bạn không chia sẻ bài viết nào.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblviewallmypublishedarticle.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void GetReturnFromUpdateMsg()
    {
        string item = "";
        int status = 0;

        //After updating settings in Myaccount.aspx
        //Make sure parameter is not empty. The passed in parameter mode is "Success"
        if (!string.IsNullOrEmpty(Request.QueryString["item"]) && !string.IsNullOrEmpty(Request.QueryString["status"]))
        {
            item = Request.QueryString["item"];
            status = (int) Util.Val(Request.QueryString["status"]);

            lblupdatesettingsmsg.Visible = true;

            //Public/Private redirection return message
            if (item == "fl")
            {
                switch (status)
                {
                    case 0:
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Danh sách bạn không được công bố.</div>";
                        break;
                    case 1:
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Danh sách bạn được công bố.</div>";
                        break;
                }
            }
            else if (item == "cb")
            {
                switch (status)
                {
                    case 0:
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'>Cập nhật thành công - Danh sách yêu thích không được công bố.</div>";
                        break;
                    case 1:
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Danh sách yêu thích được công bố.</div>";
                        break;
                }
            }
        }

        if (!string.IsNullOrEmpty(Request.QueryString["item"]) &&
            !string.IsNullOrEmpty(Request.QueryString["numrecord"]))
        {
            item = Request.QueryString["item"];
            int numrecord = (int) Util.Val(Request.QueryString["numrecord"]);

            lblupdatesettingsmsg.Visible = true;

            if (item == "fln")
            {
                lblupdatesettingsmsg.Text =
                    "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành cống - Danh sách bạn sẽ được hiển thị trong trang hồ sơ là " +
                    numrecord + " người.</div>";
            }
            else if (item == "cbn")
            {
                lblupdatesettingsmsg.Text =
                    "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành cống - Mục yêu thích sẽ được hiện thị trong trang hồ sơ là " +
                    numrecord + " bài.</div>";
            }
        }

        if (!string.IsNullOrEmpty(Request.QueryString["save"]))
        {
            lblupdatesettingsmsg.Visible = true;
            lblupdatesettingsmsg.Text =
                "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Cấu hình hiển thị đã được thay đổi.</div>";
        }

        if (!string.IsNullOrEmpty(Request.QueryString["method"]) &&
            !string.IsNullOrEmpty(Request.QueryString["setting"]))
        {
            string method = Request.QueryString["method"];
            int settingval = (int) Util.Val(Request.QueryString["setting"]);

            lblupdatesettingsmsg.Visible = true;

            switch (method)
            {
                case "receivepm":
                    if (settingval == 1)
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Bạn có thể nhận được tin nhắn từ các thành viên khác.</div>";
                    else
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Bạn không thể nhận được tin nhắn từ các thành viên khác.</div>";
                    break;

                case "pmemailalert":
                    if (settingval == 1)
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Bạn sẽ nhận được email thông báo khi có một tin nhắn mới.</div>";
                    else
                        lblupdatesettingsmsg.Text =
                            "<div style='width: 450px; margin-left: 20px; margin-top: 15px; color: #800000;'><img src='images/availuname.gif'> Cập nhật thành công - Bạn sẽ không nhận được email thông báo khi có một tin nhắn mới.</div>";
                    break;
            }
        }
    }

    public void UpdatePreferredLayoutPageSize_Click(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            Blogic.ConfigurePreferredLayoutPagesize(UserIdentity.UserID,
                                                    Int32.Parse(Request.Form[uconfigturnonofflayoutpagesize.UniqueID]),
                                                    Int32.Parse(Request.Form[uconfigpreflayout.UniqueID]),
                                                    Int32.Parse(Request.Form[uconfigprefpagesize.UniqueID]));

            Response.Redirect("confirmlayoutchange.aspx?ReturnURL=" + Request.Url.PathAndQuery + "&flag=1");
        }
    }

    public void UpdateReceivePM_Click(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            Blogic.UpdateReceivePM(UserIdentity.UserID, Int32.Parse(Request.Form[uconfigreceivepm.UniqueID]));

            Response.Redirect("confirmupdatepmconfig.aspx?mode=receivepm&val=" +
                              Int32.Parse(Request.Form[uconfigreceivepm.UniqueID]));
        }
    }

    public void UpdateReceivePMEmailAlert_Click(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            Blogic.UpdateReceivePMEmailAlert(UserIdentity.UserID,
                                             Int32.Parse(Request.Form[uconfigreceivepmemailalert.UniqueID]));

            Response.Redirect("confirmupdatepmconfig.aspx?mode=pmemailalert&val=" +
                              Int32.Parse(Request.Form[uconfigreceivepmemailalert.UniqueID]));
        }
    }

    private void GetMetaTitleTagKeywords(string UserName)
    {
        Page.Header.Title = "Trang tài khoản của : " + UserName;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Từ khóa";
        metaTag.Content = "Trang tài khoản của : " + UserName;
        Header.Controls.Add(metaTag);
    }
}