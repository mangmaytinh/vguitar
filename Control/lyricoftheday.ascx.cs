#region XD World Lyric V 2.8
// FileName: lyricoftheday.ascx.cs
// Author: Dexter Zafra
// Date Created: 7/16/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

public partial class lyricoftheday : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Instantiate utility object
            Utility Util = new Utility();

            LyricoftheDay Lyric = LyricoftheDay.GetInstance();

            Lyric.FillUp();

            RanCat.NavigateUrl = "~/category.aspx?catid=" + Lyric.CatID;
            RanCat.Text = Lyric.Category;
            RanCat.ToolTip = "Xem danh mục " + Lyric.Category;

            rdetails.NavigateUrl = "~/lyricdetail.aspx?id=" + Lyric.ID;
            rdetails.Text = "Đọc thêm...";
            rdetails.ToolTip = "Chi tiêt hợp âm " + Lyric.LyricName;

            lbrecname.Text = Lyric.LyricName;
            lbingred.Text = Util.FormatText(Lyric.Ingredients);
            lbinstruct.Text = Util.FormatText(Lyric.Instructions);
            lbhits.Text = Lyric.Hits.ToString();
            lblrating.Text = Lyric.Rating;
            lbvotes.Text = Lyric.NoRates.ToString();

            rateimage.ImageUrl = Utility.GetStarImage(Lyric.Rating);

            Util = null;
   }
}
