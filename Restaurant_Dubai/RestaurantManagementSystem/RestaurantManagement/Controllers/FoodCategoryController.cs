
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
using System.Web;
using System.Configuration;
using System.IO;

namespace RestaurantManagement.Controllers
{
    [AccessFilter]
    public class FoodCategoryController : Controller
    {
        // GET: FoodCategory	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FoodCategory()
        {
            try
            {
                RSession rsession = new RSession();
                rsession = (RSession)Session["RSession"];

                IEnumerable<FoodCategory> FoodCategorylist = null;
                DataTable dtFoodCategory = new DataTable();
                FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                objApiResponse = objFoodCategoryDL.GetFoodCategoryByRestaurantID(rsession.RestaurentId);
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    FoodCategorylist = ds.Tables[0].AsEnumerable().Select(x => new FoodCategory
                    {
                        FoodCategoryID = x.Field<int>("FoodCategoryID"),
                        CategoryTitle = x.Field<string>("CategoryTitle"),
                        Description = x.Field<string>("Description"),
                        Images = x.Field<string>("Images"),
                        // RestaurantName = x.Field<string>("Name"),
                        CuisineType = x.Field<string>("CuisineType"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(FoodCategorylist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult FoodCategory(int? id)
        {
            try
            {
                FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                objApiResponse = objFoodCategoryDL.DeleteFoodCategory(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Food Category Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Food Category can't delete because foreign key relationship";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("FoodCategory");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddFoodCategory(int? id)
        {
            ViewBag.Title = "Add FoodCategory";
            FoodCategory objFoodCategoryModels = new EntityLayer.FoodCategory();
            try
            {
                RSession rsession = new RSession();
                rsession = (RSession)Session["RSession"];

                FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                objApiResponse = objFoodCategoryDL.GetFoodCategoryById(Convert.ToInt32(id));

               // List<Restaurant> lstRestaurant = new List<Restaurant>();
                List<Cuisine> lstCuisine = new List<Cuisine>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objFoodCategoryModels = ds.Tables[0].AsEnumerable().Select(x => new FoodCategory
                            {
                                FoodCategoryID = x.Field<int>("FoodCategoryID"),
                                CategoryTitle = x.Field<string>("CategoryTitle"),
                                Description = x.Field<string>("Description"),
                                CuisineID = x.Field<int>("CuisineId"),
                                Images = x.Field<string>("Images"),
                                //RestaurantID = x.Field<int>("RestaurantID"),
                                CuisineType = x.Field<string>("CuisineType"),
                                IsActive = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                        //if (ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        //{
                        //    foreach (DataRow dr in ds.Tables[1].Rows)
                        //    {
                        //        lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                        //    }
                        //}
                        //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        if (ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCuisine.Add(new Cuisine { CuisineId = Convert.ToInt32(dr["CuisineId"]), CuisineType = Convert.ToString(dr["CuisineType"]) });
                            }
                        }
                        ViewBag.Cuisines = new SelectList(lstCuisine, "CuisineId", "CuisineType");
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

            return View(objFoodCategoryModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddFoodCategory(FoodCategory objFoodCategoryModel, int? id, HttpPostedFileBase ImagesFile = null)
        {
            string ImagesPath = ConfigurationManager.AppSettings["FoodImageFolder"].ToString();
            ViewBag.Title = "Add FoodCategory";
            if (ModelState.IsValid)
            {
                try
                {
                    FoodCategoryDL objFoodCategoryDL = new FoodCategoryDL();
                    string guid = Guid.NewGuid().ToString();
                    if (ImagesFile != null && ImagesFile.ContentLength > 0)
                    {
                        if (!Directory.Exists(ImagesPath))
                            Directory.CreateDirectory(Server.MapPath(ImagesPath));
                        if (System.IO.File.Exists(Server.MapPath(ImagesPath + objFoodCategoryModel.Images)))
                        {
                            System.IO.File.Delete(Server.MapPath(ImagesPath + objFoodCategoryModel.Images));
                        }

                        objFoodCategoryModel.Images = guid + "_" + ImagesFile.FileName;

                    }
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objFoodCategoryModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        objFoodCategoryModel.FoodCategoryID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit FoodCategory";
                        objFoodCategoryModel.ModifiedBy = rs.UserID;

                        objApiResponse = objFoodCategoryDL.UpdateFoodCategory(objFoodCategoryModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            if (ImagesFile != null)
                                ImagesFile.SaveAs(Path.Combine(Server.MapPath(ImagesPath), guid + "_" + ImagesFile.FileName));
                            TempData["NotifyMessage"] = "Congratulations! FoodCategory Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("FoodCategory");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "FoodCategory already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objFoodCategoryModel.CreatedBy = rs.UserID;

                        objApiResponse = objFoodCategoryDL.AddFoodCategory(objFoodCategoryModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            if (ImagesFile != null)
                                ImagesFile.SaveAs(Path.Combine(Server.MapPath(ImagesPath), guid + "_" + ImagesFile.FileName));
                            TempData["NotifyMessage"] = "Congratulations! FoodCategory Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("FoodCategory");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "FoodCategory already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objFoodCategoryDL.GetFoodCategoryById(Convert.ToInt32(id));
                    //List<Restaurant> lstRestaurant = new List<Restaurant>();
                    List<Cuisine> lstCuisine = new List<Cuisine>();
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        //if (ds != null && ds.Tables.Count > 0)
                        //{
                        //    if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        //    {
                        //        foreach (DataRow dr in ds.Tables[1].Rows)
                        //        {
                        //            lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                        //        }
                        //    }
                        //}
                        //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        if (ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCuisine.Add(new Cuisine { CuisineId = Convert.ToInt32(dr["CuisineId"]), CuisineType = Convert.ToString(dr["CuisineType"]) });
                            }
                        }
                        ViewBag.Cuisines = new SelectList(lstCuisine, "CuisineId", "CuisineType");
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
            return View(objFoodCategoryModel);
        }
    }
}