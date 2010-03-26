#region XD World Lyric V 2.8
// FileName: editrecipe.cs
// Author: Dexter Zafra
// Date Created: 2/13/2009
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
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using VGuitar.BL.Providers.User;

public partial class editlyric : BasePage
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    public string strRecipeImage;

    protected void Page_Load(Object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            lblusername.Text = UserIdentity.UserName;

            LoadDropDownListCategory.LoadDropDownCategory("Lyric Category", CategoryID, "Select a Category");

            try
            {
                LyricDetails lyric = new LyricDetails();

                int RecipeID = (int)Util.Val(Request.QueryString["id"]);

                strRecipeImage = GetLyricImage.GetLyricImageUserEdit(RecipeID);
                lyric.Approved = constant.ApprovedLyric;
                lyric.FillUp(RecipeID);

                Name.Value = lyric.LyricName;
                Hits.Value = lyric.Hits.ToString();
                Ingredients.Value = lyric.Ingredients;
                Instructions.Value = lyric.Instructions;
                UrlMusic.Value = lyric.UrlMusic;
                UrlZing.Value = lyric.UrlZing;
                UrlYoutube.Value = lyric.UrlYoutube;
                UrlChacha.Value = lyric.UrlChacha;

                if (lyric.UID == UserIdentity.UserID)
                {
                    HideContentIfNotLogin.Visible = true;
                }
                else
                {
                    lblyouarenotlogin.Visible = true;
                    lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> You are not authorize to edit this recipe.</div>";
                }

                lyric = null;
            }
            catch
            {

            }
        }        
        else
        {
            lblyouarenotlogin.Visible = true;
            lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> You are not authorize to edit a recipe. Please login to edit your recipe.</div>";
        }
    }

    public void Update_Recipe(Object s, EventArgs e)
    {
        if (Page.IsValid && Authentication.IsUserAuthenticated)
        {
            LyricRepository lyric = new LyricRepository();

            lyric.UID = UserIdentity.UserID;
            lyric.ID = (int)Util.Val(Request.QueryString["id"]);
            lyric.LyricName = Util.FormatTextForInput(Request.Form[Name.UniqueID]);
            lyric.CatID = int.Parse(Request.Form[CategoryID.UniqueID]);
            lyric.Ingredients = Request.Form[Ingredients.UniqueID];
            lyric.Instructions = Request.Form[Instructions.UniqueID];
            lyric.Hits = int.Parse(Request.Form[Hits.UniqueID]);

            lyric.UrlMusic = Util.FormatTextForInput(Request.Form[UrlMusic.UniqueID]);
            lyric.UrlChacha = Util.FormatTextForInput(Request.Form[UrlChacha.UniqueID]);
            lyric.UrlZing = Util.FormatTextForInput(Request.Form[UrlZing.UniqueID]);
            lyric.UrlYoutube = Util.FormatTextForInput(Request.Form[UrlYoutube.UniqueID]);

            #region Form Input Validator
            //Validate for empty recipe name
            if (lyric.LyricName.Length == 0)
            {
                lbvalenght.Text = "<br>Error: lyric Name is empty, please enter a recipe name.";
                lbvalenght.Visible = true;
                return;
            }
            //Validate for empty ingredients
            if (lyric.Ingredients.Length == 0)
            {
                lbvalenght.Text = "<br>Error: Ingredients is empty, please enter an ingredients.";
                lbvalenght.Visible = true;
                return;
            }
            //Validate for empty instruction
            //if (lyric.Instructions.Length == 0)
            //{
            //    lbvalenght.Text = "<br>Error: Instructions is empty, please enter an instruction.";
            //    lbvalenght.Visible = true;
            //    return;
            //}

            //lyric name maximum of 50 char allowed
            if (lyric.LyricName.Length > 50)
            {
                lbvalenght.Text = "<br>Error: Lyric Name is too long. Max of 50 characters.";
                lbvalenght.Visible = true;
                return;
            }
            //Ingredients maximum of 500 char allowed - can be increase to max 1000 characters.
            //if (Lyric.Ingredients.Length > 1500)
            //{
            //    lbvalenght.Text = "<br>Error: Ingredients is too long. Max of 1000 characters.";
            //    lbvalenght.Visible = true;
            //    return;
            //}
            //Instruction maximum of 750 char allowed - can be increase to max 2000 characters.
            //if (Lyric.Instructions.Length > 2000)
            //{
            //    lbvalenght.Text = "<br>Error: Instructions is too long. Max of 2000 characters.";
            //    lbvalenght.Visible = true;
            //    return;
            //}
            #endregion

            if (RecipeImageFileUpload.HasFile)
            {
                int FileSize = RecipeImageFileUpload.PostedFile.ContentLength;
                string contentType = RecipeImageFileUpload.PostedFile.ContentType;

                //File type validation
                if (!contentType.Equals("image/gif") &&
                    !contentType.Equals("image/jpeg") &&
                    !contentType.Equals("image/jpg") &&
                    !contentType.Equals("image/png"))
                {
                    lbvalenght.Text = "<br>File format is invalid. Only gif, jpg, jpeg or png files are allowed.";
                    lbvalenght.Visible = true;
                    return;
                }
                // File size validation
                if (FileSize > constant.RecipeImageMaxSize)
                {
                    lbvalenght.Text = "<br>File size exceed the maximun allowed 30000 bytes";
                    lbvalenght.Visible = true;
                    return;
                }
            }

            ImageUploadManager.UploadRecipeImage(lyric, PlaceHolder1, GetLyricImage.ImagePathDetail, constant.RecipeImageMaxSize, true);

            //Refresh cache
            Caching.PurgeCacheItems("MainCourse_LyricCategory");
            Caching.PurgeCacheItems("Ethnic_LyricCategory");
            Caching.PurgeCacheItems("MainCourse_LyricCategory");
            Caching.PurgeCacheItems("Newest_LyricsSideMenu_");

            if (lyric.Update(lyric) != 0)
            {
                JSLiteral.Text = Util.JSProcessingErrorAlert;
                return;
            }

            lyric = null;

            Response.Redirect("confirmaddeditlyric.aspx?mode=Updated&recipename=" + Request.Form[Name.UniqueID] + "&id=" + int.Parse(Request.QueryString["id"]));
        }
    }
}
