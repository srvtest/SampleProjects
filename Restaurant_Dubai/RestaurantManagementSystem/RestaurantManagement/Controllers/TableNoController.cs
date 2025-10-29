
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
    public class TableNoController : Controller
    {
        // GET: TableNo	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TableNo()
        {
            try
            {
                IEnumerable<TableNo> TableNolist = null;
                DataTable dtTableNo = new DataTable();
                TableNoDL objTableNoDL = new TableNoDL();
                objApiResponse = objTableNoDL.GetTableNo();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    TableNolist = ds.Tables[0].AsEnumerable().Select(x => new TableNo
                    {
                        TableNumberID = x.Field<int>("TableNumberID"),
                        TableNumber = x.Field<string>("TableNumber"),
                        TableCapacity = x.Field<byte>("TableCapacity"),
                        IsActive = x.Field<bool>("IsActive"),
                        IsBusy = x.Field<bool>("IsBusy"),
                        RestaurantName = x.Field<string>("Name")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(TableNolist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult TableNo(int? id)
        {
            try
            {
                TableNoDL objTableNoDL = new TableNoDL();
                objTableNoDL.DeleteTableNo(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Table Number Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("TableNo");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddTableNo(int? id)
        {
            ViewBag.Title = "Add TableNo";
            TableNo objTableNoModels = new EntityLayer.TableNo();
            try
            {
                DataTable dtTableNo = new DataTable();
                TableNoDL objTableNoDL = new TableNoDL();
                objApiResponse = objTableNoDL.GetTableNoById(Convert.ToInt32(id));
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objTableNoModels = ds.Tables[0].AsEnumerable().Select(x => new TableNo
                            {
                                TableNumberID = x.Field<int>("TableNumberID"),
                                TableNumber = x.Field<string>("TableNumber"),
                                TableCapacity = x.Field<byte>("TableCapacity"),
                                IsActive = x.Field<bool>("IsActive"),
                                IsBusy = x.Field<bool>("IsBusy"),
                                RestaurantName = x.Field<string>("Name")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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

            return View(objTableNoModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddTableNo(TableNo objTableNoModel, int? id)
        {
            ViewBag.Title = "Add TableNo";

            if (ModelState.IsValid)
            {
                try
                {
                    //objTableNoModel.TableNoID = 1;	 
                    objTableNoModel.TableNumberID = Convert.ToInt32(id);
                    TableNoDL objTableNoDL = new TableNoDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objTableNoModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        ViewBag.Title = "Edit TableNo";
                        objTableNoModel.ModifiedBy = rs.UserID;
                      
                        objApiResponse = objTableNoDL.UpdateTableNo(objTableNoModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! TableNo Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("TableNo");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objTableNoModel.CreatedBy = rs.UserID;
                      
                        objApiResponse = objTableNoDL.AddTableNo(objTableNoModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! TableNo Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("TableNo");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objTableNoDL.GetTableNoById(Convert.ToInt32(id));
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
                                    lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                                }
                            }
                            ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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
                return View(objTableNoModel);
            }
            else
            {
                return View(objTableNoModel);
            }
        }
    }
}