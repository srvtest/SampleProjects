
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
    public class CMSController : ApiController
    {
        // [Route("api/CMS")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<CMS> CMSlist = null;
                DataTable dtCMS = new DataTable();
                CMSDL objRestaurantUserDL = new CMSDL();

                objApiResponse = objRestaurantUserDL.GetCMS();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    CMSlist = ds.Tables[0].AsEnumerable().Select(x => new CMS
                    {
                        CMSID = x.Field<Int32>("CMSID"),
                        Title = x.Field<String>("Title"),
                        PageDesc = x.Field<String>("PageDesc"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = CMSlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = CMSlist;
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

        // [Route("api/CMSById")]	  

        [HttpGet]
        public ApiResponse CMSById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<CMS> CMSlist = null;

                DataTable dtCMS = new DataTable();
                CMSDL objRestaurantUserDL = new CMSDL();

                objApiResponse = objRestaurantUserDL.GetCMSById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    CMSlist = ds.Tables[0].AsEnumerable().Select(x => new CMS
                    {
                        CMSID = x.Field<Int32>("CMSID"),
                        Title = x.Field<String>("Title"),
                        PageDesc = x.Field<String>("PageDesc"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = CMSlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = CMSlist;
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


        [Route("api/CMS/AddCMS")]
        [HttpPost]
        public ApiResponse AddCMS(CMS _CMS)
        {
            CMSDL objCMSDL = new CMSDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_CMS.CMSID > 0)
                {
                    objApiResponse = objCMSDL.UpdateCMS(_CMS);

                }
                else
                {
                    objApiResponse = objCMSDL.AddCMS(_CMS);
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
        public ApiResponse DeleteCMS(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                CMSDL objCMSDL = new CMSDL();
                objApiResponse = objCMSDL.DeleteCMS(Convert.ToInt32(id));
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