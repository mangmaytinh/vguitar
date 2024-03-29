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
using VGuitar.BL.Providers.CookBooks;
using VGuitar.Security;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Common.Utilities;

public partial class userconfigfetaures : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int UserID = UserIdentity.UserID;

        UserFeaturesConfiguration.Fetch(UserID);

        int CurentRecordsShowCookBook = UserFeaturesConfiguration.GetNumRecordsCookBookShow;
        int CurentRecordsShowFriendsList = UserFeaturesConfiguration.GetNumRecordsFriendsListShow;

        uconfigcookbookddl.Items.Insert(0, new ListItem(CurentRecordsShowCookBook + " Bài hát", CurentRecordsShowCookBook.ToString()));
        uconfigcookbookddl.Items.Insert(1, new ListItem("5 Bài hát", "5"));
        uconfigcookbookddl.Items.Insert(2, new ListItem("10 Bài hát", "10"));
        uconfigcookbookddl.Items.Insert(3, new ListItem("15 Bài hát", "15"));
        uconfigcookbookddl.Items.Insert(4, new ListItem("20 Bài hát", "20"));

        uconfigfriendslistddl.Items.Insert(0, new ListItem(CurentRecordsShowFriendsList + " Friends", CurentRecordsShowFriendsList.ToString()));
        uconfigfriendslistddl.Items.Insert(1, new ListItem("5 Người", "5"));
        uconfigfriendslistddl.Items.Insert(2, new ListItem("10 Người", "10"));
        uconfigfriendslistddl.Items.Insert(3, new ListItem("15 Người", "15"));
        uconfigfriendslistddl.Items.Insert(4, new ListItem("20 Người", "20"));

        if (UserFeaturesConfiguration.IsPublicFriendsListQuickView(UserID))
            uconfigshowhidefriendslistddl.Items.Insert(0, new ListItem("Hiện danh sách bạn bè", "1"));
        else
            uconfigshowhidefriendslistddl.Items.Insert(0, new ListItem("Ẩn danh sách bạn bè", "0"));

        if (UserFeaturesConfiguration.IsPublicCookBookQuickView(UserID))
            uconfigshowhidecookbookddl.Items.Insert(0, new ListItem("Hiện mục yêu thích", "1"));
        else
            uconfigshowhidecookbookddl.Items.Insert(0, new ListItem("Ẩn mục yêu thích", "0"));
    }

    public void UpdateShowHideFriendsList_Click(object sender, EventArgs e)
    {
        Blogic.UpdateShowHideFriendsListInProfile(UserIdentity.UserID, Int32.Parse(Request.Form[uconfigshowhidefriendslistddl.UniqueID]));

        Response.Redirect("myaccount.aspx?item=fl&status=" + Int32.Parse(Request.Form[uconfigshowhidefriendslistddl.UniqueID]));

    }

    public void UpdateShowHideCookBook_Click(object sender, EventArgs e)
    {
        Blogic.UpdateShowHideCookBookInProfile(UserIdentity.UserID, Int32.Parse(Request.Form[uconfigshowhidecookbookddl.UniqueID]));

        Response.Redirect("myaccount.aspx?item=cb&status=" + Int32.Parse(Request.Form[uconfigshowhidecookbookddl.UniqueID]));
    }

    public void UpdateNumRecordsCookBook_Click(object sender, EventArgs e)
    {
        //Referesh cached
        Caching.PurgeCacheItems("MyCookBook_SideMenu_" + UserIdentity.UserID);

        Blogic.UpdateNumberRecordsCookBookProfile(UserIdentity.UserID, Int32.Parse(Request.Form[uconfigcookbookddl.UniqueID]));

        Response.Redirect("myaccount.aspx?item=cbn&numrecord=" + Int32.Parse(Request.Form[uconfigcookbookddl.UniqueID]));
    }

    public void UpdateNumRecordsFriendsList_Click(object sender, EventArgs e)
    {
        Blogic.UpdateNumberRecordsFriendsListProfile(UserIdentity.UserID, Int32.Parse(Request.Form[uconfigfriendslistddl.UniqueID]));

        Response.Redirect("myaccount.aspx?item=fln&numrecord=" + Int32.Parse(Request.Form[uconfigfriendslistddl.UniqueID]));
    }
}
