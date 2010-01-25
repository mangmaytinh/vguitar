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
using VGuitar.BL.Providers.User;

public partial class popuplast20userswhosumittedlyric : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserSubmittedRecipe.DataSource = Blogic.ActionProcedureDataProvider.GetLast20UserWhoSubmittedLyric;
        UserSubmittedRecipe.DataBind();
    }
}
