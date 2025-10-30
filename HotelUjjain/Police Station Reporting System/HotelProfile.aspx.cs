using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class HotelProfile : System.Web.UI.Page
    {
        HotelMasterDL objHotelDL = new HotelMasterDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idHotel = "";
                if (!string.IsNullOrEmpty(Request.QueryString["idHotel"]))
                {
                    idHotel = Convert.ToString(Request.QueryString["idHotel"]);
                    idHotel = UtilityFunction.Decrypt(idHotel);
                }
                LoadGridData(Convert.ToInt32(idHotel));
            }
        }

        private void LoadGridData(int idHotel)
        {
            HotelMasterDL objuserDL = new HotelMasterDL();
            ResponseDto response = objuserDL.GetHotelById(idHotel);
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
                    txtWebsite.Text = !string.IsNullOrEmpty(hotelDto.Website) ? hotelDto.Website : "-NA-"; ;
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

            DataSet dsPropertyType = objHotelDL.GetAllPropertyType();
            ddlPropertyType.DataSource = dsPropertyType.Tables[0];
            ddlPropertyType.DataTextField = "sName";
            ddlPropertyType.DataValueField = "Id";
            ddlPropertyType.DataBind();
            ddlPropertyType.Items.Insert(0, new ListItem() { Text = "Select PropertyType", Value = "0" });
        }       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
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
        protected void ddlDistrictId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrictId.SelectedValue);
        }
    }
}