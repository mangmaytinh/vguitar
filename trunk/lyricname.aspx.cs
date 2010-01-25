#region XD World Lyric V 2.8
// FileName: Recipename.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
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
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

public partial class lyricalphaletter : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Declare variables
    private string letter;
    private int OrderBy;
    private int SortBy;
    private int iPage;

    //Variable for the pagesize dropdown menu
    public string psLetter;
    public int psOrderBy;
    public int psSortBy;
    public int psPageSize;
    public int psPageIndex;

    //Variable for layout switcher
    public int pLayout;
    public string SelectedValuePrefLayout;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["ob"]) || !string.IsNullOrEmpty(this.Request.QueryString["sb"]))
        {
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            SortBy = (int)Util.Val(Request.QueryString["sb"]);
            lblsortname.Text = Util.GetSortOptionName(OrderBy) + Util.GetSortOptionOrderBy(SortBy);
        }
        else
        {
            lblsortname.Text = Util.GetSortOptionName(OrderBy);
        }

        string strmetaTag;

        letter = Request.QueryString["letter"].ToString();
        strmetaTag = "Hợp âm bắt đầu với ký tự " + letter;

        //Validate
        Util.SecureQueryString(letter);

        //Repeater databind
        BindList();

        //Get Page title and keywords
        GetMetaTitleTagKeywords(strmetaTag);

        //Release allocated memory
        Util = null;
    }

    //Return databind
    private void BindList()
    {
        letter = Request.QueryString["letter"].ToString();
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        SortBy = (int)Util.Val(Request.QueryString["sb"]);

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?letter=" + letter;

        int GetPage = (int)Util.Val(Request.QueryString["page"]);

        if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
            iPage = 1; 
        else
            iPage = (int)Util.Val(Request.QueryString["page"]);

        if (string.IsNullOrEmpty(this.Request.QueryString["ps"]))
        {
            psPageSize = 10; //If request pagesize is empty, then assign default pagesize of 10
            lbps.Text = " - Đang hiển thị <b>10</b> bài trên một trang";
        }
        else
        {
            psPageSize = (int)Util.Val(Request.QueryString["ps"]); //Grab the querystring pagesize value
            lbps.Text = " - Đang hiển thị <b>" + psPageSize + "</b> bài trên một trang";
        }

        if (psPageSize > 50)
            psPageSize = 10;

        int Layout = (int)Util.Val(Request.QueryString["layout"]);

        //Initialize variable for preferred layout dropdown menu
        SelectedValuePrefLayout = Utility.PreferredLayoutSelectedValue(Layout);
        pLayout = Utility.PreferredLayout(Layout);

        LyricCat.RepeatColumns = pLayout;

        //Initialize variable use for dynamic pagesize dropdown menu.
        psLetter = letter;
        psOrderBy = OrderBy;
        psSortBy = SortBy;
        psPageIndex = iPage;

        //Initialize pagesize and pageindex
        int PageSize = psPageSize;
        int PageIndex = iPage;

        try
        {
            LyricAlphaLetterProvider GetLyric = LyricAlphaLetterProvider.GetInstance();
            GetLyric.LyricAlphaLetterParam(letter, OrderBy, SortBy, PageIndex, PageSize);

            PagerLinks Pager = PagerLinks.GetInstance();
            Pager.PagerLinksParam(PageIndex, PageSize, GetLyric.RecordCount);

            //Get Lyric count and assign it to the label
            lblcount.Text = "(" + GetLyric.RecordCount.ToString() + ") <b>Hợp âm bắt đầu bằng chữ " + letter + "</b>";

            //Display pager link
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, SortBy, GetPage, pLayout);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Get BLL object datasource
            LyricCat.DataSource = GetLyric.GetLyricAlphabetLetter();
            LyricCat.DataBind();
        }
        catch
        {

        }
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string strPageTitle)
    {
        iPage = (int)Util.Val(Request.QueryString["page"]);

        //Assign page title and meta keywords
        Page.Header.Title = PageTitle.Title(strPageTitle, iPage);
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Keywords";
        //You can add more keywords if you want.
        metaTag.Content = PageTitle.Title(strPageTitle, iPage);
        this.Header.Controls.Add(metaTag);
    }

    public void LyricCatItemDataBound(Object s, DataListItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                            (int)DataBinder.Eval(e.Item.DataItem, "Hits"));
    }
}
