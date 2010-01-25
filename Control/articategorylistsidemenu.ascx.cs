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
using VGuitar.BL.Providers.Article;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;

public partial class articategorylistsidemenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArtCategoryList.DataSource = ArticleCategoryMenuProvider.GetArticle();
        ArtCategoryList.DataBind();
    }
}
