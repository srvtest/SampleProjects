
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
    public class TableNoController : ApiController
    {
        // [Route("api/TableNo")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<TableNo> TableNolist = null;
                DataTable dtTableNo = new DataTable();
                TableNoDL objRestaurantUserDL = new TableNoDL();

                objApiResponse = objRestaurantUserDL.GetTableNo();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    TableNolist = ds.Tables[0].AsEnumerable().Select(x => new TableNo
                    {
                        TableNumberID = x.Field<Int32>("TableNumberID"),
                        TableNumber = x.Field<String>("TableNumber"),
                        TableCapacity = x.Field<Byte>("TableCapacity"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IsBusy = x.Field<Boolean>("IsBusy"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = TableNolist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = TableNolist;
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

        // [Route("api/TableNoById")]	  

        [HttpGet]
        public ApiResponse TableNoById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<TableNo> TableNolist = null;

                DataTable dtTableNo = new DataTable();
                TableNoDL objRestaurantUserDL = new TableNoDL();

                objApiResponse = objRestaurantUserDL.GetTableNoById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    TableNolist = ds.Tables[0].AsEnumerable().Select(x => new TableNo
                    {
                        TableNumberID = x.Field<Int32>("TableNumberID"),
                        TableNumber = x.Field<String>("TableNumber"),
                        TableCapacity = x.Field<Byte>("TableCapacity"),
                        IsActive = x.Field<Boolean>("IsActive"),
                        IsBusy = x.Field<Boolean>("IsBusy"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = TableNolist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = TableNolist;
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


        [Route("api/TableNo/AddTableNo")]
        [HttpPost]
        public ApiResponse AddTableNo(TableNo _TableNo)
        {
            TableNoDL objTableNoDL = new TableNoDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_TableNo.TableNumberID > 0)
                {
                    objApiResponse = objTableNoDL.UpdateTableNo(_TableNo);

                }
                else
                {
                    objApiResponse = objTableNoDL.AddTableNo(_TableNo);
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
        public ApiResponse DeleteTableNo(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                TableNoDL objTableNoDL = new TableNoDL();
                objApiResponse = objTableNoDL.DeleteTableNo(Convert.ToInt32(id));
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