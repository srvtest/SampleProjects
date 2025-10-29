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
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace RestaurantManagement.Controllers
{
    //[AccessFilter]
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Restaurant()
        {
            try
            {
                IEnumerable<Restaurant> Restaurantlist = null;
                DataTable dtRestaurant = new DataTable();
                RestaurantDL objRestaurantDL = new RestaurantDL();

                objApiResponse = objRestaurantDL.GetRestaurant();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    // dtRestaurant = ds.Tables[0];

                    Restaurantlist = ds.Tables[0].AsEnumerable().Select(x => new Restaurant
                    {
                        RestaurantID = x.Field<int>("RestaurantID"),
                        Name = x.Field<string>("Name"),
                        Logo = x.Field<string>("Logo"),
                        Address = x.Field<string>("Address"),
                        Contact = x.Field<string>("Contact"),
                        Email = x.Field<string>("Email"),
                        CountryName = x.Field<string>("CountryName"),
                        StateName = x.Field<string>("StateName"),
                        CityName = x.Field<string>("CityName"),
                        TimeFrom = x.Field<string>("TimeFrom"),
                        TimeTo = x.Field<string>("TimeTo"),
                        Status = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Restaurantlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Restaurant(int? id)
        {
            try
            {
                RestaurantDL objRestaurantDL = new RestaurantDL();
                objApiResponse =objRestaurantDL.DeleteRestaurant(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Restaurant Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Restaurant can't delete because foreign key relationship";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("Restaurant", "Restaurant");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddRestaurant(int? id)
        {
            ViewBag.Title = "Add Restaurant";
            Restaurant objRestaurant = new EntityLayer.Restaurant();
            try
            {
                RestaurantDL objRestaurantDL = new RestaurantDL();
                objApiResponse = objRestaurantDL.GetRestaurantById(Convert.ToInt32(id));
                List<Country> lstCountry = new List<Country>();
                List<State> lstState = new List<State>();
                List<City> lstCity = new List<City>();
                List<ListItem> lstParentRestaurant = new List<ListItem>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objRestaurant = ds.Tables[0].AsEnumerable().Select(x => new Restaurant
                            {
                                RestaurantID = x.Field<int>("RestaurantID"),
                                Name = x.Field<string>("Name"),
                                Logo = x.Field<string>("Logo"),
                                MAP = x.Field<string>("MAP"),
                                Address = x.Field<string>("Address"),
                                Contact = x.Field<string>("Contact"),
                                ParentBranchID = x.Field<int>("ParentBranchID"),
                                Email = x.Field<string>("Email"),
                                CountryID = x.Field<int>("CountryID"),
                                StateID = x.Field<int>("StateID"),
                                CityID = x.Field<int>("CityID"),
                                TimeFrom = x.Field<string>("TimeFrom"),
                                TimeTo = x.Field<string>("TimeTo"),
                                Status = x.Field<bool>("IsActive")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCountry.Add(new Country { CountryID = Convert.ToInt32(dr["CountryID"]), CountryName = Convert.ToString(dr["CountryName"]) });
                            }
                        }
                        ViewBag.Country = new SelectList(lstCountry, "CountryId", "CountryName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstState.Add(new State { StateID = Convert.ToInt32(dr["StateID"]), StateName = Convert.ToString(dr["StateName"]) });
                            }
                        }
                        ViewBag.State = new SelectList(lstState, "StateId", "StateName");
                        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[3].Rows)
                            {
                                lstCity.Add(new City { CityID = Convert.ToInt32(dr["CityID"]), CityName = Convert.ToString(dr["CityName"]) });
                            }
                        }
                        ViewBag.City = new SelectList(lstCity, "CityId", "CityName");
                        if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[4].Rows)
                            {
                                lstParentRestaurant.Add(new ListItem { ID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.ParentRestaurant = new SelectList(lstParentRestaurant, "ID", "Name");
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
            return View(objRestaurant);
        }


        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddRestaurant(Restaurant objRestaurantModel, int? id, HttpPostedFileBase LogoFile = null)
        {
            string logoPath = ConfigurationManager.AppSettings["LogoImageFolder"].ToString();
            ViewBag.Title = "Add Restaurant";
            if (ModelState.IsValid)
            {
                try
                {
                    
                    RestaurantDL objRestaurantDL = new RestaurantDL();
                    string guid = Guid.NewGuid().ToString();
                    if (LogoFile != null && LogoFile.ContentLength > 0)
                    {
                        if (!Directory.Exists(logoPath))
                            Directory.CreateDirectory(Server.MapPath(logoPath));
                        if (System.IO.File.Exists(Server.MapPath(logoPath + objRestaurantModel.Logo)))
                        {
                            System.IO.File.Delete(Server.MapPath(logoPath + objRestaurantModel.Logo));
                        }

                        objRestaurantModel.Logo = guid + "_" + LogoFile.FileName;

                    }
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    if (id != null)
                    {
                        objRestaurantModel.RestaurantID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit Restaurant";
                        objRestaurantModel.ModifiedBy = rs.UserID;
                        objApiResponse = objRestaurantDL.UpdateRestaurant(objRestaurantModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            if (LogoFile != null)
                                LogoFile.SaveAs(Path.Combine(Server.MapPath(logoPath), guid + "_" + LogoFile.FileName));
                            TempData["NotifyMessage"] = "Congratulations! Restaurant Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Restaurant");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Restaurant Name/Email already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objRestaurantModel.CreatedBy = rs.UserID;
                        objApiResponse = objRestaurantDL.AddRestaurant(objRestaurantModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            if (LogoFile != null)
                                LogoFile.SaveAs(Path.Combine(Server.MapPath(logoPath), guid + "_" + LogoFile.FileName));
                            TempData["NotifyMessage"] = "Congratulations! Restaurant Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Restaurant");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Restaurant Name/Email already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }

                    objApiResponse = objRestaurantDL.GetRestaurantById(Convert.ToInt32(id));
                    List<Country> lstCountry = new List<Country>();
                    List<State> lstState = new List<State>();
                    List<City> lstCity = new List<City>();
                    List<ListItem> lstParentRestaurant = new List<ListItem>();
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
                        ViewBag.Country = new SelectList(lstCountry, "CountryId", "CountryName");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstState.Add(new State { StateID = Convert.ToInt32(dr["StateID"]), StateName = Convert.ToString(dr["StateName"]) });
                            }
                        }
                        ViewBag.State = new SelectList(lstState, "StateId", "StateName");
                        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[3].Rows)
                            {
                                lstCity.Add(new City { CityID = Convert.ToInt32(dr["CityID"]), CityName = Convert.ToString(dr["CityName"]) });
                            }
                        }
                        ViewBag.City = new SelectList(lstCity, "CityId", "CityName");
                        if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[4].Rows)
                            {
                                lstParentRestaurant.Add(new ListItem { ID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.ParentRestaurant = new SelectList(lstParentRestaurant, "ID", "Name");
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
            return View(objRestaurantModel);
        }

        public ActionResult GetStateByCountryID(int CountryID)
        {
            IEnumerable<State> Statelist = null;
            RestaurantDL objRestaurantyDL = new RestaurantDL();
            objApiResponse = objRestaurantyDL.GetStateByCountryID(CountryID);
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
            return Json(Statelist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCityByStateID(int StateID)
        {
            IEnumerable<City> Citylist = null;
            RestaurantDL objRestaurantyDL = new RestaurantDL();
            objApiResponse = objRestaurantyDL.GetCityByStateID(StateID);
            if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
            {
                DataSet ds = (DataSet)objApiResponse.Result;
                Citylist = ds.Tables[0].AsEnumerable().Select(x => new City
                {
                    CityID = x.Field<int>("CityID"),
                    CityName = x.Field<string>("CityName")
                });
            }
            else
            {
                TempData["NotifyMessage"] = objApiResponse.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return Json(Citylist, JsonRequestBehavior.AllowGet);
        }

    }
}

