#region XD World Lyric V 2.8
// FileName: activation.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
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
using VGuitar.Common.Utilities;
using VGuitar.Security;

public partial class activation : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["guid"]))
        {
            string strGUID = Request.QueryString["guid"].ToString().Trim();

            if (Blogic.IsAccountActivattionCodeValid(strGUID))
            {
                if (!Blogic.IsAccountActivated(strGUID))
                {
                    HideContentIfAlreadyActivated.Visible = true;

                    activatebutton.Text = "Kích hoạt tài khoản";
                    activatebutton.Attributes.Add("onmouseover", "Tip('Nhấn vào đây để kích hoạt tài khoản của bạn.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                    activatebutton.Attributes.Add("onmouseout", "UnTip()");

                    lblusernameactivation.Text = "Chào bạn, " + Blogic.GetUserNameForActivationPage(strGUID).ToString();
                }
                else
                {
                    lblaccountisalreadyactivated.Visible = true;
                    lblaccountisalreadyactivated.Text = "Tài khoản của bạn đã được kích hoạt.";
                }

                if (!string.IsNullOrEmpty(Request.QueryString["guid"]) && !string.IsNullOrEmpty(Request.QueryString["mode"]))
                {
                    if (Request.QueryString["mode"] == "success")
                    {
                        lblaccountisalreadyactivated.Visible = true;
                        lblaccountisalreadyactivated.Text = "Tài khoản của bạn đã được kích hoạt thành công. Xin vui lòng đăng nhập.";
                    }
                }
            }
            else
            {
                lblaccountisalreadyactivated.Visible = true;
                lblaccountisalreadyactivated.Text = "Các mã kích hoạt không hợp lệ.";
            }
        }
    }

    public void Activate_Click(object sender, EventArgs e)
    {
        string strGUID = Request.QueryString["guid"].ToString().Trim();

        if (!string.IsNullOrEmpty(strGUID))
        {
            Blogic.ActivateAccount(strGUID);
        }

        Response.Redirect("activation.aspx?guid=" + strGUID + "&mode=success");
    }
}
