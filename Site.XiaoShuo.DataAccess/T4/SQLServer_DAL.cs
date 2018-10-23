

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using System.Configuration;
using Site.XiaoShuo.DataAccess.Model;

namespace Site.XiaoShuo.DataAccess.Access
{


	[Serializable]
	public partial class ChapterListAccess : AccessBasePartial<ChapterList>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableNameFormat;
		protected override string DataTableNameFormat
		{
			get { return _dataTableNameFormat; }
			set { _dataTableNameFormat = value; }
		}
		
        

        #region 00 IDisposable 实现
        public ChapterListAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableNameFormat = "ChapterList_T_{0}";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public ChapterListAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableNameFormat = "ChapterList_T_{0}";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~ChapterListAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ChapterList_Insert
		 public override int Insert(ChapterList obj,int tableIndex)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@F_ID", DbType.Int32,obj.F_ID);
			db.AddInParameter(dbCmd, "@ChapterName", DbType.String,obj.ChapterName);
			db.AddInParameter(dbCmd, "@ChapterIndex", DbType.String,obj.ChapterIndex);
			db.AddInParameter(dbCmd, "@ChapterContent", DbType.String,obj.ChapterContent);
			db.AddInParameter(dbCmd, "@UpdateTime", DbType.DateTime,obj.UpdateTime);
			db.AddInParameter(dbCmd, "@ChapterSort", DbType.Int32,obj.ChapterSort);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_ChapterList_Delete
		 public override int Delete(int id,int tableIndex)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_ChapterList_Update
		 public override int Update(ChapterList obj,int tableIndex)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@F_ID", DbType.Int32,obj.F_ID);
			db.AddInParameter(dbCmd, "@ChapterName", DbType.String,obj.ChapterName);
			db.AddInParameter(dbCmd, "@ChapterIndex", DbType.String,obj.ChapterIndex);
			db.AddInParameter(dbCmd, "@ChapterContent", DbType.String,obj.ChapterContent);
			db.AddInParameter(dbCmd, "@UpdateTime", DbType.DateTime,obj.UpdateTime);
			db.AddInParameter(dbCmd, "@ChapterSort", DbType.Int32,obj.ChapterSort);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_ChapterList_SelectObject
		 public override ChapterList SelectObject(int id,int tableIndex)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
			
			ChapterList obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_ChapterList_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ChapterList> Select(string whereStr,int tableIndex)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
						IList<ChapterList> list= new List<ChapterList>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ChapterList obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_ChapterList_SelectPage
		 public override IList<ChapterList> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, int tableIndex,out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterList_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			db.AddInParameter(dbCmd, "@TableIndex", DbType.Int32,tableIndex);
			
