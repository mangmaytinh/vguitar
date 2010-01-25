#region XD World Lyric V 3
// FileName: ProviderRecipeOftheDay.cs
// Author: Dexter Zafra
// Date Created: 5/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Text;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Lyrics
{
    /// <summary>
    /// Objects in this class manages Lyric of the day
    /// </summary>
    public sealed class LyricoftheDay : BaseLyricObj
    {
        private static readonly LyricoftheDay Instance = new LyricoftheDay();
 
        static LyricoftheDay() 
        {
        }

        LyricoftheDay() 
        { 
        }

        public static LyricoftheDay GetInstance()
        {
          return Instance;
        }

        /// <summary>
        /// Get Lyric name, author, date, hits, rating, ingredients, instructions and other field from the DB matching the Lyric ID provided.
        /// </summary>
        /// <param name="ID">Lyric ID</param>
        public override void FillUp()
          {
              try
              {
                  IDataReader dr = Blogic.ActionProcedureDataProvider.GetHomepageLyricoftheDay;

                  dr.Read();

                  if (dr["ID"] != DBNull.Value)
                  {
                      this._ID = (int)dr["ID"];
                  }
                  if (dr["Name"] != DBNull.Value)
                  {
                      this._LyricName = (string)dr["Name"];
                  }
                  if (dr["CAT_ID"] != DBNull.Value)
                  {
                      this._CatID = (int)dr["CAT_ID"];
                  }
                  if (dr["NO_RATES"] != DBNull.Value)
                  {
                      this._NoRates = dr["NO_RATES"].ToString();
                  }
                  if (dr["HITS"] != DBNull.Value)
                  {
                      this._Hits = (int)dr["HITS"];
                  }
                  if (dr["Rates"] != DBNull.Value)
                  {
                      this._Rating = dr["Rates"].ToString();
                  }
                  if (dr["Category"] != DBNull.Value)
                  {
                      this._Category = (string)dr["Category"];
                  }
                  if (dr["Ingredients"] != DBNull.Value)
                  {
                      this._Ingredients = (string)dr["Ingredients"];
                  }
                  if (dr["Instructions"] != DBNull.Value)
                  {
                      this._Instructions = (string)dr["Instructions"];
                  }

                  dr.Close();
                  dr = null;
              }
              catch (Exception ex)
              {
                  throw ex;
              }
        }
    }
}