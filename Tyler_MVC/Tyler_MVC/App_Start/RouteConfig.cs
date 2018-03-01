using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tyler_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Contact", "Contact", new { controller = "Home", action = "Contact" });
            routes.MapRoute("About", "About", new { controller = "About", action = "About" });

            //test routes
            routes.MapRoute("MovieLibrary", "MovieLibrary", new { controller = "Home", action = "MovieLibrary" });
            routes.MapRoute("ShowLibrary", "ShowLibrary", new { controller = "Home", action = "ShowLibrary" });
            
            //Inclass
            routes.MapRoute("Languages", "Index", new { controller = "Products", action = "Index" });

            //Providers
            routes.MapRoute("MovieShow", "Netflix", new { controller = "Providers", action = "Netflix" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
