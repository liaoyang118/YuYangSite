using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.XiaoShuo.DataAccess.Service.PartialService.Search
{
    public class FictionSearchInfo
    {
        public string OrderBy = "LastUpdateTime desc";

        public string Title { get; set; }

        public int? C_C_ID { set; get; }

        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Title))
            {
                where.Add(string.Format("Title like N'%{0}%'", Title));
            }

            if (C_C_ID != null)
            {
                where.Add(string.Format("C_C_ID = {0}", C_C_ID.Value));
            }

            if (where.Count > 0)
            {
                return string.Format(" where {0}", string.Join(" and ", where.ToList()));
            }
            else
            {
                return string.Empty;
            }
        }


    }
}
