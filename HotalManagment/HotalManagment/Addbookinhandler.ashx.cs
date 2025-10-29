using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer;
using System.Data;
using DataLayer;

namespace HotalManagment
{
    /// <summary>
    /// Summary description for Addbookinhandler
    /// </summary>
    public class Addbookinhandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            CommonUtilitys objCommonUtilitys = new CommonUtilitys();
            string requestBody = GetRequestContentBody(ref context);
            objCommonUtilitys.InsertLogs(requestBody);
            if (!string.IsNullOrEmpty(requestBody))
            {
                objCommonUtilitys.SetBookingDataCP(requestBody);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private string GetRequestContentBody(ref HttpContext context)
        {
            System.IO.Stream body = context.Request.InputStream;
            System.Text.Encoding encoding = context.Request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            if (!context.Request.ContentType.ToLower().Contains("application/xml") && !context.Request.ContentType.ToLower().Contains("text/xml"))
            {
                //errorType = ErrorType.ClientDataException;
                //  exceptionMessage = "Invalid content length. Expected content is  RealEC XML";
                //context.Response.Write("Client data content type " + context.Request.ContentType);
            }
            string s = reader.ReadToEnd();
            return s;
        }
    }
}