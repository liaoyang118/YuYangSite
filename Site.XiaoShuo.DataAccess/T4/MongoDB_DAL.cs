

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
using Site.XiaoShuo.DataAccess.Model;

namespace Site.XiaoShuo.DataAccess.Access
{


	[Serializable]
	public partial class Mongo_ChapterListAccess : Mongo_AccessBasePartial<Mongo_ChapterList>,IDisposable
    {
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
        public Mongo_ChapterListAccess(string dbName) 
        {
			DataTableNameFormat = "Mongo_ChapterList_T_{0}";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ChapterListAccess()
        {
			DataTableNameFormat = "Mongo_ChapterList_T_{0}";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_ChapterListAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ChapterList_Insert
		 public override string Insert(Mongo_ChapterList obj,int tableIndex)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ChapterList_Delete
		 public override int Delete(Expression<Func<Mongo_ChapterList,bool>> filter ,int tableIndex)
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
				DeleteResult result= collection.DeleteOne<Mongo_ChapterList>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ChapterList_Update
		 public override int Update(Expression<Func<Mongo_ChapterList, bool>> filter,Mongo_ChapterList obj,int tableIndex)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
				
				UpdateResult result= collection.UpdateOne<Mongo_ChapterList>(filter,Builders<Mongo_ChapterList>.Update.Set("Id",obj.Id).Set("F_ID",obj.F_ID).Set("ChapterName",obj.ChapterName).Set("ChapterIndex",obj.ChapterIndex).Set("ChapterContent",obj.ChapterContent).Set("UpdateTime",obj.UpdateTime).Set("ChapterSort",obj.ChapterSort));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ChapterList_SelectObject
		 public override Mongo_ChapterList SelectObject(Expression<Func<Mongo_ChapterList, bool>> filter ,int tableIndex)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
                Mongo_ChapterList obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ChapterList_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ChapterList> Select(Expression<Func<Mongo_ChapterList, bool>> filter ,int tableIndex)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
                IList<Mongo_ChapterList> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ChapterList_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ChapterList> Select(Expression<Func<Mongo_ChapterList, bool>> filter,SortDefinition<Mongo_ChapterList> order ,int tableIndex)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
                IList<Mongo_ChapterList> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ChapterList_SelectPage
		 public override IList<Mongo_ChapterList> SelectPage(SortDefinition<Mongo_ChapterList> order, Expression<Func<Mongo_ChapterList, bool>> filter,  int pageIndex, int pageSize, int tableIndex,out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
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

        public override void BatchInsert(IList<Mongo_ChapterList> list ,int tableIndex)
        {
            try
            {
                IMongoCollection<Mongo_ChapterList> collection = Database.GetCollection<Mongo_ChapterList>(string.Format(DataTableNameFormat,tableIndex));
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
	public partial class Mongo_ChapterVisitsAccess : Mongo_AccessBase<Mongo_ChapterVisits>,IDisposable
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
        public Mongo_ChapterVisitsAccess(string dbName) 
        {
			DataTableName = "Mongo_ChapterVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ChapterVisitsAccess()
        {
			DataTableName = "Mongo_ChapterVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_ChapterVisitsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ChapterVisits_Insert
		 public override string Insert(Mongo_ChapterVisits obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ChapterVisits_Delete
		 public override int Delete(Expression<Func<Mongo_ChapterVisits,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_ChapterVisits>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ChapterVisits_Update
		 public override int Update(Expression<Func<Mongo_ChapterVisits, bool>> filter,Mongo_ChapterVisits obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_ChapterVisits>(filter,Builders<Mongo_ChapterVisits>.Update.Set("Id",obj.Id).Set("IP",obj.IP).Set("OS",obj.OS).Set("Browser",obj.Browser).Set("Url",obj.Url).Set("Time",obj.Time));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ChapterVisits_SelectObject
		 public override Mongo_ChapterVisits SelectObject(Expression<Func<Mongo_ChapterVisits, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
                Mongo_ChapterVisits obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ChapterVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ChapterVisits> Select(Expression<Func<Mongo_ChapterVisits, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
                IList<Mongo_ChapterVisits> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ChapterVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ChapterVisits> Select(Expression<Func<Mongo_ChapterVisits, bool>> filter,SortDefinition<Mongo_ChapterVisits> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
                IList<Mongo_ChapterVisits> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ChapterVisits_SelectPage
		 public override IList<Mongo_ChapterVisits> SelectPage(SortDefinition<Mongo_ChapterVisits> order, Expression<Func<Mongo_ChapterVisits, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_ChapterVisits> list )
        {
            try
            {
                IMongoCollection<Mongo_ChapterVisits> collection = Database.GetCollection<Mongo_ChapterVisits>(DataTableName);
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
	public partial class Mongo_ContentCateAccess : Mongo_AccessBase<Mongo_ContentCate>,IDisposable
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
        public Mongo_ContentCateAccess(string dbName) 
        {
			DataTableName = "Mongo_ContentCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ContentCateAccess()
        {
			DataTableName = "Mongo_ContentCate";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_ContentCateAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ContentCate_Insert
		 public override string Insert(Mongo_ContentCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ContentCate_Delete
		 public override int Delete(Expression<Func<Mongo_ContentCate,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_ContentCate>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ContentCate_Update
		 public override int Update(Expression<Func<Mongo_ContentCate, bool>> filter,Mongo_ContentCate obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_ContentCate>(filter,Builders<Mongo_ContentCate>.Update.Set("Id",obj.Id).Set("CateName",obj.CateName));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ContentCate_SelectObject
		 public override Mongo_ContentCate SelectObject(Expression<Func<Mongo_ContentCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
                Mongo_ContentCate obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ContentCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ContentCate> Select(Expression<Func<Mongo_ContentCate, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
                IList<Mongo_ContentCate> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ContentCate_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ContentCate> Select(Expression<Func<Mongo_ContentCate, bool>> filter,SortDefinition<Mongo_ContentCate> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
                IList<Mongo_ContentCate> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ContentCate_SelectPage
		 public override IList<Mongo_ContentCate> SelectPage(SortDefinition<Mongo_ContentCate> order, Expression<Func<Mongo_ContentCate, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_ContentCate> list )
        {
            try
            {
                IMongoCollection<Mongo_ContentCate> collection = Database.GetCollection<Mongo_ContentCate>(DataTableName);
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
	public partial class Mongo_ErrorChapterAccess : Mongo_AccessBase<Mongo_ErrorChapter>,IDisposable
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
        public Mongo_ErrorChapterAccess(string dbName) 
        {
			DataTableName = "Mongo_ErrorChapter";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_ErrorChapterAccess()
        {
			DataTableName = "Mongo_ErrorChapter";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_ErrorChapterAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_ErrorChapter_Insert
		 public override string Insert(Mongo_ErrorChapter obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_ErrorChapter_Delete
		 public override int Delete(Expression<Func<Mongo_ErrorChapter,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_ErrorChapter>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_ErrorChapter_Update
		 public override int Update(Expression<Func<Mongo_ErrorChapter, bool>> filter,Mongo_ErrorChapter obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_ErrorChapter>(filter,Builders<Mongo_ErrorChapter>.Update.Set("Id",obj.Id).Set("F_Id",obj.F_Id).Set("Title",obj.Title).Set("ChapterName",obj.ChapterName).Set("ChapterUrl",obj.ChapterUrl).Set("ExceptionMessage",obj.ExceptionMessage).Set("DisposeStatus",obj.DisposeStatus).Set("C_C_Id",obj.C_C_Id).Set("RetryCount",obj.RetryCount));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_ErrorChapter_SelectObject
		 public override Mongo_ErrorChapter SelectObject(Expression<Func<Mongo_ErrorChapter, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
                Mongo_ErrorChapter obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_ErrorChapter_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ErrorChapter> Select(Expression<Func<Mongo_ErrorChapter, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
                IList<Mongo_ErrorChapter> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_ErrorChapter_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_ErrorChapter> Select(Expression<Func<Mongo_ErrorChapter, bool>> filter,SortDefinition<Mongo_ErrorChapter> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
                IList<Mongo_ErrorChapter> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_ErrorChapter_SelectPage
		 public override IList<Mongo_ErrorChapter> SelectPage(SortDefinition<Mongo_ErrorChapter> order, Expression<Func<Mongo_ErrorChapter, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_ErrorChapter> list )
        {
            try
            {
                IMongoCollection<Mongo_ErrorChapter> collection = Database.GetCollection<Mongo_ErrorChapter>(DataTableName);
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
	public partial class Mongo_FictionAccess : Mongo_AccessBase<Mongo_Fiction>,IDisposable
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
        public Mongo_FictionAccess(string dbName) 
        {
			DataTableName = "Mongo_Fiction";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_FictionAccess()
        {
			DataTableName = "Mongo_Fiction";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_FictionAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_Fiction_Insert
		 public override string Insert(Mongo_Fiction obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_Fiction_Delete
		 public override int Delete(Expression<Func<Mongo_Fiction,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_Fiction>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_Fiction_Update
		 public override int Update(Expression<Func<Mongo_Fiction, bool>> filter,Mongo_Fiction obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_Fiction>(filter,Builders<Mongo_Fiction>.Update.Set("Id",obj.Id).Set("Title",obj.Title).Set("Author",obj.Author).Set("Intro",obj.Intro).Set("CoverImage",obj.CoverImage).Set("C_C_ID",obj.C_C_ID).Set("LastUpdateChapter",obj.LastUpdateChapter).Set("LastUpdateTime",obj.LastUpdateTime).Set("CompleteState",obj.CompleteState).Set("LastChapterId",obj.LastChapterId));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_Fiction_SelectObject
		 public override Mongo_Fiction SelectObject(Expression<Func<Mongo_Fiction, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
                Mongo_Fiction obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_Fiction_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Fiction> Select(Expression<Func<Mongo_Fiction, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
                IList<Mongo_Fiction> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_Fiction_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_Fiction> Select(Expression<Func<Mongo_Fiction, bool>> filter,SortDefinition<Mongo_Fiction> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
                IList<Mongo_Fiction> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_Fiction_SelectPage
		 public override IList<Mongo_Fiction> SelectPage(SortDefinition<Mongo_Fiction> order, Expression<Func<Mongo_Fiction, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_Fiction> list )
        {
            try
            {
                IMongoCollection<Mongo_Fiction> collection = Database.GetCollection<Mongo_Fiction>(DataTableName);
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
	public partial class Mongo_FictionVisitsAccess : Mongo_AccessBase<Mongo_FictionVisits>,IDisposable
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
        public Mongo_FictionVisitsAccess(string dbName) 
        {
			DataTableName = "Mongo_FictionVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			base.GetDatabase(dbName);
        }

        public Mongo_FictionVisitsAccess()
        {
			DataTableName = "Mongo_FictionVisits";
			ConnectionStr = ConfigurationManager.ConnectionStrings["Mongo_XiaoShuo"].ToString();
			 base.GetDatabase("Mongo_XiaoShuo");
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
        ~Mongo_FictionVisitsAccess()
        {
            Dispose(false);
        }
        #endregion


        #region 01 Mongodb_Mongo_FictionVisits_Insert
		 public override string Insert(Mongo_FictionVisits obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
				collection.InsertOne(obj);
				return obj.Id.ToString();
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion
		
		#region 02 Mongodb_Mongo_FictionVisits_Delete
		 public override int Delete(Expression<Func<Mongo_FictionVisits,bool>> filter )
		 {
			try
			{ 
			
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
				DeleteResult result= collection.DeleteOne<Mongo_FictionVisits>(filter);
				return (int)result.DeletedCount;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 03 Mongodb_Mongo_FictionVisits_Update
		 public override int Update(Expression<Func<Mongo_FictionVisits, bool>> filter,Mongo_FictionVisits obj)
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
				
				UpdateResult result= collection.UpdateOne<Mongo_FictionVisits>(filter,Builders<Mongo_FictionVisits>.Update.Set("Id",obj.Id).Set("F_Id",obj.F_Id).Set("Visits",obj.Visits).Set("C_Id",obj.C_Id));
				int returnValue = (int)result.ModifiedCount;
                return returnValue;
			}
			catch(Exception e)
			{
				throw new Exception("Mongodb数据层："+e.Message);
			}
		}
		#endregion

		#region 04 Mongodb_Mongo_FictionVisits_SelectObject
		 public override Mongo_FictionVisits SelectObject(Expression<Func<Mongo_FictionVisits, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
                Mongo_FictionVisits obj = collection.Find(filter).FirstOrDefault();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion

		#region 05 Mongodb_Mongo_FictionVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_FictionVisits> Select(Expression<Func<Mongo_FictionVisits, bool>> filter )
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
                IList<Mongo_FictionVisits> list = collection.Find(filter).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion 

		#region 05 Mongodb_Mongo_FictionVisits_Select
		 /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
		 public override IList<Mongo_FictionVisits> Select(Expression<Func<Mongo_FictionVisits, bool>> filter,SortDefinition<Mongo_FictionVisits> order )
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
                IList<Mongo_FictionVisits> list = collection.Find(filter).Sort(order).ToList();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Mongodb数据层："+e.Message);
            }
		}
		#endregion



		#region 06 Mongodb_Mongo_FictionVisits_SelectPage
		 public override IList<Mongo_FictionVisits> SelectPage(SortDefinition<Mongo_FictionVisits> order, Expression<Func<Mongo_FictionVisits, bool>> filter,  int pageIndex, int pageSize, out int rowCount)
		 {
			try
			{ 
				IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
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

        public override void BatchInsert(IList<Mongo_FictionVisits> list )
        {
            try
            {
                IMongoCollection<Mongo_FictionVisits> collection = Database.GetCollection<Mongo_FictionVisits>(DataTableName);
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
