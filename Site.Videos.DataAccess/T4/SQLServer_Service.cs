 


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

	public partial class ActiveAccountInfoService
    {

        #region 01 ActiveAccountInfo_Insert
		 public static int Insert(ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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
		
		#region 02 ActiveAccountInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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

		#region 03 ActiveAccountInfo_Update
		 public static int Update(ActiveAccountInfo obj)
		 {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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

		#region 04 ActiveAccountInfo_SelectObject
		 public static ActiveAccountInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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

		#region 05 ActiveAccountInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ActiveAccountInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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

		#region 06 ActiveAccountInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<ActiveAccountInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ActiveAccountInfoAccess())
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

		#region 07 ActiveAccountInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ActiveAccountInfo> list,int count)
        {
			try
			{
				using (var access = new ActiveAccountInfoAccess())
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
	public partial class ActiveVipInfoService
    {

        #region 01 ActiveVipInfo_Insert
		 public static int Insert(ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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
		
		#region 02 ActiveVipInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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

		#region 03 ActiveVipInfo_Update
		 public static int Update(ActiveVipInfo obj)
		 {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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

		#region 04 ActiveVipInfo_SelectObject
		 public static ActiveVipInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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

		#region 05 ActiveVipInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ActiveVipInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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

		#region 06 ActiveVipInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<ActiveVipInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ActiveVipInfoAccess())
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

		#region 07 ActiveVipInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ActiveVipInfo> list,int count)
        {
			try
			{
				using (var access = new ActiveVipInfoAccess())
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
	public partial class AdvertisingInfoService
    {

        #region 01 AdvertisingInfo_Insert
		 public static int Insert(AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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
		
		#region 02 AdvertisingInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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

		#region 03 AdvertisingInfo_Update
		 public static int Update(AdvertisingInfo obj)
		 {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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

		#region 04 AdvertisingInfo_SelectObject
		 public static AdvertisingInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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

		#region 05 AdvertisingInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<AdvertisingInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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

		#region 06 AdvertisingInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<AdvertisingInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new AdvertisingInfoAccess())
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

		#region 07 AdvertisingInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<AdvertisingInfo> list,int count)
        {
			try
			{
				using (var access = new AdvertisingInfoAccess())
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
	public partial class ComboInfoService
    {

        #region 01 ComboInfo_Insert
		 public static int Insert(ComboInfo obj)
		 {
			try
			{
				using (var access = new ComboInfoAccess())
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
		
		#region 02 ComboInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ComboInfoAccess())
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

		#region 03 ComboInfo_Update
		 public static int Update(ComboInfo obj)
		 {
			try
			{
				using (var access = new ComboInfoAccess())
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

		#region 04 ComboInfo_SelectObject
		 public static ComboInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new ComboInfoAccess())
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

		#region 05 ComboInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ComboInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new ComboInfoAccess())
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

		#region 06 ComboInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<ComboInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ComboInfoAccess())
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

		#region 07 ComboInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ComboInfo> list,int count)
        {
			try
			{
				using (var access = new ComboInfoAccess())
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
	public partial class NoticeInfoService
    {

        #region 01 NoticeInfo_Insert
		 public static int Insert(NoticeInfo obj)
		 {
			try
			{
				using (var access = new NoticeInfoAccess())
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
		
		#region 02 NoticeInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new NoticeInfoAccess())
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

		#region 03 NoticeInfo_Update
		 public static int Update(NoticeInfo obj)
		 {
			try
			{
				using (var access = new NoticeInfoAccess())
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

		#region 04 NoticeInfo_SelectObject
		 public static NoticeInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new NoticeInfoAccess())
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

		#region 05 NoticeInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<NoticeInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new NoticeInfoAccess())
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

		#region 06 NoticeInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<NoticeInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new NoticeInfoAccess())
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

		#region 07 NoticeInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<NoticeInfo> list,int count)
        {
			try
			{
				using (var access = new NoticeInfoAccess())
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
	public partial class RechargeRecoderService
    {

        #region 01 RechargeRecoder_Insert
		 public static int Insert(RechargeRecoder obj)
		 {
			try
			{
				using (var access = new RechargeRecoderAccess())
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
		
		#region 02 RechargeRecoder_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new RechargeRecoderAccess())
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

		#region 03 RechargeRecoder_Update
		 public static int Update(RechargeRecoder obj)
		 {
			try
			{
				using (var access = new RechargeRecoderAccess())
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

		#region 04 RechargeRecoder_SelectObject
		 public static RechargeRecoder SelectObject(int id)
		 {
			try
			{
				using (var access = new RechargeRecoderAccess())
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

		#region 05 RechargeRecoder_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<RechargeRecoder> Select(string whereStr)
		 {
			try
			{
				using (var access = new RechargeRecoderAccess())
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

		#region 06 RechargeRecoder_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<RechargeRecoder> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new RechargeRecoderAccess())
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

		#region 07 RechargeRecoder_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<RechargeRecoder> list,int count)
        {
			try
			{
				using (var access = new RechargeRecoderAccess())
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
	public partial class SendMailLogService
    {

        #region 01 SendMailLog_Insert
		 public static int Insert(SendMailLog obj)
		 {
			try
			{
				using (var access = new SendMailLogAccess())
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
		
		#region 02 SendMailLog_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new SendMailLogAccess())
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

		#region 03 SendMailLog_Update
		 public static int Update(SendMailLog obj)
		 {
			try
			{
				using (var access = new SendMailLogAccess())
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

		#region 04 SendMailLog_SelectObject
		 public static SendMailLog SelectObject(int id)
		 {
			try
			{
				using (var access = new SendMailLogAccess())
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

		#region 05 SendMailLog_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<SendMailLog> Select(string whereStr)
		 {
			try
			{
				using (var access = new SendMailLogAccess())
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

		#region 06 SendMailLog_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<SendMailLog> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new SendMailLogAccess())
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

		#region 07 SendMailLog_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<SendMailLog> list,int count)
        {
			try
			{
				using (var access = new SendMailLogAccess())
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
	public partial class UserInfoService
    {

        #region 01 UserInfo_Insert
		 public static int Insert(UserInfo obj)
		 {
			try
			{
				using (var access = new UserInfoAccess())
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
		
		#region 02 UserInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new UserInfoAccess())
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

		#region 03 UserInfo_Update
		 public static int Update(UserInfo obj)
		 {
			try
			{
				using (var access = new UserInfoAccess())
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

		#region 04 UserInfo_SelectObject
		 public static UserInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new UserInfoAccess())
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

		#region 05 UserInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<UserInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new UserInfoAccess())
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

		#region 06 UserInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<UserInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new UserInfoAccess())
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

		#region 07 UserInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<UserInfo> list,int count)
        {
			try
			{
				using (var access = new UserInfoAccess())
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
	public partial class UserVisitsInfoService
    {

        #region 01 UserVisitsInfo_Insert
		 public static int Insert(UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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
		
		#region 02 UserVisitsInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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

		#region 03 UserVisitsInfo_Update
		 public static int Update(UserVisitsInfo obj)
		 {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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

		#region 04 UserVisitsInfo_SelectObject
		 public static UserVisitsInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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

		#region 05 UserVisitsInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<UserVisitsInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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

		#region 06 UserVisitsInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<UserVisitsInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new UserVisitsInfoAccess())
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

		#region 07 UserVisitsInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<UserVisitsInfo> list,int count)
        {
			try
			{
				using (var access = new UserVisitsInfoAccess())
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
	public partial class VideoCateService
    {

        #region 01 VideoCate_Insert
		 public static int Insert(VideoCate obj)
		 {
			try
			{
				using (var access = new VideoCateAccess())
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
		
		#region 02 VideoCate_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new VideoCateAccess())
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

		#region 03 VideoCate_Update
		 public static int Update(VideoCate obj)
		 {
			try
			{
				using (var access = new VideoCateAccess())
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

		#region 04 VideoCate_SelectObject
		 public static VideoCate SelectObject(int id)
		 {
			try
			{
				using (var access = new VideoCateAccess())
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

		#region 05 VideoCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<VideoCate> Select(string whereStr)
		 {
			try
			{
				using (var access = new VideoCateAccess())
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

		#region 06 VideoCate_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<VideoCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new VideoCateAccess())
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

		#region 07 VideoCate_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<VideoCate> list,int count)
        {
			try
			{
				using (var access = new VideoCateAccess())
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
	public partial class VideoInfoService
    {

        #region 01 VideoInfo_Insert
		 public static int Insert(VideoInfo obj)
		 {
			try
			{
				using (var access = new VideoInfoAccess())
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
		
		#region 02 VideoInfo_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new VideoInfoAccess())
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

		#region 03 VideoInfo_Update
		 public static int Update(VideoInfo obj)
		 {
			try
			{
				using (var access = new VideoInfoAccess())
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

		#region 04 VideoInfo_SelectObject
		 public static VideoInfo SelectObject(int id)
		 {
			try
			{
				using (var access = new VideoInfoAccess())
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

		#region 05 VideoInfo_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<VideoInfo> Select(string whereStr)
		 {
			try
			{
				using (var access = new VideoInfoAccess())
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

		#region 06 VideoInfo_SelectPage
		/// <summary>
         /// 
         /// </summary>
         /// <param name="order">列名，分页排序字段，可支持多字段，多顺序</param>
         /// <param name="whereStr">以 where 开头</param>
         /// <returns></returns>
		 public static IList<VideoInfo> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new VideoInfoAccess())
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

		#region 07 VideoInfo_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<VideoInfo> list,int count)
        {
			try
			{
				using (var access = new VideoInfoAccess())
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
