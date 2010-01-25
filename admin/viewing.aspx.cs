#region XD World Lyric V 2.8
// FileName: viewing.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
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
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

public partial class admin_viewing : BasePageAdmin
{
    Utility Util = new Utility();

    private int ID;
    public string strRecipename;
    public string strRecipeImage;
    public int UserID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LyricDetails Lyric = new LyricDetails();

            int RecipeID = (int)Util.Val(Request.QueryString["id"]);
            Lyric.Approved = constant.UnApprovedRecipe;
            Lyric.FillUp(RecipeID);

            UserID = Lyric.UID;

            strRecipeImage = GetLyricImage.GetImage(RecipeID);

            if (Lyric.HitDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                lblastviewed.Text = "This Lyric Has not been view by a user lately.";
            }
            else
            {
                lblastviewed.Text = Lyric.HitDate.ToString();
            }

            lblname.Text = Lyric.LyricName;
            lblauthor.Text = Lyric.Author;
            lbldate.Text = Lyric.Date.ToShortDateString();
            lblCatName.Text = Lyric.Category;
            Ingredients.Text = Lyric.Ingredients;
            Instructions.Text = Lyric.Instructions;

            if (Lyric.Approved == 1)
            {
                approvebutton.Visible = false;
                lblapprovalstatus.Text = "Viewing Lyric";
            }
            else
            {
                lblapprovalstatus.Text = "Unapprove - This recipe is waiting for approval";
            }

            if (Lyric.Hits == 0)
            {
                lblhits.Text = "0";
            }
            else
            {
                lblhits.Text = string.Format("{0:#,###}", Lyric.Hits);
            }

            strRecipename = Lyric.LyricName;

            Util = null;
            Lyric = null;
        }
    }

    public void Approve_Recipe(object sender, EventArgs e)
    {
        ID = (int)Util.Val(Request.QueryString["id"]);

        Caching.PurgeCacheItems("MainCourse_LyricCategory");
        Caching.PurgeCacheItems("Ethnic_LyricCategory");
        Caching.PurgeCacheItems("MainCourse_LyricCategory");
        Caching.PurgeCacheItems("Newest_LyricsSideMenu_");
        Caching.PurgeCacheItems("Last5_LyricPublishedByUser_" + UserID);

        Blogic.ActionProcedureDataProvider.AdminApproveLyric(ID);

        Util.PageRedirect(8);

        Util = null;
    }
}
