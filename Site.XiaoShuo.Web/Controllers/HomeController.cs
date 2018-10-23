using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Untity;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;

namespace Site.XiaoShuo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //最近更新
        public ActionResult LastUpdate()
        {
            string ip = UntityTool.GetConfigValue("RedisIp");
            int port = UntityTool.GetConfigValue("RedisPort").ToInt32(0);
            Redis.Core.Core redis = new Redis.Core.Core(ip, port);
            List<Fiction> list = redis.Get<List<Fiction>>("sdg_lastupdate");
            if (list == null)
            {
                int rowCount;
                list = FictionService.SelectPageExcuteSql("t1.*,t2.CateName", "LastUpdateTime DESC", " left join ContentCate as t2 on t2.Id=t1.C_C_ID where t1.LastUpdateChapter !=N'' ", 1, 30, out rowCount).ToList();
                redis.Set<List<Fiction>>("sdg_lastupdate", list, new TimeSpan(0, 10, 0));
            }
            ViewBag.list = list;
            return PartialView();
        }



    }
}