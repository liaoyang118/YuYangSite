 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Access;

namespace Site.Videos.DataAccess.Service
{

	public partial class MySql_ActiveAccountInfoService
    {

        #region 01 MySql_ActiveAccountInfo_Insert
		 public static int Insert(MySql_ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
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
		
		#region 02 MySql_ActiveAccountInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
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

		#region 03 MySql_ActiveAccountInfo_Update
		 public static int Update(MySql_ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
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

		#region 04 MySql_ActiveAccountInfo_SelectObject
		 public static MySql_ActiveAccountInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
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

		#region 05 MySql_ActiveAccountInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_ActiveAccountInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
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

		#region 06 MySql_ActiveAccountInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_ActiveAccountInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_ActiveAccountInfoAccess())
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

		#region 07 MySql_ActiveAccountInfo_BatchInsert
        public static int BatchInsert(List<MySql_ActiveAccountInfo> list)
        {
			try
			{
				using (var access = new MySql_ActiveAccountInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_ActiveVipInfoService
    {

        #region 01 MySql_ActiveVipInfo_Insert
		 public static int Insert(MySql_ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
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
		
		#region 02 MySql_ActiveVipInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
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

		#region 03 MySql_ActiveVipInfo_Update
		 public static int Update(MySql_ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
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

		#region 04 MySql_ActiveVipInfo_SelectObject
		 public static MySql_ActiveVipInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
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

		#region 05 MySql_ActiveVipInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_ActiveVipInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
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

		#region 06 MySql_ActiveVipInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_ActiveVipInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_ActiveVipInfoAccess())
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

		#region 07 MySql_ActiveVipInfo_BatchInsert
        public static int BatchInsert(List<MySql_ActiveVipInfo> list)
        {
			try
			{
				using (var access = new MySql_ActiveVipInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_AdvertisingInfoService
    {

        #region 01 MySql_AdvertisingInfo_Insert
		 public static int Insert(MySql_AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
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
		
		#region 02 MySql_AdvertisingInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
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

		#region 03 MySql_AdvertisingInfo_Update
		 public static int Update(MySql_AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
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

		#region 04 MySql_AdvertisingInfo_SelectObject
		 public static MySql_AdvertisingInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
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

		#region 05 MySql_AdvertisingInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_AdvertisingInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
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

		#region 06 MySql_AdvertisingInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_AdvertisingInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_AdvertisingInfoAccess())
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

		#region 07 MySql_AdvertisingInfo_BatchInsert
        public static int BatchInsert(List<MySql_AdvertisingInfo> list)
        {
			try
			{
				using (var access = new MySql_AdvertisingInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_ComboInfoService
    {

        #region 01 MySql_ComboInfo_Insert
		 public static int Insert(MySql_ComboInfo obj)
		 {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
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
		
		#region 02 MySql_ComboInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
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

		#region 03 MySql_ComboInfo_Update
		 public static int Update(MySql_ComboInfo obj)
		 {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
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

		#region 04 MySql_ComboInfo_SelectObject
		 public static MySql_ComboInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
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

		#region 05 MySql_ComboInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_ComboInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
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

		#region 06 MySql_ComboInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_ComboInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_ComboInfoAccess())
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

		#region 07 MySql_ComboInfo_BatchInsert
        public static int BatchInsert(List<MySql_ComboInfo> list)
        {
			try
			{
				using (var access = new MySql_ComboInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_NoticeInfoService
    {

        #region 01 MySql_NoticeInfo_Insert
		 public static int Insert(MySql_NoticeInfo obj)
		 {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
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
		
		#region 02 MySql_NoticeInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
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

		#region 03 MySql_NoticeInfo_Update
		 public static int Update(MySql_NoticeInfo obj)
		 {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
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

		#region 04 MySql_NoticeInfo_SelectObject
		 public static MySql_NoticeInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
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

		#region 05 MySql_NoticeInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_NoticeInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
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

		#region 06 MySql_NoticeInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_NoticeInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_NoticeInfoAccess())
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

		#region 07 MySql_NoticeInfo_BatchInsert
        public static int BatchInsert(List<MySql_NoticeInfo> list)
        {
			try
			{
				using (var access = new MySql_NoticeInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_RechargeRecoderService
    {

        #region 01 MySql_RechargeRecoder_Insert
		 public static int Insert(MySql_RechargeRecoder obj)
		 {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
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
		
		#region 02 MySql_RechargeRecoder_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
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

		#region 03 MySql_RechargeRecoder_Update
		 public static int Update(MySql_RechargeRecoder obj)
		 {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
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

		#region 04 MySql_RechargeRecoder_SelectObject
		 public static MySql_RechargeRecoder SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
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

		#region 05 MySql_RechargeRecoder_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_RechargeRecoder> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
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

		#region 06 MySql_RechargeRecoder_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_RechargeRecoder> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_RechargeRecoderAccess())
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

		#region 07 MySql_RechargeRecoder_BatchInsert
        public static int BatchInsert(List<MySql_RechargeRecoder> list)
        {
			try
			{
				using (var access = new MySql_RechargeRecoderAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_SendMailLogService
    {

        #region 01 MySql_SendMailLog_Insert
		 public static int Insert(MySql_SendMailLog obj)
		 {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
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
		
		#region 02 MySql_SendMailLog_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
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

		#region 03 MySql_SendMailLog_Update
		 public static int Update(MySql_SendMailLog obj)
		 {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
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

		#region 04 MySql_SendMailLog_SelectObject
		 public static MySql_SendMailLog SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
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

		#region 05 MySql_SendMailLog_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_SendMailLog> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
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

		#region 06 MySql_SendMailLog_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_SendMailLog> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_SendMailLogAccess())
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

		#region 07 MySql_SendMailLog_BatchInsert
        public static int BatchInsert(List<MySql_SendMailLog> list)
        {
			try
			{
				using (var access = new MySql_SendMailLogAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_UserInfoService
    {

        #region 01 MySql_UserInfo_Insert
		 public static int Insert(MySql_UserInfo obj)
		 {
			try
			{
				using (var access = new MySql_UserInfoAccess())
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
		
		#region 02 MySql_UserInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_UserInfoAccess())
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

		#region 03 MySql_UserInfo_Update
		 public static int Update(MySql_UserInfo obj)
		 {
			try
			{
				using (var access = new MySql_UserInfoAccess())
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

		#region 04 MySql_UserInfo_SelectObject
		 public static MySql_UserInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_UserInfoAccess())
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

		#region 05 MySql_UserInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_UserInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_UserInfoAccess())
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

		#region 06 MySql_UserInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_UserInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_UserInfoAccess())
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

		#region 07 MySql_UserInfo_BatchInsert
        public static int BatchInsert(List<MySql_UserInfo> list)
        {
			try
			{
				using (var access = new MySql_UserInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_UserVisitsInfoService
    {

        #region 01 MySql_UserVisitsInfo_Insert
		 public static int Insert(MySql_UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
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
		
		#region 02 MySql_UserVisitsInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
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

		#region 03 MySql_UserVisitsInfo_Update
		 public static int Update(MySql_UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
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

		#region 04 MySql_UserVisitsInfo_SelectObject
		 public static MySql_UserVisitsInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
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

		#region 05 MySql_UserVisitsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_UserVisitsInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
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

		#region 06 MySql_UserVisitsInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_UserVisitsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_UserVisitsInfoAccess())
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

		#region 07 MySql_UserVisitsInfo_BatchInsert
        public static int BatchInsert(List<MySql_UserVisitsInfo> list)
        {
			try
			{
				using (var access = new MySql_UserVisitsInfoAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_VideoCateService
    {

        #region 01 MySql_VideoCate_Insert
		 public static int Insert(MySql_VideoCate obj)
		 {
			try
			{
				using (var access = new MySql_VideoCateAccess())
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
		
		#region 02 MySql_VideoCate_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_VideoCateAccess())
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

		#region 03 MySql_VideoCate_Update
		 public static int Update(MySql_VideoCate obj)
		 {
			try
			{
				using (var access = new MySql_VideoCateAccess())
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

		#region 04 MySql_VideoCate_SelectObject
		 public static MySql_VideoCate SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_VideoCateAccess())
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

		#region 05 MySql_VideoCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_VideoCate> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_VideoCateAccess())
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

		#region 06 MySql_VideoCate_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_VideoCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_VideoCateAccess())
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

		#region 07 MySql_VideoCate_BatchInsert
        public static int BatchInsert(List<MySql_VideoCate> list)
        {
			try
			{
				using (var access = new MySql_VideoCateAccess())
				{
					return access.BatchInsert(list);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class MySql_VideoInfoService
    {

        #region 01 MySql_VideoInfo_Insert
		 public static int Insert(MySql_VideoInfo obj)
		 {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
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
		
		#region 02 MySql_VideoInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
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

		#region 03 MySql_VideoInfo_Update
		 public static int Update(MySql_VideoInfo obj)
		 {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
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

		#region 04 MySql_VideoInfo_SelectObject
		 public static MySql_VideoInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
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

		#region 05 MySql_VideoInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<MySql_VideoInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
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

		#region 06 MySql_VideoInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<MySql_VideoInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new MySql_VideoInfoAccess())
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

		#region 07 MySql_VideoInfo_BatchInsert
        public static int BatchInsert(List<MySql_VideoInfo> list)
        {
			try
			{
				using (var access = new MySql_VideoInfoAccess())
				{
					return access.BatchInsert(list);
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
