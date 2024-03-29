#region XD World Lyric V 2.8
// FileName: printrecipe.cs
// Author: Dexter Zafra
// Date Created: 5/24/2008
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

public partial class printlyric : System.Web.UI.Page
{
    public string strRName;

    protected void Page_Load(object sender, EventArgs e)
    {
        Utility Util = new Utility();

        LyricDetails Lyric = new LyricDetails();

        int RecipeID = (int)Util.Val(Request.QueryString["id"]);
        Lyric.Approved = constant.ApprovedLyric;
        Lyric.FillUp(RecipeID);

        lblingredientsdis.Text = "Hợp âm:";
        lblinstructionsdis.Text = "Hướng dẫn:";
        lblname.Text = Lyric.LyricName;
        lblIngredients.Text = Util.FormatText(Lyric.Ingredients);
        lblInstructions.Text = Util.FormatText(Lyric.Instructions);

        strRName = "In hợp âm " + Lyric.LyricName + "";

        Util = null;
        Lyric = null;
    }
}
