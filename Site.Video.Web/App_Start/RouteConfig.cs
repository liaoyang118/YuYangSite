using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site.Video.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "List",
              url: "List/{cid}.html",
              defaults: new { controller = "List", action = "Index" }
            );

            routes.MapRoute(
              name: "Detail",
              url: "Detail/{cateId}/{vid}.html",
              defaults: new { controller = "Detail", action = "Index" }
            );

            routes.MapRoute(
              name: "Min",
              url: "Detail/Min/{cateId}/{vid}.html",
              defaults: new { controller = "Detail", action = "Min" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
