#region XD World Lyric V 2.8
// FileName: newesttolyrics.ascx.cs
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
using System.Data.SqlClient;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.User;
using Resources;

public partial class newesttolyrics : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate object
        Utility Util = new Utility();

        int CatId = (int)Util.Val(Request.QueryString["catid"]);

        //Display random recipe
        GetRandomrecipe(CatId);

        MyCookBookSideMenu();

        //Get the newest 10 recipes. Change the value to 5 if you want to display only 5 newest recipes.
        int TopNewest = 10;

        //Get the 15 popular recipes. Change the value to 5 or 10 if you want to display only 5/10 most popular recipes.
        int TopPopular = 15;

        NewestLyricSideMenuProvider GetNewestLyric = NewestLyricSideMenuProvider.GetInstance();
        GetNewestLyric.NewestLyricParam(CatId, TopNewest);

        PopularLyricSideMenuProvider GetPopularLyric = PopularLyricSideMenuProvider.GetInstance();
        GetPopularLyric.PopularLyricParam(CatId, TopPopular);

        string CategoryName = GetNewestLyric.Category;

        if (!string.IsNullOrEmpty(this.Request.QueryString["catid"]))
        {
            //lblcatname.Text = CategoryName.ToString() + "&nbsp;";
            //lblcatnamepop.Text = CategoryName.ToString() + "&nbsp;";
            //lblrancatname.Text = CategoryName.ToString() + "&nbsp;";
            //lbTopCnt.Text = TopNewest.ToString();
        }
        else
        {
            lblcatname.Text = "";
            lbTopCnt.Text = TopNewest.ToString();
        }

        RecipeNew.DataSource = GetNewestLyric.GetNewestLyric();
        RecipeNew.DataBind();

        TopRecipe.DataSource = GetPopularLyric.GetPopularLyric();
        TopRecipe.DataBind();

        if (!string.IsNullOrEmpty(this.Request.QueryString["catid"]))
        {
            lblpopcounter.Text = lang.Top_Songs;
        }
        else
        {
            lblpopcounter.Text = lang.Top_15_Song;
        }

        //Release allocated memory
        Util = null;
    }

    private void MyCookBookSideMenu()
    {
        MyCookBookSideMenuContainer.Visible = false;
        MyCookBookSideMenuRepeater.Visible = false;

        if (Authentication.IsUserAuthenticated)
        {
            MyCookBookSideMenuContainer.Visible = true;
            MyCookBookSideMenuRepeater.Visible = true;

            UsersCookBook GetUserRecipe = new UsersCookBook(UserIdentity.UserID, 10);
            MyCookBookSideMenuRepeater.DataSource = GetUserRecipe.GetUserRecipeInCookBook();
            MyCookBookSideMenuRepeater.DataBind();

            int RemainingRecipe = 50 - GetUserRecipe.TotalCount;

            lblcounter.Text = UserIdentity.UserName + " hiện tại có (" + GetUserRecipe.TotalCount.ToString() + ") bài hát, bạn chỉ được phép thêm " + RemainingRecipe + " bài vào đây.";

            GetUserRecipe = null;
        }
    }

    //Handles random recipe
    private void GetRandomrecipe(int CatId)
    {
        RandomRecipe Lyric = RandomRecipe.GetInstance();

        Lyric.CatID = CatId;
        Lyric.FillUp();

        LinkRanName.NavigateUrl = "~/lyricdetail.aspx?id=" + Lyric.ID;
        LinkRanName.Text = Lyric.LyricName;
        LinkRanName.ToolTip = lang.View + " " + Lyric.LyricName;

        LinkRanCat.NavigateUrl = "~/category.aspx?catid=" + Lyric.CatID;
        LinkRanCat.Text = Lyric.Category;
        LinkRanCat.ToolTip = lang.Browse + " " + Lyric.Category ;

        lblranhits.Text = Lyric.Hits.ToString();

        ranrateimage.ImageUrl = Utility.GetStarImage(Lyric.Rating);
        lblvotes.Text = Lyric.NoRates;
    }

    public void TopRecipe_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        //Get sequential number counter
        Utility.GetSeqCounter(TopRecipe, e);       
    }

    public void RecipeNew_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        //Get the number of days
        //parameter 1 = we are dealing with the newest recipe.
        Utility.GetCounterDay(Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "Date")), e, 1);
    }
}
