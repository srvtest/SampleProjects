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
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace Guest_Reporting_System
{
    public partial class ReportGuestDetail : System.Web.UI.Page
    {
        private string CheckinDate
        {
            get
            {              
                return (string)HttpContext.Current.Session["CheckinDate"];
            }
            set
            {
               HttpContext.Current.Session["CheckinDate"] = value;
            }
        }
        //string CheckinDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnHost.Value = ConfigurationManager.AppSettings["Host"].ToString();
                hdnToEmailId.Value = ConfigurationManager.AppSettings["FromMail"].ToString();
                hdnPassword.Value = ConfigurationManager.AppSettings["Password"].ToString();
                hdnCon.Value= ConfigurationManager.ConnectionStrings["CnnString_Hotel"].ToString();
                string fromDate = string.Empty;
                string toDate = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["para"]))
                {
                    String[] spearator = { "$$" };
                    Int32 count = 2;
                    // using the method 
                    String[] strlist = UtilityFunction.Decrypt(Convert.ToString(Request.QueryString["Para"])).Split(spearator, count,
                           StringSplitOptions.RemoveEmptyEntries);

                    fromDate = strlist[0];
                    toDate = strlist[1];
                    LoadData(fromDate, toDate);
                    lblHotelName.InnerText = (string)(Session["snsHotelName"]).ToString().ToUpper();
                    lblHotelContact.InnerText = "Phone Number : " + Convert.ToString(Session["snsHotelContact"]);
                    lblHotelAddress.InnerText = "Address : " + (string)(Session["snsHotelAddress"]).ToString().ToUpper();
                    hdnDoc.Value = "ReportGuestDetail_"+ lblHotelName.InnerText +"_" + CheckinDate;
                    hdnCheckInDate.Value = CheckinDate;                   
                }
            }
        }

       


        private void LoadData(string fromDate, string toDate)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
            guestFilterDto.FilterFromDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            guestFilterDto.FilterToDate = Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");
            hdnHotelId.Value = Convert.ToString(Session["snsHotelId"]);
            lblCheckIndate.InnerText = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            CheckinDate = Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
            ResponseDto obj = objuserDL.GetGuestCompleteDetailForReport(guestFilterDto,false);

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
                            userDto[i].ContactNo = userDto[i].ContactNo == "" ? "NA" : userDto[i].ContactNo;
                        }
                        lblTotalGuest.InnerText = Convert.ToString(userDto.Sum(x => x.AddionalGuest)) + " (" + userDto.Where(x => x.gender == "पुरुष").Count() + " पुरुष, " + userDto.Where(x => x.gender == "महिला").Count() + " महिला)"; 
                        lblReportBy.InnerText = (userDto.Count > 0 ? userDto[0].SubmitBy : "") + " (" +userDto[0].CreatedDate.ToString("dd-MMM-yyyy hh:mm:ss tt") + ")";
                        //CheckinDate = userDto[0].sDocName;
                        hdnTotalGuest.Value = Convert.ToString(userDto.Sum(x => x.AddionalGuest));
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
            if (e.Item.ItemType == ListItemType.Item ||
                           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeater = e.Item.FindControl("rptDetail") as Repeater;
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                HiddenField hdn = e.Item.FindControl("HiddenField1") as HiddenField;
                //var dataItem = (YourDataType)e.Item.DataItem;
                HtmlControl itemDiv = (HtmlControl)e.Item.FindControl("itemDiv_" + e.Item.ItemIndex);
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

                    string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image1, strFolderTemp + strFilePath1, guestMasterDto.filePass);
                    Image image1 = e.Item.FindControl("Image1") as Image;
                    image1.ImageUrl = filePathUrlTemp + strFilePath1;
                    //Label1.Text += filePathUrlTemp + strFilePath1;

                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestMasterDto.Image2, strFolderTemp + strFilePath2, guestMasterDto.filePass);
                    Image image2 = e.Item.FindControl("Image2") as Image;
                    image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    //Label1.Text += filePathUrlTemp + strFilePath1;

                    if (guestDetailDtos != null)
                    {
                        repeater.DataSource = guestDetailDtos;
                        repeater.DataBind();
                    }
                }
                //if (itemDiv != null)
                //{
                //    itemDiv.Attributes["style"] = "color: red;";
                //}
                //if ((Convert.ToInt32(hdn.Value)-1) > 0)
                //{
                //    itemDiv.Visible = false;
                //}
            }
        }

        protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIdGuestDetail") as HiddenField;

                List<GuestDetailDto> guestDetailDtos = (List<GuestDetailDto>)((Repeater)sender).DataSource;
                if (guestDetailDtos != null && guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).Count() > 0)
                {
                    GuestDetailDto guestDetailDtosData = guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).FirstOrDefault();


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
                    UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image, strFolderTemp + strFilePath1, guestDetailDtosData.filePass);
                    Image image1 = e.Item.FindControl("Image1") as Image;
                    image1.ImageUrl = filePathUrlTemp + strFilePath1;
                    //Label1.Text += filePathUrlTemp + strFilePath1;

                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image2, strFolderTemp + strFilePath2, guestDetailDtosData.filePass);
                    Image image2 = e.Item.FindControl("Image2") as Image;
                    image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    //Lbel1.Text += filePathUrlTemp + strFilePath2;
                }
            }
        }
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
    }
}