#region XD World Lyric V 3
// FileName: GetLyricImage.cs
// Author: Dexter Zafra
// Date Created: 9/11/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using VGuitar.BL;

namespace VGuitar.BL
{
    /// <summary>
    /// Object in this class manages recipe image and path
    /// </summary>
    public static class GetLyricImage
    {

        /// <summary>
        /// Return the recipe image
        /// </summary>
        public static string GetLyricImageUserEdit(int ID)
        {
            string FileName;

            FileName = "LyricImageUpload/noimageavailable.gif";

            IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricImageFileNameForUpdate(ID);

            dr.Read();

            if (dr["LyricImage"] != DBNull.Value)
            {
                FileName = "LyricImageUpload/" + (string)dr["LyricImage"];
            }

            dr.Close();

            return FileName;
        }

        /// <summary>
        /// Return the recipe image for admin section
        /// </summary>
        public static string GetImage(int ID) 
        {
            string FileName;

            FileName = "../LyricImageUpload/noimageavailable.gif";

            IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricImageFileNameForUpdate(ID);

            dr.Read();

            if (dr["LyricImage"] != DBNull.Value)
            {
                FileName = "../LyricImageUpload/" + (string)dr["LyricImage"];
            }

            dr.Close();

            return FileName;          
        }

        /// <summary>
        /// Return the recipe image for the recipe details
        /// </summary>
        public static string GetImageForLyricDetails(int ID)
        {
            string FileName;

            FileName = "LyricImageUpload/noimageavailable.gif";

            IDataReader dr = Blogic.ActionProcedureDataProvider.GetLyricImageFileNameForUpdate(ID);

            dr.Read();

            if (dr["LyricImage"] != DBNull.Value)
            {
                FileName = "LyricImageUpload/" + (string)dr["LyricImage"];
            }

            dr.Close();

            if (FileName.IndexOf("noimageavailable.gif") != -1)
            {
                FileName = string.Empty;
            }

            return FileName;
        }

        /// <summary>
        /// Return recipe image path for Admin
        /// </summary>
        public static string ImagePath
        {
            get
            {
                return "../LyricImageUpload/";
            }
        }

        /// <summary>
        /// Return recipe image path for recipedetail
        /// </summary>
        public static string ImagePathDetail
        {
            get
            {
                return "LyricImageUpload/";
            }
        }
    }
}
