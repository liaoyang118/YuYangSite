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
    public partial class FictionVisitsAccess
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
        public IList<FictionVisits> SelectPageExcuteSql(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount)
        {
            DbCommand dbCmd = db.GetStoredProcCommand("Proc_FictionVisits_SelectPage");
            db.AddOutParameter(dbCmd, "@rowCount", DbType.Int32, 4);
            db.AddInParameter(dbCmd, "@cloumns", DbType.String, cloumns);
            db.AddInParameter(dbCmd, "@pageIndex", DbType.Int32, pageIndex);
            db.AddInParameter(dbCmd, "@pageSize", DbType.Int32, pageSize);
            db.AddInParameter(dbCmd, "@orderBy", DbType.String, order);
            db.AddInParameter(dbCmd, "@where", DbType.String, whereStr);

            List<FictionVisits> list = new List<FictionVisits>();
            try
            {
                using (IDataReader reader = db.ExecuteReader(dbCmd))
                {
                    while (reader.Read())
                    {
                        //属性赋值
                        FictionVisits obj = Object2Model(reader);
                        //获取联表属性
                        obj.Fiction_Title = reader["Fiction_Title"] == DBNull.Value ? default(string) : reader["Fiction_Title"].ToString();
                        obj.Fiction_Author = reader["Fiction_Author"] == DBNull.Value ? default(string) : reader["Fiction_Author"].ToString();
                        obj.Fiction_Id = reader["Fiction_Id"] == DBNull.Value ? default(int) : (int)reader["Fiction_Id"];


                        list.Add(obj);
                    }
                    reader.NextResult();
                    rowCount = (int)dbCmd.Parameters["@rowCount"].Value;
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
