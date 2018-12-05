using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;

namespace Site.XiaoShuo.Web.Filter
{
    /// <summary>
    /// 记录浏览日志
    /// </summary>
    public class VisitsLogAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //记录访问日志
            UserVisitsInfo obj = new UserVisitsInfo();
            obj.v_browser = filterContext.RequestContext.HttpContext.Request.Browser.Browser;
            obj.v_ip = filterContext.RequestContext.HttpContext.Request.UserHostAddress;
            obj.v_os = filterContext.RequestContext.HttpContext.Request.Browser.Platform;
            obj.v_time = DateTime.Now;
            obj.v_url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            obj.u_id = string.Empty;
            obj.v_id = string.Empty;
            obj.platform = filterContext.RequestContext.HttpContext.Request.Browser.Platform;
            UserVisitsInfoService.Insert(obj);

            base.OnResultExecuted(filterContext);
        }
    }
}