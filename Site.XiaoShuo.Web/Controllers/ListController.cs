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
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index(int CateId, string key, int? page)
        {
            ContentCate cInfo = ContentCateService.SelectObject(CateId);

            int pageSize = 15;
            int rowCount;
            int pageIndex = page == null ? 1 : page.Value;

            FictionSearchInfo search = new FictionSearchInfo();
            search.Title = HttpUtility.UrlDecode(key);
            search.C_C_ID = cInfo.Id;

            IList<Fiction> list = FictionService.SelectPage("*", search.OrderBy, search.ToWhereString(), pageIndex, pageSize, out rowCount);


            ViewBag.list = list;
            ViewBag.key = HttpUtility.UrlDecode(key);

            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            ViewBag.rowCount = rowCount;

            ViewBag.CateName = cInfo.CateName;
            ViewBag.CId = cInfo.Id;

            ViewBag.keywords = string.Format("{0}小说，全网最全小说，免费小说", cInfo.CateName);
            ViewBag.description = string.Format("{0}小说，全网最全小说，免费小说", cInfo.CateName);

            return View();
        }
        
    }
}