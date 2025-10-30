using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmZoneMaster : System.Web.UI.Page
    {
        DistrictDL objZoneDL = new DistrictDL();
        int StateId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Zone Details";
            lbl2.Text = "Zone";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.Zone);
                if (!isAccess)
                    Response.Redirect("dashboard.aspx");
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ZoneDto userDto = new ZoneDto();
            userDto.ZoneName = txtZonename.Text;
            userDto.CityId = Convert.ToInt32(ddlCityId.SelectedValue);
            userDto.StateID = Convert.ToInt32(ddlStateId.SelectedValue);
            userDto.bActive= Convert.ToInt16(chkme.Checked ? 1 : 0);
            if (!string.IsNullOrEmpty(hdZoneId.Value))
            {
                userDto.idZone = Convert.ToInt32(hdZoneId.Value);
            }

            ResponseDto response = objZoneDL.InsertUpdateDeleteZone(userDto);
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

        public void LoadGridData()
        {
            ResponseDto obj = objZoneDL.GetZone();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<ZoneDto> userDto = (List<ZoneDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptUser.DataSource = userDto;
                        RptUser.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
        }

        protected void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Zone";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objZoneDL.GetZoneById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    ZoneDto userDto = (ZoneDto)response.Result;
                    
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        BindDropdown(Convert.ToString(userDto.StateID));
                        txtZonename.Text = userDto.ZoneName;
                        ddlCityId.SelectedValue = Convert.ToString(userDto.CityId);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false; 
                        hdZoneId.Value = Convert.ToString(userDto.idZone);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ZoneDto userDto = new ZoneDto();
                userDto.isDeleted = true;
                if (!string.IsNullOrEmpty(hiddenField.Value))
                {
                    userDto.idZone = Convert.ToInt32(hiddenField.Value);
                }

                ResponseDto response = objZoneDL.InsertUpdateDeleteZone(userDto);
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
        }

        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtZonename.Text = "";
            ddlCityId.SelectedIndex = -1;
            ddlStateId.SelectedIndex = -1;
            hdZoneId.Value = "";
            chkme.Checked= v;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindAllDropdown();
            lbl4.Text = "Add Zone";
        }
        private void BindAllDropdown()
        {
            DataSet dsState = objZoneDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });                   
        }

        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropdown(ddlStateId.SelectedValue);             
        }

        private void BindDropdown(string selectedValue)
        {
            DataSet dsCity = objZoneDL.GetAllCity(ddlStateId.SelectedValue);
            ddlCityId.DataSource = dsCity.Tables[0];
            ddlCityId.DataTextField = "sName";
            ddlCityId.DataValueField = "CityId";
            ddlCityId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });  
        }
    }
}