#region XD World Lyric V 3
// FileName: ActionStoredPrecedure.cs
// Author: Dexter Zafra
// Date Created: 5/19/2008
// Website: www.ex-designz.net
#endregion
using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using System.Collections;
using System.Diagnostics;
using VGuitar.DAL;
using VGuitar.Model;

namespace VGuitar.BL
{
    /// <summary>
    /// Class which contains the logic to execute retrieval of stored procedures in the database.
    /// </summary>
    public sealed class Blogic
   {
        static readonly Blogic Instance = new Blogic();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Blogic()
        {
        }

        Blogic()
        {
        }

        /// <summary>
        /// Execute retrieval of stored procedures in the database.
        /// </summary>
        public static Blogic ActionProcedureDataProvider
        {
            get
            {
                return Instance;
            }
        }

      /// <summary>
      /// Returns category in the homepage.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetCategoryHomePage
      {
          get { return DataAccess.GetFromReader("spSelectLyricCategory"); }
      }

        public IDataReader GetSpiderLyrics(int CatId)
      {
          SqlParameter prmCate = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCate.Value = CatId;
          return DataAccess.GetFromReader("GetSpiderLyrics", prmCate); 
      }

      /// <summary>
      /// Returns lyric category dropdownlist.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetLyricCategoryDropdownlist
      {
          get { return DataAccess.GetFromReader("spSelectLyricCategory"); }
      }

      /// <summary>
      /// Returns homepage main course lyric category.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetHomepageMainCourseCategory
        {
            get { return DataAccess.GetFromReader("GetHomePageCategoryMainCourseLyric"); }
        }

      /// <summary>
      /// Returns homepage ethnic and regional Lyric category.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetHomepageEthnicRegionalCategory
      {
          get { return DataAccess.GetFromReader("GetHomepageEthnicRegionalCategory"); }
      }

      /// <summary>
      /// Returns homepage Lyric of the day.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetHomepageLyricoftheDay
      {
          get { return DataAccess.GetFromReader("GetLyricOfTheDay"); }
      }

      /// <summary>
      /// Returns homepage 15 last viewed Lyric in the homepage.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetLastViewedLyric
        {
            get { return DataAccess.GetFromReader("GetLastViewedLyric"); }
        }

      /// <summary>
      /// Returns category list with count in the sidemenu.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetLyricCategoryList_SideMenu
       {
           get { return DataAccess.GetFromReader("GetLyricCategoryListSideMenu"); }
       }

       /// <summary>
       /// Returns random Lyric in the side menu.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetRandomLyricSideMenu(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetFromReader("GetRandomLyric", prmCatId);
       }

       /// <summary>
       /// Returns Lyric details.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetLyricDetail(int ID, int Approved)
        {
            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
            prmID.Value = ID;

            SqlParameter prmApproved = new SqlParameter("@Approved", SqlDbType.Int, 4);
            prmApproved.Value = Approved;

            return DataAccess.GetFromReader("spGetLyricDetail", prmID, prmApproved);
        }

       /// <summary>
       /// Returns article detail.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetArticleDetail(int ID, int Show)
       {
           SqlParameter prmID = new SqlParameter("@AID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmShow = new SqlParameter("@Show", SqlDbType.Int, 4);
           prmShow.Value = Show;

           return DataAccess.GetFromReader("GetArticleDetails", prmID, prmShow);
       }

       /// <summary>
       /// Returns Lyric comments.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetCommentsLyricDetail(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.GetFromReader("spSelectCommentLyric", prmID);
       }

