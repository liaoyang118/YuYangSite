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
            return View();
        }
        

        [HttpPost]
        public ActionResult Index(string vipCode)
        {
            return View();
        }

    }
}