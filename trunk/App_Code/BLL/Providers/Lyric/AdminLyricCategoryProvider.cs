#region XD World Lyric V 3
// FileName: ProviderAdminRecipeCategory.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Lyrics
{
    /// <summary>
    /// object in this class manages admin recipe category object List collection
    /// </summary>
    public static class AdminLyricCategoryProvider
    {
        /// <summary>
        /// Return Lyric Category Data
        /// </summary>
        public static ExtendedCollection<Lyric> GetCategories()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            IDataReader dr = Blogic.ActionProcedureDataProvider.AdminGetLyricCategoryManager;

            while (dr.Read())
            {
                Lyric item = new Lyric();

                item.CatID = (int)dr["CAT_ID"];

                if (dr["CAT_TYPE"] != DBNull.Value)
                {
                    item.Category = (string)dr["CAT_TYPE"];
                }
                if (dr["GROUPCAT"] != DBNull.Value)
                {
                    item.Group = (string)dr["GROUPCAT"];
                }
                if (dr["REC_COUNT"] != DBNull.Value)
                {
                    item.RecordCount = (int)(dr["REC_COUNT"]);
                }

                list.Add(item);
            }

            dr.Close();

            return list;
        }
    }
}
