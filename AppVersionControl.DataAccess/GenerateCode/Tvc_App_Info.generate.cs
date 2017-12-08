   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvc_App_Info.generate.cs
 * CreateTime : 2017-10-10 19:12:00
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
	public partial class Tvc_App_Info : DataAccessBase
	{
		#region 构造和基本
		public Tvc_App_Info():base()
		{}
		public Tvc_App_Info(DataRow dataRow):base(dataRow)
		{}
		public const string _SECRET_KEY = "SECRET_KEY";
		public const string _DOWNLOAD_URL = "DOWNLOAD_URL";
		public const string _CREATETIME = "CREATETIME";
		public const string _IS_DEL = "IS_DEL";
		public const string _APP_ID = "APP_ID";
		public const string _CN_NAME = "CN_NAME";
		public const string _EN_NAME = "EN_NAME";
		public const string _TableName = "TVC_APP_INFO";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVC_APP_INFO");
			table.Columns.Add(_SECRET_KEY,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_DOWNLOAD_URL,typeof(string)).DefaultValue=DBNull.Value;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_IS_DEL,typeof(int)).DefaultValue=0;
			table.Columns.Add(_APP_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CN_NAME,typeof(string)).DefaultValue=string.Empty;
			table.Columns.Add(_EN_NAME,typeof(string)).DefaultValue=string.Empty;
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
		/// defaultValue: string.Empty;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Secret_Key
		{
			get{ return DataRow[_SECRET_KEY].ToString();}
			 set{setProperty(_SECRET_KEY, value);}
		}
		/// <summary>
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Download_Url
		{
			get{ return DataRow[_DOWNLOAD_URL].ToString();}
			 set{setProperty(_DOWNLOAD_URL, value);}
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
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Is_Del
		{
			get{ return Convert.ToInt32(DataRow[_IS_DEL]);}
			 set{setProperty(_IS_DEL, value);}
		}
		/// <summary>
		/// (必填)
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
		/// (必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 100Byte
		/// </para>
		/// </summary>
		public string Cn_Name
		{
			get{ return DataRow[_CN_NAME].ToString();}
			 set{setProperty(_CN_NAME, value);}
		}
		/// <summary>
		/// (必填)
		/// <para>
		/// defaultValue: string.Empty;   Length: 50Byte
		/// </para>
		/// </summary>
		public string En_Name
		{
			get{ return DataRow[_EN_NAME].ToString();}
			 set{setProperty(_EN_NAME, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT SECRET_KEY,DOWNLOAD_URL,CREATETIME,IS_DEL,APP_ID,CN_NAME,EN_NAME FROM TVC_APP_INFO WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVC_APP_INFO WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int app_id)
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,app_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.App_Id = GetSequence("SELECT SEQ_TVC_APP_INFO.nextval FROM DUAL");
			string sql = @"INSERT INTO TVC_APP_INFO(SECRET_KEY,DOWNLOAD_URL,IS_DEL,APP_ID,CN_NAME,EN_NAME)
			VALUES (:SECRET_KEY,:DOWNLOAD_URL,:IS_DEL,:APP_ID,:CN_NAME,:EN_NAME)";
			AddParameter(_SECRET_KEY,DataRow[_SECRET_KEY]);
			AddParameter(_DOWNLOAD_URL,DataRow[_DOWNLOAD_URL]);
			AddParameter(_IS_DEL,DataRow[_IS_DEL]);
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			AddParameter(_CN_NAME,DataRow[_CN_NAME]);
			AddParameter(_EN_NAME,DataRow[_EN_NAME]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvc_App_InfoCollection.Field,object> alterDic,Dictionary<Tvc_App_InfoCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvc_App_InfoCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvc_App_InfoCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_APP_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVC_APP_INFO SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE APP_ID=:APP_ID");
			AddParameter(_APP_ID, DataRow[_APP_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByEnName(string en_name)
		{
			string condition = " EN_NAME=:EN_NAME";
			AddParameter(_EN_NAME,en_name);
			return SelectByCondition(condition);
		}
		public bool SelectByPk(int app_id)
		{
			string condition = " APP_ID=:APP_ID";
			AddParameter(_APP_ID,app_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tvc_App_InfoCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvc_App_InfoCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvc_App_Info().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvc_App_Info(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvc_App_Info._TableName;}
		}
		public Tvc_App_Info this[int index]
        {
            get { return new Tvc_App_Info(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Secret_Key=0,
			Download_Url=1,
			Createtime=2,
			Is_Del=3,
			App_Id=4,
			Cn_Name=5,
			En_Name=6,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT SECRET_KEY,DOWNLOAD_URL,CREATETIME,IS_DEL,APP_ID,CN_NAME,EN_NAME FROM TVC_APP_INFO WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvc_App_Info Find(Predicate<Tvc_App_Info> match)
        {
            foreach (Tvc_App_Info item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvc_App_InfoCollection FindAll(Predicate<Tvc_App_Info> match)
        {
            Tvc_App_InfoCollection list = new Tvc_App_InfoCollection();
            foreach (Tvc_App_Info item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvc_App_Info> match)
        {
            foreach (Tvc_App_Info item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvc_App_Info> match)
        {
            BeginTransaction();
            foreach (Tvc_App_Info item in this)
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