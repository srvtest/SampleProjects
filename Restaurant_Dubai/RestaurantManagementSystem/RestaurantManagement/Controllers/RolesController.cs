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
using Utility;

namespace RestaurantManagement.Controllers
{
    [AccessFilter]
    public class RolesController : Controller
    {
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Roles()
        {
            try
            {
                IEnumerable<Role> roleslist = null;
                DataTable dtRoles = new DataTable();
                RolesDL objRolesDL = new RolesDL();

                objApiResponse = objRolesDL.GetRoles();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    roleslist = ds.Tables[0].AsEnumerable().Select(x => new Role
                    {
                        RolesID = x.Field<int>("RolesId"),
                        RoleName = x.Field<string>("RoleName"),
                        RoleDesc = x.Field<string>("RoleDesc"),
                        RestaurantID = x.Field<int>("RestaurantID")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(roleslist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Roles(int? id)
        {
            try
            {
                RolesDL objRolesDL = new RolesDL();
                objRolesDL.DeleteRole(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Role Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("Roles");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddRole(int? id)
        {
            ViewBag.Title = "Add Role";
            Role objrolesModels = new EntityLayer.Role();
            try
            {
                DataTable dtRoles = new DataTable();
                RolesDL objRolesDL = new RolesDL();
                objApiResponse = objRolesDL.GetRoleById(Convert.ToInt32(id));
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objrolesModels = ds.Tables[0].AsEnumerable().Select(x => new Role
                            {
                                RolesID = x.Field<int>("RolesId"),
                                RoleName = x.Field<string>("RoleName"),
                                RoleDesc = x.Field<string>("RoleDesc"),
                                RestaurantID = x.Field<int>("RestaurantID")
                            }).ToList().FirstOrDefault();
                        }
                    }
                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                        }
                    }
                    ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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

            return View(objrolesModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(Role objRoleModel, int? id)
        {
            ViewBag.Title = "Add Role";
            if (ModelState.IsValid)
            {
                try
                {
                    objRoleModel.RolesID = Convert.ToInt32(id);

                    RolesDL objRolesDL = new RolesDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                  
                    if (id != null)
                    {
                        ViewBag.Title = "Edit Role";
                        objRoleModel.ModifiedBy = rs.UserID;
                      
                        objApiResponse = objRolesDL.UpdateRoles(objRoleModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Role Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Roles");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Default Roles can not be edited";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objRoleModel.CreatedBy = rs.UserID;
                    
                        objApiResponse = objRolesDL.AddRoles(objRoleModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Role Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Roles");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Default Roles can not be edited";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }

                    objApiResponse = objRolesDL.GetRoleById(Convert.ToInt32(id));
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
                                    lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                                }
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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
                return View(objRoleModel);
            }
            else
            {
                return View(objRoleModel);
            }
        }

    }
}