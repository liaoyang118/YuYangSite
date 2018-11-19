

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using DataAccess.Base;
using System.Configuration;
using Site.Videos.DataAccess.Model;

namespace Site.Videos.DataAccess.Access
{


	[Serializable]
	public partial class MySql_ActiveAccountInfoAccess : MySql_AccessBase<MySql_ActiveAccountInfo>,IDisposable
    {

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
        public MySql_ActiveAccountInfoAccess(string configName)
        {
			DataTableName = "ActiveAccountInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_ActiveAccountInfoAccess()
        {
			DataTableName = "ActiveAccountInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_ActiveAccountInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_ActiveAccountInfo_Insert
		 public override int Insert(MySql_ActiveAccountInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_ActiveAccountInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@GUID", MySqlDbType.String));
				Command.Parameters["@GUID"].Value=obj.GUID;					
				Command.Parameters.Add(new MySqlParameter("@Account", MySqlDbType.String));
				Command.Parameters["@Account"].Value=obj.Account;					
				Command.Parameters.Add(new MySqlParameter("@TimeSpan", MySqlDbType.String));
				Command.Parameters["@TimeSpan"].Value=obj.TimeSpan;					
				Command.Parameters.Add(new MySqlParameter("@Token", MySqlDbType.String));
				Command.Parameters["@Token"].Value=obj.Token;					
				Command.Parameters.Add(new MySqlParameter("@IsActive", MySqlDbType.Bit));
				Command.Parameters["@IsActive"].Value=obj.IsActive;					
				Command.Parameters.Add(new MySqlParameter("@ActiveTime", MySqlDbType.DateTime));
				Command.Parameters["@ActiveTime"].Value=obj.ActiveTime;					
				Command.Parameters.Add(new MySqlParameter("@CreateTime", MySqlDbType.DateTime));
				Command.Parameters["@CreateTime"].Value=obj.CreateTime;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_ActiveAccountInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_ActiveAccountInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_ActiveAccountInfo_Update
		 public override int Update(MySql_ActiveAccountInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveAccountInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@GUID", MySqlDbType.String));
				Command.Parameters["@GUID"].Value=obj.GUID;	
				Command.Parameters.Add(new MySqlParameter("@Account", MySqlDbType.String));
				Command.Parameters["@Account"].Value=obj.Account;	
				Command.Parameters.Add(new MySqlParameter("@TimeSpan", MySqlDbType.String));
				Command.Parameters["@TimeSpan"].Value=obj.TimeSpan;	
				Command.Parameters.Add(new MySqlParameter("@Token", MySqlDbType.String));
				Command.Parameters["@Token"].Value=obj.Token;	
				Command.Parameters.Add(new MySqlParameter("@IsActive", MySqlDbType.Bit));
				Command.Parameters["@IsActive"].Value=obj.IsActive;	
				Command.Parameters.Add(new MySqlParameter("@ActiveTime", MySqlDbType.DateTime));
				Command.Parameters["@ActiveTime"].Value=obj.ActiveTime;	
				Command.Parameters.Add(new MySqlParameter("@CreateTime", MySqlDbType.DateTime));
				Command.Parameters["@CreateTime"].Value=obj.CreateTime;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_ActiveAccountInfo_SelectObject
		 public override MySql_ActiveAccountInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveAccountInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_ActiveAccountInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_ActiveAccountInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ActiveAccountInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveAccountInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_ActiveAccountInfo> list= new List<MySql_ActiveAccountInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ActiveAccountInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_ActiveAccountInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ActiveAccountInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveAccountInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_ActiveAccountInfo> list= new List<MySql_ActiveAccountInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ActiveAccountInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_ActiveAccountInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_ActiveAccountInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("GUID");	
				sb.Append(",");		
				sb.Append("Account");	
				sb.Append(",");		
				sb.Append("TimeSpan");	
				sb.Append(",");		
				sb.Append("Token");	
				sb.Append(",");		
				sb.Append("IsActive");	
				sb.Append(",");		
				sb.Append("ActiveTime");	
				sb.Append(",");		
				sb.Append("CreateTime");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_ActiveAccountInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.GUID+"\"");
									sb.Append(",");
										sb.Append("\""+item.Account+"\"");
									sb.Append(",");
										sb.Append("\""+item.TimeSpan+"\"");
									sb.Append(",");
										sb.Append("\""+item.Token+"\"");
									sb.Append(",");
										sb.Append(item.IsActive);
									sb.Append(",");
										sb.Append("\""+item.ActiveTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_ActiveAccountInfo Object2Model(IDataReader reader)
        {
            MySql_ActiveAccountInfo obj = null;
            try
            {
                obj = new MySql_ActiveAccountInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.GUID = reader["GUID"] == DBNull.Value ? default(string) : (string)reader["GUID"];
				obj.Account = reader["Account"] == DBNull.Value ? default(string) : (string)reader["Account"];
				obj.TimeSpan = reader["TimeSpan"] == DBNull.Value ? default(string) : (string)reader["TimeSpan"];
				obj.Token = reader["Token"] == DBNull.Value ? default(string) : (string)reader["Token"];
				obj.IsActive = reader["IsActive"] == DBNull.Value ? default(bool) : (bool)reader["IsActive"];
				obj.ActiveTime = reader["ActiveTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["ActiveTime"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				
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
	public partial class MySql_ActiveVipInfoAccess : MySql_AccessBase<MySql_ActiveVipInfo>,IDisposable
    {

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
        public MySql_ActiveVipInfoAccess(string configName)
        {
			DataTableName = "ActiveVipInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_ActiveVipInfoAccess()
        {
			DataTableName = "ActiveVipInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_ActiveVipInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_ActiveVipInfo_Insert
		 public override int Insert(MySql_ActiveVipInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_ActiveVipInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.Int32));
				Command.Parameters["@u_id"].Value=obj.u_id;					
				Command.Parameters.Add(new MySqlParameter("@u_name", MySqlDbType.String));
				Command.Parameters["@u_name"].Value=obj.u_name;					
				Command.Parameters.Add(new MySqlParameter("@c_days", MySqlDbType.Int32));
				Command.Parameters["@c_days"].Value=obj.c_days;					
				Command.Parameters.Add(new MySqlParameter("@c_num", MySqlDbType.Int32));
				Command.Parameters["@c_num"].Value=obj.c_num;					
				Command.Parameters.Add(new MySqlParameter("@active_code", MySqlDbType.String));
				Command.Parameters["@active_code"].Value=obj.active_code;					
				Command.Parameters.Add(new MySqlParameter("@IsPay", MySqlDbType.Bit));
				Command.Parameters["@IsPay"].Value=obj.IsPay;					
				Command.Parameters.Add(new MySqlParameter("@pay_time", MySqlDbType.DateTime));
				Command.Parameters["@pay_time"].Value=obj.pay_time;					
				Command.Parameters.Add(new MySqlParameter("@create_time", MySqlDbType.DateTime));
				Command.Parameters["@create_time"].Value=obj.create_time;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_ActiveVipInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_ActiveVipInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_ActiveVipInfo_Update
		 public override int Update(MySql_ActiveVipInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveVipInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.Int32));
				Command.Parameters["@u_id"].Value=obj.u_id;	
				Command.Parameters.Add(new MySqlParameter("@u_name", MySqlDbType.String));
				Command.Parameters["@u_name"].Value=obj.u_name;	
				Command.Parameters.Add(new MySqlParameter("@c_days", MySqlDbType.Int32));
				Command.Parameters["@c_days"].Value=obj.c_days;	
				Command.Parameters.Add(new MySqlParameter("@c_num", MySqlDbType.Int32));
				Command.Parameters["@c_num"].Value=obj.c_num;	
				Command.Parameters.Add(new MySqlParameter("@active_code", MySqlDbType.String));
				Command.Parameters["@active_code"].Value=obj.active_code;	
				Command.Parameters.Add(new MySqlParameter("@IsPay", MySqlDbType.Bit));
				Command.Parameters["@IsPay"].Value=obj.IsPay;	
				Command.Parameters.Add(new MySqlParameter("@pay_time", MySqlDbType.DateTime));
				Command.Parameters["@pay_time"].Value=obj.pay_time;	
				Command.Parameters.Add(new MySqlParameter("@create_time", MySqlDbType.DateTime));
				Command.Parameters["@create_time"].Value=obj.create_time;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_ActiveVipInfo_SelectObject
		 public override MySql_ActiveVipInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveVipInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_ActiveVipInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_ActiveVipInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ActiveVipInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveVipInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_ActiveVipInfo> list= new List<MySql_ActiveVipInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ActiveVipInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_ActiveVipInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ActiveVipInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_ActiveVipInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_ActiveVipInfo> list= new List<MySql_ActiveVipInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ActiveVipInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_ActiveVipInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_ActiveVipInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("u_id");	
				sb.Append(",");		
				sb.Append("u_name");	
				sb.Append(",");		
				sb.Append("c_days");	
				sb.Append(",");		
				sb.Append("c_num");	
				sb.Append(",");		
				sb.Append("active_code");	
				sb.Append(",");		
				sb.Append("IsPay");	
				sb.Append(",");		
				sb.Append("pay_time");	
				sb.Append(",");		
				sb.Append("create_time");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_ActiveVipInfo item in list)
				{
				sb.Append("(");
								sb.Append(item.u_id);
									sb.Append(",");
										sb.Append("\""+item.u_name+"\"");
									sb.Append(",");
										sb.Append(item.c_days);
									sb.Append(",");
										sb.Append(item.c_num);
									sb.Append(",");
										sb.Append("\""+item.active_code+"\"");
									sb.Append(",");
										sb.Append(item.IsPay);
									sb.Append(",");
										sb.Append("\""+item.pay_time.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.create_time.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_ActiveVipInfo Object2Model(IDataReader reader)
        {
            MySql_ActiveVipInfo obj = null;
            try
            {
                obj = new MySql_ActiveVipInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.u_id = reader["u_id"] == DBNull.Value ? default(int) : (int)reader["u_id"];
				obj.u_name = reader["u_name"] == DBNull.Value ? default(string) : (string)reader["u_name"];
				obj.c_days = reader["c_days"] == DBNull.Value ? default(int) : (int)reader["c_days"];
				obj.c_num = reader["c_num"] == DBNull.Value ? default(int) : (int)reader["c_num"];
				obj.active_code = reader["active_code"] == DBNull.Value ? default(string) : (string)reader["active_code"];
				obj.IsPay = reader["IsPay"] == DBNull.Value ? default(bool) : (bool)reader["IsPay"];
				obj.pay_time = reader["pay_time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["pay_time"];
				obj.create_time = reader["create_time"] == DBNull.Value ? default(DateTime) : (DateTime)reader["create_time"];
				
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
	public partial class MySql_AdvertisingInfoAccess : MySql_AccessBase<MySql_AdvertisingInfo>,IDisposable
    {

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
        public MySql_AdvertisingInfoAccess(string configName)
        {
			DataTableName = "AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_AdvertisingInfoAccess()
        {
			DataTableName = "AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_AdvertisingInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_AdvertisingInfo_Insert
		 public override int Insert(MySql_AdvertisingInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_AdvertisingInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@a_id", MySqlDbType.String));
				Command.Parameters["@a_id"].Value=obj.a_id;					
				Command.Parameters.Add(new MySqlParameter("@a_name", MySqlDbType.String));
				Command.Parameters["@a_name"].Value=obj.a_name;					
				Command.Parameters.Add(new MySqlParameter("@a_type", MySqlDbType.Int32));
				Command.Parameters["@a_type"].Value=obj.a_type;					
				Command.Parameters.Add(new MySqlParameter("@a_src", MySqlDbType.String));
				Command.Parameters["@a_src"].Value=obj.a_src;					
				Command.Parameters.Add(new MySqlParameter("@a_second", MySqlDbType.Int32));
				Command.Parameters["@a_second"].Value=obj.a_second;					
				Command.Parameters.Add(new MySqlParameter("@a_status", MySqlDbType.Int32));
				Command.Parameters["@a_status"].Value=obj.a_status;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_AdvertisingInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_AdvertisingInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_AdvertisingInfo_Update
		 public override int Update(MySql_AdvertisingInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_AdvertisingInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@a_id", MySqlDbType.String));
				Command.Parameters["@a_id"].Value=obj.a_id;	
				Command.Parameters.Add(new MySqlParameter("@a_name", MySqlDbType.String));
				Command.Parameters["@a_name"].Value=obj.a_name;	
				Command.Parameters.Add(new MySqlParameter("@a_type", MySqlDbType.Int32));
				Command.Parameters["@a_type"].Value=obj.a_type;	
				Command.Parameters.Add(new MySqlParameter("@a_src", MySqlDbType.String));
				Command.Parameters["@a_src"].Value=obj.a_src;	
				Command.Parameters.Add(new MySqlParameter("@a_second", MySqlDbType.Int32));
				Command.Parameters["@a_second"].Value=obj.a_second;	
				Command.Parameters.Add(new MySqlParameter("@a_status", MySqlDbType.Int32));
				Command.Parameters["@a_status"].Value=obj.a_status;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_AdvertisingInfo_SelectObject
		 public override MySql_AdvertisingInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_AdvertisingInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_AdvertisingInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_AdvertisingInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_AdvertisingInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_AdvertisingInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_AdvertisingInfo> list= new List<MySql_AdvertisingInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_AdvertisingInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_AdvertisingInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_AdvertisingInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_AdvertisingInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_AdvertisingInfo> list= new List<MySql_AdvertisingInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_AdvertisingInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_AdvertisingInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_AdvertisingInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("a_id");	
				sb.Append(",");		
				sb.Append("a_name");	
				sb.Append(",");		
				sb.Append("a_type");	
				sb.Append(",");		
				sb.Append("a_src");	
				sb.Append(",");		
				sb.Append("a_second");	
				sb.Append(",");		
				sb.Append("a_status");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_AdvertisingInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.a_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.a_name+"\"");
									sb.Append(",");
										sb.Append(item.a_type);
									sb.Append(",");
										sb.Append("\""+item.a_src+"\"");
									sb.Append(",");
										sb.Append(item.a_second);
									sb.Append(",");
										sb.Append(item.a_status);
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_AdvertisingInfo Object2Model(IDataReader reader)
        {
            MySql_AdvertisingInfo obj = null;
            try
            {
                obj = new MySql_AdvertisingInfo();
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
	public partial class MySql_ComboInfoAccess : MySql_AccessBase<MySql_ComboInfo>,IDisposable
    {

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
        public MySql_ComboInfoAccess(string configName)
        {
			DataTableName = "ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_ComboInfoAccess()
        {
			DataTableName = "ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_ComboInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_ComboInfo_Insert
		 public override int Insert(MySql_ComboInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_ComboInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.String));
				Command.Parameters["@c_id"].Value=obj.c_id;					
				Command.Parameters.Add(new MySqlParameter("@c_title", MySqlDbType.String));
				Command.Parameters["@c_title"].Value=obj.c_title;					
				Command.Parameters.Add(new MySqlParameter("@c_intro", MySqlDbType.String));
				Command.Parameters["@c_intro"].Value=obj.c_intro;					
				Command.Parameters.Add(new MySqlParameter("@c_num", MySqlDbType.Int32));
				Command.Parameters["@c_num"].Value=obj.c_num;					
				Command.Parameters.Add(new MySqlParameter("@c_days", MySqlDbType.Int32));
				Command.Parameters["@c_days"].Value=obj.c_days;					
				Command.Parameters.Add(new MySqlParameter("@c_status", MySqlDbType.Int32));
				Command.Parameters["@c_status"].Value=obj.c_status;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_ComboInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_ComboInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_ComboInfo_Update
		 public override int Update(MySql_ComboInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_ComboInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.String));
				Command.Parameters["@c_id"].Value=obj.c_id;	
				Command.Parameters.Add(new MySqlParameter("@c_title", MySqlDbType.String));
				Command.Parameters["@c_title"].Value=obj.c_title;	
				Command.Parameters.Add(new MySqlParameter("@c_intro", MySqlDbType.String));
				Command.Parameters["@c_intro"].Value=obj.c_intro;	
				Command.Parameters.Add(new MySqlParameter("@c_num", MySqlDbType.Int32));
				Command.Parameters["@c_num"].Value=obj.c_num;	
				Command.Parameters.Add(new MySqlParameter("@c_days", MySqlDbType.Int32));
				Command.Parameters["@c_days"].Value=obj.c_days;	
				Command.Parameters.Add(new MySqlParameter("@c_status", MySqlDbType.Int32));
				Command.Parameters["@c_status"].Value=obj.c_status;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_ComboInfo_SelectObject
		 public override MySql_ComboInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_ComboInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_ComboInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_ComboInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ComboInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_ComboInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_ComboInfo> list= new List<MySql_ComboInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ComboInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_ComboInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_ComboInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_ComboInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_ComboInfo> list= new List<MySql_ComboInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_ComboInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_ComboInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_ComboInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("c_id");	
				sb.Append(",");		
				sb.Append("c_title");	
				sb.Append(",");		
				sb.Append("c_intro");	
				sb.Append(",");		
				sb.Append("c_num");	
				sb.Append(",");		
				sb.Append("c_days");	
				sb.Append(",");		
				sb.Append("c_status");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_ComboInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.c_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.c_title+"\"");
									sb.Append(",");
										sb.Append("\""+item.c_intro+"\"");
									sb.Append(",");
										sb.Append(item.c_num);
									sb.Append(",");
										sb.Append(item.c_days);
									sb.Append(",");
										sb.Append(item.c_status);
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_ComboInfo Object2Model(IDataReader reader)
        {
            MySql_ComboInfo obj = null;
            try
            {
                obj = new MySql_ComboInfo();
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
	public partial class MySql_NoticeInfoAccess : MySql_AccessBase<MySql_NoticeInfo>,IDisposable
    {

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
        public MySql_NoticeInfoAccess(string configName)
        {
			DataTableName = "NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_NoticeInfoAccess()
        {
			DataTableName = "NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_NoticeInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_NoticeInfo_Insert
		 public override int Insert(MySql_NoticeInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_NoticeInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@n_id", MySqlDbType.String));
				Command.Parameters["@n_id"].Value=obj.n_id;					
				Command.Parameters.Add(new MySqlParameter("@n_title", MySqlDbType.String));
				Command.Parameters["@n_title"].Value=obj.n_title;					
				Command.Parameters.Add(new MySqlParameter("@n_content", MySqlDbType.String));
				Command.Parameters["@n_content"].Value=obj.n_content;					
				Command.Parameters.Add(new MySqlParameter("@n_beginTime", MySqlDbType.DateTime));
				Command.Parameters["@n_beginTime"].Value=obj.n_beginTime;					
				Command.Parameters.Add(new MySqlParameter("@n_endTime", MySqlDbType.DateTime));
				Command.Parameters["@n_endTime"].Value=obj.n_endTime;					
				Command.Parameters.Add(new MySqlParameter("@n_status", MySqlDbType.Int32));
				Command.Parameters["@n_status"].Value=obj.n_status;					
				Command.Parameters.Add(new MySqlParameter("@n_createTime", MySqlDbType.DateTime));
				Command.Parameters["@n_createTime"].Value=obj.n_createTime;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_NoticeInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_NoticeInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_NoticeInfo_Update
		 public override int Update(MySql_NoticeInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_NoticeInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@n_id", MySqlDbType.String));
				Command.Parameters["@n_id"].Value=obj.n_id;	
				Command.Parameters.Add(new MySqlParameter("@n_title", MySqlDbType.String));
				Command.Parameters["@n_title"].Value=obj.n_title;	
				Command.Parameters.Add(new MySqlParameter("@n_content", MySqlDbType.String));
				Command.Parameters["@n_content"].Value=obj.n_content;	
				Command.Parameters.Add(new MySqlParameter("@n_beginTime", MySqlDbType.DateTime));
				Command.Parameters["@n_beginTime"].Value=obj.n_beginTime;	
				Command.Parameters.Add(new MySqlParameter("@n_endTime", MySqlDbType.DateTime));
				Command.Parameters["@n_endTime"].Value=obj.n_endTime;	
				Command.Parameters.Add(new MySqlParameter("@n_status", MySqlDbType.Int32));
				Command.Parameters["@n_status"].Value=obj.n_status;	
				Command.Parameters.Add(new MySqlParameter("@n_createTime", MySqlDbType.DateTime));
				Command.Parameters["@n_createTime"].Value=obj.n_createTime;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_NoticeInfo_SelectObject
		 public override MySql_NoticeInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_NoticeInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_NoticeInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_NoticeInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_NoticeInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_NoticeInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_NoticeInfo> list= new List<MySql_NoticeInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_NoticeInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_NoticeInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_NoticeInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_NoticeInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_NoticeInfo> list= new List<MySql_NoticeInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_NoticeInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_NoticeInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_NoticeInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("n_id");	
				sb.Append(",");		
				sb.Append("n_title");	
				sb.Append(",");		
				sb.Append("n_content");	
				sb.Append(",");		
				sb.Append("n_beginTime");	
				sb.Append(",");		
				sb.Append("n_endTime");	
				sb.Append(",");		
				sb.Append("n_status");	
				sb.Append(",");		
				sb.Append("n_createTime");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_NoticeInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.n_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.n_title+"\"");
									sb.Append(",");
										sb.Append("\""+item.n_content+"\"");
									sb.Append(",");
										sb.Append("\""+item.n_beginTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.n_endTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append(item.n_status);
									sb.Append(",");
										sb.Append("\""+item.n_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_NoticeInfo Object2Model(IDataReader reader)
        {
            MySql_NoticeInfo obj = null;
            try
            {
                obj = new MySql_NoticeInfo();
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
	public partial class MySql_RechargeRecoderAccess : MySql_AccessBase<MySql_RechargeRecoder>,IDisposable
    {

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
        public MySql_RechargeRecoderAccess(string configName)
        {
			DataTableName = "RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_RechargeRecoderAccess()
        {
			DataTableName = "RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_RechargeRecoderAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_RechargeRecoder_Insert
		 public override int Insert(MySql_RechargeRecoder obj)
		 {
			try
			{ 
				Command.CommandText="Proc_RechargeRecoder_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@r_id", MySqlDbType.String));
				Command.Parameters["@r_id"].Value=obj.r_id;					
				Command.Parameters.Add(new MySqlParameter("@r_u_id", MySqlDbType.String));
				Command.Parameters["@r_u_id"].Value=obj.r_u_id;					
				Command.Parameters.Add(new MySqlParameter("@r_c_id", MySqlDbType.String));
				Command.Parameters["@r_c_id"].Value=obj.r_c_id;					
				Command.Parameters.Add(new MySqlParameter("@r_c_title", MySqlDbType.String));
				Command.Parameters["@r_c_title"].Value=obj.r_c_title;					
				Command.Parameters.Add(new MySqlParameter("@r_money", MySqlDbType.Decimal));
				Command.Parameters["@r_money"].Value=obj.r_money;					
				Command.Parameters.Add(new MySqlParameter("@r_c_days", MySqlDbType.Int32));
				Command.Parameters["@r_c_days"].Value=obj.r_c_days;					
				Command.Parameters.Add(new MySqlParameter("@r_createTime", MySqlDbType.DateTime));
				Command.Parameters["@r_createTime"].Value=obj.r_createTime;					
				Command.Parameters.Add(new MySqlParameter("@r_u_expriseTime", MySqlDbType.DateTime));
				Command.Parameters["@r_u_expriseTime"].Value=obj.r_u_expriseTime;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_RechargeRecoder_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_RechargeRecoder_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_RechargeRecoder_Update
		 public override int Update(MySql_RechargeRecoder obj)
		 {
			try
			{ 
			Command.CommandText="Proc_RechargeRecoder_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@r_id", MySqlDbType.String));
				Command.Parameters["@r_id"].Value=obj.r_id;	
				Command.Parameters.Add(new MySqlParameter("@r_u_id", MySqlDbType.String));
				Command.Parameters["@r_u_id"].Value=obj.r_u_id;	
				Command.Parameters.Add(new MySqlParameter("@r_c_id", MySqlDbType.String));
				Command.Parameters["@r_c_id"].Value=obj.r_c_id;	
				Command.Parameters.Add(new MySqlParameter("@r_c_title", MySqlDbType.String));
				Command.Parameters["@r_c_title"].Value=obj.r_c_title;	
				Command.Parameters.Add(new MySqlParameter("@r_money", MySqlDbType.Decimal));
				Command.Parameters["@r_money"].Value=obj.r_money;	
				Command.Parameters.Add(new MySqlParameter("@r_c_days", MySqlDbType.Int32));
				Command.Parameters["@r_c_days"].Value=obj.r_c_days;	
				Command.Parameters.Add(new MySqlParameter("@r_createTime", MySqlDbType.DateTime));
				Command.Parameters["@r_createTime"].Value=obj.r_createTime;	
				Command.Parameters.Add(new MySqlParameter("@r_u_expriseTime", MySqlDbType.DateTime));
				Command.Parameters["@r_u_expriseTime"].Value=obj.r_u_expriseTime;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_RechargeRecoder_SelectObject
		 public override MySql_RechargeRecoder SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_RechargeRecoder_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_RechargeRecoder obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_RechargeRecoder_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_RechargeRecoder> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_RechargeRecoder_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_RechargeRecoder> list= new List<MySql_RechargeRecoder>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_RechargeRecoder obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_RechargeRecoder_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_RechargeRecoder> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_RechargeRecoder_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_RechargeRecoder> list= new List<MySql_RechargeRecoder>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_RechargeRecoder obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_RechargeRecoder_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_RechargeRecoder> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("r_id");	
				sb.Append(",");		
				sb.Append("r_u_id");	
				sb.Append(",");		
				sb.Append("r_c_id");	
				sb.Append(",");		
				sb.Append("r_c_title");	
				sb.Append(",");		
				sb.Append("r_money");	
				sb.Append(",");		
				sb.Append("r_c_days");	
				sb.Append(",");		
				sb.Append("r_createTime");	
				sb.Append(",");		
				sb.Append("r_u_expriseTime");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_RechargeRecoder item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.r_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.r_u_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.r_c_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.r_c_title+"\"");
									sb.Append(",");
										sb.Append(item.r_money);
									sb.Append(",");
										sb.Append(item.r_c_days);
									sb.Append(",");
										sb.Append("\""+item.r_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.r_u_expriseTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_RechargeRecoder Object2Model(IDataReader reader)
        {
            MySql_RechargeRecoder obj = null;
            try
            {
                obj = new MySql_RechargeRecoder();
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
	public partial class MySql_SendMailLogAccess : MySql_AccessBase<MySql_SendMailLog>,IDisposable
    {

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
        public MySql_SendMailLogAccess(string configName)
        {
			DataTableName = "SendMailLog";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_SendMailLogAccess()
        {
			DataTableName = "SendMailLog";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_SendMailLogAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_SendMailLog_Insert
		 public override int Insert(MySql_SendMailLog obj)
		 {
			try
			{ 
				Command.CommandText="Proc_SendMailLog_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.String));
				Command.Parameters["@Email"].Value=obj.Email;					
				Command.Parameters.Add(new MySqlParameter("@Title", MySqlDbType.String));
				Command.Parameters["@Title"].Value=obj.Title;					
				Command.Parameters.Add(new MySqlParameter("@SendTime", MySqlDbType.DateTime));
				Command.Parameters["@SendTime"].Value=obj.SendTime;					
				Command.Parameters.Add(new MySqlParameter("@SendContent", MySqlDbType.String));
				Command.Parameters["@SendContent"].Value=obj.SendContent;					
				Command.Parameters.Add(new MySqlParameter("@IsSuccess", MySqlDbType.Bit));
				Command.Parameters["@IsSuccess"].Value=obj.IsSuccess;					
				Command.Parameters.Add(new MySqlParameter("@Remark", MySqlDbType.String));
				Command.Parameters["@Remark"].Value=obj.Remark;					
				Command.Parameters.Add(new MySqlParameter("@CreateTime", MySqlDbType.DateTime));
				Command.Parameters["@CreateTime"].Value=obj.CreateTime;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_SendMailLog_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_SendMailLog_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_SendMailLog_Update
		 public override int Update(MySql_SendMailLog obj)
		 {
			try
			{ 
			Command.CommandText="Proc_SendMailLog_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.String));
				Command.Parameters["@Email"].Value=obj.Email;	
				Command.Parameters.Add(new MySqlParameter("@Title", MySqlDbType.String));
				Command.Parameters["@Title"].Value=obj.Title;	
				Command.Parameters.Add(new MySqlParameter("@SendTime", MySqlDbType.DateTime));
				Command.Parameters["@SendTime"].Value=obj.SendTime;	
				Command.Parameters.Add(new MySqlParameter("@SendContent", MySqlDbType.String));
				Command.Parameters["@SendContent"].Value=obj.SendContent;	
				Command.Parameters.Add(new MySqlParameter("@IsSuccess", MySqlDbType.Bit));
				Command.Parameters["@IsSuccess"].Value=obj.IsSuccess;	
				Command.Parameters.Add(new MySqlParameter("@Remark", MySqlDbType.String));
				Command.Parameters["@Remark"].Value=obj.Remark;	
				Command.Parameters.Add(new MySqlParameter("@CreateTime", MySqlDbType.DateTime));
				Command.Parameters["@CreateTime"].Value=obj.CreateTime;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_SendMailLog_SelectObject
		 public override MySql_SendMailLog SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_SendMailLog_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_SendMailLog obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_SendMailLog_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_SendMailLog> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_SendMailLog_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_SendMailLog> list= new List<MySql_SendMailLog>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_SendMailLog obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_SendMailLog_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_SendMailLog> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_SendMailLog_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_SendMailLog> list= new List<MySql_SendMailLog>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_SendMailLog obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_SendMailLog_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_SendMailLog> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("Email");	
				sb.Append(",");		
				sb.Append("Title");	
				sb.Append(",");		
				sb.Append("SendTime");	
				sb.Append(",");		
				sb.Append("SendContent");	
				sb.Append(",");		
				sb.Append("IsSuccess");	
				sb.Append(",");		
				sb.Append("Remark");	
				sb.Append(",");		
				sb.Append("CreateTime");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_SendMailLog item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.Email+"\"");
									sb.Append(",");
										sb.Append("\""+item.Title+"\"");
									sb.Append(",");
										sb.Append("\""+item.SendTime.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.SendContent+"\"");
									sb.Append(",");
										sb.Append(item.IsSuccess);
									sb.Append(",");
										sb.Append("\""+item.Remark+"\"");
									sb.Append(",");
										sb.Append("\""+item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_SendMailLog Object2Model(IDataReader reader)
        {
            MySql_SendMailLog obj = null;
            try
            {
                obj = new MySql_SendMailLog();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.Email = reader["Email"] == DBNull.Value ? default(string) : (string)reader["Email"];
				obj.Title = reader["Title"] == DBNull.Value ? default(string) : (string)reader["Title"];
				obj.SendTime = reader["SendTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["SendTime"];
				obj.SendContent = reader["SendContent"] == DBNull.Value ? default(string) : (string)reader["SendContent"];
				obj.IsSuccess = reader["IsSuccess"] == DBNull.Value ? default(bool) : (bool)reader["IsSuccess"];
				obj.Remark = reader["Remark"] == DBNull.Value ? default(string) : (string)reader["Remark"];
				obj.CreateTime = reader["CreateTime"] == DBNull.Value ? default(DateTime) : (DateTime)reader["CreateTime"];
				
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
	public partial class MySql_UserInfoAccess : MySql_AccessBase<MySql_UserInfo>,IDisposable
    {

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
        public MySql_UserInfoAccess(string configName)
        {
			DataTableName = "UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_UserInfoAccess()
        {
			DataTableName = "UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_UserInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_UserInfo_Insert
		 public override int Insert(MySql_UserInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_UserInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@u_gid", MySqlDbType.String));
				Command.Parameters["@u_gid"].Value=obj.u_gid;					
				Command.Parameters.Add(new MySqlParameter("@u_name", MySqlDbType.String));
				Command.Parameters["@u_name"].Value=obj.u_name;					
				Command.Parameters.Add(new MySqlParameter("@u_pwd", MySqlDbType.String));
				Command.Parameters["@u_pwd"].Value=obj.u_pwd;					
				Command.Parameters.Add(new MySqlParameter("@u_level", MySqlDbType.Int32));
				Command.Parameters["@u_level"].Value=obj.u_level;					
				Command.Parameters.Add(new MySqlParameter("@u_expriseTime", MySqlDbType.DateTime));
				Command.Parameters["@u_expriseTime"].Value=obj.u_expriseTime;					
				Command.Parameters.Add(new MySqlParameter("@u_regTime", MySqlDbType.DateTime));
				Command.Parameters["@u_regTime"].Value=obj.u_regTime;					
				Command.Parameters.Add(new MySqlParameter("@u_status", MySqlDbType.Int32));
				Command.Parameters["@u_status"].Value=obj.u_status;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_UserInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_UserInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_UserInfo_Update
		 public override int Update(MySql_UserInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_UserInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@u_gid", MySqlDbType.String));
				Command.Parameters["@u_gid"].Value=obj.u_gid;	
				Command.Parameters.Add(new MySqlParameter("@u_name", MySqlDbType.String));
				Command.Parameters["@u_name"].Value=obj.u_name;	
				Command.Parameters.Add(new MySqlParameter("@u_pwd", MySqlDbType.String));
				Command.Parameters["@u_pwd"].Value=obj.u_pwd;	
				Command.Parameters.Add(new MySqlParameter("@u_level", MySqlDbType.Int32));
				Command.Parameters["@u_level"].Value=obj.u_level;	
				Command.Parameters.Add(new MySqlParameter("@u_expriseTime", MySqlDbType.DateTime));
				Command.Parameters["@u_expriseTime"].Value=obj.u_expriseTime;	
				Command.Parameters.Add(new MySqlParameter("@u_regTime", MySqlDbType.DateTime));
				Command.Parameters["@u_regTime"].Value=obj.u_regTime;	
				Command.Parameters.Add(new MySqlParameter("@u_status", MySqlDbType.Int32));
				Command.Parameters["@u_status"].Value=obj.u_status;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_UserInfo_SelectObject
		 public override MySql_UserInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_UserInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_UserInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_UserInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_UserInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_UserInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_UserInfo> list= new List<MySql_UserInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_UserInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_UserInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_UserInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_UserInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_UserInfo> list= new List<MySql_UserInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_UserInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_UserInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_UserInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("u_gid");	
				sb.Append(",");		
				sb.Append("u_name");	
				sb.Append(",");		
				sb.Append("u_pwd");	
				sb.Append(",");		
				sb.Append("u_level");	
				sb.Append(",");		
				sb.Append("u_expriseTime");	
				sb.Append(",");		
				sb.Append("u_regTime");	
				sb.Append(",");		
				sb.Append("u_status");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_UserInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.u_gid+"\"");
									sb.Append(",");
										sb.Append("\""+item.u_name+"\"");
									sb.Append(",");
										sb.Append("\""+item.u_pwd+"\"");
									sb.Append(",");
										sb.Append(item.u_level);
									sb.Append(",");
										sb.Append("\""+item.u_expriseTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append("\""+item.u_regTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append(item.u_status);
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_UserInfo Object2Model(IDataReader reader)
        {
            MySql_UserInfo obj = null;
            try
            {
                obj = new MySql_UserInfo();
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
	public partial class MySql_UserVisitsInfoAccess : MySql_AccessBase<MySql_UserVisitsInfo>,IDisposable
    {

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
        public MySql_UserVisitsInfoAccess(string configName)
        {
			DataTableName = "UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_UserVisitsInfoAccess()
        {
			DataTableName = "UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_UserVisitsInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_UserVisitsInfo_Insert
		 public override int Insert(MySql_UserVisitsInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_UserVisitsInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.String));
				Command.Parameters["@u_id"].Value=obj.u_id;					
				Command.Parameters.Add(new MySqlParameter("@v_id", MySqlDbType.String));
				Command.Parameters["@v_id"].Value=obj.v_id;					
				Command.Parameters.Add(new MySqlParameter("@v_ip", MySqlDbType.String));
				Command.Parameters["@v_ip"].Value=obj.v_ip;					
				Command.Parameters.Add(new MySqlParameter("@platform", MySqlDbType.String));
				Command.Parameters["@platform"].Value=obj.platform;					
				Command.Parameters.Add(new MySqlParameter("@v_url", MySqlDbType.String));
				Command.Parameters["@v_url"].Value=obj.v_url;					
				Command.Parameters.Add(new MySqlParameter("@v_time", MySqlDbType.DateTime));
				Command.Parameters["@v_time"].Value=obj.v_time;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_UserVisitsInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_UserVisitsInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_UserVisitsInfo_Update
		 public override int Update(MySql_UserVisitsInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_UserVisitsInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@u_id", MySqlDbType.String));
				Command.Parameters["@u_id"].Value=obj.u_id;	
				Command.Parameters.Add(new MySqlParameter("@v_id", MySqlDbType.String));
				Command.Parameters["@v_id"].Value=obj.v_id;	
				Command.Parameters.Add(new MySqlParameter("@v_ip", MySqlDbType.String));
				Command.Parameters["@v_ip"].Value=obj.v_ip;	
				Command.Parameters.Add(new MySqlParameter("@platform", MySqlDbType.String));
				Command.Parameters["@platform"].Value=obj.platform;	
				Command.Parameters.Add(new MySqlParameter("@v_url", MySqlDbType.String));
				Command.Parameters["@v_url"].Value=obj.v_url;	
				Command.Parameters.Add(new MySqlParameter("@v_time", MySqlDbType.DateTime));
				Command.Parameters["@v_time"].Value=obj.v_time;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_UserVisitsInfo_SelectObject
		 public override MySql_UserVisitsInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_UserVisitsInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_UserVisitsInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_UserVisitsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_UserVisitsInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_UserVisitsInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_UserVisitsInfo> list= new List<MySql_UserVisitsInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_UserVisitsInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_UserVisitsInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_UserVisitsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_UserVisitsInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_UserVisitsInfo> list= new List<MySql_UserVisitsInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_UserVisitsInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_UserVisitsInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_UserVisitsInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("u_id");	
				sb.Append(",");		
				sb.Append("v_id");	
				sb.Append(",");		
				sb.Append("v_ip");	
				sb.Append(",");		
				sb.Append("platform");	
				sb.Append(",");		
				sb.Append("v_url");	
				sb.Append(",");		
				sb.Append("v_time");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_UserVisitsInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.u_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_id+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_ip+"\"");
									sb.Append(",");
										sb.Append("\""+item.platform+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_url+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_time.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_UserVisitsInfo Object2Model(IDataReader reader)
        {
            MySql_UserVisitsInfo obj = null;
            try
            {
                obj = new MySql_UserVisitsInfo();
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
	public partial class MySql_VideoCateAccess : MySql_AccessBase<MySql_VideoCate>,IDisposable
    {

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
        public MySql_VideoCateAccess(string configName)
        {
			DataTableName = "VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_VideoCateAccess()
        {
			DataTableName = "VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_VideoCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_VideoCate_Insert
		 public override int Insert(MySql_VideoCate obj)
		 {
			try
			{ 
				Command.CommandText="Proc_VideoCate_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.Int32,4));
				Command.Parameters["@c_id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@c_name", MySqlDbType.String));
				Command.Parameters["@c_name"].Value=obj.c_name;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_VideoCate_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_VideoCate_DeleteByc_id";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_VideoCate_Update
		 public override int Update(MySql_VideoCate obj)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoCate_UpdateByc_id";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.Int32,4));
				Command.Parameters["@c_id"].Value=obj.c_id;
				Command.Parameters.Add(new MySqlParameter("@c_name", MySqlDbType.String));
				Command.Parameters["@c_name"].Value=obj.c_name;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_VideoCate_SelectObject
		 public override MySql_VideoCate SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoCate_SelectByc_id";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@c_id", MySqlDbType.Int32,4));
			Command.Parameters["@c_id"].Value=id;
			
			MySql_VideoCate obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_VideoCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_VideoCate> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoCate_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_VideoCate> list= new List<MySql_VideoCate>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_VideoCate obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_VideoCate_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_VideoCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoCate_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_VideoCate> list= new List<MySql_VideoCate>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_VideoCate obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_VideoCate_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_VideoCate> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("c_name");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_VideoCate item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.c_name+"\"");
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_VideoCate Object2Model(IDataReader reader)
        {
            MySql_VideoCate obj = null;
            try
            {
                obj = new MySql_VideoCate();
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
	public partial class MySql_VideoInfoAccess : MySql_AccessBase<MySql_VideoInfo>,IDisposable
    {

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
        public MySql_VideoInfoAccess(string configName)
        {
			DataTableName = "VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings[configName].ToString();
			GetCommand();

        }

        public MySql_VideoInfoAccess()
        {
			DataTableName = "VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["MySql_Video"].ToString();
            GetCommand();

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
        ~MySql_VideoInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_MySql_VideoInfo_Insert
		 public override int Insert(MySql_VideoInfo obj)
		 {
			try
			{ 
				Command.CommandText="Proc_VideoInfo_Insert";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;                

				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Direction = ParameterDirection.Output;
				Command.Parameters.Add(new MySqlParameter("@v_id", MySqlDbType.String));
				Command.Parameters["@v_id"].Value=obj.v_id;					
				Command.Parameters.Add(new MySqlParameter("@v_c_id", MySqlDbType.Int32));
				Command.Parameters["@v_c_id"].Value=obj.v_c_id;					
				Command.Parameters.Add(new MySqlParameter("@v_c_name", MySqlDbType.String));
				Command.Parameters["@v_c_name"].Value=obj.v_c_name;					
				Command.Parameters.Add(new MySqlParameter("@v_titile", MySqlDbType.String));
				Command.Parameters["@v_titile"].Value=obj.v_titile;					
				Command.Parameters.Add(new MySqlParameter("@v_intro", MySqlDbType.String));
				Command.Parameters["@v_intro"].Value=obj.v_intro;					
				Command.Parameters.Add(new MySqlParameter("@v_coverImgSrc", MySqlDbType.String));
				Command.Parameters["@v_coverImgSrc"].Value=obj.v_coverImgSrc;					
				Command.Parameters.Add(new MySqlParameter("@v_playSrc", MySqlDbType.String));
				Command.Parameters["@v_playSrc"].Value=obj.v_playSrc;					
				Command.Parameters.Add(new MySqlParameter("@v_min_playSrc", MySqlDbType.String));
				Command.Parameters["@v_min_playSrc"].Value=obj.v_min_playSrc;					
				Command.Parameters.Add(new MySqlParameter("@v_timeLength", MySqlDbType.String));
				Command.Parameters["@v_timeLength"].Value=obj.v_timeLength;					
				Command.Parameters.Add(new MySqlParameter("@v_createTime", MySqlDbType.DateTime));
				Command.Parameters["@v_createTime"].Value=obj.v_createTime;					
				Command.Parameters.Add(new MySqlParameter("@v_status", MySqlDbType.Int32));
				Command.Parameters["@v_status"].Value=obj.v_status;					
				Command.Parameters.Add(new MySqlParameter("@v_totalSecond", MySqlDbType.Int32));
				Command.Parameters["@v_totalSecond"].Value=obj.v_totalSecond;					
							
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Proc_MySql_VideoInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{
				Command.CommandText="Proc_VideoInfo_DeleteById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				
							int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();

				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Proc_MySql_VideoInfo_Update
		 public override int Update(MySql_VideoInfo obj)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoInfo_UpdateById";
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.StoredProcedure;
				Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
				Command.Parameters["@Id"].Value=obj.Id;
				Command.Parameters.Add(new MySqlParameter("@v_id", MySqlDbType.String));
				Command.Parameters["@v_id"].Value=obj.v_id;	
				Command.Parameters.Add(new MySqlParameter("@v_c_id", MySqlDbType.Int32));
				Command.Parameters["@v_c_id"].Value=obj.v_c_id;	
				Command.Parameters.Add(new MySqlParameter("@v_c_name", MySqlDbType.String));
				Command.Parameters["@v_c_name"].Value=obj.v_c_name;	
				Command.Parameters.Add(new MySqlParameter("@v_titile", MySqlDbType.String));
				Command.Parameters["@v_titile"].Value=obj.v_titile;	
				Command.Parameters.Add(new MySqlParameter("@v_intro", MySqlDbType.String));
				Command.Parameters["@v_intro"].Value=obj.v_intro;	
				Command.Parameters.Add(new MySqlParameter("@v_coverImgSrc", MySqlDbType.String));
				Command.Parameters["@v_coverImgSrc"].Value=obj.v_coverImgSrc;	
				Command.Parameters.Add(new MySqlParameter("@v_playSrc", MySqlDbType.String));
				Command.Parameters["@v_playSrc"].Value=obj.v_playSrc;	
				Command.Parameters.Add(new MySqlParameter("@v_min_playSrc", MySqlDbType.String));
				Command.Parameters["@v_min_playSrc"].Value=obj.v_min_playSrc;	
				Command.Parameters.Add(new MySqlParameter("@v_timeLength", MySqlDbType.String));
				Command.Parameters["@v_timeLength"].Value=obj.v_timeLength;	
				Command.Parameters.Add(new MySqlParameter("@v_createTime", MySqlDbType.DateTime));
				Command.Parameters["@v_createTime"].Value=obj.v_createTime;	
				Command.Parameters.Add(new MySqlParameter("@v_status", MySqlDbType.Int32));
				Command.Parameters["@v_status"].Value=obj.v_status;	
				Command.Parameters.Add(new MySqlParameter("@v_totalSecond", MySqlDbType.Int32));
				Command.Parameters["@v_totalSecond"].Value=obj.v_totalSecond;	
				
			
				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
                DisposeConnection();
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mysql数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_MySql_VideoInfo_SelectObject
		 public override MySql_VideoInfo SelectObject(int id)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoInfo_SelectById";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32,4));
			Command.Parameters["@Id"].Value=id;
			
			MySql_VideoInfo obj=null;
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						obj=Object2Model(reader);
					}
                }

				DisposeCommand();
                DisposeConnection();
				return obj;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Proc_MySql_VideoInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_VideoInfo> Select(string whereStr)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoInfo_SelectList";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;
			Command.Parameters.Add(new MySqlParameter("@whereStr", MySqlDbType.String));
			Command.Parameters["@whereStr"].Value=whereStr;
						IList<MySql_VideoInfo> list= new List<MySql_VideoInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_VideoInfo obj= Object2Model(reader);
						list.Add(obj);
					}
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion

		#region 06 Proc_MySql_VideoInfo_SelectPage
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<MySql_VideoInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			Command.CommandText="Proc_VideoInfo_SelectPage";
			Command.CommandTimeout=30;
			Command.CommandType= CommandType.StoredProcedure;

			Command.Parameters.Add(new MySqlParameter("@rowCount", MySqlDbType.Int32,4));
			Command.Parameters["@rowCount"].Direction = ParameterDirection.Output;

			Command.Parameters.Add(new MySqlParameter("@cloumns", MySqlDbType.String));
			Command.Parameters["@cloumns"].Value=cloumns;
			Command.Parameters.Add(new MySqlParameter("@pageIndex", MySqlDbType.Int32));
			Command.Parameters["@pageIndex"].Value=pageIndex;
			Command.Parameters.Add(new MySqlParameter("@pageSize", MySqlDbType.Int32));
			Command.Parameters["@pageSize"].Value=pageSize;
			Command.Parameters.Add(new MySqlParameter("@orderBy", MySqlDbType.String));
			Command.Parameters["@orderBy"].Value=order;
			Command.Parameters.Add(new MySqlParameter("@where", MySqlDbType.String));
			Command.Parameters["@where"].Value=whereStr;

			
			List<MySql_VideoInfo> list= new List<MySql_VideoInfo>();
			
               using(IDataReader reader = Command.ExecuteReader())
               {
					while (reader.Read())
					{
						//属性赋值
						MySql_VideoInfo obj= Object2Model(reader);
						list.Add(obj);
					}
					reader.NextResult();
					rowCount = (int)Command.Parameters["@rowCount"].Value;
                }
				DisposeCommand();
                DisposeConnection();
				return list;
            }
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
		}
		#endregion


		#region 07 Proc__MySql_VideoInfo_BatchInsert

		/// <summary>
        /// 批量插入，必须先开启Mysql数据库的多条模式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
		public override int BatchInsert(IList<MySql_VideoInfo> list)
        {

			try
			{
				//必须先开启数据库的多条模式
				//INSERT INTO table (field1,field2,field3) VALUES ('a',"b","c"), ('a',"b","c"),('a',"b","c");
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO ");
				sb.Append(DataTableName);
				sb.Append(" (");

				sb.Append("v_id");	
				sb.Append(",");		
				sb.Append("v_c_id");	
				sb.Append(",");		
				sb.Append("v_c_name");	
				sb.Append(",");		
				sb.Append("v_titile");	
				sb.Append(",");		
				sb.Append("v_intro");	
				sb.Append(",");		
				sb.Append("v_coverImgSrc");	
				sb.Append(",");		
				sb.Append("v_playSrc");	
				sb.Append(",");		
				sb.Append("v_min_playSrc");	
				sb.Append(",");		
				sb.Append("v_timeLength");	
				sb.Append(",");		
				sb.Append("v_createTime");	
				sb.Append(",");		
				sb.Append("v_status");	
				sb.Append(",");		
				sb.Append("v_totalSecond");	
				sb.Append(") VALUES ");
				int _index=0;
				foreach(MySql_VideoInfo item in list)
				{
				sb.Append("(");
								sb.Append("\""+item.v_id+"\"");
									sb.Append(",");
										sb.Append(item.v_c_id);
									sb.Append(",");
										sb.Append("\""+item.v_c_name+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_titile+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_intro+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_coverImgSrc+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_playSrc+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_min_playSrc+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_timeLength+"\"");
									sb.Append(",");
										sb.Append("\""+item.v_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"\"");
									sb.Append(",");
										sb.Append(item.v_status);
									sb.Append(",");
										sb.Append(item.v_totalSecond);
									sb.Append(")");
					if(_index<list.Count-1)
					{
						sb.Append(",");
					}
						_index++;
				}
            
				string sql=sb.ToString();

				Command.CommandText=sql;
				Command.CommandTimeout=30;
				Command.CommandType= CommandType.Text;


				int returnValue = Command.ExecuteNonQuery();
				DisposeCommand();
				DisposeConnection();
				return returnValue;
			}
            catch (Exception e)
            {
                throw new Exception("MySql数据层："+e.Message);
            }
        }

		#endregion


		#region Object2Model

        public MySql_VideoInfo Object2Model(IDataReader reader)
        {
            MySql_VideoInfo obj = null;
            try
            {
                obj = new MySql_VideoInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.v_id = reader["v_id"] == DBNull.Value ? default(string) : (string)reader["v_id"];
				obj.v_c_id = reader["v_c_id"] == DBNull.Value ? default(int) : (int)reader["v_c_id"];
				obj.v_c_name = reader["v_c_name"] == DBNull.Value ? default(string) : (string)reader["v_c_name"];
				obj.v_titile = reader["v_titile"] == DBNull.Value ? default(string) : (string)reader["v_titile"];
				obj.v_intro = reader["v_intro"] == DBNull.Value ? default(string) : (string)reader["v_intro"];
				obj.v_coverImgSrc = reader["v_coverImgSrc"] == DBNull.Value ? default(string) : (string)reader["v_coverImgSrc"];
				obj.v_playSrc = reader["v_playSrc"] == DBNull.Value ? default(string) : (string)reader["v_playSrc"];
				obj.v_min_playSrc = reader["v_min_playSrc"] == DBNull.Value ? default(string) : (string)reader["v_min_playSrc"];
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
