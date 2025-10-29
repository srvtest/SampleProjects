using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebsite
{
    public static class Utility
    {
        public static string GetBaseUrl()
        {
            System.Web.UI.Page page = (System.Web.UI.Page)HttpContext.Current.Handler;
            return page.ResolveUrl("~/");
        }
    }
}