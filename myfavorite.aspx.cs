#region XD World Lyric V 3
// FileName: MyCookBook.cs
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
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;
using VGuitar.BL.Providers.User;
using Resources;

public partial class myfavorite : BasePage
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
            string UserName = UserIdentity.UserName;

            lblusernameheader.Text = "Mục yêu thích của " +  UserName + "";

            Blogic.UpdateUserLastLogin(UserID);
            GetMetaTitleTagKeywords(UserName);

            LoadData(UserID);
        }
        else
        {
            GetMetaTitleTagKeywords("Không có quyền xem");
            HideContentIfNotLogin.Visible = false;
            lblyouarenotlogin.Visible = true;
            lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Bạn không được phép để xem mục yêu thích. Hãy đăng nhập vào để xem được mục này.</div>";
        }
    }

    private void LoadData(int UserID)
    {
        int OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        int SortBy = (int)Util.Val(Request.QueryString["sb"]);

        string ParamURL = Request.CurrentExecutionFilePath + "?";

        int iPage;

        if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
            iPage = 1;
        else
            iPage = (int)Util.Val(Request.QueryString["page"]);

        int PageSize = 20;
        int PageIndex = iPage;

        ProviderCookBookMainPage CookBook = new ProviderCookBookMainPage(UserID, OrderBy, SortBy, PageIndex, PageSize);

        PagerLinks Pager = PagerLinks.GetInstance();
        Pager.PagerLinksParam(PageIndex, PageSize, CookBook.TotalCount);

        lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, iPage);

        lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

        SavedRecipeInCookBook.DataSource = CookBook.GetUserRecipeInCookBookMain();
        SavedRecipeInCookBook.DataBind();

        int NumRecordsAllowed = SiteConfiguration.GetConfiguration.NumberOfLyricInFavorite;

        int Remaining = NumRecordsAllowed - CookBook.TotalCount;

        lblcounter.Text = "<img src='images/cookbookicon.gif' align='absmiddle'>&nbsp;&nbsp;Bạn có (" + CookBook.TotalCount + ") bài hát trong mục yêu thích. Bạn được phép nhớ tối đa " + NumRecordsAllowed + " bài hát. Hiện tại bạn đã có " + Remaining + " bài hát trong mục yêu thích.";

        SortOptionLinks(OrderBy, SortBy, iPage);

        CookBook = null;
    }

    public void SavedRecipeInCookBook_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblDelete = (Label)(e.Item.FindControl("lblDelete"));

            int ID = (int)DataBinder.Eval(e.Item.DataItem, "itemID");

            lblDelete.Text = "<a class='thickbox' href='#TB_inline?height=75&width=350&inlineId=confirmModal" + ID + "&modal=true'><img border='0' src='images/icon_delete.gif'></a>";
            lblDelete.Attributes.Add("onmouseover", "Tip('Xóa bài hát (<b>" + DataBinder.Eval(e.Item.DataItem, "LyricName") + "</b>) ra khỏi mục yêu thích của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            lblDelete.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void GetMetaTitleTagKeywords(string UserName)
    {
        Page.Header.Title = UserName + " Favorite";
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Từ khóa";
        metaTag.Content = UserName + " Yêu thích.";
        this.Header.Controls.Add(metaTag);
    }

    private void SortOptionLinks(int OrderBy, int Sort_By, int iPage)
    {
        if (OrderBy == 1)
        {
            SortLinkHits.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkHits.Text = lang.Most_Popular;
            SortLinkHits.ToolTip = lang.Sort_by_Most_Popular_ASC_order;
            ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage1.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkHits.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkHits.Text = lang.Most_Popular;
                SortLinkHits.ToolTip = lang.Sort_by_Most_Popular_DESC_order;
                ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage1.Visible = true;
            }
        }
        else
        {
            SortLinkHits.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=1" + "&sb=1&page=" + iPage;
            SortLinkHits.Text = lang.Most_Popular;
            SortLinkHits.ToolTip = lang.Sort_by_Most_Popular;
            ArrowImage1.Visible = false;
        }

        if (OrderBy == 2)
        {
            SortLinkRating.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkRating.Text = "Bầu chọn nhiều nhất";
            SortLinkRating.ToolTip = lang.Sort_by_highest_rated_ASC_order;
            ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage4.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkRating.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkRating.Text = "Bầu chọn nhiều nhất";
                SortLinkRating.ToolTip = lang.Sort_by_highest_rated_DESC_order;
                ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage4.Visible = true;
            }
        }
        else
        {
            SortLinkRating.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=2" + "&sb=1&page=" + iPage;
            SortLinkRating.Text = "Bầu chọn nhiều nhất";
            SortLinkRating.ToolTip = "Bầu chọn nhiều nhất";
            ArrowImage4.Visible = false;
        }

        if (OrderBy == 3)
        {
            SortLinkRecipeName.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkRecipeName.Text = "Tên bài hát";
            SortLinkRecipeName.ToolTip = lang.Sort_by_name_ASC_order;
            ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage2.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkRecipeName.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkRecipeName.Text = "Tên bài hát";
                SortLinkRecipeName.ToolTip = lang.Sort_by_name_DESC_order;
                ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage2.Visible = true;
            }
            if (Sort_By == 0)
            {
                SortLinkRecipeName.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkRecipeName.Text = "Tên bài hát";
                SortLinkRecipeName.ToolTip = lang.Sort_by_name_DESC_order;
                ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage2.Visible = true;
            }
        }
        else
        {
            SortLinkRecipeName.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=3" + "&sb=1&page=" + iPage;
            SortLinkRecipeName.Text = "Tên bài hát";
            SortLinkRecipeName.ToolTip = lang.Sort_by_name;
            ArrowImage2.Visible = false;
        }

        if (OrderBy == 4)
        {
            SortLinkDateAdded.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkDateAdded.Text = "Mới nhất"; //"Date Added";
            SortLinkDateAdded.ToolTip = "Sắp xếp theo ngày đăng bài từ trên xuống dưới";//"Sort by Date Added to CookBook ASC order";
            ArrowImage5.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage5.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkDateAdded.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkDateAdded.Text = "Mới nhất";//"Date Added";
                SortLinkDateAdded.ToolTip = "Sắp xếp theo ngày thêm vào bài từ dưới lên";//"Sort by Date Added to CookBook DESC order";
                ArrowImage5.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage5.Visible = true;
            }
        }
        else
        {
            SortLinkDateAdded.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=4&sb=" + Sort_By + "&page=" + iPage;
            SortLinkDateAdded.Text = "Mới nhất"; //"Date Added";
            SortLinkDateAdded.ToolTip = "Sắp xếp theo ngày nhớ vào mục yêu thích";//"Sort by Date Added to CookBook";
            ArrowImage5.Visible = false;
        }
    }
}
