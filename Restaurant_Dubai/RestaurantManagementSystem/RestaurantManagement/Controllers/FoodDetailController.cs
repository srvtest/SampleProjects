
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using EntityLayer;
using System.Data;
using DataLayer;
using System.Web;
using RestaurantManagement.Models;
using System.IO;

namespace RestaurantManagement.Controllers
{
    [AccessFilter]
    public class FoodDetailController : Controller
    {
        // GET: FoodDetail	 
        ApiResponse objApiResponse;
        public ActionResult Index(int id)
        {

            return View();
        }

       // http://localhost:3248/api/FoodDetail/GetFoodDetail?Restaurant=1
        public ActionResult FoodDetail()
        {
            try
            {
                RSession rsession = new RSession();
                rsession = (RSession)Session["RSession"];

                IEnumerable<FoodDetail> FoodDetaillist = null;
                DataTable dtFoodDetail = new DataTable();
                FoodDetailDL objFoodDetailDL = new FoodDetailDL();
                objApiResponse = objFoodDetailDL.GetFoodDetail(rsession.RestaurentId);
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    FoodDetaillist = ds.Tables[0].AsEnumerable().Select(x => new FoodDetail
                    {
                        FoodID = x.Field<int>("FoodID"),
                        Title = x.Field<string>("Title"),
                        //Description = x.Field<string>("Description"),
                        Price = x.Field<decimal>("Price"),
                        DiscountPrice = x.Field<decimal>("DiscountPrice"),
                        //FoodCategoryID = x.Field<int>("FoodCategoryID"),
                        Quantity = x.Field<int>("Quantity"),
                        FoodType = x.Field<string>("FoodType"),
                        //images = x.Field<string>("images"),
                        IsActive = x.Field<bool>("IsActive")
                        //SearchTag = x.Field<string>("SearchTag"),
                        //SpecialFoodID = x.Field<byte>("SpecialFoodID"),
                        //RestaurantID = x.Field<int>("RestaurantID")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(FoodDetaillist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult FoodDetail(int? id)
        {
            try
            {
                FoodDetailDL objFoodDetailDL = new FoodDetailDL();
                objApiResponse =objFoodDetailDL.DeleteFoodDetail(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Food Detail Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Error in food detail deleting";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("FoodDetail");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddFoodDetail(int? id)
        {
            ViewBag.Title = "Add FoodDetail";
            FoodDetail objFoodDetailModels = new EntityLayer.FoodDetail();
            try
            {
                RSession rsession = new RSession();
                rsession = (RSession)Session["RSession"];

                FoodDetailDL objFoodDetailDL = new FoodDetailDL();
                objApiResponse = objFoodDetailDL.GetFoodDetailById(Convert.ToInt32(id), rsession.RestaurentId);
                List<FoodCategory> lstFoodCategory = new List<FoodCategory>();
                List<SpecialFood> lstSpecialFood = new List<SpecialFood>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 1)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstFoodCategory.Add(new FoodCategory { FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]), CategoryTitle = Convert.ToString(dr["CategoryTitle"]) });
                            }
                        }
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objFoodDetailModels = ds.Tables[0].AsEnumerable().Select(x => new FoodDetail
                            {
                                FoodID = x.Field<int>("FoodID"),
                                Title = x.Field<string>("Title"),
                                Description = x.Field<string>("Description"),
                                Price = x.Field<decimal>("Price"),
                                DiscountPrice = x.Field<decimal>("DiscountPrice"),
                                FoodCategoryID = x.Field<int>("FoodCategoryID"),
                                Quantity = x.Field<int>("Quantity"),
                                FoodType = x.Field<string>("FoodType"),
                               // images = x.Field<string>("images"),
                                IsActive = x.Field<bool>("IsActive"),
                                SearchTag = x.Field<string>("SearchTag"),
                                //SpecialFoodID = x.Field<byte>("SpecialFoodID"),
                                RestaurantID = x.Field<int>("RestaurantID")
                            }).ToList().FirstOrDefault();
                        }
                        else
                        {
                            objFoodDetailModels.RestaurantID = rsession.RestaurentId;
                        }

                        ViewBag.UserFoodCategory = new SelectList(lstFoodCategory, "FoodCategoryID", "CategoryTitle");
                        //if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        //{
                        //    foreach (DataRow dr in ds.Tables[2].Rows)
                        //    {
                        //        lstSpecialFood.Add(new SpecialFood { SpecialFoodID = Convert.ToInt32(dr["SpecialFoodID"]), Name = Convert.ToString(dr["Name"]) });
                        //    }
                        //}
                        //ViewBag.UserSpecialFood = new SelectList(lstSpecialFood, "SpecialFoodID", "Name");
                        //if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        //{
                        //    foreach (DataRow dr in ds.Tables[3].Rows)
                        //    {
                        //        lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                        //    }
                        //}
                        //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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

            return View(objFoodDetailModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddFoodDetail(FoodDetail objFoodDetailModel, int? id, HttpPostedFileBase file)
        {
            ViewBag.Title = "Add FoodDetail";

            if (ModelState.IsValid)
            {
                try
                {
                    //objFoodDetailModel.FoodDetailID = 1;	 
                    
                    //Guid g;
                    //g = Guid.NewGuid();

                    //Upload Images
                    //if (file != null && file.ContentLength > 0)
                    //{
                    //    if (!Directory.Exists(HttpContext.Server.MapPath("~/Content/images/")))
                    //        Directory.CreateDirectory(HttpContext.Server.MapPath("~/Content/images/"));
                    //    if (System.IO.File.Exists(Server.MapPath("~/Content/images/") + objFoodDetailModel.images))
                    //    {
                    //        System.IO.File.Delete(Server.MapPath("~/Content/images/") + objFoodDetailModel.images);
                    //    }
                        
                    //    objFoodDetailModel.images = g.ToString() + "_" + file.FileName;
                    //}
                    FoodDetailDL objFoodDetailDL = new FoodDetailDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objFoodDetailModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        objFoodDetailModel.FoodID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit FoodDetail";
                        objFoodDetailModel.ModifiedBy = rs.UserID;

                        objApiResponse = objFoodDetailDL.UpdateFoodDetail(objFoodDetailModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            //if(file != null)
                            //    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/")+ g.ToString() + "_" + file.FileName);
                            TempData["NotifyMessage"] = "Congratulations! FoodDetail Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("FoodDetail");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Food title already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objFoodDetailModel.CreatedBy = rs.UserID;

                        objApiResponse = objFoodDetailDL.AddFoodDetail(objFoodDetailModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            //if (file != null)
                            //    file.SaveAs(HttpContext.Server.MapPath("~/Content/images/") + g.ToString() + "_" + file.FileName);
                            TempData["NotifyMessage"] = "Congratulations! FoodDetail Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("FoodDetail");

                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Food title already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objFoodDetailDL.GetFoodDetailById(Convert.ToInt32(id),rs.RestaurentId);
                    List<FoodCategory> lstFoodCategory = new List<FoodCategory>();
                    List<SpecialFood> lstSpecialFood = new List<SpecialFood>();
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
                                    lstFoodCategory.Add(new FoodCategory { FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]), CategoryTitle = Convert.ToString(dr["CategoryTitle"]) });
                                }
                            }
                            ViewBag.UserFoodCategory = new SelectList(lstFoodCategory, "FoodCategoryID", "CategoryTitle");
                            //if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in ds.Tables[2].Rows)
                            //    {
                            //        lstSpecialFood.Add(new SpecialFood { SpecialFoodID = Convert.ToInt32(dr["SpecialFoodID"]), Name = Convert.ToString(dr["Name"]) });
                            //    }
                            //}
                            //ViewBag.UserSpecialFood = new SelectList(lstSpecialFood, "SpecialFoodID", "Name");
                            //if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in ds.Tables[3].Rows)
                            //    {
                            //        lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            //    }
                            //}
                            //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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
                return View(objFoodDetailModel);
            }
            else
            {
                return View(objFoodDetailModel);
            }
        }
    }
}