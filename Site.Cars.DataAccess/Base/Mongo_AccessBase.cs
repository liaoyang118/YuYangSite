using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Data;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccess.Base
{
    /// <summary>
    /// 所有id属性 默认为表中的主键
    /// </summary>
    /// <typeparam name="T">操作对象</typeparam>
    public abstract class Mongo_AccessBase<T> where T : class
    {
        MongoClient client = null;
        public IMongoDatabase Database = null;
        
        public void GetDatabase(string databaseName)
        {
            if (client == null)
            {
                client = new MongoClient(ConnectionStr);
            }
            if (Database == null)
            {
                Database = client.GetDatabase(databaseName);
            }
        }

        //抽象属性
        protected abstract string ConnectionStr { get; set; }
        protected abstract string DataTableName { get; set; }

        public abstract string Insert(T obj);

        public abstract int Delete(Expression<Func<T, bool>> filter);

        public abstract int Update(Expression<Func<T, bool>> filter, T obj);

        public abstract T SelectObject(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IList<T> Select(Expression<Func<T, bool>> filter);


        public abstract IList<T> Select(Expression<Func<T, bool>> filter, SortDefinition<T> order); 

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="order"></param>
        /// <param name="filter">格式： where 条件</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public abstract IList<T> SelectPage(SortDefinition<T> order, Expression<Func<T, bool>> filter, int pageIndex, int pageSize, out int rowCount);

        public abstract void BatchInsert(IList<T> list);
    }
}
