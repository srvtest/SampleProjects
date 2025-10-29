using DataLayer;
using EntityLayer;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Controllers
{
    [AccessFilter]
    public class CMSTypeController : Controller
    {
        // GET: CMSType
        ApiResponse objApiResponse;
        public ActionResult CMSType()
        {
            IEnumerable<CMSType> CMSTypelist = new List<CMSType>();
            try
            {
                DataTable dtCMS = new DataTable();
                CMSTypeDL objCMSDL = new CMSTypeDL();
                objApiResponse = objCMSDL.GetCMSType();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    CMSTypelist = ds.Tables[0].AsEnumerable().Select(x => new CMSType
                    {
                        CMSTypeID = x.Field<int>("CMSTypeID"),
                        CMSTypeName = x.Field<string>("CMSTypeName"),
                        IsActive = x.Field<bool>("IsActive")
                    });
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
            return View(CMSTypelist);
        }
        [HttpGet]
        public ActionResult AddCMSType(int? id)
        {
            ViewBag.Title = "Add CMS Type";
            CMSType objCMSTypeModels = new CMSType();
            try
            {
                DataTable dtCMSType = new DataTable();
                CMSTypeDL objCMSTypeDL = new CMSTypeDL();
                objApiResponse = objCMSTypeDL.GetCMSTypeById(Convert.ToInt32(id));

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objCMSTypeModels = ds.Tables[0].AsEnumerable().Select(x => new CMSType
                            {
                                CMSTypeID = x.Field<int>("CMSTypeID"),
                                CMSTypeName = x.Field<string>("CMSTypeName"),
                                IsActive = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                    }
                }
                else
                {
                    TempData["error"] = objApiResponse.Message;
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View(objCMSTypeModels);
        }
        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCMSType(CMSType objCMSType,int? id)
        {
            ViewBag.Title = "Add CMS Type";
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];

                    CMSTypeDL objCMSTypeDL = new CMSTypeDL();
                    if (id != null)
                    {
                        objCMSType.CMSTypeID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit CMS Type";
                        objCMSType.ModifiedBy = rs.UserID;
                        objApiResponse = objCMSTypeDL.UpdateCMSType(objCMSType);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! CMS Type Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("CMSType");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "CMS Type already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objCMSType.CreatedBy = rs.UserID;
                        objApiResponse = objCMSTypeDL.AddCMSType(objCMSType);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! CMS Type Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("CMSType");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "CMS Type already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objCMSType);
            }
            else
            {
                return View(objCMSType);
            }
        }

        [HttpDelete]
        public ActionResult CMSType(int? id)
        {
            try
            {
                CMSTypeDL objCMSTypeDL = new CMSTypeDL();
                objCMSTypeDL.DeleteCMSType(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "CMS Type Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("CMSType");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }
    }
}