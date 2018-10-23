using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.XiaoShuo.DataAccess.Model;

namespace Site.XiaoShuo.DataAccess.Access
{
    public partial class FictionAccess
    {
        #region 01 Proc_ExcuteSqlSelectPage
        /// <summary>
        /// 联表查询，主表别名固定为t1
        /// </summary>
        /// <param name="cloumns">查询列，列名必须和实体中属性一致</param>
        /// <param name="order">主表的排序字段</param>
        /// <param name="whereStr">联表语句</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IList<Fiction> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_SelectPage");
            db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32, 4);
            db.AddInParameter(dbCmd, "@cloumns", DbType.String, cloumns);
            db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCmd, "@pageSize", DbType.Int32, pageSize);
            db.AddInParameter(dbCmd, "@orderBy", DbType.String, order);
            db.AddInParameter(dbCmd, "@where", DbType.String, whereStr);

            List<Fiction> list = new List<Fiction>();
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        //属性赋值
                        Fiction obj = Object2Model(reader);
                        //获取联表属性
                        obj.CateName = reader["CateName"] == DBNull.Value ? default(string) : reader["CateName"].ToString();


                        list.Add(obj);
                    }
                    reader.NextResult();
                    rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("数据层：" + e.Message);
            }
        }
        #endregion

        #region 02 更新最新章节

        public int GetLastUpdateChapter(int fid, int cateId)
        {
            DbCommand dbCmd = db.GetStoredProcCommand("Proc_Fiction_GetLastUpdateChapter");
            db.AddInParameter(dbCmd, "@Id", DbType.Int32, fid);
            db.AddInParameter(dbCmd, "@C_C_ID", DbType.Int32, cateId);
            try
            {
                int returnValue = db.ExecuteNonQuery(dbCmd);
                return returnValue;
            }
            catch (Exception e)
            {
                throw new Exception("数据层：" + e.Message);
            }
        }


        #endregion
    }
}
