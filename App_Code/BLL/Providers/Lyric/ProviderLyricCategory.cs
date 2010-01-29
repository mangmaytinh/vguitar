#region XD World Lyric V 3
// FileName: ProviderRecipeCategory.cs
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
    /// object in this class manages Lyric category object List collection
    /// </summary>
    public sealed class LyricCategoryProvider : Lyric
    {
        private static readonly LyricCategoryProvider Instance = new LyricCategoryProvider();

        static LyricCategoryProvider()
        {
        }

        LyricCategoryProvider()
        {
        }

        public static LyricCategoryProvider GetInstance()
        {
            return Instance;
        }

        public void CategoryParam(int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
        {
            this._CatID = CatId;
            this._OrderBy = OrderBy;
            this._SortBy = SortBy;
            this._Index = PageIndex;
            this._PageSize = PageSize;

            IDataReader dr = GetData;

            while (dr.Read())
            {
                //Get the category name and record count
                this._Category = (string)dr["Category"];
                this._RecordCount = (int)dr["RCount"];
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
                IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricCategoryWithCustomPaging(CatID, OrderBy, SortBy, Index, PageSize);
                return dr;
            }
        }

        public ExtendedCollection<Lyric> GetCategories()
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
                if (dr["Ingredients"] != DBNull.Value)
                {
                    item.Ingredients = (string)dr["Ingredients"];
                }
                if (dr["CreateBy"] != DBNull.Value)
                {
                    item.CreateBy = (string)dr["CreateBy"];
                }

                list.Add(item);
            }

            dr.Close();

            return list;
        }
    }
}
