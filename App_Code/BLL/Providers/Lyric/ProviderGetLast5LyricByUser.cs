#region XD World Lyric V 3
// FileName: ProviderGetLast5LyricByUser.cs
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
    /// object in this class returns a list of the last 5 recipe published by user.
    /// </summary>
    public sealed class ProviderGetLast5LyricByUser : Lyric
    {
        private static readonly ProviderGetLast5LyricByUser Instance = new ProviderGetLast5LyricByUser();

        static ProviderGetLast5LyricByUser()
        {
        }

        ProviderGetLast5LyricByUser()
        {
        }

        public static ProviderGetLast5LyricByUser GetInstance()
        {
            return Instance;
        }

        public void Param(int UserID)
        {
            this._UID = UserID;
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
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetLast5LyricByUser(UID);
                return dr;
            }
        }

        public ExtendedCollection<Lyric> GetRecipe()
        {
           ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

           string Key = "Last5_RecipePublishedByUser_" + UID;

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

