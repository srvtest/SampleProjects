using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ApiResponse objApiResponse;

        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        public ActionResult Index(RestaurantUser objRestaurantUserModel, string returnUrl)
        {
            Session["RSession"] = null;
            Session["lstMenus"] = null;
            RestaurantUser objRestaurantUser = new EntityLayer.RestaurantUser();
            // IEnumerable<RestaurantUser> RestaurantUserlist = null;
            try
            {
                if (objRestaurantUserModel != null)
                {
                    DataTable dtRestaurantUser = new DataTable();
                    RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                    // objRestaurantUserModel.Password = Utility.CryptoEngine.Decrypt(objRestaurantUserModel.Password);
                    objApiResponse = objRestaurantUserDL.LoginAdmin(objRestaurantUserModel.Email, objRestaurantUserModel.Password);
                    //  objApiResponse = objRestaurantUserDL.LoginUser(objRestaurantUserModel.Email, Utility.CryptoEngine.Decrypt(objRestaurantUserModel.Password));
                    if (objApiResponse.StatusCode == 200 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        RSession rs = new RSession();
                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
                        {
                            rs.Firstname = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
                            rs.Email = Convert.ToString(ds.Tables[1].Rows[0]["Email"]);
                            rs.UserID = Convert.ToInt32(ds.Tables[1].Rows[0]["Id"]);
                            Session["RSession"] = rs;
                            


                            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                            {
                                List<Access> lstmenus = new List<Access>();
                                lstmenus = ds.Tables[2].AsEnumerable().Select(x => new Access
                                {
                                    AccessID = x.Field<int>("AccessID"),
                                    AccessName = x.Field<string>("AccessName"),
                                    AccessDesc = x.Field<string>("AccessDesc"),
                                    BaseAccessID = x.Field<int>("BaseAccessID"),
                                    PageURL = x.Field<string>("PageURL"),
                                }).ToList();
                                Session["lstMenus"] = lstmenus;
                            }
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Invalid username or password.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        TempData["NotifyMessage"] = objApiResponse.Message;
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                    }
                    //Response.Redirect("~/home/index");
                    //return Redirect("~/home/index");
                    //Login();
                   // return RedirectToLocal(returnUrl);
                    //return RedirectToAction("Index", "DashBoard");
                    //return RedirectToAction("Index", "Home");
                    //return View(objRestaurantUser);
                }
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View(objRestaurantUser);
        }


    }
}