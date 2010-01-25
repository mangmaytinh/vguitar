#region XD World Lyric V 3
// FileName: ProviderGetAllRecipeCommentedbyUser.cs
// Author: Dexter Zafra
// Date Created: 8/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Collections.Generic;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Lyrics
{
    /// <summary>
    /// object in this class returns all recipe by author
    /// </summary>
    public sealed class ProviderGetAllLyricCommentedbyUser : Lyric
    {
        private static readonly ProviderGetAllLyricCommentedbyUser Instance = new ProviderGetAllLyricCommentedbyUser();

        static ProviderGetAllLyricCommentedbyUser()
        {
        }

        ProviderGetAllLyricCommentedbyUser()
        {
        }

        public static ProviderGetAllLyricCommentedbyUser GetInstance()
        {
            return Instance;
        }

        public void Param(string AuthorName, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._AuthorName = AuthorName;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            while (dr.Read())
            {
                //Get category name and record count
                this._RecordCount = (int)dr["RCount"];
            }

            dr.Close();
        }

        /// <summary>
        /// Return Data
        /// </summary>
        /// <returns></returns>
        private IDataReader GetData
        {
            get
            {
                //Get data
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetAllLyricCommentedByUser(AuthorName, OrderBy, Index, PageSize);
                return dr;
            }
        }

        public ExtendedCollection<Lyric> GetAllRecipeCommentedByAuthorResult()
        {
            ExtendedCollection<Lyric> list = new ExtendedCollection<Lyric>();

            IDataReader dr = GetData;

            while (dr.Read())
            {
                Lyric item = new Lyric();

                item.ID = (int)dr["ID"];

                item.CatID = (int)dr["CAT_ID"];

                if (dr["Name"] != DBNull.Value)
                {
                    item.LyricName = (string)dr["Name"];
                }
                if (dr["Category"] != DBNull.Value)
                {
                    item.Category = (string)dr["Category"];
                }
                if (dr["Author"] != DBNull.Value)
                {
                    item.Author = (string)dr["Author"];
                }
                if (dr["Rates"] != DBNull.Value)
                {
                    item.Rating = dr["Rates"].ToString();
                }
                if (dr["NO_RATES"] != DBNull.Value)
                {
                    item.NoRates = dr["NO_RATES"].ToString();
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
                if (dr["UID"] != DBNull.Value)
                {
                    item.UID = (int)dr["UID"];
                }

                list.Add(item);
            }

            dr.Close();

            return list;
        }
    }
}


