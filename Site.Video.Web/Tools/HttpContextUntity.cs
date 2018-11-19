using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Untity;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Videos.DataAccess.Service.PartialService.Search;

namespace Site.Video.Web.Tools
{
    public class HttpContextUntity
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static MySql_UserInfo CurrentUser
        {
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    return (MySql_UserInfo)HttpContext.Current.Session["user"];
                }
                else
                {
                    string name = HttpContext.Current.User.Identity.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        UserInfoSearchInfo search = new UserInfoSearchInfo
                        {
                            Account = name,
                            AccountState = (int)SiteEnum.AccountState.正常
                        };
                        IList<MySql_UserInfo> list = MySql_UserInfoService.Select(search.ToWhereString());
                        MySql_UserInfo sInfo = list.FirstOrDefault();
                        return sInfo;
                    }
                    return null;
                }
            }
        }
    }
}