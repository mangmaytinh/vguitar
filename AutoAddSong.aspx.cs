#region XD World Lyric V 2.8
// FileName: addrecipe.cs
// Author: Dexter Zafra
// Date Created: 5/28/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using VGuitar.BL.Providers.User;

public partial class AutoAddSong : BasePage
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        Panel3.Visible = false;
        lblwarning.Visible = true;
        lblwarning.Text = "<img src='images/lock.gif' align='absmiddle'> Bạn phải đăng nhập trước khi muốn chia sẻ hợp âm cho mọi người. " + "<a href='registration.aspx'>Đăng ký tài khoản</a>";

        if (Authentication.IsUserAuthenticated)
        {
            Panel3.Visible = true;
            lblwarning.Visible = false;
            lblusername.Text = UserIdentity.UserName;
            Author.Value = UserIdentity.UserName;
            if (!IsPostBack)
            {
            }
            LoadDropDownListCategory.LoadDropDownCategory("Lyric Category", CategoryID, "Chọn phân loại");

        }
    }

    public void Add_Recipe(Object s, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (Page.IsValid)
            {
                Utility Util = new Utility();

                int categoryid = int.Parse(Request.Form[CategoryID.UniqueID]);                            

                IDataReader dr = Blogic.ActionProcedureDataProvider.GetSpiderLyrics(categoryid);
                while (dr.Read())
                {
                    LyricRepository lyric = new LyricRepository();
                    //Filters harmful scripts from input string.
                    if (dr["Title"] != DBNull.Value)
                    {
                        lyric.LyricName = (string)dr["Title"].ToString().Trim();
                    }

                    if (dr["Author"] != DBNull.Value)
                    {
                        lyric.Author = (string)dr["Author"].ToString().Trim();
                    }

                    if (dr["Lyric"] != DBNull.Value)
                    {
                        lyric.Ingredients = (string)dr["Lyric"].ToString().Trim();
                    }

                    lyric.CatID = int.Parse(Request.Form[CategoryID.UniqueID]);                    
                    lyric.Instructions = "";
                    lyric.UID = UserIdentity.UserID;

                    lyric.Add(lyric);
                    lyric = null;
                }
                //EmailRecipeSubmissionNotificationToAdministrator(Lyric.LyricName);                
                Response.Redirect("confirmaddeditlyric.aspx?mode=Added");
                Util = null;
            }
        }
    }

    private void ValidateFileUploadContentType(FileUpload ImageUpload, int maxFileSize)
    {
  
    }

    private void EmailRecipeSubmissionNotificationToAdministrator(string LyricName)
    {
        EmailTemplate SendEMail = new EmailTemplate();
        SendEMail.ItemName = LyricName;
        SendEMail.SendEmailAddRecipeNotify();
        SendEMail = null;
    }
}
