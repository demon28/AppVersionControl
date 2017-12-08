   /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tvc_Tester.generate.cs
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
	public partial class Tvc_Tester : DataAccessBase
	{
		#region 构造和基本
		public Tvc_Tester():base()
		{}
		public Tvc_Tester(DataRow dataRow):base(dataRow)
		{}
		public const string _TESTER_ID = "TESTER_ID";
		public const string _APP_ID = "APP_ID";
		public const string _USER_ID = "USER_ID";
		public const string _VERSION_TYPE = "VERSION_TYPE";
		public const string _CREATETIME = "CREATETIME";
		public const string _REMARKS = "REMARKS";
		public const string _TableName = "TVC_TESTER";
		protected override DataRow BuildRow()
		{
			DataTable table = new DataTable("TVC_TESTER");
			table.Columns.Add(_TESTER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_APP_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_USER_ID,typeof(int)).DefaultValue=0;
			table.Columns.Add(_VERSION_TYPE,typeof(int)).DefaultValue=0;
			table.Columns.Add(_CREATETIME,typeof(DateTime)).DefaultValue=DateTime.Now;
			table.Columns.Add(_REMARKS,typeof(string)).DefaultValue=DBNull.Value;
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
		public int Tester_Id
		{
			get{ return Convert.ToInt32(DataRow[_TESTER_ID]);}
			 set{setProperty(_TESTER_ID, value);}
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
		/// defaultValue: 0;   Length: 22Byte
		/// </para>
		/// </summary>
		public int Version_Type
		{
			get{ return Convert.ToInt32(DataRow[_VERSION_TYPE]);}
			 set{setProperty(_VERSION_TYPE, value);}
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
		/// (可空)
		/// <para>
		/// defaultValue: DBNull.Value;   Length: 400Byte
		/// </para>
		/// </summary>
		public string Remarks
		{
			get{ return DataRow[_REMARKS].ToString();}
			 set{setProperty(_REMARKS, value);}
		}
		#endregion
		
		#region 基本方法
		protected bool SelectByCondition(string condition)
		{
			string sql = "SELECT TESTER_ID,APP_ID,USER_ID,VERSION_TYPE,CREATETIME,REMARKS FROM TVC_TESTER WHERE "+condition;
			return base.SelectBySql(sql);
		}
		protected bool DeleteByCondition(string condition)
		{
			string sql = "DELETE FROM TVC_TESTER WHERE "+condition;
			return base.DeleteBySql(sql);
		}
		
		public bool Delete(int tester_id)
		{
			string condition = " TESTER_ID=:TESTER_ID";
			AddParameter(_TESTER_ID,tester_id);
			return DeleteByCondition(condition);
		}
		public bool Delete()
		{
			string condition = " TESTER_ID=:TESTER_ID";
			AddParameter(_TESTER_ID,DataRow[_TESTER_ID]);
			return DeleteByCondition(condition);
		}
				
		public bool Insert()
		{		
			int id = this.Tester_Id = GetSequence("SELECT SEQ_TVC_TESTER.nextval FROM DUAL");
			string sql = @"INSERT INTO TVC_TESTER(TESTER_ID,APP_ID,USER_ID,VERSION_TYPE,REMARKS)
			VALUES (:TESTER_ID,:APP_ID,:USER_ID,:VERSION_TYPE,:REMARKS)";
			AddParameter(_TESTER_ID,DataRow[_TESTER_ID]);
			AddParameter(_APP_ID,DataRow[_APP_ID]);
			AddParameter(_USER_ID,DataRow[_USER_ID]);
			AddParameter(_VERSION_TYPE,DataRow[_VERSION_TYPE]);
			AddParameter(_REMARKS,DataRow[_REMARKS]);
			return InsertBySql(sql);
		}
		
		public bool Update()
		{
			return UpdateByCondition(string.Empty);
		}
		public bool Update(Dictionary<Tvc_TesterCollection.Field,object> alterDic,Dictionary<Tvc_TesterCollection.Field,object> conditionDic)
		{
			if (alterDic.Count <= 0)
                return false;
            if (conditionDic.Count <= 0)
                return false;
            StringBuilder sql = new StringBuilder();
            sql.Append("update ").Append(_TableName).Append(" set ");
            foreach (Tvc_TesterCollection.Field key in alterDic.Keys)
            {
                object value = alterDic[key];
                string name = key.ToString();
                sql.Append(name).Append("=:").Append(name).Append(",");
                AddParameter(name, value);
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            sql.Append(" where ");
            foreach (Tvc_TesterCollection.Field key in conditionDic.Keys)
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
			ChangePropertys.Remove(_TESTER_ID);
			if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TVC_TESTER SET");
			while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
			sql.Append(" WHERE TESTER_ID=:TESTER_ID");
			AddParameter(_TESTER_ID, DataRow[_TESTER_ID]);			
			if (!string.IsNullOrEmpty(condition))
            {
				sql.AppendLine(" AND " + condition);
			}
			bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
		}	
		public bool SelectByPk(int tester_id)
		{
			string condition = " TESTER_ID=:TESTER_ID";
			AddParameter(_TESTER_ID,tester_id);
			return SelectByCondition(condition);
		}
		#endregion
	}
	/// <summary>
	/// [集合对象]
	/// </summary>
	public partial class Tvc_TesterCollection : DataAccessCollectionBase
	{
		#region 构造和基本
		public Tvc_TesterCollection():base()
		{			
		}
		
		protected override DataTable BuildTable()
		{
			return new Tvc_Tester().CloneSchemaOfTable();
		}
		protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tvc_Tester(DataTable.Rows[index]);
        }
		protected override string TableName
		{
			get{return Tvc_Tester._TableName;}
		}
		public Tvc_Tester this[int index]
        {
            get { return new Tvc_Tester(DataTable.Rows[index]); }
        }
		public enum Field
        {
			Tester_Id=0,
			App_Id=1,
			User_Id=2,
			Version_Type=3,
			Createtime=4,
			Remarks=5,
		}
		#endregion
		#region 基本方法
		protected bool ListByCondition(string condition)
		{
			string sql = "SELECT TESTER_ID,APP_ID,USER_ID,VERSION_TYPE,CREATETIME,REMARKS FROM TVC_TESTER WHERE "+condition;
			return ListBySql(sql);
		}

		public bool ListByApp_Id(int app_id)
		{
			string condition = "APP_ID=:APP_ID ORDER BY TESTER_ID DESC";
			AddParameter(Tvc_Tester._APP_ID,app_id);
			return ListByCondition(condition);		
		}
		public bool ListByUser_Id(int user_id)
		{
			string condition = "USER_ID=:USER_ID ORDER BY TESTER_ID DESC";
			AddParameter(Tvc_Tester._USER_ID,user_id);
			return ListByCondition(condition);		
		}
		public bool ListAll()
		{
			string condition = " 1=1";
			return ListByCondition(condition);
		}
		#region Linq
		public Tvc_Tester Find(Predicate<Tvc_Tester> match)
        {
            foreach (Tvc_Tester item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tvc_TesterCollection FindAll(Predicate<Tvc_Tester> match)
        {
            Tvc_TesterCollection list = new Tvc_TesterCollection();
            foreach (Tvc_Tester item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tvc_Tester> match)
        {
            foreach (Tvc_Tester item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }
		public bool DeleteAt(Predicate<Tvc_Tester> match)
        {
            BeginTransaction();
            foreach (Tvc_Tester item in this)
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