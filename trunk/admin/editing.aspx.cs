#region XD World Lyric V 2.8
// FileName: editing.cs
// Author: Dexter Zafra
// Date Created: 6/13/2008
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
using System.Data.SqlClient;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.User;

public partial class admin_editing : BasePageAdmin
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    public string strRecipeImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropDownListCategory.LoadDropDownCategory("Lyric Category", CategoryID, "Select a Category");

            lblusername.Text = "Welcome Admin:&nbsp;" + UserIdentity.AdminUsername;

            LyricDetails Lyric = new LyricDetails();

            int RecipeID = (int)Util.Val(Request.QueryString["id"]);

            strRecipeImage = GetLyricImage.GetImage(RecipeID);
            Lyric.Approved = constant.UnApprovedRecipe;
            Lyric.FillUp(RecipeID);

            lblauthorname.Text = Lyric.Author;
            Userid.Value = Lyric.UID.ToString();
            Name.Text = Lyric.LyricName;
            Author.Value = Lyric.Author;
            Hits.Text = Lyric.Hits.ToString();
            Ingredients.Text = Lyric.Ingredients;
            Instructions.Text = Lyric.Instructions;

            Lyric = null;
        }
    }

    public void Update_Recipe(object sender, EventArgs e)
    {
        RecipeRepository Lyric = new RecipeRepository();

        Lyric.UID = int.Parse(Request.Form["Userid"]);
        Lyric.ID = (int)Util.Val(Request.QueryString["id"]);
        Lyric.LyricName = Request.Form["Name"];
        Lyric.Author = Request.Form["Author"];
        Lyric.CatID = int.Parse(Request.Form["CategoryID"]);
        Lyric.Ingredients = Request.Form["Ingredients"];
        Lyric.Instructions = Request.Form["Instructions"];
        Lyric.Hits = int.Parse(Request.Form["Hits"]);

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

        ImageUploadManager.UploadRecipeImage(Lyric, PlaceHolder1, GetLyricImage.ImagePath, constant.RecipeImageMaxSize, true);

        if (Lyric.Update(Lyric) != 0)
        {
            JSLiteral.Text = Util.JSProcessingErrorAlert;
            return;
        }

        string strURLRedirect;
        strURLRedirect = "confirmdel.aspx?catname=" + Lyric.LyricName + "&mode=update";

        Lyric = null;

        Response.Redirect(strURLRedirect);

    }

    public void Cancel_Update(object sender, EventArgs e)
    {
        Response.Redirect("lyricmanager.aspx");
    }
}
