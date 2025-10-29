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
    public class CityController : Controller
    {
        ApiResponse objApiResponse;
        // GET: City
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult City()
        {
            try
            {
                IEnumerable<City> Citylist = null;
                DataTable dtCity = new DataTable();
                CityDL objRestaurantUserDL = new CityDL();

                objApiResponse = objRestaurantUserDL.GetCity();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
                    {
                        CityID = x.Field<int>("CityID"),
                        CityName = x.Field<string>("CityName"),
                        CountryName = x.Field<string>("CountryName"),
                        StateName = x.Field<string>("StateName"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Citylist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult City(int? id)
        {
            try
            {
                CityDL objCityDL = new CityDL();
                objApiResponse=objCityDL.DeleteCity(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "City Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "City can't delete before its associate restaurant delete.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("City");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddCity(int? id)
        {
            ViewBag.Title = "Add City";
            City objCityModels = new EntityLayer.City();
            try
            {
                DataTable dtCity = new DataTable();
                CityDL objCityDL = new CityDL();
                objApiResponse = objCityDL.GetCityById(Convert.ToInt32(id));
                List<State> lstState = new List<State>();
                List<Country> lstCountry = new List<Country>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objCityModels = ds.Tables[0].AsEnumerable().Select(x => new City
                            {
                                CityID = x.Field<int>("CityID"),
                                CityName = x.Field<string>("CityName"),
                                CountryID = x.Field<int>("CountryID"),
                                StateID = x.Field<int>("StateID"),
                                IsActive = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCountry.Add(new Country { CountryID = Convert.ToInt32(dr["CountryID"]), CountryName = Convert.ToString(dr["CountryName"]) });
                            }
                        }
                        ViewBag.UserCountry = new SelectList(lstCountry, "CountryID", "CountryName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstState.Add(new State { StateID = Convert.ToInt32(dr["StateID"]), StateName = Convert.ToString(dr["StateName"]) });
                            }
                        }
                        ViewBag.UserState = new SelectList(lstState, "StateID", "StateName");
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
            return View(objCityModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCity(City objCityModel, int? id)
        {
            ViewBag.Title = "Add City";

            if (ModelState.IsValid)
            {
                try
                {
                    //objCityModel.CityID = 1;
                    objCityModel.CityID = Convert.ToInt32(id);
                    CityDL objCityDL = new CityDL();
                    if (id != null)
                    {
                        ViewBag.Title = "Edit City";
                        objApiResponse = objCityDL.UpdateCity(objCityModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! City Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("City");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "City ID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objApiResponse = objCityDL.AddCity(objCityModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! City Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("City");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "City already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning; 
                        }
                    }

                    objApiResponse = objCityDL.GetCityById(Convert.ToInt32(id));
                    List<State> lstState = new List<State>();
                    List<Country> lstCountry = new List<Country>();
                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCountry.Add(new Country { CountryID = Convert.ToInt32(dr["CountryID"]), CountryName = Convert.ToString(dr["CountryName"]) });
                            }
                        }
                        ViewBag.UserCountry = new SelectList(lstCountry, "CountryID", "CountryName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstState.Add(new State { StateID = Convert.ToInt32(dr["StateID"]), StateName = Convert.ToString(dr["StateName"]) });
                            }
                        }
                        ViewBag.UserState = new SelectList(lstState, "StateID", "StateName");
                    }
                    else
                    {
                        TempData["NotifyMessage"] = objApiResponse.Message;
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                    }

                    return View(objCityModel);
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objCityModel);
            }
            else
            {
                return View(objCityModel);
            }
        }

        public ActionResult GetStateByCountryID(int CountryID)
        {
            IEnumerable<State> Statelist = null;
            CityDL objCityDL = new CityDL();
            objApiResponse = objCityDL.GetStateByCountryID(CountryID);
            if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            {
                DataSet ds = (DataSet)objApiResponse.Result;
                Statelist = ds.Tables[0].AsEnumerable().Select(x => new State
                {
                    StateID = x.Field<int>("StateID"),
                    StateName = x.Field<string>("StateName")
                });
            }
            else
            {
                TempData["NotifyMessage"] = objApiResponse.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return Json(Statelist,JsonRequestBehavior.AllowGet);
        }
    }
}