       /// <summary>
       /// Returns related Lyric in the Lyric detail.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetRelatedLyric(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetFromReader("GetRelatedLyric", prmCatId);
       }

      /// <summary>
      /// Returns newest Lyrics in the side menu.
      /// </summary>
      /// <returns></returns>
       public IDataReader GetNewestLyricsSideMenu(int CatId, int Top)
       {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
          prmTop.Value = Top;

          return DataAccess.GetFromReader("GetNewestLyricsSideMenu", prmCatId, prmTop);
      }

      /// <summary>
      /// Returns RSS Most Popular Lyric
      /// </summary>
      /// <returns></returns>
      public IDataReader GetRSSMostPopularLyric
      {
          get { return DataAccess.GetFromReader("GetXMLTopLyric"); }
      }

      /// <summary>
      /// Returns RSS newest Lyric
      /// </summary>
      /// <returns></returns>
      public IDataReader GetRSSNewestLyric
      {
          get { return DataAccess.GetFromReader("GetXMLNewestLyric"); }
      }

      /// <summary>
      /// Returns Admin Article Comments
      /// </summary>
      /// <returns></returns>
      public DataTable AdminGetArticleComments(string Author)
      {
          SqlParameter prmAuthor = new SqlParameter("@FindByAuthor", SqlDbType.VarChar, 50);
          prmAuthor.Value = Author;

          return DataAccess.GetFromDataTable("spSelectArticleCommentAdmin", prmAuthor);
      }

      /// <summary>
      /// Returns Admin Get Lyric Category Manager
      /// </summary>
      /// <returns></returns>
        public IDataReader AdminGetLyricCategoryManager
      {
          get { return DataAccess.GetFromReader("AdminGetLyricCategoryManager"); }
      }

      /// <summary>
      /// Returns category name
      /// </summary>
      /// <param name="CategoryID">Category ID</param>
      /// <returns></returns>
      public IDataReader GetCatName(int CatId)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          return DataAccess.GetFromReader("GetCategoryName", prmCatId);
      }

      /// <summary>
      /// Returns Lyric image filename to use for update
      /// </summary>
      /// <returns></returns>
        public IDataReader GetLyricImageFileNameForUpdate(int ID)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.GetFromReader("GetLyricImageFileNameForUpdate", prmID);
      }

      /// <summary>
      /// Returns user image filename by userID - This is use when deleting a user to delete user image in the folder.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUserPhotoByUserID(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectUserPhotoByUserID", prmUserID);
      }

      /// <summary>
      /// Returns Admin Lyric Comments
      /// </summary>
      /// <returns></returns>
      public DataTable AdminGetLyricComments(string Author)
      {
          SqlParameter prmAuthor = new SqlParameter("@FindByAuthor", SqlDbType.VarChar, 50);
          prmAuthor.Value = Author;

          return DataAccess.GetFromDataTable("AdminLyricComments", prmAuthor);
      }

      /// <summary>
      /// Log Exception Error
      /// </summary>
      public static int LogExceptionError(string URL, string ExceptionError)
      {
          SqlParameter prmURL = new SqlParameter("@URL", SqlDbType.VarChar, 100);
          prmURL.Value = URL;

          SqlParameter prmExceptionError = new SqlParameter("@Exception", SqlDbType.VarChar, 1000);
          prmExceptionError.Value = ExceptionError;

          return DataAccess.Execute("spInsertExceptionError", prmURL, prmExceptionError);
      }

      /// <summary>
      /// Returns site statistics counter
      /// </summary>
      /// <returns></returns>
        public IDataReader SiteStatisticsCounter
        {
            get { return DataAccess.GetFromReader("spSelectSiteStatistics"); }
        }

        /// <summary>
        /// Returns unapprove article - articles waiting for approval.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetUnApprovedArticle
        {
            get { return DataAccess.GetFromReader("spSelectUnApprovedArticle"); }
        }

        /// <summary>
        /// Returns Count of unapproved articles
        /// </summary>
        /// <returns></returns>
        public static int GetUnApprovedArticleCount
        {
            get { return DataAccess.GetIntScalarVal("spGetCountofUnApprovedArticle"); }
        }

        /// <summary>
        /// Check whether an account has been activated
        /// </summary>
        public static bool IsAccountActivated(string GUID)
        {
            SqlParameter prmGUID = new SqlParameter("@Guid", SqlDbType.VarChar, 100);
            prmGUID.Value = GUID;

            int Result = DataAccess.GetInt32("spCheckIfAccountIsActivated", prmGUID);

            if (Result != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check if the account activation code is valid
        /// </summary>
        public static bool IsAccountActivattionCodeValid(string GUID)
        {
            SqlParameter prmGUID = new SqlParameter("@Guid", SqlDbType.VarChar, 100);
            prmGUID.Value = GUID;

            int Result = DataAccess.GetInt32("spCheckIfActivationCodeIsvalid", prmGUID);

            if (Result != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns a username in the activation page.
        /// </summary>
        /// <returns></returns>
        public static string GetUserNameForActivationPage(string GUID)
        {
            SqlParameter prmGUID = new SqlParameter("@Guid", SqlDbType.VarChar, 100);
            prmGUID.Value = GUID;

            return DataAccess.GetString("spGetActivationUserName", prmGUID);
        }

        /// <summary>
        /// Returns the last 20 users who submitted a Lyric
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast20UserWhoSubmittedLyric
        {
            get { return DataAccess.GetFromReader("spSelectLast20UserWhoSubmittedLyric"); }
        }

        /// <summary>
        /// Returns the last 20 users who submitted an article
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast20UsersWhoSubmittedArticle
        {
            get { return DataAccess.GetFromReader("spSelectLast20UsersWhoSubmittedArticle"); }
        }

        /// <summary>
        /// Returns the last 50 Exception Error
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast50ExceptionErrorLog
        {
            get { return DataAccess.GetFromReader("spSelectLast50ExceptionErrorLog"); }
        }

        /// <summary>
        /// Returns the last 25 users who added a friend with friend username.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast25UsersWhoAddedAFriend
        {
            get { return DataAccess.GetFromReader("spSelectLast25UsersWhoAddedAFriend"); }
        }

        /// <summary>
        /// Returns the last 25 users who added a Lyric in CookBook.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast25UsersWhoAddedLyricInFavorite
        {
            get { return DataAccess.GetFromReader("spSelectLast25UsersWhoAddedLyricInFavorite"); }
        }

        /// <summary>
        /// Returns the last 25 users who commented a Lyric.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast25UsersWhoCommentedALyric
        {
            get { return DataAccess.GetFromReader("spSelectLast25UsersWhoCommentedALyric"); }
        }

        /// <summary>
        /// Returns 50 users who has not activated the account.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetTop50UsersWhoHasNotActivatedAnAccount
        {
            get { return DataAccess.GetFromReader("spSelectTop50UsersWhoHasNotActivatedAnAccount"); }
        }

        /// <summary>
        /// Delete exception log
        /// </summary>
        public static int DeleteException(string CsvID)
        {
            SqlParameter prmCsvID = new SqlParameter("@CsvID", SqlDbType.VarChar, 200);
            prmCsvID.Value = CsvID;

            return DataAccess.Execute("spDeleteExceptionLog", prmCsvID);
        }

        /// <summary>
        /// Returns the last 10 updated article from article update log.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast10UpdatedArticle
        {
            get { return DataAccess.GetFromReader("spSelectLast10UpdatedArticle"); }
        }

        /// <summary>
        /// Returns the last 10 updated Lyric from Lyric update log.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetLast10UpdatedLyric
        {
            get { return DataAccess.GetFromReader("spSelectLast10UpdatedLyric"); }
        }

        /// <summary>
        /// Returns Top 5 Lyric by user
        /// </summary>
        public IDataReader GetLast5LyricByUser(int UserID)
        {
            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            prmUserID.Value = UserID;

            return DataAccess.GetFromReader("spSelectLast5LyricByUser", prmUserID);
        }

        /// <summary>
        /// Returns Top 5 article by user
        /// </summary>
        public IDataReader GetLast5ArticleByUser(int UserID)
        {
            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
            prmUserID.Value = UserID;

            return DataAccess.GetFromReader("spSelectLast5ArticleByUser", prmUserID);
        }

        /// <summary>
        /// Returns deleted user log.
        /// </summary>
        /// <returns></returns>
        public IDataReader ViewDeletedUsersLog
        {
            get { return DataAccess.GetFromReader("spSelectViewDeleteduserLog"); }
        }

        /// <summary>
        /// Returns top 25 users who commented a Lyric with count.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetTop25UsersWhoCommentALyric
        {
            get { return DataAccess.GetFromReader("spSelectTop25UsersWhoCommentALyric"); }
        }

        /// <summary>
        /// Returns top 25 users who commented an article with count.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetTop25UsersWhoCommentAnArticle
        {
            get { return DataAccess.GetFromReader("spSelectTop25UsersWhoCommentAnArticle"); }
        }

        /// <summary>
        /// Returns site configuration.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetSiteConfiguration
        {
            get { return DataAccess.GetFromReader("spSelectSiteConfigurationAdmin"); }
        }

        /// <summary>
        /// Update the number of records to show in Users CookBook.
        /// </summary>
        public static int UpdateConfigNumberOfRecordsInCookBookAdmin(int NumRecord)
        {
            SqlParameter prmNumRecord = new SqlParameter("@NumRecords", SqlDbType.Int, 4);
            prmNumRecord.Value = NumRecord;

            return DataAccess.Execute("spUpdateConfigNumberOfRecordsInCookBookAdmin", prmNumRecord);
        }

        /// <summary>
        /// Update the number of records to show in Users Friends List.
        /// </summary>
        public static int UpdateConfigNumberOfRecordsInFriendsListAdmin(int NumRecord)
        {
            SqlParameter prmNumRecord = new SqlParameter("@NumRecords", SqlDbType.Int, 4);
            prmNumRecord.Value = NumRecord;

            return DataAccess.Execute("spUpdateConfigNumberOfRecordsInFriendsListAdmin", prmNumRecord);
        }

#region Users Membership and Site Configuration
      /// <summary>
      /// User Login
      /// </summary>
      public static bool UserLoginVerify(string UserName, string Paswword)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmPaswword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
          prmPaswword.Value = Paswword;

          int Result = DataAccess.GetInt32("spVerifyUserLoginCredential", prmUserName, prmPaswword);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Check user status if active or temporarily disabled due to site policy violation.
      /// </summary>
      public static bool IsUserActive(string UserName, string Paswword)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmPaswword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
          prmPaswword.Value = Paswword;

          int Result = DataAccess.GetInt32("spSelectUserStatus", prmUserName, prmPaswword);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Check if account has been activated by clicking on the link in the new account email activation.
      /// </summary>
      public static bool IsUserActivated(string UserName, string Paswword)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmPaswword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
          prmPaswword.Value = Paswword;

          int Result = DataAccess.GetInt32("spSelectCheckUserActivation", prmUserName, prmPaswword);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Activate user account
      /// </summary>
      public static int ActivateAccount(string strGUID)
      {
          SqlParameter prmGUID = new SqlParameter("@GUID", SqlDbType.VarChar, 100);
          prmGUID.Value = strGUID;

          return DataAccess.Execute("spActivateAccount", prmGUID);
      }

      /// <summary>
      /// Get UserID
      /// </summary>
      public static int GetUserID(string UserName, string Paswword)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmPaswword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
          prmPaswword.Value = Paswword;

          return DataAccess.GetInt32("spGetUserID", prmUserName, prmPaswword);
      }

      /// <summary>
      /// Check Username availability during registration - used by Ajax
      /// </summary>
      public static bool IsUsernameAvailable(string UserName)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          int Result = DataAccess.GetInt32("spCheckUsernameAvailabilityAjax", prmUserName);

          if (Result == 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Check email in the database if it exists during registration - used by Ajax
      /// </summary>
      public static bool IsEmailExists(string Email)
      {
          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = Email;

          int Result = DataAccess.GetInt32("spCheckEmailIfExistsAjax", prmEmail);

          if (Result == 1)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Check whether user wants to show his/her Friends List in the user profile
      /// </summary>
      public static bool IsShowUserFriendsListInProfile(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          int Result = DataAccess.GetInt32("spSelectFriendsListUserConfig", prmUserID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Check whether user wants to show his/her Friends List in the user profile
      /// </summary>
      public static bool IsShowUserCookBookInProfile(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          int Result = DataAccess.GetInt32("spSelectUserCookBookConfig", prmUserID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Returns users features configuration settings.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersFeaturesConfiguration(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectUsersFeaturesConfiguration", prmUserID);
      }

      /// <summary>
      /// Returns last 5 users who saved my published Lyric in their Cook Book.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetLast5UsersWhoSavedMyLyricInCookBook(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectLast5UsersWhoSavedMyLyricInFavorite", prmUserID);
      }

      /// <summary>
      /// Returns last 5 users who saved this Lyric in their Cook Book.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsersWhoSavedThisLyricInFavorite(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectUsersWhoSavedThisLyricInFavorite", prmUserID);
      }

      /// <summary>
      /// Configure user preferred layout and pagesize settings
      /// </summary>
        public static int ConfigurePreferredLayoutPagesize(int UserID, int TurnOnOff, int Layout, int PageSize)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmTurnOnOff = new SqlParameter("@ChoosePreferredLayout", SqlDbType.Int, 4);
          prmTurnOnOff.Value = TurnOnOff;

          SqlParameter prmLayout = new SqlParameter("@PreferredLayout", SqlDbType.Int, 4);
          prmLayout.Value = Layout;

          SqlParameter prmPageSize = new SqlParameter("@PreferredPagesize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.Execute("spUpdatePreferredLayoutPageSizeFromMyAccount", prmUserID, prmTurnOnOff, prmLayout, prmPageSize);
      }

      /// <summary>
      /// Update user preferred category layout
      /// </summary>
      public static int UpdateUserPreferredLayout(int UserID, int Layout)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmLayout = new SqlParameter("@PreferredLayout", SqlDbType.Int, 4);
          prmLayout.Value = Layout;

          return DataAccess.Execute("spUpdateUserPreferredLayout", prmUserID, prmLayout);
      }

      /// <summary>
      /// Update user preferred category pagesize
      /// </summary>
      public static int UpdateUserPreferredPageSize(int UserID, int PageSize)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmPageSize = new SqlParameter("@PreferredPagesize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.Execute("spUpdateUserPreferredPageSize", prmUserID, prmPageSize);
      }

      /// <summary>
      /// Returns suspenion note by particular user
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsersSuspenionNote(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectViewSuspenionNoteByuserID", prmUserID);
      }

      /// <summary>
      /// Returns user search basic result.
      /// </summary>
      /// <returns></returns>
        public IDataReader SearchUser(string Input, int Condition, int PageIndex, int PageSize)
      {
          SqlParameter prmInput = new SqlParameter("@Input", SqlDbType.VarChar, 50);
          prmInput.Value = Input;

          SqlParameter prmCondition = new SqlParameter("@Condition", SqlDbType.Int, 4);
          prmCondition.Value = Condition;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectSearchUser", prmInput, prmCondition, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns all users/members - user front-end.
      /// </summary>
      /// <returns></returns>
        public IDataReader ShowAllMembers(int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectDisplayAllMembers", prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns all users/members - Admin Membership back-end.
      /// </summary>
      /// <returns></returns>
      public IDataReader ShowAllMembersAdmin(string SearchInput, int NumDays, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmSearchInput = new SqlParameter("@Input", SqlDbType.VarChar, 50);
          prmSearchInput.Value = SearchInput;

          SqlParameter prmNumDays = new SqlParameter("@NumDays", SqlDbType.Int, 4);
          prmNumDays.Value = NumDays;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectDisplayAllMembersAdmin", prmSearchInput, prmNumDays, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Add new user
      /// </summary>
      /// <returns></returns>
      public static int AddNewUser(Users user)
      {
          SqlParameter prmUsername = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUsername.Value = user.Username;

          SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
          prmPassword.Value = user.Password;

          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = user.Email;

          SqlParameter prmFirstName = new SqlParameter("@Firstname", SqlDbType.VarChar, 50);
          prmFirstName.Value = user.FirstName;

          SqlParameter prmLastName = new SqlParameter("@Lastname", SqlDbType.VarChar, 50);
          prmLastName.Value = user.LastName;

          SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar, 50);
          prmCity.Value = user.City;

          SqlParameter prmState = new SqlParameter("@State", SqlDbType.VarChar, 50);
          prmState.Value = user.State;

          SqlParameter prmCountry = new SqlParameter("@Country", SqlDbType.VarChar, 50);
          prmCountry.Value = user.Country;

          SqlParameter prmDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
          prmDOB.Value = user.DOB;

          SqlParameter prmFavoriteFoods1 = new SqlParameter("@FavoriteFoods1", SqlDbType.VarChar, 50);
          prmFavoriteFoods1.Value = user.FavoriteFoods1;

          SqlParameter prmFavoriteFoods2 = new SqlParameter("@FavoriteFoods2", SqlDbType.VarChar, 50);
          prmFavoriteFoods2.Value = user.FavoriteFoods2;

          SqlParameter prmFavoriteFoods3 = new SqlParameter("@FavoriteFoods3", SqlDbType.VarChar, 50);
          prmFavoriteFoods3.Value = user.FavoriteFoods3;

          SqlParameter prmNewsletter = new SqlParameter("@Newsletter", SqlDbType.Int, 4);
          prmNewsletter.Value = user.NewsLetter;

          SqlParameter prmContactMe = new SqlParameter("@ContactMe", SqlDbType.Int, 4);
          prmContactMe.Value = user.ContactMe;

          SqlParameter prmWebsite = new SqlParameter("@Website", SqlDbType.VarChar, 100);
          prmWebsite.Value = user.Website;

          SqlParameter prmAboutMe = new SqlParameter("@AboutMe", SqlDbType.VarChar, 1000);
          prmAboutMe.Value = user.AboutMe;

          SqlParameter prmPhoto = new SqlParameter("@Photo", SqlDbType.VarChar, 50);
          prmPhoto.Value = user.Photo;

          SqlParameter prmGUID = new SqlParameter("@Guid", SqlDbType.VarChar, 100);
          prmGUID.Value = user.GUID;

          return DataAccess.Execute("spInsertUser", prmUsername, prmPassword, prmEmail, prmFirstName, prmLastName, prmCity, prmState, prmCountry, prmDOB,
              prmFavoriteFoods1, prmFavoriteFoods2, prmFavoriteFoods3, prmNewsletter, prmContactMe, prmWebsite, prmAboutMe, prmPhoto, prmGUID);
      }


      /// <summary>
      /// Update user
      /// </summary>
      /// <returns></returns>
        public static int UpdateUser(Users user)
      {
          SqlParameter prmUserId = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserId.Value = user.UID;

          SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
          prmPassword.Value = user.Password;

          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = user.Email;

          SqlParameter prmFirstName = new SqlParameter("@Firstname", SqlDbType.VarChar, 50);
          prmFirstName.Value = user.FirstName;

          SqlParameter prmLastName = new SqlParameter("@Lastname", SqlDbType.VarChar, 50);
          prmLastName.Value = user.LastName;

          SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar, 50);
          prmCity.Value = user.City;

          SqlParameter prmState = new SqlParameter("@State", SqlDbType.VarChar, 50);
          prmState.Value = user.State;

          SqlParameter prmCountry = new SqlParameter("@Country", SqlDbType.VarChar, 50);
          prmCountry.Value = user.Country;

          SqlParameter prmDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
          prmDOB.Value = user.DOB;

          SqlParameter prmFavoriteFoods1 = new SqlParameter("@FavoriteFoods1", SqlDbType.VarChar, 50);
          prmFavoriteFoods1.Value = user.FavoriteFoods1;

          SqlParameter prmFavoriteFoods2 = new SqlParameter("@FavoriteFoods2", SqlDbType.VarChar, 50);
          prmFavoriteFoods2.Value = user.FavoriteFoods2;

          SqlParameter prmFavoriteFoods3 = new SqlParameter("@FavoriteFoods3", SqlDbType.VarChar, 50);
          prmFavoriteFoods3.Value = user.FavoriteFoods3;

          SqlParameter prmNewsletter = new SqlParameter("@Newsletter", SqlDbType.Int, 4);
          prmNewsletter.Value = user.NewsLetter;

          SqlParameter prmContactMe = new SqlParameter("@ContactMe", SqlDbType.Int, 4);
          prmContactMe.Value = user.ContactMe;

          SqlParameter prmWebsite = new SqlParameter("@Website", SqlDbType.VarChar, 100);
          prmWebsite.Value = user.Website;

          SqlParameter prmAboutMe = new SqlParameter("@AboutMe", SqlDbType.VarChar, 1000);
          prmAboutMe.Value = user.AboutMe;

          SqlParameter prmPhoto = new SqlParameter("@Photo", SqlDbType.VarChar, 50);
          prmPhoto.Value = user.Photo;

          return DataAccess.Execute("spUpdateUser", prmUserId, prmPassword, prmEmail, prmFirstName, prmLastName, prmCity, prmState, prmCountry, prmDOB,
              prmFavoriteFoods1, prmFavoriteFoods2, prmFavoriteFoods3, prmNewsletter, prmContactMe, prmWebsite, prmAboutMe, prmPhoto);
      }

      /// <summary>
      /// Delete user
      /// </summary>
        public static int DeleteUser(Users user)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = user.UID;

          return DataAccess.Execute("spDeleteUser", prmUserID);
      }

      /// <summary>
      /// Insert a log when user is deleted.
      /// </summary>
      public static int DeleteUserLog(int UserID, string UserName, string Reason)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmReason = new SqlParameter("@Reason", SqlDbType.VarChar, 250);
          prmReason.Value = Reason;

          return DataAccess.Execute("spInsertDeletedUserLog", prmUserID, prmUserName, prmReason);
      }

      /// <summary>
      /// Suspend user
      /// </summary>
      public static int SuspendUser(int UserID, string Type, string Note)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmType = new SqlParameter("@Type", SqlDbType.VarChar, 50);
          prmType.Value = Type;

          SqlParameter prmNote = new SqlParameter("@Note", SqlDbType.VarChar, 500);
          prmNote.Value = Note;

          return DataAccess.Execute("spSuspendUserWithNote", prmUserID, prmType, prmNote);
      }

      /// <summary>
      /// Resinstate user account.
      /// </summary>
        public static int ReinstateUserAccount(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.Execute("spReinstateUserAccount", prmUserID);
      }

      /// <summary>
      /// Recover Lost Password
      /// </summary>
      /// <returns></returns>
      public IDataReader RecoverLostPassword(string Email)
      {
          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = Email;

          return DataAccess.GetFromReader("spSelectRecoverLostPassword", prmEmail);
      }

      /// <summary>
      /// Validate username and email during registration.
      /// </summary>
      /// <returns></returns>
      public IDataReader ValidateUsernameAndEmail(string UserName, string Email)
      {
          SqlParameter prmUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = Email;

          return DataAccess.GetFromReader("spValidateUsernameAndEmailOnRegistration", prmUserName, prmEmail);
      }

      /// <summary>
      /// Update number records Friends List in profile
      /// </summary>
      public static int UpdateNumberRecordsFriendsListProfile(int UserID, int NewValue)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewValue = new SqlParameter("@NewValue", SqlDbType.Int, 4);
          prmNewValue.Value = NewValue;

          return DataAccess.Execute("spUpdateNumRecordsFriendsListProfile", prmUserID, prmNewValue);
      }

      /// <summary>
      /// Update number records CookBook in profile
      /// </summary>
      public static int UpdateNumberRecordsCookBookProfile(int UserID, int NewValue)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewValue = new SqlParameter("@NewValue", SqlDbType.Int, 4);
          prmNewValue.Value = NewValue;

          return DataAccess.Execute("spUpdateNumRecordsCookBookProfile", prmUserID, prmNewValue);
      }

      /// <summary>
      /// Update show/hide Friends List in profile
      /// </summary>
      public static int UpdateShowHideFriendsListInProfile(int UserID, int NewValue)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewValue = new SqlParameter("@NewValue", SqlDbType.Int, 4);
          prmNewValue.Value = NewValue;

          return DataAccess.Execute("spUpdateShowHideFriendsListProfile", prmUserID, prmNewValue);
      }

      /// <summary>
      /// Update show/hide CookBook in profile
      /// </summary>
      public static int UpdateShowHideCookBookInProfile(int UserID, int NewValue)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewValue = new SqlParameter("@NewValue", SqlDbType.Int, 4);
          prmNewValue.Value = NewValue;

          return DataAccess.Execute("spUpdateShowHideCookBookInProfile", prmUserID, prmNewValue);
      }

      /// <summary>
      /// Record user last login
      /// </summary>
      public static int UpdateUserLastLogin(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.Execute("spUpdateLastVisit", prmUserID);
      }

      /// <summary>
      /// Returns users
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsers(int UID)
      {
          SqlParameter prmUID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUID.Value = UID;

          return DataAccess.GetFromReader("spSelectUser", prmUID);
      }

      /// <summary>
      /// Check whether profile page is public or private.
      /// </summary>
      public static bool IsProfilePagePublic
      {
          get 
          {
              int Result = DataAccess.GetIntScalarVal("spSelectIsProfilePagePublicOrPrivate");

              if (Result != 0)
                  return true;
              else
                  return false; 
          }
      }

      /// <summary>
      /// Configure profile page either public or private.
      /// </summary>
      public static int ConfigureProfilePage(int TheValue)
      {
          SqlParameter prmVal = new SqlParameter("@Value", SqlDbType.Int, 4);
          prmVal.Value = TheValue;

          return DataAccess.Execute("spInsertIsProfilePagePublicOrPrivate", prmVal);
      }

      #endregion

