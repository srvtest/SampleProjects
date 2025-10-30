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
    public partial class frmRolePoliceStation : System.Web.UI.Page
    {
        RolePoliceStationDL objRolePoliceStationDL = new RolePoliceStationDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Role Police Station Details";
            lbl2.Text = "Role Police Station";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionAddData();", true);
        }

        public void LoadGridData()
        {
            ResponseDto obj = objRolePoliceStationDL.GetRolePoliceStation();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<RolePoliceStationDto> userDto = (List<RolePoliceStationDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptUser.DataSource = userDto;
                        RptUser.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Role Police Station";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objRolePoliceStationDL.GetRolePoliceStationById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    RolePoliceStationDto userDto = (RolePoliceStationDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        ddlRole.SelectedValue = Convert.ToString(userDto.idRole);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.idState);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrict.SelectedValue = Convert.ToString(userDto.idDistrict);
                        BindCityDropdown(ddlDistrict.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(userDto.idCity);
                        BindPoliceStationDropdown(ddlCityId.SelectedValue);
                        ddlPoliceStation.SelectedValue = Convert.ToString(userDto.idPoliceStation);   
                        hdRolePoliceStationId.Value = Convert.ToString(userDto.idRolePoliceStation);
                        EnableDisableControl(true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                if (hiddenField.Value != null)
                {
                    hdnId.Value = hiddenField.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "View Role Police Station";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objRolePoliceStationDL.GetRolePoliceStationById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    RolePoliceStationDto userDto = (RolePoliceStationDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        ddlRole.SelectedValue = Convert.ToString(userDto.idRole);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.idState);
                        BindDistrictDropdown(ddlStateId.SelectedValue);
                        ddlDistrict.SelectedValue = Convert.ToString(userDto.idDistrict);
                        BindCityDropdown(ddlDistrict.SelectedValue);
                        ddlCityId.SelectedValue = Convert.ToString(userDto.idCity);
                        BindPoliceStationDropdown(ddlCityId.SelectedValue);
                        ddlPoliceStation.SelectedValue = Convert.ToString(userDto.idPoliceStation);
                        hdRolePoliceStationId.Value = Convert.ToString(userDto.idRolePoliceStation);
                        EnableDisableControl(false);
                    }
                }
            }
        }

        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            ddlRole.Enabled = v;
            ddlStateId.Enabled = v;
            ddlDistrict.Enabled = v;
            ddlCityId.Enabled = v;
            ddlPoliceStation.Enabled = v;
            //chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            ddlDistrict.SelectedIndex = -1;
            ddlCityId.SelectedIndex = -1;
            ddlStateId.SelectedIndex = -1;
            ddlRole.SelectedIndex = -1;
            ddlPoliceStation.SelectedIndex = -1;
            hdRolePoliceStationId.Value = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindAllDropdown();
            lbl4.Text = "Add Role Police Station";
            EnableDisableControl(true);
        }
        private void BindAllDropdown()
        {
            DataSet dsState = objRolePoliceStationDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });

            DataSet dsRole = objRolePoliceStationDL.GetAllRole();
            ddlRole.DataSource = dsRole.Tables[0];
            ddlRole.DataTextField = "sName";
            ddlRole.DataValueField = "Id";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem() { Text = "Select Role", Value = "0" });
        }

        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(ddlStateId.SelectedValue);
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCityDropdown(ddlDistrict.SelectedValue);
        }

        private void BindDistrictDropdown(string selectedValue)
        {
            DataSet dsDistrict = objRolePoliceStationDL.GetAllDistrict(selectedValue);
            DataRow workRow = dsDistrict.Tables[0].NewRow();
            workRow["sName"] = "No Data";
            workRow["Id"] = "0";
            dsDistrict.Tables[0].Rows.Add(workRow);
            dsDistrict.Tables[0].DefaultView.Sort = "Id";
            DataTable dt = dsDistrict.Tables[0].DefaultView.ToTable();
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataTextField = "sName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();
            //ddlZoneId.Items.Insert(0, new ListItem() { Text = "Select Zone", Value = "0" }); 
        }
        private void BindCityDropdown(string selectedValue)
        {
            DataSet dsCity = objRolePoliceStationDL.GetAllCity(selectedValue);
            DataRow workRow = dsCity.Tables[0].NewRow();
            workRow["sName"] = "No Data";
            workRow["CityId"] = "0";
            dsCity.Tables[0].Rows.Add(workRow);
            dsCity.Tables[0].DefaultView.Sort = "CityId";
            DataTable dt = dsCity.Tables[0].DefaultView.ToTable();

            ddlCityId.DataSource = dt;
            ddlCityId.DataTextField = "sName";
            ddlCityId.DataValueField = "CityId";
            ddlCityId.DataBind();
            //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });
        }
        private void BindPoliceStationDropdown(string selectedValue)
        {
            DataSet dsPoliceStation = objRolePoliceStationDL.GetAllPoliceStation(selectedValue);
            DataRow workRow = dsPoliceStation.Tables[0].NewRow();
            workRow["sName"] = "No Data";
            workRow["Id"] = "0";
            dsPoliceStation.Tables[0].Rows.Add(workRow);
            dsPoliceStation.Tables[0].DefaultView.Sort = "Id";
            DataTable dt = dsPoliceStation.Tables[0].DefaultView.ToTable();
            ddlPoliceStation.DataSource = dt;
            ddlPoliceStation.DataTextField = "sName";
            ddlPoliceStation.DataValueField = "Id";
            ddlPoliceStation.DataBind();
            //ddlPoliceStation.Items.Insert(0, new ListItem() { Text = "Select PoliceStation", Value = "0" });
        }

        protected void ddlCityId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPoliceStationDropdown(ddlCityId.SelectedValue);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            RolePoliceStationDto userDto = new RolePoliceStationDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idRolePoliceStation = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objRolePoliceStationDL.InsertUpdateDeleteRolePoliceStation(userDto);
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
        protected void Button4_Click(object sender, EventArgs e)
        {
            RolePoliceStationDto userDto = new RolePoliceStationDto();
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                userDto.idDistrict = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlCityId.SelectedValue))
                userDto.idCity = Convert.ToInt32(ddlCityId.SelectedValue);
            if (!string.IsNullOrEmpty(ddlRole.SelectedValue))
                userDto.idRole = Convert.ToInt32(ddlRole.SelectedValue);
            if (!string.IsNullOrEmpty(ddlPoliceStation.SelectedValue))
                userDto.idPoliceStation = Convert.ToInt32(ddlPoliceStation.SelectedValue);
            userDto.idState = Convert.ToInt32(ddlStateId.SelectedValue);
            if (!string.IsNullOrEmpty(hdRolePoliceStationId.Value))
            {
                userDto.idRolePoliceStation = Convert.ToInt32(hdRolePoliceStationId.Value);
            }

            ResponseDto response = objRolePoliceStationDL.InsertUpdateDeleteRolePoliceStation(userDto);
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
    }
}