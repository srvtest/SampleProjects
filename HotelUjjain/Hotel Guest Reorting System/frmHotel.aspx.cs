using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmHotel : System.Web.UI.Page
    {
        HotelMasterDL objHotelDL = new HotelMasterDL();
        private const string bucketName = "guestreport";
        private const string accessKey = "AKIA3FLD27LK36WSWZLP";
        private const string secretKey = "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";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.APSouth1;
        HotelMasterDto hotelDto;
        List<PoliceStationMasterDto> policeStationMasterDto
        {
            get
            {
                return (List<PoliceStationMasterDto>)Session["policestation"];
            }
            set
            {
                Session["policestation"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Hotel Details";
            lbl2.Text = "Hotel";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.Hotel);
                if (!isAccess)
                    Response.Redirect("dashboard.aspx");
                BindPoliceStationMasterDropdown();
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionAddData();", true);
        }

        public void LoadGridData()
        {
            HotelMasterDL objHotelMasterDL = new HotelMasterDL();
            ResponseDto obj = objHotelMasterDL.GetHotelDetail();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<HotelMasterDto> lstHotelMasterDto = (List<HotelMasterDto>)obj.Result;
                    // BindFilterPoliceStationDropdown(lstHotelMasterDto);                    
                    if (RbNew.Checked)
                    {
                        lstHotelMasterDto = lstHotelMasterDto.Where(x => x.SubscriptionExpireDate == DateTime.MinValue).ToList();
                    }
                    else if (RBExpired.Checked)
                    {
                        DateTime FromDate;
                        DateTime ToDate;
                        FromDate = Convert.ToDateTime(txtFromDate.Text);
                        ToDate = Convert.ToDateTime(txtToDate.Text);
                        lstHotelMasterDto = lstHotelMasterDto.Where(x => x.SubscriptionExpireDate >= FromDate && x.SubscriptionExpireDate <= ToDate).ToList();
                        //if (!string.IsNullOrEmpty(ddlPoliceStationFilter.SelectedItem.Text))
                        //{
                        //    lstHotelMasterDto = lstHotelMasterDto.Where(x => x.PoliceStationName == ddlPoliceStationFilter.SelectedItem.Text).ToList();
                        //}
                    }
                    else if (!string.IsNullOrEmpty(ddlPoliceStationFilter.SelectedItem.Text))
                    {
                        lstHotelMasterDto = lstHotelMasterDto.Where(x => x.idPoliceStationMaster == Convert.ToInt32(ddlPoliceStationFilter.SelectedValue) || ddlPoliceStationFilter.SelectedIndex == 0).ToList();
                    }


                    if (lstHotelMasterDto != null)
                    {
                        RptHotel.DataSource = lstHotelMasterDto;
                        RptHotel.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected async void RptHotel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HotelMasterDL objuserDL = new HotelMasterDL();
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Hotel";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
                int idHotel = Convert.ToInt32(e.CommandArgument);
                ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(idHotel));
                if (response != null)
                {
                    hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        ShowUserPanal(true);
                        txtName.Text = hotelDto.HotelName;
                        txtPassword.Text = (hotelDto.Password);
                        //txtPassword.Text = EncryptionHelper.Decrypt(hotelDto.Password);
                        txtSubscribed.Text = hotelDto.IsSubscribed;

                        chkActive.Checked = hotelDto.Status;
                        // chkSubscribed.Checked = Convert.ToBoolean(hotelDto.IsSubscribed);

                        hdnHotelNewId.Value = Convert.ToString(hotelDto.HotelID);
                        txtAddress.Text = hotelDto.HotelAddress;
                        txtContact.Text = hotelDto.HotelOwnerNumber;
                        txtContactPerson.Text = hotelDto.HotelOwnerName;
                        txtEmail.Text = hotelDto.HotelEmail;
                        txtContactPersonMobile.Text = hotelDto.RegMobileNumber;
                        txtWebsite.Text = hotelDto.HotelWebsite;
                        //hotelDto.FileGumasta = "";
                        //hotelDto.FileAdhar = "";
                        //txtPoliceStation.Text = Convert.ToString(hotelDto.idPoliceStation);
                        ddlStateId.SelectedValue = Convert.ToString(hotelDto.HotelStateId);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrict.SelectedValue = Convert.ToString(hotelDto.idDistrict);
                        BindCityDropdown(ddlDistrict.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(hotelDto.HotelCityid);
                        BindPoliceStationDropdown(ddlCityId.SelectedValue);
                        ddlPoliceStation.SelectedValue = Convert.ToString(hotelDto.HotelPoliceStationId);
                        txtValidUpto.Text = hotelDto.SubscriptionExpireDate.ToString("yyyy-MM-dd");
                        ddlPropertyType.SelectedValue = Convert.ToString(hotelDto.HotelTypeId);
                        txtNoOfRoom.Text = hotelDto.HotelRoomCapacity.ToString();
                        Image1.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelOwnerAdharFrontPath);
                        Image2.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelOwnerAdharBackPath);
                        Image3.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelRegistrationDocPath);

                        BindCategory();
                        EnableDisableControl(true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
                if (hiddenField.Value != null)
                {
                    hdnId.Value = hiddenField.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "Edit Hotel";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
                int idHotel = Convert.ToInt32(e.CommandArgument);
                ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(idHotel));
                if (response != null)
                {
                    hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        ShowUserPanal(true);
                        txtName.Text = hotelDto.HotelName;
                        txtPassword.Text = (hotelDto.Password);
                        //txtPassword.Text = EncryptionHelper.Decrypt(hotelDto.Password);
                        txtSubscribed.Text = hotelDto.IsSubscribed;

                        chkActive.Checked = hotelDto.Status;
                        // chkSubscribed.Checked = Convert.ToBoolean(hotelDto.IsSubscribed);

                        hdnHotelNewId.Value = Convert.ToString(hotelDto.HotelID);
                        txtAddress.Text = hotelDto.HotelAddress;
                        txtContact.Text = hotelDto.HotelOwnerNumber;
                        txtContactPerson.Text = hotelDto.HotelOwnerName;
                        txtEmail.Text = hotelDto.HotelEmail;
                        txtContactPersonMobile.Text = hotelDto.RegMobileNumber;
                        txtWebsite.Text = hotelDto.HotelWebsite;
                        //hotelDto.FileGumasta = "";
                        //hotelDto.FileAdhar = "";
                        // txtPoliceStation.Text = Convert.ToString(hotelDto.idPoliceStation);
                        ddlStateId.SelectedValue = Convert.ToString(hotelDto.HotelStateId);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrict.SelectedValue = Convert.ToString(hotelDto.HotelDistrictId);
                        BindCityDropdown(ddlDistrict.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(hotelDto.HotelCityid);
                        BindPoliceStationDropdown(ddlCityId.SelectedValue);
                        ddlPoliceStation.SelectedValue = Convert.ToString(hotelDto.HotelPoliceStationId);
                        txtValidUpto.Text = hotelDto.SubscriptionExpireDate.ToString("yyyy-MM-dd");
                        ddlPropertyType.SelectedValue = Convert.ToString(hotelDto.HotelTypeId);
                        txtNoOfRoom.Text = hotelDto.HotelRoomCapacity.ToString();
                        Image1.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelOwnerAdharFrontPath);
                        Image2.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelOwnerAdharBackPath);
                        Image3.ImageUrl = GetPresignedUrl(accessKey, secretKey, bucketRegion, bucketName, hotelDto.HotelRegistrationDocPath);
                        BindCategory();
                        EnableDisableControl(false);
                    }
                }
            }
            else if (e.CommandName == "Send")
            {
                string regMobileNumber = "", UserName = "", Password = "", HotelName = "", HotelEmail = "";
                Random generator = new Random();
                string randomPassword = Convert.ToString(generator.Next(100000, 1000000));
                string encryptedPassword = EncryptionHelper.Encrypt(randomPassword);
                //string encryptedPassword = randomPassword;
                lbl4.Text = "Reset Password";
                //BindAllDropdown();
                ///HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objuserDL.ResetHotelPassword(Convert.ToInt32(e.CommandArgument), encryptedPassword);
                if (response != null)
                {
                    //SendRegistrationEmail(requestModel.idPoliceStationMaster, HotelName, HotelEmail, UserName, Password, _SendGrid_API_KEY_ID, _SendGrid_FROM_EMAIL, _SendGri_FROM_NAME, cn);
                    ShowUserPanal(false);
                    EnableDisableControl(false);
                    hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        regMobileNumber = hotelDto.RegMobileNumber;
                        UserName = hotelDto.RegMobileNumber.ToString();
                        Password = EncryptionHelper.Decrypt(hotelDto.Password);
                        HotelName = hotelDto.HotelName.ToString();
                        HotelEmail = hotelDto.HotelEmail.ToString();
                        string Message = "Welcome to GuestReport.in Your login detail as follow - UN -" + UserName + " Pwd -" + Password + " login url -https://guestreport.in/hotellogin Thanks GuestReport.in";
                        ResponseDto response1 = await objuserDL.InsertNotificationLogsAsync(Convert.ToInt32(e.CommandArgument), regMobileNumber, Message);
                        if (response1 != null)
                        {
                        }
                    }
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
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            ddlPropertyType.Enabled = v;
            ddlStateId.Enabled = v;
            ddlDistrict.Enabled = v;
            ddlCityId.Enabled = v;
            ddlPoliceStation.Enabled = v;
            txtName.Enabled = v;
            txtPassword.Enabled = v;
            txtAddress.Enabled = v;
            txtContact.Enabled = v; txtContactPerson.Enabled = v;
            txtEmail.Enabled = v;
            txtValidUpto.Enabled = v;
            txtContactPersonMobile.Enabled = v;
            txtWebsite.Enabled = v;
            txtNoOfRoom.Enabled = v;
            chkActive.Enabled = v;
            txtSubscribed.Enabled = v;

            btnSubmit.Enabled = v;
            btnSaveCategory.Enabled = v;
            txtRoomCategory.Enabled = v;
            txtRoomPrice.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtName.Text = "";
            txtPassword.Text = "";

            chkActive.Checked = false;
            txtSubscribed.Text = "";
            hdnHotelNewId.Value = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtContactPerson.Text = "";
            txtEmail.Text = "";
            ddlDistrict.SelectedIndex = -1;
            ddlCityId.SelectedIndex = -1;
            ddlStateId.SelectedIndex = -1;
            ddlPoliceStation.SelectedIndex = -1;

            DataSet dsState = objHotelDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });

            DataSet dsPropertyType = objHotelDL.GetAllPropertyType();
            ddlPropertyType.DataSource = dsPropertyType.Tables[0];
            ddlPropertyType.DataTextField = "sName";
            ddlPropertyType.DataValueField = "Id";
            ddlPropertyType.DataBind();
            ddlPropertyType.Items.Insert(0, new ListItem() { Text = "Select PropertyType", Value = "0" });
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            lbl4.Text = "Add Hotel";
            EnableDisableControl(true);
        }

        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }

        protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPoliceStationDropdown(ddlCityId.SelectedValue);
        }

        private void BindDistrictDropdown(string selectedValue)
        {
            DataSet dsDistrict = objHotelDL.GetAllDistrict(selectedValue);
            ddlDistrict.DataSource = dsDistrict.Tables[0];
            ddlDistrict.DataTextField = "sName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();
            //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        }
        private void BindCityDropdown(string selectedValue)
        {
            DataSet dsCity = objHotelDL.GetAllCity(selectedValue);
            ddlCityId.DataSource = dsCity.Tables[0];
            ddlCityId.DataTextField = "sName";
            ddlCityId.DataValueField = "CityId";
            ddlCityId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
            BindPoliceStationDropdown(ddlCityId.SelectedValue);
        }
        private void BindPoliceStationDropdown(string selectedValue)
        {
            DataSet dsPoliceStation = objHotelDL.GetAllPoliceStation(selectedValue);
            ddlPoliceStation.DataSource = dsPoliceStation.Tables[0];
            ddlPoliceStation.DataTextField = "sName";
            ddlPoliceStation.DataValueField = "Id";
            ddlPoliceStation.DataBind();
            //ddlPoliceStation.Items.Insert(0, new ListItem() { Text = "Select PoliceStation", Value = "0" });
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrict.SelectedValue);
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
            ResponseDto response = objHotelDL.InsertUpdateHotelCategory(hotelCatDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                    BindCategory();
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }
        }

        public void BindCategory()
        {
            hdnidHotelRoomCategory.Value = "";
            txtRoomPrice.Text = "";
            txtRoomCategory.Text = "";
            HotelMasterDL objHotelDL = new HotelMasterDL();
            ResponseDto response = objHotelDL.GetHotelCategory(Convert.ToInt32(hdnHotelNewId.Value));
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    List<HotelCategoryDto> lst = (List<HotelCategoryDto>)response.Result;
                    rptCategory.DataSource = lst;
                    rptCategory.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }
        }

        protected void btnCancelCategory_Click(object sender, EventArgs e)
        {

        }

        protected void rptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                HiddenField hdnidHotelRoomCategory_Data = (HiddenField)e.Item.FindControl("hdnidHotelRoomCategory");
                HiddenField hdnCategoryName = (HiddenField)e.Item.FindControl("hdnCategoryName");
                HiddenField hdniPrice = (HiddenField)e.Item.FindControl("hdniPrice");
                hdnidHotelRoomCategory.Value = hdnidHotelRoomCategory_Data.Value;
                txtRoomCategory.Text = hdnCategoryName.Value;
                txtRoomPrice.Text = hdniPrice.Value;
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdnidHotelRoomCategory_Data = (HiddenField)e.Item.FindControl("hdnidHotelRoomCategory");
                HotelMasterDL objHotelDL = new HotelMasterDL();
                HotelCategoryDto hotelCatDto = new HotelCategoryDto();
                hotelCatDto.isDeleted = true;
                if (!string.IsNullOrEmpty(hdnidHotelRoomCategory_Data.Value))
                {
                    hotelCatDto.idHotelRoomCategory = Convert.ToInt32(hdnidHotelRoomCategory_Data.Value);
                }
                ResponseDto response = objHotelDL.InsertUpdateHotelCategory(hotelCatDto);
                if (response != null)
                {
                    if (response.StatusCode == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                        BindCategory();
                    }
                    else
                    {
                        hdMessage.Value = "Hotel Registation |" + response.Message;
                        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HotelMasterDL objHotelMasterDL = new HotelMasterDL();
            HotelMasterDto hotelDto = new HotelMasterDto();
            hotelDto.SubscriptionExpireDate = DateTime.Now;
            hotelDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                hotelDto.HotelID = Convert.ToString(hdnId.Value);
            }

            ResponseDto response = objHotelMasterDL.InsertUpdateDeleteHotel(hotelDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void RbAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private static readonly string Key = "AAAAAABBBBBBCCCC"; // Replace with your secure key
        private static readonly string IV = "ddwdszlpiojinckf"; // Replace with your secure IV (16 bytes)
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.Close();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(IV);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            HotelMasterDto hotelDto = new HotelMasterDto();
            hotelDto.HotelName = txtName.Text;
            //hotelDto.Password = (txtPassword.Text).ToString();
            hotelDto.Password = EncryptionHelper.Encrypt(txtPassword.Text).ToString();
            hotelDto.Status = chkActive.Checked;
            // Convert.ToBoolean(hotelDto.IsSubscribed) =chkSubscribed.Checked;
            hotelDto.IsSubscribed = txtSubscribed.Text;
            hotelDto.HotelAddress = txtAddress.Text;
            hotelDto.HotelOwnerNumber = txtContactPersonMobile.Text;
            hotelDto.HotelOwnerName = txtContactPerson.Text;
            hotelDto.RegMobileNumber = txtContact.Text;
            hotelDto.HotelWebsite = txtWebsite.Text;
            //hotelDto.HotelRegistrationDoc = "";
            //hotelDto.HotelOwnerAdharFront = "";
            //hotelDto.filePass = "";
            hotelDto.HotelEmail = txtEmail.Text;
            hotelDto.HotelPoliceStationId = Convert.ToInt32(ddlPoliceStation.SelectedValue);
            hotelDto.HotelStateId = Convert.ToInt32(ddlStateId.SelectedValue);
            hotelDto.HotelCityid = Convert.ToInt32(ddlCityId.SelectedValue);
            hotelDto.HotelDistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            hotelDto.SubscriptionExpireDate = Convert.ToDateTime(txtValidUpto.Text);
            hotelDto.HotelTypeId = Convert.ToInt32(ddlPropertyType.SelectedValue);
            hotelDto.HotelRoomCapacity = !string.IsNullOrEmpty(txtNoOfRoom.Text.Trim()) ? Convert.ToInt32(txtNoOfRoom.Text.Trim()) : 0;
            if (!string.IsNullOrEmpty(hdnHotelNewId.Value))
                hotelDto.HotelID = Convert.ToString(hdnHotelNewId.Value);
            ResponseDto response = objHotelDL.InsertUpdateDeleteHotel(hotelDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = response.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = response.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
            }
        }

        protected void ddlPoliceStationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void BindFilterPoliceStationDropdown(List<HotelMasterDto> lstHotelMasterDto)
        {
            if (policeStationMasterDto == null || policeStationMasterDto.Count() == 0)
            {
                policeStationMasterDto = new List<PoliceStationMasterDto>();
                int[] id = lstHotelMasterDto.Select(a => a.idPoliceStationMaster).Distinct().ToArray();
                foreach (int item in id)
                {
                    policeStationMasterDto.Add(lstHotelMasterDto.Where(a => a.idPoliceStationMaster == item).Select(a => new PoliceStationMasterDto() { idPoliceStationMaster = a.idPoliceStationMaster, PoliceStationName = a.PoliceStationName }).FirstOrDefault());
                }

                ddlPoliceStationFilter.DataSource = policeStationMasterDto;

                //.Select(x => x.PoliceStationName).Distinct().ToList(); 
                ddlPoliceStationFilter.DataTextField = "PoliceStationName";
                ddlPoliceStationFilter.DataValueField = "idPoliceStationMaster";
                ddlPoliceStationFilter.DataBind();
                //ddlPoliceStation.Items.Insert(0, new ListItem() { Text = "Select PoliceStation", Value = "0" });
            }
        }
        private void BindPoliceStationMasterDropdown()
        {
            DataSet dsPoliceStation = objHotelDL.GetAllPoliceStationMaster();
            ddlPoliceStationFilter.DataSource = dsPoliceStation.Tables[0];
            ddlPoliceStationFilter.DataTextField = "sName";
            ddlPoliceStationFilter.DataValueField = "Id";
            ddlPoliceStationFilter.DataBind();
            ddlPoliceStationFilter.Items.Insert(0, new ListItem() { Text = "Select PoliceStation", Value = "0" });
        }

        protected async void btnSaveImage_Click(object sender, EventArgs e)
        {
            var gumastaImage = ConvertImageToBase64(FileUploadGumasta);
            var aadharFrontImage = ConvertImageToBase64(FileUploadAadharFront);
            var aadharBackImage = ConvertImageToBase64(FileUploadAadharBack);
            ResponseDto response = objHotelDL.GetHotelById(Convert.ToInt32(hdnHotelNewId.Value));
            if (response != null)
            {
                hotelDto = (HotelMasterDto)response.Result;
            }
            var s3Client = new AmazonS3Client(accessKey, secretKey, bucketRegion);
            try
            {
                hotelDto.HotelName = hotelDto.HotelName.TrimEnd();
                if (!string.IsNullOrEmpty(gumastaImage.ImageData))
                {
                    try
                    {
                        string uniqueString = Guid.NewGuid().ToString("N");
                        string s3Key = $"{hotelDto.HotelName}/HotelDocuments/HotelRegistrationDoc_{uniqueString}_{gumastaImage.ImageName}";

                        Stream memStream = new MemoryStream(Convert.FromBase64String(gumastaImage.ImageData));
                        var transferUtility = new TransferUtility(s3Client);
                        await transferUtility.UploadAsync(memStream, bucketName, s3Key);
                        hotelDto.HotelRegistrationDocPath = s3Key;

                        Console.WriteLine("HotelRegistrationDoc uploaded to S3 successfully.");
                    }
                    catch (AmazonS3Exception ex)
                    {
                        Console.WriteLine($"Error uploading to S3: {ex.Message}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                        throw;
                    }
                }

                if (!string.IsNullOrEmpty(aadharFrontImage.ImageData))
                {
                    try
                    {
                        string uniqueString = Guid.NewGuid().ToString("N");
                        string s3Key = $"{hotelDto.HotelName}/HotelDocuments/HotelOwnerAdharFront_{uniqueString}_{aadharFrontImage.ImageName}";

                        Stream memStream = new MemoryStream(Convert.FromBase64String(aadharFrontImage.ImageData));
                        var transferUtility = new TransferUtility(s3Client);
                        await transferUtility.UploadAsync(memStream, bucketName, s3Key);
                        hotelDto.HotelOwnerAdharFrontPath = s3Key;
                        Console.WriteLine("HotelOwnerAdharFront uploaded to S3 successfully.");
                    }
                    catch (AmazonS3Exception ex)
                    {
                        Console.WriteLine($"Error uploading to S3: {ex.Message}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                        throw;
                    }
                }

                if (!string.IsNullOrEmpty(aadharBackImage.ImageData))
                {
                    // Handle AadharBackFile file
                    try
                    {
                        string uniqueString = Guid.NewGuid().ToString("N");
                        string s3Key = $"{hotelDto.HotelName}/HotelDocuments/HotelOwnerAdharBack_{uniqueString}_{aadharBackImage.ImageName}";

                        Stream memStream = new MemoryStream(Convert.FromBase64String(aadharBackImage.ImageData));
                        var transferUtility = new TransferUtility(s3Client);
                        await transferUtility.UploadAsync(memStream, bucketName, s3Key);
                        hotelDto.HotelOwnerAdharBackPath = s3Key;

                        Console.WriteLine("HotelOwnerAdharBack uploaded to S3 successfully.");
                    }
                    catch (AmazonS3Exception ex)
                    {
                        Console.WriteLine($"Error uploading to S3: {ex.Message}");
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                        throw;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            ResponseDto resp = objHotelDL.InsertUpdateDeleteHotelImage(hotelDto);
            if (resp != null)
            {
                if (resp.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = resp.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = resp.Message;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
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

        public ImageInformation ConvertImageToBase64(FileUpload fileUpload)
        {
            var fileName = fileUpload.PostedFile.FileName;
            System.IO.Stream fs = fileUpload.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var imageInformation = new ImageInformation
            {
                ImageData = base64,
                ImageName = fileName
            };
            return imageInformation;
        }

        protected void ddlPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}