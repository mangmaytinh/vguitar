#region XD World Lyric V 3
// FileName: ProviderNewestRecipeSideMenu.cs
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
    /// object in this class manages newest Lyric sidemenu object List collection
    /// </summary>
    public sealed class NewestLyricSideMenuProvider : Lyric
    {
        private static readonly NewestLyricSideMenuProvider Instance = new NewestLyricSideMenuProvider();

        static NewestLyricSideMenuProvider()
        {
        }

        NewestLyricSideMenuProvider()
        {
        }

        public static NewestLyricSideMenuProvider GetInstance()
        {
            return Instance;
        }

        public void NewestLyricParam(int CatId, int Top)
        {

            if (CatId != null)
            {
                this._CatID = CatId;
            }

            this._Top = Top;

            IDataReader dr = GetData;

            if (dr.Read())
            {
                //Get the category name
                this._Category = (string)dr["Category"];
            }
            dr.Close();
        }

        /// <summary>
        /// Return Lyric Category Data
        /// </summary>
        /// <returns></returns>
        private IDataReader GetData
        {
            get
            {
                //Get data
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetNewestLyricsSideMenu(CatID, Top);

                return dr;
            }
        }

        public ExtendedCollection<Lyric> GetNewestLyric()
        {
            string Key = "Newest_LyricsSideMenu_" + CatID.ToString();

            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            if (Caching.Cache[Key] != null)
            {
                list = (ExtendedCollection<Lyric>)Caching.Cache[Key];
            }
            else
            {
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
                    if (dr["Date"] != DBNull.Value)
                    {
                        item.Date = (DateTime)(dr["Date"]);
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
