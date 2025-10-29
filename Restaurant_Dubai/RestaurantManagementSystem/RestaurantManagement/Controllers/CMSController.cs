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
    public class CMSController : Controller
    {
        // GET: CMS
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }
        // Get show Database Field in Gridview
        public ActionResult CMS()
        {
            try
            {
                IEnumerable<CMS> CMSlist = null;
                DataTable dtCMS = new DataTable();
                CMSDL objCMSDL = new CMSDL();
                objApiResponse = objCMSDL.GetCMS();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    CMSlist = ds.Tables[0].AsEnumerable().Select(x => new CMS
                    {
                        CMSID = x.Field<int>("CMSID"),
                        RestaurantID = x.Field<int>("RestaurantID"),
                        RestaurantName = x.Field<string>("Name"),
                        CMSTypeID = x.Field<int>("CMSTypeID"),
                        CMSTypeName = x.Field<string>("CMSTypeName"),
                        Title = x.Field<string>("Title"),
                        PageDesc = x.Field<string>("PageDesc"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(CMSlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult CMS(int? id)
        {
            try
            {
                CMSDL objCMSDL = new CMSDL();
                objApiResponse=objCMSDL.DeleteCMS(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "CMS Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "CMS can't delete because foreign key relationship";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("CMS");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        // Get Show Database Field to Toolbox
        public ActionResult AddCMS(int? id)
        {
            ViewBag.Title = "Add CMS";
            CMS objCMSModels = new EntityLayer.CMS();
            try
            {
                RSession rs = new RSession();
                rs = (RSession)Session["RSession"];
                if (rs != null)
                {
                    ViewBag.RoleId = Convert.ToInt32(rs.RoleId);
                    if(rs.RoleId != 1)
                        ViewBag.RestaurantID = Convert.ToInt32(rs.RestaurentId);
                }
                DataTable dtCMS = new DataTable();
                CMSDL objCMSDL = new CMSDL();
                objApiResponse = objCMSDL.GetCMSById(id);
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                List<CMSType> lstCMSType = new List<CMSType>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objCMSModels = ds.Tables[0].AsEnumerable().Select(x => new CMS
                            {
                                CMSID = x.Field<int>("CMSID"),
                                RestaurantID = x.Field<int>("RestaurantID"),
                                CMSTypeID = x.Field<int>("CMSTypeID"),
                                Title = x.Field<string>("Title"),
                                PageDesc = x.Field<string>("PageDesc"),
                                IsActive = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        if (ds.Tables.Count > 2 &&  ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstCMSType.Add(new CMSType { CMSTypeID = Convert.ToInt32(dr["CMSTypeID"]), CMSTypeName = Convert.ToString(dr["CMSTypeName"]) });
                            }
                        }
                        ViewBag.CMSType = new SelectList(lstCMSType, "CMSTypeID", "CMSTypeName");
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
            return View(objCMSModels);
        }

        // Add or Update Method

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCMS(CMS objCMSModel, int? id)
        {
            ViewBag.Title = "Add CMS";
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    if (rs != null)
                    {
                        ViewBag.RoleId = Convert.ToInt32(rs.RoleId);
                        if (rs.RoleId != 1)
                            ViewBag.RestaurantID = Convert.ToInt32(rs.RestaurentId);
                    }
                    CMSDL objCMSDL = new CMSDL();
                    if (id != null)
                    {
                        objCMSModel.CMSID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit CMS";
                        objCMSModel.ModifiedBy = rs.UserID;
                        objApiResponse = objCMSDL.UpdateCMS(objCMSModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! CMS Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("CMS");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "CMS already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objCMSModel.CreatedBy = rs.UserID;
                        objApiResponse = objCMSDL.AddCMS(objCMSModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! CMS Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("CMS");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Title and Restaurant already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objCMSDL.GetCMSById(Convert.ToInt32(id));
                    List<Restaurant> lstRestaurant = new List<Restaurant>();
                    List<CMSType> lstCMSType = new List<EntityLayer.CMSType>();
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
                        if (ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstCMSType.Add(new CMSType { CMSTypeID = Convert.ToInt32(dr["CMSTypeID"]), CMSTypeName = Convert.ToString(dr["CMSTypeName"]) });
                            }
                        }
                        ViewBag.CMSType = new SelectList(lstCMSType, "CMSTypeID", "CMSTypeName");
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
                return View(objCMSModel);
            }
            else
            {
                return View(objCMSModel);
            }
        }
    }
}