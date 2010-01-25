#region XD World Lyric V 2.8
// FileName: ProviderRelatedRecipe.cs
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
    /// object in this class manages related Lyric object List collection
    /// </summary>
    public static class RelatedLyricProvider
    {
        /// <summary>
        /// Returns related Lyric
        /// </summary>
        public static ExtendedCollection<Lyric> GetRelatedLyrics(int CatId)
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            IDataReader dr = Blogic.ActionProcedureDataProvider.GetRelatedLyric(CatId);

            while (dr.Read())
            {
                Lyric item = new Lyric();

                item.ID = (int)dr["ID"];

                if (dr["Name"] != DBNull.Value)
                {
                    item.LyricName = (string)dr["Name"];
                }
                if (dr["Category"] != DBNull.Value)
                {
                    item.Category = (string)dr["Category"];
                }
                if (dr["Hits"] != DBNull.Value)
                {
                    item.Hits = (int)(dr["Hits"]);
                }
                if (dr["LyricImage"] != DBNull.Value)
                {
                    item.LyricImage = (string)dr["LyricImage"];
                }

                list.Add(item);
            }

            dr.Close();

            return list;
        }
    }
}