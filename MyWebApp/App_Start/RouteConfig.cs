using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //route.ignoreRoute 忽略*.asd格式的網址路徑，*pathInfo的*表示CatchAll任何字串包含空白都算。
            //eg. 網址為/WebResource.axd/a/b/c/d的話，{resource}.axd = WebResource.axd
            //, {*pathInfo} = a/b/c/d，若{*pathInfo}沒星號，則{pathInfo} = a
            //不要透過ASP.NET MVC執行，改由IIS的其他HttpModules進行處理。目的是要讓ASP.NET MVC與Webform可以在同一個站台下執行不互相影響。
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}