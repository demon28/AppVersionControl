   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvc_Version.generate.cs
 * CreateTime : 2017-11-22 18:30:49
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
	/// app版本记录
	/// </summary>
	public partial class Tvc_Version : DataAccessBase
	{
		#region 构造和基本
		public Tvc_Version():base()
		{}
		public Tvc_Version(DataRow dataRow):base(dataRow)
		{}
		public const string _DOWNLOAD_TIMES = "DOWNLOAD_TIMES";
		public const string _VERSION_ID = "VERSION_ID";
		public const string _APP_ID = "APP_ID";
		public const string _HASH_CODE = "HASH_CODE";
		public const string _DOWNLOAD_URL = "DOWNLOAD_URL";
		public const string _VERSION_CODE = "VERSION_CODE";
		public const string _VERSION_TYPE = "VERSION_TYPE";
		public const string _CREATE_TIME = "CREATE_TIME";
		public const string _RELEASE_NOTE = "RELEASE_NOTE";
		public const string _IS_FORCE_UPGRADE = "IS_FORCE_UPGRADE";
		public const string _IS_DEL = "IS_DEL";
		public const string _TableName = "TVC_VERSION";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVC_VERSION");
			table.Columns.Add(_DOWNLOAD_TIMES,typeof(int)).DefaultValue=0;
			table.Columns.Add(_VERSION_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_APP_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_HASH_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_DOWNLOAD_URL,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_VERSION_CODE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_VERSION_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATE_TIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_RELEASE_NOTE,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_IS_FORCE_UPGRADE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_IS_DEL,typeof(int)).DefaultValue=0;
			return table.NewRow();
		}
		#endregion
		
		#region 属性
		protected override string TableName
		{
			get{return _TableName;}
		}
		/// <summary>
		/// 下载次数(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Download_Times
		{
			get{ return Convert.ToInt32(DataRow[_DOWNLOAD_TIMES]);}
			 set{setProperty(_DOWNLOAD_TIMES, value);}
		}
		/// <summary>
		/// 版本ID(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Version_Id
		{
			get{ return Convert.ToInt32(DataRow[_VERSION_ID]);}
			 set{setProperty(_VERSION_ID, value);}
		}
		/// <summary>
		/// app编号(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int App_Id
		{
			get{ return Convert.ToInt32(DataRow[_APP_ID]);}
			 set{setProperty(_APP_ID, value);}
		}
		/// <summary>
		/// 文件hash值(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Hash_Code
		{
			get{ return DataRow[_HASH_CODE].ToString();}
			 set{setProperty(_HASH_CODE, value);}
		}
		/// <summary>
		/// 下载地址(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 200Byte
		/// </para>
		/// </summary>
		public string Download_Url
		{
			get{ return DataRow[_DOWNLOAD_URL].ToString();}
			 set{setProperty(_DOWNLOAD_URL, value);}
		}
		/// <summary>
		/// 版本号（0.0.0.0）(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 10Byte
		/// </para>
		/// </summary>
		public string Version_Code
		{
			get{ return DataRow[_VERSION_CODE].ToString();}
			 set{setProperty(_VERSION_CODE, value);}
		}
		/// <summary>
		/// 版本类型[1：beta，2：RC，4：Release](必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Version_Type
		{
			get{ return Convert.ToInt32(DataRow[_VERSION_TYPE]);}
			 set{setProperty(_VERSION_TYPE, value);}
		}
		/// <summary>
		/// 发布时间(必填)
		/// <para>
		/// defaultValue: DateTime.Now;   Length: 7Byte
		/// </para>
		/// </summary>
		public DateTime Create_Time
		{
			get{ return Convert.ToDateTime(DataRow[_CREATE_TIME]);}
			 set{setProperty(_CREATE_TIME, value);}
		}
		/// <summary>
		/// 发布内容(必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 4000Byte
		/// </para>
		/// </summary>
		public string Release_Note
		{
			get{ return DataRow[_RELEASE_NOTE].ToString();}
			 set{setProperty(_RELEASE_NOTE, value);}
		}
		/// <summary>
		/// 是否强制更新(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Force_Upgrade
		{
			get{ return Convert.ToInt32(DataRow[_IS_FORCE_UPGRADE]);}
			 set{setProperty(_IS_FORCE_UPGRADE, value);}
		}
		/// <summary>
		/// 是否已删除(必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Del
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEL]);}
			 set{setProperty(_IS_DEL, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT DOWNLOAD_TIMES,VERSION_ID,APP_ID,HASH_CODE,DOWNLOAD_URL,VERSION_CODE,VERSION_TYPE,CREATE_TIME,RELEASE_NOTE,IS_FORCE_UPGRADE,IS_DEL FROM TVC_VERSION WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVC_VERSION WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int version_id)
		{
			string condition = " VERSION_ID=:VERSION_ID";
			AddParameter(_VERSION_ID,version_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " VERSION_ID=:VERSION_ID";
			AddParameter(_VERSION_ID,DataRow[_VERSION_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Version_Id = GetSequence("SELECT SEQ_TVC_VERSION.nextval FROM DUAL");
			string sql = @"INSERT INTO TVC_VERSION(DOWNLOAD_TIMES,VERSION_ID,APP_ID,HASH_CODE,DOWNLOAD_URL,VERSION_CODE,VERSION_TYPE,RELEASE_NOTE,IS_FORCE_UPGRADE,IS_DEL)
			VALUES (:DOWNLOAD_TIMES,:VERSION_ID,:APP_ID,:HASH_CODE,:DOWNLOAD_URL,:VERSION_CODE,:VERSION_TYPE,:RELEASE_NOTE,:IS_FORCE_UPGRADE,:IS_DEL)";
			AddParameter(_DOWNLOAD_TIMES,DataRow[_DOWNLOAD_TIMES]);
			AddParameter(_VERSION_ID,DataRow[_VERSION_ID]);
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			AddParameter(_HASH_CODE,DataRow[_HASH_CODE]);
			AddParameter(_DOWNLOAD_URL,DataRow[_DOWNLOAD_URL]);
			AddParameter(_VERSION_CODE,DataRow[_VERSION_CODE]);
			AddParameter(_VERSION_TYPE,DataRow[_VERSION_TYPE]);
			AddParameter(_RELEASE_NOTE,DataRow[_RELEASE_NOTE]);
			AddParameter(_IS_FORCE_UPGRADE,DataRow[_IS_FORCE_UPGRADE]);
			AddParameter(_IS_DEL,DataRow[_IS_DEL]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvc_VersionCollection.Field,object> alterDic,Dictionary<Tvc_VersionCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvc_VersionCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvc_VersionCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_VERSION_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVC_VERSION SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE VERSION_ID=:VERSION_ID");
			AddParameter(_VERSION_ID, DataRow[_VERSION_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int version_id)
		{
			string condition = " VERSION_ID=:VERSION_ID";
			AddParameter(_VERSION_ID,version_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// app版本记录[集合对象]
	/// </summary>
	public partial class Tvc_VersionCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvc_VersionCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvc_Version().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvc_Version(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvc_Version._TableName;}
		}
		public Tvc_Version this[int index]
        {
            get { return new Tvc_Version(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Download_Times=0,
			Version_Id=1,
			App_Id=2,
			Hash_Code=3,
			Download_Url=4,
			Version_Code=5,
			Version_Type=6,
			Create_Time=7,
			Release_Note=8,
			Is_Force_Upgrade=9,
			Is_Del=10,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT DOWNLOAD_TIMES,VERSION_ID,APP_ID,HASH_CODE,DOWNLOAD_URL,VERSION_CODE,VERSION_TYPE,CREATE_TIME,RELEASE_NOTE,IS_FORCE_UPGRADE,IS_DEL FROM TVC_VERSION WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByApp_Id(int app_id)
		{
			string condition = "APP_ID=:APP_ID ORDER BY VERSION_ID DESC";
			AddParameter(Tvc_Version._APP_ID,app_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvc_Version Find(Predicate<Tvc_Version> match)
        {
            foreach (Tvc_Version item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvc_VersionCollection FindAll(Predicate<Tvc_Version> match)
        {
            Tvc_VersionCollection list = new Tvc_VersionCollection();
            foreach (Tvc_Version item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvc_Version> match)
        {
            foreach (Tvc_Version item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvc_Version> match)
        {
            BeginTransaction();
            foreach (Tvc_Version item in this)
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