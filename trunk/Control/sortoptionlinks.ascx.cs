#region XD World Lyric V 2.8
// FileName: sortoptionlinks.ascx.cs
// Author: Dexter Zafra
// Date Created: 5/25/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Common.Utilities;
using Resources;

public partial class sortoptionlinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Instantiate validation
        Utility Util = new Utility();

        int OrderBy, Sort_By, iPage, Layout;
        OrderBy = (int)Util.Val(Request.QueryString["ob"]);
        Sort_By = (int)Util.Val(Request.QueryString["sb"]);

        if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
        {
            iPage = 1; //If request pageindex is empty, assign pageindex of 1 = 1st page
        }
        else
        {
            iPage = (int)Util.Val(Request.QueryString["page"]); //Grab the querystring pageindex value
        }

        if (string.IsNullOrEmpty(this.Request.QueryString["layout"]))
        {
            Layout = 1;
        }
        else
        {
            Layout = (int)Util.Val(Request.QueryString["layout"]);
        }

        #region Sort option links for category.aspx
        //Handles the sort option links for the category.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["catid"]))
        {
            int CatId;

            CatId = (int)Util.Val(Request.QueryString["catid"]);

            // Here we check what field are we going to sort, this depends on the sort value
            if (OrderBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = Resources.lang.Most_Popular;
                LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular_ASC_Order;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;

                if (Sort_By == 2)
                {
                    LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = Resources.lang.Most_Popular;
                    LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular_DESC_Order;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage1.Visible = true;
                }
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=1" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = Resources.lang.Most_Popular;
                LinkMostPopular.ToolTip = Resources.lang.Sort_category_by_Most_Popular;
                ArrowImage1.Visible = false;
            }

            if (OrderBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = Resources.lang.Highest_Rated;
                LinkHighestRated.ToolTip = Resources.lang.Sort_category_by_highest_rated_ASC_order;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;

                if (Sort_By == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = Resources.lang.Highest_Rated;
                    LinkHighestRated.ToolTip = Resources.lang.Sort_category_by_highest_rated_DESC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage2.Visible = true;
                }
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=2" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_category_by_highest_rated;
                ArrowImage2.Visible = false;
            }

            if (OrderBy == 3)
            {
                LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_song_by_name_DESC_order;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;

                if (Sort_By == 1)
                {
                    LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_song_by_name_ASC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage3.Visible = true;
                }
            }
            else
            {
                LinkName.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=3" + "&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_category_by_name;
                ArrowImage3.Visible = false;
            }

            if (OrderBy == 4)
            {
                LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_category_by_newest_song_ASC_order;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;

                if (Sort_By == 2)
                {
                    LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_song_DESC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage4.Visible = true;
                }
            }
            else
            {
                LinkNewest.NavigateUrl = "~/category.aspx?catid=" + CatId + "&ob=4&sb=" + Sort_By + "&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_category_by_newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

        #region Sort option links for sort.aspx - most popular
        //Handles the sort option links for the sort.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["sid"]))
        {
            int SortBy, SBy;

            SortBy = (int)Util.Val(Request.QueryString["sid"]);
            SBy = (int)Util.Val(Request.QueryString["sb"]);

            // Here we check what field are we going to sort, this depends the sort value
            if (SortBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_60_Most_Popular_ASC_order;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;

                if (SBy == 2)
                {
                    LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_60_Most_Popular_DESC_order;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage1.Visible = true;
                }
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/sort.aspx?sid=1&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_60_Most_Popular;
                ArrowImage1.Visible = false;
            }

            if (SortBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_60_Highest_Rated_songs_ASC_order;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;

                if (SBy == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_60_Highest_Rated_songs_DESC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage2.Visible = true;
                }
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/sort.aspx?sid=2&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_60_Highest_Rated;
                ArrowImage2.Visible = false;
            }
            if (SortBy == 3)
            {
                LinkName.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name_DESC_order;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;

                if (SBy == 1)
                {
                    LinkName.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_by_name_ASC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage3.Visible = true;
                }
            }
            else
            {
                LinkName.NavigateUrl = "~/sort.aspx?sid=3&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.Visible = false;
            }
            if (SortBy == 4)
            {
                LinkNewest.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_60_Newest_song_ASC_order;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;

                if (SBy == 2)
                {
                    LinkNewest.NavigateUrl = "~/sort.aspx?sid=" + SortBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_by_60_Newest_songs_DESC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage4.Visible = true;
                }
            }
            else
            {
                LinkNewest.NavigateUrl = "~/sort.aspx?sid=4&sb=" + SBy + "&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_60_Newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

        #region Sort option links for lyricname.aspx
        //Handles the sort option links for the lyricname.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["letter"]))
        {
            string letter;
            int Sby = (int)Util.Val(Request.QueryString["sb"]);

            letter = Request.QueryString["letter"].ToString();

            // Here we check what field are we going to sort, this depends the sort value
            if (OrderBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular_ASC_order;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;

                if (Sby == 2)
                {
                    LinkMostPopular.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkMostPopular.Text = lang.Most_Popular;
                    LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular_DESC_order;
                    ArrowImage1.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage1.Visible = true;
                }
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=1&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.Visible = false;
            }

            if (OrderBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_ASC_order;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;

                if (Sby == 2)
                {
                    LinkHighestRated.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkHighestRated.Text = lang.Highest_Rated;
                    LinkHighestRated.ToolTip = lang.Sort_by_highest_rated_DESC_order;
                    ArrowImage2.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage2.Visible = true;
                }
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=2&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.Visible = false;
            }
            if (OrderBy == 3)
            {
                LinkName.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_song_by_name_DESC_order;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;

                if (Sby == 1)
                {
                    LinkName.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                    LinkName.Text = lang.Name;
                    LinkName.ToolTip = lang.Sort_song_by_name_ASC_order;
                    ArrowImage3.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage3.Visible = true;
                }
            }
            else
            {
                LinkName.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=3&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.Visible = false;
            }
            if (OrderBy == 4)
            {
                LinkNewest.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=2&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_category_by_newest_song_ASC_order;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;

                if (Sby == 2)
                {
                    LinkNewest.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=" + OrderBy + "&sb=1&page=" + iPage + "&layout=" + Layout;
                    LinkNewest.Text = lang.Newest;
                    LinkNewest.ToolTip = lang.Sort_category_by_newest_song_DESC_order;
                    ArrowImage4.ImageUrl = Util.SortOptionArrowUpImage;
                    ArrowImage4.Visible = true;
                }
            }
            else
            {
                LinkNewest.NavigateUrl = "~/lyricname.aspx?letter=" + letter + "&ob=4&sb=" + Sby + "&page=" + iPage + "&layout=" + Layout;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

        #region Sort option links for search.aspx
        //Handles the sort option links for the search.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["find"]))
        {
            int CatId;
            string strKeyword;

            CatId = (int)Util.Val(Request.QueryString["catid"]);
            strKeyword = Request.QueryString["find"].ToString();

            // Here we check what field are we going to sort, this depends the sort value
            if (OrderBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=1";
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.Visible = false;
            }
            if (OrderBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=2";
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.Visible = false;
            }
            if (OrderBy == 3)
            {
                LinkName.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;
            }
            else
            {
                LinkName.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=3";
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.Visible = false;
            }
            if (OrderBy == 4)
            {
                LinkNewest.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=" + OrderBy;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;
            }
            else
            {
                LinkNewest.NavigateUrl = "~/searchlyric.aspx?find=" + strKeyword + "&catid=" + CatId + "&ob=4";
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

        #region Sort option links for findallrecipebyauthor
        //Handles the sort option links for findalllyricbyauthor.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["author"]))
        {
            string strAuthorName;
            strAuthorName = Request.QueryString["author"].ToString();

            // Here we check what field are we going to sort, this depends the sort value
            if (OrderBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=" + OrderBy;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=1";
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.Visible = false;
            }
            if (OrderBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=" + OrderBy;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=2";
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.Visible = false;
            }
            if (OrderBy == 3)
            {
                LinkName.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=" + OrderBy;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;
            }
            else
            {
                LinkName.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=3";
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.Visible = false;
            }
            if (OrderBy == 4)
            {
                LinkNewest.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=" + OrderBy;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;
            }
            else
            {
                LinkNewest.NavigateUrl = "~/findalllyricbyauthor.aspx?author=" + strAuthorName + "&ob=4";
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

        #region Sort option links for findalllyriccommentedbyuser.aspx
        //Handles the sort option links for findalllyriccommentedbyuser.aspx
        if (!string.IsNullOrEmpty(Request.QueryString["commentauthor"]))
        {
            string strCommentAuthorName;
            strCommentAuthorName = Request.QueryString["commentauthor"].ToString();

            // Here we check what field are we going to sort, this depends the sort value
            if (OrderBy == 1)
            {
                LinkMostPopular.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=" + OrderBy;
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage1.Visible = true;
            }
            else
            {
                LinkMostPopular.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=1";
                LinkMostPopular.Text = lang.Most_Popular;
                LinkMostPopular.ToolTip = lang.Sort_by_Most_Popular;
                ArrowImage1.Visible = false;
            }
            if (OrderBy == 2)
            {
                LinkHighestRated.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=" + OrderBy;
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage2.Visible = true;
            }
            else
            {
                LinkHighestRated.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=2";
                LinkHighestRated.Text = lang.Highest_Rated;
                LinkHighestRated.ToolTip = lang.Sort_by_highest_rated;
                ArrowImage2.Visible = false;
            }
            if (OrderBy == 3)
            {
                LinkName.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=" + OrderBy;
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage3.Visible = true;
            }
            else
            {
                LinkName.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=3";
                LinkName.Text = lang.Name;
                LinkName.ToolTip = lang.Sort_by_name;
                ArrowImage3.Visible = false;
            }
            if (OrderBy == 4)
            {
                LinkNewest.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=" + OrderBy;
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.ImageUrl = Util.SortOptionArrowImage;
                ArrowImage4.Visible = true;
            }
            else
            {
                LinkNewest.NavigateUrl = "~/findalllyriccommentedbyuser.aspx?commentauthor=" + strCommentAuthorName + "&ob=4";
                LinkNewest.Text = lang.Newest;
                LinkNewest.ToolTip = lang.Sort_by_newest_songs;
                ArrowImage4.Visible = false;

            }
        }
        #endregion

    }
}

