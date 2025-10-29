using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace EcommerceWebsiteB2B.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "Category/{categoryname}", "~/categorypage.aspx");
            routes.MapPageRoute("", "ProductDetail/{productname}", "~/ProductDetail.aspx");
            routes.MapPageRoute("Home", "Home", "~/index.aspx");
            routes.MapPageRoute("", "additionallink/{link}", "~/additionallink.aspx");
            routes.MapPageRoute("", "Account/{link}", "~/account.aspx");
            routes.MapPageRoute("", "products/{mastercategoryname}", "~/products.aspx");
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}