			List<ChapterList> list= new List<ChapterList>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ChapterList obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public ChapterList Object2Model(IDataReader reader)
        {
            ChapterList obj = null;
            try
            {
                obj = new ChapterList();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.F_ID = reader["F_ID"] == DBNull.Value ? default(int) : (int)reader["F_ID"];
				obj.ChapterName = reader["ChapterName"] == DBNull.Value ? default(string) : (string)reader["ChapterName"];
				obj.ChapterIndex = reader["ChapterIndex"] == DBNull.Value ? default(string) : (string)reader["ChapterIndex"];
				obj.ChapterContent = reader["ChapterContent"] == DBNull.Value ? default(string) : (string)reader["ChapterContent"];
				obj.UpdateTime = reader["UpdateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["UpdateTime"];
				obj.ChapterSort = reader["ChapterSort"] == DBNull.Value ? default(int) : (int)reader["ChapterSort"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class ChapterVisitsAccess : AccessBase<ChapterVisits>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public ChapterVisitsAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "ChapterVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public ChapterVisitsAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableName = "ChapterVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~ChapterVisitsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ChapterVisits_Insert
		 public override int Insert(ChapterVisits obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@IP", DbType.String,obj.IP);
			db.AddInParameter(dbCmd, "@OS", DbType.String,obj.OS);
			db.AddInParameter(dbCmd, "@Browser", DbType.String,obj.Browser);
			db.AddInParameter(dbCmd, "@Url", DbType.String,obj.Url);
			db.AddInParameter(dbCmd, "@Time", DbType.DateTime,obj.Time);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_ChapterVisits_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_ChapterVisits_Update
		 public override int Update(ChapterVisits obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@IP", DbType.String,obj.IP);
			db.AddInParameter(dbCmd, "@OS", DbType.String,obj.OS);
			db.AddInParameter(dbCmd, "@Browser", DbType.String,obj.Browser);
			db.AddInParameter(dbCmd, "@Url", DbType.String,obj.Url);
			db.AddInParameter(dbCmd, "@Time", DbType.DateTime,obj.Time);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_ChapterVisits_SelectObject
		 public override ChapterVisits SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			ChapterVisits obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_ChapterVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ChapterVisits> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<ChapterVisits> list= new List<ChapterVisits>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ChapterVisits obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_ChapterVisits_SelectPage
		 public override IList<ChapterVisits> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ChapterVisits_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<ChapterVisits> list= new List<ChapterVisits>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ChapterVisits obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public ChapterVisits Object2Model(IDataReader reader)
        {
            ChapterVisits obj = null;
            try
            {
                obj = new ChapterVisits();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.IP = reader["IP"] == DBNull.Value ? default(string) : (string)reader["IP"];
				obj.OS = reader["OS"] == DBNull.Value ? default(string) : (string)reader["OS"];
				obj.Browser = reader["Browser"] == DBNull.Value ? default(string) : (string)reader["Browser"];
				obj.Url = reader["Url"] == DBNull.Value ? default(string) : (string)reader["Url"];
				obj.Time = reader["Time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["Time"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class ContentCateAccess : AccessBase<ContentCate>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public ContentCateAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "ContentCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public ContentCateAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableName = "ContentCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~ContentCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ContentCate_Insert
		 public override int Insert(ContentCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@CateName", DbType.String,obj.CateName);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_ContentCate_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_ContentCate_Update
		 public override int Update(ContentCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@CateName", DbType.String,obj.CateName);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_ContentCate_SelectObject
		 public override ContentCate SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			ContentCate obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_ContentCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ContentCate> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<ContentCate> list= new List<ContentCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ContentCate obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_ContentCate_SelectPage
		 public override IList<ContentCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ContentCate_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<ContentCate> list= new List<ContentCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ContentCate obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public ContentCate Object2Model(IDataReader reader)
        {
            ContentCate obj = null;
            try
            {
                obj = new ContentCate();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.CateName = reader["CateName"] == DBNull.Value ? default(string) : (string)reader["CateName"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class ErrorChapterAccess : AccessBase<ErrorChapter>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public ErrorChapterAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "ErrorChapter";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public ErrorChapterAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableName = "ErrorChapter";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~ErrorChapterAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ErrorChapter_Insert
		 public override int Insert(ErrorChapter obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@F_Id", DbType.Int32,obj.F_Id);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@ChapterName", DbType.String,obj.ChapterName);
			db.AddInParameter(dbCmd, "@ChapterUrl", DbType.String,obj.ChapterUrl);
			db.AddInParameter(dbCmd, "@ExceptionMessage", DbType.String,obj.ExceptionMessage);
			db.AddInParameter(dbCmd, "@DisposeStatus", DbType.Int32,obj.DisposeStatus);
			db.AddInParameter(dbCmd, "@C_C_Id", DbType.Int32,obj.C_C_Id);
			db.AddInParameter(dbCmd, "@RetryCount", DbType.Int32,obj.RetryCount);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_ErrorChapter_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_ErrorChapter_Update
		 public override int Update(ErrorChapter obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@F_Id", DbType.Int32,obj.F_Id);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@ChapterName", DbType.String,obj.ChapterName);
			db.AddInParameter(dbCmd, "@ChapterUrl", DbType.String,obj.ChapterUrl);
			db.AddInParameter(dbCmd, "@ExceptionMessage", DbType.String,obj.ExceptionMessage);
			db.AddInParameter(dbCmd, "@DisposeStatus", DbType.Int32,obj.DisposeStatus);
			db.AddInParameter(dbCmd, "@C_C_Id", DbType.Int32,obj.C_C_Id);
			db.AddInParameter(dbCmd, "@RetryCount", DbType.Int32,obj.RetryCount);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_ErrorChapter_SelectObject
		 public override ErrorChapter SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			ErrorChapter obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_ErrorChapter_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ErrorChapter> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<ErrorChapter> list= new List<ErrorChapter>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ErrorChapter obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_ErrorChapter_SelectPage
		 public override IList<ErrorChapter> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ErrorChapter_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<ErrorChapter> list= new List<ErrorChapter>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ErrorChapter obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public ErrorChapter Object2Model(IDataReader reader)
        {
            ErrorChapter obj = null;
            try
            {
                obj = new ErrorChapter();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.F_Id = reader["F_Id"] == DBNull.Value ? default(int) : (int)reader["F_Id"];
				obj.Title = reader["Title"] == DBNull.Value ? default(string) : (string)reader["Title"];
				obj.ChapterName = reader["ChapterName"] == DBNull.Value ? default(string) : (string)reader["ChapterName"];
				obj.ChapterUrl = reader["ChapterUrl"] == DBNull.Value ? default(string) : (string)reader["ChapterUrl"];
				obj.ExceptionMessage = reader["ExceptionMessage"] == DBNull.Value ? default(string) : (string)reader["ExceptionMessage"];
				obj.DisposeStatus = reader["DisposeStatus"] == DBNull.Value ? default(int) : (int)reader["DisposeStatus"];
				obj.C_C_Id = reader["C_C_Id"] == DBNull.Value ? default(int) : (int)reader["C_C_Id"];
				obj.RetryCount = reader["RetryCount"] == DBNull.Value ? default(int) : (int)reader["RetryCount"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class FictionAccess : AccessBase<Fiction>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public FictionAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "Fiction";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public FictionAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableName = "Fiction";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~FictionAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Fiction_Insert
		 public override int Insert(Fiction obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@Author", DbType.String,obj.Author);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
			db.AddInParameter(dbCmd, "@CoverImage", DbType.String,obj.CoverImage);
			db.AddInParameter(dbCmd, "@C_C_ID", DbType.Int32,obj.C_C_ID);
			db.AddInParameter(dbCmd, "@LastUpdateChapter", DbType.String,obj.LastUpdateChapter);
			db.AddInParameter(dbCmd, "@LastUpdateTime", DbType.DateTime,obj.LastUpdateTime);
			db.AddInParameter(dbCmd, "@CompleteState", DbType.Int32,obj.CompleteState);
			db.AddInParameter(dbCmd, "@LastChapterId", DbType.String,obj.LastChapterId);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_Fiction_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_Fiction_Update
		 public override int Update(Fiction obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@Title", DbType.String,obj.Title);
			db.AddInParameter(dbCmd, "@Author", DbType.String,obj.Author);
			db.AddInParameter(dbCmd, "@Intro", DbType.String,obj.Intro);
			db.AddInParameter(dbCmd, "@CoverImage", DbType.String,obj.CoverImage);
			db.AddInParameter(dbCmd, "@C_C_ID", DbType.Int32,obj.C_C_ID);
			db.AddInParameter(dbCmd, "@LastUpdateChapter", DbType.String,obj.LastUpdateChapter);
			db.AddInParameter(dbCmd, "@LastUpdateTime", DbType.DateTime,obj.LastUpdateTime);
			db.AddInParameter(dbCmd, "@CompleteState", DbType.Int32,obj.CompleteState);
			db.AddInParameter(dbCmd, "@LastChapterId", DbType.String,obj.LastChapterId);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_Fiction_SelectObject
		 public override Fiction SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Fiction obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_Fiction_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<Fiction> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<Fiction> list= new List<Fiction>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Fiction obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_Fiction_SelectPage
		 public override IList<Fiction> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<Fiction> list= new List<Fiction>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Fiction obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public Fiction Object2Model(IDataReader reader)
        {
            Fiction obj = null;
            try
            {
                obj = new Fiction();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Title = reader["Title"] == DBNull.Value ? default(string) : (string)reader["Title"];
				obj.Author = reader["Author"] == DBNull.Value ? default(string) : (string)reader["Author"];
				obj.Intro = reader["Intro"] == DBNull.Value ? default(string) : (string)reader["Intro"];
				obj.CoverImage = reader["CoverImage"] == DBNull.Value ? default(string) : (string)reader["CoverImage"];
				obj.C_C_ID = reader["C_C_ID"] == DBNull.Value ? default(int) : (int)reader["C_C_ID"];
				obj.LastUpdateChapter = reader["LastUpdateChapter"] == DBNull.Value ? default(string) : (string)reader["LastUpdateChapter"];
				obj.LastUpdateTime = reader["LastUpdateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["LastUpdateTime"];
				obj.CompleteState = reader["CompleteState"] == DBNull.Value ? default(int) : (int)reader["CompleteState"];
				obj.LastChapterId = reader["LastChapterId"] == DBNull.Value ? default(string) : (string)reader["LastChapterId"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }

	[Serializable]
	public partial class FictionVisitsAccess : AccessBase<FictionVisits>,IDisposable
    {

		Database db;

		DatabaseProviderFactory factory = new DatabaseProviderFactory();//6.0 创建方式

		 private string _connectionStr;
        protected override string ConnectionStr
        {
            get { return _connectionStr; }
            set { _connectionStr = value; }
        }

		private string _dataTableName;
		protected override string DataTableName
		{
			get { return _dataTableName; }
			set { _dataTableName = value; }
		}
		
        

        #region 00 IDisposable 实现
        public FictionVisitsAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "FictionVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        public FictionVisitsAccess()
        {
            db = factory.Create("XiaoShuo");
			DataTableName = "FictionVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["XiaoShuo"].ToString();
        }

        //虚拟Idisposable 实现,手动调用的
        public void Dispose()
        {
            //调用方法，释放资源
            Dispose(true);
            //通知GC，已经手动调用，不用调用析构函数了
            System.GC.SuppressFinalize(this);
        }

        //重载方法，满足不同的调用，清理干净资源，提升性能
        /// <summary>
        /// true --手动调用，清理托管资源
        /// false--GC 调用，把非托管资源一起清理掉
        /// </summary>
        /// <param name="isDispose"></param>
        protected virtual void Dispose(bool isDispose)
        {
            if (isDispose)
            {

            }
            //清理非托管资源，此处没有，所以直接ruturn
            return;
        }

        //析构函数，供GC 调用
        ~FictionVisitsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_FictionVisits_Insert
		 public override int Insert(FictionVisits obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@F_Id", DbType.Int32,obj.F_Id);
			db.AddInParameter(dbCmd, "@Visits", DbType.Int32,obj.Visits);
			db.AddInParameter(dbCmd, "@C_Id", DbType.Int32,obj.C_Id);
						
				int returnValue = db.ExecuteNonQuery(dbCmd);
				int Id = (int)dbCmd.Parameters["@Id"].Value;
				return Id;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_FictionVisits_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_DeleteById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_FictionVisits_Update
		 public override int Update(FictionVisits obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@F_Id", DbType.Int32,obj.F_Id);
			db.AddInParameter(dbCmd, "@Visits", DbType.Int32,obj.Visits);
			db.AddInParameter(dbCmd, "@C_Id", DbType.Int32,obj.C_Id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_FictionVisits_SelectObject
		 public override FictionVisits SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			FictionVisits obj=null;
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_FictionVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<FictionVisits> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<FictionVisits> list= new List<FictionVisits>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						FictionVisits obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_FictionVisits_SelectPage
		 public override IList<FictionVisits> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<FictionVisits> list= new List<FictionVisits>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						FictionVisits obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层："+e.Message);
            }
		}
		#endregion


		#region Object2Model

        public FictionVisits Object2Model(IDataReader reader)
        {
            FictionVisits obj = null;
            try
            {
                obj = new FictionVisits();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.F_Id = reader["F_Id"] == DBNull.Value ? default(int) : (int)reader["F_Id"];
				obj.Visits = reader["Visits"] == DBNull.Value ? default(int) : (int)reader["Visits"];
				obj.C_Id = reader["C_Id"] == DBNull.Value ? default(int) : (int)reader["C_Id"];
				
            }
            catch(Exception ex)
            {
                obj = null;
            }
            return obj;
        }



        #endregion


    }
}
