#region XD World Lyric V 2.8
// FileName: lastviewedrecipe.ascx.cs
// Author: Dexter Zafra
// Date Created: 7/16/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Common.Utilities;

public partial class Controllastviewedrecipe : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbgethour.Text = ProviderLastViewedLyric.GetMinuteSpan.ToString();

        lastview.DataSource = ProviderLastViewedLyric.GetLastViewedLyric();
        lastview.DataBind();
    }

    public void lastview_ItemDataBound(Object s, RepeaterItemEventArgs e)
    {
        //Get sequential number counter
        Utility.GetSeqCounter(lastview, e);
    }
}
