
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
    public class TableReservationController : Controller
    {
        // GET: TableReservation	
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TableReservation()
        {
            try
            {
                IEnumerable<TableReservation> TableReservationlist = null;
                DataTable dtTableReservation = new DataTable();
                TableReservationDL objTableReservationDL = new TableReservationDL();
                objApiResponse = objTableReservationDL.GetTableReservation();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    TableReservationlist = ds.Tables[0].AsEnumerable().Select(x => new TableReservation
                    {
                        TableReservationID = x.Field<Int32>("TableReservationID"),
                        TableNumberID = x.Field<Int32>("TableNumberID"),
                        BookStartTime = x.Field<DateTime>("BookStartTime"),
                       // BookEndTime = x.Field<DateTime>("BookEndTime"),
                        // RestaurantID = x.Field<Int32>("RestaurantID"),
                        RestaurantName = x.Field<string>("Name"),
                        IsActive = x.Field<bool>("IsActive"),
                        //CustomerID = x.Field<Int32>("CustomerID")
                        CustomerName = x.Field<string>("CustomerName")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(TableReservationlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult TableReservation(int? id)
        {
            try
            {
                TableReservationDL objTableReservationDL = new TableReservationDL();
                objTableReservationDL.DeleteTableReservation(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Table Reservation Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("TableReservation");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddTableReservation(int? id)
        {
            ViewBag.Title = "Add TableReservation";
            TableReservation objTableReservationModels = new EntityLayer.TableReservation();
            try
            {
                DataTable dtTableReservation = new DataTable();
                TableReservationDL objTableReservationDL = new TableReservationDL();
                objApiResponse = objTableReservationDL.GetTableReservationById(Convert.ToInt32(id));
                List<TableNo> lstTableNo = new List<TableNo>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                List<Customer> lstCustomer = new List<Customer>();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objTableReservationModels = ds.Tables[0].AsEnumerable().Select(x => new TableReservation
                            {
                                TableReservationID = x.Field<Int32>("TableReservationID"),
                                TableNumberID = x.Field<Int32>("TableNumberID"),
                                BookStartTime = x.Field<DateTime>("BookStartTime"),
                               // BookEndTime = x.Field<DateTime>("BookEndTime"),
                                //RestaurantID = x.Field<Int32>("RestaurantID"),
                                RestaurantName = x.Field<string>("Name"),
                                IsActive = x.Field<bool>("IsActive"),
                                //CustomerID = x.Field<Int32>("CustomerID")
                                CustomerName = x.Field<string>("CustomerName")
                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstTableNo.Add(new TableNo { TableNumberID = Convert.ToInt32(dr["TableNumberID"]), TableNumber = Convert.ToString(dr["TableNumber"]) });
                            }
                        }
                        ViewBag.UserTableNo = new SelectList(lstTableNo, "TableNumberID", "TableNumber");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
                            {
                                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[3].Rows)
                            {
                                lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["Firstname"]) });
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
            return View(objTableReservationModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddTableReservation(TableReservation objTableReservationModel, int? id)
        {
            ViewBag.Title = "Add TableReservation";

            if (ModelState.IsValid)
            {
                try
                {
                    //objTableReservationModel.TableReservationID = 1;	 
                    objTableReservationModel.TableReservationID = Convert.ToInt32(id);
                    TableReservationDL objTableReservationDL = new TableReservationDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objTableReservationModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        ViewBag.Title = "Edit TableReservation";
                        objTableReservationModel.ModifiedBy = rs.UserID;

                        objApiResponse = objTableReservationDL.UpdateTableReservation(objTableReservationModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! TableReservation Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("TableReservation");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objTableReservationModel.CreatedBy = rs.UserID;

                        objApiResponse = objTableReservationDL.AddTableReservation(objTableReservationModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! TableReservation Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("TableReservation");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objTableReservationDL.GetTableReservationById(Convert.ToInt32(id));
                    List<TableNo> lstTableNo = new List<TableNo>();
                    List<Restaurant> lstRestaurant = new List<Restaurant>();
                    List<Customer> lstCustomer = new List<Customer>();

                    if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                    {
                        DataSet ds = (DataSet)objApiResponse.Result;
                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    lstTableNo.Add(new TableNo { TableNumberID = Convert.ToInt32(dr["TableNumberID"]), TableNumber = Convert.ToString(dr["TableNumber"]) });
                                }
                            }
                            ViewBag.UserTableNo = new SelectList(lstTableNo, "TableNumberID", "TableNumber");
                            if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[2].Rows)
                                {
                                    lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                                }
                            }
                            ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
                            if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[3].Rows)
                                {
                                    lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["Firstname"]) });
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
                return View(objTableReservationModel);
            }
            else
            {
                return View(objTableReservationModel);
            }
        }
    }
}