
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
    public class TableReservationController : ApiController
    {
        // [Route("api/TableReservation")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<TableReservation> TableReservationlist = null;
                DataTable dtTableReservation = new DataTable();
                TableReservationDL objRestaurantUserDL = new TableReservationDL();

                objApiResponse = objRestaurantUserDL.GetTableReservation();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    TableReservationlist = ds.Tables[0].AsEnumerable().Select(x => new TableReservation
                    {
                        TableReservationID = x.Field<Int32>("TableReservationID"),
                        TableNumberID = x.Field<Int32>("TableNumberID"),
                        BookStartTime = x.Field<DateTime>("BookStartTime"),
                        //BookEndTime = x.Field<DateTime>("BookEndTime"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = TableReservationlist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = TableReservationlist;
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

        // [Route("api/TableReservationById")]	  

        [HttpGet]
        public ApiResponse TableReservationById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<TableReservation> TableReservationlist = null;

                DataTable dtTableReservation = new DataTable();
                TableReservationDL objRestaurantUserDL = new TableReservationDL();

                objApiResponse = objRestaurantUserDL.GetTableReservationById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    TableReservationlist = ds.Tables[0].AsEnumerable().Select(x => new TableReservation
                    {
                        TableReservationID = x.Field<Int32>("TableReservationID"),
                        TableNumberID = x.Field<Int32>("TableNumberID"),
                        BookStartTime = x.Field<DateTime>("BookStartTime"),
                        //BookEndTime = x.Field<DateTime>("BookEndTime"),
                        RestaurantID = x.Field<Int32>("RestaurantID"),
                        CustomerID = x.Field<Int32>("CustomerID"),
                        ModifiedBy = x.Field<Int32>("ModifiedBy"),
                        ModifiedDate = x.Field<DateTime>("ModifiedDate"),
                        CreatedBy = x.Field<Int32>("CreatedBy"),
                        CreatedDate = x.Field<DateTime>("CreatedDate")
                    });
                    objApiResponse.Result = TableReservationlist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = TableReservationlist;
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


        [Route("api/TableReservation/AddTableReservation")]
        [HttpPost]
        public ApiResponse AddTableReservation(TableReservation _TableReservation)
        {
            TableReservationDL objTableReservationDL = new TableReservationDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_TableReservation.TableReservationID > 0)
                {
                    objApiResponse = objTableReservationDL.UpdateTableReservation(_TableReservation);

                }
                else
                {
                    objApiResponse = objTableReservationDL.AddTableReservation(_TableReservation);
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
        public ApiResponse DeleteTableReservation(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                TableReservationDL objTableReservationDL = new TableReservationDL();
                objApiResponse = objTableReservationDL.DeleteTableReservation(Convert.ToInt32(id));
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