
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
    public class StateController : ApiController
    {
        // [Route("api/State")]	  
        public ApiResponse Get()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<State> Statelist = null;
                DataTable dtState = new DataTable();
                StateDL objRestaurantUserDL = new StateDL();

                objApiResponse = objRestaurantUserDL.GetState();

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Statelist = ds.Tables[0].AsEnumerable().Select(x => new State
                    {
                        StateID = x.Field<Int32>("StateID"),
                        StateName = x.Field<String>("StateName"),
                        CountryID = x.Field<Int32>("CountryID"),
                        IsActive = x.Field<Boolean>("IsActive"),
                    });
                    objApiResponse.Result = Statelist;
                    objApiResponse.StatusCode = 0;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Statelist;
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

        // [Route("api/StateById")]	  

        [HttpGet]
        public ApiResponse StateById(int id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                IEnumerable<State> Statelist = null;

                DataTable dtState = new DataTable();
                StateDL objRestaurantUserDL = new StateDL();

                objApiResponse = objRestaurantUserDL.GetStateById(id);

                if (objApiResponse.StatusCode == 0 && objApiResponse.Result != null)
                {
                    DataSet ds = (DataSet)objApiResponse.Result;
                    Statelist = ds.Tables[0].AsEnumerable().Select(x => new State
                    {
                        StateID = x.Field<Int32>("StateID"),
                        StateName = x.Field<String>("StateName"),
                        CountryID = x.Field<Int32>("CountryID"),
                        IsActive = x.Field<Boolean>("IsActive"),
                    });
                    objApiResponse.Result = Statelist;
                    objApiResponse.StatusCode = 1;
                    objApiResponse.Message = "Data Received successfully";
                }
                else
                {
                    objApiResponse.Result = Statelist;
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


        [Route("api/State/AddState")]
        [HttpPost]
        public ApiResponse AddState(State _State)
        {
            StateDL objStateDL = new StateDL();
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                if (_State.StateID > 0)
                {
                    objApiResponse = objStateDL.UpdateState(_State);

                }
                else
                {
                    objApiResponse = objStateDL.AddState(_State);
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
        public ApiResponse DeleteState(int? id)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                StateDL objStateDL = new StateDL();
                objApiResponse = objStateDL.DeleteState(Convert.ToInt32(id));
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