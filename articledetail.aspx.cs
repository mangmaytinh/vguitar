#region XD World Lyric V 2.8
// FileName: articledetail.cs
// Author: Dexter Zafra
// Date Created: 2/28/2009
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
using VGuitar.BL.Providers.Article;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.BL.Providers.User;
using VGuitar.Security;
using VGuitar.BL.Providers.Comments;
using VGuitar.Common.Utilities;
using VGuitar.Security;

public partial class articledetail : BasePage
{
    public int ArtCatId;
    public string strCatName;
    public string strArtTitle;
    public string strBookmarkURL;
    public int ArticleSection;
    public int ArticleID;
    public string strAuthor;

    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ProviderArticleDetails Article = new ProviderArticleDetails();

        ArticleID = (int)Util.Val(Request.QueryString["aid"]);

        Article.Approved = constant.Approved;
        Article.FillUp(ArticleID);

        if (!string.IsNullOrEmpty(Article.Content))
            lblwordcount.Text = Utility.WordCount(Article.Content).ToString();

        CommentLink.Text = "Bình luận (" + Article.CountComments + ")";
        CommentLink.Attributes.Add("onmouseover", "Tip('Đọc hoặc viết bình luận.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
        CommentLink.Attributes.Add("onmouseout", "UnTip()");

        lbcountcomment.Text = Article.CountComments.ToString();
        lbtitle.Text = Article.Title;
        lbcontent.Text = Article.Content;
        lbhits.Text = string.Format("{0:#,###}", Article.Hits);
        lbauthor.Text = "<a class='content2' title='Xem tác giả hoàn tất thông tin cá nhân.' href=userprofile.aspx?uid=" + Article.UID + ">" + Article.Author + "</a>";
        lblrating.Text = Article.Rating;
        lblvotescount.Text = Article.NoRates;
        starimage.ImageUrl = Utility.GetStarImage(Article.Rating);
        lbldate.Text = Utility.FormatDate(Article.Date);

        lbauthor.Attributes.Add("onmouseover", "Tip('Xem thông tin cá nhân <b>" + Article.Author + "</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
        lbauthor.Attributes.Add("onmouseout", "UnTip()");

        strBookmarkURL = Bookmark.URL;

        strAuthor = Article.Author;
        strArtTitle = Article.Title;
        strCatName = Article.Category;
        ArtCatId = Article.CatID;
        ArticleSection = constant.intArticle;

        ShowEditLink(Article);
        GetMetaTitleTagKeywords(Article);
        GetUserCookingArticleRating(ArticleID);
        GetRelatedArticle(Article);
        GetOtherArticleByThisAuthor(Article);
        GetComments(ArticleID);
        ShowCommentFormIfLogin();

        Article = null;
    }

    private void ShowEditLink(ProviderArticleDetails Article)
    {
        if (Authentication.IsUserAuthenticated && Article.UID == UserIdentity.UserID)
        {
            editarticlelink.Visible = true;
            editarticlelink.Text = "<img src='images/icon_pencil.gif' alt='Sửa' border='0'> Sửa";
            editarticlelink.NavigateUrl = "editarticle.aspx?aid=" + Article.ID;
            editarticlelink.Attributes.Add("onmouseover", "Tip('Sửa bài viết <b>" + Article.Title + "</b>. của bạn', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            editarticlelink.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void ShowCommentFormIfLogin()
    {
        if (Authentication.IsUserAuthenticated)
        {
            Panel3.Visible = true;
            lbllogintocomment.Visible = false;

            AUTHOR.Value = UserIdentity.UserName;
            EMAIL.Value = UserIdentity.UserEmail;
            lblUsernameComment.Text = UserIdentity.UserName;
            lbluserCommentEmail.Text = UserIdentity.UserEmail;
        }
        else
        {
            Panel3.Visible = false;
            lbllogintocomment.Visible = true;
            lbllogintocomment.Text = "Để có thể để lại một bình luận hãy đăng nhập ở góc trên bên phải hoặc " + "<a href='registration.aspx'>Đăng ký</a>.";
        }
    }

    private void GetRelatedArticle(ProviderArticleDetails Article)
    {
        ProviderRalatedArticle GetRelatedArticle = ProviderRalatedArticle.GetInstance();
        GetRelatedArticle.Param(Article.CatID, Article.ID);

        if (GetRelatedArticle.RecordCount > 1)
        {
            PanelRelatedArticle.Visible = true;
            RelatedArticle.DataSource = GetRelatedArticle.GetArticle();
            RelatedArticle.DataBind();
        }
    }

    private void GetOtherArticleByThisAuthor(ProviderArticleDetails Article)
    {
        ProviderOtherArticleByThisAuthor GetOtherArticle = ProviderOtherArticleByThisAuthor.GetInstance();
        GetOtherArticle.Param(Article.UID, Article.ID);

        if (GetOtherArticle.RecordCount > 1)
        {
            PanelOtherArticleByAuthor.Visible = true;
            OtherArticleByThisAuthor.DataSource = GetOtherArticle.GetArticle();
            OtherArticleByThisAuthor.DataBind();
        }
    }

    private void GetUserCookingArticleRating(int AID)
    {
        CookieRating GetCookie = new CookieRating(constant.intArticle, AID, PlaceHolder2);
        GetCookie.GetUserCookieRating();
        GetCookie = null;
    }

    private void GetComments(int AID)
    {
        ArticleComments Comment = new ArticleComments(AID, RecComments, PlaceHolder2);
        Comment.FillUp();
        Comment = null;
    }

    private void GetMetaTitleTagKeywords(ProviderArticleDetails Article)
    {
        Page.Header.Title = Article.Title + "," + Article.Category;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Từ khóa";
        metaTag.Content = Article.Title + "," + Article.Category;
        this.Header.Controls.Add(metaTag);
    }

    public void Add_Comment(Object s, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (Page.IsValid && (txtsecfield.Text.ToString() == Session["randomStr"].ToString()))
            {
                ArticleCommentsRepository comment = new ArticleCommentsRepository();

                comment.ID = (int)Util.Val(Request.QueryString["aid"]);
                comment.UID = UserIdentity.UserID;
 
                comment.Author = Util.FormatTextForInput(Request.Form[AUTHOR.UniqueID]);
                comment.Email = Util.FormatTextForInput(Request.Form[EMAIL.UniqueID]);
                comment.Comments = Util.FormatTextForInput(Request.Form[COMMENTS.UniqueID]);

                if (comment.Comments.Length == 0)
                {
                    lbvalenght.Text = "<br>Lỗi: Thảo luận không có sản phẩm nào, xin vui lòng nhập bình luận của bạn.";
                    lbvalenght.Visible = true;
                    txtsecfield.Text = "";
                    return;
                }
                if (comment.Comments.Length > 350)
                {
                    lbvalenght.Text = "<br>Lỗi: Bình luận là quá dài. Tối đa là 350 ký tự.";
                    lbvalenght.Visible = true;
                    txtsecfield.Text = "";
                    return;
                }

                if (comment.Add(comment) != 0)
                {
                    lbvalenght.Text = "Một lỗi cơ sở dữ liệu đã xảy ra khi xử lý luận của bạn.";
                    return;
                }

                EmailCommentNotificationToAdministrator(comment.ID, strArtTitle);

                comment = null;

                Response.Redirect("commentpostconfirmation.aspx?ReturnURL=" + this.Request.Url.PathAndQuery);
            }
            else
            {
                lbvalenght.Text = "<br>Không hợp lệ mã bảo mật. Hãy chắc chắn rằng bạn nhập chính xác.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";

                lblinvalidsecode.Text = "Không hợp lệ mã bảo mật. Hãy chắc chắn rằng bạn nhập chính xác.";
                lblinvalidsecode.Visible = true;
            }
        }
    }

    private void EmailCommentNotificationToAdministrator(int ID, string Title)
    {
        EmailTemplate SendEmail = new EmailTemplate();
        SendEmail.ItemID = ID;
        SendEmail.ItemName = Title;
        SendEmail.SendEmailArticleCommentNotify();
        SendEmail = null;
    }
}
