 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Access;

namespace Site.XiaoShuo.DataAccess.Service
{

	public partial class ChapterListService
    {

        #region 01 ChapterList_Insert
		 public static int Insert(ChapterList obj,int tableIndex)
		 {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.Insert(obj,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		 }
		#endregion
		
		#region 02 ChapterList_Delete
		 public static int Delete(int id,int tableIndex)
		 {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.Delete(id,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 ChapterList_Update
		 public static int Update(ChapterList obj,int tableIndex)
		 {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.Update(obj,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 ChapterList_SelectObject
		 public static ChapterList SelectObject(int id,int tableIndex)
		 {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.SelectObject(id,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 ChapterList_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ChapterList> Select(string whereStr,int tableIndex)
		 {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.Select(whereStr,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 06 ChapterList_SelectPage
		 public static IList<ChapterList> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, int tableIndex,out int rowCount)
		 {
			 try
			 {
				using (var access = new ChapterListAccess())
				{
					return access.SelectPage(cloumns,order,whereStr,pageIndex,pageSize,tableIndex,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 ChapterList_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ChapterList> list,int tableIndex,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
				{
					return access.SqlBulkCopyBatchInsert(list,tableIndex, count);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class ChapterVisitsService
    {

        #region 01 ChapterVisits_Insert
		 public static int Insert(ChapterVisits obj)
		 {
			try
			{
				using (var access = new ChapterVisitsAccess())
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
		
		#region 02 ChapterVisits_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ChapterVisitsAccess())
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

		#region 03 ChapterVisits_Update
		 public static int Update(ChapterVisits obj)
		 {
			try
			{
				using (var access = new ChapterVisitsAccess())
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

		#region 04 ChapterVisits_SelectObject
		 public static ChapterVisits SelectObject(int id)
		 {
			try
			{
				using (var access = new ChapterVisitsAccess())
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

		#region 05 ChapterVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ChapterVisits> Select(string whereStr)
		 {
			try
			{
				using (var access = new ChapterVisitsAccess())
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

		#region 06 ChapterVisits_SelectPage
		 public static IList<ChapterVisits> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ChapterVisitsAccess())
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

		#region 07 ChapterVisits_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ChapterVisits> list,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
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
	public partial class ContentCateService
    {

        #region 01 ContentCate_Insert
		 public static int Insert(ContentCate obj)
		 {
			try
			{
				using (var access = new ContentCateAccess())
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
		
		#region 02 ContentCate_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ContentCateAccess())
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

		#region 03 ContentCate_Update
		 public static int Update(ContentCate obj)
		 {
			try
			{
				using (var access = new ContentCateAccess())
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

		#region 04 ContentCate_SelectObject
		 public static ContentCate SelectObject(int id)
		 {
			try
			{
				using (var access = new ContentCateAccess())
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

		#region 05 ContentCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ContentCate> Select(string whereStr)
		 {
			try
			{
				using (var access = new ContentCateAccess())
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

		#region 06 ContentCate_SelectPage
		 public static IList<ContentCate> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ContentCateAccess())
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

		#region 07 ContentCate_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ContentCate> list,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
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
	public partial class ErrorChapterService
    {

        #region 01 ErrorChapter_Insert
		 public static int Insert(ErrorChapter obj)
		 {
			try
			{
				using (var access = new ErrorChapterAccess())
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
		
		#region 02 ErrorChapter_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new ErrorChapterAccess())
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

		#region 03 ErrorChapter_Update
		 public static int Update(ErrorChapter obj)
		 {
			try
			{
				using (var access = new ErrorChapterAccess())
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

		#region 04 ErrorChapter_SelectObject
		 public static ErrorChapter SelectObject(int id)
		 {
			try
			{
				using (var access = new ErrorChapterAccess())
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

		#region 05 ErrorChapter_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<ErrorChapter> Select(string whereStr)
		 {
			try
			{
				using (var access = new ErrorChapterAccess())
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

		#region 06 ErrorChapter_SelectPage
		 public static IList<ErrorChapter> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new ErrorChapterAccess())
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

		#region 07 ErrorChapter_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<ErrorChapter> list,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
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
	public partial class FictionService
    {

        #region 01 Fiction_Insert
		 public static int Insert(Fiction obj)
		 {
			try
			{
				using (var access = new FictionAccess())
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
		
		#region 02 Fiction_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new FictionAccess())
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

		#region 03 Fiction_Update
		 public static int Update(Fiction obj)
		 {
			try
			{
				using (var access = new FictionAccess())
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

		#region 04 Fiction_SelectObject
		 public static Fiction SelectObject(int id)
		 {
			try
			{
				using (var access = new FictionAccess())
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

		#region 05 Fiction_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Fiction> Select(string whereStr)
		 {
			try
			{
				using (var access = new FictionAccess())
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

		#region 06 Fiction_SelectPage
		 public static IList<Fiction> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new FictionAccess())
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

		#region 07 Fiction_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<Fiction> list,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
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
	public partial class FictionVisitsService
    {

        #region 01 FictionVisits_Insert
		 public static int Insert(FictionVisits obj)
		 {
			try
			{
				using (var access = new FictionVisitsAccess())
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
		
		#region 02 FictionVisits_Delete
		 public static int Delete(int id)
		 {
			try
			{
				using (var access = new FictionVisitsAccess())
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

		#region 03 FictionVisits_Update
		 public static int Update(FictionVisits obj)
		 {
			try
			{
				using (var access = new FictionVisitsAccess())
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

		#region 04 FictionVisits_SelectObject
		 public static FictionVisits SelectObject(int id)
		 {
			try
			{
				using (var access = new FictionVisitsAccess())
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

		#region 05 FictionVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<FictionVisits> Select(string whereStr)
		 {
			try
			{
				using (var access = new FictionVisitsAccess())
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

		#region 06 FictionVisits_SelectPage
		 public static IList<FictionVisits> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new FictionVisitsAccess())
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

		#region 07 FictionVisits_SqlBulkCopyBatchInsert
        public static int SqlBulkCopyBatchInsert(List<FictionVisits> list,int count)
        {
			try
			{
				using (var access = new ChapterListAccess())
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
