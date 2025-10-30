using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Guest_Reporting_System
{
    public partial class HotelRegistration : System.Web.UI.Page
    {
        HotelMasterDL objHotelDL = new HotelMasterDL();
        private string NoOfRoom
        {
            get
            {
                if (ViewState["NoOfRoom"] == null)
                {
                    ViewState["NoOfRoom"] = string.Empty;
                }
                return (string)ViewState["NoOfRoom"];
            }
            set
            {
                ViewState["NoOfRoom"] = value;
            }
        }
        
        private string MobileOTP
        {
            get
            {
                if (ViewState["MobileOTP"] == null)
                {
                    ViewState["MobileOTP"] = string.Empty;
                }
                return (string)ViewState["MobileOTP"];
            }
            set
            {
                ViewState["MobileOTP"] = value;
            }
        }

        private List<HotelCategoryDto> hotelCategoryDtos
        {
            get
            {
                //if (ViewState["hotelCategory"] == null)
                //{
                //    ViewState["hotelCategory"] = new List<HotelCategoryDto>();
                //}
                return (List<HotelCategoryDto>)ViewState["hotelCategory"];
            }
            set
            {
                ViewState["hotelCategory"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadState();
                //===== Add text to stop spammer.
                generateStopSpamText();
                //hdnHotelNewId.Value = "1";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(1)", true);
            }
        }

        private void LoadState()
        {
            DataSet dsState = objHotelDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });
            ddlStateId.SelectedValue = ConfigurationManager.AppSettings["StateConfig"].ToString();
            BindDistrictDropdown(ddlStateId.SelectedValue);
            ddlDistrictId.SelectedValue = "50";
            ddlDistrictId_SelectedIndexChanged(null, null);
            BindCityDropdown(ddlDistrictId.SelectedValue);
            ddlCityId_SelectedIndexChanged(null, null);
            DataSet dsPropertyType = objHotelDL.GetAllPropertyType();
            ddlPropertyType.DataSource = dsPropertyType.Tables[0];
            ddlPropertyType.DataTextField = "sName";
            ddlPropertyType.DataValueField = "Id";
            ddlPropertyType.DataBind();
            ddlPropertyType.Items.Insert(0, new ListItem() { Text = "Select PropertyType", Value = "0" });
        }


        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            CompareValidator1.ValueToCompare = ViewState["spam"].ToString();
            CompareValidator1.Validate();
            if (txtStopSpam.Text == ViewState["spam"].ToString())
            {
                RegistorHotel();
                formloginMobile.Visible = false;
                frmRegData.Visible = false;
                frmCategory.Visible = true;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(3)", true);
                //==== Create new spam protection code.
                generateStopSpamText();
                btnInsertCategory.Enabled = false;
            }
            else
            {
                CustomValidator val = new CustomValidator();
                CompareValidator2.ValidationGroup = "com";
                CompareValidator2.IsValid = false;
                CompareValidator2.CssClass = "valFailure";
                CompareValidator2.ErrorMessage = "You have entered invalid captcha code. Please retry.";
                this.Page.Validators.Add(CompareValidator2);

                //---- Generate new captcha code.
                generateStopSpamText();
            }
        }

        private void RegistorHotel()
        {
            HotelMasterDto hotelDto = new HotelMasterDto();
            hotelDto.HotelName = txtHotelName.Text;
            hotelDto.bActive = true;
            hotelDto.Address = txtAddress.Text;
            hotelDto.Contact = txtMobileno.Text;
            hotelDto.ContactPerson = txtContactPerson.Text;
            hotelDto.ContactPersonMobile = txtContactPersonMobile.Text;
            hotelDto.Website = txtWebsite.Text;
            hotelDto.EmailAddress = txtEmail.Text;
            //hotelDto.PropertyType = Convert.ToInt32(ddlPropertyType.SelectedValue);
            hotelDto.idPoliceStation = Convert.ToInt32(ddlPoliceStation.SelectedValue);
            hotelDto.idState = Convert.ToInt32(ddlStateId.SelectedValue);
            hotelDto.idCity = Convert.ToInt32(ddlCityId.SelectedValue);
            //hotelDto.idZone = Convert.ToInt32(ddlZoneId.SelectedValue);
            hotelDto.ValidUpto = DateTime.Now.AddDays(2);
            string sFPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
            string sFileGumasta = UploadImage(FileGumasta, sFPassword);
            string sFileAdhar = UploadImage(FileAdhar, sFPassword);
            string sFileAdharBack = UploadImage(FileAdharBack, sFPassword);
            hotelDto.FileGumasta = sFileGumasta;
            hotelDto.FileAdhar = sFileAdhar;
            hotelDto.FileAdharBack = sFileAdharBack;
            hotelDto.filePass = sFPassword;
            hotelDto.NoOfRoom = Convert.ToInt32(txtNoOfRoom.Text);
            hotelDto.idDistrict = Convert.ToInt32(ddlDistrictId.SelectedValue);
            hotelDto.PropertyType = Convert.ToInt32(ddlPropertyType.SelectedValue);
            ViewState["PropertyType"] = ddlPropertyType.SelectedItem.Text;
            NoOfRoom = Convert.ToString(txtNoOfRoom.Text);
            hdnHotelName.Value = txtHotelName.Text;
            hdnRMobileNo.Value = txtMobileno.Text;
            hdnNoRoom.Value = txtNoOfRoom.Text;
            ResponseDto response = objHotelDL.InsertUpdateDeleteHotel(hotelDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    int idHotel = Convert.ToInt32(response.Result);
                    hdnHotelNewId.Value = idHotel.ToString();
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }
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
            return strFilePath.Replace("Temp_", "");
        }
        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }

        protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPoliceStationDropdown(ddlCityId.SelectedValue);
        }

        //private void BindZoneDropdown(string selectedValue)
        //{
        //    DataSet dsZone = objHotelDL.GetAllZone(selectedValue);
        //    ddlZoneId.DataSource = dsZone.Tables[0];
        //    ddlZoneId.DataTextField = "sName";
        //    ddlZoneId.DataValueField = "Id";
        //    ddlZoneId.DataBind();
        //    //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        //}
        private void BindCityDropdown(string selectedValue)
        {
            if (string.IsNullOrEmpty(selectedValue))
                return;
            DataSet dsCity = objHotelDL.GetAllCity(selectedValue);
            ddlCityId.DataSource = dsCity.Tables[0];
            ddlCityId.DataTextField = "sName";
            ddlCityId.DataValueField = "CityId";
            ddlCityId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
        }
        private void BindDistrictDropdown(string selectedValue)
        {
            if (string.IsNullOrEmpty(selectedValue))
                return;
            DataSet dsDistrict = objHotelDL.GetAllDistrict(selectedValue);
            ddlDistrictId.DataSource = dsDistrict.Tables[0];
            ddlDistrictId.DataTextField = "sName";
            ddlDistrictId.DataValueField = "Id";
            ddlDistrictId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
        }
        private void BindPoliceStationDropdown(string selectedValue)
        {
            if (string.IsNullOrEmpty(selectedValue))
                return;
            DataSet dsPoliceStation = objHotelDL.GetAllPoliceStation(selectedValue);
            ddlPoliceStation.DataSource = dsPoliceStation.Tables[0];
            ddlPoliceStation.DataTextField = "sName";
            ddlPoliceStation.DataValueField = "Id";
            ddlPoliceStation.DataBind();
            //ddlPoliceStation.Items.Insert(0, new ListItem() { Text = "Select PoliceStation", Value = "0" });
        }

        private void generateStopSpamText()
        {
            Random ran = new Random();
            int firstNumber = ran.Next(1, 9);
            int secondNumber = ran.Next(1, 9);
            ViewState["spam"] = firstNumber + secondNumber;
            lblStopSpam.Text = firstNumber.ToString() + " + " + secondNumber.ToString();
        }

        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("hotelLogin.aspx");
        }

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            spnmsgMob.Visible = false;
            spnmsgOtp.Visible = false;
            spnmsgSuccessMob.Visible = false;
            Random generator = new Random();
            MobileOTP = Convert.ToString(generator.Next(100000, 1000000));
            if (ConfigurationManager.AppSettings["test"].ToString() == "1")
            {
                MobileOTP = "123456";
            }
            HotelMasterDL objLoginDL = new HotelMasterDL();
            hotelCategoryDtos = null;
            int idHotel = 0;
            string sPropertyType = string.Empty;
            ResponseDto response = objLoginDL.ValidateMobileNo(txtVMobileNo.Text, out idHotel, out sPropertyType);
            if (response != null)
            {
                if (response.StatusCode == 0 || response.StatusCode == 1)
                {
                    if (ConfigurationManager.AppSettings["test"].ToString() != "1")
                    {
                        string sSms = "Hello, Your OTP to Login is " + MobileOTP + " Thanks Fanatical Technologies";
                        UtilityFunction.SendSMS(sSms, txtVMobileNo.Text, ConfigurationManager.AppSettings["TemplateIdOtp"].ToString());
                    }
                    spnmsgSuccessMob.Visible = true;
                    spnmsgSuccessMob.InnerText = "OTP send successfully.";
                    btnSendOTP.Visible = false;
                    btnResend.Visible = true;
                    if (response.StatusCode == 1)
                    {
                        hotelCategoryDtos = (List<HotelCategoryDto>)response.Result;
                        BindCategory();
                        hdnHotelNewId.Value = Convert.ToString(idHotel);
                        NoOfRoom = sPropertyType;
                    }

                }
                else
                {
                    spnmsgMob.Visible = true;
                    //spnmsgMob.InnerText = response.Message;
                    spnmsgMob.InnerHtml = "यह मोबाइल नंबर पहले से पंजीकृत है। कृपया पंजीकरण के लिए नया नंबर उपयोग करे , या आप लॉगिन पेज पर जाकर इस नंबर से लॉगिन कर सकते हैं। होटल लॉगिन लिंक - <a href=\"hotelLogin.aspx\"><b style=\"text-decoration-color: #1AA7FF\">होटल लॉगिन</b></a>";
                    MobileOTP = "";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            spnmsgMob.Visible = false;
            spnmsgSuccessMob.Visible = false;
            spnmsgOtp.Visible = false;
            string OTP = txtOTP.Text + txtOTP1.Text + txtOTP2.Text + txtOTP3.Text + txtOTP4.Text + txtOTP5.Text;
            if (MobileOTP == OTP)
            {
                formloginMobile.Visible = false;

                frmRegData.Visible = true;
                if (hotelCategoryDtos != null)
                {
                    frmRegData.Visible = false;
                    frmCategory.Visible = true;
                    BindCategory();
                }
                txtMobileno.Text = txtVMobileNo.Text;
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(2)", true);
            }
            else
            {
                spnmsgOtp.Visible = true;
                spnmsgOtp.InnerText = "OTP is not correct or Expired.";
            }
        }

        protected void ddlDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrictId.SelectedValue);
            ddlCityId_SelectedIndexChanged(null, null);
        }

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            HotelCategoryDto hotelCatDto = new HotelCategoryDto();
            hotelCatDto.CategoryName = txtRoomCategory.Text;
            hotelCatDto.iPrice = Convert.ToInt32(txtRoomPrice.Text);
            hotelCatDto.idHotel = Convert.ToInt32(hdnHotelNewId.Value);
            if (!string.IsNullOrEmpty(hdnidHotelRoomCategory.Value))
            {
                hotelCatDto.idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory.Value);
            }
            if (hotelCategoryDtos == null)
                hotelCategoryDtos = new List<HotelCategoryDto>();
            hotelCategoryDtos.Add(hotelCatDto);
            BindCategory();
        }

        private void BindCategory()
        {
            hdnidHotelRoomCategory.Value = "";
            txtRoomPrice.Text = "";
            txtRoomCategory.Text = "";
            HotelMasterDL objHotelDL = new HotelMasterDL();
            if (hotelCategoryDtos.Count() == 0)
            {
                btnInsertCategory.Enabled = false;
            }
            else
            {
                btnInsertCategory.Enabled = true;
            }
            rptCategory.DataSource = hotelCategoryDtos;
            rptCategory.DataBind();
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            //frmCategory.Visible = false;
            //frmPlan.Visible = true;
            //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(4)", true);
            HotelMasterDL objHotelDL = new HotelMasterDL();
            HotelCategoryDto hotelCatDto = null;
            List<HotelCategoryDto> lstHotelCategoryDto = new List<HotelCategoryDto>();
            foreach (RepeaterItem item in rptCategory.Items)
            {
                hotelCatDto = new HotelCategoryDto();
                hotelCatDto.idHotel = Convert.ToInt32(hdnHotelNewId.Value);
                HiddenField hdnCategoryName = (HiddenField)item.FindControl("hdnCategoryName");
                hotelCatDto.CategoryName = hdnCategoryName.Value;

                HiddenField hdniPrice = (HiddenField)item.FindControl("hdniPrice");
                hotelCatDto.iPrice = !string.IsNullOrEmpty(hdniPrice.Value) ? Convert.ToInt32(hdniPrice.Value) : 0;

                lstHotelCategoryDto.Add(hotelCatDto);
            }

            //hotelCatDto.CategoryName = txtRoomCategory.Text;
            //hotelCatDto.iPrice = Convert.ToInt32(txtRoomPrice.Text);
            //hotelCatDto.idHotel = Convert.ToInt32(hdnHotelNewId.Value);
            //if (!string.IsNullOrEmpty(hdnidHotelRoomCategory.Value))
            //{
            //    hotelCatDto.idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory.Value);
            //}
            ResponseDto response = objHotelDL.InsertHotelCategory(lstHotelCategoryDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    frmCategory.Visible = false;
                    frmPlan.Visible = true;
                    if (Convert.ToInt32(NoOfRoom) <= 10)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel2500Value"].ToString();
                    }
                    else if (Convert.ToInt32(NoOfRoom) <= 35)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel3500Value"].ToString();
                    }
                    else
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel5500Value"].ToString();
                    }
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(4)", true);
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                    //BindCategory();
                    ResponseDto res = objHotelDL.GetHotelById(Convert.ToInt32(hdnHotelNewId.Value));
                    if (res != null)
                    {
                        HotelMasterDto hotelDto = (HotelMasterDto)res.Result;
                        if (hotelDto != null)
                        {
                            lblHotelName.Text = hotelDto.HotelName;
                            lblMobileNo.Text = hotelDto.Contact;
                            lblNoRoom.Text = Convert.ToString(hotelDto.NoOfRoom);
                        }
                    }
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }

        }

        protected void btnInsertCategory_Click(object sender, EventArgs e)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            HotelCategoryDto hotelCatDto = null;
            List<HotelCategoryDto> lstHotelCategoryDto = new List<HotelCategoryDto>();
            foreach (RepeaterItem item in rptCategory.Items)
            {
                hotelCatDto = new HotelCategoryDto();
                hotelCatDto.idHotel = Convert.ToInt32(hdnHotelNewId.Value);
                HiddenField hdnCategoryName = (HiddenField)item.FindControl("hdnCategoryName");
                hotelCatDto.CategoryName = hdnCategoryName.Value;

                HiddenField hdniPrice = (HiddenField)item.FindControl("hdniPrice");
                hotelCatDto.iPrice = !string.IsNullOrEmpty(hdniPrice.Value) ? Convert.ToInt32(hdniPrice.Value) : 0;

                lstHotelCategoryDto.Add(hotelCatDto);
            }

            //hotelCatDto.CategoryName = txtRoomCategory.Text;
            //hotelCatDto.iPrice = Convert.ToInt32(txtRoomPrice.Text);
            //hotelCatDto.idHotel = Convert.ToInt32(hdnHotelNewId.Value);
            //if (!string.IsNullOrEmpty(hdnidHotelRoomCategory.Value))
            //{
            //    hotelCatDto.idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory.Value);
            //}
            ResponseDto response = objHotelDL.InsertHotelCategory(lstHotelCategoryDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    frmCategory.Visible = false;
                    frmPlan.Visible = true;
                    if (Convert.ToInt32(NoOfRoom) <= 10)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel2500Value"].ToString();
                    }
                    else if (Convert.ToInt32(NoOfRoom) <= 35)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel3500Value"].ToString();
                    }
                    else
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel5500Value"].ToString();
                    }
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SetSteps(4)", true);
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                    //BindCategory();
                    ResponseDto res = objHotelDL.GetHotelById(Convert.ToInt32(hdnHotelNewId.Value));
                    if (res != null)
                    {
                        HotelMasterDto hotelDto = (HotelMasterDto)res.Result;
                        if (hotelDto != null)
                        {
                            lblHotelName.Text = hotelDto.HotelName;
                            lblMobileNo.Text = hotelDto.Contact;
                            lblNoRoom.Text = Convert.ToString(hotelDto.NoOfRoom);
                        }
                    }
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }
        }

        protected void btnStandard_Click(object sender, EventArgs e)
        {
            string sURL = string.Empty;

            if (Convert.ToInt32(NoOfRoom) <= 10)
            {
                sURL = ConfigurationManager.AppSettings["propertyTypeAll2500"].ToString();
            }
            else if (Convert.ToInt32(NoOfRoom) <= 35)
            {
                sURL = ConfigurationManager.AppSettings["propertyHotel3500"].ToString();
            }
            else
            {
                sURL = ConfigurationManager.AppSettings["propertyHotel5500"].ToString();
            }
            Response.Redirect(sURL, true);

        }

        protected void btnBasic_Click(object sender, EventArgs e)
        {
            ResponseDto response = objHotelDL.UpdateHotelValidUptoById(Convert.ToInt32(hdnHotelNewId.Value));
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestSub()", true);
                    //Response.Redirect("HotelLogin.aspx", true);
                }
            }


        }


    }
}