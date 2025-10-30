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
    public partial class PendingReport : System.Web.UI.Page
    {
        List<GuestMasterDto> userDto = null;
        ResponseDto obj = null;
        string CheckinDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuestMasterDL objuserDL = new GuestMasterDL();
                string submitdate = DateTime.Now.ToShortDateString();
                string idHotel;
                if (!string.IsNullOrEmpty(Request.QueryString["submitdate"]))
                {
                    idHotel = Request.QueryString["idHotel"];
                    idHotel= UtilityFunction.Decrypt(idHotel);
                    submitdate = Request.QueryString["SubmitDate"];
                    submitdate = UtilityFunction.Decrypt(submitdate);
                    LoadData(idHotel,submitdate, submitdate);
                    
                    hdnDoc.Value = "PendingGuestReport_" + lblHotelName.InnerText + "_" + CheckinDate;
                }
            }
        }
        private void LoadData(string idHotel,string fromDate, string toDate)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(idHotel);
            guestFilterDto.FilterFromDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            guestFilterDto.FilterToDate = Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");

            lblCheckIndate.InnerText = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            CheckinDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            obj = objuserDL.GetGuestPendingDetailForPoliceReport(guestFilterDto, false);

            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        for (int i = 0; i < userDto.Count; i++)
                        {
                            userDto[i].IdentificationNo = new string('x', userDto[i].IdentificationNo.Length - 4) + userDto[i].IdentificationNo.Substring(userDto[i].IdentificationNo.Length - 4);
                            userDto[i].ContactNo = userDto[i].ContactNo == "" ? "NA" : userDto[i].ContactNo;
                        }
                        lblTotalGuest.InnerText = Convert.ToString(userDto.Sum(x => x.AddionalGuest)) + " (" + userDto.Where(x => x.gender == "पुरुष").Count() + " पुरुष, " + userDto.Where(x => x.gender == "महिला").Count() + " महिला)";
                        lblReportBy.InnerText = userDto[0].isSubmitted ? "हाँ" : "रिपोर्ट सबमिट नहीं की गई है।";
                        lblHotelName.InnerText = userDto.Count > 0 ? userDto[0].HotelName.ToString().ToUpper() : "";
                        lblHotelContact.InnerText = "Phone Number : " + (userDto.Count > 0 ? userDto[0].HotelContact : "");
                        lblHotelAddress.InnerText = userDto.Count > 0 ? "Address : " + userDto[0].HotelAddress.ToString().ToUpper() + ", " + userDto[0].city.ToString().ToUpper() : "";
                        rptGuestDetailTbl.DataSource = userDto;
                        rptGuestDetailTbl.DataBind();
                        rptGuestDetail.DataSource = userDto;
                        rptGuestDetail.DataBind();
                    }
                }
            }


        }

        protected void rptGuestDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item ||
            //               e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Repeater repeater = e.Item.FindControl("rptDetail") as Repeater;
            //    HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
            //    userDto = (List<GuestMasterDto>)rptGuestDetail.DataSource;
            //    if (userDto != null && userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).Count() > 0)
            //    {
            //        GuestMasterDto guestMasterDto = userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
            //        List<GuestDetailDto> guestDetailDtos = guestMasterDto.Details;
            //        string strFolder;
            //        strFolder = Server.MapPath("./GuestFiles/");
            //        // Create the directory if it does not exist.
            //        if (!Directory.Exists(strFolder))
            //        {
            //            Directory.CreateDirectory(strFolder);
            //        }
            //        string strFolderTemp;
            //        strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
            //        // Create the directory if it does not exist.
            //        if (!Directory.Exists(strFolderTemp))
            //        {
            //            Directory.CreateDirectory(strFolderTemp);
            //        }
            //        string filePathurl = ConfigurationManager.AppSettings["filePathUrl"].ToString();
            //        string filePathUrlTemp = ConfigurationManager.AppSettings["filePathUrlTemp"].ToString();

            //        string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
            //        UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
            //        Image image1 = e.Item.FindControl("Image1") as Image;
            //        image1.ImageUrl = filePathUrlTemp + strFilePath1;
            //        //Label1.Text += filePathUrlTemp + strFilePath1;

            //        string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
            //        UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
            //        Image image2 = e.Item.FindControl("Image2") as Image;
            //        image2.ImageUrl = filePathUrlTemp + strFilePath2;
            //        //Label1.Text += filePathUrlTemp + strFilePath1;

            //        if (guestDetailDtos != null)
            //        {
            //            repeater.DataSource = guestDetailDtos;
            //            repeater.DataBind();
            //        }
            //    }
            //}
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
        //            string strFolderTemp;
        //            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
        //            // Create the directory if it does not exist.
        //            if (!Directory.Exists(strFolderTemp))
        //            {
        //                Directory.CreateDirectory(strFolderTemp);
        //            }
        //            string filePathurl = ConfigurationManager.AppSettings["filePathUrl"].ToString();
        //            string filePathUrlTemp = ConfigurationManager.AppSettings["filePathUrlTemp"].ToString();

        //            string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
        //            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image, strFolderTemp + strFilePath1, guestDetailDtosData.filePass);
        //            Image image1 = e.Item.FindControl("Image1") as Image;
        //            image1.ImageUrl = filePathUrlTemp + strFilePath1;
        //            //Label1.Text += filePathUrlTemp + strFilePath1;

        //            string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
        //            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image2, strFolderTemp + strFilePath2, guestDetailDtosData.filePass);
        //            Image image2 = e.Item.FindControl("Image2") as Image;
        //            image2.ImageUrl = filePathUrlTemp + strFilePath2;
        //            //Lbel1.Text += filePathUrlTemp + strFilePath2;
        //        }
        //    }
        //}

        protected void rptGuestDetailTbl_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                        e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Change")
                {
                    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnIdGuest");
                    Literal literal = (Literal)e.Item.FindControl("Literal1");
                    Response.Redirect("AddGuest.aspx?idGuestMaster=" + UtilityFunction.Encrypt(Convert.ToString(literal.Text)));
                }
            }
        }

        protected void rptGuestDetailTbl_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                         e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = e.Item.FindControl("Button1") as Button;
                string submitdate = Request.QueryString["submitdate"];
                submitdate = UtilityFunction.Decrypt(submitdate);
                if (Convert.ToDateTime(submitdate) <= DateTime.Now.AddDays(-2))
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}