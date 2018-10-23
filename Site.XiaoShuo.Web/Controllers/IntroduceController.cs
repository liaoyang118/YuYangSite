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
    public class IntroduceController : Controller
    {
        // GET: Introduce
        public ActionResult Index(int Id)
        {
            Fiction fInfo = FictionService.SelectObject(Id);
            if (fInfo == null)
            {
                return RedirectToAction("NotFound", "Common");
            }

            ContentCate cInfo = ContentCateService.SelectObject(fInfo.C_C_ID);

            //作者作品
            IList<Fiction> rList = FictionService.Select(string.Format("where Author=N'{0}' and Title <>N'{1}'", fInfo.Author, fInfo.Title));

            //相关阅读推荐
            int rowCount;
            IList<FictionVisits> recList = FictionVisitsService.SelectPageExcuteSql("t1.*,t2.Title as Fiction_Title,t2.Author as Fiction_Author,t2.Id as Fiction_Id", "t1.Visits DESC", string.Format("RIGHT JOIN dbo.Fiction AS t2 ON t2.Id=t1.F_Id WHERE t2.C_C_ID = {0}", fInfo.C_C_ID), 1, 3, out rowCount);

            //章节列表
            //IList<ChapterList> chpList = ChapterListService.Select(string.Format("where F_ID={0} order by UpdateTime,ChapterSort", fInfo.Id), cInfo.Id);

            //MongoDB
            IList<Mongo_ChapterList> chpList = Mongo_ChapterListService.Select(u => u.F_ID == fInfo.Id, cInfo.Id).OrderBy(sort => sort.UpdateTime).OrderBy(sort => sort.ChapterSort).ToList();

            
            ViewBag.fInfo = fInfo;
            ViewBag.cInfo = cInfo;
            ViewBag.rList = rList;
            ViewBag.recList = recList;
            ViewBag.chpList = chpList;

            ViewBag.keywords = string.Format("{0}小说，{1}-{2}-章节列表，全网最全小说，免费小说", cInfo.CateName, fInfo.Title, fInfo.Author);
            ViewBag.description = string.Format("{0}小说，{1}-{2}-章节列表，全网最全小说，免费小说", cInfo.CateName, fInfo.Title, fInfo.Author);

            return View();
        }
    }
}