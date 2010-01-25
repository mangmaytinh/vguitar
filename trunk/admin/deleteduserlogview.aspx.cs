using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;
using VGuitar.Security;
using VGuitar.BL.Providers.User;
using System.Web.UI.HtmlControls;

public partial class admin_deleteduserlogview : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblusername.Text = "Welcome Admin:&nbsp;" + UserIdentity.AdminUsername;

        DeletedUserLog.DataSource = Blogic.ActionProcedureDataProvider.ViewDeletedUsersLog;
        DeletedUserLog.DataBind();
    }
}
