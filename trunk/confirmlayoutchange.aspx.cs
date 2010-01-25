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
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;
using VGuitar.BL.Providers.User;

public partial class confirmlayoutchange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            //Coming from category.aspx
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnURL"]) && !string.IsNullOrEmpty(Request.QueryString["mode"]))
            {
                string strURLRedirect = Request.QueryString["ReturnURL"];
                string mode = Request.QueryString["mode"];

                switch (mode)
                {
                    case "L":
                        Blogic.UpdateUserPreferredLayout(UserIdentity.UserID, int.Parse(Request.QueryString["playout"]));
                        break;

                    case "P":
                        Blogic.UpdateUserPreferredPageSize(UserIdentity.UserID, int.Parse(Request.QueryString["psize"]));
                        break;
                }

                Response.Redirect(strURLRedirect);
            }

            //Coming from MyAccount.aspx
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnURL"]) && !string.IsNullOrEmpty(Request.QueryString["flag"]))
            {
                string strURLRedirectToMyAccount = Request.QueryString["ReturnURL"] + "?save=success";

                Response.Redirect(strURLRedirectToMyAccount);
            }
        }

        Response.Redirect("default.aspx");
    }
}
