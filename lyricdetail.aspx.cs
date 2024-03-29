#region XD World Lyric V 2.8
// FileName: Recipedetail.cs
// Author: Dexter Zafra
// Date Created: 5/23/2008
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
using VGuitar.BL.Providers.Lyrics;
using VGuitar.BL.Providers.Comments;
using VGuitar.BL.Providers.User;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.Common.Utilities;
using VGuitar.Security;
using System.Text;

public partial class lyricdetail : BasePage
{
    public string strRName;
    public string strCName;
    public string strCreateBy;
    public int iUserID;
    public int RecCatId;
    public string strBookmarkURL;
    public string strLyricImage;
    public int LyricSection;
    public string strAddCookBookURL;
    public string strAddCookbookLinkTooltip;
    public string strAddCookBookURLWithJavaScriptCall;
    public DateTime dateposted;

    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LyricDetails lyric = new LyricDetails();

        int LyricID = (int)Util.Val(Request.QueryString["id"]);
        lyric.Approved = constant.ApprovedLyric;
        lyric.FillUp(LyricID);

        RecCatId = lyric.CatID;
        strRName = lyric.LyricName;
        strCName = lyric.Category;
        LyricSection = constant.intLyric;
        dateposted = lyric.Date;
        strCreateBy = lyric.CreateBy;
        iUserID = lyric.UID;

        CommentLink.Text = "Lời bình (" + lyric.CountComments + ")";
        CommentLink.Attributes.Add("onmouseover", "Tip('Đọc và viết lời bình cho bài hát này.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
        CommentLink.Attributes.Add("onmouseout", "UnTip()");
        lbcountcomment.Text = lyric.CountComments.ToString();
        lblname.Text = lyric.LyricName;
        //lblauthor.Text = "<a href=" + "userprofile.aspx?uid=" + lyric.UID + ">" + lyric.Author + "</a>";
        lblhits.Text = string.Format("{0:#,###}", lyric.Hits);
        lblrating.Text = lyric.Rating;
        lblvotescount.Text = lyric.NoRates;
        lblcategorytop.Text = lyric.Category;
        lbldate.Text = Utility.FormatDate(lyric.Date);
        lblIngredients.Text = lyric.Ingredients;
        lblInstructions.Text = lyric.Instructions;        
        starimage.ImageUrl = Utility.GetStarImage(lyric.Rating);
        lblMediaPlayer.Text = GetAllMediaPlayer(lyric.UrlMusic,lyric.UrlChacha,lyric.UrlZing,lyric.UrlYoutube);

        //lblauthor.Attributes.Add("onmouseover", "Tip('Xem tất cả bài hát đăng bởi <b>" + lyric.Author + "</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
        //lblauthor.Attributes.Add("onmouseout", "UnTip()");
        //lblauthor.Attributes.Add("onclick", "Popup('AjaxRequest/popUpAjax.aspx?uid=" + lyric.UID + "&author=" + lyric.Author + "',this);return false");

        strBookmarkURL = Bookmark.URL;

        GetMetaKeywords(DynamicKeywords.Keywords(constant.intLyricDynamicKeywordDetails, "Bài hát " + lyric.LyricName.ToString() + " thể loại " + lyric.Category.ToString()));

        ShowLyricImage(LyricID);
        AddToCookBookLinkButton(lyric.LyricName);
        ShowEditLink(lyric);
        ShowNewPopularImage(LyricID);
        GetRelatedLyrics(lyric.CatID);
        GetUserLyricCookieRating(LyricID);
        GetComments(LyricID);
        ShowCommentFormIfLogin();

        lyric = null;
    }

    private string GetMediaPlayer(string url)
    {
        string result = "";
        
        result =          "<object classid=\"clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95\" width=\"340\" height=\"64\">";
        result = result + "<param value=\" " + url + "\" name=\"FILENAME\">";
        result = result + "<param value=\"true\" name=\"ShowStatusBar\">";
        result = result + "<param value=\"false\" name=\"AutoStart\">"; 
        result = result + "<embed type=\"application/x-mplayer2\" src=\"" + url + "\" showstatusbar=\"1\" autostart=\"0\" width=\"380\" height=\"64\">";          
        result = result + "</object>";
        return  result;
    }

    private string GetWebPlayer(string url)
    {
        string result = "";
        result = result + "<object id=\"myPlayer\" data=\"webplayer.swf\" type=\"application/x-shockwave-flash\" width=\"280\" height=\"32\">";
        result = result + "<param name=\"movie\" value=\"webplayer.swf\">";
        result = result + "<param name=\"menu\" value=\"false\">";
        result = result + "<param name=\"scale\" value=\"noscale\">";
        result = result + "<param name=\"wmode\" value=\"transparent\">";
        //result = result + "<param name=\"bgcolor\" value=\"#C0C0C0\">";
        result = result + "<param name=\"flashvars\" value=\"src=" + url +  "&autostart=no&loop=no&random=no&remote=no&debug=no\">";
        result = result + "</object>";
        return result;
    }

