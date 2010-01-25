#region XD World Lyric V 3
// FileName: ProviderDataFieldsCookBook.cs
// Author: Dexter Zafra
// Date Created: 3/29/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VGuitar.Model;
using VGuitar.Common;

namespace VGuitar.BL.Providers.CookBooks
{
    /// <summary>
    /// Object in this class provides data fields list for Cook Book.
    /// </summary>
    public static class ProviderDataFieldsCookBook
    {
        public static ExtendedCollection<CookBook> GetDataFields(IDataReader dr)
        {
            ExtendedCollection<CookBook> list = new ExtendedCollection<CookBook>();

            while (dr.Read())
            {
                CookBook item = new CookBook();

                if (dr["ID"] != DBNull.Value)
                {
                    item.itemID = (int)dr["ID"];
                }
                if (dr["UID"] != DBNull.Value)
                {
                    item.UIDForDelete = (int)dr["UID"];
                }
                if (dr["RecipeID"] != DBNull.Value)
                {
                    item.RecipeID = (int)dr["RecipeID"];
                }
                if (dr["LyricName"] != DBNull.Value)
                {
                    item.LyricName = (string)dr["LyricName"];
                }
                if (dr["Hits"] != DBNull.Value)
                {
                    item.Hits = (int)dr["Hits"];
                }
                if (dr["Date"] != DBNull.Value)
                {
                    item.Date = (DateTime)(dr["Date"]);
                }
                if (dr["Author"] != DBNull.Value)
                {
                    item.Author = (string)dr["Author"];
                }
                if (dr["Category"] != DBNull.Value)
                {
                    item.Category = (string)dr["Category"];
                }
                if (dr["TOTAL_COMMENTS"] != DBNull.Value)
                {
                    item.Comments = (int)dr["TOTAL_COMMENTS"];
                }
                if (dr["Rates"] != DBNull.Value)
                {
                    item.Rating = dr["Rates"].ToString();
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

