using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class GuestDertails : System.Web.UI.Page
    {
        string CheckinDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["idGuestMaster"]))
                {
                    string idGuestMaster = Request.QueryString["idGuestMaster"];
                    idGuestMaster = UtilityFunction.Decrypt(idGuestMaster);
                    LoadData(idGuestMaster);
                    lblHotelName.InnerText = (string)(Session["snsHotelName"]).ToString().ToUpper();
                    lblHotelContact.InnerText = "Phone Number : " + Convert.ToString(Session["snsHotelContact"]);
                    lblHotelAddress.InnerText = "Address : " + (string)(Session["snsHotelAddress"]).ToString().ToUpper();
                    hdnDoc.Value = "SearchGuestReport_" + lblHotelName.InnerText + "_" + CheckinDate;
                }
            }

        }

        private void LoadData(object idGuestMaster)
        {
            GuestMasterDL objGuestMasterDL = new GuestMasterDL();
            ResponseDto response = objGuestMasterDL.GetGuestMasterById(Convert.ToInt16(idGuestMaster));
            if (response != null)
            {
                List<GuestMasterDto> userDto = (List<GuestMasterDto>)response.Result;
                if (userDto != null)
                {
                    for (int i = 0; i < userDto.Count; i++)
                    {
                        userDto[i].IdentificationNo = new string('x', userDto[i].IdentificationNo.Length - 4) + userDto[i].IdentificationNo.Substring(userDto[i].IdentificationNo.Length - 4);
                        userDto[i].ContactNo = userDto[i].ContactNo == "" ? "NA" : userDto[i].ContactNo;
                    }
                    CheckinDate = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
                    lblCheckIndate.InnerText = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
                    lblCheckOutdate.InnerText = Convert.ToDateTime(userDto[0].CheckOutDate).ToString("dd-MMM-yyyy");
                    lblTotalGuest.InnerText = Convert.ToString(userDto.Sum(x => x.AddionalGuest)) + " (" + userDto.Where(x => x.gender == "पुरुष").Count() + " पुरुष, " + userDto.Where(x => x.gender == "महिला").Count() + " महिला)"; ;
                    lblisSumbit.InnerText = userDto[0].isSubmitted ? "हाँ" : "नहीं";
                    rptGuestDetailTbl.DataSource = userDto;
                    rptGuestDetailTbl.DataBind();
                    rptDetail.DataSource = userDto;
                    rptDetail.DataBind();

                }
            }
        }

        protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                          e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                List<GuestMasterDto> userDto = (List<GuestMasterDto>)rptDetail.DataSource;
                // List<GuestDetailDto> guestDetailDtos = (List<GuestDetailDto>)((Repeater)sender).DataSource;
                //if (guestDetailDtos != null && guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).Count() > 0)
                //{
                //    GuestDetailDto guestDetailDtosData = guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
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

                    string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
                    Image image1 = e.Item.FindControl("Image1") as Image;
                    image1.ImageUrl = filePathUrlTemp + strFilePath1;
                    //Label1.Text += filePathUrlTemp + strFilePath1;

                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
                    Image image2 = e.Item.FindControl("Image2") as Image;
                    image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    //Lbel1.Text += filePathUrlTemp + strFilePath2;
                    //if (guestDetailDtos != null)
                    //{
                    //    repeater.DataSource = guestDetailDtos;
                    //    repeater.DataBind();
                    //}
                }
            }
        }
    }
}