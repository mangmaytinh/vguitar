#region XD World Lyric V 2.8
// FileName: articlesortoptionlinks.ascx.cs
// Author: Dexter Zafra
// Date Created: 7/18/2008
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
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Common.Utilities;
using Resources;

public partial class articlesortoptionlinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
            //Instantiate utility object
            Utility Util = new Utility();

            int CatId, OrderBy, SortBy;
            OrderBy = (int)Util.Val(Request.QueryString["ob"]);
            SortBy = (int)Util.Val(Request.QueryString["sb"]);

            if (!string.IsNullOrEmpty(Request.QueryString["catid"]))
            {
                CatId = (int)Util.Val(Request.QueryString["catid"]);

                // Here we check what field are we going to sort, this depends on the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkMostPopular.Text = Resources.lang.Most_Popular;
                    LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular_ASC_Order;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkMostPopular.Text = Resources.lang.Most_Popular;
                        LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular_DESC_Order;
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=1";
                    LinkMostPopular.Text = Resources.lang.Most_Popular;
                    LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular;
                    ArrowImage1.Visible = false;
                }
                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkHighestRated.Text = Resources.lang.Highest_Rated;
                    LinkHighestRated.ToolTip = Resources.lang.Sort_category_by_highest_rated_ASC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkHighestRated.Text = Resources.lang.Highest_Rated;
                        LinkHighestRated.ToolTip = Resources.lang.Sort_category_by_highest_rated_DESC_order;
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=2";
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_category_by_highest_rated;
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_song_by_name_DESC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SortBy == 1)
                    {
                        LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                        LinkName.Text = lang.Name;
                        LinkName.ToolTip = lang.Sort_song_by_name_ASC_order;
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=3";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_category_by_name;
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_song_ASC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkNewest.Text = lang.Newest;
                        LinkNewest.ToolTip = lang.Sort_category_by_newest_song_DESC_order;
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/articlecategory.aspx?catid=" + CatId + "&ob=4";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_songs;
                    ArrowImage4.Visible = false;

                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString["find"]))
            {

                string strKeyword;

                CatId = (int)Util.Val(Request.QueryString["catid"]);
                strKeyword = Request.QueryString["find"].ToString();

                // Here we check what field are we going to sort, this depends the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular_ASC_order;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkMostPopular.Text = lang.Most_Popular;
                        LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular_DESC_order;
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=1";
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                    ArrowImage1.Visible = false;
                }
                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_ASC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkHighestRated.Text = lang.Highest_Rated;
                        LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_DESC_order;
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=2";
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_song_by_name_DESC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SortBy == 1)
                    {
                        LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                        LinkName.Text = lang.Name;
                        LinkName.ToolTip = lang.Sort_song_by_name_ASC_order;
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=3";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_by_name;
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=2";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_song_ASC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy + "&sb=1";
                        LinkNewest.Text = lang.Newest;
                        LinkNewest.ToolTip = lang.Sort_category_by_newest_song_DESC_order;
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/searcharticle.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=4";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                    ArrowImage4.Visible = false;
                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString["author"]))
            {

                string strAuthor;

                strAuthor = Request.QueryString["author"].ToString();

                // Here we check what field are we going to sort, this depends the sort value
                if (OrderBy == 1)
                {
                    LinkMostPopular.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=2";
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage1.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkMostPopular.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=1";
                        LinkMostPopular.Text = lang.Most_Popular;
                        LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                        ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage1.Visible = true;
                    }
                }
                else
                {
                    LinkMostPopular.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=1";
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                    ArrowImage1.Visible = false;
                }
                if (OrderBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=2";
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_ASC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage2.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkHighestRated.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=1";
                        LinkHighestRated.Text = lang.Highest_Rated;
                        LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_DESC_order;
                        ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage2.Visible = true;
                    }
                }
                else
                {
                    LinkHighestRated.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=2";
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                    ArrowImage2.Visible = false;
                }
                if (OrderBy == 3)
                {
                    LinkName.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=1";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_by_name_DESC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage3.Visible = true;

                    if (SortBy == 1)
                    {
                        LinkName.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=2";
                        LinkName.Text = lang.Name;
                        LinkName.ToolTip = lang.Sort_by_name_ASC_order;
                        ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage3.Visible = true;
                    }
                }
                else
                {
                    LinkName.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=3";
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_by_name;
                    ArrowImage3.Visible = false;
                }
                if (OrderBy == 4)
                {
                    LinkNewest.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=2";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_song_ASC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                    ArrowImage4.Visible = true;

                    if (SortBy == 2)
                    {
                        LinkNewest.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=" + OrderBy + "&sb=1";
                        LinkNewest.Text = lang.Newest;
                        LinkNewest.ToolTip = lang.Sort_by_Newest_DESC_order;
                        ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                        ArrowImage4.Visible = true;
                    }
                }
                else
                {
                    LinkNewest.NavigateUrl = "~/findallarticlebyauthor.aspx?author=" + strAuthor + "&ob=4";
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_by_Newest;
                    ArrowImage4.Visible = false;
                }
            }

        }
}
