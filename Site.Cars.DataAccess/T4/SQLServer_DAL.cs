

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
using Site.Cars.DataAccess.Model;

namespace Site.Cars.DataAccess.Access
{


	[Serializable]
	public partial class CarsCateAccess : AccessBase<CarsCate>,IDisposable
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
        public CarsCateAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "CarsCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
        }

        public CarsCateAccess()
        {
            db = factory.Create("Cars");
			DataTableName = "CarsCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
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
        ~CarsCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_CarsCate_Insert
		 public override int Insert(CarsCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_Insert");
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
		
		#region 02 Proc_CarsCate_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_DeleteById");
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

		#region 03 Proc_CarsCate_Update
		 public override int Update(CarsCate obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_UpdateById");
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

		#region 04 Proc_CarsCate_SelectObject
		 public override CarsCate SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			CarsCate obj=null;
			
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

		#region 05 Proc_CarsCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<CarsCate> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<CarsCate> list= new List<CarsCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						CarsCate obj= Object2Model(reader);
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

		#region 06 Proc_CarsCate_SelectPage
		 public override IList<CarsCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsCate_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<CarsCate> list= new List<CarsCate>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						CarsCate obj= Object2Model(reader);
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

        public CarsCate Object2Model(IDataReader reader)
        {
            CarsCate obj = null;
            try
            {
                obj = new CarsCate();
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
	public partial class CarsInfoAccess : AccessBase<CarsInfo>,IDisposable
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
        public CarsInfoAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "CarsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
        }

        public CarsInfoAccess()
        {
            db = factory.Create("Cars");
			DataTableName = "CarsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
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
        ~CarsInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_CarsInfo_Insert
		 public override int Insert(CarsInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@FullName", DbType.String,obj.FullName);
			db.AddInParameter(dbCmd, "@FullNameCN", DbType.String,obj.FullNameCN);
			db.AddInParameter(dbCmd, "@Price", DbType.Decimal,obj.Price);
			db.AddInParameter(dbCmd, "@PriceUnti", DbType.String,obj.PriceUnti);
			db.AddInParameter(dbCmd, "@Used", DbType.Boolean,obj.Used);
			db.AddInParameter(dbCmd, "@Kilometres", DbType.Int32,obj.Kilometres);
			db.AddInParameter(dbCmd, "@Colour", DbType.String,obj.Colour);
			db.AddInParameter(dbCmd, "@Transmission", DbType.String,obj.Transmission);
			db.AddInParameter(dbCmd, "@Body", DbType.String,obj.Body);
			db.AddInParameter(dbCmd, "@BodyType", DbType.String,obj.BodyType);
			db.AddInParameter(dbCmd, "@DriveType", DbType.String,obj.DriveType);
			db.AddInParameter(dbCmd, "@Engine", DbType.String,obj.Engine);
			db.AddInParameter(dbCmd, "@ReleaseDate", DbType.String,obj.ReleaseDate);
			db.AddInParameter(dbCmd, "@BuildDate", DbType.String,obj.BuildDate);
			db.AddInParameter(dbCmd, "@ComplianceDate", DbType.String,obj.ComplianceDate);
			db.AddInParameter(dbCmd, "@FuelEconomyCombined", DbType.String,obj.FuelEconomyCombined);
			db.AddInParameter(dbCmd, "@TransmissionType", DbType.String,obj.TransmissionType);
			db.AddInParameter(dbCmd, "@AreaId", DbType.String,obj.AreaId);
			db.AddInParameter(dbCmd, "@CarsCateId", DbType.String,obj.CarsCateId);
			db.AddInParameter(dbCmd, "@CarsCoverSrc", DbType.String,obj.CarsCoverSrc);
						
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
		
		#region 02 Proc_CarsInfo_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_DeleteById");
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

		#region 03 Proc_CarsInfo_Update
		 public override int Update(CarsInfo obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@FullName", DbType.String,obj.FullName);
			db.AddInParameter(dbCmd, "@FullNameCN", DbType.String,obj.FullNameCN);
			db.AddInParameter(dbCmd, "@Price", DbType.Decimal,obj.Price);
			db.AddInParameter(dbCmd, "@PriceUnti", DbType.String,obj.PriceUnti);
			db.AddInParameter(dbCmd, "@Used", DbType.Boolean,obj.Used);
			db.AddInParameter(dbCmd, "@Kilometres", DbType.Int32,obj.Kilometres);
			db.AddInParameter(dbCmd, "@Colour", DbType.String,obj.Colour);
			db.AddInParameter(dbCmd, "@Transmission", DbType.String,obj.Transmission);
			db.AddInParameter(dbCmd, "@Body", DbType.String,obj.Body);
			db.AddInParameter(dbCmd, "@BodyType", DbType.String,obj.BodyType);
			db.AddInParameter(dbCmd, "@DriveType", DbType.String,obj.DriveType);
			db.AddInParameter(dbCmd, "@Engine", DbType.String,obj.Engine);
			db.AddInParameter(dbCmd, "@ReleaseDate", DbType.String,obj.ReleaseDate);
			db.AddInParameter(dbCmd, "@BuildDate", DbType.String,obj.BuildDate);
			db.AddInParameter(dbCmd, "@ComplianceDate", DbType.String,obj.ComplianceDate);
			db.AddInParameter(dbCmd, "@FuelEconomyCombined", DbType.String,obj.FuelEconomyCombined);
			db.AddInParameter(dbCmd, "@TransmissionType", DbType.String,obj.TransmissionType);
			db.AddInParameter(dbCmd, "@AreaId", DbType.String,obj.AreaId);
			db.AddInParameter(dbCmd, "@CarsCateId", DbType.String,obj.CarsCateId);
			db.AddInParameter(dbCmd, "@CarsCoverSrc", DbType.String,obj.CarsCoverSrc);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_CarsInfo_SelectObject
		 public override CarsInfo SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			CarsInfo obj=null;
			
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

		#region 05 Proc_CarsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<CarsInfo> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<CarsInfo> list= new List<CarsInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						CarsInfo obj= Object2Model(reader);
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

		#region 06 Proc_CarsInfo_SelectPage
		 public override IList<CarsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_CarsInfo_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<CarsInfo> list= new List<CarsInfo>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						CarsInfo obj= Object2Model(reader);
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

        public CarsInfo Object2Model(IDataReader reader)
        {
            CarsInfo obj = null;
            try
            {
                obj = new CarsInfo();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.FullName = reader["FullName"] == DBNull.Value ? default(string) : (string)reader["FullName"];
				obj.FullNameCN = reader["FullNameCN"] == DBNull.Value ? default(string) : (string)reader["FullNameCN"];
				obj.Price = reader["Price"] == DBNull.Value ? default(decimal) : (decimal)reader["Price"];
				obj.PriceUnti = reader["PriceUnti"] == DBNull.Value ? default(string) : (string)reader["PriceUnti"];
				obj.Used = reader["Used"] == DBNull.Value ? default(bool) : (bool)reader["Used"];
				obj.Kilometres = reader["Kilometres"] == DBNull.Value ? default(int) : (int)reader["Kilometres"];
				obj.Colour = reader["Colour"] == DBNull.Value ? default(string) : (string)reader["Colour"];
				obj.Transmission = reader["Transmission"] == DBNull.Value ? default(string) : (string)reader["Transmission"];
				obj.Body = reader["Body"] == DBNull.Value ? default(string) : (string)reader["Body"];
				obj.BodyType = reader["BodyType"] == DBNull.Value ? default(string) : (string)reader["BodyType"];
				obj.DriveType = reader["DriveType"] == DBNull.Value ? default(string) : (string)reader["DriveType"];
				obj.Engine = reader["Engine"] == DBNull.Value ? default(string) : (string)reader["Engine"];
				obj.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? default(string) : (string)reader["ReleaseDate"];
				obj.BuildDate = reader["BuildDate"] == DBNull.Value ? default(string) : (string)reader["BuildDate"];
				obj.ComplianceDate = reader["ComplianceDate"] == DBNull.Value ? default(string) : (string)reader["ComplianceDate"];
				obj.FuelEconomyCombined = reader["FuelEconomyCombined"] == DBNull.Value ? default(string) : (string)reader["FuelEconomyCombined"];
				obj.TransmissionType = reader["TransmissionType"] == DBNull.Value ? default(string) : (string)reader["TransmissionType"];
				obj.AreaId = reader["AreaId"] == DBNull.Value ? default(string) : (string)reader["AreaId"];
				obj.CarsCateId = reader["CarsCateId"] == DBNull.Value ? default(string) : (string)reader["CarsCateId"];
				obj.CarsCoverSrc = reader["CarsCoverSrc"] == DBNull.Value ? default(string) : (string)reader["CarsCoverSrc"];
				
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
	public partial class WorldsAccess : AccessBase<Worlds>,IDisposable
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
        public WorldsAccess(string configName)
        {
			db = factory.Create(configName);
			DataTableName = "Worlds";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
        }

        public WorldsAccess()
        {
            db = factory.Create("Cars");
			DataTableName = "Worlds";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Cars"].ToString();
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
        ~WorldsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Proc_Worlds_Insert
		 public override int Insert(Worlds obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_Insert");
			db.AddOutParameter(dbCmd, "@Id", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@AreaId", DbType.Int32,obj.AreaId);
			db.AddInParameter(dbCmd, "@ParentId", DbType.Int32,obj.ParentId);
			db.AddInParameter(dbCmd, "@Name", DbType.String,obj.Name);
						
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
		
		#region 02 Proc_Worlds_Delete
		 public override int Delete(int id)
		 {
			try
			{ 
			
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_DeleteById");
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

		#region 03 Proc_Worlds_Update
		 public override int Update(Worlds obj)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_UpdateById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,obj.Id);
			db.AddInParameter(dbCmd, "@AreaId", DbType.Int32,obj.AreaId);
			db.AddInParameter(dbCmd, "@ParentId", DbType.Int32,obj.ParentId);
			db.AddInParameter(dbCmd, "@Name", DbType.String,obj.Name);
			
			
				int returnValue = db.ExecuteNonQuery(dbCmd);
				return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Proc_Worlds_SelectObject
		 public override Worlds SelectObject(int id)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_SelectById");
			db.AddInParameter(dbCmd, "@Id", DbType.Int32,id);
			
			Worlds obj=null;
			
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

		#region 05 Proc_Worlds_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public override IList<Worlds> Select(string whereStr)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_SelectList");
			db.AddInParameter(dbCmd, "@whereStr", DbType.String,whereStr);
						IList<Worlds> list= new List<Worlds>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Worlds obj= Object2Model(reader);
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

		#region 06 Proc_Worlds_SelectPage
		 public override IList<Worlds> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
			DbCommand dbCmd = db.GetStoredProcCommand("Proc_Worlds_SelectPage");
			db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32,4);
			db.AddInParameter(dbCmd, "@cloumns", DbType.String,cloumns);
			db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32,pageIndex);
			db.AddInParameter(dbCmd, "@pageSize", DbType.Int32,pageSize);
			db.AddInParameter(dbCmd, "@orderBy", DbType.String,order);
			db.AddInParameter(dbCmd, "@where", DbType.String,whereStr);
			
			List<Worlds> list= new List<Worlds>();
			
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						//属性赋值
						Worlds obj= Object2Model(reader);
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

        public Worlds Object2Model(IDataReader reader)
        {
            Worlds obj = null;
            try
            {
                obj = new Worlds();
				obj.Id = reader["Id"] == DBNull.Value ? default(int) : (int)reader["Id"];
				obj.AreaId = reader["AreaId"] == DBNull.Value ? default(int) : (int)reader["AreaId"];
				obj.ParentId = reader["ParentId"] == DBNull.Value ? default(int) : (int)reader["ParentId"];
				obj.Name = reader["Name"] == DBNull.Value ? default(string) : (string)reader["Name"];
				
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
