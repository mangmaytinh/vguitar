#region XD World Lyric V 2.8
// FileName: BaseRecipeObj.cs
// Author: Dexter Zafra
// Date Created: 6/29/2008
// Website: www.ex-designz.net
#endregion
using System;
using VGuitar.Common;
using VGuitar.Model;

namespace VGuitar.BL
{
    /// <summary>
    /// Object in this class manages Lyric CRUD database methods.
    /// </summary>
    public abstract class BaseLyricObj : Lyric, IRepository
    {
        #region class members
            public virtual int Add(Lyric recipe) { return 0; } //Insert to database
            public virtual int Update(Lyric recipe) { return 0; } //Update to database
            public virtual int Delete(Lyric recipe) { return 0; } //Delete from database
            public virtual int AddCategory(Lyric category) { return 0; } //Insert to database
            public virtual int UpdateCategory(Lyric category) { return 0; } //Update to database
            public virtual int DeleteCategory(Lyric category) { return 0; } //Delete from database
            public virtual void FillUp(int ID) { } //Fill up database fields
        #endregion

        #region Interface Contract Implementation - overload methods
            public virtual int Add() { return 0; } //Insert to database
            public virtual int Update() { return 0; } //Update to database
            public virtual int Delete() { return 0; } //Delete from database
            public virtual void FillUp() { } //Fill up database fields
        #endregion
    }
}

