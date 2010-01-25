#region XD World Lyric V 3
// FileName: LoadDropDownListCategory.cs
// Author: Dexter Zafra
// Date Created: 5/15/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using VGuitar.Common;
using System.Web.UI.WebControls;
using System.Collections;
using VGuitar.BL.Providers.Article;
using VGuitar.BL.Providers.Lyrics;

namespace VGuitar.BL
{
    /// <summary>
    /// Object in this class load the category dropdownlist.
    /// </summary>
    public static class LoadDropDownListCategory
    {
        public static void LoadDropDownCategory(string SectionName, DropDownList ddlname, string defaultvalue)
        {
            if (SectionName == "Article Category")
            {
                ProviderArticleCategoryDropdown LoadArticleCategoryData = new ProviderArticleCategoryDropdown();
                DropdownlistHelper.FillUpDropDown(ddlname, LoadArticleCategoryData.categoryListArticle, defaultvalue);
                LoadArticleCategoryData = null;
            }
            else if (SectionName == "Lyric Category")
            {
                ProviderLyricCategoryDropdown LoadLyricCategoryData = new ProviderLyricCategoryDropdown();
                DropdownlistHelper.FillUpDropDown(ddlname, LoadLyricCategoryData.categoryListLyric, defaultvalue);
                LoadLyricCategoryData = null;
            }
        }
    }
}
