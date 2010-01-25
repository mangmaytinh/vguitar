#region XD World Lyric V 3
// FileName: DynamicKeywords
// Author: Dexter Zafra
// Date Created: 8/12/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using VGuitar.BL;
using VGuitar.BL.Providers;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL
{
    /// <summary>
    /// Onject in this class manages dynamic page title and keywords based on the page view.
    /// </summary>
    public static class DynamicKeywords
    {
        /// <summary>
        /// Return dynamic page title and keywords
        /// </summary>
        public static string Keywords(int whatpage, int SortBy)
        {
            string strPageTitleAndKeywords = "";

            //whatpage 2 is for the sort.aspx page
            if (whatpage == constant.intRecipeDynamicKeywordSortPage)
            {
                switch (SortBy)
                {
                    case 1:
                        strPageTitleAndKeywords = "100 Most Popular Recipes,100 Most Popular Recipes";
                        break;

                    case 2:
                        strPageTitleAndKeywords = "100 Highest Rated Recipes,100 Highest Rated Recipes";
                        break;

                    case 3:
                        strPageTitleAndKeywords = "Sorted by Lyric Name,Sorted by Lyric Name";
                        break;

                    case 4:
                        strPageTitleAndKeywords = "100 Newest Recipes,100 Newest Recipes";
                        break;

                    default:
                        strPageTitleAndKeywords = "100 Newest Recipes,100 Newest Recipes";
                        break;

                }

            }

            return strPageTitleAndKeywords;
        }

        //overload 1
        public static string Keywords(int whatpage)
        {
            string strPageTitleAndKeywords = "";

            //whatpage 1 is for the category.aspx page
            if (whatpage == constant.intRecipeDynamicKeywordCategory)
            {
                strPageTitleAndKeywords = " recipes, barbeque recipe, seafoods recipes, salad recipe, mexican recipe";
            }

            return strPageTitleAndKeywords;
        }

        //overload 2
        public static string Keywords(int whatpage, string strPagetileKeywords)
        {
            string strPageTitleAndKeywords = "";

            //whatpage 3 is for the lyricdetail.aspx page
            if (whatpage == constant.intLyricDynamicKeywordDetails)
            {
                strPageTitleAndKeywords = strPagetileKeywords;
            }

            return strPageTitleAndKeywords;
        }
    }
}