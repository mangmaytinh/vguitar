#region XD World Lyric V 3
// FileName: RecipeCommentsRepository.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;
using VGuitar.BL;

namespace VGuitar.Model
{
    /// <summary>
    /// Objects in this class manage Add, update and delete Lyric comments
    /// </summary>
    public class LyricCommentsRepository : BaseCommentObj
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LyricCommentsRepository()
        {
        }

        /// <summary>
        /// Perform Insert to Database
        /// </summary>
        /// <returns></returns>
        public override int Add(Comment comment)
        {
            return Blogic.ActionProcedureDataProvider.AddComment(comment);
        }

        /// <summary>
        /// Perform Update
        /// </summary>
        /// <returns></returns>
        public override int Update(Comment comment)
        {
            return Blogic.ActionProcedureDataProvider.UpdateLyricComments(comment);
        }

        /// <summary>
        /// Perform Delete
        /// </summary>
        /// <returns></returns>
        public override int Delete(Comment comment)
        {
            return Blogic.ActionProcedureDataProvider.AdminDeleteLyricComments(comment);
        }
    }
}
