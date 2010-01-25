#region XD World Lyric V 3
// FileName: CookBook.cs
// Author: Dexter Zafra
// Date Created: 2/21/2009
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

namespace VGuitar.Model
{
    /// <summary>
    /// Object in this class manages users Cookbook
    /// </summary>
    public class CookBook
    {
        //Default constructor
        public CookBook()
        {
        }

        protected int _itemID;

        protected int _UID;

        protected string _UserName;

        protected int _UIDForDelete;

        protected int _RecipeID;

        protected string _LyricName;

        protected int _Hits;

        protected DateTime _Date;

        protected int _TotalCount;

        protected int _NumRecords;

        protected string _Author;

        protected string _Category;

        protected int _Comments;

        protected string _Rating;

        protected string _LyricImage;


        public int itemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        public int UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public int UIDForDelete
        {
            get { return _UIDForDelete; }
            set { _UIDForDelete = value; }
        }

        public int RecipeID
        {
            get { return _RecipeID; }
            set { _RecipeID = value; }
        }
        public string LyricName
        {
            get { return _LyricName; }
            set { _LyricName = value; }
        }
        public int Hits
        {
            get { return _Hits; }
            set { _Hits = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public int TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }
        public int NumRecords
        {
            get { return _NumRecords; }
            set { _NumRecords = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public int Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        public string Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public string LyricImage
        {
            get { return _LyricImage; }
            set { _LyricImage = value; }
        }
    }
}
