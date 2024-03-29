#region XD World Lyric V 2.8
// FileName: popupviewuserssavedrecipepublishedbyme.cs
// Author: Dexter Zafra
// Date Created: 3/29/2009
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
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.User;

public partial class popupviewuserssavedlyricpublishedbyme : BasePage
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            HideContentIfNotLogin.Visible = true;

            if (!string.IsNullOrEmpty(Request.QueryString["uid"]) && Utility.IsNumeric(Request.QueryString["uid"]))
            {
                int UserID = (int)Util.Val(Request.QueryString["uid"]);
                LoadData(UserID);
            }
        }
        else
        {
            HideContentIfNotLogin.Visible = false;
            lblyouarenotlogin.Visible = true;
            lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Ybạn không được phép vào trang Tài khoản của tôi. Xin vui lòng đăng nhập để vào mục tài khoản của bạn.</div>";
        }
    }

    private void LoadData(int UserID)
    {
        UserSavedRecipeCookBookPublishedByme.DataSource = Blogic.ActionProcedureDataProvider.GetViewUsersLyricSavedPublishedByMe(UserIdentity.UserID, UserID);
        UserSavedRecipeCookBookPublishedByme.DataBind();
    }
}
