
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
    public class CountryController : Controller
    {
        ApiResponse objApiResponse;
        // GET: Country	 
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Country()
        {
            try
            {
                IEnumerable<Country> Countrylist = null;
                DataTable dtCountry = new DataTable();
                CountryDL objCountryDL = new CountryDL();
                objApiResponse = objCountryDL.GetCountry();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Countrylist = ds.Tables[0].AsEnumerable().Select(x => new Country
                    {
                        CountryID = x.Field<Int32>("CountryID"),
                        CountryName = x.Field<String>("CountryName"),
                        IsActive = x.Field<Boolean>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Countrylist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Country(int? id)
        {
            try
            {
                CountryDL objCountryDL = new CountryDL();
                objApiResponse = objCountryDL.DeleteCountry(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Country Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Country can't delete before its associate state delete.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("Country");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddCountry(int? id)
        {
            ViewBag.Title = "Add Country";
            Country objCountryModels = new Country();
            try
            {
                DataTable dtCountry = new DataTable();
                CountryDL objCountryDL = new CountryDL();
                objApiResponse = objCountryDL.GetCountryById(Convert.ToInt32(id));

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objCountryModels = ds.Tables[0].AsEnumerable().Select(x => new Country
                        {
                            CountryID = x.Field<Int32>("CountryID"),
                            CountryName = x.Field<String>("CountryName"),
                            IsActive = x.Field<Boolean>("IsActive")
                        }).ToList().FirstOrDefault();
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
            return View(objCountryModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCountry(Country objCountryModel, int? id)
        {
            ViewBag.Title = "Add Country";
            if (ModelState.IsValid)
            {
                try
                {
                    CountryDL objCountryDL = new CountryDL();
                    if (id != null)
                    {
                        objCountryModel.CountryID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit Country";
                        objApiResponse = objCountryDL.UpdateCountry(objCountryModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Country Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Country");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Country already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objApiResponse = objCountryDL.AddCountry(objCountryModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Country Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Country");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Country already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objCountryModel);
            }
            else
            {
                return View(objCountryModel);
            }
        }
    }
}