using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sistema_Tempus
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "relatorios",
                url: "relatorios/{data}",
                defaults: new { controller = "Home", action = "Relatorios", data = UrlParameter.Optional}
            );
            routes.MapRoute(
          name: "crud",
          url: "crud",
          defaults: new { controller = "Home", action = "Index" }
      );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
