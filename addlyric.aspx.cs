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

public partial class addlyric : BasePage
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

                LyricRepository lyric = new LyricRepository();

                //Filters harmful scripts from input string.
                lyric.LyricName = Util.FormatTextForInput(Request.Form[Name.UniqueID]);
                lyric.Author = Util.FormatTextForInput(Request.Form[Author.UniqueID]);
                lyric.CatID = int.Parse(Request.Form[CategoryID.UniqueID]);
                lyric.Ingredients = Util.FormatTextForInput(Request.Form[Ingredients.UniqueID]);
                lyric.Instructions = Util.FormatTextForInput(Request.Form[Instructions.UniqueID]);

                lyric.UID = UserIdentity.UserID;

                #region Form Input Validator
                //Validate for empty recipe name
                if (lyric.LyricName.Length == 0)
                {
                    lbvalenght.Text = "<br>Error: lyric Name is empty, please enter a recipe name.";
                    lbvalenght.Visible = true;
                    return;
                }
                if (lyric.CatID == 0)
                {
                    lbvalenght.Text = "<br>Error: You must select a category where you want your recipe to show.";
                    lbvalenght.Visible = true;
                    return;
                }
                //Validate for empty author name
                if (lyric.Author.Length == 0)
                {
                    lbvalenght.Text = "<br>Error: Author Name is empty, please enter the author name";
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
                if (lyric.Instructions.Length == 0)
                {
                    lbvalenght.Text = "<br>Error: Instructions is empty, please enter an instruction.";
                    lbvalenght.Visible = true;
                    return;
                }

                //lyric name maximum of 50 char allowed
                if (lyric.LyricName.Length > 50)
                {
                    lbvalenght.Text = "<br>Error: lyric Name is too long. Max of 50 characters.";
                    lbvalenght.Visible = true;
                    Name.Value = "";
                    return;
                }
                //Author name maximum of 25 char allowed
                if (lyric.Author.Length > 25)
                {
                    lbvalenght.Text = "<br>Error: Author Name is too long. Max of 25 characters.";
                    lbvalenght.Visible = true;
                    Author.Value = "";
                    return;
                }
                //Ingredients maximum of 1000 char allowed - can be increase to max of 1000 char.
                //if (lyric.Ingredients.Length > 500)
                //{
                //    lbvalenght.Text = "<br>Error: Ingredients is too long. Max of 500 characters.";
                //    lbvalenght.Visible = true;
                //    return;
                //}
                //Instruction maximum of 750 char allowed - can be increase to max of 2000 char
                //if (lyric.Instructions.Length > 750)
                //{
                //    lbvalenght.Text = "<br>Error: Instructions is too long. Max of 700 characters.";
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
                        lbvalenght.Text = "<br>Định dạng file không đúng. chỉ cho phép định dạng file: gif, jpg, jpeg or png.";
                        lbvalenght.Visible = true;
                        return;
                    }
                    // File size validation
                    if (FileSize > constant.RecipeImageMaxSize)
                    {
                        lbvalenght.Text = "<br>Kích thước file cho phép không quá 30000 bytes";
                        lbvalenght.Visible = true;
                        return;
                    }
                }

                ImageUploadManager.UploadRecipeImage(lyric, PlaceHolder1, GetLyricImage.ImagePathDetail, constant.RecipeImageMaxSize, false);

                if (lyric.Add(lyric) != 0)
                {
                    JSLiteral.Text = "Quá trình sử lý thất bại.";
                    return;
                }

                EmailRecipeSubmissionNotificationToAdministrator(lyric.LyricName);

                lyric = null;

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
