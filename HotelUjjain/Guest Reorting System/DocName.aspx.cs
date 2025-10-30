using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Guest_Reporting_System
{
    public partial class DocName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static void EmailReport(string base64String, string DocName, string HotelId,string CheckInDate,string host,string FromEmailId, string Pass,string Con)
        {
            byte[] pdfBytes = Convert.FromBase64String(base64String);

            string pathToFiles = HttpContext.Current.Server.MapPath("/iReports");
            //File.WriteAllBytes(pathToFiles + "\\" + DocName + ".pdf", memoryStream.ToArray());
            //DocName = (string)(Session["D"]);
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
                    ToEmail=hotelDto.PoliceStationEmailId;
                    HotelName=hotelDto.HotelName;
                    HotelEmail = hotelDto.EmailAddress;
                }
            }
            string Subject = "Guest Report Submission [" + HotelName +"]-["+DateTime.Now+"]";
            string Body = "<!DOCTYPE html>\r\n<html>\r\n\t<head>\r\n\t\t<title></title>\r\n\t</head>\r\n\t<body>\r\n\t\t<p>प्रिय "+ HotelName + ", </p>\r\n \r\n<p>नमस्कार! </p>\r\n \r\n<p>धन्यवाद! आपकी होटल की "+ CheckInDate + " की अतिथि जानकारी सफलतापूर्वक पुलिस स्टेशन  में सबमिट हो गई है।</br> कृपया संलग्न रिपोर्ट की एक प्रति अपने रिकॉर्ड के लिए रखें। </p>\r\n</br> \r\n</br>   \r\n<p>धन्यवाद! </p>\r\n<p>सादर, </br> GuestReport.in टीम </p>\r\n<p>(यह ईमेल स्वचालित रूप से उत्पन्न किया गया है, कृपया इसका उत्तर न दें।)</p>\r\n\t</body>\r\n</html>";
            UtilityFunctionDL.SendEmail(ToEmail, Subject, Body, attachmentPath, HotelEmail, host, FromEmailId, Pass,Con);
        }
    }
}