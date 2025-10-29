
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
    public class EmailTemplateController : Controller
    {
        // GET: EmailTemplate	 
        ApiResponse objApiResponse;
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EmailTemplate()
        {
            try
            {
                IEnumerable<EmailTemplate> EmailTemplatelist = null;
                DataTable dtEmailTemplate = new DataTable();
                EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();

                objApiResponse = objEmailTemplateDL.GetEmailTemplate();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    EmailTemplatelist = ds.Tables[0].AsEnumerable().Select(x => new EmailTemplate
                    {
                        EmailTemplateID = x.Field<int>("EmailTemplateID"),
                        RestaurantID = x.Field<int>("RestaurantID"),
                        Name = x.Field<string>("Name"),
                        EmailBody = x.Field<string>("EmailBody"),
                        IsActive = x.Field<bool>("IsActive")
                    });
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }

                return View(EmailTemplatelist);
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }

        [HttpDelete]
        public ActionResult EmailTemplate(int? id)
        {
            try
            {
                EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();
                objApiResponse= objEmailTemplateDL.DeleteEmailTemplate(Convert.ToInt32(id));
                if (objApiResponse != null && objApiResponse.StatusCode == 0)
                {
                    if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(1))
                    {
                        TempData["NotifyMessage"] = "Email Template Deleted Successfully";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                    }
                    else if (int.Parse(Convert.ToString(objApiResponse.Result)).Equals(-2))
                    {
                        TempData["NotifyMessage"] = "Email Template can't delete because foreign key relationship";
                        TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                    }
                }
                else
                {
                    TempData["NotifyMessage"] = objApiResponse.Message;
                    TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
                }
                TempData.Keep();
                return RedirectToAction("EmailTemplate");
            }
            catch (Exception ex)
            {
                TempData["NotifyMessage"] = ex.Message;
                TempData["NotifyType"] = Utility.CommonEnums.MessageType.danger;
            }
            return View();
        }


        public ActionResult AddEmailTemplate(int? id)
        {
            ViewBag.Title = "Add EmailTemplate";
            EmailTemplate objEmailTemplateModels = new EntityLayer.EmailTemplate();
            try
            {
                //ViewBag.Title = "Edit EmailTemplate";
                EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();
                objApiResponse = objEmailTemplateDL.GetEmailTemplateById(Convert.ToInt32(id));
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            objEmailTemplateModels = ds.Tables[0].AsEnumerable().Select(x => new EmailTemplate
                            {
                                EmailTemplateID = x.Field<int>("EmailTemplateID"),
                                RestaurantID = x.Field<int>("RestaurantID"),
                                Name = x.Field<string>("Name"),
                                EmailBody = x.Field<string>("EmailBody"),
                                IsActive = x.Field<bool>("IsActive")
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
            return View(objEmailTemplateModels);
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmailTemplate(EmailTemplate objEmailTemplateModel, int? id)
        {
            ViewBag.Title = "Add EmailTemplate";

            if (ModelState.IsValid)
            {
                try
                {
                    RSession rs = new RSession();
                    rs = (RSession)Session["RSession"];
                    objEmailTemplateModel.RestaurantID = rs.RestaurentId;	 
                    objEmailTemplateModel.EmailTemplateID = Convert.ToInt32(id);
                    EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();
                    if (id != null)
                    {
                        ViewBag.Title = "Edit EmailTemplate";
                        objApiResponse = objEmailTemplateDL.UpdateEmailTemplate(objEmailTemplateModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! EmailTemplate Updated Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("EmailTemplate");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Name already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    else
                    {
                        objApiResponse = objEmailTemplateDL.AddEmailTemplate(objEmailTemplateModel);
                        if (objApiResponse.Result != null && int.Parse(Convert.ToString(objApiResponse.Result)) != -2)
                        {
                            TempData["NotifyMessage"] = "Congratulations! EmailTemplate Created Successfully";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.success;
                            ModelState.Clear();
                            TempData.Keep();
                            return RedirectToAction("EmailTemplate");
                        }
                        else
                        {
                            TempData["NotifyMessage"] = "Name already exists.";
                            TempData["NotifyType"] = Utility.CommonEnums.MessageType.warning;
                        }
                    }
                    //return View(new EmailTemplate());

                    objApiResponse = objEmailTemplateDL.GetEmailTemplateById(Convert.ToInt32(id));
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
                        }
                        ViewBag.UserRestaurant = new SelectList(lstRestaurant, "RestaurantID", "Name");
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
                return View(objEmailTemplateModel);
            }
            else
            {
                return View(objEmailTemplateModel);
            }
        }
    }
}