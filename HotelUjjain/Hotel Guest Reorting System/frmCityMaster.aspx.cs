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
    public partial class frmCityMaster : System.Web.UI.Page
    {
        CityDL objCityDL = new CityDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "City Details";
            lbl2.Text = "City";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.City);
                if (!isAccess)
                    Response.Redirect("dashboard.aspx");
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionAddData();", true);
        }

        public void LoadGridData()
        {
            ResponseDto obj = objCityDL.GetCity();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<CityDto> userDto = (List<CityDto>)obj.Result;
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
                lbl4.Text = "Edit City";
                BindStateDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objCityDL.GetCityById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    CityDto userDto = (CityDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtCityname.Text = userDto.CityName;
                        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        hdCityId.Value = Convert.ToString(userDto.CityId);
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
                lbl4.Text = "View City";
                BindStateDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objCityDL.GetCityById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    CityDto userDto = (CityDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtCityname.Text = userDto.CityName;
                        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        hdCityId.Value = Convert.ToString(userDto.CityId);
                        EnableDisableControl(false);
                    }
                }
            }
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            ddlStateId.Enabled = v;
            ddlDistrict.Enabled= v;
            txtCityname.Enabled = v;
            chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtCityname.Text = "";
            ddlStateId.SelectedIndex = -1;
            hdCityId.Value = "";
            chkme.Checked = v;
            ddlDistrict.SelectedIndex = -1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lbl4.Text = "Add City";
            ShowUserPanal(true);
            BindStateDropdown();
            EnableDisableControl(true);
        }
        private void BindStateDropdown()
        {
            DataSet dsState = objCityDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });
            BindDistrictDropdown(0);
        }

        protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrictDropdown(Convert.ToInt32(ddlStateId.SelectedValue));
        }
        private void BindDistrictDropdown(int StateId)
        {
            if (StateId > 0)
            {
                DataSet dsDistrict = objCityDL.GetDistictByStateId(StateId);
                ddlDistrict.DataSource = dsDistrict.Tables[0];
                ddlDistrict.DataTextField = "sName";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
            }
            ddlDistrict.Items.Insert(0, new ListItem() { Text = "Select District", Value = "0" });
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            CityDto userDto = new CityDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.CityId = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objCityDL.InsertUpdateDeleteCity(userDto);
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
            CityDto userDto = new CityDto();
            userDto.CityName = txtCityname.Text;
            userDto.idDistrict = Convert.ToInt32(ddlDistrict.SelectedValue);
            userDto.StateID = Convert.ToInt32(ddlStateId.SelectedValue);
            userDto.bActive = Convert.ToInt16(chkme.Checked ? 1 : 0);
            if (!string.IsNullOrEmpty(hdCityId.Value))
            {
                userDto.CityId = Convert.ToInt32(hdCityId.Value);
            }

            ResponseDto response = objCityDL.InsertUpdateDeleteCity(userDto);
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