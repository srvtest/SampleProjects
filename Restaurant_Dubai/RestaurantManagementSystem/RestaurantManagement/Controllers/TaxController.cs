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
    public class TaxController : Controller
    {
        // GET: Tax
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            //if (Session["RSession"] != null)
            //{
            //    RSession rs = new RSession();
            //    rs = (RSession)Session["RSession"];
            //    if (!string.IsNullOrEmpty(Convert.ToString(rs.RestaurentId)))
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            Session["RSession"] = null;
            return View();
        }

        public ActionResult Tax()
        {
            try
            {
                IEnumerable<Tax> Taxlist = null;
                DataTable dtTax = new DataTable();
                TaxDL objTaxDL = new TaxDL();

                objApiResponse = objTaxDL.GetTax();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    Taxlist = ds.Tables[0].AsEnumerable().Select(x => new Tax
                    {
                        TaxID = x.Field<int>("TaxID"),
                        TaxName = x.Field<string>("TaxName"),
                        TaxInPercentage = x.Field<decimal>("TaxInPercentage"),
                        RestaurantName = x.Field<string>("Name"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Taxlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Tax(int? id)
        {
            try
            {
                TaxDL objTaxDL = new TaxDL();
                objApiResponse=objTaxDL.DeleteTax(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Tax Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Error in tax deleting";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("Tax");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        public ActionResult AddTax(int? id)
        {
            ViewBag.Title = "Add Tax";
            Tax objTaxModels = new EntityLayer.Tax();
            try
            {

                TaxDL objTaxDL = new TaxDL();
                objApiResponse = objTaxDL.GetTaxById(Convert.ToInt32(id));

                List<Restaurant> lstRestaurant = new List<Restaurant>();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {

                            objTaxModels = ds.Tables[0].AsEnumerable().Select(x => new Tax
                            {
                                TaxID = x.Field<int>("TaxID"),
                                TaxInPercentage = x.Field<decimal>("TaxInPercentage"),
                                TaxName = x.Field<string>("TaxName"),
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

            return View(objTaxModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddTax(Tax objTaxModel, int? id)
        {
            ViewBag.Title = "Add Tax";
            if (ModelState.IsValid)
            {
                try
                {
                    
                    TaxDL objTaxDL = new TaxDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objTaxModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        objTaxModel.TaxID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit Access";
                        objTaxModel.ModifiedBy = rs.UserID;
                      
                        objApiResponse = objTaxDL.UpdateTax(objTaxModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Tax Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Tax");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Tax already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                         objTaxModel.CreatedBy = rs.UserID;
                       
                        objApiResponse = objTaxDL.AddTax(objTaxModel);

                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Tax Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Tax");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Tax already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }

                    //objApiResponse = objTaxDL.GetTaxById(Convert.ToInt32(id));
                    //List<Restaurant> lstRestaurant = new List<Restaurant>();
                    //if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    //{
                    //    DataSet ds = (DataSet)objApiResponse.Result;
                    //    if (ds != null && ds.Tables.Count > 0)
                    //    {
                    //        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    //        {
                    //            foreach (DataRow dr in ds.Tables[1].Rows)
                    //            {
                    //                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                    //            }
                    //        }
                    //    }
                    //    ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                    //}
                    //else
                    //{
                    //    TempData["NotifyMessage"] = objApiResponse.Message;
                    //    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                    //}


                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objTaxModel);
            }
            else
            {
                return View(objTaxModel);
            }
        }
    }
}