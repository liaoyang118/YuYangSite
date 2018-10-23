 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.Cars.DataAccess.Model;
using Site.Cars.DataAccess.Access;

namespace Site.Cars.DataAccess.Service
{

	public partial class CarsCateService
    {

        #region 01 CarsCate_Insert
		 public static int Insert(CarsCate obj)
		 {
			try
			{
				using (var access = new CarsCateAccess())
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
		
		#region 02 CarsCate_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new CarsCateAccess())
				{
					return access.Delete(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 CarsCate_Update
		 public static int Update(CarsCate obj)
		 {
			try
			{
				using (var access = new CarsCateAccess())
				{
					return access.Update(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 CarsCate_SelectObject
		 public static CarsCate SelectObject(int id)
		 {
			try
			{
				using (var access = new CarsCateAccess())
				{
					return access.SelectObject(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 CarsCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<CarsCate> Select(string whereStr)
		 {
			try
			{
				using (var access = new CarsCateAccess())
				{
					return access.Select(whereStr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 CarsCate_SelectPage
		 public static IList<CarsCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new CarsCateAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 CarsCate_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<CarsCate> list,int count)
        {
			try
			{
				using (var access = new CarsCateAccess())
				{
					return access.SqlBulkCopyBatchInsert(list, count);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class CarsInfoService
    {

        #region 01 CarsInfo_Insert
		 public static int Insert(CarsInfo obj)
		 {
			try
			{
				using (var access = new CarsInfoAccess())
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
		
		#region 02 CarsInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new CarsInfoAccess())
				{
					return access.Delete(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 CarsInfo_Update
		 public static int Update(CarsInfo obj)
		 {
			try
			{
				using (var access = new CarsInfoAccess())
				{
					return access.Update(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 CarsInfo_SelectObject
		 public static CarsInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new CarsInfoAccess())
				{
					return access.SelectObject(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 CarsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<CarsInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new CarsInfoAccess())
				{
					return access.Select(whereStr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 CarsInfo_SelectPage
		 public static IList<CarsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new CarsInfoAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 CarsInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<CarsInfo> list,int count)
        {
			try
			{
				using (var access = new CarsInfoAccess())
				{
					return access.SqlBulkCopyBatchInsert(list, count);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class WorldsService
    {

        #region 01 Worlds_Insert
		 public static int Insert(Worlds obj)
		 {
			try
			{
				using (var access = new WorldsAccess())
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
		
		#region 02 Worlds_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new WorldsAccess())
				{
					return access.Delete(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Worlds_Update
		 public static int Update(Worlds obj)
		 {
			try
			{
				using (var access = new WorldsAccess())
				{
					return access.Update(obj);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Worlds_SelectObject
		 public static Worlds SelectObject(int id)
		 {
			try
			{
				using (var access = new WorldsAccess())
				{
					return access.SelectObject(id);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Worlds_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Worlds> Select(string whereStr)
		 {
			try
			{
				using (var access = new WorldsAccess())
				{
					return access.Select(whereStr);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 Worlds_SelectPage
		 public static IList<Worlds> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new WorldsAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Worlds_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<Worlds> list,int count)
        {
			try
			{
				using (var access = new WorldsAccess())
				{
					return access.SqlBulkCopyBatchInsert(list, count);
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
