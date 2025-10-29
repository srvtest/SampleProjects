
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
    public class StateController : Controller
    {
        ApiResponse objApiResponse;
        // GET: State	 
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult State()
        {
            try
            {
                IEnumerable<State> Statelist = null;
                DataTable dtState = new DataTable();
                StateDL objStateDL = new StateDL();
                objApiResponse = objStateDL.GetState();


                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Statelist = ds.Tables[0].AsEnumerable().Select(x => new State
                    {
                        StateID = x.Field<Int32>("StateID"),
                        StateName = x.Field<String>("StateName"),
                        CountryName = x.Field<string>("CountryName"),
                        IsActive = x.Field<Boolean>("IsActive")

                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Statelist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult State(int? id)
        {
            try
            {
                StateDL objStateDL = new StateDL();
                objApiResponse = objStateDL.DeleteState(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "State Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "State can't delete before its associate city delete.";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("State");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddState(int? id)
        {
            ViewBag.Title = "Add State";
            State objStateModels = new EntityLayer.State();            
            try
            {
                DataTable dtState = new DataTable();
                StateDL objStateDL = new StateDL();
                objApiResponse = objStateDL.GetStateById(Convert.ToInt32(id));
                List<Country> lstCountry = new List<Country>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objStateModels = ds.Tables[0].AsEnumerable().Select(x => new State
                            {
                                StateID = x.Field<Int32>("StateID"),
                                StateName = x.Field<String>("StateName"),
                                CountryID = x.Field<Int32>("CountryID"),
                                IsActive = x.Field<Boolean>("IsActive")

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
            return View(objStateModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddState(State objStateModel, int? id)
        {
            ViewBag.Title = "Add State";
            if (ModelState.IsValid)
            {
                try
                { 
                    StateDL objStateDL = new StateDL();
                    if (id != null)
                    {
                        objStateModel.StateID = Convert.ToInt32(id);
                        ViewBag.Title = "Edit State";
                        objApiResponse = objStateDL.UpdateState(objStateModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! State Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("State");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "City ID already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objApiResponse = objStateDL.AddState(objStateModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! State Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("State");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "State already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objStateDL.GetStateById(Convert.ToInt32(id));
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
                    }
                    else
                    {
                        TempData["NotifyMessage"] = objApiResponse.Message;
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                    }

                    return View(objStateModel);
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objStateModel);
            }
            else
            {
                return View(objStateModel);
            }
        }
    }
}