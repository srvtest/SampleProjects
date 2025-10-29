
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
    public class ReviewRatingController : Controller
    {
        // GET: ReviewRating	
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ReviewRating()
        {
            try
            {
                RSession rs = new RSession();
                rs = (RSession)Session["RSession"];
                IEnumerable<ReviewRating> ReviewRatinglist = null;
                DataTable dtReviewRating = new DataTable();
                ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
                objApiResponse = objReviewRatingDL.GetReviewRating(rs.RestaurentId);
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    ReviewRatinglist = ds.Tables[0].AsEnumerable().Select(x => new ReviewRating
                    {
                        ReviewRatingID = x.Field<int>("ReviewRatingID"),
                        Rating = x.Field<int>("Rating"),
                        Review = x.Field<string>("Review"),
                        CustomerName = x.Field<string>("CustomerName"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(ReviewRatinglist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult ReviewRating(int? id)
        {
            try
            {
                ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
                objApiResponse = objReviewRatingDL.DeleteReviewRating(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Review Rating Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Review Rating did not delete";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("ReviewRating");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddReviewRating(int? id)
        {
            ViewBag.Title = "Add ReviewRating";
            ReviewRating objReviewRatingModels = new EntityLayer.ReviewRating();
            try
            {
                //DataTable dtReviewRating = new DataTable();
                ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
                objApiResponse = objReviewRatingDL.GetReviewRatingById(Convert.ToInt32(id));

                List<Restaurant> lstRestaurant = new List<Restaurant>();
                List<Customer> lstCustomer = new List<Customer>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {

                            objReviewRatingModels = ds.Tables[0].AsEnumerable().Select(x => new ReviewRating
                            {
                                ReviewRatingID = x.Field<int>("ReviewRatingID"),
                                Rating = x.Field<int>("Rating"),
                                Review = x.Field<string>("Review"),
                                RestaurantID = x.Field<int>("RestaurantID"),
                                CustomerID = x.Field<int>("CustomerID"),
                                IsActive = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                        //if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        //{
                        //    foreach (DataRow dr in ds.Tables[1].Rows)
                        //    {
                        //        lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                        //    }
                        //}
                        //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["CustomerName"]) });
                            }
                        }
                        ViewBag.UserCustomer = new SelectList(lstCustomer, "CustomerID", "Firstname");
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

            return View(objReviewRatingModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddReviewRating(ReviewRating objReviewRatingModel, int? id)
        {
            ViewBag.Title = "Add ReviewRating";
            if (ModelState.IsValid)
            {
                try
                {
                    ReviewRatingDL objReviewRatingDL = new ReviewRatingDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objReviewRatingModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        objReviewRatingModel.ReviewRatingID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit ReviewRating";
                        objReviewRatingModel.ModifiedBy = rs.UserID;

                        objApiResponse = objReviewRatingDL.UpdateReviewRating(objReviewRatingModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! ReviewRating Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("ReviewRating");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "ReviewRating already exists for this customer";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objReviewRatingModel.CreatedBy = rs.UserID;

                        objApiResponse = objReviewRatingDL.AddReviewRating(objReviewRatingModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! ReviewRating Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("ReviewRating");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "ReviewRating already exists for this customer";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objReviewRatingDL.GetReviewRatingById(Convert.ToInt32(id));
                    List<Restaurant> lstRestaurant = new List<Restaurant>();
                    List<Customer> lstCustomer = new List<Customer>();
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            //if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in ds.Tables[1].Rows)
                            //    {
                            //        lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            //    }
                            //}
                            //ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["CustomerName"]) });
                                }
                            }
                            ViewBag.UserCustomer = new SelectList(lstCustomer, "CustomerID", "Firstname");
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
                return View(new ReviewRating());
            }
            return View(objReviewRatingModel);
        }
    }
}