    private string GetAllMediaPlayer(string url,string chacha,string zing , string youtube)
    {
        StringBuilder result = new StringBuilder();

        result.Append("<div onClick=\"javascript:Player('" + url + "');\" href=\"javascript:void(0);\" style=\"cursor: pointer;  height: 28px; text-align: center; float: left ;padding-right:10px\">Mặc định</div>");
        result.Append(System.Environment.NewLine);
        result.Append("<div onClick=\"javascript:zing('" + zing + "');\" href=\"javascript:void(0);\" style=\"cursor: pointer;  height: 28px;text-align: center; float: left;padding-right:10px\">Zing</div>");
        result.Append(System.Environment.NewLine);
        result.Append("<div onClick=\"javascript:chacha('" + chacha + "');\" href=\"javascript:void(0);\" style=\"cursor: pointer;  height: 28px; text-align: center; float: left; padding-right:10px\">Chacha</div>");
        result.Append(System.Environment.NewLine);
        result.Append("<div onClick=\"javascript:youtube('" + youtube + "');\" href=\"javascript:void(0);\" style=\"cursor: pointer; height: 28px; text-align: center; float: left;\">Youtube</div>");
        result.Append(System.Environment.NewLine);
        result.Append("<div style=\"clear: both; display: block;\" id=\"chacha_audio\"><a class=\"media\" href=\"" + url + "\"></a></div>");
        result.Append(System.Environment.NewLine);
        return result.ToString();
    }

