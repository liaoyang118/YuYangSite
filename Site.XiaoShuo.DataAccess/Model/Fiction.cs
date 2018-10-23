using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.XiaoShuo.DataAccess.Model
{
    public partial class Fiction
    {
        /// <summary>
        /// 小说访问量
        /// </summary>
        public int Visits { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CateName { get; set; }

    }
}
