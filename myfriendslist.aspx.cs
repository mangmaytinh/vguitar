#region XD World Lyric V 3
// FileName: myfriendslist.cs
// Author: Dexter Zafra
// Date Created: 2/25/2009
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

public partial class myfriendslist : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            HideContentIfNotLogin.Visible = true;

            lblusernameheader.Text = "Danh sách bạn bè của " + UserIdentity.UserName;

            Blogic.UpdateUserLastLogin(UserIdentity.UserID);

            GetMetaTitleTagKeywords(UserIdentity.UserName);
            GetCountUnApprovedNewFriendsLink();
            LoadData();
        }
        else
        {
            GetMetaTitleTagKeywords("Không có quyền xem");
            HideContentIfNotLogin.Visible = false;
            lblyouarenotlogin.Visible = true;
            lblusernameheader.Text = "Không có quyền xem danh sách bạn bè";
            lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Bạn không được phép để xem danh sách Friends. Xin vui lòng đăng nhập để xem Danh sách Bạn bè của bạn.</div>";
        }
    }

    private void LoadData()
    {
        ProviderFriendsListMain MyFriends = new ProviderFriendsListMain(UserIdentity.UserID);

        MyFriendsList.DataSource = MyFriends.GetFriendsList();
        MyFriendsList.DataBind();

        int NumRecordsAllowed = SiteConfiguration.GetConfiguration.NumberOfFriendsInFriendsList;

        int Remaining = NumRecordsAllowed - MyFriends.TotalCount;

        lblcounter.Text = "<img src='images/friendlisticon.gif' align='absmiddle'>&nbsp;&nbsp;Bạn có (" + MyFriends.TotalCount + ") thành viên trong danh sách. Bạn chỉ có quyền nhớ " + NumRecordsAllowed + " Thành viên trong danh sách bạn bè. Bạn còn nhớ thêm được " + Remaining + " thành viên nữa.";

        MyFriends = null;
    }

    private void GetCountUnApprovedNewFriendsLink()
    {
        int CountUnApprovedNewFriends = Blogic.GetCountUnApprovedFriends(UserIdentity.UserID);

        if (CountUnApprovedNewFriends != 0)
        {
            PanelUnApprovedFriends.Visible = true;
            lblcountunpprovednewfriends.Text = "Bạn có <a href='viewunapprovedfriends.aspx'><b>" + CountUnApprovedNewFriends + "</b> thành viên</a> muốn thêm bạn vào danh sách bạn bè của bạn, và đang trờ bạn cho phép.";
            lblcountunpprovednewfriends.Attributes.Add("onmouseover", "Tip('Nhấp vào liên kết để chấp nhận hoặc từ chối yêu cầu của người sử dụng.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblcountunpprovednewfriends.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    public void MyFriendsList_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblDelete = (Label)(e.Item.FindControl("lblDelete"));

            int ID = (int)DataBinder.Eval(e.Item.DataItem, "ID");

            lblDelete.Text = "<a class='thickbox' href='#TB_inline?height=75&width=350&inlineId=confirmModal" + ID + "&modal=true'><img border='0' src='images/icon_delete.gif'></a>";
            lblDelete.Attributes.Add("onmouseover", "Tip('Xóa (<b>" + DataBinder.Eval(e.Item.DataItem, "Username") + "</b>) ra khỏi danh sách.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblDelete.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void GetMetaTitleTagKeywords(string UserName)
    {
        Page.Header.Title = "Danh sách bạn bè của " + UserName;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        metaTag.Content = "Danh sách bạn bè của " + UserName + ".";
        this.Header.Controls.Add(metaTag);
    }
}
