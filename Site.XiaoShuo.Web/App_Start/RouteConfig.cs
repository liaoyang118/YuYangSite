using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site.XiaoShuo.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "List",
              url: "List/{CateId}.html",
              defaults: new { controller = "List", action = "Index" }
            );

            routes.MapRoute(
              name: "Introduce",
              url: "Introduce/{Id}.html",
              defaults: new { controller = "Introduce", action = "Index" }
            );

            routes.MapRoute(
             name: "Detail",
             url: "Detail/{fid}/{cid}.html",
             defaults: new { controller = "Detail", action = "Index" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
