
using Site.Untity;
using Site.Video.Web.Tools;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Video.Web.Filter;
using Site.XiaoShuo.Web.Filter;

namespace Site.Video.Web.Controllers
{
    public class HomeController : Controller
    {

        [Vip]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous, VisitsLog]
        public ActionResult Min()
        {
            if (HttpContextUntity.CurrentUser != null)
            {
                UserInfo uInfo = HttpContextUntity.CurrentUser;
                if (uInfo.u_level != (int)SiteEnum.AccountLevel.普通用户)
                {
                    if (uInfo.u_expriseTime != null && uInfo.u_expriseTime.Value < DateTime.Now.AddDays(1))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }

    }
}