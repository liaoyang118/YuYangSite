

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
using Site.Videos.DataAccess.Model;

namespace Site.Videos.DataAccess.Access
{


	[Serializable]
	public partial class AdvertisingInfoAccess : AccessBase<AdvertisingInfo>,IDisposable
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
        public AdvertisingInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public AdvertisingInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~AdvertisingInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_AdvertisingInfo_Insert
		 public override int Insert(AdvertisingInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@a_id", DbType.String,obj.a_id);
			db.AddInParameter(dbCmd, "@a_name", DbType.String,obj.a_name);
			db.AddInParameter(dbCmd, "@a_type", DbType.Int32,obj.a_type);
			db.AddInParameter(dbCmd, "@a_src", DbType.String,obj.a_src);
			db.AddInParameter(dbCmd, "@a_second", DbType.Int32,obj.a_second);
			db.AddInParameter(dbCmd, "@a_status", DbType.Int32,obj.a_status);
						
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
		
		#region 02 Proc_AdvertisingInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_DeleteById");
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

		#region 03 Proc_AdvertisingInfo_Update
		 public override int Update(AdvertisingInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@a_id", DbType.String,obj.a_id);
			db.AddInParameter(dbCmd, "@a_name", DbType.String,obj.a_name);
			db.AddInParameter(dbCmd, "@a_type", DbType.Int32,obj.a_type);
			db.AddInParameter(dbCmd, "@a_src", DbType.String,obj.a_src);
			db.AddInParameter(dbCmd, "@a_second", DbType.Int32,obj.a_second);
			db.AddInParameter(dbCmd, "@a_status", DbType.Int32,obj.a_status);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_AdvertisingInfo_SelectObject
		 public override AdvertisingInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			AdvertisingInfo obj=null;
			
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

		#region 05 Proc_AdvertisingInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<AdvertisingInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<AdvertisingInfo> list= new List<AdvertisingInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						AdvertisingInfo obj= Object2Model(reader);
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

		#region 06 Proc_AdvertisingInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<AdvertisingInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_AdvertisingInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<AdvertisingInfo> list= new List<AdvertisingInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						AdvertisingInfo obj= Object2Model(reader);
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

        public AdvertisingInfo Object2Model(IDataReader reader)
        {
            AdvertisingInfo obj = null;
            try
            {
                obj = new AdvertisingInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.a_id = reader["a_id"] == DBNull.Value ? default(string) : (string)reader["a_id"];
				obj.a_name = reader["a_name"] == DBNull.Value ? default(string) : (string)reader["a_name"];
				obj.a_type = reader["a_type"] == DBNull.Value ? default(int) : (int)reader["a_type"];
				obj.a_src = reader["a_src"] == DBNull.Value ? default(string) : (string)reader["a_src"];
				obj.a_second = reader["a_second"] == DBNull.Value ? default(int) : (int)reader["a_second"];
				obj.a_status = reader["a_status"] == DBNull.Value ? default(int) : (int)reader["a_status"];
				
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
	public partial class ComboInfoAccess : AccessBase<ComboInfo>,IDisposable
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
        public ComboInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public ComboInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~ComboInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_ComboInfo_Insert
		 public override int Insert(ComboInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@c_id", DbType.String,obj.c_id);
			db.AddInParameter(dbCmd, "@c_title", DbType.String,obj.c_title);
			db.AddInParameter(dbCmd, "@c_intro", DbType.String,obj.c_intro);
			db.AddInParameter(dbCmd, "@c_num", DbType.Int32,obj.c_num);
			db.AddInParameter(dbCmd, "@c_days", DbType.Int32,obj.c_days);
			db.AddInParameter(dbCmd, "@c_status", DbType.Int32,obj.c_status);
						
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
		
		#region 02 Proc_ComboInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_DeleteById");
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

		#region 03 Proc_ComboInfo_Update
		 public override int Update(ComboInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@c_id", DbType.String,obj.c_id);
			db.AddInParameter(dbCmd, "@c_title", DbType.String,obj.c_title);
			db.AddInParameter(dbCmd, "@c_intro", DbType.String,obj.c_intro);
			db.AddInParameter(dbCmd, "@c_num", DbType.Int32,obj.c_num);
			db.AddInParameter(dbCmd, "@c_days", DbType.Int32,obj.c_days);
			db.AddInParameter(dbCmd, "@c_status", DbType.Int32,obj.c_status);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_ComboInfo_SelectObject
		 public override ComboInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			ComboInfo obj=null;
			
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

		#region 05 Proc_ComboInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ComboInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<ComboInfo> list= new List<ComboInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ComboInfo obj= Object2Model(reader);
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

		#region 06 Proc_ComboInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<ComboInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_ComboInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<ComboInfo> list= new List<ComboInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						ComboInfo obj= Object2Model(reader);
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

        public ComboInfo Object2Model(IDataReader reader)
        {
            ComboInfo obj = null;
            try
            {
                obj = new ComboInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.c_id = reader["c_id"] == DBNull.Value ? default(string) : (string)reader["c_id"];
				obj.c_title = reader["c_title"] == DBNull.Value ? default(string) : (string)reader["c_title"];
				obj.c_intro = reader["c_intro"] == DBNull.Value ? default(string) : (string)reader["c_intro"];
				obj.c_num = reader["c_num"] == DBNull.Value ? default(int) : (int)reader["c_num"];
				obj.c_days = reader["c_days"] == DBNull.Value ? default(int) : (int)reader["c_days"];
				obj.c_status = reader["c_status"] == DBNull.Value ? default(int) : (int)reader["c_status"];
				
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
	public partial class NoticeInfoAccess : AccessBase<NoticeInfo>,IDisposable
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
        public NoticeInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public NoticeInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~NoticeInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_NoticeInfo_Insert
		 public override int Insert(NoticeInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@n_id", DbType.String,obj.n_id);
			db.AddInParameter(dbCmd, "@n_title", DbType.String,obj.n_title);
			db.AddInParameter(dbCmd, "@n_content", DbType.String,obj.n_content);
			db.AddInParameter(dbCmd, "@n_beginTime", DbType.DateTime,obj.n_beginTime);
			db.AddInParameter(dbCmd, "@n_endTime", DbType.DateTime,obj.n_endTime);
			db.AddInParameter(dbCmd, "@n_status", DbType.Int32,obj.n_status);
			db.AddInParameter(dbCmd, "@n_createTime", DbType.DateTime,obj.n_createTime);
						
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
		
		#region 02 Proc_NoticeInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_DeleteById");
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

		#region 03 Proc_NoticeInfo_Update
		 public override int Update(NoticeInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@n_id", DbType.String,obj.n_id);
			db.AddInParameter(dbCmd, "@n_title", DbType.String,obj.n_title);
			db.AddInParameter(dbCmd, "@n_content", DbType.String,obj.n_content);
			db.AddInParameter(dbCmd, "@n_beginTime", DbType.DateTime,obj.n_beginTime);
			db.AddInParameter(dbCmd, "@n_endTime", DbType.DateTime,obj.n_endTime);
			db.AddInParameter(dbCmd, "@n_status", DbType.Int32,obj.n_status);
			db.AddInParameter(dbCmd, "@n_createTime", DbType.DateTime,obj.n_createTime);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_NoticeInfo_SelectObject
		 public override NoticeInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			NoticeInfo obj=null;
			
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

		#region 05 Proc_NoticeInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<NoticeInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<NoticeInfo> list= new List<NoticeInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						NoticeInfo obj= Object2Model(reader);
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

		#region 06 Proc_NoticeInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<NoticeInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_NoticeInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<NoticeInfo> list= new List<NoticeInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						NoticeInfo obj= Object2Model(reader);
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

        public NoticeInfo Object2Model(IDataReader reader)
        {
            NoticeInfo obj = null;
            try
            {
                obj = new NoticeInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.n_id = reader["n_id"] == DBNull.Value ? default(string) : (string)reader["n_id"];
				obj.n_title = reader["n_title"] == DBNull.Value ? default(string) : (string)reader["n_title"];
				obj.n_content = reader["n_content"] == DBNull.Value ? default(string) : (string)reader["n_content"];
				obj.n_beginTime = reader["n_beginTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["n_beginTime"];
				obj.n_endTime = reader["n_endTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["n_endTime"];
				obj.n_status = reader["n_status"] == DBNull.Value ? default(int) : (int)reader["n_status"];
				obj.n_createTime = reader["n_createTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["n_createTime"];
				
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
	public partial class RechargeRecoderAccess : AccessBase<RechargeRecoder>,IDisposable
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
        public RechargeRecoderAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public RechargeRecoderAccess()
        {
            db = factory.Create("Video");
			DataTableName = "RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~RechargeRecoderAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_RechargeRecoder_Insert
		 public override int Insert(RechargeRecoder obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@r_id", DbType.String,obj.r_id);
			db.AddInParameter(dbCmd, "@r_u_id", DbType.String,obj.r_u_id);
			db.AddInParameter(dbCmd, "@r_c_id", DbType.String,obj.r_c_id);
			db.AddInParameter(dbCmd, "@r_c_title", DbType.String,obj.r_c_title);
			db.AddInParameter(dbCmd, "@r_money", DbType.Decimal,obj.r_money);
			db.AddInParameter(dbCmd, "@r_c_days", DbType.Int32,obj.r_c_days);
			db.AddInParameter(dbCmd, "@r_createTime", DbType.DateTime,obj.r_createTime);
			db.AddInParameter(dbCmd, "@r_u_expriseTime", DbType.DateTime,obj.r_u_expriseTime);
						
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
		
		#region 02 Proc_RechargeRecoder_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_DeleteById");
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

		#region 03 Proc_RechargeRecoder_Update
		 public override int Update(RechargeRecoder obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@r_id", DbType.String,obj.r_id);
			db.AddInParameter(dbCmd, "@r_u_id", DbType.String,obj.r_u_id);
			db.AddInParameter(dbCmd, "@r_c_id", DbType.String,obj.r_c_id);
			db.AddInParameter(dbCmd, "@r_c_title", DbType.String,obj.r_c_title);
			db.AddInParameter(dbCmd, "@r_money", DbType.Decimal,obj.r_money);
			db.AddInParameter(dbCmd, "@r_c_days", DbType.Int32,obj.r_c_days);
			db.AddInParameter(dbCmd, "@r_createTime", DbType.DateTime,obj.r_createTime);
			db.AddInParameter(dbCmd, "@r_u_expriseTime", DbType.DateTime,obj.r_u_expriseTime);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_RechargeRecoder_SelectObject
		 public override RechargeRecoder SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			RechargeRecoder obj=null;
			
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

		#region 05 Proc_RechargeRecoder_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<RechargeRecoder> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<RechargeRecoder> list= new List<RechargeRecoder>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						RechargeRecoder obj= Object2Model(reader);
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

		#region 06 Proc_RechargeRecoder_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<RechargeRecoder> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_RechargeRecoder_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<RechargeRecoder> list= new List<RechargeRecoder>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						RechargeRecoder obj= Object2Model(reader);
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

        public RechargeRecoder Object2Model(IDataReader reader)
        {
            RechargeRecoder obj = null;
            try
            {
                obj = new RechargeRecoder();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.r_id = reader["r_id"] == DBNull.Value ? default(string) : (string)reader["r_id"];
				obj.r_u_id = reader["r_u_id"] == DBNull.Value ? default(string) : (string)reader["r_u_id"];
				obj.r_c_id = reader["r_c_id"] == DBNull.Value ? default(string) : (string)reader["r_c_id"];
				obj.r_c_title = reader["r_c_title"] == DBNull.Value ? default(string) : (string)reader["r_c_title"];
				obj.r_money = reader["r_money"] == DBNull.Value ? default(decimal) : (decimal)reader["r_money"];
				obj.r_c_days = reader["r_c_days"] == DBNull.Value ? default(int) : (int)reader["r_c_days"];
				obj.r_createTime = reader["r_createTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["r_createTime"];
				obj.r_u_expriseTime = reader["r_u_expriseTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["r_u_expriseTime"];
				
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
	public partial class UserInfoAccess : AccessBase<UserInfo>,IDisposable
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
        public UserInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public UserInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~UserInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_UserInfo_Insert
		 public override int Insert(UserInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@u_name", DbType.String,obj.u_name);
			db.AddInParameter(dbCmd, "@u_pwd", DbType.String,obj.u_pwd);
			db.AddInParameter(dbCmd, "@u_level", DbType.Int32,obj.u_level);
			db.AddInParameter(dbCmd, "@u_expriseTime", DbType.DateTime,obj.u_expriseTime);
			db.AddInParameter(dbCmd, "@u_regTime", DbType.DateTime,obj.u_regTime);
			db.AddInParameter(dbCmd, "@u_status", DbType.Int32,obj.u_status);
						
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
		
		#region 02 Proc_UserInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_DeleteById");
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

		#region 03 Proc_UserInfo_Update
		 public override int Update(UserInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@u_gid", DbType.String,obj.u_gid);
			db.AddInParameter(dbCmd, "@u_name", DbType.String,obj.u_name);
			db.AddInParameter(dbCmd, "@u_pwd", DbType.String,obj.u_pwd);
			db.AddInParameter(dbCmd, "@u_level", DbType.Int32,obj.u_level);
			db.AddInParameter(dbCmd, "@u_expriseTime", DbType.DateTime,obj.u_expriseTime);
			db.AddInParameter(dbCmd, "@u_regTime", DbType.DateTime,obj.u_regTime);
			db.AddInParameter(dbCmd, "@u_status", DbType.Int32,obj.u_status);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_UserInfo_SelectObject
		 public override UserInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			UserInfo obj=null;
			
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

		#region 05 Proc_UserInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<UserInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<UserInfo> list= new List<UserInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserInfo obj= Object2Model(reader);
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

		#region 06 Proc_UserInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<UserInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<UserInfo> list= new List<UserInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserInfo obj= Object2Model(reader);
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

        public UserInfo Object2Model(IDataReader reader)
        {
            UserInfo obj = null;
            try
            {
                obj = new UserInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.u_gid = reader["u_gid"] == DBNull.Value ? default(string) : (string)reader["u_gid"];
				obj.u_name = reader["u_name"] == DBNull.Value ? default(string) : (string)reader["u_name"];
				obj.u_pwd = reader["u_pwd"] == DBNull.Value ? default(string) : (string)reader["u_pwd"];
				obj.u_level = reader["u_level"] == DBNull.Value ? default(int) : (int)reader["u_level"];
				obj.u_expriseTime = reader["u_expriseTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["u_expriseTime"];
				obj.u_regTime = reader["u_regTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["u_regTime"];
				obj.u_status = reader["u_status"] == DBNull.Value ? default(int) : (int)reader["u_status"];
				
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
	public partial class UserVisitsInfoAccess : AccessBase<UserVisitsInfo>,IDisposable
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
        public UserVisitsInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public UserVisitsInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~UserVisitsInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_UserVisitsInfo_Insert
		 public override int Insert(UserVisitsInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@u_id", DbType.String,obj.u_id);
			db.AddInParameter(dbCmd, "@v_id", DbType.String,obj.v_id);
			db.AddInParameter(dbCmd, "@v_ip", DbType.String,obj.v_ip);
			db.AddInParameter(dbCmd, "@platform", DbType.String,obj.platform);
			db.AddInParameter(dbCmd, "@v_url", DbType.String,obj.v_url);
			db.AddInParameter(dbCmd, "@v_time", DbType.DateTime,obj.v_time);
						
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
		
		#region 02 Proc_UserVisitsInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_DeleteById");
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

		#region 03 Proc_UserVisitsInfo_Update
		 public override int Update(UserVisitsInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@u_id", DbType.String,obj.u_id);
			db.AddInParameter(dbCmd, "@v_id", DbType.String,obj.v_id);
			db.AddInParameter(dbCmd, "@v_ip", DbType.String,obj.v_ip);
			db.AddInParameter(dbCmd, "@platform", DbType.String,obj.platform);
			db.AddInParameter(dbCmd, "@v_url", DbType.String,obj.v_url);
			db.AddInParameter(dbCmd, "@v_time", DbType.DateTime,obj.v_time);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_UserVisitsInfo_SelectObject
		 public override UserVisitsInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			UserVisitsInfo obj=null;
			
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

		#region 05 Proc_UserVisitsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<UserVisitsInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<UserVisitsInfo> list= new List<UserVisitsInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserVisitsInfo obj= Object2Model(reader);
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

		#region 06 Proc_UserVisitsInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<UserVisitsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_UserVisitsInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<UserVisitsInfo> list= new List<UserVisitsInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						UserVisitsInfo obj= Object2Model(reader);
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

        public UserVisitsInfo Object2Model(IDataReader reader)
        {
            UserVisitsInfo obj = null;
            try
            {
                obj = new UserVisitsInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.u_id = reader["u_id"] == DBNull.Value ? default(string) : (string)reader["u_id"];
				obj.v_id = reader["v_id"] == DBNull.Value ? default(string) : (string)reader["v_id"];
				obj.v_ip = reader["v_ip"] == DBNull.Value ? default(string) : (string)reader["v_ip"];
				obj.platform = reader["platform"] == DBNull.Value ? default(string) : (string)reader["platform"];
				obj.v_url = reader["v_url"] == DBNull.Value ? default(string) : (string)reader["v_url"];
				obj.v_time = reader["v_time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["v_time"];
				
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
	public partial class VideoCateAccess : AccessBase<VideoCate>,IDisposable
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
        public VideoCateAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public VideoCateAccess()
        {
            db = factory.Create("Video");
			DataTableName = "VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~VideoCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_VideoCate_Insert
		 public override int Insert(VideoCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_Insert");
			db.AddOutParameter(dbCmd, "@c_id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@c_name", DbType.String,obj.c_name);
						
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
		
		#region 02 Proc_VideoCate_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_DeleteByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,id);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_VideoCate_Update
		 public override int Update(VideoCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_UpdateByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,obj.c_id);
			db.AddInParameter(dbCmd, "@c_name", DbType.String,obj.c_name);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_VideoCate_SelectObject
		 public override VideoCate SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_SelectByc_id");
			db.AddInParameter(dbCmd, "@c_id", DbType.Int32,id);
			
			VideoCate obj=null;
			
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

		#region 05 Proc_VideoCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<VideoCate> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<VideoCate> list= new List<VideoCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						VideoCate obj= Object2Model(reader);
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

		#region 06 Proc_VideoCate_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<VideoCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoCate_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<VideoCate> list= new List<VideoCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						VideoCate obj= Object2Model(reader);
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

        public VideoCate Object2Model(IDataReader reader)
        {
            VideoCate obj = null;
            try
            {
                obj = new VideoCate();
				obj.c_id = reader["c_id"] == DBNull.Value ? default(int) : (int)reader["c_id"];
				obj.c_name = reader["c_name"] == DBNull.Value ? default(string) : (string)reader["c_name"];
				
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
	public partial class VideoInfoAccess : AccessBase<VideoInfo>,IDisposable
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
        public VideoInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
        }

        public VideoInfoAccess()
        {
            db = factory.Create("Video");
			DataTableName = "VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Video"].ToString();
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
        ~VideoInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_VideoInfo_Insert
		 public override int Insert(VideoInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@v_id", DbType.String,obj.v_id);
			db.AddInParameter(dbCmd, "@v_c_id", DbType.Int32,obj.v_c_id);
			db.AddInParameter(dbCmd, "@v_c_name", DbType.String,obj.v_c_name);
			db.AddInParameter(dbCmd, "@v_titile", DbType.String,obj.v_titile);
			db.AddInParameter(dbCmd, "@v_intro", DbType.String,obj.v_intro);
			db.AddInParameter(dbCmd, "@v_coverImgSrc", DbType.String,obj.v_coverImgSrc);
			db.AddInParameter(dbCmd, "@v_playSrc", DbType.String,obj.v_playSrc);
			db.AddInParameter(dbCmd, "@v_timeLength", DbType.String,obj.v_timeLength);
			db.AddInParameter(dbCmd, "@v_createTime", DbType.DateTime,obj.v_createTime);
			db.AddInParameter(dbCmd, "@v_status", DbType.Int32,obj.v_status);
			db.AddInParameter(dbCmd, "@v_totalSecond", DbType.Int32,obj.v_totalSecond);
						
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
		
		#region 02 Proc_VideoInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_DeleteById");
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

		#region 03 Proc_VideoInfo_Update
		 public override int Update(VideoInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@v_id", DbType.String,obj.v_id);
			db.AddInParameter(dbCmd, "@v_c_id", DbType.Int32,obj.v_c_id);
			db.AddInParameter(dbCmd, "@v_c_name", DbType.String,obj.v_c_name);
			db.AddInParameter(dbCmd, "@v_titile", DbType.String,obj.v_titile);
			db.AddInParameter(dbCmd, "@v_intro", DbType.String,obj.v_intro);
			db.AddInParameter(dbCmd, "@v_coverImgSrc", DbType.String,obj.v_coverImgSrc);
			db.AddInParameter(dbCmd, "@v_playSrc", DbType.String,obj.v_playSrc);
			db.AddInParameter(dbCmd, "@v_timeLength", DbType.String,obj.v_timeLength);
			db.AddInParameter(dbCmd, "@v_createTime", DbType.DateTime,obj.v_createTime);
			db.AddInParameter(dbCmd, "@v_status", DbType.Int32,obj.v_status);
			db.AddInParameter(dbCmd, "@v_totalSecond", DbType.Int32,obj.v_totalSecond);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_VideoInfo_SelectObject
		 public override VideoInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			VideoInfo obj=null;
			
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

		#region 05 Proc_VideoInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<VideoInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<VideoInfo> list= new List<VideoInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						VideoInfo obj= Object2Model(reader);
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

		#region 06 Proc_VideoInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<VideoInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_VideoInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<VideoInfo> list= new List<VideoInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						VideoInfo obj= Object2Model(reader);
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

        public VideoInfo Object2Model(IDataReader reader)
        {
            VideoInfo obj = null;
            try
            {
                obj = new VideoInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.v_id = reader["v_id"] == DBNull.Value ? default(string) : (string)reader["v_id"];
				obj.v_c_id = reader["v_c_id"] == DBNull.Value ? default(int) : (int)reader["v_c_id"];
				obj.v_c_name = reader["v_c_name"] == DBNull.Value ? default(string) : (string)reader["v_c_name"];
				obj.v_titile = reader["v_titile"] == DBNull.Value ? default(string) : (string)reader["v_titile"];
				obj.v_intro = reader["v_intro"] == DBNull.Value ? default(string) : (string)reader["v_intro"];
				obj.v_coverImgSrc = reader["v_coverImgSrc"] == DBNull.Value ? default(string) : (string)reader["v_coverImgSrc"];
				obj.v_playSrc = reader["v_playSrc"] == DBNull.Value ? default(string) : (string)reader["v_playSrc"];
				obj.v_timeLength = reader["v_timeLength"] == DBNull.Value ? default(string) : (string)reader["v_timeLength"];
				obj.v_createTime = reader["v_createTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["v_createTime"];
				obj.v_status = reader["v_status"] == DBNull.Value ? default(int) : (int)reader["v_status"];
				obj.v_totalSecond = reader["v_totalSecond"] == DBNull.Value ? default(int) : (int)reader["v_totalSecond"];
				
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
