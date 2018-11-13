using Site.Video.Web.Filder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Untity;
using Site.Videos.DataAccess.Service.PartialService.Search;

namespace Site.Video.Web.Controllers
{
    public class DetailController : Controller
    {
        [Vip]
        public ActionResult Index(int cateId, int vid)
        {
            VideoCate vcInfo = VideoCateService.SelectObject(cateId);
            VideoInfo vInfo = VideoInfoService.SelectObject(vid);
            if (vInfo != null && vInfo.v_status.Value == (int)SiteEnum.BasicStatus.有效)
            {
                VideoInfoSearchInfo searchInfo = new VideoInfoSearchInfo();
                searchInfo.v_c_id = vcInfo.c_id;

                int rowcount;
                IList<VideoInfo> list = VideoInfoService.SelectPage("* ", " v_createTime desc ", searchInfo.ToWhereString(), 1, 6, out rowcount);

                ViewData["cateInfo"] = vcInfo;
                ViewData["vInfo"] = vInfo;
                ViewData["list"] = list;
            }
            else
            {
                return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode("访问的视频已经不存在，请重新访问其它页面！") });
            }

            return View();
        }



        public ActionResult Min(int cateId, int vid)
        {
            VideoCate vcInfo = VideoCateService.SelectObject(cateId);
            VideoInfo vInfo = VideoInfoService.SelectObject(vid);
            if (vInfo != null && vInfo.v_status.Value == (int)SiteEnum.BasicStatus.有效)
            {
                VideoInfoSearchInfo searchInfo = new VideoInfoSearchInfo();
                searchInfo.v_c_id = vcInfo.c_id;

                int rowcount;
                IList<VideoInfo> list = VideoInfoService.SelectPage("* ", " v_createTime desc ", searchInfo.ToWhereString(), 1, 6, out rowcount);



                ViewData["cateInfo"] = vcInfo;
                ViewData["vInfo"] = vInfo;
                ViewData["list"] = list;

            }
            else
            {
                return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode("访问的视频已经不存在，请重新访问其它页面！") });
            }
            return View();
        }
    }
}