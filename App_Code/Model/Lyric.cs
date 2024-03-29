#region XD World Lyric V 3
// FileName: recipe.cs
// Author: Dexter Zafra
// Date Created: 6/30/2008
// Website: www.ex-designz.net
#endregion
using System;

namespace VGuitar.Model
{
    /// <summary>
    /// Objects in this class manages Lyric properties and fields
    /// </summary>
    // This class a generic Lyric properties and fields use in Lyricdetail, admin update and admin review page
    public class Lyric : pager
    {
        ///<summary>Default Constructor</summary>
        public Lyric()
        {
        }

        #region Class Variables
        /// <summary>What Page We are dealing</summary>
        protected int _WhatPageID;

        /// <summary>Lyric ID</summary>
        protected int _ID;

        /// <summary>Search Keyword</summary>
        protected string _Keyword;

        /// <summary>Letter</summary>
        protected string _Letter;

        /// <summary>Search Keyword</summary>
        protected string _FindByAuthor;

        /// <summary>Lyric Name</summary>
        protected string _LyricName;

        /// <summary>Author</summary>
        protected string _Author;

        /// <summary>Category ID</summary>
        protected int _CatID;

        /// <summary>No of Votes</summary>
        protected string _NoRates;

        /// <summary>No of Hits</summary>
        protected int _Hits;

        /// <summary>Rating</summary>
        protected string _Rating;

        /// <summary>Category</summary>
        protected string _Category;

        /// <summary>Ingredients</summary>
        protected string _Ingredients;

        /// <summary>Instruction</summary>
        protected string _Instructions;

        /// <summary>Date of Submission</summary>
        protected DateTime _Date;

        ///<summary>Comment Count</summary>
        protected int _CountComments;

        ///<summary>Approved Flag</summary>
        protected int _Approved;

        /// <summary>Category Group ID</summary>
        protected int _CatGroupID;

        /// <summary>Record Count</summary>
        protected int _RecordCount;

        /// <summary>Category Type</summary>
        protected string _Group;

        protected int _Hours;

        protected int _Minutes;

        protected string _LyricImage;

        protected DateTime _HitDate;

        protected int _Top;

        protected int _OrderBy;

        protected int _SortBy;

        protected string _AuthorName;

        protected string _CreateBy;

        protected int _UID;

        protected string _UrlMusic;

        protected string _UrlVideo;
        protected string _UrlZing;
        protected string _UrlChacha;
        protected string _UrlYoutube;

        #endregion

        #region Properties - Get and Set Accessor
        public int WhatPageID
        {
            get { return _WhatPageID; }
            set { _WhatPageID = value; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Letter
        {
            get { return _Letter; }
            set { _Letter = value; }
        }
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }
        public string FindByAuthor
        {
            get { return _FindByAuthor; }
            set { _FindByAuthor = value; }
        }
        public string LyricName
        {
            get { return _LyricName; }
            set { _LyricName = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public int CatID
        {
            get { return _CatID; }
            set { _CatID = value; }
        }

        public string NoRates
        {
            get { return _NoRates; }
            set { _NoRates = value; }
        }
        public int Hits
        {
            get { return _Hits; }
            set { _Hits = value; }
        }
        public string Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public string Ingredients
        {
            get { return _Ingredients; }
            set { _Ingredients = value; }
        }
        public string Instructions
        {
            get { return _Instructions; }
            set { _Instructions = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public int CountComments
        {
            get { return _CountComments; }
            set { _CountComments = value; }
        }
        public int Approved
        {
            get { return _Approved; }
            set { _Approved = value; }
        }
        public string LyricImage
        {
            get { return _LyricImage; }
            set { _LyricImage = value; }
        }
        public DateTime HitDate
        {
            get { return _HitDate; }
            set { _HitDate = value; }
        }
        public int CatGroupID
        {
            get { return _CatGroupID; }
            set { _CatGroupID = value; }
        }
        public int RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        }
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }
        public int Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }
        public int Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }
        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public int OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }
        public int SortBy
        {
            get { return _SortBy; }
            set { _SortBy = value; }
        }
        public string AuthorName
        {
            get { return _AuthorName; }
            set { _AuthorName = value; }
        }
        public int UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        public string CreateBy
        {
            get { return _CreateBy; }
            set { _CreateBy = value; }
        }

        public string UrlMusic
        {
            get { return _UrlMusic; }
            set { _UrlMusic = value; }
        }

        public string UrlVideo
        {
            get { return _UrlVideo; }
            set { _UrlVideo = value; }
        }

        public string UrlZing
        {
            get { return _UrlZing; }
            set { _UrlZing = value; }
        }

        public string UrlChacha
        {
            get { return _UrlChacha; }
            set { _UrlChacha = value; }
        }

        public string UrlYoutube
        {
            get { return _UrlYoutube; }
            set { _UrlYoutube = value; }
        }
        #endregion
    }
}
