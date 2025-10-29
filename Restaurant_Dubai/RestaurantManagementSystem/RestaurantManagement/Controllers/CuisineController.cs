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
    public class CuisineController : Controller
    {
        ApiResponse objApiResponse;
        // GET: Cuisine
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cuisine()
        {
            try
            {
                IEnumerable<Cuisine> Cuisinelist = null;
                DataTable dtCuisine = new DataTable();
                CuisineDL objCuisineDL = new CuisineDL();
                objApiResponse = objCuisineDL.GetCuisine();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Cuisinelist = ds.Tables[0].AsEnumerable().Select(x => new Cuisine
                    {
                        CuisineId = x.Field<Int32>("CuisineId"),
                        CuisineType = x.Field<String>("CuisineType"),
                        IsActive = x.Field<Boolean>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Cuisinelist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Cuisine(int? id)
        {
            try
            {
                CuisineDL objCuisineDL = new CuisineDL();
                objApiResponse=objCuisineDL.DeleteCuisine(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Cuisine Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Error in cuisine deleting";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("Cuisine");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddCuisine(int? id)
        {
            ViewBag.Title = "Add State";
            Cuisine objCuisineModels = new EntityLayer.Cuisine();
            try
            {
                DataTable dtCuisine = new DataTable();
                CuisineDL objCuisineDL = new CuisineDL();
                objApiResponse = objCuisineDL.GetCuisineById(Convert.ToInt32(id));
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objCuisineModels = ds.Tables[0].AsEnumerable().Select(x => new Cuisine
                            {
                                CuisineId = x.Field<Int32>("CuisineId"),
                                CuisineType = x.Field<String>("CuisineType"),
                                IsActive = x.Field<Boolean>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
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
            return View(objCuisineModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCuisine(Cuisine objCuisineModel, int? id)
        {
            ViewBag.Title = "Add Cuisine";
            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = (RSession)Session["RSession"];
                    CuisineDL objCuisineDL = new CuisineDL();
                    if (id != null)
                    {
                        objCuisineModel.CuisineId = Convert.ToInt32(id);
                        ViewBag.Title = "Edit Cuisine";
                        //objCuisineModel.RestaurantId = rs.RestaurentId;
                        objApiResponse = objCuisineDL.UpdateCuisine(objCuisineModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Cuisine Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Cuisine");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Cuisine Type already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objApiResponse = objCuisineDL.AddCuisine(objCuisineModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Cuisine Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Cuisine");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Cuisine Type already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objCuisineModel);
            }
            else
            {
                return View(objCuisineModel);
            }
        }
    }
}