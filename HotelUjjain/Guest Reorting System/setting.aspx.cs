using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class setting : System.Web.UI.Page
    {
        HotelMasterDL objHotelDL = new HotelMasterDL();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Enabled = false;
                HotelMasterDL objuserDL = new HotelMasterDL();
                ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(Session["snsHotelId"]));
                if (response != null)
                {
                    HotelMasterDto hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        LoadState();
                        txtName.Text = hotelDto.HotelName;
                        hdnHotelNewId.Value = Convert.ToString(hotelDto.idHotelMaster);
                        txtAddress.Text = hotelDto.Address;
                        txtContact.Text = hotelDto.Contact;
                        txtContactPerson.Text = hotelDto.ContactPerson;
                        txtEmail.Text = hotelDto.EmailAddress;
                        txtMobileno.Text = hotelDto.ContactPersonMobile;
                        txtWebsite.Text = !string.IsNullOrEmpty(hotelDto.Website) ? hotelDto.Website : "-NA-";
                        ddlPropertyType.SelectedValue = Convert.ToString(hotelDto.PropertyType);
                        ddlStateId.SelectedValue = Convert.ToString(hotelDto.idState);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrictId.SelectedValue = Convert.ToString(hotelDto.idDistrict);
                        BindCityDropdown(ddlDistrictId.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(hotelDto.idCity);
                        //BindZoneDropdown(ddlCityId.SelectedValue);
                        //ddlZoneId.SelectedValue = Convert.ToString(hotelDto.idZone);
                        BindPoliceStationDropdown(ddlCityId.SelectedValue);
                        ddlPoliceStation.SelectedValue = Convert.ToString(hotelDto.idPoliceStation);
                    }
                }
                BindCategory();
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
            //BindCityDropdown(ddlStateId.SelectedValue);

            DataSet dsPropertyType = objHotelDL.GetAllPropertyType();
            ddlPropertyType.DataSource = dsPropertyType.Tables[0];
            ddlPropertyType.DataTextField = "sName";
            ddlPropertyType.DataValueField = "Id";
            ddlPropertyType.DataBind();
            ddlPropertyType.Items.Insert(0, new ListItem() { Text = "Select PropertyType", Value = "0" });
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            HotelMasterDto hotelDto = new HotelMasterDto();
            hotelDto.HotelName = txtName.Text;
            hotelDto.bActive = true;
            hotelDto.Address = txtAddress.Text;
            hotelDto.Contact = txtMobileno.Text;
            hotelDto.ContactPerson = txtContactPerson.Text;
            hotelDto.ContactPersonMobile = txtContact.Text;
            hotelDto.Website = txtWebsite.Text;
            hotelDto.EmailAddress = txtEmail.Text;
            hotelDto.PropertyType = Convert.ToInt32(ddlPropertyType.SelectedValue);
            hotelDto.idPoliceStation = Convert.ToInt32(ddlPoliceStation.SelectedValue);
            hotelDto.idState = Convert.ToInt32(ddlStateId.SelectedValue);
            hotelDto.idDistrict = Convert.ToInt32(ddlDistrictId.SelectedValue);
            hotelDto.idCity = Convert.ToInt32(ddlCityId.SelectedValue);
            //hotelDto.idZone = Convert.ToInt32(ddlZoneId.SelectedValue);
            hotelDto.ValidUpto = DateTime.Now.AddDays(2);
            string sFPassword = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8);
            //string sFileGumasta = UploadImage(FileGumasta, sFPassword);
            //string sFileAdhar = UploadImage(FileAdhar, sFPassword);
            //hotelDto.FileGumasta = sFileGumasta;
            //hotelDto.FileAdhar = sFileAdhar;
            hotelDto.filePass = sFPassword;

            if (!string.IsNullOrEmpty(hdnHotelNewId.Value))
                hotelDto.idHotelMaster = Convert.ToInt32(hdnHotelNewId.Value);
            ResponseDto response = objHotelDL.InsertUpdateDeleteHotel(hotelDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }

        protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPoliceStationDropdown(ddlCityId.SelectedValue);
        }

        //protected void ddlZoneId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindPoliceStationDropdown(ddlZoneId.SelectedValue);
        //}

        //private void BindZoneDropdown(string selectedValue)
        //{
        //    DataSet dsZone = objHotelDL.GetAllZone(selectedValue);
        //    ddlZoneId.DataSource = dsZone.Tables[0];
        //    ddlZoneId.DataTextField = "sName";
        //    ddlZoneId.DataValueField = "Id";
        //    ddlZoneId.DataBind();
        //    //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        //}

        private void BindDistrictDropdown(string selectedValue)
        {
            DataSet dsDistrict = objHotelDL.GetAllDistrict(selectedValue);
            ddlDistrictId.DataSource = dsDistrict.Tables[0];
            ddlDistrictId.DataTextField = "sName";
            ddlDistrictId.DataValueField = "Id";
            ddlDistrictId.DataBind();
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
        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HotelMasterDL objHotelDL = new HotelMasterDL();
            HotelCategoryDto hotelCatDto = new HotelCategoryDto();
            hotelCatDto.isDeleted = Convert.ToBoolean(hdisDeleted.Value);
            hotelCatDto.idHotelRoomCategory = Convert.ToInt32(hdidHotelRoomCategory.Value);
            ResponseDto response = objHotelDL.InsertUpdateHotelCategory(hotelCatDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestData()", true);
                    BindCategory();
                }
                else
                {
                    hdMessage.Value = "Hotel Registation |" + response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "SaveGuestError()", true);
                }
            }
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
            hdnidHotelRoomCategory.Value = "";
            txtRoomPrice.Text = "";
            txtRoomCategory.Text = "";
            //Response.Redirect("Dashboard.aspx");
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
                if (hdnidHotelRoomCategory_Data.Value != null)
                {
                    hdidHotelRoomCategory.Value = hdnidHotelRoomCategory_Data.Value;
                    hdisDeleted.Value = Convert.ToString(true);
                    Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "QuestionDeleteData();", true);
                }                
            }
        }

        protected void ddlDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrictId.SelectedValue);
        }
    }
}