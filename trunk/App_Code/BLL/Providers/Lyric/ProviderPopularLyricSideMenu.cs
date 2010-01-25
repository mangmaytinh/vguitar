#region XD World Lyric V 3
// FileName: ProviderPopularRecipeSideMenu.cs
// Author: Dexter Zafra
// Date Created: 8/26/2008
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
    /// object in this class manages popular Lyric sidemenu object List collection
    /// </summary>
    public sealed class PopularLyricSideMenuProvider : Lyric
    {
        private static readonly PopularLyricSideMenuProvider Instance = new PopularLyricSideMenuProvider();
 
        static PopularLyricSideMenuProvider() 
        {
        }

        PopularLyricSideMenuProvider() 
        { 
        }

        public static PopularLyricSideMenuProvider GetInstance()
        {
          return Instance;
        }

        public void PopularLyricParam(int CatId, int Top)
        {
            if (CatId != null)
            {
                this._CatID = CatId;
            }

            this._Top = Top;
        }

        /// <summary>
        /// Returns Most Popular Lyrics Side Menu
        /// </summary>
        public ExtendedCollection<Lyric> GetPopularLyric()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            string Key = "MostPopular_LyricsSideMenu_" + CatID.ToString();

            if (Caching.Cache[Key] != null)
            {
                list = (ExtendedCollection<Lyric>)Caching.Cache[Key];
            }
            else
            {
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetMostpopularLyricsSideMenu(CatID, Top);

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
                    if (dr["HITS"] != DBNull.Value)
                    {
                        item.Hits = (int)dr["HITS"];
                    }
                    if (dr["LyricImage"] != DBNull.Value)
                    {
                        item.LyricImage = (string)dr["LyricImage"];
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
