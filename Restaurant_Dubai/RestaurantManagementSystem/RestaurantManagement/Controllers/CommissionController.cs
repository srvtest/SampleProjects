
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using EntityLayer;
using System.Data;
using DataLayer;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    [AccessFilter]
    public class CommissionController : Controller
    {
        // GET: Commission	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Commission()
        {
            try
            {
                RSession rs = new RSession();
                rs = (RSession)Session["RSession"];
                IEnumerable<Commission> Commissionlist = null;
                DataTable dtCommission = new DataTable();
                CommissionDL objCommissionDL = new CommissionDL();
                objApiResponse = objCommissionDL.GetCommission();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    Commissionlist = ds.Tables[0].AsEnumerable().Select(x => new Commission
                    {
                        RoleID = x.Field<int>("RoleID"),
                        CommissionID = x.Field<int>("CommissionID"),
                        UserID = x.Field<int>("UserID"),
                        Percentage = x.Field<decimal>("Percentage"),
                        Desc = x.Field<string>("Desc"),
                        RestaurantName = x.Field<string>("Name")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Commissionlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Commission(int? id)
        {
            try
            {
                CommissionDL objCommissionDL = new CommissionDL();
                objCommissionDL.DeleteCommission(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Commission Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("Commission");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddCommission(int? id)
        {
            ViewBag.Title = "Add Commission";
            Commission objCommissionModels = new EntityLayer.Commission();
            try
            {
                List<Role> lstRole = new List<Role>();
                List<RestaurantUser> lstRestaurantUser = new List<RestaurantUser>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                CommissionDL objCommissionDL = new CommissionDL();
                objApiResponse = objCommissionDL.GetCommissionById(Convert.ToInt32(id));               
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objCommissionModels = ds.Tables[0].AsEnumerable().Select(x => new Commission
                            {
                                RoleID = x.Field<int>("RoleID"),
                               // CommissionID = x.Field<int>("CommissionID"),
                                UserID = x.Field<int>("UserID"),
                                Percentage = x.Field<decimal>("Percentage"),
                                Desc = x.Field<string>("Desc"),
                                RestaurantName = x.Field<string>("Name")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesID"]), RoleName = Convert.ToString(dr["RoleName"]) });
                            }
                        }
                        ViewBag.UserRole = new SelectList(lstRole, "RolesID", "RoleName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstRestaurantUser.Add(new RestaurantUser { UserID = Convert.ToInt32(dr["UserID"]), Firstname = Convert.ToString(dr["Firstname"]) });
                            }
                        }
                        ViewBag.UserRestaurantUser = new SelectList(lstRestaurantUser, "UserID", "Firstname");
                        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[3].Rows)
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

            return View(objCommissionModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCommission(Commission objCommissionModel, int? id)
        {
            ViewBag.Title = "Add Commission";

            if (ModelState.IsValid)
            {
                try
                {
                    //objCommissionModel.CommissionID = 1;	 
                    objCommissionModel.CommissionID = Convert.ToInt32(id);
                    CommissionDL objCommissionDL = new CommissionDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    if (id != null)
                    {
                        ViewBag.Title = "Edit Commission";
                        //objCommissionModel.RoleID = rs.RoleId;
                        objApiResponse = objCommissionDL.UpdateCommission(objCommissionModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Commission Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Commission");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Commission ID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        //objCommissionModel.RoleID = rs.RoleId;
                        objApiResponse = objCommissionDL.AddCommission(objCommissionModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Commission Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Commission");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "RoleID, UserID & RestaurantID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objCommissionDL.GetCommissionById(Convert.ToInt32(id));
                    List<Role> lstRole = new List<Role>();
                    List<RestaurantUser> lstRestaurantUser = new List<RestaurantUser>();
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
                                    lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesID"]), RoleName = Convert.ToString(dr["RoleName"]) });
                                }
                            }
                            ViewBag.UserRole = new SelectList(lstRole, "RolesID", "RoleName");
                            if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[2].Rows)
                                {
                                    lstRestaurantUser.Add(new RestaurantUser { UserID = Convert.ToInt32(dr["UserID"]), Firstname = Convert.ToString(dr["Firstname"]) });
                                }
                            }
                            ViewBag.UserRestaurantUser = new SelectList(lstRestaurantUser, "UserID", "Firstname");
                            if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[3].Rows)
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
                return View(objCommissionModel);
            }
            else
            {
                return View(objCommissionModel);
            }
        }
    }
}