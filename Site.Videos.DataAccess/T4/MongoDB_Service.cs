 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using MongoDB.Driver;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Access;

namespace Site.Videos.DataAccess.Service
{

	public partial class Mongo_ActiveAccountInfoService
    {

        #region 01 Mongo_ActiveAccountInfo_Insert
		 public static string Insert(Mongo_ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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
		
		#region 02 Mongo_ActiveAccountInfo_Delete
		 public static int Delete(Expression<Func<Mongo_ActiveAccountInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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

		#region 03 Mongo_ActiveAccountInfo_Update
		 public static int Update(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter,Mongo_ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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

		#region 04 Mongo_ActiveAccountInfo_SelectObject
		 public static Mongo_ActiveAccountInfo SelectObject(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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

		#region 05 Mongo_ActiveAccountInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ActiveAccountInfo> Select(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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

		#region 05 Mongo_ActiveAccountInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ActiveAccountInfo> Select(Expression<Func<Mongo_ActiveAccountInfo, bool>> filter,SortDefinition<Mongo_ActiveAccountInfo> order)
		 {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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



		#region 06 Mongo_ActiveAccountInfo_SelectPage
		 public static IList<Mongo_ActiveAccountInfo> SelectPage(SortDefinition<Mongo_ActiveAccountInfo> order, Expression<Func<Mongo_ActiveAccountInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ActiveAccountInfoAccess())
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

		#region 07 Mongo_ActiveAccountInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_ActiveAccountInfo> list)
        {
			try
			{
				using (var access = new Mongo_ActiveAccountInfoAccess())
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
	public partial class Mongo_ActiveVipInfoService
    {

        #region 01 Mongo_ActiveVipInfo_Insert
		 public static string Insert(Mongo_ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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
		
		#region 02 Mongo_ActiveVipInfo_Delete
		 public static int Delete(Expression<Func<Mongo_ActiveVipInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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

		#region 03 Mongo_ActiveVipInfo_Update
		 public static int Update(Expression<Func<Mongo_ActiveVipInfo, bool>> filter,Mongo_ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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

		#region 04 Mongo_ActiveVipInfo_SelectObject
		 public static Mongo_ActiveVipInfo SelectObject(Expression<Func<Mongo_ActiveVipInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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

		#region 05 Mongo_ActiveVipInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ActiveVipInfo> Select(Expression<Func<Mongo_ActiveVipInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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

		#region 05 Mongo_ActiveVipInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ActiveVipInfo> Select(Expression<Func<Mongo_ActiveVipInfo, bool>> filter,SortDefinition<Mongo_ActiveVipInfo> order)
		 {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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



		#region 06 Mongo_ActiveVipInfo_SelectPage
		 public static IList<Mongo_ActiveVipInfo> SelectPage(SortDefinition<Mongo_ActiveVipInfo> order, Expression<Func<Mongo_ActiveVipInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ActiveVipInfoAccess())
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

		#region 07 Mongo_ActiveVipInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_ActiveVipInfo> list)
        {
			try
			{
				using (var access = new Mongo_ActiveVipInfoAccess())
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
	public partial class Mongo_AdvertisingInfoService
    {

        #region 01 Mongo_AdvertisingInfo_Insert
		 public static string Insert(Mongo_AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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
		
		#region 02 Mongo_AdvertisingInfo_Delete
		 public static int Delete(Expression<Func<Mongo_AdvertisingInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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

		#region 03 Mongo_AdvertisingInfo_Update
		 public static int Update(Expression<Func<Mongo_AdvertisingInfo, bool>> filter,Mongo_AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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

		#region 04 Mongo_AdvertisingInfo_SelectObject
		 public static Mongo_AdvertisingInfo SelectObject(Expression<Func<Mongo_AdvertisingInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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

		#region 05 Mongo_AdvertisingInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_AdvertisingInfo> Select(Expression<Func<Mongo_AdvertisingInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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

		#region 05 Mongo_AdvertisingInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_AdvertisingInfo> Select(Expression<Func<Mongo_AdvertisingInfo, bool>> filter,SortDefinition<Mongo_AdvertisingInfo> order)
		 {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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



		#region 06 Mongo_AdvertisingInfo_SelectPage
		 public static IList<Mongo_AdvertisingInfo> SelectPage(SortDefinition<Mongo_AdvertisingInfo> order, Expression<Func<Mongo_AdvertisingInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_AdvertisingInfoAccess())
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

		#region 07 Mongo_AdvertisingInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_AdvertisingInfo> list)
        {
			try
			{
				using (var access = new Mongo_AdvertisingInfoAccess())
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
	public partial class Mongo_ComboInfoService
    {

        #region 01 Mongo_ComboInfo_Insert
		 public static string Insert(Mongo_ComboInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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
		
		#region 02 Mongo_ComboInfo_Delete
		 public static int Delete(Expression<Func<Mongo_ComboInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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

		#region 03 Mongo_ComboInfo_Update
		 public static int Update(Expression<Func<Mongo_ComboInfo, bool>> filter,Mongo_ComboInfo obj)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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

		#region 04 Mongo_ComboInfo_SelectObject
		 public static Mongo_ComboInfo SelectObject(Expression<Func<Mongo_ComboInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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

		#region 05 Mongo_ComboInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ComboInfo> Select(Expression<Func<Mongo_ComboInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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

		#region 05 Mongo_ComboInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ComboInfo> Select(Expression<Func<Mongo_ComboInfo, bool>> filter,SortDefinition<Mongo_ComboInfo> order)
		 {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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



		#region 06 Mongo_ComboInfo_SelectPage
		 public static IList<Mongo_ComboInfo> SelectPage(SortDefinition<Mongo_ComboInfo> order, Expression<Func<Mongo_ComboInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ComboInfoAccess())
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

		#region 07 Mongo_ComboInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_ComboInfo> list)
        {
			try
			{
				using (var access = new Mongo_ComboInfoAccess())
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
	public partial class Mongo_NoticeInfoService
    {

        #region 01 Mongo_NoticeInfo_Insert
		 public static string Insert(Mongo_NoticeInfo obj)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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
		
		#region 02 Mongo_NoticeInfo_Delete
		 public static int Delete(Expression<Func<Mongo_NoticeInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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

		#region 03 Mongo_NoticeInfo_Update
		 public static int Update(Expression<Func<Mongo_NoticeInfo, bool>> filter,Mongo_NoticeInfo obj)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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

		#region 04 Mongo_NoticeInfo_SelectObject
		 public static Mongo_NoticeInfo SelectObject(Expression<Func<Mongo_NoticeInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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

		#region 05 Mongo_NoticeInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_NoticeInfo> Select(Expression<Func<Mongo_NoticeInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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

		#region 05 Mongo_NoticeInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_NoticeInfo> Select(Expression<Func<Mongo_NoticeInfo, bool>> filter,SortDefinition<Mongo_NoticeInfo> order)
		 {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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



		#region 06 Mongo_NoticeInfo_SelectPage
		 public static IList<Mongo_NoticeInfo> SelectPage(SortDefinition<Mongo_NoticeInfo> order, Expression<Func<Mongo_NoticeInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_NoticeInfoAccess())
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

		#region 07 Mongo_NoticeInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_NoticeInfo> list)
        {
			try
			{
				using (var access = new Mongo_NoticeInfoAccess())
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
	public partial class Mongo_RechargeRecoderService
    {

        #region 01 Mongo_RechargeRecoder_Insert
		 public static string Insert(Mongo_RechargeRecoder obj)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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
		
		#region 02 Mongo_RechargeRecoder_Delete
		 public static int Delete(Expression<Func<Mongo_RechargeRecoder,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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

		#region 03 Mongo_RechargeRecoder_Update
		 public static int Update(Expression<Func<Mongo_RechargeRecoder, bool>> filter,Mongo_RechargeRecoder obj)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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

		#region 04 Mongo_RechargeRecoder_SelectObject
		 public static Mongo_RechargeRecoder SelectObject(Expression<Func<Mongo_RechargeRecoder, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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

		#region 05 Mongo_RechargeRecoder_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_RechargeRecoder> Select(Expression<Func<Mongo_RechargeRecoder, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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

		#region 05 Mongo_RechargeRecoder_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_RechargeRecoder> Select(Expression<Func<Mongo_RechargeRecoder, bool>> filter,SortDefinition<Mongo_RechargeRecoder> order)
		 {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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



		#region 06 Mongo_RechargeRecoder_SelectPage
		 public static IList<Mongo_RechargeRecoder> SelectPage(SortDefinition<Mongo_RechargeRecoder> order, Expression<Func<Mongo_RechargeRecoder, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_RechargeRecoderAccess())
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

		#region 07 Mongo_RechargeRecoder_BatchInsert
        public static void BatchInsert(IList<Mongo_RechargeRecoder> list)
        {
			try
			{
				using (var access = new Mongo_RechargeRecoderAccess())
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
	public partial class Mongo_SendMailLogService
    {

        #region 01 Mongo_SendMailLog_Insert
		 public static string Insert(Mongo_SendMailLog obj)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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
		
		#region 02 Mongo_SendMailLog_Delete
		 public static int Delete(Expression<Func<Mongo_SendMailLog,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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

		#region 03 Mongo_SendMailLog_Update
		 public static int Update(Expression<Func<Mongo_SendMailLog, bool>> filter,Mongo_SendMailLog obj)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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

		#region 04 Mongo_SendMailLog_SelectObject
		 public static Mongo_SendMailLog SelectObject(Expression<Func<Mongo_SendMailLog, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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

		#region 05 Mongo_SendMailLog_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_SendMailLog> Select(Expression<Func<Mongo_SendMailLog, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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

		#region 05 Mongo_SendMailLog_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_SendMailLog> Select(Expression<Func<Mongo_SendMailLog, bool>> filter,SortDefinition<Mongo_SendMailLog> order)
		 {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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



		#region 06 Mongo_SendMailLog_SelectPage
		 public static IList<Mongo_SendMailLog> SelectPage(SortDefinition<Mongo_SendMailLog> order, Expression<Func<Mongo_SendMailLog, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_SendMailLogAccess())
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

		#region 07 Mongo_SendMailLog_BatchInsert
        public static void BatchInsert(IList<Mongo_SendMailLog> list)
        {
			try
			{
				using (var access = new Mongo_SendMailLogAccess())
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
	public partial class Mongo_UserInfoService
    {

        #region 01 Mongo_UserInfo_Insert
		 public static string Insert(Mongo_UserInfo obj)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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
		
		#region 02 Mongo_UserInfo_Delete
		 public static int Delete(Expression<Func<Mongo_UserInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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

		#region 03 Mongo_UserInfo_Update
		 public static int Update(Expression<Func<Mongo_UserInfo, bool>> filter,Mongo_UserInfo obj)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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

		#region 04 Mongo_UserInfo_SelectObject
		 public static Mongo_UserInfo SelectObject(Expression<Func<Mongo_UserInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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

		#region 05 Mongo_UserInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_UserInfo> Select(Expression<Func<Mongo_UserInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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

		#region 05 Mongo_UserInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_UserInfo> Select(Expression<Func<Mongo_UserInfo, bool>> filter,SortDefinition<Mongo_UserInfo> order)
		 {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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



		#region 06 Mongo_UserInfo_SelectPage
		 public static IList<Mongo_UserInfo> SelectPage(SortDefinition<Mongo_UserInfo> order, Expression<Func<Mongo_UserInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_UserInfoAccess())
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

		#region 07 Mongo_UserInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_UserInfo> list)
        {
			try
			{
				using (var access = new Mongo_UserInfoAccess())
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
	public partial class Mongo_UserVisitsInfoService
    {

        #region 01 Mongo_UserVisitsInfo_Insert
		 public static string Insert(Mongo_UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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
		
		#region 02 Mongo_UserVisitsInfo_Delete
		 public static int Delete(Expression<Func<Mongo_UserVisitsInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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

		#region 03 Mongo_UserVisitsInfo_Update
		 public static int Update(Expression<Func<Mongo_UserVisitsInfo, bool>> filter,Mongo_UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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

		#region 04 Mongo_UserVisitsInfo_SelectObject
		 public static Mongo_UserVisitsInfo SelectObject(Expression<Func<Mongo_UserVisitsInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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

		#region 05 Mongo_UserVisitsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_UserVisitsInfo> Select(Expression<Func<Mongo_UserVisitsInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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

		#region 05 Mongo_UserVisitsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_UserVisitsInfo> Select(Expression<Func<Mongo_UserVisitsInfo, bool>> filter,SortDefinition<Mongo_UserVisitsInfo> order)
		 {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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



		#region 06 Mongo_UserVisitsInfo_SelectPage
		 public static IList<Mongo_UserVisitsInfo> SelectPage(SortDefinition<Mongo_UserVisitsInfo> order, Expression<Func<Mongo_UserVisitsInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_UserVisitsInfoAccess())
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

		#region 07 Mongo_UserVisitsInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_UserVisitsInfo> list)
        {
			try
			{
				using (var access = new Mongo_UserVisitsInfoAccess())
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
	public partial class Mongo_VideoCateService
    {

        #region 01 Mongo_VideoCate_Insert
		 public static string Insert(Mongo_VideoCate obj)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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
		
		#region 02 Mongo_VideoCate_Delete
		 public static int Delete(Expression<Func<Mongo_VideoCate,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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

		#region 03 Mongo_VideoCate_Update
		 public static int Update(Expression<Func<Mongo_VideoCate, bool>> filter,Mongo_VideoCate obj)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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

		#region 04 Mongo_VideoCate_SelectObject
		 public static Mongo_VideoCate SelectObject(Expression<Func<Mongo_VideoCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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

		#region 05 Mongo_VideoCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_VideoCate> Select(Expression<Func<Mongo_VideoCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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

		#region 05 Mongo_VideoCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_VideoCate> Select(Expression<Func<Mongo_VideoCate, bool>> filter,SortDefinition<Mongo_VideoCate> order)
		 {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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



		#region 06 Mongo_VideoCate_SelectPage
		 public static IList<Mongo_VideoCate> SelectPage(SortDefinition<Mongo_VideoCate> order, Expression<Func<Mongo_VideoCate, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_VideoCateAccess())
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

		#region 07 Mongo_VideoCate_BatchInsert
        public static void BatchInsert(IList<Mongo_VideoCate> list)
        {
			try
			{
				using (var access = new Mongo_VideoCateAccess())
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
	public partial class Mongo_VideoInfoService
    {

        #region 01 Mongo_VideoInfo_Insert
		 public static string Insert(Mongo_VideoInfo obj)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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
		
		#region 02 Mongo_VideoInfo_Delete
		 public static int Delete(Expression<Func<Mongo_VideoInfo,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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

		#region 03 Mongo_VideoInfo_Update
		 public static int Update(Expression<Func<Mongo_VideoInfo, bool>> filter,Mongo_VideoInfo obj)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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

		#region 04 Mongo_VideoInfo_SelectObject
		 public static Mongo_VideoInfo SelectObject(Expression<Func<Mongo_VideoInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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

		#region 05 Mongo_VideoInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_VideoInfo> Select(Expression<Func<Mongo_VideoInfo, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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

		#region 05 Mongo_VideoInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_VideoInfo> Select(Expression<Func<Mongo_VideoInfo, bool>> filter,SortDefinition<Mongo_VideoInfo> order)
		 {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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



		#region 06 Mongo_VideoInfo_SelectPage
		 public static IList<Mongo_VideoInfo> SelectPage(SortDefinition<Mongo_VideoInfo> order, Expression<Func<Mongo_VideoInfo, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_VideoInfoAccess())
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

		#region 07 Mongo_VideoInfo_BatchInsert
        public static void BatchInsert(IList<Mongo_VideoInfo> list)
        {
			try
			{
				using (var access = new Mongo_VideoInfoAccess())
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
