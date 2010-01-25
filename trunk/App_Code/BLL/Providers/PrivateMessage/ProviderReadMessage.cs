#region XD World Lyric V 3
// FileName: ProviderReadMessage.cs
// Author: Dexter Zafra
// Date Created: 3/8/2009
// Website: www.ex-designz.net
#endregion
using System;
using System.Data;
using VGuitar.BL;
using VGuitar.Model;

namespace VGuitar.BL.Providers.PrivateMessages
{
    /// <summary>
    /// Object in this class return private message read details.
    /// </summary>
    public sealed class ProviderReadMessage : BasePMObj
    {
        public ProviderReadMessage()
        {
        }

        public override void FillUp(int ID, int UserID)
        {
            this._ID = ID;
            this._LyricUserID = UserID;

            IDataReader dr = Blogic.ActionProcedureDataProvider.GetUsersReadPrivateMessage(ID, LyricUserID);

            while (dr.Read())
            {
                if (dr["M_Subject"] != DBNull.Value)
                {
                    this._Subject = (string)dr["M_Subject"];
                }
                if (dr["PM_Message"] != DBNull.Value)
                {
                    this._Message = (string)dr["PM_Message"];
                }
                if (dr["M_From"] != DBNull.Value)
                {
                    this._SenderUserID = (int)dr["M_From"];
                }
                if (dr["UserName"] != DBNull.Value)
                {
                    this._SenderUserName = (string)dr["UserName"];
                }
                if (dr["M_Sent"] != DBNull.Value)
                {
                    this._DateSent = (DateTime)dr["M_Sent"];
                }
            }

            dr.Close();
        }
    }
}
