using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RestaurantManagement.Models;
namespace RestaurantManagement.Controllers
{
    
    public class HomeController : Controller
    {
        public void InitializeController(RequestContext context)
        {
            base.Initialize(context);
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}