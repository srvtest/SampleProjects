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

namespace Police_Station_Reporting_System
{
    public partial class setting : System.Web.UI.Page
    {
        PoliceStationMasterDL objPoliceStationMasterDL = new PoliceStationMasterDL();
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
                //HotelMasterDL objuserDL = new HotelMasterDL();
                BindPoliceStationDropdown(Convert.ToString(Session["UserId"]));
                ddlPoliceStation_SelectedIndexChanged(null, null);
                //ddlPoliceStation.SelectedValue = Convert.ToString(Session["UserId"]);

            }
        }
        private void LoadState()
        {
            DataSet dsState = objPoliceStationMasterDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });
            ddlStateId.SelectedValue = ConfigurationManager.AppSettings["StateConfig"].ToString();
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PoliceStationMasterDto userDto = new PoliceStationMasterDto();
            userDto.PoliceStationName = txtName.Text;
            // userDto.idZone = Convert.ToInt32(ddlZoneId.SelectedValue);
            userDto.idDistrict = Convert.ToInt32(ddlDistrictId.SelectedValue);
            userDto.idCity = Convert.ToInt32(ddlCityId.SelectedValue);
            userDto.idState = Convert.ToInt32(ddlStateId.SelectedValue);
            if (!string.IsNullOrEmpty(hdnHotelNewId.Value))
            {
                userDto.idPoliceStationMaster = Convert.ToInt32(hdnHotelNewId.Value);
            }
            ResponseDto response = objPoliceStationMasterDL.InsertUpdateDeletePoliceStationMaster(userDto);
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
            Response.Redirect("index.aspx");
        }
        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }

        //protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindZoneDropdown(ddlCityId.SelectedValue);
        //}

        //private void BindZoneDropdown(string selectedValue)
        //{
        //    DataSet dsZone = objPoliceStationMasterDL.GetAllZone(selectedValue);
        //    ddlZoneId.DataSource = dsZone.Tables[0];
        //    ddlZoneId.DataTextField = "sName";
        //    ddlZoneId.DataValueField = "Id";
        //    ddlZoneId.DataBind();
        //    //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        //}
        private void BindDistrictDropdown(string selectedValue)
        {
            DataSet dsDistrict = objPoliceStationMasterDL.GetAllDistrict(selectedValue);
            ddlDistrictId.DataSource = dsDistrict.Tables[0];
            ddlDistrictId.DataTextField = "sName";
            ddlDistrictId.DataValueField = "Id";
            ddlDistrictId.DataBind();
            //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        }
        private void BindCityDropdown(string selectedValue)
        {
            DataSet dsCity = objPoliceStationMasterDL.GetAllCity(selectedValue);
            ddlCityId.DataSource = dsCity.Tables[0];
            ddlCityId.DataTextField = "sName";
            ddlCityId.DataValueField = "CityId";
            ddlCityId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
        }
        protected void ddlDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrictId.SelectedValue);
        }

        protected void ddlPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResponseDto response = objPoliceStationMasterDL.GetPoliceStationMasterById(Convert.ToInt32(ddlPoliceStation.SelectedValue));
            if (response != null)
            {
                PoliceStationMasterDto hotelDto = (PoliceStationMasterDto)response.Result;
                if (hotelDto != null)
                {
                    LoadState();
                    txtName.Text = hotelDto.PoliceStationName;
                    hdnHotelNewId.Value = Convert.ToString(hotelDto.idPoliceStationMaster);
                    txtContact.Text = hotelDto.MobileNumber;
                    txtLandline.Text = hotelDto.landLineNumber;
                    txtEmail.Text = hotelDto.EmailId;
                    if (hotelDto.idState != 0)
                    {
                        ddlStateId.SelectedValue = Convert.ToString(hotelDto.idState);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrictId.SelectedValue = Convert.ToString(hotelDto.idDistrict);
                        BindCityDropdown(ddlDistrictId.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(hotelDto.idCity);
                    }
                }
            }
        }

        private void BindPoliceStationDropdown(string selectedValue)
        {
            if (string.IsNullOrEmpty(selectedValue))
                return;
            DataSet dsPoliceStation = objPoliceStationMasterDL.GetAllPoliceStation(selectedValue);
            ddlPoliceStation.DataSource = dsPoliceStation.Tables[0];
            ddlPoliceStation.DataTextField = "sName";
            ddlPoliceStation.DataValueField = "Id";
            ddlPoliceStation.DataBind();
        }
    }
}