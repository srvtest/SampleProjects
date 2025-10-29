
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using System.Net;
//using System.Net.Http;
//using EntityLayer;
//using System.Data;
//using DataLayer;

//namespace RestaurantManagement.Controllers
//{
//    public class SpecialFoodController : Controller
//    {
//        // GET: SpecialFood	 
//        public ActionResult Index()
//        {
//            return View();
//        }


//        public ActionResult SpecialFood()
//        {
//            try
//            {
//            //    IEnumerable<SpecialFood> SpecialFoodlist = null;
//            //    DataTable dtSpecialFood = new DataTable();
//            //    SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//            //    DataSet ds = objSpecialFoodDL.GetSpecialFood();


//            //    SpecialFoodlist = ds.Tables[0].AsEnumerable().Select(x => new SpecialFood
//            //    {
//            //        SpecialFoodID = x.Field<Int32>("SpecialFoodID"),
//            //        Name = x.Field<String>("Name"),
//            //        Desc = x.Field<String>("Desc"),
//            //        RestaurantID = x.Field<Int32>("RestaurantID"),
//            //        CreatedBy = x.Field<Int32>("CreatedBy"),
//            //        CreatedDate = x.Field<DateTime>("CreatedDate"),
//            //        ModifiedBy = x.Field<Int32>("ModifiedBy"),
//            //        ModifiedDate = x.Field<DateTime>("ModifiedDate")
//            //    });

//            //    return View(SpecialFoodlist);
//            //}
//            //catch (Exception ex)
//            //{
//            //    TempData["error"] = ex.Message;
//            //}
//            return View();
//        }

//        [HttpDelete]
//        public ActionResult SpecialFood(int? id)
//        {
//            try
//            {
//                SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//                objSpecialFoodDL.DeleteSpecialFood(Convert.ToInt32(id));
//                return RedirectToAction("SpecialFood");
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//            }
//            return View();
//        }


//        public ActionResult AddSpecialFood(int? id)
//        {
//            ViewBag.Title = "Add SpecialFood";
//            SpecialFood objSpecialFoodModels = new SpecialFood();
//            if (id != null)
//            {
//                ViewBag.Title = "Edit SpecialFood";
//                try
//                {
//                    DataTable dtSpecialFood = new DataTable();
//                    SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//                    //DataSet ds = objSpecialFoodDL.GetSpecialFoodById(Convert.ToInt32(id));
//                    //dtSpecialFood = ds.Tables[0];

//                    //if (dtSpecialFood.Rows.Count > 0)
//                    //{
//                    //    // SpecialFood objSpecialFoodModels = new SpecialFood();
//                    //    objSpecialFoodModels.SpecialFoodID = Convert.Int32(dtSpecialFood.Rows[0]["SpecialFoodID"]);
//                    //    objSpecialFoodModels.Name = Convert.String(dtSpecialFood.Rows[0]["Name"]);
//                    //    objSpecialFoodModels.Desc = Convert.String(dtSpecialFood.Rows[0]["Desc"]);
//                    //    objSpecialFoodModels.RestaurantID = Convert.Int32(dtSpecialFood.Rows[0]["RestaurantID"]);
//                    //    objSpecialFoodModels.CreatedBy = Convert.Int32(dtSpecialFood.Rows[0]["CreatedBy"]);
//                    //    objSpecialFoodModels.CreatedDate = Convert.DateTime(dtSpecialFood.Rows[0]["CreatedDate"]);
//                    //    objSpecialFoodModels.ModifiedBy = Convert.Int32(dtSpecialFood.Rows[0]["ModifiedBy"]);
//                    //    objSpecialFoodModels.ModifiedDate = Convert.DateTime(dtSpecialFood.Rows[0]["ModifiedDate"]);
//                    //    return View(objSpecialFoodModels);
//                    //}
//                }
//                catch (Exception ex)
//                {
//                    TempData["error"] = ex.Message;
//                }
//            }
//            return View(objSpecialFoodModels);
//        }

//        [HttpPost]
//        [ValidateInput(true)]
//        [ValidateAntiForgeryToken]
//        public ActionResult AddSpecialFood(SpecialFood objSpecialFoodModel, int? id)
//        {
//            ViewBag.Title = "Add SpecialFood";

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    //objSpecialFoodModel.SpecialFoodID = 1;	 
//                    //objSpecialFoodModel.CityID = Convert.ToInt32(id);
//                    SpecialFoodDL objSpecialFoodDL = new SpecialFoodDL();
//                    if (id != null)
//                    {
//                        ViewBag.Title = "Edit SpecialFood";
//                        objSpecialFoodDL.UpdateSpecialFood(objSpecialFoodModel);
//                        TempData["success"] = "Congratulations! SpecialFood Updated Successfully";
//                    }
//                    else
//                    {
//                        objSpecialFoodDL.AddSpecialFood(objSpecialFoodModel);
//                        TempData["success"] = "Congratulations! SpecialFood Created Successfully";
//                        ModelState.Clear();
//                        return View(new SpecialFood());
//                    }
//                }
//                catch (Exception ex)
//                {
//                    TempData["error"] = ex.Message;
//                }
//                return View(objSpecialFoodModel);
//            }
//            else
//            {
//                return View(objSpecialFoodModel);
//            }
//        }
//    }
//}