   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvc_User.generate.cs
 * CreateTime : 2017-10-11 14:28:02
 * CodeGenerateVersion : 1.0.0.0
 * TemplateVersion: 2.0.0
 * E_Mail : zhj.pavel@gmail.com
 * Blog : 
 * Copyright (C) YXH
 * 
 ***************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Winner.Framework.Core.DataAccess.Oracle;
using AppVersionControl.Entities;

namespace AppVersionControl.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Tvc_User : DataAccessBase
	{
		#region 构造和基本
		public Tvc_User():base()
		{}
		public Tvc_User(DataRow dataRow):base(dataRow)
		{}
		public const string _USER_ID = "USER_ID";
		public const string _USER_CODE = "USER_CODE";
		public const string _USER_NAME = "USER_NAME";
		public const string _CREATETIME = "CREATETIME";
		public const string _TableName = "TVC_USER";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVC_USER");
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_USER_NAME,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int User_Id
		{
			get{ return Convert.ToInt32(DataRow[_USER_ID]);}
			 set{setProperty(_USER_ID, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 20Byte
		/// </para>
		/// </summary>
		public string User_Code
		{
			get{ return DataRow[_USER_CODE].ToString();}
			 set{setProperty(_USER_CODE, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 40Byte
		/// </para>
		/// </summary>
		public string User_Name
		{
			get{ return DataRow[_USER_NAME].ToString();}
			 set{setProperty(_USER_NAME, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Createtime
		{
			get{ return Convert.ToDateTime(DataRow[_CREATETIME]);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT USER_ID,USER_CODE,USER_NAME,CREATETIME FROM TVC_USER WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVC_USER WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int user_id)
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,user_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.User_Id = GetSequence("SELECT SEQ_TVC_USER.nextval FROM DUAL");
			string sql = @"INSERT INTO TVC_USER(USER_ID,USER_CODE,USER_NAME)
			VALUES (:USER_ID,:USER_CODE,:USER_NAME)";
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_USER_CODE,DataRow[_USER_CODE]);
			AddParameter(_USER_NAME,DataRow[_USER_NAME]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvc_UserCollection.Field,object> alterDic,Dictionary<Tvc_UserCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvc_UserCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvc_UserCollection.Field key in conditionDic.Keys)
            {
                object value = conditionDic[key];
                string name = key.ToString();
				if (alterDic.Keys.Contains(key))
                {
                    name = string.Concat("condition_", key);
                }
                sql.Append(key).Append("=:").Append(name).Append(" and ");
                AddParameter(name, value);
            }
            int len = " and ".Length;
            sql.Remove(sql.Length - len, len);//移除最后一个and
            return UpdateBySql(sql.ToString());
		}
		protected bool UpdateByCondition(string condition)
		{
			ChangePropertys.Remove(_USER_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVC_USER SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE USER_ID=:USER_ID");
			AddParameter(_USER_ID, DataRow[_USER_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByUserCode(string user_code)
		{
			string condition = " USER_CODE=:USER_CODE";
			AddParameter(_USER_CODE,user_code);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int user_id)
		{
			string condition = " USER_ID=:USER_ID";
			AddParameter(_USER_ID,user_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tvc_UserCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvc_UserCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvc_User().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvc_User(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvc_User._TableName;}
		}
		public Tvc_User this[int index]
        {
            get { return new Tvc_User(DataTable.Rows[index]); }
        }
		public enum Field
        {
			User_Id=0,
			User_Code=1,
			User_Name=2,
			Createtime=3,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT USER_ID,USER_CODE,USER_NAME,CREATETIME FROM TVC_USER WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvc_User Find(Predicate<Tvc_User> match)
        {
            foreach (Tvc_User item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvc_UserCollection FindAll(Predicate<Tvc_User> match)
        {
            Tvc_UserCollection list = new Tvc_UserCollection();
            foreach (Tvc_User item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvc_User> match)
        {
            foreach (Tvc_User item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvc_User> match)
        {
            BeginTransaction();
            foreach (Tvc_User item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
		#endregion
		#endregion		
	}
}