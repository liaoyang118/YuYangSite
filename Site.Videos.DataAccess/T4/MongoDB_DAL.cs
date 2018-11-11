

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
using Site.Videos.DataAccess.Model;

namespace Site.Videos.DataAccess.Access
{


	[Serializable]
	public partial class Mongo_ActiveAccountInfoAccess : Mongo_AccessBase<Mongo_ActiveAccountInfo>,IDisposable
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
        public Mongo_ActiveAccountInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_ActiveAccountInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ActiveAccountInfoAccess()
        {
			DataTableName = "Mongo_ActiveAccountInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_ActiveAccountInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ActiveAccountInfo_Insert
		 public override string Insert(Mongo_ActiveAccountInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ActiveAccountInfo_Delete
		 public override int Delete(Expression<Func<Mongo_ActiveAccountInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_ActiveAccountInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ActiveAccountInfo_Update
		 public override int Update(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter,Mongo_ActiveAccountInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_ActiveAccountInfo>(filter,Builders<Mongo_ActiveAccountInfo>.Update.Set("Id",obj.Id).Set("GUID",obj.GUID).Set("Account",obj.Account).Set("TimeSpan",obj.TimeSpan).Set("Token",obj.Token).Set("IsActive",obj.IsActive).Set("ActiveTime",obj.ActiveTime).Set("CreateTime",obj.CreateTime));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ActiveAccountInfo_SelectObject
		 public override Mongo_ActiveAccountInfo SelectObject(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
                Mongo_ActiveAccountInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ActiveAccountInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ActiveAccountInfo> Select(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
                IList<Mongo_ActiveAccountInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ActiveAccountInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ActiveAccountInfo> Select(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter,SortDefinition<Mongo_ActiveAccountInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
                IList<Mongo_ActiveAccountInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ActiveAccountInfo_SelectPage
		 public override IList<Mongo_ActiveAccountInfo> SelectPage(SortDefinition<Mongo_ActiveAccountInfo> order, Expression<Func<Mongo_ActiveAccountInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_ActiveAccountInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_ActiveAccountInfo> collection = Database.GetCollection<Mongo_ActiveAccountInfo>(DataTableName);
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
	public partial class Mongo_AdvertisingInfoAccess : Mongo_AccessBase<Mongo_AdvertisingInfo>,IDisposable
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
        public Mongo_AdvertisingInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_AdvertisingInfoAccess()
        {
			DataTableName = "Mongo_AdvertisingInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_AdvertisingInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_AdvertisingInfo_Insert
		 public override string Insert(Mongo_AdvertisingInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_AdvertisingInfo_Delete
		 public override int Delete(Expression<Func<Mongo_AdvertisingInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_AdvertisingInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_AdvertisingInfo_Update
		 public override int Update(Expression<Func<Mongo_AdvertisingInfo, bool>> filter,Mongo_AdvertisingInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_AdvertisingInfo>(filter,Builders<Mongo_AdvertisingInfo>.Update.Set("Id",obj.Id).Set("a_id",obj.a_id).Set("a_name",obj.a_name).Set("a_type",obj.a_type).Set("a_src",obj.a_src).Set("a_second",obj.a_second).Set("a_status",obj.a_status));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_AdvertisingInfo_SelectObject
		 public override Mongo_AdvertisingInfo SelectObject(Expression<Func<Mongo_AdvertisingInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
                Mongo_AdvertisingInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_AdvertisingInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_AdvertisingInfo> Select(Expression<Func<Mongo_AdvertisingInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
                IList<Mongo_AdvertisingInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_AdvertisingInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_AdvertisingInfo> Select(Expression<Func<Mongo_AdvertisingInfo, bool>> filter,SortDefinition<Mongo_AdvertisingInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
                IList<Mongo_AdvertisingInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_AdvertisingInfo_SelectPage
		 public override IList<Mongo_AdvertisingInfo> SelectPage(SortDefinition<Mongo_AdvertisingInfo> order, Expression<Func<Mongo_AdvertisingInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_AdvertisingInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_AdvertisingInfo> collection = Database.GetCollection<Mongo_AdvertisingInfo>(DataTableName);
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
	public partial class Mongo_ComboInfoAccess : Mongo_AccessBase<Mongo_ComboInfo>,IDisposable
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
        public Mongo_ComboInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ComboInfoAccess()
        {
			DataTableName = "Mongo_ComboInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_ComboInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ComboInfo_Insert
		 public override string Insert(Mongo_ComboInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ComboInfo_Delete
		 public override int Delete(Expression<Func<Mongo_ComboInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_ComboInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ComboInfo_Update
		 public override int Update(Expression<Func<Mongo_ComboInfo, bool>> filter,Mongo_ComboInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_ComboInfo>(filter,Builders<Mongo_ComboInfo>.Update.Set("Id",obj.Id).Set("c_id",obj.c_id).Set("c_title",obj.c_title).Set("c_intro",obj.c_intro).Set("c_num",obj.c_num).Set("c_days",obj.c_days).Set("c_status",obj.c_status));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ComboInfo_SelectObject
		 public override Mongo_ComboInfo SelectObject(Expression<Func<Mongo_ComboInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
                Mongo_ComboInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ComboInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ComboInfo> Select(Expression<Func<Mongo_ComboInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
                IList<Mongo_ComboInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ComboInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ComboInfo> Select(Expression<Func<Mongo_ComboInfo, bool>> filter,SortDefinition<Mongo_ComboInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
                IList<Mongo_ComboInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ComboInfo_SelectPage
		 public override IList<Mongo_ComboInfo> SelectPage(SortDefinition<Mongo_ComboInfo> order, Expression<Func<Mongo_ComboInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_ComboInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_ComboInfo> collection = Database.GetCollection<Mongo_ComboInfo>(DataTableName);
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
	public partial class Mongo_NoticeInfoAccess : Mongo_AccessBase<Mongo_NoticeInfo>,IDisposable
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
        public Mongo_NoticeInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_NoticeInfoAccess()
        {
			DataTableName = "Mongo_NoticeInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_NoticeInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_NoticeInfo_Insert
		 public override string Insert(Mongo_NoticeInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_NoticeInfo_Delete
		 public override int Delete(Expression<Func<Mongo_NoticeInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_NoticeInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_NoticeInfo_Update
		 public override int Update(Expression<Func<Mongo_NoticeInfo, bool>> filter,Mongo_NoticeInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_NoticeInfo>(filter,Builders<Mongo_NoticeInfo>.Update.Set("Id",obj.Id).Set("n_id",obj.n_id).Set("n_title",obj.n_title).Set("n_content",obj.n_content).Set("n_beginTime",obj.n_beginTime).Set("n_endTime",obj.n_endTime).Set("n_status",obj.n_status).Set("n_createTime",obj.n_createTime));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_NoticeInfo_SelectObject
		 public override Mongo_NoticeInfo SelectObject(Expression<Func<Mongo_NoticeInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
                Mongo_NoticeInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_NoticeInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_NoticeInfo> Select(Expression<Func<Mongo_NoticeInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
                IList<Mongo_NoticeInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_NoticeInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_NoticeInfo> Select(Expression<Func<Mongo_NoticeInfo, bool>> filter,SortDefinition<Mongo_NoticeInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
                IList<Mongo_NoticeInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_NoticeInfo_SelectPage
		 public override IList<Mongo_NoticeInfo> SelectPage(SortDefinition<Mongo_NoticeInfo> order, Expression<Func<Mongo_NoticeInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_NoticeInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_NoticeInfo> collection = Database.GetCollection<Mongo_NoticeInfo>(DataTableName);
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
	public partial class Mongo_RechargeRecoderAccess : Mongo_AccessBase<Mongo_RechargeRecoder>,IDisposable
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
        public Mongo_RechargeRecoderAccess(string dbName) 
        {
			DataTableName = "Mongo_RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_RechargeRecoderAccess()
        {
			DataTableName = "Mongo_RechargeRecoder";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_RechargeRecoderAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_RechargeRecoder_Insert
		 public override string Insert(Mongo_RechargeRecoder obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_RechargeRecoder_Delete
		 public override int Delete(Expression<Func<Mongo_RechargeRecoder,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_RechargeRecoder>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_RechargeRecoder_Update
		 public override int Update(Expression<Func<Mongo_RechargeRecoder, bool>> filter,Mongo_RechargeRecoder obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_RechargeRecoder>(filter,Builders<Mongo_RechargeRecoder>.Update.Set("Id",obj.Id).Set("r_id",obj.r_id).Set("r_u_id",obj.r_u_id).Set("r_c_id",obj.r_c_id).Set("r_c_title",obj.r_c_title).Set("r_money",obj.r_money).Set("r_c_days",obj.r_c_days).Set("r_createTime",obj.r_createTime).Set("r_u_expriseTime",obj.r_u_expriseTime));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_RechargeRecoder_SelectObject
		 public override Mongo_RechargeRecoder SelectObject(Expression<Func<Mongo_RechargeRecoder, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
                Mongo_RechargeRecoder obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_RechargeRecoder_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_RechargeRecoder> Select(Expression<Func<Mongo_RechargeRecoder, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
                IList<Mongo_RechargeRecoder> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_RechargeRecoder_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_RechargeRecoder> Select(Expression<Func<Mongo_RechargeRecoder, bool>> filter,SortDefinition<Mongo_RechargeRecoder> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
                IList<Mongo_RechargeRecoder> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_RechargeRecoder_SelectPage
		 public override IList<Mongo_RechargeRecoder> SelectPage(SortDefinition<Mongo_RechargeRecoder> order, Expression<Func<Mongo_RechargeRecoder, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_RechargeRecoder> list )
        {
            try
            {
                IMongoCollection<Mongo_RechargeRecoder> collection = Database.GetCollection<Mongo_RechargeRecoder>(DataTableName);
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
	public partial class Mongo_SendMailLogAccess : Mongo_AccessBase<Mongo_SendMailLog>,IDisposable
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
        public Mongo_SendMailLogAccess(string dbName) 
        {
			DataTableName = "Mongo_SendMailLog";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_SendMailLogAccess()
        {
			DataTableName = "Mongo_SendMailLog";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_SendMailLogAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_SendMailLog_Insert
		 public override string Insert(Mongo_SendMailLog obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_SendMailLog_Delete
		 public override int Delete(Expression<Func<Mongo_SendMailLog,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_SendMailLog>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_SendMailLog_Update
		 public override int Update(Expression<Func<Mongo_SendMailLog, bool>> filter,Mongo_SendMailLog obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_SendMailLog>(filter,Builders<Mongo_SendMailLog>.Update.Set("Id",obj.Id).Set("Email",obj.Email).Set("Title",obj.Title).Set("SendTime",obj.SendTime).Set("SendContent",obj.SendContent).Set("IsSuccess",obj.IsSuccess).Set("Remark",obj.Remark).Set("CreateTime",obj.CreateTime));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_SendMailLog_SelectObject
		 public override Mongo_SendMailLog SelectObject(Expression<Func<Mongo_SendMailLog, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
                Mongo_SendMailLog obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_SendMailLog_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_SendMailLog> Select(Expression<Func<Mongo_SendMailLog, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
                IList<Mongo_SendMailLog> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_SendMailLog_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_SendMailLog> Select(Expression<Func<Mongo_SendMailLog, bool>> filter,SortDefinition<Mongo_SendMailLog> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
                IList<Mongo_SendMailLog> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_SendMailLog_SelectPage
		 public override IList<Mongo_SendMailLog> SelectPage(SortDefinition<Mongo_SendMailLog> order, Expression<Func<Mongo_SendMailLog, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_SendMailLog> list )
        {
            try
            {
                IMongoCollection<Mongo_SendMailLog> collection = Database.GetCollection<Mongo_SendMailLog>(DataTableName);
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
	public partial class Mongo_UserInfoAccess : Mongo_AccessBase<Mongo_UserInfo>,IDisposable
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
        public Mongo_UserInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_UserInfoAccess()
        {
			DataTableName = "Mongo_UserInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_UserInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_UserInfo_Insert
		 public override string Insert(Mongo_UserInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_UserInfo_Delete
		 public override int Delete(Expression<Func<Mongo_UserInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_UserInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_UserInfo_Update
		 public override int Update(Expression<Func<Mongo_UserInfo, bool>> filter,Mongo_UserInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_UserInfo>(filter,Builders<Mongo_UserInfo>.Update.Set("Id",obj.Id).Set("u_gid",obj.u_gid).Set("u_name",obj.u_name).Set("u_pwd",obj.u_pwd).Set("u_level",obj.u_level).Set("u_expriseTime",obj.u_expriseTime).Set("u_regTime",obj.u_regTime).Set("u_status",obj.u_status));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_UserInfo_SelectObject
		 public override Mongo_UserInfo SelectObject(Expression<Func<Mongo_UserInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
                Mongo_UserInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_UserInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_UserInfo> Select(Expression<Func<Mongo_UserInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
                IList<Mongo_UserInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_UserInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_UserInfo> Select(Expression<Func<Mongo_UserInfo, bool>> filter,SortDefinition<Mongo_UserInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
                IList<Mongo_UserInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_UserInfo_SelectPage
		 public override IList<Mongo_UserInfo> SelectPage(SortDefinition<Mongo_UserInfo> order, Expression<Func<Mongo_UserInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_UserInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_UserInfo> collection = Database.GetCollection<Mongo_UserInfo>(DataTableName);
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
	public partial class Mongo_UserVisitsInfoAccess : Mongo_AccessBase<Mongo_UserVisitsInfo>,IDisposable
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
        public Mongo_UserVisitsInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_UserVisitsInfoAccess()
        {
			DataTableName = "Mongo_UserVisitsInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_UserVisitsInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_UserVisitsInfo_Insert
		 public override string Insert(Mongo_UserVisitsInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_UserVisitsInfo_Delete
		 public override int Delete(Expression<Func<Mongo_UserVisitsInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_UserVisitsInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_UserVisitsInfo_Update
		 public override int Update(Expression<Func<Mongo_UserVisitsInfo, bool>> filter,Mongo_UserVisitsInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_UserVisitsInfo>(filter,Builders<Mongo_UserVisitsInfo>.Update.Set("Id",obj.Id).Set("u_id",obj.u_id).Set("v_id",obj.v_id).Set("v_ip",obj.v_ip).Set("platform",obj.platform).Set("v_url",obj.v_url).Set("v_time",obj.v_time));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_UserVisitsInfo_SelectObject
		 public override Mongo_UserVisitsInfo SelectObject(Expression<Func<Mongo_UserVisitsInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
                Mongo_UserVisitsInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_UserVisitsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_UserVisitsInfo> Select(Expression<Func<Mongo_UserVisitsInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
                IList<Mongo_UserVisitsInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_UserVisitsInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_UserVisitsInfo> Select(Expression<Func<Mongo_UserVisitsInfo, bool>> filter,SortDefinition<Mongo_UserVisitsInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
                IList<Mongo_UserVisitsInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_UserVisitsInfo_SelectPage
		 public override IList<Mongo_UserVisitsInfo> SelectPage(SortDefinition<Mongo_UserVisitsInfo> order, Expression<Func<Mongo_UserVisitsInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_UserVisitsInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_UserVisitsInfo> collection = Database.GetCollection<Mongo_UserVisitsInfo>(DataTableName);
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
	public partial class Mongo_VideoCateAccess : Mongo_AccessBase<Mongo_VideoCate>,IDisposable
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
        public Mongo_VideoCateAccess(string dbName) 
        {
			DataTableName = "Mongo_VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_VideoCateAccess()
        {
			DataTableName = "Mongo_VideoCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_VideoCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_VideoCate_Insert
		 public override string Insert(Mongo_VideoCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_VideoCate_Delete
		 public override int Delete(Expression<Func<Mongo_VideoCate,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_VideoCate>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_VideoCate_Update
		 public override int Update(Expression<Func<Mongo_VideoCate, bool>> filter,Mongo_VideoCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_VideoCate>(filter,Builders<Mongo_VideoCate>.Update.Set("c_id",obj.c_id).Set("c_name",obj.c_name));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_VideoCate_SelectObject
		 public override Mongo_VideoCate SelectObject(Expression<Func<Mongo_VideoCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
                Mongo_VideoCate obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_VideoCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_VideoCate> Select(Expression<Func<Mongo_VideoCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
                IList<Mongo_VideoCate> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_VideoCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_VideoCate> Select(Expression<Func<Mongo_VideoCate, bool>> filter,SortDefinition<Mongo_VideoCate> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
                IList<Mongo_VideoCate> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_VideoCate_SelectPage
		 public override IList<Mongo_VideoCate> SelectPage(SortDefinition<Mongo_VideoCate> order, Expression<Func<Mongo_VideoCate, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_VideoCate> list )
        {
            try
            {
                IMongoCollection<Mongo_VideoCate> collection = Database.GetCollection<Mongo_VideoCate>(DataTableName);
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
	public partial class Mongo_VideoInfoAccess : Mongo_AccessBase<Mongo_VideoInfo>,IDisposable
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
        public Mongo_VideoInfoAccess(string dbName) 
        {
			DataTableName = "Mongo_VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_VideoInfoAccess()
        {
			DataTableName = "Mongo_VideoInfo";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_Video"].ToString();
			 base.GetDatabase("Mongo_Video");
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
        ~Mongo_VideoInfoAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_VideoInfo_Insert
		 public override string Insert(Mongo_VideoInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_VideoInfo_Delete
		 public override int Delete(Expression<Func<Mongo_VideoInfo,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_VideoInfo>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_VideoInfo_Update
		 public override int Update(Expression<Func<Mongo_VideoInfo, bool>> filter,Mongo_VideoInfo obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_VideoInfo>(filter,Builders<Mongo_VideoInfo>.Update.Set("Id",obj.Id).Set("v_id",obj.v_id).Set("v_c_id",obj.v_c_id).Set("v_c_name",obj.v_c_name).Set("v_titile",obj.v_titile).Set("v_intro",obj.v_intro).Set("v_coverImgSrc",obj.v_coverImgSrc).Set("v_playSrc",obj.v_playSrc).Set("v_min_playSrc",obj.v_min_playSrc).Set("v_timeLength",obj.v_timeLength).Set("v_createTime",obj.v_createTime).Set("v_status",obj.v_status).Set("v_totalSecond",obj.v_totalSecond));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_VideoInfo_SelectObject
		 public override Mongo_VideoInfo SelectObject(Expression<Func<Mongo_VideoInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
                Mongo_VideoInfo obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_VideoInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_VideoInfo> Select(Expression<Func<Mongo_VideoInfo, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
                IList<Mongo_VideoInfo> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_VideoInfo_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_VideoInfo> Select(Expression<Func<Mongo_VideoInfo, bool>> filter,SortDefinition<Mongo_VideoInfo> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
                IList<Mongo_VideoInfo> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_VideoInfo_SelectPage
		 public override IList<Mongo_VideoInfo> SelectPage(SortDefinition<Mongo_VideoInfo> order, Expression<Func<Mongo_VideoInfo, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_VideoInfo> list )
        {
            try
            {
                IMongoCollection<Mongo_VideoInfo> collection = Database.GetCollection<Mongo_VideoInfo>(DataTableName);
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
