
using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestaurantManagement.Controllers.API
{
    public class EmailTemplateController : ApiController
    {
        // [Route("api/EmailTemplate")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<EmailTemplate> EmailTemplatelist = null;
                DataTable dtEmailTemplate = new DataTable();
                EmailTemplateDL objRestaurantUserDL = new EmailTemplateDL();

                objApiResponse = objRestaurantUserDL.GetEmailTemplate();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    EmailTemplatelist = ds.Tables[0].AsEnumerable().Select(x => new EmailTemplate
                    {
                        EmailTemplateID = x.Field<Int32>("EmailTemplateID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        Name = x.Field<String>("Name"),
                        EmailBody = x.Field<String>("EmailBody"),
                        IsActive = x.Field<Boolean>("IsActive")
                    });
                    objApiResponse.Result = EmailTemplatelist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = EmailTemplatelist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Not found";
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }

        // [Route("api/EmailTemplateById")]	  

        [HttpGet]
        public ApiResponse EmailTemplateById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<EmailTemplate> EmailTemplatelist = null;

                DataTable dtEmailTemplate = new DataTable();
                EmailTemplateDL objRestaurantUserDL = new EmailTemplateDL();

                objApiResponse = objRestaurantUserDL.GetEmailTemplateById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    EmailTemplatelist = ds.Tables[0].AsEnumerable().Select(x => new EmailTemplate
                    {
                        EmailTemplateID = x.Field<Int32>("EmailTemplateID"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        Name = x.Field<String>("Name"),
                        EmailBody = x.Field<String>("EmailBody"),
                        IsActive = x.Field<Boolean>("IsActive")
                    });
                    objApiResponse.Result = EmailTemplatelist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = EmailTemplatelist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Not found";
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }


        [Route("api/EmailTemplate/AddEmailTemplate")]
        [HttpPost]
        public ApiResponse AddEmailTemplate(EmailTemplate _EmailTemplate)
        {
            EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_EmailTemplate.EmailTemplateID > 0)
                {
                    objApiResponse = objEmailTemplateDL.UpdateEmailTemplate(_EmailTemplate);

                }
                else
                {
                    objApiResponse = objEmailTemplateDL.AddEmailTemplate(_EmailTemplate);
                }

            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;

        }


        [HttpPost]
        public ApiResponse DeleteEmailTemplate(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                EmailTemplateDL objEmailTemplateDL = new EmailTemplateDL();
                objApiResponse = objEmailTemplateDL.DeleteEmailTemplate(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                objApiResponse.Result = null;
                objApiResponse.StatusCode = ex.HResult;
                objApiResponse.Message = ex.Message;
            }
            return objApiResponse;
        }
    }
}