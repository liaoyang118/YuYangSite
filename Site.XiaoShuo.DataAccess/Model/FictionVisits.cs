using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.XiaoShuo.DataAccess.Model
{
    public partial class FictionVisits
    {
        #region Fiction 字段

        /// <summary>
        /// 书名
        /// </summary>
        public string Fiction_Title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Fiction_Author { get; set; }

        /// <summary>
        /// 小说ID
        /// </summary>
        public int Fiction_Id { get; set; }

        #endregion

    }
}
