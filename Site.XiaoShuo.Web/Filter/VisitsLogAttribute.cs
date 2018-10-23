using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;

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
            ChapterVisits obj = new ChapterVisits();
            obj.Browser = filterContext.RequestContext.HttpContext.Request.Browser.Browser;
            obj.IP = filterContext.RequestContext.HttpContext.Request.UserHostAddress;
            obj.OS = filterContext.RequestContext.HttpContext.Request.Browser.Platform;
            obj.Time = DateTime.Now;
            obj.Url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            ChapterVisitsService.Insert(obj);

            base.OnResultExecuted(filterContext);
        }
    }
}