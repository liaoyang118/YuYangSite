using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;

namespace DataAccess.Base
{
    /// <summary>
    /// MySql操作
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class MySql_AccessBase<T> where T : class
    {
        MySqlConnection connection = null;
        public MySqlCommand Command = null;

        public void GetCommand()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(ConnectionStr);
                connection.Open();
            }
            if (Command == null)
            {
                Command = new MySqlCommand();
                Command.Connection = connection;
            }
        }

        public void DisposeCommand()
        {
            if (Command != null)
            {
                Command.Dispose();
            }
        }

        public void DisposeConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        //抽象属性
        protected abstract string ConnectionStr { get; set; }
        protected abstract string DataTableName { get; set; }

        public abstract int Insert(T obj);

        public abstract int Delete(int id);

        public abstract int Update(T obj);

        public abstract T SelectObject(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <returns></returns>
        public abstract IList<T> Select(string whereStr);

        /// <summary>
        /// 分页查询，注意需要数据库有该存储过程 Proc_SelectPageBase
        /// </summary>
        /// <param name="cloumns">格式：*、name,age,num</param>
        /// <param name="order">格式:ID DESC、ID ASC、name,age desc</param>
        /// <param name="whereStr">格式： where a<1 and b>2 </param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public abstract IList<T> SelectPage(string cloumns, string order, string whereStr, int pageIndex, int pageSize, out int rowCount);


        public abstract int BatchInsert(IList<T> list);
    }
}
