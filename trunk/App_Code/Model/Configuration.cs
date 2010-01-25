#region XD World Lyric V 3
// FileName: Configuration.cs
// Author: Dexter Zafra
// Date Created: 2/14/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;


namespace VGuitar.Model
{
    /// <summary>
    /// Site Configuration object
    /// </summary>
    public class Configuration
    {
        protected int _ShowHideLyricComment;
        protected int _ShowHideArticleComment;
        protected int _NumberOfLyricInFavorite;
        protected int _NumberOfFriendsInFriendsList;
        protected int _PublicPrivateProfile;
        protected string _AdminToEmail;
        protected string _AdminFromEmail;
        protected int _LastViewedNumberOfHoursSpan;

        public int ShowHideRecipeComment
        {
            get { return _ShowHideLyricComment; }
            set { _ShowHideLyricComment = value; }
        }
        public int ShowHideArticleComment
        {
            get { return _ShowHideArticleComment; }
            set { _ShowHideArticleComment = value; }
        }
        public int NumberOfLyricInFavorite
        {
            get { return _NumberOfLyricInFavorite; }
            set { _NumberOfLyricInFavorite = value; }
        }
        public int NumberOfFriendsInFriendsList
        {
            get { return _NumberOfFriendsInFriendsList; }
            set { _NumberOfFriendsInFriendsList = value; }
        }
        public int PublicPrivateProfile
        {
            get { return _PublicPrivateProfile; }
            set { _PublicPrivateProfile = value; }
        }
        public string AdminToEmail
        {
            get { return _AdminToEmail; }
            set { _AdminToEmail = value; }
        }
        public string AdminFromEmail
        {
            get { return _AdminFromEmail; }
            set { _AdminFromEmail = value; }
        }
        public int LastViewedNumberOfHoursSpan
        {
            get { return _LastViewedNumberOfHoursSpan; }
            set { _LastViewedNumberOfHoursSpan = value; }
        }
    }
}
