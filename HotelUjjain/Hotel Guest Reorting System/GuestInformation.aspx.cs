using Amazon.S3.Model;
using Amazon.S3;
using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;

namespace Hotel_Guest_Reporting_System
{
    public partial class GuestInformation : System.Web.UI.Page
    {
        private const string bucketName = "guestreport";
        private const string accessKey = "AKIA3FLD27LK36WSWZLP";
        private const string secretKey = "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";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.APSouth1;
        //string CheckinDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["HotelID"]))
                {
                    string idGuestMaster = Request.QueryString["idGuestMaster"];
                    string HotelID = (Request.QueryString["HotelID"]);
                    string CheckinDate = (Request.QueryString["CheckinDate"]);
                    string BookingId = (Request.QueryString["BookingId"]);
                    //string HotelID = EncryptionHelper.Decrypt(Request.QueryString["HotelID"]);
                    //string CheckinDate = EncryptionHelper.Decrypt(Request.QueryString["CheckinDate"]);
                    //string BookingId = EncryptionHelper.Decrypt(Request.QueryString["BookingId"]);
                    //idGuestMaster = UtilityFunction.Decrypt(idGuestMaster);
                    LoadData(idGuestMaster, Convert.ToInt32(HotelID), CheckinDate, Convert.ToInt32(BookingId));
                    hdnDoc.Value = "SearchGuestReport_" + CheckinDate;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", idGuestMaster + "_"+  HotelID + "_" + CheckinDate + "_" + BookingId, true);
                }
            }
        }

        private void LoadData(object idGuestMaster,int HotelID,string CheckInDate,int BookingId)
        {
            var responseModel = new GuestDataReportResponseModel();
            GuestMasterDL objGuestMasterDL = new GuestMasterDL();
            //ResponseDto response = objGuestMasterDL.GetGuestMasterById(Convert.ToInt16(idGuestMaster));
            //if (response != null)
            //{
            //    List<GuestMasterDto> userDto = (List<GuestMasterDto>)response.Result;
            //    if (userDto != null)
            //    {
            //        CheckinDate = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
            //        lblCheckIndate.InnerText = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
            //        lblCheckOutdate.InnerText = Convert.ToDateTime(userDto[0].CheckOutDate).ToString("dd-MMM-yyyy");
            //        lblTotalGuest.InnerText = Convert.ToString(userDto[0].AddionalGuest);
            //        lblisSumbit.InnerText = userDto[0].isSubmitted ? "हाँ" : "नहीं";
            //        lblHotelName.InnerText = (string)(userDto[0].HotelName);
            //        lblHotelContact.InnerText = "Phone Number : " + Convert.ToString(userDto[0].HotelContact);
            //        lblHotelAddress.InnerText = (string)(userDto[0].HotelAddress);
            //        rptGuestDetailTbl.DataSource = userDto;
            //        rptGuestDetailTbl.DataBind();
            //        rptDetail.DataSource = userDto;
            //        rptDetail.DataBind();
            //    }
            //}
            CheckInReportWithGuestDataRequestModel requestModel = new CheckInReportWithGuestDataRequestModel();
            requestModel.HotelId = HotelID;
            requestModel.CheckInDate = CheckInDate;
            requestModel.BookingId = BookingId;
            ResponseDto response = objGuestMasterDL.GetGuestMasterByHotelID(requestModel);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", Convert.ToString(response), true);
            if (response != null)
            {
                List<GuestDataReportResponseModel> userDto = (List<GuestDataReportResponseModel>)response.Result;
                if (userDto != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", Convert.ToString(userDto), true);
                    //CheckinDate = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
                    lblCheckIndate.InnerText = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
                    //lblCheckOutdate.InnerText = Convert.ToDateTime(userDto[0].CheckOutDate).ToString("dd-MMM-yyyy");
                    lblTotalGuest.InnerText = Convert.ToString(userDto[0].Totalguest);
                    //lblisSumbit.InnerText = userDto[0].isSubmitted ? "हाँ" : "नहीं";
                    lblHotelName.InnerText = (string)(userDto[0].hotelDetails.HotelName);
                    lblHotelContact.InnerText = "Phone Number : " + Convert.ToString(userDto[0].hotelDetails.HotelMobileNumber);
                    lblHotelAddress.InnerText = (string)(userDto[0].hotelDetails.HotelAddress);
                    rptGuestDetailTbl.DataSource = userDto[0].guestdetails;
                    rptGuestDetailTbl.DataBind();
                    rptDetail.DataSource = userDto[0].guestdetails;
                    rptDetail.DataBind();
                }
                //    foreach (var guest in responseModel.guestdetails)
                //    {
                //        guest.guestIDNumber = MaskIDProofNumber(guest.guestIDNumber);
                //        guest.guestFrontSideDocs = await GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, guest.guestFrontSideDocs);
                //        guest.guestBackSideDocs = await GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, guest.guestBackSideDocs);
                //    }
                //}

            }

        }

        protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                          e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                List<guestdetailsResponseModel> userDto = (List<guestdetailsResponseModel>)rptDetail.DataSource;

                //List<GuestDetailDto> guestDetailDtos = (List<GuestDetailDto>)((Repeater)sender).DataSource;
                //if (guestDetailDtos != null && guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).Count() > 0)
                //{
                //    GuestDetailDto guestDetailDtosData = guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (userDto != null && userDto.Where(x => x.guestID == Convert.ToInt32(hdnId.Value)).Count() > 0)
                {
                    guestdetailsResponseModel guestMasterDto = userDto.Where(x => x.guestID == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                    //List<GuestDetailDto> guestDetailDtos = guestMasterDto.Details;
                    string strFolder;
                    strFolder = Server.MapPath("./GuestFiles/");
                    // Create the directory if it does not exist.
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }



                    string strFolderTemp;
                    strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
                    // Create the directory if it does not exist.
                    if (!Directory.Exists(strFolderTemp))
                    {
                        Directory.CreateDirectory(strFolderTemp);
                    }
                    string filePathurl = ConfigurationManager.AppSettings["filePathUrl"].ToString();
                    string filePathUrlTemp = ConfigurationManager.AppSettings["filePathUrlTemp"].ToString();

                    //string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                    //UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
                    //Image image1 = e.Item.FindControl("Image1") as Image;
                    //image1.ImageUrl = filePathUrlTemp + strFilePath1;
                    ////Label1.Text += filePathUrlTemp + strFilePath1;

                    //string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    //UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
                    //Image image2 = e.Item.FindControl("Image2") as Image;
                    //image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    //using (var client = new WebClient())
                    //{
                    //    client.DownloadFile(filePathurl + guestMasterDto.Image1, strFolder + guestMasterDto.Image1);
                    //}
                    //string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                    ////UtilityFunction.DecryptFile(strFolder + userDto.Image1, strFolderTemp + strFilePath1, userDto.filePass);
                    //UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
                    Image image1 = e.Item.FindControl("Image1") as Image;
                    image1.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, guestMasterDto.guestFrontSideDocs);
                    //Label1.Text += filePathUrlTemp + strFilePath1;
                    //System.IO.File.Delete(strFolder + guestMasterDto.Image1);


                    //using (var client = new WebClient())
                    //{
                    //    client.DownloadFile(filePathurl + guestMasterDto.Image2, strFolder + guestMasterDto.Image2);
                    //}
                    //string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    //UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
                    Image image2 = e.Item.FindControl("Image2") as Image;
                    image2.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, guestMasterDto.guestBackSideDocs);
                    //Label1.Text += filePathUrlTemp + strFilePath1;
                    //System.IO.File.Delete(strFolder + guestMasterDto.Image2);


                }
            }
        }
        public string GetPresignedUrl(string accessKey, string secretKey, RegionEndpoint bucketRegion, string bucketName, string key)
        {
            var s3Client = new AmazonS3Client(accessKey, secretKey, bucketRegion);
            var urlRequest = new GetPreSignedUrlRequest()
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            var presignedUrl = s3Client.GetPreSignedURL(urlRequest);

            return presignedUrl;
        }
    }
}