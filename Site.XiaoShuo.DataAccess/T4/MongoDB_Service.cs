 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using MongoDB.Driver;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Access;

namespace Site.XiaoShuo.DataAccess.Service
{

	public partial class Mongo_ChapterListService
    {

        #region 01 Mongo_ChapterList_Insert
		 public static string Insert(Mongo_ChapterList obj,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
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
		
		#region 02 Mongo_ChapterList_Delete
		 public static int Delete(Expression<Func<Mongo_ChapterList,bool>> filter,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.Delete(filter,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 03 Mongo_ChapterList_Update
		 public static int Update(Expression<Func<Mongo_ChapterList, bool>> filter,Mongo_ChapterList obj,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.Update(filter,obj,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 04 Mongo_ChapterList_SelectObject
		 public static Mongo_ChapterList SelectObject(Expression<Func<Mongo_ChapterList, bool>> filter,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.SelectObject(filter,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_ChapterList_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ChapterList> Select(Expression<Func<Mongo_ChapterList, bool>> filter,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.Select(filter,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 05 Mongo_ChapterList_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ChapterList> Select(Expression<Func<Mongo_ChapterList, bool>> filter,SortDefinition<Mongo_ChapterList> order,int tableIndex)
		 {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.Select(filter,order,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion 



		#region 06 Mongo_ChapterList_SelectPage
		 public static IList<Mongo_ChapterList> SelectPage(SortDefinition<Mongo_ChapterList> order, Expression<Func<Mongo_ChapterList, bool>> filter, int pageIndex, int pageSize, int tableIndex,out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ChapterListAccess())
				{
					return access.SelectPage(order,filter,pageIndex,pageSize,tableIndex,out rowCount);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region 07 Mongo_ChapterList_BatchInsert
        public static void BatchInsert(IList<Mongo_ChapterList> list,int tableIndex)
        {
			try
			{
				using (var access = new Mongo_ChapterListAccess())
				{
					access.BatchInsert(list,tableIndex);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
        #endregion

    }
	public partial class Mongo_ChapterVisitsService
    {

        #region 01 Mongo_ChapterVisits_Insert
		 public static string Insert(Mongo_ChapterVisits obj)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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
		
		#region 02 Mongo_ChapterVisits_Delete
		 public static int Delete(Expression<Func<Mongo_ChapterVisits,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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

		#region 03 Mongo_ChapterVisits_Update
		 public static int Update(Expression<Func<Mongo_ChapterVisits, bool>> filter,Mongo_ChapterVisits obj)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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

		#region 04 Mongo_ChapterVisits_SelectObject
		 public static Mongo_ChapterVisits SelectObject(Expression<Func<Mongo_ChapterVisits, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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

		#region 05 Mongo_ChapterVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ChapterVisits> Select(Expression<Func<Mongo_ChapterVisits, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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

		#region 05 Mongo_ChapterVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ChapterVisits> Select(Expression<Func<Mongo_ChapterVisits, bool>> filter,SortDefinition<Mongo_ChapterVisits> order)
		 {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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



		#region 06 Mongo_ChapterVisits_SelectPage
		 public static IList<Mongo_ChapterVisits> SelectPage(SortDefinition<Mongo_ChapterVisits> order, Expression<Func<Mongo_ChapterVisits, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ChapterVisitsAccess())
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

		#region 07 Mongo_ChapterVisits_BatchInsert
        public static void BatchInsert(IList<Mongo_ChapterVisits> list)
        {
			try
			{
				using (var access = new Mongo_ChapterVisitsAccess())
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
	public partial class Mongo_ContentCateService
    {

        #region 01 Mongo_ContentCate_Insert
		 public static string Insert(Mongo_ContentCate obj)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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
		
		#region 02 Mongo_ContentCate_Delete
		 public static int Delete(Expression<Func<Mongo_ContentCate,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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

		#region 03 Mongo_ContentCate_Update
		 public static int Update(Expression<Func<Mongo_ContentCate, bool>> filter,Mongo_ContentCate obj)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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

		#region 04 Mongo_ContentCate_SelectObject
		 public static Mongo_ContentCate SelectObject(Expression<Func<Mongo_ContentCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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

		#region 05 Mongo_ContentCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ContentCate> Select(Expression<Func<Mongo_ContentCate, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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

		#region 05 Mongo_ContentCate_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ContentCate> Select(Expression<Func<Mongo_ContentCate, bool>> filter,SortDefinition<Mongo_ContentCate> order)
		 {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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



		#region 06 Mongo_ContentCate_SelectPage
		 public static IList<Mongo_ContentCate> SelectPage(SortDefinition<Mongo_ContentCate> order, Expression<Func<Mongo_ContentCate, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ContentCateAccess())
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

		#region 07 Mongo_ContentCate_BatchInsert
        public static void BatchInsert(IList<Mongo_ContentCate> list)
        {
			try
			{
				using (var access = new Mongo_ContentCateAccess())
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
	public partial class Mongo_ErrorChapterService
    {

        #region 01 Mongo_ErrorChapter_Insert
		 public static string Insert(Mongo_ErrorChapter obj)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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
		
		#region 02 Mongo_ErrorChapter_Delete
		 public static int Delete(Expression<Func<Mongo_ErrorChapter,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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

		#region 03 Mongo_ErrorChapter_Update
		 public static int Update(Expression<Func<Mongo_ErrorChapter, bool>> filter,Mongo_ErrorChapter obj)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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

		#region 04 Mongo_ErrorChapter_SelectObject
		 public static Mongo_ErrorChapter SelectObject(Expression<Func<Mongo_ErrorChapter, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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

		#region 05 Mongo_ErrorChapter_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ErrorChapter> Select(Expression<Func<Mongo_ErrorChapter, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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

		#region 05 Mongo_ErrorChapter_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_ErrorChapter> Select(Expression<Func<Mongo_ErrorChapter, bool>> filter,SortDefinition<Mongo_ErrorChapter> order)
		 {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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



		#region 06 Mongo_ErrorChapter_SelectPage
		 public static IList<Mongo_ErrorChapter> SelectPage(SortDefinition<Mongo_ErrorChapter> order, Expression<Func<Mongo_ErrorChapter, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_ErrorChapterAccess())
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

		#region 07 Mongo_ErrorChapter_BatchInsert
        public static void BatchInsert(IList<Mongo_ErrorChapter> list)
        {
			try
			{
				using (var access = new Mongo_ErrorChapterAccess())
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
	public partial class Mongo_FictionService
    {

        #region 01 Mongo_Fiction_Insert
		 public static string Insert(Mongo_Fiction obj)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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
		
		#region 02 Mongo_Fiction_Delete
		 public static int Delete(Expression<Func<Mongo_Fiction,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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

		#region 03 Mongo_Fiction_Update
		 public static int Update(Expression<Func<Mongo_Fiction, bool>> filter,Mongo_Fiction obj)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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

		#region 04 Mongo_Fiction_SelectObject
		 public static Mongo_Fiction SelectObject(Expression<Func<Mongo_Fiction, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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

		#region 05 Mongo_Fiction_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Fiction> Select(Expression<Func<Mongo_Fiction, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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

		#region 05 Mongo_Fiction_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_Fiction> Select(Expression<Func<Mongo_Fiction, bool>> filter,SortDefinition<Mongo_Fiction> order)
		 {
			try
			{
				using (var access = new Mongo_FictionAccess())
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



		#region 06 Mongo_Fiction_SelectPage
		 public static IList<Mongo_Fiction> SelectPage(SortDefinition<Mongo_Fiction> order, Expression<Func<Mongo_Fiction, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_FictionAccess())
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

		#region 07 Mongo_Fiction_BatchInsert
        public static void BatchInsert(IList<Mongo_Fiction> list)
        {
			try
			{
				using (var access = new Mongo_FictionAccess())
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
	public partial class Mongo_FictionVisitsService
    {

        #region 01 Mongo_FictionVisits_Insert
		 public static string Insert(Mongo_FictionVisits obj)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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
		
		#region 02 Mongo_FictionVisits_Delete
		 public static int Delete(Expression<Func<Mongo_FictionVisits,bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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

		#region 03 Mongo_FictionVisits_Update
		 public static int Update(Expression<Func<Mongo_FictionVisits, bool>> filter,Mongo_FictionVisits obj)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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

		#region 04 Mongo_FictionVisits_SelectObject
		 public static Mongo_FictionVisits SelectObject(Expression<Func<Mongo_FictionVisits, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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

		#region 05 Mongo_FictionVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_FictionVisits> Select(Expression<Func<Mongo_FictionVisits, bool>> filter)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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

		#region 05 Mongo_FictionVisits_Select
		/// <summary>
         /// 
         /// </summary>
         /// <param name="whereStr">以where 开始</param>
         /// <returns></returns>
		 public static IList<Mongo_FictionVisits> Select(Expression<Func<Mongo_FictionVisits, bool>> filter,SortDefinition<Mongo_FictionVisits> order)
		 {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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



		#region 06 Mongo_FictionVisits_SelectPage
		 public static IList<Mongo_FictionVisits> SelectPage(SortDefinition<Mongo_FictionVisits> order, Expression<Func<Mongo_FictionVisits, bool>> filter, int pageIndex, int pageSize, out int rowCount)
		 {
			 try
			 {
				using (var access = new Mongo_FictionVisitsAccess())
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

		#region 07 Mongo_FictionVisits_BatchInsert
        public static void BatchInsert(IList<Mongo_FictionVisits> list)
        {
			try
			{
				using (var access = new Mongo_FictionVisitsAccess())
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