#region Private Message

      /// <summary>
      /// Insert private message
      /// </summary>
      public static int InsertPrivateMessage(PrivateMessage pm)
      {
          SqlParameter prmSubject = new SqlParameter("@Subject", SqlDbType.VarChar, 100);
          prmSubject.Value = pm.Subject;

          SqlParameter prmSenderUserID = new SqlParameter("@FromUserID", SqlDbType.Int, 4);
          prmSenderUserID.Value = pm.SenderUserID;

          SqlParameter prmLyricUserName = new SqlParameter("@ToUserName", SqlDbType.VarChar, 50);
          prmLyricUserName.Value = pm.LyricUserName;

          SqlParameter prmMessage = new SqlParameter("@Message", SqlDbType.VarChar, 4000);
          prmMessage.Value = pm.Message;

          return DataAccess.Execute("spInsertPrivateMessage", prmSubject, prmSenderUserID, prmLyricUserName, prmMessage);
      }

      /// <summary>
      /// Returns users Private Messages
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsersPrivateMessages(string Folder, int UserID, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmFolder = new SqlParameter("@folder", SqlDbType.VarChar, 20);
          prmFolder.Value = Folder;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectPrivateMessages", prmFolder, prmUserID, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns users Read Private Message
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersReadPrivateMessage(int PMID, int UserID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectReadPrivateMessage", prmPMID, prmUserID);
      }

      /// <summary>
      /// Returns users sent Read Private Message
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersReadSentPrivateMessage(int PMID, int UserID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectReadSentPrivateMessage", prmPMID, prmUserID);
      }

      /// <summary>
      /// Delete a private message
      /// </summary>
      public static int DeletePrivateMessage(PrivateMessage pm)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = pm.LyricUserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = pm.ID;

          return DataAccess.Execute("spDeletePrivateMessage", prmUserID, prmID);
      }

      /// <summary>
      /// Move private message to trash
      /// </summary>
        public static int MovePMToTrash(int UserID, int ID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.Execute("spMovePMToTrash", prmUserID, prmID);
      }

      /// <summary>
      /// Move private message back to inbox
      /// </summary>
        public static int MovePMBackToInbox(int UserID, int ID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.Execute("spMovePMBackToInbox", prmUserID, prmID);
      }

      /// <summary>
      /// Delete user sent private message
      /// </summary>
      public static int DeleteSentPrivateMessage(PrivateMessage pm)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = pm.SenderUserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = pm.ID;

          return DataAccess.Execute("spDeletePrivateMessageSent", prmUserID, prmID);
      }

      /// <summary>
      /// Mark message Unread or Read
      /// </summary>
      public static int MarkMessageUnreadOrRead(int UserID, int ID, int NewVal)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          SqlParameter prmNewVal = new SqlParameter("@Val", SqlDbType.Int, 4);
          prmNewVal.Value = NewVal;

          return DataAccess.Execute("spUpdateMarkPMUnreadOrRead", prmUserID, prmID, prmNewVal);
      }

      /// <summary>
      /// Returns user sent PM count
      /// </summary>
      /// <returns></returns>
      public static int CountUserSentPM(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountSentPM", prmUserID);
      }

      /// <summary>
      /// Returns Private Message Statistic
      /// </summary>
      /// <returns></returns>
      public IDataReader GetPrivateMessageStatistic
      {
          get { return DataAccess.GetFromReader("spSelectPrivateMessageStatistic"); }
      }

      /// <summary>
      /// Returns user PM new message count.
      /// </summary>
      public static int GetUserNewPrivateMessageCount(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectUserNewPrivateMessage", prmUserID);
      }

      /// <summary>
      /// Returns user PM count in trash by userID
      /// </summary>
        public static int GetPMinTrashByUserID(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountPMinTrashByUserID", prmUserID);
      }

      /// <summary>
      /// Validate user when reading Private Message. This ensure that this user cannot read other user PM.
      /// </summary>
        public static bool IsPMOwner(int PMID, int UserID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          int Result = DataAccess.GetInt32("spSelectPMReadingMsgValidation", prmPMID, prmUserID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Validate user when reading sent Private Message. This ensure that this user cannot read other user sent PM.
      /// </summary>
      public static bool IsPMOwnerSentMsg(int PMID, int UserID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          int Result = DataAccess.GetInt32("spSelectPMReadingSentMsgValidation", prmPMID, prmUserID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Return PM Message BY PMID.
      /// </summary>
      public static string GetPMMessage(int PMID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          return DataAccess.GetString("spSelectPrivateMessageByPMID", prmPMID);
      }

      /// <summary>
      /// Mark PM as an old image through AJAX.
      /// </summary>
      /// <returns></returns>
      public IDataReader MarkPMasOldMsgViaAjax(int PMID, int UserID)
      {
          SqlParameter prmPMID = new SqlParameter("@PMID", SqlDbType.Int, 4);
          prmPMID.Value = PMID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spUpdateMarkedPMOldMsgViaAJAX", prmPMID, prmUserID);
      }

      /// <summary>
      /// Update is user receive PM
      /// </summary>
      public static int UpdateReceivePM(int UserID, int NewVal)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewVal = new SqlParameter("@NewVal", SqlDbType.Int, 4);
          prmNewVal.Value = NewVal;

          return DataAccess.Execute("spUpdateUserReceivePM", prmUserID, prmNewVal);
      }

      /// <summary>
      /// Update is user receive PM
      /// </summary>
        public static int UpdateReceivePMEmailAlert(int UserID, int NewVal)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNewVal = new SqlParameter("@NewVal", SqlDbType.Int, 4);
          prmNewVal.Value = NewVal;

          return DataAccess.Execute("spUpdateUserReceivePMEmailAlert", prmUserID, prmNewVal);
      }

      /// <summary>
      /// Get all block listed users by userID
      /// </summary>
      /// <returns></returns>
        public IDataReader ShowAllPMBlockedUsersByUserID(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectShowAllPMBlockedUsersByUserID", prmUserID);
      }

      /// <summary>
      /// Insert user to be block from sending a private message.
      /// </summary>
        public static int InsertPMBlockedUser(int UserID, int BlockedUID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmBlockedUID = new SqlParameter("@BlockedUID", SqlDbType.Int, 4);
          prmBlockedUID.Value = BlockedUID;

          return DataAccess.Execute("spInsertPMBlockedUser", prmUserID, prmBlockedUID);
      }

      /// <summary>
      /// Remove user from private message block list.
      /// </summary>
        public static int RemovedUserFromPMBlockedList(int ID, int UserID)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.Execute("spRemovedUserFromPMBlockedList", prmID, prmUserID);
      }

      /// <summary>
      /// Check wheter sender userID is being blocked by recipient.
      /// </summary>
        public static bool IsUserBlockedByLyric(string ToUserName, int FromUserID)
      {
          SqlParameter prmToUserName = new SqlParameter("@ToUsername", SqlDbType.VarChar, 50);
          prmToUserName.Value = ToUserName;

          SqlParameter prmFromUserID = new SqlParameter("@FromUserID", SqlDbType.Int, 4);
          prmFromUserID.Value = FromUserID;

          int Result = DataAccess.GetInt32("spSelectIsUserBlockedFromSendingPM", prmToUserName, prmFromUserID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Returns Private Message blocklisted users by UserID
      /// </summary>
      public static int CountPMBlocklistedUsers(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountPMBlocklistedUsers", prmUserID);
      }

      /// <summary>
      /// Check if user is already blocked.
      /// </summary>
      public static bool IsUserBlocked(int UserID, int BlockedUID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmBlockedUID = new SqlParameter("@BlockedUID", SqlDbType.Int, 4);
          prmBlockedUID.Value = BlockedUID;

          int Result = DataAccess.GetInt32("spSelectCheckIfUserAlreadyBlocked", prmUserID, prmBlockedUID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Delete all messages in trash
      /// </summary>
        public static int DeleteAllPMInTrash(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.Execute("spDeleteAllPMInTrash", prmUserID);
      }
#endregion

#region Events Calendar

      /// <summary>
      /// Returns upcoming 30 days public events
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUpComingMonthPublicEvents(string EventType)
        {
            SqlParameter prmEventType = new SqlParameter("@EventType", SqlDbType.VarChar, 50);
            prmEventType.Value = EventType;

            return DataAccess.GetFromReader("spSelectUpComingPublicEvents", prmEventType);
        }

      /// <summary>
      /// Returns past 30 days public events
      /// </summary>
      /// <returns></returns>
        public IDataReader GetPastPublicEvents(string EventType)
        {
            SqlParameter prmEventType = new SqlParameter("@EventType", SqlDbType.VarChar, 50);
            prmEventType.Value = EventType;

            return DataAccess.GetFromReader("spSelectPastPublicEvents", prmEventType);
        }

      /// <summary>
      /// Returns all public events for calendar view
      /// </summary>
      /// <returns></returns>
        public DataTable GetAllPublicEventsCalendar(DateTime StartDate, DateTime EndDate, string EventType)
      {
          SqlParameter prmStartDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
          prmStartDate.Value = StartDate;

          SqlParameter prmEndDate = new SqlParameter("@EndDate", SqlDbType.DateTime);
          prmEndDate.Value = EndDate;

          SqlParameter prmEventType = new SqlParameter("@EventType", SqlDbType.VarChar, 50);
          prmEventType.Value = EventType;

          return DataAccess.GetFromDataTable("spSelectAllPublicEvents", prmStartDate, prmEndDate, prmEventType);
      }

      /// <summary>
      /// Returns public events week view.
      /// </summary>
      /// <returns></returns>
      public IDataReader PublicEventWeekView(DateTime startDate, string EventType)
      {
          SqlParameter prmstartDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
          prmstartDate.Value = startDate;

          SqlParameter prmEventType = new SqlParameter("@EventType", SqlDbType.VarChar, 50);
          prmEventType.Value = EventType;

          return DataAccess.GetFromReader("spSelectEventWeekView", prmstartDate, prmEventType);
      }

      /// <summary>
      /// Returns event week view begin and end date
      /// </summary>
      /// <returns></returns>
        public IDataReader EventWeekViewBeginAndEndDate(int Year, int WeekNumber)
      {
          SqlParameter prmYear = new SqlParameter("@Year", SqlDbType.Int, 4);
          prmYear.Value = Year;

          SqlParameter prmWeekNumber = new SqlParameter("@WeekNumber", SqlDbType.Int, 4);
          prmWeekNumber.Value = WeekNumber;

          return DataAccess.GetFromReader("spSelectEventWeekViewBeginAndEndDate", prmYear, prmWeekNumber);
      }

      /// <summary>
      /// Returns public event details
      /// </summary>
        public IDataReader GetPublicEventDetails(int ID)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.GetFromReader("spSelectGetPublicEventDetails", prmID);
      }

#endregion

#region Friends List

      /// <summary>
      /// Add a new friend to the users friend list.
      /// </summary>
      public static bool IsFriendExists(int UserID, int FriendID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmFriendID = new SqlParameter("@FriendID", SqlDbType.Int, 4);
          prmFriendID.Value = FriendID;

          int Result = DataAccess.GetInt32("spCheckIfFrienExistsInFriendsList", prmUserID, prmFriendID);

          if (Result != 0)
              return true;
          else
              return false;
      }

      /// <summary>
      /// Add a new friend to the users friend list.
      /// </summary>
      public static int AddNewFriend(int UserID, int FriendID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmFriendID = new SqlParameter("@FriendID", SqlDbType.Int, 4);
          prmFriendID.Value = FriendID;

          return DataAccess.Execute("spInsertAFriendToFriendsList", prmUserID, prmFriendID);
      }

      /// <summary>
      /// Add a new friend to the users friend list.
      /// </summary>
      public static int DeleteFriend(int UserID, int FriendID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmFriendID = new SqlParameter("@FriendID", SqlDbType.Int, 4);
          prmFriendID.Value = FriendID;

          return DataAccess.Execute("spDeleteAFriendInFriendsList", prmUserID, prmFriendID);
      }

      /// <summary>
      /// Returns users Friends List main page.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsersFriendsListMain(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectFriendsListMainPage", prmUserID);
      }

      /// <summary>
      /// Returns users Friends List Quick View for profile page.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersFriendsList(int UserID, int NumRecords)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNumRecords = new SqlParameter("@NumRecords", SqlDbType.Int, 4);
          prmNumRecords.Value = NumRecords;

          return DataAccess.GetFromReader("spSelectFriendsList", prmUserID, prmNumRecords);
      }

      /// <summary>
      /// Returns a list of users who added me in Friends List
      /// </summary>
      public IDataReader GetUsersWhoAddMeInFriendsList(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectWhoAddsMeInFriendsList", prmUserID);
      }

      /// <summary>
      /// Returns the number of user who add me in ther Friends List
      /// </summary>
      /// <returns></returns>
      public static int GetCountUserWhoAddMeInFriendsList(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountUserWhoAddMeInFriendsList", prmUserID);
      }

      /// <summary>
      /// Returns the number of users who saved my published Lyric in the Cook Book.
      /// </summary>
      /// <returns></returns>
        public static int GetCountUsersWhoSavedMyLyricInFavorite(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountUsersWhoSavedMyLyricInFavorite", prmUserID);
      }

      /// <summary>
      /// Returns count of unapproved new friends
      /// </summary>
        public static int GetCountUnApprovedFriends(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetInt32("spSelectCountUnApprovedFriends", prmUserID);
      }

      /// <summary>
      /// Aprrove a new friend
      /// </summary>
        public static int ApprovedAFriend(int UserID, int ID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.Execute("spUdateApprovedAFriend", prmUserID, prmID);
      }

      /// <summary>
      /// Delete unpprove new friend
      /// </summary>
        public static int DeleteUnApprovedFriends(int UserID, int ID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.Execute("spDeleteUnApprovedFriends", prmUserID, prmID);
      }

      /// <summary>
      /// Returns the list of unprroved new friends
      /// </summary>
        public IDataReader GetNewFriendsWaitingForApproval(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectNewFriendsWaitingForApproval", prmUserID);
      }

#endregion

#region CookBook
      /// <summary>
      /// Insert user favorite Lyric to the cookbook
      /// </summary>
      /// <returns></returns>
      public static int InsertLyricToFavorite(int UserID, int LyricID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmLyricID = new SqlParameter("@RecipeID", SqlDbType.Int, 4);
          prmLyricID.Value = LyricID;

          return DataAccess.Execute("spInsertFavoriteLyricToFavorite", prmUserID, prmLyricID);
      }

      /// <summary>
      /// Returns Top 10 users saved lyrics in the CookBook for profile page.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetUsersLyricInFavorite(int UserID, int NumRecords)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmNumRecords = new SqlParameter("@NumRecords", SqlDbType.Int, 4);
          prmNumRecords.Value = NumRecords;

          return DataAccess.GetFromReader("spSelectUsersLyricInFavorite", prmUserID, prmNumRecords);
      }

      /// <summary>
      /// Returns lyric in users CookBook main page.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersCookBook(int UserID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          return DataAccess.GetFromReader("spSelectUsersCookBook", prmUserID);
      }

      /// <summary>
      /// Returns lyric in users CookBook main page.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetUsersCookBookMain(int UserID, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectUsersCookBookMain", prmUserID, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Delete individual user lyric in CookBook
      /// </summary>
      public static int DeleteIndividualLyricInFavorite(int UserID, int ID)
      {
          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = UserID;

          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.Execute("spDeleteUserLyricInFavorite", prmUserID, prmID);
      }

      /// <summary>
      /// Returns top 25 lyric saved by users published by me.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetViewUsersLyricSavedPublishedByMe(int PublisherID, int UserIDWhoSaved)
      {
          SqlParameter prmPublisherID = new SqlParameter("@PublisherID", SqlDbType.Int, 4);
          prmPublisherID.Value = PublisherID;

          SqlParameter prmUserIDWhoSaved = new SqlParameter("@UserIDWhoSaved", SqlDbType.Int, 4);
          prmUserIDWhoSaved.Value = UserIDWhoSaved;

          return DataAccess.GetFromReader("spSelectViewUsersLyricSavedPublishedByMe", prmPublisherID, prmUserIDWhoSaved);
      }

      #endregion

