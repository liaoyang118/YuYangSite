

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.XiaoShuo.DataAccess.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using DataAccess.Base;
using System.Configuration;
using System.Linq.Expressions;
using Site.Cars.DataAccess.Model;

namespace Site.Cars.DataAccess.Access
{


	[Serializable]
	public partial class Mongo_CarsCateAccess : Mongo_AccessBase<Mongo_CarsCate>,IDisposable
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
        public Mongo_CarsCateAccess(string dbName) 
        {
			DataTableName = "Mongo_CarsCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_CarsCateAccess()
        {
			DataTableName = "Mongo_CarsCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			 base.GetDatabase("Mongo_Cars");
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
        ~Mongo_CarsCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_CarsCate_Insert
		 public override string Insert(Mongo_CarsCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_CarsCate_Delete
		 public override int Delete(Expression<Func<Mongo_CarsCate,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_CarsCate>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_CarsCate_Update
		 public override int Update(Expression<Func<Mongo_CarsCate, bool>> filter,Mongo_CarsCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_CarsCate>(filter,Builders<Mongo_CarsCate>.Update.Set("Id",obj.Id).Set("CateName",obj.CateName));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_CarsCate_SelectObject
		 public override Mongo_CarsCate SelectObject(Expression<Func<Mongo_CarsCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
                Mongo_CarsCate obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_CarsCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_CarsCate> Select(Expression<Func<Mongo_CarsCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
                IList<Mongo_CarsCate> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_CarsCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_CarsCate> Select(Expression<Func<Mongo_CarsCate, bool>> filter,SortDefinition<Mongo_CarsCate> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
                IList<Mongo_CarsCate> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_CarsCate_SelectPage
		 public override IList<Mongo_CarsCate> SelectPage(SortDefinition<Mongo_CarsCate> order, Expression<Func<Mongo_CarsCate, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
                var result = collection.Find(filter).Sort(order);
                rowCount = (int)result.CountDocuments();

                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 07 BatchInsert

        public override void BatchInsert(IList<Mongo_CarsCate> list )
        {
            try
            {
                IMongoCollection<Mongo_CarsCate> collection = Database.GetCollection<Mongo_CarsCate>(DataTableName);
                collection.InsertMany(list);
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层：" + e.Message);
            }
        }

        #endregion

    }

	[Serializable]
	public partial class Mongo_CarsInfoAccess : Mongo_AccessBase<Mongo_CarsInfo>,IDisposable
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
        public Mongo_CarsInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_CarsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_CarsInfoAccess()
        {
			DataTableName = "Mongo_CarsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			 base.GetDatabase("Mongo_Cars");
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
        ~Mongo_CarsInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_CarsInfo_Insert
		 public override string Insert(Mongo_CarsInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_CarsInfo_Delete
		 public override int Delete(Expression<Func<Mongo_CarsInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_CarsInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_CarsInfo_Update
		 public override int Update(Expression<Func<Mongo_CarsInfo, bool>> filter,Mongo_CarsInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_CarsInfo>(filter,Builders<Mongo_CarsInfo>.Update.Set("Id",obj.Id).Set("FullName",obj.FullName).Set("FullNameCN",obj.FullNameCN).Set("Price",obj.Price).Set("PriceUnti",obj.PriceUnti).Set("Used",obj.Used).Set("Kilometres",obj.Kilometres).Set("Colour",obj.Colour).Set("Transmission",obj.Transmission).Set("Body",obj.Body).Set("BodyType",obj.BodyType).Set("DriveType",obj.DriveType).Set("Engine",obj.Engine).Set("ReleaseDate",obj.ReleaseDate).Set("BuildDate",obj.BuildDate).Set("ComplianceDate",obj.ComplianceDate).Set("FuelEconomyCombined",obj.FuelEconomyCombined).Set("TransmissionType",obj.TransmissionType).Set("AreaId",obj.AreaId).Set("CarsCateId",obj.CarsCateId).Set("CarsCoverSrc",obj.CarsCoverSrc));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_CarsInfo_SelectObject
		 public override Mongo_CarsInfo SelectObject(Expression<Func<Mongo_CarsInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
                Mongo_CarsInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_CarsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_CarsInfo> Select(Expression<Func<Mongo_CarsInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
                IList<Mongo_CarsInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_CarsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_CarsInfo> Select(Expression<Func<Mongo_CarsInfo, bool>> filter,SortDefinition<Mongo_CarsInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
                IList<Mongo_CarsInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_CarsInfo_SelectPage
		 public override IList<Mongo_CarsInfo> SelectPage(SortDefinition<Mongo_CarsInfo> order, Expression<Func<Mongo_CarsInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
                var result = collection.Find(filter).Sort(order);
                rowCount = (int)result.CountDocuments();

                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 07 BatchInsert

        public override void BatchInsert(IList<Mongo_CarsInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_CarsInfo> collection = Database.GetCollection<Mongo_CarsInfo>(DataTableName);
                collection.InsertMany(list);
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层：" + e.Message);
            }
        }

        #endregion

    }

	[Serializable]
	public partial class Mongo_WorldsAccess : Mongo_AccessBase<Mongo_Worlds>,IDisposable
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
        public Mongo_WorldsAccess(string dbName) 
        {
			DataTableName = "Mongo_Worlds";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_WorldsAccess()
        {
			DataTableName = "Mongo_Worlds";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Cars"].ToString();
			 base.GetDatabase("Mongo_Cars");
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
        ~Mongo_WorldsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_Worlds_Insert
		 public override string Insert(Mongo_Worlds obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_Worlds_Delete
		 public override int Delete(Expression<Func<Mongo_Worlds,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_Worlds>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_Worlds_Update
		 public override int Update(Expression<Func<Mongo_Worlds, bool>> filter,Mongo_Worlds obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_Worlds>(filter,Builders<Mongo_Worlds>.Update.Set("Id",obj.Id).Set("AreaId",obj.AreaId).Set("ParentId",obj.ParentId).Set("Name",obj.Name));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_Worlds_SelectObject
		 public override Mongo_Worlds SelectObject(Expression<Func<Mongo_Worlds, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
                Mongo_Worlds obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_Worlds_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Worlds> Select(Expression<Func<Mongo_Worlds, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
                IList<Mongo_Worlds> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_Worlds_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Worlds> Select(Expression<Func<Mongo_Worlds, bool>> filter,SortDefinition<Mongo_Worlds> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
                IList<Mongo_Worlds> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_Worlds_SelectPage
		 public override IList<Mongo_Worlds> SelectPage(SortDefinition<Mongo_Worlds> order, Expression<Func<Mongo_Worlds, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
                var result = collection.Find(filter).Sort(order);
                rowCount = (int)result.CountDocuments();

                return result.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 07 BatchInsert

        public override void BatchInsert(IList<Mongo_Worlds> list )
        {
            try
            {
                IMongoCollection<Mongo_Worlds> collection = Database.GetCollection<Mongo_Worlds>(DataTableName);
                collection.InsertMany(list);
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层：" + e.Message);
            }
        }

        #endregion

    }
}
