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
    public class AccessController : Controller
    {
        // GET: Access
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Access()
        {

            try
            {
                IEnumerable<Access> Accesslist = GetAssessAllList();
                return View(Accesslist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Access(int? id)
        {
            try
            {
                AccessDL objAccessDL = new AccessDL();
                objAccessDL.DeleteAccess(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Access Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("access");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        public ActionResult AddAccess(int? id)
        {
            ViewBag.Title = "Add Access";
            Access objAccessModels = new EntityLayer.Access();
            SetAssessList();
            if (id != null)
            {
                ViewBag.Title = "Edit Access";
                try
                {
                    DataTable dtAccess = new DataTable();
                    AccessDL objAccessDL = new AccessDL();

                    

                    objApiResponse = objAccessDL.GetAccessById(Convert.ToInt32(id));
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        objAccessModels = ds.Tables[0].AsEnumerable().Select(x => new Access
                        {
                            AccessID = x.Field<int>("AccessID"),
                            AccessName = x.Field<string>("AccessName"),
                            AccessDesc = x.Field<string>("AccessDesc"),
                            BaseAccessID= x.Field<int>("BaseAccessID"),
                            PageURL= x.Field<string>("PageURL")
                        }).ToList().FirstOrDefault();
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
            }
            return View(objAccessModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccess(Access objAccessModel, int? id)
        {
            ViewBag.Title = "Add Access";
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    AccessDL objAccessDL = new AccessDL();
                    if (id != null)
                    {
                        objAccessModel.AccessID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit Access";
                        objAccessModel.ModifiedBy = rs.UserID;
                        objApiResponse = objAccessDL.UpdateAccess(objAccessModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Access Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("access");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Access ID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                            SetAssessList();
                        }
                    }
                    else
                    {
                        objAccessModel.CreatedBy = rs.UserID;
                        objApiResponse = objAccessDL.AddAccess(objAccessModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Access Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("access");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Access Name already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                            SetAssessList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objAccessModel);
            }
            else
            {
                return View(objAccessModel);
            }
        }

        public IEnumerable<Access> GetAssessAllList()
        {

            IEnumerable<Access> Accesslist = null;
            DataTable dtAccess = new DataTable();
            AccessDL objAccessDL = new AccessDL();

            objApiResponse = objAccessDL.GetAccess();
            if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            {
                DataSet ds = (DataSet)objApiResponse.Result;
                Accesslist = ds.Tables[0].AsEnumerable().Select(x => new Access
                {
                    AccessID = x.Field<int>("AccessID"),
                    AccessName = x.Field<string>("AccessName"),
                    AccessDesc = x.Field<string>("AccessDesc"),
                    BaseAccessID = x.Field<int>("BaseAccessID"),
                    PageURL= x.Field<string>("PageURL"),
                });
            }
            else
            {
                TempData["NotifyMessage"] = objApiResponse.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }

            return Accesslist;
        }

        private void SetAssessList() {
            IEnumerable<Access> Accesslist = GetAssessAllList().Where(x => x.BaseAccessID == 0);
            //List<Access> lstAccess = Accesslist.ToList();
            //lstAccess.Add(new Access() { AccessID = 0, AccessName = "Select Access" });
            //Accesslist = lstAccess.AsEnumerable<Access>();
            ViewBag.AccessList = new SelectList(Accesslist, "AccessID", "AccessName");
        }
    }
}