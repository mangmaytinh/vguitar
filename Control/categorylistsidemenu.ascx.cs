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
using VGuitar.BL.Providers.Lyrics;

public partial class categorylistsidemenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CategoryList.DataSource = LyricCategoryMenuProvider.GetLyricCategoryMenu();
        CategoryList.DataBind();
    }
}
