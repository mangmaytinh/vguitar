#region XD World Lyric V 2.8
// FileName: popupuserprofile.cs
// Author: Dexter Zafra
// Date Created: 2/20/2009
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
using VGuitar.BL.Providers.User;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;

public partial class popupuserprofile : BasePage
{
    /**********************************************************************
    * This page is only accessible to Administrator.
    * This page is use in the Admin Membership pahe to view user profile.
    ***********************************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate utility/common object
        Utility Util = new Utility();

        if (!CookieLoginHelper.IsLoginAdminSessionExists)
        {
            PanelIsProfilePublicOrPrivate.Visible = false;
            lblyouarenotauthorizedtoview.Visible = true;
            lblyouarenotauthorizedtoview.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Bạn không được phép để xem trang này.</div>";
        }
        else
        {
            PanelIsProfilePublicOrPrivate.Visible = true;
        }

        string mode;

        //After adding a friend redirect back to this page.
        //Make sure parameter is not empty. The passed in parameter mode is "Success"
        if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
        {
            //Validate to make sure it does not contain illegal characters i.e. HTML tags.
            Util.SecureQueryString(Request.QueryString["mode"]);

            mode = Request.QueryString["mode"];

            lbladdfriendsuccessmsg.Visible = true;
            lbladdfriendsuccessmsg.Text = "<div style='text-align: center; margin-top: 15px; color: #800000;'>Thêm bạn thành công. Một người bạn mới đã được thêm vào Danh sách Bạn bè của bạn.</div>";
        }
        else
        {
            //Assign failed if not coming from redirect page.
            mode = "Failed";
        }

        try
        {
            int userID = (int)Util.Val(Request.QueryString["uid"]);
            int user_ID = UserIdentity.UserID;

            //Get the users settings based on the passed in querystring.
            UserFeaturesConfiguration.Fetch(userID);

            ProviderFriendsList MyFriends = new ProviderFriendsList(userID, UserFeaturesConfiguration.GetNumRecordsFriendsListShow);
            UsersCookBook CookBook = new UsersCookBook(userID, UserFeaturesConfiguration.GetNumRecordsCookBookShow);

            ProviderUserDetails user = new ProviderUserDetails();

            user.FillUp(userID);

            userimage.ImageUrl = GetUserImage.GetImage(user.Photo).ToString();

            lblusernameheader.Text = "Thông tin cá nhân của " + user.Username;
            lblusername.Text = user.Username;
            lblfullname.Text = user.FirstName + "&nbsp;" + user.LastName;
            lblprofileviews.Text = user.Hits.ToString();
            lbllastupdate.Text = Utility.FormatDate(user.LastUpdated);
            lbljoined.Text = Utility.FormatDate(user.DateJoined);
            lbldob.Text = Utility.FormatDate(user.DOB);
            lblcommentedrecipe.Text = user.CommentRecipeCount.ToString();
            lblaboutme.Text = user.AboutMe;
            lblpostedrecipecount.Text = user.PostedRecipeCount.ToString();
            lblpostedarticlecount.Text = user.PostedArticleCount.ToString();
            lblfavfood1.Text = user.FavoriteFoods1;
            lblfavfood2.Text = user.FavoriteFoods2;
            lblfavfood3.Text = user.FavoriteFoods3;
            lblnosavedrecipe.Visible = true;
            lblcity.Text = "NA";
            lblstate.Text = "NA";
            lblnosavedrecipe.Text = "Không có bài hát nào được lưu.";
            lblnofriends.Text = "Không có người bạn nào thêm vào.";
            lbllastlogin.Text = "NA";

            //Show last visit to registered users only.
            if (Authentication.IsUserAuthenticated)
            {
                lbllastlogin.Text = Utility.FormatDate(user.LastLogin);
            }

            if (user.City != "NA")
            {
                lblcity.Text = "<a title href=searchuser.aspx?input=" + user.City + "&condition=4>" + user.City + "</a>";
                lblcity.Attributes.Add("onmouseover", "Tip('Xem tất cả thành viên sống ở <b>" + user.City + "</b>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblcity.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.State != "NA")
            {
                lblstate.Text = "<a title href=searchuser.aspx?input=" + user.State + "&condition=5>" + user.State + "</a>";
                lblstate.Attributes.Add("onmouseover", "Tip('Xem tất cả thành viên sống ở <b>" + user.State + "</b>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblstate.Attributes.Add("onmouseout", "UnTip()");
            }

            lblcountry.Text = "<a title href=searchuser.aspx?input=" + user.Country + "&condition=6>" + user.Country + "</a>";
            lblcountry.Attributes.Add("onmouseover", "Tip('Xem tất cả thành viên sống ở <b>" + user.Country + "</b>', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcountry.Attributes.Add("onmouseout", "UnTip()");

            //Prevent adding himself/herself to the Friends List.
            if (Authentication.IsUserAuthenticated && (user_ID == userID))
            {
                lbladdtofriendslist.Visible = true;
                lbladdtofriendslist.Attributes.Add("onclick", "csscody.alert('<b>Denied Save</b><br>Sorry! You cannot add yourself.');return false;");
                lbladdtofriendslist.Attributes.Add("onmouseover", "Tip('Xin lỗi! Bạn không thể thêm mới<br>chính bạn vào danh sách bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lbladdtofriendslist.Attributes.Add("onmouseout", "UnTip()");
                lbladdtofriendslist.Text = "<a title='Xin lỗi! Bạn không thể thêm chính.' href='javascript:void(0)'>Thêm mới vào danh sách bạn bè</a>";
            }
            else if (Authentication.IsUserAuthenticated && (user_ID != userID))
            {
                //Check mode - adding a friend.
                //This prevent successive clicking after adding a friend
                if (mode == "Success")
                {
                    LinkButtonAddfriendLogin.Visible = false;
                    lbladdtofriendslist.Visible = true;
                    lbladdtofriendslist.Attributes.Add("onclick", "csscody.alert('<b>Không được phép lưu</b><br>Xin lỗi! (" + user.Username + ")  đã tồn tại trong danh sách của bạn.');return false;");
                    lbladdtofriendslist.Attributes.Add("onmouseover", "Tip('Xin lỗi! (" + user.Username + ") đã tồn tại trong danh sách của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                    lbladdtofriendslist.Attributes.Add("onmouseout", "UnTip()");
                    lbladdtofriendslist.Text = "<a title='Xin lỗi! Bạn đã thêm vào người dùng này Danh sách Bạn bè của bạn.' href='javascript:void(0)'>Thêm vào danh sách bạn</a>";
                }
                //Check if the user is already in friends List. If exists, hide linkbutton and show the label link.
                else if (Blogic.IsFriendExists(user_ID, userID))
                {
                    LinkButtonAddfriendLogin.Visible = false;
                    lbladdtofriendslist.Visible = true;
                    lbladdtofriendslist.Attributes.Add("onclick", "csscody.alert('<b>Denied Save</b><br>Sorry! (" + user.Username + ") is already in your Friends List.');return false;");
                    lbladdtofriendslist.Attributes.Add("onmouseover", "Tip('Xin lỗi! (" + user.Username + ") đã tồn tại trong danh sách.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                    lbladdtofriendslist.Attributes.Add("onmouseout", "UnTip()");
                    lbladdtofriendslist.Text = "<a title='Tài khoản đã tồn tại trong danh sách.' href='javascript:void(0)'>Thêm vào Danh sách Bạn bè</a>";
                }
                else
                {
                    LinkButtonAddfriendLogin.Visible = true;
                    LinkButtonAddfriendLogin.Text = "Thêm vào Danh sách Bạn bè";
                    LinkButtonAddfriendLogin.Attributes.Add("onmouseover", "Tip('Thêm (" + user.Username + ") vào danh sách bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                    LinkButtonAddfriendLogin.Attributes.Add("onmouseout", "UnTip()");
                }
            }
            else
            {
                lbladdtofriendslist.Visible = true;
                lbladdtofriendslist.Attributes.Add("onclick", "csscody.alert('<b>Không có quyền nhớ</b><br>Bạn cần đăng nhập để thêm (" + user.Username + ") vào danh sách bạn bè.');return false;");
                lbladdtofriendslist.Attributes.Add("onmouseover", "Tip('bạn cần đăng nhập để thêm (" + user.Username + ") vào danh sách bạn bè.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lbladdtofriendslist.Attributes.Add("onmouseout", "UnTip()");
                lbladdtofriendslist.Text = "<a title='Bạn phải đăng nhập để thêm người dùng này vào Danh sách Bạn bè của bạn.' href='javascript:void(0)'>hêm vào Danh sách Bạn bè</a>";
            }

            if (user.FavoriteFoods1 != "NA")
            {
                lblfavfood1.Text = "<a title='Tìm kiếm' href=" + "searchlyric.aspx?find=" + user.FavoriteFoods1.Replace(" ", "+") + "&catid=0>" + user.FavoriteFoods1 + "</a>";
                lblfavfood1.Attributes.Add("onmouseover", "Tip('Tìm kiếm bài hát (<b>" + user.FavoriteFoods1.Replace(" ", "+") + "</b>).', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblfavfood1.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.FavoriteFoods2 != "NA")
            {
                lblfavfood2.Text = "<a title='Tìm kiếm' target='_blank' href=" + "searchlyric.aspx?find=" + user.FavoriteFoods2.Replace(" ", "+") + "&catid=0>" + user.FavoriteFoods2 + "</a>";
                lblfavfood2.Attributes.Add("onmouseover", "Tip('Tìm kiếm bài hát (<b>" + user.FavoriteFoods1.Replace(" ", "+") + "</b>).', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblfavfood2.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.FavoriteFoods3 != "NA")
            {
                lblfavfood3.Text = "<a title='Tìm kiếm' target='_blank' href=" + "searchlyric.aspx?find=" + user.FavoriteFoods3.Replace(" ", "+") + "&catid=0>" + user.FavoriteFoods3 + "</a>";
                lblfavfood3.Attributes.Add("onmouseover", "Tip('Tìm kiếm bài hát (<b>" + user.FavoriteFoods1.Replace(" ", "+") + "</b>) .', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblfavfood3.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.PostedRecipeCount != 0)
            {
                lblpostedrecipecount.Text = "<a target='_blank' href=" + "findalllyricbyauthor.aspx?author=" + user.Username + ">" + user.PostedRecipeCount + "</a>";
                lblpostedrecipecount.Attributes.Add("onmouseover", "Tip('Xem tất cả bài hát <b>" + user.Username + "</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblpostedrecipecount.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.CommentRecipeCount != 0)
            {
                lblcommentedrecipe.Text = "<a target='_blank' href=" + "findalllyriccommentedbyuser.aspx?commentauthor=" + user.Username + ">" + user.CommentRecipeCount + "</a>";
                lblcommentedrecipe.Attributes.Add("onmouseover", "Tip('Xem tất cả bài hát chia sẻ bởi <b>" + user.Username + "</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                lblcommentedrecipe.Attributes.Add("onmouseout", "UnTip()");
            }

            if (user.SavedrecipeCount != 0)
                lblnosavedrecipe.Visible = false;

            if (user.FriendsCount != 0)
                lblnofriends.Visible = false;

            string websiteURL = user.Website;

            if (websiteURL.IndexOf("http://") == -1)
            {
                lblwebsite.Text = "<a title='Ghé thăm trang web' target='_blank' href=" + "http://" + websiteURL + ">" + websiteURL + "</a>";
            }
            if (websiteURL.IndexOf("http://") != -1)
            {
                lblwebsite.Text = "<a title='Ghé thắm trang web' target='_blank' href=" + websiteURL + ">" + websiteURL + "</a>";
            }
            if (websiteURL == "NA")
            {
                lblwebsite.Text = websiteURL;
            }

            GetMetaTitleTagKeywords(user.Username);

            //Check whether the user wants to make Friends List quick view public in profile page.
            //Public view - everyone who access the profile including non-member will be able to see the quick view.
            //Quick view only show up to 20 items maximun. The main Friends List page can show up to 50 or more...
            if (UserFeaturesConfiguration.IsPublicFriendsListQuickView(userID))
            {
                MyFriendsListPanel.Visible = true;

                MyFriendsList.DataSource = MyFriends.GetFriendsList();
                MyFriendsList.DataBind();

                lblmyfriendscount.Text = "(" + MyFriends.TotalCount.ToString() + ")";
            }
            else
            {
                //Private only - only the owner will see the quick view.
                if (Authentication.IsUserAuthenticated && (user_ID == userID))
                {
                    MyFriendsListPanel.Visible = true;

                    MyFriendsList.DataSource = MyFriends.GetFriendsList();
                    MyFriendsList.DataBind();

                    lblmyfriendscount.Text = "(" + MyFriends.TotalCount.ToString() + ")";
                }
            }

            //Check whether the user wants to make the CookBook quick view public in profile page.
            //Public view - everyone who access the profile including non-member will be able to see the quick view.
            //Quick view only show up to 20 items maximun. The main Cook Book page can show up to 50 or more...
            if (UserFeaturesConfiguration.IsPublicCookBookQuickView(userID))
            {
                MyCookBookPanel.Visible = true;

                SavedUserCookBookProfile.DataSource = CookBook.GetUserRecipeInCookBook();
                SavedUserCookBookProfile.DataBind();

                lblmycookbookcount.Text = "(" + user.SavedrecipeCount.ToString() + ")";
            }
            else
            {
                //Private only - only the owner will see the quick view.
                if (Authentication.IsUserAuthenticated && (user_ID == userID))
                {
                    MyCookBookPanel.Visible = true;

                    SavedUserCookBookProfile.DataSource = CookBook.GetUserRecipeInCookBook();
                    SavedUserCookBookProfile.DataBind();

                    lblmycookbookcount.Text = "(" + user.SavedrecipeCount.ToString() + ")";

                }
            }

            //Release allocated memory
            MyFriends = null;
            CookBook = null;
            user = null;

        }
        catch
        {
            Server.Transfer("pagenotfound.aspx");
        }

        //Clean up memory
        Util = null;
    }

    //Handles add a friend click event
    public void Add_Friend(Object s, EventArgs e)
    {
        //Instantiate utility/common object
        Utility Util = new Utility();

        int FriendID = (int)Util.Val(Request.QueryString["uid"]);

        //Check if user is authenticated from the login.
        if (Authentication.IsUserAuthenticated)
        {
            Blogic.AddNewFriend(UserIdentity.UserID, FriendID);
            Response.Redirect("popupuserprofile.aspx?uid=" + FriendID + "&mode=Success");
        }

        Util = null;
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string UserName)
    {
        //Assign page title and meta keywords
        Page.Header.Title ="Hồ sơ về " + UserName;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Từ khóa";
        //You can add more keywords if you want.
        metaTag.Content = "Hồ sơ về " + UserName;
        this.Header.Controls.Add(metaTag);
    }
}
