using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public Response()
        {
        }
        public Response(int statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            Result = result;
            Message = errorMessage;
        }
    }
}