#region XD World Lyric V 3
// FileName: searchuser.cs
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using VGuitar.BL.Providers.User;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Security;
using VGuitar.Common.Utilities;
using VGuitar.BL.Providers.CookBooks;
using VGuitar.BL.Providers.FriendList;
using VGuitar.BL.Providers.User;

public partial class searchuser : BasePage
{
    private Utility Util
    {
        get { return new Utility(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["input"]) && Utility.IsNumeric(Request.QueryString["condition"]))
        {
            Util.SecureQueryString(Request.QueryString["input"]);

            string Input = Request.QueryString["input"];

            int iPage = 1;
            int Condition = 1;

            if (!string.IsNullOrEmpty(Request.QueryString["condition"]))
                Condition = (int)Util.Val(Request.QueryString["condition"]);

            string ParamURL = Request.CurrentExecutionFilePath + "?input=" + Input + "&condition=" + Condition;

            if (!string.IsNullOrEmpty(this.Request.QueryString["page"]))
                iPage = (int)Util.Val(Request.QueryString["page"]);

            int PageSize = PagerLinks.DefaultPageSize;
            int PageIndex = iPage;

            ProviderUsersSearch Search = new ProviderUsersSearch(Input, Condition, PageIndex, PageSize);

            lblcounter.Text = "<img src='images/community-users-icon.jpg' align='absmiddle'>&nbsp;&nbsp;Có " + Search.TotalCount + " Thành viên " + ConditionTextMsg;

            PagerLinks Pager = PagerLinks.GetInstance();
            Pager.PagerLinksParam(PageIndex, PageSize, Search.TotalCount);

            lbPagerLink.Text = Pager.DisplayNumericPagerLink(ParamURL, 0, 0, iPage);

            lblRecpage.Text = Pager.GetBottomPagerCounterCustomPaging;

            UserSearchRep.DataSource = Search.GetUserSearchResult();
            UserSearchRep.DataBind();

            lblAplhaLetterLinks.Text = AlphabetLink.BuildLinkSearchMembers("searchuser.aspx?input=", "content12", "Duyệt tất cả các thành viên tên bắt đầu bằng chữ cái", "&nbsp;&nbsp;&nbsp;");

            Search = null;
        }
    }

    private string ConditionTextMsg
    {
        get
        {
            string Input = Request.QueryString["input"];

            int Condition = 1;

            if (!string.IsNullOrEmpty(Request.QueryString["condition"]))
                Condition = Int32.Parse(Request.QueryString["condition"]);;

            string CondtionText = "";

            switch (Condition)
            {
                case 1:
                    if (Input.Length == 1)
                        CondtionText = "với tài khoản bắt đầu bằng ký tự <b>" + Input + "</b>";
                    else
                        CondtionText = "với tài khoản là " + Input;
                    break;
                case 2:
                    CondtionText = " " + Input;
                    break;
                case 3:
                    CondtionText = "với tên đệm là " + Input;
                    break;
                case 4:
                    CondtionText = "đến từ tỉnh/thành phố " + Input;
                    break;
                case 5:
                    CondtionText = "đến từ vùng/miền " + Input;
                    break;
                case 6:
                    CondtionText = "đến từ quốc tịch " + Input;
                    break;
            }

            return CondtionText;
        }
    }
}
