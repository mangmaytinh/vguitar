#region XD World Lyric V 3
// FileName: ProviderLastViewedRecipe.cs
// Author: Dexter Zafra
// Date Created: 7/15/2008
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
    /// Objects in this class manages last viewed recipe
    /// </summary>
    public static class ProviderLastViewedLyric
    {
        /// <summary>
        /// Returns the number of hours
        /// </summary>
        public static int GetMinuteSpan
        {
            get
            {
                int MinuteSpan = 0;

                try
                {
                    IDataReader dr = GetData;

                    dr.Read();

                    //Get the Minutes/hours span
                    MinuteSpan = (int)dr["MinuteSpan"];

                    dr.Close();
                }
                catch
                {
                }

                return MinuteSpan;
            }
        }

        /// <summary>
        /// Return Last Viewed Lyric Data
        /// </summary>
        /// <returns></returns>
        public static IDataReader GetData
        {
            get
            {
                //Get data
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetLastViewedLyric;

                return dr;
            }
        }

        public static ExtendedCollection<Lyric> GetLastViewedLyric()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

                IDataReader dr = GetData;

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
                    if (dr["Hours"] != DBNull.Value)
                    {
                        item.Hours = (int)(dr["Hours"]);
                    }
                    if (dr["Minutes"] != DBNull.Value)
                    {
                        item.Minutes = (int)(dr["Minutes"]);
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
