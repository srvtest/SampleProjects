using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Guest_Reporting_System
{
    public partial class AddGuest : System.Web.UI.Page
    {
        #region Variable Declaration
        private static string _EncryptionKey;
        public static string EncryptionKey
        {
            get
            {
                if (_EncryptionKey == null || _EncryptionKey == string.Empty)
                {
                    _EncryptionKey = "H0t3l!Gu35t";
                }
                return _EncryptionKey;
            }
        }
        List<GuestMasterDto> userDto = new List<GuestMasterDto>();
        string filepassup = string.Empty;
        private List<GuestDetailDto> GuestDetails
        {
            get
            {
                if (ViewState["GuestDetails"] == null)
                {
                    ViewState["GuestDetails"] = new List<GuestDetailDto>();
                }
                return (List<GuestDetailDto>)ViewState["GuestDetails"];
            }
            set
            {
                ViewState["GuestDetails"] = value;
            }
        }
        private List<GuestRoomDto> GuestRoomDetails
        {
            get
            {
                if (ViewState["GuestRoomDto"] == null)
                {
                    ViewState["GuestRoomDto"] = new List<GuestDetailDto>();
                }
                return (List<GuestRoomDto>)ViewState["GuestRoomDto"];
            }
            set
            {
                ViewState["GuestRoomDto"] = value;
            }
        }
        private int snsHotelId
        {
            get
            {
                if (Session["snsHotelId"] == null)
                {
                    Session["snsHotelId"] = 0;
                }
                return (int)Session["snsHotelId"];
            }
            set
            {
                Session["snsHotelId"] = value;
            }
        }
        //private string sFPassword
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sFPassword"];
        //    }
        //    set
        //    {
        //        Session["sFPassword"] = value;
        //    }
        //}
        //private string sFruntFileName
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sFruntFileName"];
        //    }
        //    set
        //    {
        //        Session["sFruntFileName"] = value;
        //    }
        //}
        //private string sBackFileName
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sBackFileName"];
        //    }
        //    set
        //    {
        //        Session["sBackFileName"] = value;
        //    }
        //}
        //private string sPassword
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sPassword"];
        //    }
        //    set
        //    {
        //        Session["sPassword"] = value;
        //    }
        //}
        //private string sFileName
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sFileName"];
        //    }
        //    set
        //    {
        //        Session["sFileName"] = value;
        //    }
        //}
        //private string sFileNameBack
        //{
        //    get
        //    {
        //        //if (Session["snsHotelId"] == null)
        //        //{
        //        //    Session["snsHotelId"] = 0;
        //        //}
        //        return (string)Session["sFileNameBack"];
        //    }
        //    set
        //    {
        //        Session["sFileNameBack"] = value;
        //    }
        //}
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GuestMasterDL objGuestMasterDL = new GuestMasterDL();
                ResponseDto response = objGuestMasterDL.ValidateSubmitDate(snsHotelId, DateTime.Now.AddDays(-1).Date);
                if (response != null)
                {
                    int count = (int)response.Result;
                    if (count == 0)
                        ddlCheckIn.Items.Add(new ListItem { Text = "Yesterday (" + DateTime.Now.AddDays(-1).Date.ToString("dd-MMM-yyyy") + ")", Value = "Yesterday" });
                    else
                        ddlCheckIn.Items.Add(new ListItem { Text = "Yesterday (" + DateTime.Now.AddDays(-1).Date.ToString("dd-MMM-yyyy") + ") रिपोर्ट सबमिट हो चुकी है।", Value = "Yesterday" });
                }
                response = objGuestMasterDL.ValidateSubmitDate(snsHotelId, DateTime.Now.Date);
                if (response != null)
                {
                    int count = (int)response.Result;
                    if (count == 0)
                        ddlCheckIn.Items.Add(new ListItem { Text = "Today (" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + ")", Value = "Today" });
                    else
                        ddlCheckIn.Items.Add(new ListItem { Text = "Today (" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + ") रिपोर्ट सबमिट हो चुकी है।", Value = "Today" });

                }
                //txtCheckOutDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                txtCheckOutDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                List<GuestRoomDto> lstGuestRoom = null;
                if (!string.IsNullOrEmpty(Request.QueryString["idGuestMaster"]))
                {
                    string idGuestMaster = Request.QueryString["idGuestMaster"];
                    idGuestMaster = UtilityFunction.Decrypt(idGuestMaster);
                    lstGuestRoom = LoadData(idGuestMaster);
                    //UploadDoc.Visible = true;
                    if (rptGuest.Items.Count > 0)
                    {
                        //rptGuest.FindControl("filetypeload").Visible = false;
                    }
                }
                //if (lstGuestRoom != null)
                //{
                BindCategory(lstGuestRoom);
                //}
                //else
                //{
                //    lblMessage2.InnerText = "सबसे पहले कमरे की श्रेणी जोड़ें";
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SaveGuestData1();", true);
                //}   
                bool isSelect = false;
                foreach (ListItem item in ddlCheckIn.Items)
                {
                    if (item.Text.Contains("रिपोर्ट सबमिट"))
                    {
                        item.Attributes.Add("disabled", "disabled");
                        AllControlDisable();
                    }
                    else if (!isSelect)
                    {
                        isSelect = true;
                        item.Selected = true;
                        AllControlEnable();
                    }
                    //else
                    //{
                    //    item.Selected = false;
                    //}
                }
            }
            //LoadFileUpload();
            //var pmyFileUploadFrunt = hdnPryFront.Value;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "setFilecontrolValue();", true);
        }
        public void BindCategory(List<GuestRoomDto> lstGuestRoom)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            ResponseDto response = objHotelDL.GetHotelCategory(snsHotelId);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    List<HotelCategoryDto> lst = (List<HotelCategoryDto>)response.Result;
                    if (lstGuestRoom != null)
                    {
                        foreach (var item in lstGuestRoom)
                        {
                            (from u in lst where u.idHotelRoomCategory == item.idHotelRoomCategory select u).ToList()
                            .ForEach(u => u.bChecked = true);
                        }
                    }
                    if (lst.Count != 0)
                    {
                        rptCategory.DataSource = lst;
                        rptCategory.DataBind();
                    }
                    //else
                    //{
                    //    lblMessage2.InnerText = "सबसे पहले कमरे की श्रेणी जोड़ें";
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SaveGuestData1();", true);
                    //}
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }

        }
        private List<GuestRoomDto> LoadData(string idGuestMaster)
        {
            List<GuestRoomDto> lstGuestRoom = null;
            GuestMasterDL objGuestMasterDL = new GuestMasterDL();
            ResponseDto response = objGuestMasterDL.GetGuestCompleteDetailByGuestId(idGuestMaster, false);
            if (response != null)
            {
                userDto = (List<GuestMasterDto>)response.Result;
                if (userDto != null)
                {
                    if (userDto[0].GuestRoomXml != null)
                    {
                        lstGuestRoom = userDto[0].GuestRoomXml.FromXML<GuestMasterDto>().GuestRoomDetails;
                    }
                    //ShowUserPanal(true);
                    txtContactNo.Text = userDto[0].ContactNo;
                    txtCheckOutDate.Text = Convert.ToDateTime(userDto[0].CheckOutDate).ToString("dd-MMM-yyyy");
                    //txtCheckInDate.Text = Convert.ToDateTime(userDto[0].CheckInDate).ToString("dd-MMM-yyyy");
                    txtFirstName.Text = userDto[0].GuestName;
                    //txtGuestLastName.Text = userDto[0].GuestLastName;
                    txtIdentificationNo.Text = userDto[0].IdentificationNo;
                    ddlIDType.Text = userDto[0].IdentificationType;
                    //txtAddress.Text = userDto[0].Address;
                    hdGuestMasterId.Value = Convert.ToString(userDto[0].idGuestMaster);
                    ddlAddGustCnt.SelectedValue = Convert.ToString(userDto[0].AddionalGuest);
                    //ddlAddGustCnt.Attributes.Add("disabled", "disabled");
                    txtCity.Text = userDto[0].city;
                    //txtPinCode.Text = userDto[0].PIncode;
                    hdnPassword.Value = userDto[0].filePass;
                    if (userDto[0].Details != null)
                    {
                        foreach (var item in userDto[0].Details)
                        {
                            item.ContactNo = item.ContactNo.Decrypt(EncryptionKey, true);
                            item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                        }
                    }
                    GuestDetails = userDto[0].Details;
                    // GuestRoomDetails = userDto[0].GuestRoomDetails;
                    TxtNoofGuest_TextChanged(null, null);
                    //foreach (var item in userDto[0].Details)
                    //{
                    //    item.ContactNo = item.ContactNo.Decrypt(EncryptionKey, true);
                    //    item.IdentificationNo = item.IdentificationNo.Decrypt(EncryptionKey, true);
                    //}
                    string strFolder;
                    strFolder = Server.MapPath("./GuestFiles/");
                    // Create the directory if it does not exist.
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }
                    //hdnPassword.Value = userDto[0].filePass;
                    hdnsFruntFileName.Value = userDto[0].Image1;
                    hdnsBackFileName.Value = userDto[0].Image2;
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
                    UtilityFunction.DecryptFile(strFolder + hdnsFruntFileName.Value, strFolderTemp + strFilePath1, hdnPassword.Value);
                    Image1.ImageUrl = filePathUrlTemp + strFilePath1;

                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                    UtilityFunction.DecryptFile(strFolder + hdnsBackFileName.Value, strFolderTemp + strFilePath2, hdnPassword.Value);
                    Image2.ImageUrl = filePathUrlTemp + strFilePath2;
                    RequiredFieldValidator5.Visible = false;
                    RequiredFieldValidator2.Visible = false;
                }
            }
            return lstGuestRoom;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ShowUserPanal(false);
            Response.Redirect("GuestList.aspx");
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            //ShowUserPanal(true);
            lbl4.Text = "Add Guest Master";
        }
        protected void TxtNoofGuest_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(hdGuestMasterId.Value) == 0)
            {
                GuestDetails = new List<GuestDetailDto>();
                if (Convert.ToInt32(ddlAddGustCnt.Text) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(ddlAddGustCnt.Text); i++)
                    {
                        if (GuestDetails.Count < (i + 1))
                        {
                            GuestDetails.Add(new GuestDetailDto());
                        }
                    }
                }
            }
            BindGuest();
        }
        public void BindGuest()
        {
            rptGuest.DataSource = GuestDetails.Where(x => x.isDelete == 0).ToList();
            rptGuest.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GuestMasterDL objGuestMasterDL = new GuestMasterDL();
            GuestMasterDto guestMasterDto = new GuestMasterDto();
            guestMasterDto.idHotel = snsHotelId;
            guestMasterDto.GuestName = txtFirstName.Text;
            //guestMasterDto.GuestLastName = txtGuestLastName.Text;
            guestMasterDto.gender = ddlFirstSex.Text;
            guestMasterDto.ContactNo = txtContactNo.Text;
            guestMasterDto.ContactNoTemp = txtContactNo.Text;
            guestMasterDto.TravelReson = ddlTrevelReson.Text;
            //guestMasterDto.Address = txtAddress.Text;
            guestMasterDto.city = txtCity.Text;
            //guestMasterDto.PIncode = txtPinCode.Text;
            guestMasterDto.IdentificationType = ddlIDType.Text;
            guestMasterDto.IdentificationNo = txtIdentificationNo.Text;
            guestMasterDto.IdentificationNoTemp = txtIdentificationNo.Text;
            string sFPassword;
            if (string.IsNullOrEmpty(hdnPassword.Value))
            {
                sFPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
            }
            else
            {
                sFPassword = hdnPassword.Value;
            }
            string sFruntFileName = "";
            string sBackFileName = "";
            //if (RequiredFieldValidator5.Visible == true && RequiredFieldValidator2.Visible == true)
            //{
            //    sFruntFileName = UploadImage(FileUploadFrunt, sFPassword);
            //    sBackFileName = UploadImage(FileUploadBack, sFPassword);
            //}
            if (FileUploadFrunt.FileName != "")
            {
                sFruntFileName = UploadImage(FileUploadFrunt, sFPassword);
            }
            else
            {
                sFruntFileName = hdnsFruntFileName.Value;
            }
            if (FileUploadBack.FileName != "")
            {
                sBackFileName = UploadImage(FileUploadBack, sFPassword);
            }
            else
            {
                sBackFileName = hdnsBackFileName.Value;
            }
            guestMasterDto.Image1 = sFruntFileName;
            guestMasterDto.Image2 = sBackFileName;
            guestMasterDto.filePass = sFPassword;
            //string dt = txtCheckOutDate.Text.Substring(3, 2) + "/" + txtCheckOutDate.Text.Substring(0, 2) + "/" + txtCheckOutDate.Text.Substring(6, 4);
            guestMasterDto.CheckOutDate = Convert.ToDateTime(txtCheckOutDate.Text).ToString("dd-MMM-yyyy");
            if (ddlCheckIn.Text == "Yesterday")
                guestMasterDto.CheckInDate = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            else
                guestMasterDto.CheckInDate = DateTime.Now.ToShortDateString();

            if (string.IsNullOrEmpty(ddlAddGustCnt.Text))
                ddlAddGustCnt.Text = "0";
            guestMasterDto.AddionalGuest = Convert.ToInt32(ddlAddGustCnt.Text);
            if (!string.IsNullOrEmpty(hdGuestMasterId.Value))
            {
                guestMasterDto.idGuestMaster = Convert.ToInt32(hdGuestMasterId.Value);
            }
            guestMasterDto.Details = new List<GuestDetailDto>();
            foreach (RepeaterItem item in rptGuest.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBox txtGName = (TextBox)item.FindControl("txtSecGuestFirstName");
                    TextBox txtContactNumber = (TextBox)item.FindControl("txtContactNumber");
                    TextBox txtGNameLast = (TextBox)item.FindControl("txtSecGuestLastName");
                    DropDownList txtidType = (DropDownList)item.FindControl("ddlSecGuestIDType");
                    TextBox txtId = (TextBox)item.FindControl("txtSecGuestIdentificationNo");
                    DropDownList ddlGender = (DropDownList)item.FindControl("ddlSecGuestFirstSex");
                    HiddenField hdnGuestPassword = (HiddenField)item.FindControl("hdnGuestPassword");
                    HiddenField hdnIdGuestDetail = (HiddenField)item.FindControl("hdnIdGuestDetail");
                    HiddenField hdnsFileName = (HiddenField)item.FindControl("hdnsFileName");
                    HiddenField hdnsFileNameBack = (HiddenField)item.FindControl("hdnsFileNameBack");
                    string sPassword;
                    if (string.IsNullOrEmpty(hdnGuestPassword.Value))
                    {
                        sPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
                    }
                    else
                    {
                        sPassword = hdnGuestPassword.Value;
                    }
                    FileUpload fileUpload = (FileUpload)item.FindControl("FileSecGuestUpload1");
                    //Control div1 = item.FindControl("filetypeload");
                    string sFileName = "";
                    string sFileNameBack = "";
                    FileUpload fileUploadBack = (FileUpload)item.FindControl("FileSecGuestUpload2");
                    //if (div1.Visible)
                    //{
                    if (fileUpload.FileName != "")
                    {
                        sFileName = UploadImage(fileUpload, sPassword);
                    }
                    else
                    {
                        sFileName = hdnsFileName.Value;
                    }

                    if (fileUploadBack.FileName != "")
                    {
                        sFileNameBack = UploadImage(fileUploadBack, sPassword);
                    }
                    else
                    {
                        sFileNameBack = hdnsFileNameBack.Value;
                    }
                    //}
                    //guestMasterDto.Details.Add(new GuestDetailDto { idGuestDetail = Convert.ToInt32(hdnIdGuestDetail.Value), IdentificationNo = txtId.Text, IdentificationType = txtidType.Text, sName = txtGName.Text, Image = sFileName, gender = ddlGender.SelectedValue, filePass = sPassword, Image2 = sFileNameBack, LastName = txtGNameLast.Text, ContactNo = txtContactNumber.Text, ContactNoTemp = txtContactNumber.Text, IdentificationNoTemp = txtId.Text });
                    //guestMasterDto.Details.Add(new GuestDetailDto { idGuestDetail = Convert.ToInt32(hdnIdGuestDetail.Value), IdentificationNo = txtId.Text, IdentificationType = txtidType.Text, sName = "With " + txtFirstName.Text, Image = sFileName, gender = ddlGender.SelectedValue, filePass = sPassword, Image2 = sFileNameBack, ContactNo = txtContactNo.Text, ContactNoTemp = txtContactNumber.Text, IdentificationNoTemp = txtId.Text });
                    guestMasterDto.Details.Add(new GuestDetailDto { idGuestDetail = Convert.ToInt32(hdnIdGuestDetail.Value), IdentificationNo = txtId.Text, IdentificationType = txtidType.Text, sName = txtGName.Text, Image = sFileName, gender = ddlGender.SelectedValue, filePass = sPassword, Image2 = sFileNameBack, ContactNo = txtContactNo.Text, ContactNoTemp = txtContactNumber.Text, IdentificationNoTemp = txtId.Text });
                }
            }

            guestMasterDto.Categories = new List<HotelCategoryDto>();
            string sCategory = "", sPrice = "";
            foreach (RepeaterItem item in rptCategory.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnidHotelRoomCategory = (HiddenField)item.FindControl("hdnidHotelRoomCategory");
                    HiddenField hdnCategoryName = (HiddenField)item.FindControl("hdnCategoryName");
                    HiddenField hdniPrice = (HiddenField)item.FindControl("hdniPrice");
                    CheckBox chk = (CheckBox)item.FindControl("ChkSelect");
                    if (chk.Checked)
                    {
                        sCategory += (string.IsNullOrEmpty(sCategory) ? "" : " And ") + hdnCategoryName.Value;
                        sPrice += (string.IsNullOrEmpty(sPrice) ? "" : " And ") + hdniPrice.Value;
                        guestMasterDto.Categories.Add(new HotelCategoryDto { idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory.Value), idHotel = snsHotelId, iPrice = Convert.ToInt32(hdniPrice.Value) });
                    }
                }
            }
            if (!ValidateRequestData(guestMasterDto))
            {
                Spnerror.InnerText = "कृपया प्राइमरी और अन्य अतिथि के लिए अलग अलग आईडी नंबर दर्ज करे।";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyKey", "ShowError()", true);
                return;
            }
            ResponseDto response = objGuestMasterDL.InsertUpdateDeleteGuestMaster(guestMasterDto, false);
            if (response != null)
            {
                string sSMS = "Dear Guest, For Your stay in " + Convert.ToString(Session["snsHotelName"]) + " Room Category: " + (string.IsNullOrEmpty(sCategory) ? "NA" : sCategory) + " Approved Rate is: " + (string.IsNullOrEmpty(sPrice) ? "NA" : sPrice) + " For any issue during your stay Please contact on below number " + Session["snspoliceContact"] + " Thanks, Fanatical Technologies";
                if (response.StatusCode == 0)
                {
                    //LoadGridData();
                    UtilityFunction.SendSMS(sSMS, txtContactNo.Text, ConfigurationManager.AppSettings["TemplateIdGuestSMS"].ToString());
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SaveGuestData();", true);
                }
                else if (response.StatusCode == 1)
                {
                    UtilityFunction.SendSMS(sSMS, txtContactNo.Text, ConfigurationManager.AppSettings["TemplateIdGuestSMS"].ToString());
                    ResponseDto response1 = objGuestMasterDL.GetPoliceStationNoBySurveillanceNo(txtContactNo.Text);
                    if (response1 != null)
                    {
                        List<GuestMasterDto> userDto1 = (List<GuestMasterDto>)response1.Result;
                        if (userDto1 != null)
                        {
                            string policeSMS = "Namaskar Aapne Jo detail monitoring ke liye portal pe Dali thi Us ki Entry abhi Hotel me hui hai. Adhik Jankari ke liye aap samprk kare " + Convert.ToString(Session["snsHotelContact"]) + " Team Fanatical Technologies";
                            UtilityFunction.SendSMS(policeSMS, userDto1[0].PoliceStationNo, ConfigurationManager.AppSettings["TemplateIdPoliceAlert"].ToString());
                        }
                    } 
                    lblMessage.InnerHtml = "<b><center>महत्वपूर्ण सूचना</center><br><i class=\"fa fa-exclamation-triangle fa-2x\"></i>" + response.Message + "</b><br>";
                    Span1.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SaveGuestData();", true);
                }
                else if (response.StatusCode == -1 || response.StatusCode == -2 || response.StatusCode == -3)
                {
                    Span2.InnerHtml = response.Message;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "MessageShow();", true);
                }
                else
                {
                    //hdMessage.Value = "Add Guest |" + response.Message;
                    // lblMessage.InnerHtml = response.Message;
                    //Span1.Visible = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyKey", "Errormsg()", true);
                }
            }
        }
        private bool ValidateRequestData(GuestMasterDto guestMasterDto)
        {
            List<string> lst = new List<string>();
            //return true;
            //lst.Add(guestMasterDto.ContactNo);
            //foreach (var item in guestMasterDto.Details)
            //    if (lst.Contains(item.ContactNo))
            //        return false;
            //    else
            //    {
            //        lst.Add(item.ContactNo);
            //    }
            //return true;
            lst.Add(guestMasterDto.IdentificationNo);
            foreach (var item in guestMasterDto.Details)
                if (lst.Contains(item.IdentificationNo))
                    return false;
                else
                {
                    lst.Add(item.IdentificationNo);
                }
            return true;
        }
        public string UploadImage(FileUpload oFile, string Password)
        {

            string strFileName;
            string strFilePath = string.Empty;
            string strFolder;
            strFolder = Server.MapPath("./GuestFiles/");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            strFileName = Guid.NewGuid().ToString() + "_" + strFileName;
            string FileName = strFileName;
            strFileName = "Temp_" + strFileName;
            if (!string.IsNullOrEmpty(strFileName))
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    //hdMessage.Value = "Add Guest |" + strFileName + " already exists on the server!";
                    // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);

                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);
                    UtilityFunction.EncryptFile(strFilePath, strFilePath.Replace("Temp_", ""), Password);
                    File.Delete(strFilePath);
                    //hdMessage.Value = "Add Guest |" + strFileName + " has been successfully uploaded.";
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);

                }
            }
            else
            {
                //hdMessage.Value = "Add Guest |" + "Click 'Browse' to select the file to upload.";
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            // Display the result of the upload.
            //frmConfirmation.Visible = true;
            return FileName;
        }
        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlGender");
            // ddl.SelectedValue= GuestDetails.ToList
        }
        protected void rptGuest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (Convert.ToInt32(hdGuestMasterId.Value) > 0)
                {
                    HiddenField hdnId = e.Item.FindControl("hdnIdGuestDetail") as HiddenField;
                    RequiredFieldValidator rd1 = e.Item.FindControl("RequiredFieldValidator5") as RequiredFieldValidator;
                    RequiredFieldValidator rd2 = e.Item.FindControl("RequiredFieldValidator7") as RequiredFieldValidator;

                    List<GuestDetailDto> guestDetailDtos = (List<GuestDetailDto>)((Repeater)sender).DataSource;
                    if (guestDetailDtos != null && guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).Count() > 0)
                    {
                        GuestDetailDto guestDetailDtosData = guestDetailDtos.Where(x => x.idGuestDetail == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                        //
                        //
                        //    Control div1 = e.Item.FindControl("filetypeload");
                        //    //e.Item.Controls[0]("filetypeload").
                        //    div1.Visible = true;
                        //}
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
                        if (guestDetailDtosData.filePass != null)
                        {
                            string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
                            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image, strFolderTemp + strFilePath1, guestDetailDtosData.filePass);
                            Image image1 = e.Item.FindControl("Image3") as Image;
                            image1.ImageUrl = filePathUrlTemp + strFilePath1;

                            string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
                            UtilityFunction.DecryptFile(strFolder + guestDetailDtosData.Image2, strFolderTemp + strFilePath2, guestDetailDtosData.filePass);
                            Image image2 = e.Item.FindControl("Image4") as Image;
                            image2.ImageUrl = filePathUrlTemp + strFilePath2;
                            rd1.Visible = false;
                            rd2.Visible = false;
                        }
                    }
                }
            }
            //btnSubmit_Click(null, null);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtCheckOutDate.Attributes.Add("readonly", "readonly");
            
            if (Convert.ToInt32(hdGuestMasterId.Value) == 0)
            {
                GuestDetails = new List<GuestDetailDto>();
                if (Convert.ToInt32(ddlAddGustCnt.Text) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(ddlAddGustCnt.Text) - 1; i++)
                    {
                        if (GuestDetails.Count < (i + 1))
                        {
                            GuestDetails.Add(new GuestDetailDto());
                            //GuestDetails[i].sName = "With " + txtFirstName.Text;
                            //GuestDetails[i].LastName = txtGuestLastName.Text;
                            GuestDetails[i].ContactNo = txtContactNo.Text;
                        }
                    }
                }
            }
            else if (Convert.ToInt32(hdGuestMasterId.Value) > 0)
            {
                //GuestDetails = new List<GuestDetailDto>();
                if (Convert.ToInt32(ddlAddGustCnt.Text) > 0)
                {
                    if (Convert.ToInt32(ddlAddGustCnt.Text) - 1 > GuestDetails.Count())
                    {
                        for (int i = 0; i < Convert.ToInt32(ddlAddGustCnt.Text) - 1; i++)
                        {
                            if (GuestDetails.Count < (i + 1))
                            {
                                GuestDetails.Add(new GuestDetailDto());
                            }
                        }
                    }
                    else if (Convert.ToInt32(ddlAddGustCnt.Text) - 1 < GuestDetails.Count())
                    {
                        for (int i = 0; i < GuestDetails.Count(); i++)
                        {
                            if (Convert.ToInt32(ddlAddGustCnt.Text) - 1 < (i + 1))
                            {
                                GuestDetails[i].isDelete = 1;
                            }
                            else
                            {
                                GuestDetails[i].isDelete = 0;
                            }
                        }
                    }
                }
            }
            //rptGuest.DataSource = GuestDetails.Where(x => x.isDelete == 0).ToList();
            //rptGuest.DataBind();
            BindGuest();
            //txtCheckOutDate.ReadOnly = true;
        }
        protected void ddlCheckIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCheckIn.SelectedValue == "Yesterday")
            {
                txtCheckOutDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                txtCheckOutDate.Text = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
            }
            //LoadFileUpload();
        }
        private void LoadFileUpload()
        {
            if (Session["FileUploadFrunt"] == null && FileUploadFrunt.HasFile)
            {
                Session["FileUploadFrunt"] = FileUploadFrunt;
            }
            // Next time submit and Session has values but FileUpload is Blank
            // Return the values from session to FileUpload
            else if (Session["FileUploadFrunt"] != null && (!FileUploadFrunt.HasFile))
            {
                FileUploadFrunt = (FileUpload)Session["FileUploadFrunt"];
            }
            // Now there could be another sictution when Session has File but user want to change the file
            // In this case we have to change the file in session object
            else if (FileUploadFrunt.HasFile)
            {
                Session["FileUploadFrunt"] = FileUploadFrunt;
            }
        }
        private void AllControlDisable()
        {
            //txtAddress.ReadOnly = true;
            //txtCheckOutDate.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtContactNo.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            //txtGuestLastName.ReadOnly = true;
            txtIdentificationNo.ReadOnly = true;
            //txtPinCode.ReadOnly = true;
            ddlAddGustCnt.Enabled = false;
            // ddlCheckIn.ReadOnly=false;
            ddlFirstSex.Enabled = false;
            ddlIDType.Enabled = false;
            ddlTrevelReson.Enabled = false;
            FileUploadFrunt.Enabled = false;
            FileUploadBack.Enabled = false;
            btnSubmit.Enabled = false;
            Button1.Enabled = false;
        }
        private void AllControlEnable()
        {
            //txtAddress.ReadOnly = false;
            //txtCheckOutDate.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtContactNo.ReadOnly = false;
            txtFirstName.ReadOnly = false;
            //txtGuestLastName.ReadOnly = false;
            txtIdentificationNo.ReadOnly = false;
            //txtPinCode.ReadOnly = false;
            ddlAddGustCnt.Enabled = true;
            //ddlCheckIn.ReadOnly = true;
            ddlFirstSex.Enabled = true;
            ddlIDType.Enabled = true;
            ddlTrevelReson.Enabled = true;
            FileUploadFrunt.Enabled = true;
            FileUploadBack.Enabled = true;
            btnSubmit.Enabled = true;
            Button1.Enabled = true;
        }
        protected void cvvalidate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //e.IsValid = ChkSelect.Checked;
        }
        //protected void btnUpload_Click(object sender, EventArgs e)
        //{            
        //    if (FileUploadFrunt.HasFile || FileUploadBack.HasFile)
        //    {
        //        string sFPasswordU;               
        //        string sFruntFileNameU = "";
        //        string sBackFileNameU = "";
        //        if (string.IsNullOrEmpty(hdnPassword.Value))
        //        {
        //            sFPasswordU = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
        //        }
        //        else
        //        {
        //            sFPasswordU = hdnPassword.Value;
        //        }

        //        //if (RequiredFieldValidator5.Visible == true && RequiredFieldValidator2.Visible == true)
        //        //{
        //        //    sFruntFileName = UploadImage(FileUploadFrunt, sFPassword);
        //        //    sBackFileName = UploadImage(FileUploadBack, sFPassword);
        //        //}
        //        if (FileUploadFrunt.FileName != "")
        //        {
        //            sFruntFileNameU = UploadImage(FileUploadFrunt, sFPasswordU);
        //        }
        //        else
        //        {
        //            sFruntFileNameU = hdnsFruntFileName.Value;
        //        }
        //        if (FileUploadBack.FileName != "")
        //        {
        //            sBackFileNameU = UploadImage(FileUploadBack, sFPasswordU);
        //        }
        //        else
        //        {
        //            sBackFileNameU = hdnsBackFileName.Value;
        //        }
        //        hdnPassword.Value = sFPasswordU;
        //        hdnsFruntFileName.Value = sFruntFileNameU;
        //        hdnsBackFileName.Value = sBackFileNameU;

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
        //        UtilityFunction.DecryptFile(strFolder + sFruntFileNameU, strFolderTemp + strFilePath1, sFPasswordU);
        //        Image1.ImageUrl = filePathUrlTemp + strFilePath1;

        //        string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
        //        UtilityFunction.DecryptFile(strFolder + sBackFileNameU, strFolderTemp + strFilePath2, sFPasswordU);
        //        Image2.ImageUrl = filePathUrlTemp + strFilePath2;
        //        RequiredFieldValidator5.Visible = false;
        //        RequiredFieldValidator2.Visible = false;
        //        Label4.Visible = true;
        //        Label4.Text = " Image Saved Successfully!";
        //        Label4.ForeColor = System.Drawing.Color.Green;
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SHOWmESSAGEUpload();", true);
        //        //btnUpload.Enabled = false;
        //    }
        //    else
        //    {
        //        Label4.Visible = true;
        //        Label4.Text = " Please Upload The Image.....";
        //        Label4.ForeColor = System.Drawing.Color.Red;
        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SHOWmESSAGEUpload();", true);
        //    }
        //}
        //protected void btnUploadAdd_Click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem item in rptGuest.Items)
        //    {
        //        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            FileUpload fuFront = item.FindControl("FileSecGuestUpload1") as FileUpload;
        //            FileUpload fuBack = item.FindControl("FileSecGuestUpload2") as FileUpload;
        //            RequiredFieldValidator rd1 = item.FindControl("RequiredFieldValidator5") as RequiredFieldValidator;
        //            RequiredFieldValidator rd2 = item.FindControl("RequiredFieldValidator7") as RequiredFieldValidator;
        //            HiddenField hdnGuestPassword = (HiddenField)item.FindControl("hdnGuestPassword");
        //            HiddenField hdnIdGuestDetail = (HiddenField)item.FindControl("hdnIdGuestDetail");
        //            HiddenField hdnsFileName = (HiddenField)item.FindControl("hdnsFileName");
        //            HiddenField hdnsFileNameBack = (HiddenField)item.FindControl("hdnsFileNameBack");
        //            System.Web.UI.WebControls.Label myLabel = (System.Web.UI.WebControls.Label)item.FindControl("Label5");                    
        //            if (hdnIdGuestDetail.Value != null)
        //            {
        //                if (fuFront.HasFile || fuBack.HasFile)
        //                {
        //                    string sPassword;
        //                    if (string.IsNullOrEmpty(hdnGuestPassword.Value))
        //                    {
        //                        sPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
        //                    }
        //                    else
        //                    {
        //                        sPassword = hdnGuestPassword.Value;
        //                    }
        //                    string sFileNameF = "";
        //                    string sFileNameBackF = "";
        //                    //if (RequiredFieldValidator5.Visible == true && RequiredFieldValidator2.Visible == true)
        //                    //{
        //                    //    sFruntFileName = UploadImage(FileUploadFrunt, sFPassword);
        //                    //    sBackFileName = UploadImage(FileUploadBack, sFPassword);
        //                    //}
        //                    if (fuFront.FileName != "")
        //                    {
        //                        sFileNameF = UploadImage(fuFront, sPassword);
        //                    }
        //                    else
        //                    {
        //                        sFileNameF = hdnsFileName.Value;
        //                    }
        //                    if (fuBack.FileName != "")
        //                    {
        //                        sFileNameBackF = UploadImage(fuBack, sPassword);
        //                    }
        //                    else
        //                    {
        //                        sFileNameBackF = hdnsFileNameBack.Value;
        //                    }
        //                    hdnGuestPassword.Value= sPassword;
        //                    hdnsFileName.Value = sFileNameF;
        //                    hdnsFileNameBack.Value = sFileNameBackF;
        //                    string strFolder;
        //                    strFolder = Server.MapPath("./GuestFiles/");
        //                    // Create the directory if it does not exist.
        //                    if (!Directory.Exists(strFolder))
        //                    {
        //                        Directory.CreateDirectory(strFolder);
        //                    }
        //                    string strFolderTemp;
        //                    strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
        //                    // Create the directory if it does not exist.
        //                    if (!Directory.Exists(strFolderTemp))
        //                    {
        //                        Directory.CreateDirectory(strFolderTemp);
        //                    }
        //                    string filePathurl = ConfigurationManager.AppSettings["filePathUrl"].ToString();
        //                    string filePathUrlTemp = ConfigurationManager.AppSettings["filePathUrlTemp"].ToString();

        //                    string strFilePath1 = Guid.NewGuid().ToString() + ".jpg";
        //                    UtilityFunction.DecryptFile(strFolder + sFileNameF, strFolderTemp + strFilePath1, sPassword);
        //                    Image image3 = item.FindControl("Image3") as Image;
        //                    image3.ImageUrl = filePathUrlTemp + strFilePath1;

        //                    string strFilePath2 = Guid.NewGuid().ToString() + ".jpg";
        //                    UtilityFunction.DecryptFile(strFolder + sFileNameBackF, strFolderTemp + strFilePath2, sPassword);
        //                    Image image4 = item.FindControl("Image4") as Image;
        //                    image4.ImageUrl = filePathUrlTemp + strFilePath1;
        //                    //Image2.ImageUrl = filePathUrlTemp + strFilePath2;
        //                    rd1.Visible = false;
        //                    rd2.Visible = false;
        //                    myLabel.Visible = true;
        //                    myLabel.Text = " Image Saved Successfully!";
        //                    myLabel.ForeColor = System.Drawing.Color.Green;
                            
        //                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
        //                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SHOWmESSAGEUpload();", true);
        //                    //btnUpload.Enabled = false;
        //                }
        //                else
        //                {
        //                    myLabel.Visible = true;
        //                    myLabel.Text = " Please Upload The Image.....";
        //                    myLabel.ForeColor = System.Drawing.Color.Red;
        //                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
        //                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SHOWmESSAGEUpload();", true);
        //                }
        //            }
        //        }
        //    }
        //}
    }

}
