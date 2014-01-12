using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Waterproofing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "Content" });


            routes.MapRoute(
                "high-tech-waterproofing",
                "high-tech-waterproofing",
                new { controller = "Home", action = "HighTechWaterproofing" }
                );

            routes.MapRoute(
                "crawlspace-encapsulation",
                "crawlspace-encapsulation",
                new { controller = "Home", action = "CrawlspaceEncapsulation" }
                );

            routes.MapRoute(
                "foundation-crack-repair",
                "foundation-crack-repair",
                new { controller = "Home", action = "FoundationCrackRepair" }
                );

            routes.MapRoute(
                "basement-drain-tile-system",
                "basement-drain-tile-system",
                new { controller = "Home", action = "BasementDrainTileSystem" }
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "HighTechWaterproofing", id = UrlParameter.Optional }
                );
        }
    }
}