    private void AddToCookBookLinkButton(string LyricName)
    {
        if (Authentication.IsUserAuthenticated)
        {
            UsersCookBookMain UserCookBook = new UsersCookBookMain(UserIdentity.UserID);

            int NumRecordsCookBookAllowed = SiteConfiguration.GetConfiguration.NumberOfLyricInFavorite;

            addtoCookBook.Visible = false;
            LinkButtonAddtoCookBookLogin.Visible = true;

            if (UserCookBook.TotalCount > NumRecordsCookBookAllowed)
            {
                LinkButtonAddtoCookBookLogin.Text = "Ghi nhớ";
                LinkButtonAddtoCookBookLogin.Attributes.Add("onclick", "csscody.alert('<b>Không được phép nhớ bài hát</b><br>Bạn không thể nhớ bất cứ bài hát nào. Bạn đã đạt đến số lượng tối đa của các khoá được cho phép để lưu vào mục yêu thích.');return false;");
                LinkButtonAddtoCookBookLogin.Attributes.Add("onmouseover", "Tip('Không thể lưu tiếp các công thức. Bạn đã đạt đến mức tối đa được phép.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                LinkButtonAddtoCookBookLogin.Attributes.Add("onmouseout", "UnTip()");
            }
            else
            {
                LinkButtonAddtoCookBookLogin.Text = "Ghi nhớ";
                LinkButtonAddtoCookBookLogin.Attributes.Add("onmouseover", "Tip('Thêm bài hát(<b>" + LyricName + "</b>) Vào mục yêu thích.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
                LinkButtonAddtoCookBookLogin.Attributes.Add("onmouseout", "UnTip()");
            }

            UserCookBook = null;
        }
        else
        {
            addtoCookBook.Visible = true;
            saveicon.AlternateText = "Ghi nhớ";
            addtoCookBook.Text = "<a href='javascript:void(0)'>Ghi nhớ</a>";
            addtoCookBook.Attributes.Add("onclick", "csscody.alert('<b>Không cho phép bài hát đó</b><br>Đăng nhập để thêm bài hát (<b>" + LyricName + "</b>) vào mục yêu thích.');return false;");
            addtoCookBook.Attributes.Add("onmouseover", "Tip('Đăng nhập để thêm bài hát đó vào mục yêu thích.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            addtoCookBook.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    private void ShowLyricImage(int LyricID)
    {
        Lyricimage.Visible = false;

        string strLyricImage = GetLyricImage.GetImageForLyricDetails(LyricID);

        if (!string.IsNullOrEmpty(strLyricImage))
        {
            Lyricimage.Visible = true;
            Lyricimage.ImageUrl = strLyricImage.ToString();
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
            lbllogintocomment.Text = "Hãy đăng nhập để có thể thêm lời bình, nếu bạn chưa có tài khoản, hãy nhấn vào đây để " + "<a href='registration.aspx'>Đăng ký</a> một tài khoản trên hệ thống.";
        }
    }

    private void ShowEditLink(LyricDetails lyric)
    {
        if (Authentication.IsUserAuthenticated && lyric.UID == UserIdentity.UserID)
        {
            editLyriclink.Visible = true;
            editLyriclink.Text = "<img src='images/icon_pencil.gif' alt='Sửa' border='0'> Sửa";
            editLyriclink.NavigateUrl = "editlyric.aspx?id=" + lyric.ID;
            editLyriclink.Attributes.Add("onmouseover", "Tip('Sửa thông tin của bài hát <b>" + lyric.LyricName + "</b>.', BGCOLOR, '#FFFBE1', BORDERCOLOR, '#acc6db')");
            editLyriclink.Attributes.Add("onmouseout", "UnTip()");
        }
    }

    public void Add_CookBook(Object s, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            int LyricID = (int)Util.Val(Request.QueryString["id"]);
            Caching.PurgeCacheItems("MyCookBook_SideMenu_" + UserIdentity.UserID);
            Blogic.InsertLyricToFavorite(UserIdentity.UserID, LyricID);
            Response.Redirect("myfavorite.aspx");
        }
    }

    private void GetUserLyricCookieRating(int LyricID)
    {
        CookieRating GetCookie = new CookieRating(constant.intLyric, LyricID, PlaceHolder1);
        GetCookie.GetUserCookieRating();
        GetCookie = null;
    }

    private void ShowNewPopularImage(int LyricID)
    {
        Utility.GetIdentifyItemNewPopular(dateposted, PlaceHolder1, LyricID);
    }

    private void GetRelatedLyrics(int CatID)
    {
        RelatedLyrics.DataSource = RelatedLyricProvider.GetRelatedLyrics(CatID);
        RelatedLyrics.DataBind();
    }

    private void GetComments(int LyricID)
    {
        LyricComments Comment = new LyricComments(LyricID, RecComments, PlaceHolder1);
        Comment.FillUp();
        Comment = null;
    }

    private void GetMetaKeywords(string strPageTitleAndKeywords)
    {
        Page.Header.Title = strPageTitleAndKeywords;
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = "Từ khóa";
        metaTag.Content = strPageTitleAndKeywords;
        this.Header.Controls.Add(metaTag);
    }

    public void Add_Comment(Object s, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            if (Page.IsValid && (txtsecfield.Text.ToString() == Session["randomStr"].ToString()))
            {
                LyricCommentsRepository comment = new LyricCommentsRepository();

                comment.ID = (int)Util.Val(Request.QueryString["id"]);
                comment.UID = UserIdentity.UserID;

                comment.Author = Util.FormatTextForInput(Request.Form[AUTHOR.UniqueID]);
                comment.Email = Util.FormatTextForInput(Request.Form[EMAIL.UniqueID]);
                comment.Comments = Util.FormatTextForInput(Request.Form[COMMENTS.UniqueID]);

                if (comment.Comments.Length == 0)
                {
                    lbvalenght.Text = "<br>Lỗi: Lời bình chưa có, hãy đưa vào lời bình của bạn.";
                    lbvalenght.Visible = true;
                    txtsecfield.Text = "";
                    return;
                }
                if (comment.Comments.Length > 350)
                {
                    lbvalenght.Text = "<br>Lỗi: Lời bình quá dài. Lớn nhất là 350 ký tự.";
                    lbvalenght.Visible = true;
                    txtsecfield.Text = "";
                    return;
                }

                if (comment.Add(comment) != 0)
                {
                    lbvalenght.Text = "Một lỗi cơ sở dữ liệu trong quá trình sử lý lời bình của bạn.";
                    return;
                }

                EmailCommentNotificationToAdministrator(comment.ID, strRName);

                comment = null;

                Response.Redirect("commentpostconfirmation.aspx?ReturnURL=" + this.Request.Url.PathAndQuery);
            }
            else
            {
                lbvalenght.Text = "<br>Mã bảo mật không đúng. Chắc chắn những gì bạn đưa vào là đúng.";
                lbvalenght.Visible = true;
                txtsecfield.Text = "";

                lblinvalidsecode.Text = "Mã bảo mật không đúng. Chắc chắn những gì bạn đưa vào là đúng.";
                lblinvalidsecode.Visible = true;
            }
        }
    }

    private void EmailCommentNotificationToAdministrator(int ID, string LyricName)
    {
        EmailTemplate SendEmail = new EmailTemplate();

        SendEmail.ItemID = ID;
        SendEmail.ItemName = LyricName;

        SendEmail.SendEmailLyricCommentNotify();

        SendEmail = null;
    }
}
