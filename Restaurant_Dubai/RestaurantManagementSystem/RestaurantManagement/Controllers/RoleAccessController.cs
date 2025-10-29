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
    [AccessFilter]
    public class RoleAccessController : Controller
    {
        ApiResponse objApiResponse;
        // GET: RoleAccess
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        ///  Method to get the list of role Access
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleAccess()
        {
            try
            {
                ViewBag.Title = "RoleAccess";
                List<RoleAccessMaster> lstRoleAccessMaster = new List<RoleAccessMaster>();
                DataTable dtRoleAccess = new DataTable();
                RoleAccessDL objRoleAccessDL = new RoleAccessDL();
                RSession rs = new RSession();
                rs = (RSession)Session["RSession"];
              
                objApiResponse = objRoleAccessDL.GetRoleAccessList(1);  ///// Here we will pass the restaurantID from session
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    lstRoleAccessMaster = ds.Tables[0].AsEnumerable().Select(x => new RoleAccessMaster
                    {
                        RestaurentName = x.Field<string>("Name"),
                        RestaurentID = x.Field<Int32>("RestaurentID"),
                        Descp = x.Field<string>("Descp"),
                        RolesID = x.Field<Int32>("RolesID"),
                        RoleAccessMasterID = Convert.ToInt32(x.Field<Int32>("RoleAccessMasterID")),
                        MenuAccess = x.Field<string>("MenuAccess"),
                        RoleName = x.Field<string>("RoleName")
                    }).ToList();
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(lstRoleAccessMaster);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        /// <summary>
        ///  Method to delete the role Access
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult RoleAccess(int? id)
        {
            try
            {
              RoleAccessMasterDL objRoleAccessMaster = new RoleAccessMasterDL();
                objRoleAccessMaster.DeleteRoleAccessMaster(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "RoleAccess Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("RoleAccess");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        public ActionResult AddRoleAccess(int? id)
        {
            if (id == null)
                id = 0;
            ViewBag.Title = "Add RoleAccess";
            if (id > 0)
            {
                ViewBag.Title = "Edit RoleAccess";
            }

            //objApiResponse = new ApiResponse();
            ViewRoleAccessMaster objViewRoleAccessMaster = new ViewRoleAccessMaster();
            DataSet ds = null;
            RoleAccessDL objRoleAccessDL = new RoleAccessDL();
            objApiResponse = objRoleAccessDL.GetRoleAccessById(Convert.ToInt32(id));
            if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            {
                ds = (DataSet)objApiResponse.Result;
                if (ds != null && ds.Tables.Count > 0)
                {
                    objViewRoleAccessMaster.objRoleAccessMaster = new RoleAccessMaster();
                    
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                         objViewRoleAccessMaster.objRoleAccessMaster = ds.Tables[0].AsEnumerable().Select(x => new RoleAccessMaster
                        {
                            RoleAccessMasterID = x.Field<int>("RoleAccessMasterID"),
                            RolesID = x.Field<int>("RoleID"),
                            RestaurentID = x.Field<int>("RestaurentID"),
                            Descp = x.Field<string>("Descp")
                        }).ToList().FirstOrDefault();
                    }
                    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        objViewRoleAccessMaster.lstRoleAccess = ds.Tables[1].AsEnumerable().Select(x => new RoleAccess
                        {
                            UserRoleAccessID = x.Field<int>("UserRoleAccessID"),
                            AccessID = x.Field<int>("AccessID"),
                            RoleAccessMasterID = x.Field<int>("RoleAccessMasterID")
                        }).ToList();
                    }
                    if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                    {
                        objViewRoleAccessMaster.lstAccess = ds.Tables[2].AsEnumerable().Select(x => new Access
                        {
                            AccessID = x.Field<int>("AccessID"),
                            AccessName = x.Field<string>("AccessName")
                        }).ToList();
                    }
                    if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                    {
                        objViewRoleAccessMaster.lstRole = ds.Tables[3].AsEnumerable().Select(x => new Role
                        {
                            RolesID = x.Field<int>("RolesId"),
                            RoleName = x.Field<string>("RoleName")
                        }).ToList();
                    }
                    if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                    {
                        objViewRoleAccessMaster.lstRestaurant = ds.Tables[4].AsEnumerable().Select(x => new Restaurant
                        {
                            RestaurantID = x.Field<int>("RestaurantID"),
                            Name = x.Field<string>("RestaurantName")
                        }).ToList();
                    }
                }
            }


            //try
            //{
            //    DataTable dtCity = new DataTable();


            //    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            //    {
            //        ds = (DataSet)objApiResponse.Result;

            //        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataTable dtRoleAccess = ds.Tables[0];
            //            objRoleAccessMaster.lstRoleAccess = dtRoleAccess.AsEnumerable().Select(x => new RoleAccess
            //            {
            //                AccessID = x.Field<int>("AccessID"),
            //                RolesID = x.Field<int>("RolesID"),
            //                //Desc = x.Field<string>("[Desc]"),
            //                //RestaurantID = x.Field<int>("RestaurantID"),


            //            }).ToList();


            //        }
            //    }


            //    List<Access> lstAccess = new List<Access>();
            //    if (ds != null && ds.Tables.Count > 1)
            //    {
            //        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[1].Rows)
            //            {
            //                lstAccess.Add(new Access { AccessID = Convert.ToInt32(dr["AccessID"]), AccessName = Convert.ToString(dr["AccessName"]) });
            //            }
            //        }
            //    }

            //    objRoleAccessMaster.lstAccess = lstAccess;

            //    List<Role> lstRole = new List<Role>();
            //    if (ds != null && ds.Tables.Count > 2)
            //    {
            //        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[2].Rows)
            //            {
            //                lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesId"]), RoleName = Convert.ToString(dr["RoleName"]) });
            //            }
            //        }
            //    }
            //    objRoleAccessMaster.lstRole = lstRole;
            //    List<Restaurant> lstRestaurant = new List<Restaurant>();
            //    if (ds != null && ds.Tables.Count > 3)
            //    {
            //        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[3].Rows)
            //            {
            //                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
            //            }
            //        }
            //    }
            //    objRoleAccessMaster.lstRestaurant = lstRestaurant;

            //}
            //catch (Exception ex)
            //{
            //    TempData["error"] = ex.Message;
            //}

            ////Utility.CommonEnums.ObjectToXML(Utility.CommonEnums.GetXMLFromObject(objRoleAccessMaster),)
            return View(objViewRoleAccessMaster);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoleAccess(ViewRoleAccessMaster objViewRoleAccessMaster, int? id)
        {
            
            //ViewBag.Title = "Add Role Access";
            ViewBag.Title = "Add Role Access";
            RoleAccessMasterDL objRoleAccessMaster = new RoleAccessMasterDL();
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objViewRoleAccessMaster.objRoleAccessMaster.CreatedBy = rs.UserID;
                    objViewRoleAccessMaster.objRoleAccessMaster.ModifiedBy = rs.UserID;
                    string XMLData = Utility.CommonEnums.GetXMLFromObject(objViewRoleAccessMaster);
                    objApiResponse = objRoleAccessMaster.AddUpdateRoleAccessMaster(XMLData);
                    if(objApiResponse != null && objApiResponse.StatusCode == 0)
                    {
                        TempData["NotifyMessage"] ="Role Access saved successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                        ModelState.Clear();
                        TempData.Keep();
                        return RedirectToAction("RoleAccess");
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
            }
            //RoleAccessMaster objRoleAccessMaster = new RoleAccessMaster();

            //if (ModelState.IsValid)
            //{
            //    string sss = "";
            //}
            //try
            //{
            //    //objRoleAccessModel.lstRoleAccess[0].CreatedBy = 1;
            //    //objRoleAccessModel.lstRoleAccess[0].CreatedDate = System.DateTime.Now;
            //    //objRoleAccessModel.lstRoleAccess[0].RestaurantID = 1;
            //    //objRoleAccessModel.lstRoleAccess[0].RolesID = 1;
            //    // objRoleAccessModel.AccessID = Convert.ToInt32(id);

            //    RoleAccessDL objRoleAccessDL = new RoleAccessDL();

            //    //ViewBag.Title = "Edit Role Access";
            //    //objApiResponse = objRoleAccessDL.UpdateRolesAccess(objRoleAccessModel.lstRoleAccess[0]);
            //    //if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
            //    //{
            //    //    TempData["success"] = "Congratulations! Role Access Updated Successfully";
            //    //    ModelState.Clear();
            //    //    return View(new RoleAccess());
            //    //    //return RedirectToAction("City");
            //    //}
            //    //else
            //    //{
            //    //    TempData["error"] = "Role Access already exists.";
            //    //}

            //    string XMLData = Utility.CommonEnums.GetXMLFromObject(objRoleAccessModel);
            //    objApiResponse = objRoleAccessDL.AddRolesAccess(XMLData);
            //    if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) == 1)
            //    {
            //        TempData["success"] = "Congratulations! Role Access Created Successfully";
            //        ModelState.Clear();

            //        // return View(new RoleAccess());
            //        //return RedirectToAction("City");
            //    }

            //    else if (objApiResponse.Message != "")
            //    {
            //        TempData["error"] = objApiResponse.Message;
            //    }
            //    else if (objApiResponse.Message != "")
            //    {
            //        TempData["error"] = "Role Access already exists.";
            //    }


            //    objApiResponse = objRoleAccessDL.GetRoleAccessById(Convert.ToInt32(id));
            //    DataSet ds = (DataSet)objApiResponse.Result;
            //    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            //    {


            //        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //        {
            //            DataTable dtRoleAccess = ds.Tables[0];
            //            RoleAccess objRoleAccess = new EntityLayer.RoleAccess();
            //            objRoleAccessMaster.lstRoleAccess = dtRoleAccess.AsEnumerable().Select(x => new RoleAccess
            //            {
            //                AccessID = x.Field<int>("AccessID"),
            //                RolesID = x.Field<int>("RolesID"),
            //                //Desc = x.Field<string>("[Desc]"),
            //                //RestaurantID = x.Field<int>("RestaurantID"),


            //            }).ToList();


            //        }
            //    }
            //    List<Access> lstAccess = new List<Access>();
            //    if (ds != null && ds.Tables.Count > 1)
            //    {
            //        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[1].Rows)
            //            {
            //                lstAccess.Add(new Access { AccessID = Convert.ToInt32(dr["AccessID"]), AccessName = Convert.ToString(dr["AccessName"]) });
            //            }
            //        }
            //    }

            //    objRoleAccessMaster.lstAccess = lstAccess;

            //    List<Role> lstRole = new List<Role>();
            //    if (ds != null && ds.Tables.Count > 2)
            //    {
            //        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[2].Rows)
            //            {
            //                lstRole.Add(new Role { RolesID = Convert.ToInt32(dr["RolesId"]), RoleName = Convert.ToString(dr["RoleName"]) });
            //            }
            //        }
            //    }
            //    objRoleAccessMaster.lstRole = lstRole;
            //    List<Restaurant> lstRestaurant = new List<Restaurant>();
            //    if (ds != null && ds.Tables.Count > 3)
            //    {
            //        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in ds.Tables[3].Rows)
            //            {
            //                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
            //            }
            //        }
            //    }
            //    objRoleAccessMaster.lstRestaurant = lstRestaurant;
             //return RedirectToAction("RoleAccess");
            //}
            //catch (Exception ex)
            //{
            //    TempData["error"] = ex.Message;
            //}
            //return View(objRoleAccessMaster);

            return View(objViewRoleAccessMaster);

        }

    }
}