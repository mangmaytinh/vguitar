#region XD World Lyric V 2.8
// FileName: default.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VGuitar.UI;
using VGuitar.BL;
using VGuitar.BL.Providers.Lyrics;
using VGuitar.Common;
using VGuitar.Model;
using VGuitar.Common.Utilities;
using Resources;

public partial class _default : BasePage
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        GetMetaKeywords();

        lbltotalLyric.Text = "Có tất cả " + string.Format("{0:#,###}",
        Blogic.ActionProcedureDataProvider.GetHomepageTotalLyricCount) + " bài hát hợp âm và " + Blogic.ActionProcedureDataProvider.GetHomepageTotalCategoryCount + " danh mục";

        Myranimage.ImageUrl = Utility.GetRandomImage;

        BindList();
    }

    private void BindList()
    {
        MainCourseCategory.DataSource = MainCourseLyricCategoryProvider.GetMainCourseCategory();
        MainCourseCategory.DataBind();

        EthnicRegionalCat.DataSource = EthnicLyricCategoryProvider.GetEthnicCategory();
        EthnicRegionalCat.DataBind();
    }

    private void GetMetaKeywords()
    {
        Page.Header.Title = "VGuitar";
        HtmlMeta metaTag = new HtmlMeta();
        metaTag.Name = Resources.lang.Keywords;
        metaTag.Content = "Hợp âm, Gam , bản nhạc";
        this.Header.Controls.Add(metaTag);
    }
}
