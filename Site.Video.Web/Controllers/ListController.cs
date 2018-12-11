using Site.Video.Web.Filter;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Videos.DataAccess.Service.PartialService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Video.Web.Controllers
{
    public class ListController : Controller
    {

        [Vip]
        public ActionResult Index(int cid, int? page)
        {
            int pageSize = 14;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            VideoCate cInfo = VideoCateService.SelectObject(cid);

            VideoInfoSearchInfo search = new VideoInfoSearchInfo();
            search.v_c_id = cid;

            IList<VideoInfo> list = VideoInfoService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            ViewBag.CateName = cInfo.c_name;
            ViewBag.c_id = cInfo.c_id;

            return View();
        }
    }
}