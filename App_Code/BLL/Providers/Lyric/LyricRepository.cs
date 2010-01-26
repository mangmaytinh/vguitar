#region XD World Lyric V 2.8
// FileName: RecipeRepository.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using VGuitar.Model;

namespace VGuitar.BL
{
    /// <summary>
    /// Objects in this class manages Add, Update and Delete Lyric
    /// </summary>
    public class LyricRepository : BaseLyricObj
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LyricRepository()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add(Lyric lyric)
        {
            return Blogic.ActionProcedureDataProvider.AddLyric(lyric);
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update(Lyric lyric)
        {
            return Blogic.ActionProcedureDataProvider.UpdateLyric(lyric);
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete(Lyric lyric)
        {
            return Blogic.ActionProcedureDataProvider.AdminLyricManagerDelete(lyric);
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int AddCategory(Lyric category)
        {
            return Blogic.ActionProcedureDataProvider.AdminAddNewLyricCategory(category);
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int UpdateCategory(Lyric category)
        {
            return Blogic.ActionProcedureDataProvider.UpdateLyricCategory(category);
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int DeleteCategory(Lyric category)
        {
            return Blogic.ActionProcedureDataProvider.AdminDeleteLyricCategory(category);
        }
    }
}


