
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
    public class OrderTrackController : Controller
    {
        // GET: OrderTrack	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OrderTrack()
        {
            try
            {
                IEnumerable<OrderTrack> OrderTracklist = null;
                DataTable dtOrderTrack = new DataTable();
                OrderTrackDL objOrderTrackDL = new OrderTrackDL();
                objApiResponse = objOrderTrackDL.GetOrderTrack();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;

                    OrderTracklist = ds.Tables[0].AsEnumerable().Select(x => new OrderTrack
                    {
                        DeliveryID = x.Field<Int32>("DeliveryID"),
                        OrderID = x.Field<Int32>("OrderID"),
                        Packed = x.Field<Boolean>("Packed"),
                        DineIn = x.Field<String>("DineIn"),
                        DineInDate = x.Field<DateTime>("DineInDate"),
                        DineOut = x.Field<String>("DineOut"),
                        DineOutDate = x.Field<DateTime>("DineOutDate"),
                        Delivered = x.Field<String>("Delivered"),
                        DeliveryDate = x.Field<DateTime>("DeliveryDate"),
                        DeliveryDesc = x.Field<String>("DeliveryDesc"),
                        StaffID = x.Field<Int32>("StaffID"),
                        //CustomerID = x.Field<Int32>("CustomerID"),
                        //RestaurantID = x.Field<Int32>("RestaurantID"),
                        CustomerName = x.Field<string>("CustomerName"),
                        RestaurantName = x.Field<string>("Name"),
                        DeliveryCost = x.Field<decimal>("DeliveryCost"),
                        PaymentType = x.Field<Byte>("PaymentType"),
                        Amount = x.Field<decimal>("Amount"),
                        Address = x.Field<String>("Address")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(OrderTracklist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult OrderTrack(int? id)
        {
            try
            {
                OrderTrackDL objOrderTrackDL = new OrderTrackDL();
                objOrderTrackDL.DeleteOrderTrack(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "OrderTrack Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("OrderTrack");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddOrderTrack(int? id)
        {
            ViewBag.Title = "Add OrderTrack";
            OrderTrack objOrderTrackModels = new EntityLayer.OrderTrack();

            try
            {
                DataTable dtOrderTrack = new DataTable();
                OrderTrackDL objOrderTrackDL = new OrderTrackDL();
                objApiResponse = objOrderTrackDL.GetOrderTrackById(Convert.ToInt32(id));
                List<Customer> lstCustomer = new List<Customer>();
                List<Tax> lstTax = new List<Tax>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objOrderTrackModels = ds.Tables[0].AsEnumerable().Select(x => new OrderTrack
                            {
                                DeliveryID = x.Field<Int32>("DeliveryID"),
                                OrderID = x.Field<Int32>("OrderID"),
                                Packed = x.Field<Boolean>("Packed"),
                                DineIn = x.Field<String>("DineIn"),
                                DineInDate = x.Field<DateTime>("DineInDate"),
                                DineOut = x.Field<String>("DineOut"),
                                DineOutDate = x.Field<DateTime>("DineOutDate"),
                                Delivered = x.Field<String>("Delivered"),
                                DeliveryDate = x.Field<DateTime>("DeliveryDate"),
                                DeliveryDesc = x.Field<String>("DeliveryDesc"),
                                StaffID = x.Field<Int32>("StaffID"),
                                //CustomerID = x.Field<Int32>("CustomerID"),
                                CustomerName = x.Field<string>("CustomerName"),
                                //RestaurantID = x.Field<Int32>("RestaurantID"),
                                RestaurantName = x.Field<string>("Name"),
                                DeliveryCost = x.Field<decimal>("DeliveryCost"),
                                PaymentType = x.Field<Byte>("PaymentType"),
                                Amount = x.Field<decimal>("Amount"),
                                Address = x.Field<String>("Address")

                            }).ToList().FirstOrDefault();
                        }
                        if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["Firstname"]) });
                            }
                        }
                        ViewBag.UserCustomer = new SelectList(lstCustomer, "CustomerID", "Firstname");
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[2].Rows)
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

            return View(objOrderTrackModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrderTrack(OrderTrack objOrderTrackModel, int? id)
        {
            ViewBag.Title = "Add OrderTrack";

            if (ModelState.IsValid)
            {
                try
                {
                    //objOrderTrackModel.OrderTrackID = 1;	 
                    objOrderTrackModel.DeliveryID = Convert.ToInt32(id);
                    OrderTrackDL objOrderTrackDL = new OrderTrackDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objOrderTrackModel.RestaurantID = rs.RestaurentId;
                    if (id != null)
                    {
                        ViewBag.Title = "Edit OrderTrack";
                        objOrderTrackModel.ModifiedBy = rs.UserID;
                   
                        objApiResponse = objOrderTrackDL.UpdateOrderTrack(objOrderTrackModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! OrderTrack Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("OrderTrack");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objOrderTrackModel.CreatedBy = rs.UserID;
                
                        objApiResponse = objOrderTrackDL.AddOrderTrack(objOrderTrackModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! OrderTrack Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("OrderTrack");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objOrderTrackDL.GetOrderTrackById(Convert.ToInt32(id));
                    List<Customer> lstCustomer = new List<Customer>();
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
                                    lstCustomer.Add(new Customer { CustomerID = Convert.ToInt32(dr["CustomerID"]), Firstname = Convert.ToString(dr["Firstname"]) });
                                }
                            }
                            ViewBag.UserCustomer = new SelectList(lstCustomer, "CustomerID", "Firstname");
                            if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[2].Rows)
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
                return View(objOrderTrackModel);
            }
            else
            {
                return View(objOrderTrackModel);
            }
        }
    }
}