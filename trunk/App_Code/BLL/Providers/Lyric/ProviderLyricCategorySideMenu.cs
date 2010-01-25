#region XD World Lyric V 3
// FileName: ProviderRecipeCategorySideMenu.cs
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
    /// object in this class manages Lyric category side menu object List collection
    /// </summary>
    public static class LyricCategoryMenuProvider
    {
        /// <summary>
        /// Return Lyric Category
        /// </summary>
        public static ExtendedCollection<Lyric> GetLyricCategoryMenu()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            string Key = "LyricCategory_SideMenu";

            if (Caching.Cache[Key] != null)
            {
                list = (ExtendedCollection<Lyric>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricCategoryList_SideMenu;

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