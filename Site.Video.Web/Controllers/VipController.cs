using Site.Untity;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Video.Web.Controllers
{
    public class VipController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            //获取套餐内容
            List<ComboInfo> list = ComboInfoService.Select(string.Format(" where c_status={0} order by c_num", (int)SiteEnum.BasicStatus.有效)).ToList();


            ViewData["list"] = list;
            return View();
        }



        public ActionResult Dredge(string code)
        {
            ComboInfo cInfo = ComboInfoService.Select(string.Format(" where c_id='{0}'", code)).FirstOrDefault();

            string message = "开通失败，请稍后再试！";
            if (cInfo != null)
            {

            }
            else
            {
                message = "开通失败，该套餐已经下架，请重新选择其它套餐！";
            }


            return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode(message) });
        }

    }
}