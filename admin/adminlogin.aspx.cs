#region XD World Lyric V 2.8
// FileName: adminlogin.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
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
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.Security;

public partial class admin_adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Note: You can use form authentication through web config. Just change the code
    }

    public void ProcessLogin(Object s, EventArgs e)
    {
        //Instantiate validation
        Utility Util = new Utility();

        string Username;
        string Userpass;

       #region Input Validations
        //Validate username and password both are empty.
        if (Request.Form["uname"].Trim() == "" && Request.Form["password"].Trim() == "")
        {
            lblerror.Text = "Hãy tài khoản người dùng và mật khẩu.";
            return;
        }
        if (Request.Form["uname"].Trim() == "")
        {
            lblerror.Text = "Hãy nhập tài khoản người dùng.";
            return;         
        }
        if (Request.Form["password"].Trim() == "")
        {
            lblerror.Text = "Hãy nhập mật khẩu.";
            return;
        }
      #endregion

        //Retreive value from the request.form property and filter dirty character.
        Username = Util.FormatTextForInput(Request.Form["uname"]);
        Userpass = Util.FormatTextForInput(Request.Form["password"]);

        //Do final login process with validation
        ProcessLoginCheck(Username, Userpass);

        Util = null;
    }

    //Handles final login process with validation
    private void ProcessLoginCheck(string Username, string Password)
    {
        //Instantiate validation
        Utility Util = new Utility();

        //Validate admin login. Encrypt the password so it mathc to the database.
        if (Blogic.ValidateAdminLogin(Username, Encryption.Encrypt(Password)))
        {   
            //Create admin login session
            CookieLoginHelper.CreateAdminLoginSession(Username, Password);

            //If everything is okay, then redirect to the Manager Main page.
            Response.Redirect("managermain.aspx");
        }
        else
        {
            uname.Text = "";
            lblerror.Text = "Đăng nhập không hợp lệ";
            JSLiteral.Text = Util.JSAlert("Đăng nhập không hợp lệ");
            return;
        }

        Util = null;
    }
}
