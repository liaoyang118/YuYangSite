 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using MongoDB.Driver;
using Site.Cars.DataAccess.Model;
using Site.Cars.DataAccess.Access;

namespace Site.Cars.DataAccess.Service
{

	public partial class Mongo_CarsCateService
    {

        #region 01 Mongo_CarsCate_Insert
		 public static string Insert(Mongo_CarsCate obj)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.Insert(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 Mongo_CarsCate_Delete
		 public static int Delete(Expression<Func<Mongo_CarsCate,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.Delete(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_CarsCate_Update
		 public static int Update(Expression<Func<Mongo_CarsCate, bool>> filter,Mongo_CarsCate obj)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.Update(filter,obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_CarsCate_SelectObject
		 public static Mongo_CarsCate SelectObject(Expression<Func<Mongo_CarsCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.SelectObject(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_CarsCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_CarsCate> Select(Expression<Func<Mongo_CarsCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.Select(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_CarsCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_CarsCate> Select(Expression<Func<Mongo_CarsCate, bool>> filter,SortDefinition<Mongo_CarsCate> order)
		 {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.Select(filter,order);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_CarsCate_SelectPage
		 public static IList<Mongo_CarsCate> SelectPage(SortDefinition<Mongo_CarsCate> order, Expression<Func<Mongo_CarsCate, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_CarsCateAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_CarsCate_BatchInsert
        public static void BatchInsert(IList<Mongo_CarsCate> list)
        {
			try
			{
				using (var access = new Mongo_CarsCateAccess())
				{
					access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class Mongo_CarsInfoService
    {

        #region 01 Mongo_CarsInfo_Insert
		 public static string Insert(Mongo_CarsInfo obj)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.Insert(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 Mongo_CarsInfo_Delete
		 public static int Delete(Expression<Func<Mongo_CarsInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.Delete(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_CarsInfo_Update
		 public static int Update(Expression<Func<Mongo_CarsInfo, bool>> filter,Mongo_CarsInfo obj)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.Update(filter,obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_CarsInfo_SelectObject
		 public static Mongo_CarsInfo SelectObject(Expression<Func<Mongo_CarsInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.SelectObject(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_CarsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_CarsInfo> Select(Expression<Func<Mongo_CarsInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.Select(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_CarsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_CarsInfo> Select(Expression<Func<Mongo_CarsInfo, bool>> filter,SortDefinition<Mongo_CarsInfo> order)
		 {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.Select(filter,order);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_CarsInfo_SelectPage
		 public static IList<Mongo_CarsInfo> SelectPage(SortDefinition<Mongo_CarsInfo> order, Expression<Func<Mongo_CarsInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_CarsInfoAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_CarsInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_CarsInfo> list)
        {
			try
			{
				using (var access = new Mongo_CarsInfoAccess())
				{
					access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class Mongo_WorldsService
    {

        #region 01 Mongo_Worlds_Insert
		 public static string Insert(Mongo_Worlds obj)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.Insert(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 Mongo_Worlds_Delete
		 public static int Delete(Expression<Func<Mongo_Worlds,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.Delete(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_Worlds_Update
		 public static int Update(Expression<Func<Mongo_Worlds, bool>> filter,Mongo_Worlds obj)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.Update(filter,obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_Worlds_SelectObject
		 public static Mongo_Worlds SelectObject(Expression<Func<Mongo_Worlds, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.SelectObject(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_Worlds_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Worlds> Select(Expression<Func<Mongo_Worlds, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.Select(filter);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_Worlds_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Worlds> Select(Expression<Func<Mongo_Worlds, bool>> filter,SortDefinition<Mongo_Worlds> order)
		 {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					return access.Select(filter,order);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_Worlds_SelectPage
		 public static IList<Mongo_Worlds> SelectPage(SortDefinition<Mongo_Worlds> order, Expression<Func<Mongo_Worlds, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_WorldsAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_Worlds_BatchInsert
        public static void BatchInsert(IList<Mongo_Worlds> list)
        {
			try
			{
				using (var access = new Mongo_WorldsAccess())
				{
					access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
}
