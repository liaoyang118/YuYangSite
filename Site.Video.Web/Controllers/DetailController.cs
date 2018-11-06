using Site.Video.Web.Filder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Video.Web.Controllers
{
    public class DetailController : Controller
    {
        [Vip]
        public ActionResult Detail(string gid)
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult Min(string vid)
        {
            return View();
        }
    }
}