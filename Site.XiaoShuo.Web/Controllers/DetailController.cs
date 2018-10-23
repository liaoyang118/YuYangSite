using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.XiaoShuo.DataAccess.Model;
using Site.XiaoShuo.DataAccess.Service;
using Site.XiaoShuo.Web.Filter;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Site.XiaoShuo.Web.Controllers
{
    public class DetailController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fid">小说ID</param>
        /// <param name="cid">章节id</param>
        /// <returns></returns>
        [VisitsLog]
        public ActionResult Index(int fid, string cid)
        {
            Fiction fInfo = FictionService.SelectObject(fid);
            ContentCate cInfo = ContentCateService.SelectObject(fInfo.C_C_ID);
            try
            {
                ObjectId bid = new ObjectId(cid);
                Mongo_ChapterList clInfo = Mongo_ChapterListService.SelectObject(u => u.Id == bid, cInfo.Id);


                ViewBag.fInfo = fInfo;
                ViewBag.cInfo = cInfo;
                ViewBag.clInfo = clInfo;

                ViewBag.keywords = string.Format("{0}小说，{1}-{2}-{3}-{4}，全网最全小说，免费小说", cInfo.CateName, fInfo.Title, clInfo.ChapterIndex, clInfo.ChapterName, fInfo.Author);
                ViewBag.description = string.Format("{0}小说，{1}-{2}-{3}-{4}，全网最全小说，免费小说", cInfo.CateName, fInfo.Title, clInfo.ChapterIndex, clInfo.ChapterName, fInfo.Author);

                //记录阅读统计日志
                FictionVisits fv = new FictionVisits();
                fv.F_Id = fInfo.Id;
                fv.C_Id = cInfo.Id;
                FictionVisitsService.Insert(fv);
            }
            catch
            {
                return RedirectToAction("error", "common");
            }
            return View();
        }

        /// <summary>
        /// 上一章，下一章
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="cid"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public ActionResult Chapter(int fid, string cid, string o)
        {
            Fiction fInfo = FictionService.SelectObject(fid);
            ContentCate cInfo = ContentCateService.SelectObject(fInfo.C_C_ID);
            ObjectId bid = new ObjectId(cid);
            Mongo_ChapterList clInfo = Mongo_ChapterListService.SelectObject(u => u.Id == bid, cInfo.Id);
            if (o == "n")
            {
                clInfo = Mongo_ChapterListService.Select(u => u.F_ID == fid && u.ChapterSort > clInfo.ChapterSort, Builders<Mongo_ChapterList>.Sort.Ascending("ChapterSort"), cInfo.Id).FirstOrDefault();
            }
            else
            {
                clInfo = Mongo_ChapterListService.Select(u => u.F_ID == fid && u.ChapterSort < clInfo.ChapterSort, Builders<Mongo_ChapterList>.Sort.Descending("ChapterSort"), cInfo.Id).FirstOrDefault();
            }

            if (clInfo == null)
            {
                return RedirectToAction("Index", "Introduce", new { Id = fid });
            }
            else
            {
                return RedirectToAction("Index", new { fid, cid = clInfo.Id.ToString() });
            }
        }

    }
}