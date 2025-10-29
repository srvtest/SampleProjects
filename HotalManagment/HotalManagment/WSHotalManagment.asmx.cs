using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EntityLayer;
using DataLayer;

namespace HotalManagment
{
    /// <summary>
    /// Summary description for WSHotalManagment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSHotalManagment : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public RES_Response Reservation(RES_Request request)
        {
            RES_Response objResponse = new RES_Response();
            DL_WSHotalManagment objWSHotalManagment = new DL_WSHotalManagment();
            switch (request.Request_Type)
            {
                case "RoomInfo":
                   objResponse  =objWSHotalManagment.RoomInfo(request.Authentication.HotelCode);
                    break;
                default:
                    break;
            }
            return objResponse;
        }

        [WebMethod]
        public RES_Response AddMultipleBooking(RES_Response request)
        {
            RES_Response objResponse = new RES_Response();
            DL_WSHotalManagment objWSHotalManagment = new DL_WSHotalManagment();
            return objResponse;
        }

        
    }
}
