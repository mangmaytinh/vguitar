#region XD World Lyric V 2.8
// FileName: members.cs
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
using VGuitar.Security;
using VGuitar.BL.Providers.User;
using Resources;

public partial class members : BasePage
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
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

        ProviderShowAllUsers Members = new ProviderShowAllUsers(OrderBy, SortBy, PageIndex, PageSize);

        lblcounter.Text = "<img src='images/community-users-icon.jpg' align='absmiddle'>&nbsp;&nbsp;Tổng cộng số thành viên: " + Members.TotalCount;

        PagerLinks Pager = PagerLinks.GetInstance();
        Pager.PagerLinksParam(PageIndex, PageSize, Members.TotalCount);

        lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, iPage);

        lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

        MembersRep.DataSource = Members.GetAllUsers();
        MembersRep.DataBind();

        lblAplhaLetterLinks.Text = AlphabetLink.BuildLinkSearchMembers("searchuser.aspx?input=", "content12", "Duyệt tất cả các thành viên tên bắt đầu bằng chữ cái", "&nbsp;&nbsp;&nbsp;");

        SortOptionLinks(OrderBy, SortBy, iPage);

        Members = null;
    }

    private void SortOptionLinks(int OrderBy, int Sort_By, int iPage)
    {
        if (OrderBy == 1)
        {
            SortLinkHits.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkHits.Text = Resources.lang.Most_Popular; 
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
            SortLinkLastVisit.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkLastVisit.Text = "Ghé thăm gần đây"; //"Last Visit";
            SortLinkLastVisit.ToolTip = "Sắp xếp theo lần ghé thăm gần đây từ dưới lên";
            ArrowImage5.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage5.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkLastVisit.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkLastVisit.Text = "Ghé thăm gần đây"; //"Last Visit";
                SortLinkLastVisit.ToolTip = "Sắp xếp theo lần ghé thăm gần đây từ trên suống";
                ArrowImage5.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage5.Visible = true;
            }
        }
        else
        {
            SortLinkLastVisit.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=2" + "&sb=1&page=" + iPage;
            SortLinkLastVisit.Text = "Ghé thăm gần đây"; //"Last Visit";
            SortLinkLastVisit.ToolTip = "Sắp xếp theo lần ghé thăm gần đây";
            ArrowImage5.Visible = false;
        }

        if (OrderBy == 3)
        {
            SortLinkUsername.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkUsername.Text = "Tài khoản";
            SortLinkUsername.ToolTip = "Sắp xếp theo tài khoản từ dưới lên";
            ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage2.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkUsername.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkUsername.Text = "Tài khoản";
                SortLinkUsername.ToolTip = "Sắp xếp theo tài khoản từ trên suống";
                ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage2.Visible = true;
            }
            if (Sort_By == 0)
            {
                SortLinkUsername.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkUsername.Text = "Tài khoản";
                SortLinkUsername.ToolTip = "Sắp xếp theo tài khoản";
                ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage2.Visible = true;
            }
        }
        else
        {
            SortLinkUsername.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=3" + "&sb=1&page=" + iPage;
            SortLinkUsername.Text = "Tài khoản";
            SortLinkUsername.ToolTip = "Sắp xếp theo tài khoản";
            ArrowImage2.Visible = false;
        }

        if (OrderBy == 4)
        {
            SortLinkDateJoined.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=2&page=" + iPage;
            SortLinkDateJoined.Text = "Ngày đăng ký"; //"Date Joined";
            SortLinkDateJoined.ToolTip = "Xắp xếp theo ngày đăng ký từ trên suống";
            ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
            ArrowImage4.Visible = true;

            if (Sort_By == 2)
            {
                SortLinkDateJoined.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=" + OrderBy + "&sb=1&page=" + iPage;
                SortLinkDateJoined.Text = "Ngày đăng ký";
                SortLinkDateJoined.ToolTip = "Xắp xếp theo ngày đăng ký từ dưới lên";
                ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                ArrowImage4.Visible = true;
            }
        }
        else
        {
            SortLinkDateJoined.NavigateUrl = Request.CurrentExecutionFilePath + "?ob=4&sb=" + Sort_By + "&page=" + iPage;
            SortLinkDateJoined.Text = "Ngày đăng ký";
            SortLinkDateJoined.ToolTip = "Xắp xếp theo ngày đăng ký";
            ArrowImage4.Visible = false;

        }
    }
}

