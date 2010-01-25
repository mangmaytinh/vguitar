#region XD World Lyric V 3
// FileName: ProviderEthnicRecipeCategory.cs
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
    /// object in this class manages ethnic recipe category object List collection
    /// </summary>
    public static class EthnicLyricCategoryProvider
    {
        /// <summary>
        /// Return GetData
        /// </summary>
        public static ExtendedCollection<Lyric> GetEthnicCategory()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            string Key = "Ethnic_RecipeCategory";
          
            if (Caching.Cache[Key] != null)
            {
                list = (ExtendedCollection<Lyric>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetHomepageEthnicRegionalCategory;

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