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
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

public partial class alphaletter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblletter.Text = Resources.lang.Song + " A-Z:";
        lblalphaletter.Text = AlphabetLink.BuildLink("lyricname.aspx?letter=", "letter", Resources.lang.Browse_all_song_starting_with_letter, "&nbsp;&nbsp;");
    }
}
