#region XD World Lyric V 2.8
// FileName: searchrecipe.cs
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

public partial class searchlyric : BasePage
{
    //Instantiate utility/common object
    Utility Util = new Utility();

    //Declare variables
    private string strKeyword;
    private int OrderBy;
    private int CatId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request.QueryString["ob"]))
        {
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            lblsortname.Text = Util.GetSortOptionName(OrderBy);
        }
        else
        {
            lblsortname.Text = "";
        }

        strKeyword = Request.QueryString["find"].ToString();
        string strmetaTag = "Kết quả tìm kiếm cho từ khóa " + strKeyword;

        //Get Page title and keywords
        GetMetaTitleTagKeywords(strmetaTag);

        BindList();

        //Release allocated memory
        Util = null;
    }

    //Return databind
    private void BindList()
    {
        CatId = (int)Util.Val(Request.QueryString["catid"]);
        strKeyword = Request.QueryString["find"].ToString();
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);

        //Get the current file path
        string ParamURL = Request.CurrentExecutionFilePath + "?find=" + strKeyword + "&catid=" + CatId;

        int GetPage = (int)Util.Val(Request.QueryString["page"]);

        int iPage;

        if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
            iPage = 1; 
        else
            iPage = (int)Util.Val(Request.QueryString["page"]);

        //Initialize pagesize and pageindex
        int PageSize = PagerLinks.DefaultPageSize;
        int PageIndex = iPage;

        try
        {
            LyricSearchProvider GetLyric = LyricSearchProvider.GetInstance();
            GetLyric.LyricSearchParam(strKeyword, CatId, OrderBy, 0, PageIndex, PageSize);

            PagerLinks Pager = PagerLinks.GetInstance();
            Pager.PagerLinksParam(PageIndex, PageSize, GetLyric.RecordCount);

            string strSearchIn;

            if (CatId == 0)
                strSearchIn = "<b>trong tất cả các chủ đề</b>.";
            else
                strSearchIn = "trong chủ đề <b>" + GetLyric.Category + "</b>.";

            //Get Lyric count in category and assign it to the labale
            lblcount.Text = "(" + GetLyric.RecordCount.ToString() + ") Hợp âm cho từ khóa (<b>" + strKeyword + "</b>) " + strSearchIn;

            //Get pageindex, pagesize and record count
            //Pager.GetPager(PageIndex, PageSize, GetLyric.RecordCount, PlaceHolder1);

            //Display numeric pager link
            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, OrderBy, 0, GetPage);

            //Display the top right corner pager counter
            lblRecpagetop.Text = Pager.GetTopRightPagerCounterCustomPaging;

            //Display the bottom pager counter
            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            //Bind Generic List to a repeater
            LyricCat.DataSource = GetLyric.GetLyricSearchResult();
            LyricCat.DataBind();
        }
        catch
        {
            lblNorecordFound.Visible = true;
            lblNorecordFound.Text = "Không có hợp âm nào cho từ khóa (" + strKeyword + "). Hãy thử lại đi cưng.";
        }
    }

    //Handle dynamic page title and keywords
    private void GetMetaTitleTagKeywords(string AlphaLetterName)
    {
        //Other option is to declare a public variable 

        //Assign page title and meta keywords
        Page.Header.Title = AlphaLetterName;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = Resources.lang.Keywords;
        //You can add more keywords if you want.
        metaTag.Content = AlphaLetterName;
        this.Header.Controls.Add(metaTag);
    }

    public void LyricCat_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        Utility.GetIdentifyItemNewPopular(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e,
                                            (int)DataBinder.Eval(e.Item.DataItem, "Hits"));
    }
}
