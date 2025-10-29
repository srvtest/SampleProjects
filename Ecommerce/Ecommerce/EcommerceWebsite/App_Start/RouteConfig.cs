using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace EcommerceWebsite
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
       
            routes.MapPageRoute("", "Category/{categoryname}", "~/categorypage.aspx");
            routes.MapPageRoute("", "ProductDetail/{productname}", "~/ProductDetail.aspx");
            routes.MapPageRoute("Home", "Home", "~/index.aspx");
            routes.MapPageRoute("", "AdditionalLink/{link}", "~/AdditionalLink.aspx");
            routes.MapPageRoute("", "Account/{link}", "~/account.aspx");
            routes.MapPageRoute("", "Products/{mastercategoryname}", "~/Products.aspx");
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
