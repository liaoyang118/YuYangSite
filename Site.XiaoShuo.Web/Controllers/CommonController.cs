using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;
using Site.XiaoShuo.DataAccess.Service.PartialService.Search;

namespace Site.XiaoShuo.Web.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Search(string key, int? page)
        {

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            FictionSearchInfo search = new FictionSearchInfo();
            search.Title = HttpUtility.UrlDecode(key);

            IList<Fiction> list = FictionService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;


            return View();
        }

        //上报错误
        public ActionResult Reported()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Reported(string title)
        {
            return View();
        }

        //最热阅读
        public ActionResult HotRead()
        {
            int rowCount;
            IList<FictionVisits> list = FictionVisitsService.SelectPageExcuteSql("t1.*,t2.Title as Fiction_Title,t2.Author as Fiction_Author,t2.Id as Fiction_Id", "t1.Visits DESC", " RIGHT JOIN dbo.Fiction AS t2 ON t2.Id=t1.F_Id ", 1, 9, out rowCount);

            ViewBag.list = list;
            return PartialView();
        }

        //推荐阅读
        public ActionResult RecomendRead()
        {
            int rowCount;
            IList<FictionVisits> list = FictionVisitsService.SelectPageExcuteSql("t1.*,t2.Title as Fiction_Title,t2.Author as Fiction_Author,t2.Id as Fiction_Id", "t2.LastUpdateTime DESC", " RIGHT JOIN dbo.Fiction AS t2 ON t2.Id=t1.F_Id ", 1, 9, out rowCount);

            ViewBag.list = list;
            return PartialView();
        }


    }
}