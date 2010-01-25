#region XD World Lyric V 2.8
// FileName: articlepreview.cs
// Author: Dexter Zafra
// Date Created: 5/26/2008
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
using VGuitar.BL.Providers.Article;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.User;

public partial class admin_articlepreview : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate utility object
        Utility Util = new Utility();

        ProviderArticleDetails Article =  new ProviderArticleDetails();

        int ArticleID = (int)Util.Val(Request.QueryString["aid"]);

        Article.Approved = constant.UnApproved;
        Article.FillUp(ArticleID);

        lbtitle.Text = Article.Title;
        lblsummary.Text = Article.Summary;
        lblkeyword.Text = Article.Keyword;
        lbartdetail.Text = Article.Content;

        //Release allocated memory
        Util = null;
        Article = null;
    }

}