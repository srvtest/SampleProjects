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
    public class CustomerController : Controller
    {
        ApiResponse objApiResponse;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // Get show Database Field in Gridview
        public ActionResult Customer()
        {
            try
            {
                IEnumerable<Customer> Customerlist = null;
                DataTable dtCustomer = new DataTable();
                CustomerDL objCustomerDL = new CustomerDL();

                objApiResponse = objCustomerDL.GetCustomer();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Customerlist = ds.Tables[0].AsEnumerable().Select(x => new Customer
                    {
                        CustomerID = x.Field<int>("CustomerID"),
                        Firstname = x.Field<string>("Firstname"),
                        LastName = x.Field<string>("LastName"),
                        Gender = x.Field<int>("Gender"),
                        Email = x.Field<string>("Email"),
                        password = x.Field<string>("password"),
                        Mobile = x.Field<string>("Mobile"),
                        Address = x.Field<string>("Address"),
                        OfficeAddress = x.Field<string>("OfficeAddress"),
                        CarRegistrationNo = x.Field<string>("CarRegistrationNo"),
                        IsActive = x.Field<bool>("IsActive"),
                        IpAddress = x.Field<string>("IpAddress")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(Customerlist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Customer(int? id)
        {
            try
            {
                CustomerDL objCustomerDL = new CustomerDL();
                objCustomerDL.DeleteCustomer(Convert.ToInt32(id));
                TempData["NotifyMessage"] = "Customer Deleted Successfully";
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                TempData.Keep();
                return RedirectToAction("customer");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        // Get Show Database Field to Toolbox
        public ActionResult AddCustomer(int? id)
        {
            ViewBag.Title = "Add Customer";
            Customer objCustomerModels = new EntityLayer.Customer();
            try
            {
                DataTable dtCustomer = new DataTable();
                CustomerDL objCustomerDL = new CustomerDL();
                objApiResponse = objCustomerDL.GetCustomerById(Convert.ToInt32(id));
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    objCustomerModels = ds.Tables[0].AsEnumerable().Select(x => new Customer
                    {
                        //CustomerID = x.Field<int>("CustomerID"),
                        Firstname = x.Field<string>("Firstname"),
                        LastName = x.Field<string>("LastName"),
                        Gender = x.Field<int>("Gender"),
                        Email = x.Field<string>("Email"),
                        password = x.Field<string>("password"),
                        Mobile = x.Field<string>("Mobile"),
                        Address = x.Field<string>("Address"),
                        OfficeAddress = x.Field<string>("OfficeAddress"),
                        CarRegistrationNo = x.Field<string>("CarRegistrationNo"),
                        IsActive = x.Field<bool>("IsActive"),
                        IpAddress = x.Field<string>("IpAddress")
                    }).ToList().FirstOrDefault();
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
            return View(objCustomerModels);
        }

        // Add or Update Method

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(Customer objCustomerModel, int? id)
        {
            ViewBag.Title = "Add Customer";
            if (ModelState.IsValid)
            {
                try
                {
                    objCustomerModel.CustomerID = Convert.ToInt32(id);
                    CustomerDL objCustomerDL = new CustomerDL();
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];

                    if (id != null)
                    {
                        ViewBag.Title = "Edit Customer";
                        objCustomerModel.ModifiedBy = rs.UserID;
                        objApiResponse = objCustomerDL.UpdateCustomer(objCustomerModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Customer Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Customer");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Customer ID Already Existed";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objCustomerModel.CreatedBy = rs.UserID;
                        objApiResponse = objCustomerDL.AddCustomer(objCustomerModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! Customer Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("Customer");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Email Already Existed";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["NotifyMessage"] = ex.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                return View(objCustomerModel);
            }
            else
            {
                return View(objCustomerModel);
            }

        }

    }
}