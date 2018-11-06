using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Videos.DataAccess.Service.PartialService.Search
{
    public class UserInfoSearchInfo
    {
        public string OrderBy = "u_regTime desc";

        public string Account { get; set; }

        public int? AccountState { get; set; }


        public string ToWhereString()
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(Account))
            {
                where.Add(string.Format("u_name='{0}'", Account));
            }
            if (AccountState != null)
            {
                where.Add(string.Format("u_status={0}", AccountState));
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