#region Get category, A-Z lyricname, sort and search with Custom Paging
      /// <summary>
      /// Returns Category with custom paging
      /// </summary>
      /// <param name="SectionName">Section Name</param>
      /// <param name="Category">Category</param>
      /// <returns></returns>
        public IDataReader GetLyricCategoryWithCustomPaging(int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetLyricCategory", prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns A-Z lyric name with custom paging
      /// </summary>
      /// <param name="SectionName">Section Name</param>
      /// <param name="Category">A-Z lyric</param>
      /// <returns></returns>
        public IDataReader GetLyricAlphaLetterWithPaging(string Letter, int OrderBy, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.Char, 1);
          prmLetter.Value = Letter;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetLyricFirstAlphaLetterName", prmLetter, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns Sorted Lyric.
      /// </summary>
      /// <returns></returns>
        public IDataReader GetSortLyricPage(int Sid, int SortBy, int PageIndex, int PageSize)
      {
          SqlParameter prmSid = new SqlParameter("@Sid", SqlDbType.Int, 4);
          prmSid.Value = Sid;

          SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
          prmSortBy.Value = SortBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetSortingLyric", prmSid, prmSortBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns search result
      /// </summary>
        public IDataReader GetSearchResult(string Search, int CatId, int OrderBy, int PageIndex, int PageSize)
      {
          SqlParameter prmSearch = new SqlParameter("@Search", SqlDbType.NVarChar, 20);
          prmSearch.Value = Search;

          SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("GetSearchResult", prmSearch, prmCatId, prmOrderBy, prmPageIndex, prmPageSize);
      }


      /// <summary>
      /// Returns all Lyric submitted by user
      /// </summary>
      public IDataReader GetAllLyricSubmittedByUser(string AuthorName, int OrderBy, int PageIndex, int PageSize)
      {
          SqlParameter prmAuthorName = new SqlParameter("@FindByAuthor", SqlDbType.VarChar, 20);
          prmAuthorName.Value = AuthorName;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectGetAllLyricByUser", prmAuthorName, prmOrderBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns all Lyric submitted by user
      /// </summary>
      public IDataReader GetAllLyricCommentedByUser(string AuthorName, int OrderBy, int PageIndex, int PageSize)
      {
          SqlParameter prmAuthorName = new SqlParameter("@CommentsByAuthor ", SqlDbType.VarChar, 20);
          prmAuthorName.Value = AuthorName;

          SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
          prmOrderBy.Value = OrderBy;

          SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
          prmPageIndex.Value = PageIndex;

          SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
          prmPageSize.Value = PageSize;

          return DataAccess.GetFromReader("spSelectGetAllLyricCommentByUser", prmAuthorName, prmOrderBy, prmPageIndex, prmPageSize);
      }

      /// <summary>
      /// Returns top 15 Most Popular Lyrics in the side menu.
      /// </summary>
      /// <returns></returns>
      public IDataReader GetMostpopularLyricsSideMenu(int CatId, int Top)
      {
          SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
          prmCatId.Value = CatId;

          SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
          prmTop.Value = Top;

          return DataAccess.GetFromReader("GetTopLyricsSideMenu", prmCatId, prmTop);
      }

#endregion 

#region Article Comments - Add, select, delete and update
      /// <summary>
      /// Insert article comments
      /// </summary>
      /// <returns></returns>
      public int InsertArticleComment(Comment comment)
      {
          SqlParameter prmCommentID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmCommentID.Value = comment.ID;

          SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
          prmAuthor.Value = comment.Author;

          SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
          prmEmail.Value = comment.Email;

          SqlParameter prmComment = new SqlParameter("@Comments", SqlDbType.VarChar, 350);
          prmComment.Value = comment.Comments;

          SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
          prmUserID.Value = comment.UID;

          return DataAccess.Execute("spInsertArticleComment", prmCommentID, prmAuthor, prmEmail, prmComment, prmUserID);
      }

      /// <summary>
      /// Update article comment
      /// </summary>
      /// <returns></returns>
      public int UpdateArticleComment(Comment comment)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = comment.ID;

          SqlParameter prmComment = new SqlParameter("@Comment", SqlDbType.VarChar, 350);
          prmComment.Value = comment.Comments;

          return DataAccess.Execute("UpdateArticleComments", prmID, prmComment);
      }

      /// <summary>
      /// Delete individual article comment
      /// </summary>
      /// <returns></returns>
      public int DeleteArticleComment(Comment comment)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = comment.ID;

          SqlParameter prmAID = new SqlParameter("@AID", SqlDbType.Int, 4);
          prmAID.Value = comment.RECID;

          return DataAccess.Execute("AdminDeleteArticleComments", prmID, prmAID);
      }

      /// <summary>
      /// Delete multiple/batch article comment
      /// </summary>
      /// <returns></returns>
      public int DeleteMultipleArticleComment(string CsvID, string CsvItemID)
      {
          SqlParameter prmCsvID = new SqlParameter("@CsvID", SqlDbType.VarChar, 1000);
          prmCsvID.Value = CsvID;

          SqlParameter prmCsvItemID = new SqlParameter("@CsvItemID", SqlDbType.VarChar, 1000);
          prmCsvItemID.Value = CsvItemID;

          return DataAccess.Execute("AdminDeleteArticleComments", prmCsvID, prmCsvItemID);
      }

      /// <summary>
      /// Returns an article comments
      /// </summary>
      public IDataReader GetArticleComments(int ID)
      {
          SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
          prmID.Value = ID;

          return DataAccess.GetFromReader("spSelectCommentArticle", prmID);
      }

      /// <summary>
      /// Show or Hide article comment
      /// </summary>
      /// <returns></returns>
        public static int UpdateArticleCommentConfiguration(int Val)
      {
          SqlParameter prmVal = new SqlParameter("@Val", SqlDbType.Int, 4);
          prmVal.Value = Val;

          return DataAccess.Execute("spUpdateArticleCommentConfiguration", prmVal);
      }

#endregion

#region Return counter - int32 Scalar value

      /// <summary>
      /// Returns UserID from username
      /// </summary>
      public static int GetUserIDByUsername(string UserName)
      {
          SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
          prmUserName.Value = UserName;

          return DataAccess.GetInt32("spSelectGetUserIDByUsername", prmUserName);
      }

      /// <summary>
      /// Returns category Lyric count
      /// </summary>
      /// <param name="CategoryID">Category ID</param>
      /// <returns></returns>
       public int CategoryCount(int CatId)
       {
           SqlParameter prmCatId = new SqlParameter("@CatId", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           return DataAccess.GetInt32("CategoryPage_GetLyricsCount", prmCatId);
       }

       /// <summary>
       /// Returns Article Comments Count
       /// </summary>
       /// <returns></returns>
        public static int CountAllArticleComments
       {
           get { return DataAccess.GetIntScalarVal("spCountAllArticleComments"); }
       }

       /// <summary>
       /// Returns Article Count
       /// </summary>
       /// <returns></returns>
       public int ArticleCountAll
       {
           get { return DataAccess.GetIntScalarVal("ArticleCountAll"); }
       }

      /// <summary>
      /// Returns total category count
      /// </summary>
      /// <returns></returns>
       public int GetHomepageTotalCategoryCount
       {
           get { return DataAccess.GetIntScalarVal("GetHompageTotalCategoryCount"); }
       }

       /// <summary>
       /// Returns total Lyric count
       /// </summary>
       /// <returns></returns>
       public int GetHomepageTotalLyricCount
       {
           get { return DataAccess.GetIntScalarVal("GetCountTotalLyrics"); }
       }

       /// <summary>
       /// Returns total comments count
       /// </summary>
       /// <returns></returns>
       public int AdminLyricManagerGetTotalComments
       {
           get { return DataAccess.GetIntScalarVal("GetTotalCommentsCount"); }
       }

       /// <summary>
       /// Returns admin Lyric manager waiting for approval Lyric count
       /// </summary>
       /// <returns></returns>
       public int AdminLyricManagerGetWaitingforApprovalCount
       {
           get { return DataAccess.GetIntScalarVal("GetUnApprovedLyricCount"); }
       }
#endregion

#region Get article details, Update hit counter, Get Category list, Add, Update and Delete Article

       /// <summary>
       /// Returns article category list.
       /// </summary>
       /// <returns></returns>
       public IDataReader GetArticleCategoryList
       {
           get { return DataAccess.GetFromReader("GetArticleCategoryList"); }
       }

       /// <summary>
       /// Returns 10 newest cooking articles in the right side panel.
       /// </summary>
       /// <returns></returns>
        public IDataReader GetNewestArticleSidePanel(int Top)
       {
           SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
           prmTop.Value = Top;

           return DataAccess.GetFromReader("GetNewestArticleSidePanel", prmTop); 
       }

       /// <summary>
       /// Returns Article Category
       /// </summary>
        public IDataReader GetArticlesInCategory(int CATID, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CATID;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("GetCategoryArticle", prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

       /// <summary>
       /// Returns top 10 articles submitted by author/user
       /// </summary>
        public IDataReader GetTop10OtherArticlesByThisAuthor(int UserID, int AID)
       {
           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = UserID;

           SqlParameter prmAID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmAID.Value = AID;

           return DataAccess.GetFromReader("spSelectOtherArticlesByThisAuthor", prmUserID, prmAID);
       }

       /// <summary>
       /// Returns 10 related articles
       /// </summary>
        public IDataReader GetRelatedArticle(int CatID, int AID)
       {
           SqlParameter prmCatId = new SqlParameter("@CatID", SqlDbType.Int, 4);
           prmCatId.Value = CatID;

           SqlParameter prmAID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmAID.Value = AID;

           return DataAccess.GetFromReader("spSelectRelatedArticle", prmCatId, prmAID);
       }

       /// <summary>
       /// Returns IDataReader Article Category
       /// </summary>
       public IDataReader GetArticleCategory(int CATID, int OrderBy)
       {
           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CATID;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           return DataAccess.GetFromReader("CategoryPage_Article", prmCatId, prmOrderBy);
       }

       /// <summary>
       /// Returns article category name
       /// </summary>
       /// <returns></returns>
       public string GetArticleCategoryName(int CAT_ID)
       {
           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = CAT_ID;

           return DataAccess.GetString("GetArticleCategoryName", prmCatID);
       }

       /// <summary>
       /// Update article rating
       /// </summary>
       /// <returns></returns>
       public static int AddArticleRating(int ID, int Rating)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmRating = new SqlParameter("@Rating", SqlDbType.Int, 4);
           prmRating.Value = Rating;

           return DataAccess.Execute("AddArticleRating", prmID, prmRating);
       }

       /// <summary>
       /// Insert article
       /// </summary>
       /// <returns></returns>
       public int AddArticle(article article)
       {
           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = article.UID;

           SqlParameter prmTitle = new SqlParameter("@Title", SqlDbType.VarChar, 200);
           prmTitle.Value = article.Title;

           SqlParameter prmContent = new SqlParameter("@Content", SqlDbType.NText);
           prmContent.Value = article.Content;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = article.Author;

           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = article.CatID;

           SqlParameter prmKeyword = new SqlParameter("@Keyword", SqlDbType.VarChar, 255);
           prmKeyword.Value = article.Keyword;

           SqlParameter prmSummary = new SqlParameter("@Summary", SqlDbType.VarChar, 500);
           prmSummary.Value = article.Summary;

           return DataAccess.Execute("spInsertArticle", prmUserID, prmTitle, prmContent, prmAuthor, prmCatID, prmKeyword, prmSummary);

       }

       /// <summary>
       /// Update a users article
       /// </summary>
       /// <returns></returns>
        public int UpdateArticle(article article)
       {
           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = article.UID;

           SqlParameter prmID = new SqlParameter("@AID", SqlDbType.Int, 4);
           prmID.Value = article.ID;

           SqlParameter prmTitle = new SqlParameter("@Title", SqlDbType.VarChar, 200);
           prmTitle.Value = article.Title;

           SqlParameter prmContent = new SqlParameter("@Content", SqlDbType.VarChar, 8000);
           prmContent.Value = article.Content;

           SqlParameter prmCatID = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatID.Value = article.CatID;

           SqlParameter prmKeyword = new SqlParameter("@Keyword", SqlDbType.VarChar, 100);
           prmKeyword.Value = article.Keyword;

           SqlParameter prmSummary = new SqlParameter("@Summary", SqlDbType.VarChar, 500);
           prmSummary.Value = article.Summary;

           return DataAccess.Execute("spUpdateArticle", prmUserID, prmID, prmTitle, prmContent, prmCatID, prmKeyword, prmSummary);
       }

       /// <summary>
       /// Finalize Insert article
       /// </summary>
       /// <returns></returns>
       public int FinalizeAddArticle(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("FinalizeArticleSubmission", prmID);
       }

       /// <summary>
       /// Returns last submitted article ID
       /// </summary>
       /// <returns></returns>
       public IDataReader GetLastArticleID
       {
           get { return DataAccess.GetFromReader("GetLastArticleID"); }
       }

       /// <summary>
       /// Admin Lyric Manager Delete Lyric
       /// </summary>
       /// <returns></returns>
        public int AdminDeleteArticle(article article)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = article.ID;

           return DataAccess.Execute("ArticleDelete", prmID);
       }

       /// <summary>
       /// Returns article search result
       /// </summary>
        public IDataReader GetArticleSearchResult(string Search, int CatId, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmSearch = new SqlParameter("@Search", SqlDbType.VarChar, 20);
           prmSearch.Value = Search;

           SqlParameter prmCatId = new SqlParameter("@CATID", SqlDbType.Int, 4);
           prmCatId.Value = CatId;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("GetArticleSearchResult", prmSearch, prmCatId, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

       /// <summary>
       /// Returns all article submitted by an author/user.
       /// </summary>
       public IDataReader GetAllArticleByAuthor(string Author, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmAuthor = new SqlParameter("@FindByAuthor", SqlDbType.VarChar, 20);
           prmAuthor.Value = Author;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("spSelectAllArticleByUser", prmAuthor, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

       /// <summary>
       /// Returns all article commented by user.
       /// </summary>
       public IDataReader GetAllArticleCommentedByUser(string Author, int OrderBy, int SortBy, int PageIndex, int PageSize)
       {
           SqlParameter prmAuthor = new SqlParameter("@FindByAuthor", SqlDbType.VarChar, 20);
           prmAuthor.Value = Author;

           SqlParameter prmOrderBy = new SqlParameter("@OrderBy", SqlDbType.Int, 4);
           prmOrderBy.Value = OrderBy;

           SqlParameter prmSortBy = new SqlParameter("@SortBy", SqlDbType.Int, 4);
           prmSortBy.Value = SortBy;

           SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
           prmPageIndex.Value = PageIndex;

           SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
           prmPageSize.Value = PageSize;

           return DataAccess.GetFromReader("spSelectGetUserArticleCommentByUser", prmAuthor, prmOrderBy, prmSortBy, prmPageIndex, prmPageSize);
       }

#endregion

#region Admin Lyric Manager return Lyric, approve, update, delete and configuration
       /// <summary>
       /// Returns Admin Lyric Manager for Datagrid
       /// </summary>
       /// <returns></returns>
        public DataTable AdminLyricManagerWithCustomPaging(int CAT_ID, string Letter, string Find, int Tab, int Top, int Year, int Month, int LyricImage, int LastViewed, int PageIndex, int PageSize)
        {
            SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
            prmCatId.Value = CAT_ID;

            SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.VarChar, 10);
            prmLetter.Value = Letter;

            SqlParameter prmFind = new SqlParameter("@Find", SqlDbType.VarChar, 50);
            prmFind.Value = Find;

            SqlParameter prmTab = new SqlParameter("@Tab", SqlDbType.Int, 4);
            prmTab.Value = Tab;

            SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
            prmTop.Value = Top;

            SqlParameter prmYear = new SqlParameter("@Year", SqlDbType.Int, 4);
            prmYear.Value = Year;

            SqlParameter prmMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
            prmMonth.Value = Month;

            SqlParameter prmLyricImage = new SqlParameter("@LyricImage", SqlDbType.Int, 4);
            prmLyricImage.Value = LyricImage;

            SqlParameter prmLastViewed = new SqlParameter("@LastViewed", SqlDbType.Int, 4);
            prmLastViewed.Value = LastViewed;

            SqlParameter prmPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int, 4);
            prmPageIndex.Value = PageIndex;

            SqlParameter prmPageSize = new SqlParameter("@PageSize", SqlDbType.Int, 4);
            prmPageSize.Value = PageSize;

            return DataAccess.GetFromDataTable("AdminManagerGetLyric", prmCatId, prmLetter, prmFind, prmTab, prmTop, prmYear, prmMonth, prmLyricImage, prmLastViewed, prmPageIndex, prmPageSize);
        }

       /// <summary>
       /// Returns Datagrid Admin Lyric Manager
       /// </summary>
       /// <returns></returns>
       public IDataReader AdminLyricManager(int CAT_ID, string Letter, string Find, int Tab, int Top, int Year, int Month)
       {
           SqlParameter prmCatId = new SqlParameter("@CAT_ID", SqlDbType.Int, 4);
           prmCatId.Value = CAT_ID;

           SqlParameter prmLetter = new SqlParameter("@Letter", SqlDbType.VarChar, 10);
           prmLetter.Value = Letter;

           SqlParameter prmFind = new SqlParameter("@Find", SqlDbType.VarChar, 50);
           prmFind.Value = Find;

           SqlParameter prmTab = new SqlParameter("@Tab", SqlDbType.Int, 4);
           prmTab.Value = Tab;

           SqlParameter prmTop = new SqlParameter("@Top", SqlDbType.Int, 4);
           prmTop.Value = Top;

           SqlParameter prmYear = new SqlParameter("@Year", SqlDbType.Int, 4);
           prmYear.Value = Year;

           SqlParameter prmMonth = new SqlParameter("@Month", SqlDbType.Int, 4);
           prmMonth.Value = Month;

           return DataAccess.GetFromReader("AdminManagerGetLyric", prmCatId, prmLetter, prmFind, prmTab, prmTop, prmYear, prmMonth);
       }

       /// <summary>
       /// Admin Update Email Address and SMTP Server Address
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateEmailAndSMTPAddress(string Email, string SMTP)
       {
           SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 100);
           prmEmail.Value = Email;

           SqlParameter prmSMTP = new SqlParameter("@SMTP", SqlDbType.VarChar, 50);
           prmSMTP.Value = SMTP;

           return DataAccess.Execute("AdminUpdateEmailAndSMTPAddress", prmEmail, prmSMTP);
       }

       /// <summary>
       /// Admin Lyric Manager Delete Lyric
       /// </summary>
       /// <returns></returns>
        public int AdminLyricManagerDelete(Lyric lyric)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = lyric.ID;

           return DataAccess.Execute("AdminManagerDeleteLyric", prmID);
       }

       /// <summary>
       /// Approve Lyric
       /// </summary>
       /// <returns></returns>
       public int AdminApproveLyric(int ID)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           return DataAccess.Execute("AdminApproveLyric", prmID);
       }

       /// <summary>
       /// Update last viewed hour span
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateLastViewedHours(int Minutes)
       {
           SqlParameter prmMinutes = new SqlParameter("@Minutes", SqlDbType.Int, 4);
           prmMinutes.Value = Minutes;

           return DataAccess.Execute("AdminUpdateLastViewedHours", prmMinutes);
       }

       /// <summary>
       /// Configure show hide comment
       /// </summary>
       /// <returns></returns>
       public int AdminUpdateShowHideComment(int Showhide)
       {
           SqlParameter prmShowhide = new SqlParameter("@Showhide", SqlDbType.Int, 4);
           prmShowhide.Value = Showhide;

           return DataAccess.Execute("AdminUpdateShowHideComment", prmShowhide);
       }

       /// <summary>
       /// Update Lyric
       /// </summary>
       /// <returns></returns>
        public int UpdateLyric(Lyric lyric)
       {
           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = lyric.UID;

           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = lyric.ID;

           SqlParameter prmName = new SqlParameter("@Name", SqlDbType.NVarChar, 200);
           prmName.Value = lyric.LyricName;

           SqlParameter prmCatId = new SqlParameter("@Cat_Id", SqlDbType.Int, 4);
           prmCatId.Value = lyric.CatID;

           SqlParameter prmIngred = new SqlParameter("@Ingredients", SqlDbType.NText);
           prmIngred.Value = lyric.Ingredients;

           SqlParameter prmInstruc = new SqlParameter("@Instructions", SqlDbType.NText);
           prmInstruc.Value = lyric.Instructions;

           SqlParameter prmHits = new SqlParameter("@Hits", SqlDbType.Int, 4);
           prmHits.Value = lyric.Hits;

           SqlParameter prmLyricImage = new SqlParameter("@LyricImage", SqlDbType.NVarChar, 50);
           prmLyricImage.Value = lyric.LyricImage;

           return DataAccess.Execute("spUpdateLyric", prmUserID, prmID, prmName, prmCatId, prmIngred, prmInstruc, prmHits, prmLyricImage);

       }
#endregion

#region Admin Update, Delete Lyric Comment
       /// <summary>
       /// Update Lyric Comment
       /// </summary>
       /// <returns></returns>
        public int UpdateLyricComments(Comment comment)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = comment.ID;

           SqlParameter prmComment = new SqlParameter("@Comment", SqlDbType.VarChar, 350);
           prmComment.Value = comment.Comments;

           return DataAccess.Execute("UpdateLyricComments", prmID, prmComment);
       }

       /// <summary>
       /// Delete Lyric Comment
       /// </summary>
       /// <returns></returns>
        public int AdminDeleteLyricComments(Comment comment)
       {
           SqlParameter prmID = new SqlParameter("@COMID", SqlDbType.Int, 4);
           prmID.Value = comment.ID;

           SqlParameter prmLyricID = new SqlParameter("@RecipeID", SqlDbType.Int, 4);
           prmLyricID.Value = comment.RECID;

           return DataAccess.Execute("AdminDeleteLyricComments", prmID, prmLyricID);
       }

       /// <summary>
       /// Delete multiple/batch Lyric comment
       /// </summary>
       /// <returns></returns>
        public static int DeleteMultipleLyricComment(string CsvID, string CsvItemID)
       {
           SqlParameter prmCsvID = new SqlParameter("@CsvID", SqlDbType.VarChar, 1000);
           prmCsvID.Value = CsvID;

           SqlParameter prmCsvItemID = new SqlParameter("@CsvItemID", SqlDbType.VarChar, 1000);
           prmCsvItemID.Value = CsvItemID;

           return DataAccess.Execute("spDeleteMultipleLyricComment", prmCsvID, prmCsvItemID);
       }

