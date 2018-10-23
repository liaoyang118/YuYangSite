using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Site.Cars.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            string strAssemblyFilePath = Assembly.GetExecutingAssembly().Location;
            return Content(strAssemblyFilePath);
        }
    }
}