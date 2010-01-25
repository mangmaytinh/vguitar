#region XD World Lyric V 3
// FileName: BasePage.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Common.Utilities;
using System.Globalization;

namespace VGuitar.UI
{
    /// <summary>
    /// Base Page
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        private const string SESSION_KEY_LANGUAGE = "CURRENT_LANGUAGE";

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            //If you would like to have DefaultLanguage changes to effect all users,
            // or when the session expires, the DefaultLanguage will be chosen, do this:
            // (better put in somewhere more GLOBAL so it will be called once)
            //LanguageManager.DefaultCulture = ...

            //Change language setting to user-chosen one
            if (Session[SESSION_KEY_LANGUAGE] != null)
            {
                ApplyNewLanguage((CultureInfo)Session[SESSION_KEY_LANGUAGE]);
            }
        }

        private void ApplyNewLanguage(CultureInfo culture)
        {
            LanguageManager.CurrentCulture = culture;
            //Keep current language in session
            Session.Add(SESSION_KEY_LANGUAGE, LanguageManager.CurrentCulture);
        }

        protected void ApplyNewLanguageAndRefreshPage(CultureInfo culture)
        {
            ApplyNewLanguage(culture);
            //Refresh the current page to make all control-texts take effect
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        void Page_Error(object sender, EventArgs e)
        {
            //Get current URL
            string GetCurrentURL = Request.Url.ToString();

            //Get the Exception error
            string GetExceptionError = Server.GetLastError().ToString();

            //Log Exception Error
            Blogic.LogExceptionError(GetCurrentURL, GetExceptionError);

            //Instantiate email temple object
            EmailTemplate SendEmailNotification = new EmailTemplate();

            SendEmailNotification.SendExceptionErrorNotification(GetCurrentURL, GetExceptionError);

            SendEmailNotification = null;

            //Redirect to the error page.
            Server.Transfer("error.aspx");
        }

        /// <summary>
        /// Format date to "Jan. 1, 2009"
        /// </summary>
        public string CustomDateFormat(object o)
        {
            string newdateformat = Utility.FormatDate(Convert.ToDateTime(o));
            return newdateformat;
        }

        /// <summary>
        /// Format Text
        /// </summary>
        public string FormatText(object o)
        {
            Utility Util = new Utility();

            string formattxt = Util.FormatText(Convert.ToString(o));
            return formattxt;

            Util = null;
        }


    }
}
