
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Video.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int rowCount;
            List<VideoInfo> infos = VideoInfoService.SelectPage("*", "", "", 1, 10, out rowCount).ToList();

            ViewData["list"] = infos;
            return View();
        }


        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}