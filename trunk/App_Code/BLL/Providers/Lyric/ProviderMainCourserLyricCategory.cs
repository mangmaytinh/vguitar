#region XD World Lyric V 3
// FileName: ProviderMainCourserRecipeCategory.cs
// Author: Dexter Zafra
// Date Created: 8/26/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Data;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Lyrics
{
    /// <summary>
    /// object in this class manages main course Lyric category object List collection
    /// </summary>
    public static class MainCourseLyricCategoryProvider
    {

        /// <summary>
        /// Return Lyric Main Course Category
        /// </summary>
        /// <returns></returns>
        public static ExtendedCollection<Lyric> GetMainCourseCategory()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            string Key = "MainCourse_LyricCategory";

            if (Caching.Cache[Key] != null)
            {
                list = (ExtendedCollection<Lyric>)Caching.Cache[Key];
            }

            else
            {
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetHomepageMainCourseCategory;

                while (dr.Read())
                {
                    Lyric item = new Lyric();

                    item.CatID = (int)dr["CAT_ID"];

                    if (dr["CAT_TYPE"] != DBNull.Value)
                    {
                        item.Category = (string)dr["CAT_TYPE"];
                    }

                    if (dr["REC_COUNT"] != DBNull.Value)
                    {
                        item.RecordCount = (int)(dr["REC_COUNT"]);
                    }

                    list.Add(item);

                    Caching.CahceData(Key, list);
                }

                dr.Close();
            }

            return list;
        }
    }
}