#region XD World Lyric V 3
// FileName: ProviderRecipeDropdownList.cs
// Author: Dexter Zafra
// Date Created: 6/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Lyrics
{
    /// <summary>
    /// Object in this class populate Lyric category dropdownlist
    /// </summary>
    public sealed class ProviderLyricCategoryDropdown
    {
        public ProviderLyricCategoryDropdown()
        {
        }

        private Hashtable _CategoryListLyric;

        /// <summary>
        /// Return a hashtable of Lyric category
        /// </summary>
        public Hashtable categoryListLyric
        {
            get
            {
                if (_CategoryListLyric == null)
                    createCategoryListLyric();
                return _CategoryListLyric;
            }
        }

        /// <summary>
        /// Create a hashtable for Lyric Category dropdownlist
        /// </summary>
        private void createCategoryListLyric()
        {
            //Get data
            IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricCategoryDropdownlist;

            try
            {
                Hashtable ht = new Hashtable();
                while (dr.Read())
                {
                    ht.Add(dr["CAT_ID"].ToString(), dr["CAT_TYPE"].ToString());

                    _CategoryListLyric = ht;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Release allocated memory
            dr.Close();
        }
    }
}