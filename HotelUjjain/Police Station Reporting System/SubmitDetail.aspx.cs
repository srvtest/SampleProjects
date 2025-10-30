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

namespace Police_Station_Reporting_System
{
    public partial class SubmitDetail : System.Web.UI.Page
    {
        string CheckinDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetSubmitedGuestByHotelId
            if (!IsPostBack)
            {
                string idHotel = "";
                string submitDate = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["idHotel"]) && !string.IsNullOrEmpty(Request.QueryString["SubmitDate"]))
                {
                    idHotel = Convert.ToString(Request.QueryString["idHotel"]);
                    idHotel = UtilityFunction.Decrypt(idHotel);
                    submitDate = Convert.ToString(Request.QueryString["SubmitDate"]);
                    submitDate = UtilityFunction.Decrypt(submitDate);
                }
                LoadGridData(Convert.ToInt32(idHotel), submitDate);
                hdnDoc.Value = "GuestCheckInReport_" + CheckinDate;
            }
        }

        private void LoadGridData(int idHotel, string submitDate)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = idHotel;
            guestFilterDto.FilterFromDate = submitDate;
            guestFilterDto.FilterToDate = submitDate;
            lblCheckIndate.InnerText = Convert.ToDateTime(guestFilterDto.FilterFromDate).ToString("dd-MMM-yyyy");

            ResponseDto obj = objuserDL.GetSubmitedGuestByHotelId(guestFilterDto);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        for (int i = 0; i < userDto.Count; i++)
                        {
                            userDto[i].IdentificationNo = new string('x', userDto[i].IdentificationNo.Length - 4) + userDto[i].IdentificationNo.Substring(userDto[i].IdentificationNo.Length - 4);
                        }
                        lblTotalGuest.InnerText = Convert.ToString(userDto.Sum(x => x.AddionalGuest)) + " (" + userDto.Where(x => x.gender == "पुरुष").Count() + " पुरुष, " + userDto.Where(x => x.gender == "महिला").Count() + " महिला)";
                        lblReportBy.InnerText = (userDto.Count > 0 ? userDto[0].SubmitBy : "") + " (" + userDto[0].CreatedDate.ToString("dd-MMM-yyyy hh:mm:ss tt") + ")";
                        lblHotelName.InnerText = userDto.Count > 0 ? userDto[0].HotelName.ToString().ToUpper() : "";
                        lblHotelContact.InnerText = "Phone Number : " + (userDto.Count > 0 ? userDto[0].HotelContact : "");
                        lblHotelAddress.InnerText = userDto.Count > 0 ? "Address : " + userDto[0].HotelAddress.ToString().ToUpper() + ", " + userDto[0].city.ToString().ToUpper() : "";
                        CheckinDate = lblHotelName.InnerText + "_" + Convert.ToDateTime(guestFilterDto.FilterFromDate).ToString("dd-MMM-yyyy");
                        rptGuestDetailTbl.DataSource = userDto;
                        rptGuestDetailTbl.DataBind();
                        rptGuestDetail.DataSource = userDto;
                        rptGuestDetail.DataBind();
                    }
                }
            }
            //ShowUserPanal(false);
        }

        protected void rptGuestDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeater = e.Item.FindControl("rptDetail") as Repeater;
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                List<GuestMasterDto> userDto = (List<GuestMasterDto>)rptGuestDetail.DataSource;
                if (userDto != null && userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).Count() > 0)
                {
                    GuestMasterDto guestMasterDto = userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).FirstOrDefault();


                    List<GuestDetailDto> guestDetailDtos = guestMasterDto.Details;

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


                    using (var client = new WebClient())
                    {
                        client.DownloadFile(filePathurl + guestMasterDto.Image1, strFolder + guestMasterDto.Image1);
                    }
                    string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                    //UtilityFunction.DecryptFile(strFolder + userDto.Image1, strFolderTemp + strFilePath1, userDto.filePass);
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
                    Image image1 = e.Item.FindControl("Image1") as Image;
                    image1.ImageUrl = filePathUrlTemp + strFilePath1;
                    //Label1.Text += filePathUrlTemp + strFilePath1;
                    System.IO.File.Delete(strFolder + guestMasterDto.Image1);


                    using (var client = new WebClient())
                    {
                        client.DownloadFile(filePathurl + guestMasterDto.Image2, strFolder + guestMasterDto.Image2);
                    }
                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
                    Image image2 = e.Item.FindControl("Image2") as Image;
                    image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    //Label1.Text += filePathUrlTemp + strFilePath1;
                    System.IO.File.Delete(strFolder + guestMasterDto.Image2);

                    //if (guestDetailDtos != null)
                    //{
                    //    repeater.DataSource = guestDetailDtos;
                    //    repeater.DataBind();
                    //}                   
                }
            }
        }

        //protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item ||
        //                   e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HiddenField hdnId = e.Item.FindControl("hdnIdGuestDetail") as HiddenField;

        //        List<GuestDetailDto> guestDetailDtos = (List<GuestDetailDto>)((Repeater)sender).DataSource;
        //        if (guestDetailDtos != null && guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).Count() > 0)
        //        {
        //            GuestDetailDto guestDetailDtosData = guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).FirstOrDefault();

        //            string strFolder;
        //            strFolder = Server.MapPath("./GuestFiles/");
        //            // Create the directory if it does not exist.
        //            if (!Directory.Exists(strFolder))
        //            {
        //                Directory.CreateDirectory(strFolder);
        //            }

        //            //=================================

        //            string strFolderTemp;
        //            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
        //            // Create the directory if it does not exist.
        //            if (!Directory.Exists(strFolderTemp))
        //            {
        //                Directory.CreateDirectory(strFolderTemp);
        //            }
        //            string filePathurl = ConfigurationManager.AppSettings["filePathUrl"].ToString();
        //            string filePathUrlTemp = ConfigurationManager.AppSettings["filePathUrlTemp"].ToString();


        //            using (var client = new WebClient())
        //            {
        //                client.DownloadFile(filePathurl + guestDetailDtosData.Image, strFolder + guestDetailDtosData.Image);
        //            }
        //            string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
        //            //UtilityFunction.DecryptFile(strFolder + userDto.Image1, strFolderTemp + strFilePath1, userDto.filePass);
        //            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image, strFolderTemp + strFilePath1, guestDetailDtosData.filePass);
        //            Image image1 = e.Item.FindControl("Image") as Image;
        //            image1.ImageUrl = filePathUrlTemp + strFilePath1;
        //            //Label1.Text += filePathUrlTemp + strFilePath1;
        //            System.IO.File.Delete(strFolder + guestDetailDtosData.Image);


        //            using (var client = new WebClient())
        //            {
        //                client.DownloadFile(filePathurl + guestDetailDtosData.Image2, strFolder + guestDetailDtosData.Image2);
        //            }
        //            string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
        //            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image2, strFolderTemp + strFilePath2, guestDetailDtosData.filePass);
        //            Image image2 = e.Item.FindControl("Image2") as Image;
        //            image2.ImageUrl = filePathUrlTemp + strFilePath2;
        //            //Label1.Text += filePathUrlTemp + strFilePath1;
        //            System.IO.File.Delete(strFolder + guestDetailDtosData.Image2);


        //        }
        //    }
       // }
    }
}