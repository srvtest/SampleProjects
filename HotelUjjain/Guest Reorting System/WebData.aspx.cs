using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using Entity;


namespace Guest_Reporting_System
{
    public partial class WebData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HotelMasterDL objuserDL = new HotelMasterDL();
                ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(Session["snsHotelId"]));
                if (response != null)
                {
                    HotelMasterDto hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                    }
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public static void EmailReport(string base64String,string DocName,string HotelId)
        {
            byte[] pdfBytes = Convert.FromBase64String(base64String);

            string pathToFiles = HttpContext.Current.Server.MapPath("/iReports");
            //File.WriteAllBytes(pathToFiles + "\\" + DocName + ".pdf", memoryStream.ToArray());

            // Specify the path where you want to save the PDF file
            string filePath = pathToFiles + "\\" + DocName + ".pdf";

            // Write the byte array to a file
            File.WriteAllBytes(filePath, pdfBytes);

           
            String[] attachmentPath = new String[1];
            attachmentPath[0] = filePath;

            string ToEmail = string.Empty;
            string HotelName = string.Empty;
            string HotelEmail = string.Empty;

            HotelMasterDL objuserDL = new HotelMasterDL();
            ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(HotelId));
            if (response != null)
            {
                HotelMasterDto hotelDto = (HotelMasterDto)response.Result;
                if (hotelDto != null)
                {
                    ToEmail = hotelDto.PoliceStationEmailId;
                    HotelName = hotelDto.HotelName;
                    HotelEmail = hotelDto.EmailAddress;
                }
            }



            //UtilityFunctionDL.SendEmail(ToEmail, "Guest Report", "PFA", attachmentPath, HotelEmail);

        }



    }
}