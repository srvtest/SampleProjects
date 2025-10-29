using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RestaurantManagement.Models
{
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<Access> lstMenus = new List<Access>();
            lstMenus = (List<Access>)HttpContext.Current.Session["lstMenus"];
            RSession rs = new RSession();
            rs = (RSession)HttpContext.Current.Session["RSession"];
            if(rs == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "RestaurantUser" },
                                          { "action", "Login" }
                                                         });
            }
            if (lstMenus != null)
            {
                lstMenus = lstMenus.Where(x => x.PageURL.StartsWith(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/")).ToList<Access>();
                //lstMenus = lstMenus.Where(x=> x.PageURL.Any(y=>y.))
                //lstMenus = lstMenus.Where(x => x.PageURL.Contains(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/")).ToList<Access>();
                if (lstMenus != null && lstMenus.Count > 0)
                    base.OnActionExecuting(filterContext);
                else
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "RestaurantUser" },
                                          { "action", "Login" }
                                                         });
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}