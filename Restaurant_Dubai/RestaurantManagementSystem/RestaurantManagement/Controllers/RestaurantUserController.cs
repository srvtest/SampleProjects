using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagement.Models;
using DataLayer;
using EntityLayer;
using ExceptionManager;
using System.Data;

namespace RestaurantManagement.Controllers
{

    public class RestaurantUserController : Controller
    {
        // GET: RestaurantUser
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            Session["RSession"] = null;

            return View();
        }

        public ActionResult LogOff()
        {
            Session.Remove("RSession");
            return RedirectToAction("Login", "RestaurantUser");
        }
        //[AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["RSession"] != null)
            {
                RSession rs = new RSession();
                rs = (RSession)Session["RSession"];
                if (!string.IsNullOrEmpty(rs.Email))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        //[AllowAnonymous]
        [HttpPost]
        public ActionResult Login(RestaurantUser objRestaurantUserModel, string returnUrl)
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
                    //objApiResponse = objRestaurantUserDL.LoginUser(objRestaurantUserModel.Email, objRestaurantUserModel.Password);
                      objApiResponse = objRestaurantUserDL.LoginUser(objRestaurantUserModel.Email, Utility.CryptoEngine.Encrypt(objRestaurantUserModel.Password));
                    if (objApiResponse.StatusCode == 200 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        RSession rs = new RSession();
                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            rs.RoleId = Convert.ToInt32(ds.Tables[1].Rows[0]["RolesID"]);
                            rs.Firstname = Convert.ToString(ds.Tables[1].Rows[0]["Firstname"]);
                            rs.LastName = Convert.ToString(ds.Tables[1].Rows[0]["LastName"]);
                            rs.Email = Convert.ToString(ds.Tables[1].Rows[0]["Email"]);
                            rs.RoleName = Convert.ToString(ds.Tables[1].Rows[0]["RoleName"]);
                            rs.MenuAccess = Convert.ToString(ds.Tables[1].Rows[0]["MenuAccess"]);
                            rs.MenuAccessID = Convert.ToString(ds.Tables[1].Rows[0]["MenuAccessID"]);
                            rs.UserID = Convert.ToInt32(ds.Tables[1].Rows[0]["UserID"]);
                            rs.RestaurentId = Convert.ToInt32(ds.Tables[1].Rows[0]["RestaurantID"]);
                            rs.RestaurentName = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);
                            rs.Logo = Convert.ToString(ds.Tables[1].Rows[0]["Logo"]);
                            rs.TimeFrom = Convert.ToString(ds.Tables[1].Rows[0]["TimeFrom"]);
                            rs.TimeTo = Convert.ToString(ds.Tables[1].Rows[0]["TimeTo"]);
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
                            return View(objRestaurantUser);
                        }
                    }
                    else
                    {
                        TempData["NotifyMessage"] = objApiResponse.Message;
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                        return View(objRestaurantUser);
                    }
                    //Response.Redirect("~/home/index");
                    //return Redirect("~/home/index");
                    //Login();
                  //TempData.Keep();
                    return RedirectToLocal(returnUrl);
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
        [AllowAnonymous]
        private ActionResult RedirectToLocal(string returnUrl)
        {

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Index", "DashBoard");
            //return Redirect("~/Home/Index");

            // return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword(RestaurantLogin objRestaurantLogin)
        {
            //RestaurantUser objRestaurantUser = new EntityLayer.RestaurantUser();
            //if (ModelState.IsValid)
            //{
            //IEnumerable<RestaurantUser> RestaurantUserlist = null;
            try
            {
                if (objRestaurantLogin.EmailID != null)
                {
                    RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                    objApiResponse = objRestaurantUserDL.Forgetpassword(objRestaurantLogin.EmailID);
                    if (objApiResponse != null && objApiResponse.StatusCode == 200)
                    {
                        TempData["NotifyMessage"] = "Password sent  to your email please check.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                        string userid = string.Empty;
                        DataTable dt = (DataTable)objApiResponse.Result;
                        if (dt != null && dt.Rows.Count > 0)
                            userid = Convert.ToString(dt.Rows[0]["UserID"]);
                        string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                        string subject = "Reset Password";
                        string body = "Hi,<br/><br/>We got a request to reset your account password. Please click on the link below to reset your password" +
                              "<br/><br/><a href=" + baseUrl + "RestaurantUser/ResetPassword?prm=" + Utility.CryptoEngine.Encrypt(userid) + " > Reset Password link</a>";

                        Utility.CommonEnums.SendEmail(objRestaurantLogin.EmailID, subject, body);
                    }
                    else
                    {
                        TempData["NotifyMessage"] = "Invalid email.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                        //send email                      
                    }
                    return View(objRestaurantLogin);
                }
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            //}
            //else
            //{
            //    return View();
            //}
            return View(objRestaurantLogin);
        }

        [AllowAnonymous]
        public ActionResult ChangePassword(string emailID, string oldPassword, string Password)
        {
            RestaurantUser objRestaurantUser = new EntityLayer.RestaurantUser();
            //IEnumerable<RestaurantUser> RestaurantUserlist = null;
            try
            {

                if (emailID != null)
                {
                    RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();

                    objApiResponse = objRestaurantUserDL.Changepassword(emailID, Utility.CryptoEngine.Encrypt(oldPassword), Utility.CryptoEngine.Encrypt(Password));
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        TempData["NotifyMessage"] = "Password changed successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                        string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                        string subject = "Change Password";
                        string body = "Hi,<br/>br/>We got request for change password your account password. It's successfully change password.";
                        // "<br/><br/><a href=" + baseUrl + "RestaurantUser/forgetpassword?pwd=" + Utility.CryptoEngine.Encrypt(emailID) + " > Reset Password link</a>";

                        Utility.CommonEnums.SendEmail(emailID, subject, body);
                    }
                    else
                    {
                        TempData["NotifyMessage"] = "Invalid email.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                    //send email

                    return View(objRestaurantUser);
                }
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View(objRestaurantUser);
        }

        public ActionResult RestaurantUser()
        {

            try
            {
                IEnumerable<RestaurantUser> RestaurantUserlist = null;
                DataTable dtRestaurantUser = new DataTable();
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();

                objApiResponse = objRestaurantUserDL.GetRestaurantUser();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    RestaurantUserlist = ds.Tables[0].AsEnumerable().Select(x => new RestaurantUser
                    {
                        UserID = x.Field<int>("UserID"),
                        Firstname = x.Field<string>("Firstname"),
                        LastName = x.Field<string>("LastName"),
                        Gender = x.Field<int>("Gender"),
                        Email = x.Field<string>("Email"),
                        Mobile = x.Field<string>("Mobile"),
                        Address = x.Field<string>("Address"),
                       OfficeAddress = x.Field<string>("OfficeAddress")
                    });


                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(RestaurantUserlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult RestaurantUser(int? id)
        {
            try
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                objRestaurantUserDL.DeleteRestaurantUser(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Restaurant User Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("restaurantuser");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        public ActionResult AddRestaurantUser(int? id)
        {
            //ViewBag.Title = "Add RestaurantUser";
            RestaurantUser objRestaurantUser = new EntityLayer.RestaurantUser();
            try
            {
                RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                List<Role> lstRole = new List<Role>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                objApiResponse = objRestaurantUserDL.GetRestaurantUserById(Convert.ToInt32(id));

              
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {

                            objRestaurantUser = ds.Tables[0].AsEnumerable().Select(x => new RestaurantUser
                            {
                                UserID = Convert.ToInt32(id),
                                Firstname = x.Field<string>("Firstname"),
                                LastName = x.Field<string>("LastName"),
                                Gender = x.Field<int>("Gender"),
                                Email = x.Field<string>("Email"),
                                Mobile = x.Field<string>("Mobile"),
                                Address = x.Field<string>("Address"),
                                OfficeAddress = x.Field<string>("OfficeAddress"),
                                IsActive = x.Field<bool>("IsActive"),
                                Password = x.Field<string>("Password"),
                                //IpAddress = x.Field<string>("IpAddress"),
                                RolesID = x.Field<int>("RolesID"),
                                RestaurantID = x.Field<int>("RestaurantID")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesId"]), RoleName = Convert.ToString(dr["RoleName"]) });
                            }
                        }
                        ViewBag.UserRole = new SelectList(lstRole, "RolesId", "RoleName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }

            return View(objRestaurantUser);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddRestaurantUser(RestaurantUser objRestaurantUserModel, int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objRestaurantUserModel.CreatedBy = rs.UserID;
                    RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                    if (id != null)
                    {
                        ViewBag.Title = "Edit Restaurant User";
                        objApiResponse = objRestaurantUserDL.UpdateRestaurantUser(objRestaurantUserModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Restaurant User Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("RestaurantUser");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "User ID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        ViewBag.Title = "Add Restaurant User";
                        objApiResponse = objRestaurantUserDL.AddRestaurantUser(objRestaurantUserModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Restaurant User Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("RestaurantUser");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Email already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }

                    objApiResponse = objRestaurantUserDL.GetRestaurantUserById(Convert.ToInt32(id));
                    List<Role> lstRole = new List<Role>();
                    List<Restaurant> lstRestaurant = new List<Restaurant>();
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesId"]), RoleName = Convert.ToString(dr["RoleName"]) });
                                }
                            }
                            ViewBag.UserRole = new SelectList(lstRole, "RolesId", "RoleName");
                            if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[2].Rows)
                                {
                                    lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                                }
                            }
                            ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        }
                    }
                    else
                    {
                        TempData["NotifyMessage"] = objApiResponse.Message;
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(new RestaurantUser());
            }
            else
            {
                return View(objRestaurantUserModel);
            }
        }


        [AllowAnonymous]
        public ActionResult ResetPassword(RestaurantLogin resetPass, string prm = null)
        {
            if (!string.IsNullOrEmpty(prm))
            {
                string userid = Utility.CryptoEngine.Decrypt(prm);
                if (!string.IsNullOrEmpty(userid))
                {
                    resetPass.UserID = Convert.ToInt32(userid);
                    
                    return View(resetPass);
                }
            }
            else if (resetPass != null)
            {
                ModelState.Remove("EmailID");
                if (ModelState.IsValid)
                {
                    if (resetPass.UserID > 0)
                    {
                        RestaurantUserDL objRestaurantUserDL = new RestaurantUserDL();
                        objApiResponse = objRestaurantUserDL.ResetPassword(resetPass.UserID, Utility.CryptoEngine.Encrypt(resetPass.NewPassword));
                        if(objApiResponse.StatusCode == 200)
                        {
                            TempData["NotifyMessage"] = "Password changed successfully.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            TempData.Keep();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                TempData["NotifyMessage"] = "Error...Try again...";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }
    }
}