#endregion

#region Admin Update, Delete Lyric Category
       /// <summary>
       /// Update Lyric Category
       /// </summary>
       /// <returns></returns>
        public int UpdateLyricCategory(Lyric category)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = category.CatID;

           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.NVarChar, 100);
           prmCatName.Value = category.Category;

           return DataAccess.Execute("UpdateLyricCategory", prmCatId, prmCatName);
       }

       /// <summary>
       /// Delete Lyric Category
       /// </summary>
       /// <returns></returns>
        public int AdminDeleteLyricCategory(Lyric category)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = category.CatID;

           return DataAccess.Execute("AdminDeleteLyricCategory", prmCatId);
       }

       /// <summary>
       /// Add New Lyric Category
       /// </summary>
       /// <returns></returns>
        public int AdminAddNewLyricCategory(Lyric category)
       {
           SqlParameter prmCategoryName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCategoryName.Value = category.Category;

           SqlParameter prmGroupID = new SqlParameter("@Group", SqlDbType.Int, 4);
           prmGroupID.Value = category.CatGroupID;

           return DataAccess.Execute("AdminAddNewLyricCategory", prmCategoryName, prmGroupID);
       }
#endregion

#region Admin Update, Delete Article Category
       /// <summary>
       /// Update Lyric Comment
       /// </summary>
       /// <returns></returns>
        public int UpdateArticleCategory(article category)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = category.CatID;

           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.NVarChar, 100);
           prmCatName.Value = category.Category;

           return DataAccess.Execute("UpdateArticleCategory", prmCatId, prmCatName);
       }

       /// <summary>
       /// Delete Article Category
       /// </summary>
       /// <returns></returns>
        public int AdminDeleteArticleCategory(article category)
       {
           SqlParameter prmCatId = new SqlParameter("@Catid", SqlDbType.Int, 4);
           prmCatId.Value = category.CatID;

           return DataAccess.Execute("AdminDeleteArticleCategory", prmCatId);
       }

       /// <summary>
       /// Add New Article Category
       /// </summary>
       /// <returns></returns>
       public int AdminAddNewArticleCategory(article category)
       {
           SqlParameter prmCatName = new SqlParameter("@CatName", SqlDbType.VarChar, 100);
           prmCatName.Value = category.Category;

           return DataAccess.Execute("AdminAddNewArticleCategory", prmCatName);
       }

