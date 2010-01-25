#region XD World Lyric V 3
// FileName: ProviderArticleComments.cs
// Author: Dexter Zafra
// Date Created: 8/26/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Web;
using System.Data;
using VGuitar.BL;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL.Providers.Comments
{
    /// <summary>
    /// object in this class manages article comments object List collection
    /// </summary>
    public static class ProviderArticleComments
    {
        /// <summary>
        /// Return Lyric Comment
        /// </summary>
        public static ExtendedCollection<Comment> GetComments(int ID)
        {
            return ProviderDataFieldsComment.GetDataFields(Blogic.ActionProcedureDataProvider.GetArticleComments(ID));
        }
    }
}
