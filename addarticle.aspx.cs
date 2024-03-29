#region XD World Lyric V 2.8
// FileName: addarticle.cs
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
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.User;
using VGuitar.BL.Providers.Article;

public partial class addarticle : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            HideContentIfNotLogin.Visible = true;
            lblauthorname.Text = UserIdentity.UserName.ToString();

            LoadDropDownListCategory.LoadDropDownCategory("Article Category", ddlarticlecategory, "Chọn chuyên mục"); 
        }
        else
        {
            lblyouarenotlogin.Visible = true;
            lblyouarenotlogin.Text = "<div style='margin-top: 12px; margin-bottom: 7px;'><img src='images/lock.gif' align='absmiddle'> Bạn phải có quyền để thêm mới, chia sẻ một bài viết.</div>";
        }
    }

    public void Add_Article(Object s, EventArgs e)
    {
        if (Authentication.IsUserAuthenticated)
        {
            Utility Util = new Utility();

            ArticleRepository Article = new ArticleRepository();

            Article.UID = UserIdentity.UserID;
            Article.Author = UserIdentity.UserName;
            Article.Title = Util.FormatTextForInput(Request.Form["Title"]);
            Article.Summary = Util.FormatTextForInput(Request.Form["Summary"]);
            Article.Content = Request.Form["Content"];
            Article.CatID = Int32.Parse(Request.Form["ddlarticlecategory"]);
            Article.Keyword = Util.FormatTextForInput(Request.Form["Keyword"]);

            #region Form Input Validator
            if (Article.Title.Length == 0)
            {
                lbvalenght.Text = "<br>Lỗi: Tiêu đề chưa có, Hãy nhập tiêu đề bài viết vào.";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.CatID == 0)
            {
                lbvalenght.Text = "<br>Lỗi: Bạn phải chọn một chuyên mục, nơi mà bài viết hiển thị";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.Summary.Length == 0)
            {
                lbvalenght.Text = "<br>Lõi: Nội dung tóm tắt chưa có, hãy nhập nội dung tóm tắt vào.";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.Content.Length == 0)
            {
                lbvalenght.Text = "<br>Lõi: Nội dung bài viết chưa có, hãy nhập nội dung bài viết vào.";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.Keyword.Length == 0)
            {
                lbvalenght.Text = "<br>Lỗi: Từ khóa cho bài viết chưa có, hãy nhập từ khóa vào.";
                lbvalenght.Visible = true;
                return;
            }
            //if (Article.Content.Length > 8000)
            //{
            //    lbvalenght.Text = "<br>Error: Content is too long, max of 8000 characters including HTML formatting.";
            //    lbvalenght.Visible = true;
            //    return;
            //}
            if (Article.Title.Length > 65)
            {
                lbvalenght.Text = "<br>Lỗi: Tiêu đề quá dài, nó không thể lớn hơn 65 ký tự.";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.Summary.Length > 350)
            {
                lbvalenght.Text = "<br>Lỗi: Nội dung tóm tắt quá dài, nó không thể vượt quá 350 ký tự.";
                lbvalenght.Visible = true;
                return;
            }
            if (Article.Keyword.Length > 80)
            {
                lbvalenght.Text = "<br>Lỗi: Từ khóa quá dài, nó không thể vượt quá 80 ký tự.";
                lbvalenght.Visible = true;
                return;
            }

            #endregion

            if (Article.Add(Article) != 0)
            {
                JSLiteral.Text = "Quá trình sử lý thất bại.";
                return;
            }

            Article = null;
            Util = null;

            Response.Redirect("confirmsubmitarticle.aspx?mode=Added");
        }
    }
}