#endregion

#region Admin Username and Password Validation

       /// <summary>
       /// Validate Admin Login Credential
       /// </summary>
       public static bool ValidateAdminLogin(string UserName, string Paswword)
       {
           SqlParameter prmUserName = new SqlParameter("@Username", SqlDbType.VarChar, 50);
           prmUserName.Value = UserName;

           SqlParameter prmPaswword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 50);
           prmPaswword.Value = Paswword;

           int Result = DataAccess.GetInt32("spSelectAdminUserLogin", prmUserName, prmPaswword);

           if (Result != 0)
               return true;
           else
               return false;
       }
#endregion

#region Front-end Add Lyric, Add Comment and Add Rating
       /// <summary>
       /// Insert Lyric
       /// </summary>
       /// <returns></returns>
       public int AddLyric(Lyric lyric)
       {
           SqlParameter prmName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
           prmName.Value = lyric.LyricName;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
           prmAuthor.Value = lyric.Author;

           SqlParameter prmCatID = new SqlParameter("@Cat_Id", SqlDbType.Int, 4);
           prmCatID.Value = lyric.CatID;

           SqlParameter prmIngred = new SqlParameter("@Ingredients", SqlDbType.NText);
           prmIngred.Value = lyric.Ingredients;

           SqlParameter prmInstruct = new SqlParameter("@Instructions", SqlDbType.NText);
           prmInstruct.Value = lyric.Instructions;

           SqlParameter prmLyricImage = new SqlParameter("@LyricImage", SqlDbType.NVarChar, 50);
           prmLyricImage.Value = lyric.LyricImage;

           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = lyric.UID;

           return DataAccess.Execute("spAddLyric", prmName, prmAuthor, prmCatID, prmIngred, prmInstruct, prmLyricImage, prmUserID);
       }

       /// <summary>
       /// Insert Lyric comments
       /// </summary>
       /// <returns></returns>
        public int AddComment(Comment comment)
       {
           SqlParameter prmCommentID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmCommentID.Value = comment.ID;

           SqlParameter prmAuthor = new SqlParameter("@Author", SqlDbType.VarChar, 50);
           prmAuthor.Value = comment.Author;

           SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
           prmEmail.Value = comment.Email;

           SqlParameter prmComment = new SqlParameter("@Comments", SqlDbType.NVarChar, 350);
           prmComment.Value = comment.Comments;

           SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
           prmUserID.Value = comment.UID;

           return DataAccess.Execute("AddComments", prmCommentID, prmAuthor, prmEmail, prmComment, prmUserID);
       }

       /// <summary>
       /// Insert Lyric rating
       /// </summary>
       /// <returns></returns>
       public static int AddRating(int ID, int Rating)
       {
           SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int, 4);
           prmID.Value = ID;

           SqlParameter prmRating = new SqlParameter("@Rating", SqlDbType.VarChar, 50);
           prmRating.Value = Rating;

           return DataAccess.Execute("AddRating", prmID, prmRating);

       }
#endregion

   }
}