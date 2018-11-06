using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.Video.Web.Tools;
using Site.Videos.DataAccess.Model;

namespace Site.Video.Web.Filder
{
    /// <summary>
    /// 会员验证
    /// </summary>
    public class VipAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 超级管理员验证
        /// </summary>
        public bool AllowSuperAdmin { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string httpMethod = filterContext.RequestContext.HttpContext.Request.HttpMethod.ToLower();
            UserInfo uInfo = HttpContextUntity.CurrentUser;
            if (uInfo == null)
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                //验证超级管理员
                if (uInfo.u_level != (int)SiteEnum.AccountLevel.普通用户)
                {
                    if (uInfo.u_expriseTime != null && uInfo.u_expriseTime.Value < DateTime.Now)
                    {
                        if (httpMethod == "post")
                        {
                            filterContext.Result = new JsonResult() { Data = UntityTool.JsonResult(false, "请先开通Vip") };
                            return;
                        }
                        else
                        {
                            //无权限访问
                            filterContext.Result = new RedirectResult("/Vip/Index");
                            return;
                        }
                    }
                }
                else
                {
                    if (httpMethod == "post")
                    {
                        filterContext.Result = new JsonResult() { Data = UntityTool.JsonResult(false, "请先开通Vip") };
                        return;
                    }
                    else
                    {
                        //无权限访问
                        filterContext.Result = new RedirectResult("/Vip/Index");
                        return;
                    }
                }
            }

        }
    }
}