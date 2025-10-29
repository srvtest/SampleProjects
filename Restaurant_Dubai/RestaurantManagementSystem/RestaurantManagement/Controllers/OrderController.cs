
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
    public class OrderController : Controller
    {
        // GET: Order	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Order()
        {
            try
            {
                IEnumerable<Order> Orderlist = null;
                DataTable dtOrder = new DataTable();
                OrderDL objOrderDL = new OrderDL();
                objApiResponse = objOrderDL.GetOrder();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Orderlist = ds.Tables[0].AsEnumerable().Select(x => new Order
                    {
                        TransID = x.Field<Int32>("TransID"),
                        OrderNumber = x.Field<Int64>("OrderNumber"),
                        CustomerEmail = x.Field<string>("Email"),
                        TableID = x.Field<Int32>("TableID"),
                        NumOfPerson = x.Field<Int32>("NumOfPerson"),
                        TimeOfArrival = x.Field<string>("TimeOfArrival"),
                        OrderServeTime = x.Field<string>("OrderServeTime"),
                        RestaurantName = x.Field<string>("Name"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Orderlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Order(int? id)
        {
            try
            {
                OrderDL objOrderDL = new OrderDL();
                objOrderDL.DeleteOrder(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Order Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("Order");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddOrder(int? id)
        {
            ViewBag.Title = "Add Order";
            Order objOrderModels = new EntityLayer.Order();
            try
            {
                DataTable dtOrder = new DataTable();
                OrderDL objOrderDL = new OrderDL();
                objApiResponse = objOrderDL.GetOrderById(Convert.ToInt32(id));
                List<Customer> lstCustomer = new List<Customer>();
                List<FoodDetail> lstFoodDetail = new List<FoodDetail>();
                List<TableNo> lstTable = new List<TableNo>();
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                List<OrderDetails> lstOrderDtls = new List<OrderDetails>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {

                            objOrderModels = ds.Tables[0].AsEnumerable().Select(x => new Order
                            {
                                TransID = x.Field<Int32>("TransID"),
                                OrderNumber = x.Field<Int64>("OrderNumber"),
                                CustomerID = x.Field<Int32>("CustomerID"),
                                TableID = x.Field<Int32>("TableID"),
                                NumOfPerson = x.Field<Int32>("NumOfPerson"),
                                TimeOfArrival = x.Field<string>("TimeOfArrival"),
                                OrderServeTime = x.Field<string>("OrderServeTime"),
                                RestaurantID = x.Field<Int32>("RestaurantID"),
                                IsActive = x.Field<bool>("IsActive")
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
                                lstFoodDetail.Add(new FoodDetail { FoodID = Convert.ToInt32(dr["FoodID"]), Title = Convert.ToString(dr["Title"]) });
                            }
                        }
                        ViewBag.UserFoodDetail = new SelectList(lstFoodDetail, "FoodID", "Title");
                        if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[3].Rows)
                            {
                                lstTable.Add(new TableNo { TableNumberID = Convert.ToInt32(dr["TableNumberID"]), TableNumber = Convert.ToString(dr["TableNumber"]) });
                            }
                        }
                        ViewBag.TableNo = new SelectList(lstTable, "TableNumberID", "TableNumber");
                        if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[4].Rows)
                            {
                                lstRestaurant.Add(new Restaurant { RestaurantID = Convert.ToInt32(dr["RestaurantID"]), Name = Convert.ToString(dr["Name"]) });
                            }
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");

                        if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[5].Rows)
                            {
                                lstOrderDtls.Add(new OrderDetails { FoodID = Convert.ToInt32(dr["FoodID"]), FoodName = Convert.ToString(dr["Title"]), Quantity = Convert.ToInt32(dr["Quantity"]), Amount = Convert.ToDecimal(dr["Amount"]) });
                            }
                        }
                        objOrderModels.lstOrderDetails = lstOrderDtls;
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
            return View(objOrderModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(Order objOrderModel, int? id)
        {
            ViewBag.Title = "Add Order";

            if (ModelState.IsValid)
            {
                try
                {
                    //objOrderModel.OrderID = 1;	 
                    objOrderModel.TransID = Convert.ToInt32(id);
                    OrderDL objOrderDL = new OrderDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];

                    if (id != null)
                    {
                        ViewBag.Title = "Edit Order";
                        objOrderModel.ModifiedBy = rs.UserID;

                        objApiResponse = objOrderDL.AddUpdateOrder(objOrderModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Order Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Order");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objOrderModel.CreatedBy = rs.UserID;

                        objApiResponse = objOrderDL.AddUpdateOrder(objOrderModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Order Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Order");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    objApiResponse = objOrderDL.GetOrderById(Convert.ToInt32(id));
                    List<Customer> lstCustomer = new List<Customer>();
                    List<FoodDetail> lstFoodDetail = new List<FoodDetail>();
                    List<TableNo> lstTable = new List<TableNo>();
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
                                    lstFoodDetail.Add(new FoodDetail { FoodID = Convert.ToInt32(dr["CustomerID"]), Title = Convert.ToString(dr["Title"]) });
                                }
                            }
                            ViewBag.UserFoodDetail = new SelectList(lstFoodDetail, "FoodID", "Title");
                            if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[3].Rows)
                                {
                                    lstTable.Add(new TableNo { TableNumberID = Convert.ToInt32(dr["TableNumberID"]), TableNumber = Convert.ToString(dr["TableNumber"]) });
                                }
                            }
                            ViewBag.TableNo = new SelectList(lstTable, "TableNumberID", "TableNumber");
                            if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                            {
                                foreach (DataRow dr in ds.Tables[4].Rows)
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
                return View(objOrderModel);
            }
            else
            {
                return View(objOrderModel);
            }
        }

        public decimal GetPrice(int foodId)
        {
            OrderDL objOrderDL = new OrderDL();
            objApiResponse = objOrderDL.GetPrice(foodId);
            decimal foodPrice = 0;
            if (objApiResponse != null && objApiResponse.Result != null)
            {
                DataSet ds = (DataSet)objApiResponse.Result;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    foodPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]);
            }
            return foodPrice;
        }

        public JsonResult CreateOrder(Order objOrderModel)
        {
            OrderDL objOrderDL = new OrderDL();
            RSession rs = new RSession();
            rs = (RSession)Session["RSession"];
            if(rs != null)
                objOrderModel.CreatedBy = rs.UserID;
            else
                return Json("0", JsonRequestBehavior.AllowGet);

            objApiResponse = objOrderDL.AddUpdateOrder(objOrderModel);
            if (objApiResponse.StatusCode == 200)
            {
                TempData["success"] = "Congratulations! Order Created Successfully";
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}