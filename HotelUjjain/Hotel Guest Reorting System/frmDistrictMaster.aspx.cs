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
    public partial class frmDistrictMaster : System.Web.UI.Page
    {
        DistrictDL objDistrictDL = new DistrictDL();
        int StateId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "District Details";
            lbl2.Text = "District";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.District);
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
            ResponseDto obj = objDistrictDL.GetDistrict();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<DistrictDto> userDto = (List<DistrictDto>)obj.Result;
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
                lbl4.Text = "Edit District";
                BindStateDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");

                ResponseDto response = objDistrictDL.GetDistrictById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    DistrictDto userDto = (DistrictDto)response.Result;
                    
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        //BindDropdown(Convert.ToString(userDto.StateID));
                        txtDistrictname.Text = userDto.DistrictName;
                        //ddlCityId.SelectedValue = Convert.ToString(userDto.CityId);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false; 
                        hdDistrictId.Value = Convert.ToString(userDto.idDistrict);
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
                lbl4.Text = "View District";
                BindStateDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");

                ResponseDto response = objDistrictDL.GetDistrictById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    DistrictDto userDto = (DistrictDto)response.Result;

                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        //BindDropdown(Convert.ToString(userDto.StateID));
                        txtDistrictname.Text = userDto.DistrictName;
                        //ddlCityId.SelectedValue = Convert.ToString(userDto.CityId);
                        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        hdDistrictId.Value = Convert.ToString(userDto.idDistrict);
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
            txtDistrictname.Enabled = v;
            chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtDistrictname.Text = "";
            //ddlCityId.SelectedIndex = -1;
            ddlStateId.SelectedIndex = -1;
            hdDistrictId.Value = "";
            chkme.Checked= v;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindStateDropdown();
            lbl4.Text = "Add District";
            EnableDisableControl(true);
        }
        private void BindStateDropdown()
        {
            DataSet dsState = objDistrictDL.GetAllState();
            ddlStateId.DataSource = dsState.Tables[0];
            ddlStateId.DataTextField = "sName";
            ddlStateId.DataValueField = "Id";
            ddlStateId.DataBind();
            ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });                   
        }

        //protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindDistrictDropdown(ddlStateId.SelectedValue);             
        //}

        //private void BindDistrictDropdown(string selectedValue)
        //{
        //    DataSet dsCity = objDistrictDL.GetDistrictById(Convert.ToInt32(ddlStateId.SelectedValue));
        //    ddl.DataSource = dsCity.Tables[0];
        //    ddlCityId.DataTextField = "DistrictName";
        //    ddlCityId.DataValueField = "idDistrict";
        //    ddlCityId.DataBind();
        //    //ddlCityId.Items.Insert(0, new ListItem() { Text = "Select City", Value = "0" });  
        //}
        protected void Button3_Click(object sender, EventArgs e)
        {
            DistrictDto userDto = new DistrictDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idDistrict = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objDistrictDL.InsertUpdateDeleteDistrict(userDto);
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
            DistrictDto userDto = new DistrictDto();
            userDto.DistrictName = txtDistrictname.Text;
            //userDto.CityId = Convert.ToInt32(ddlCityId.SelectedValue);
            userDto.StateID = Convert.ToInt32(ddlStateId.SelectedValue);
            userDto.bActive = Convert.ToInt16(chkme.Checked ? 1 : 0);
            if (!string.IsNullOrEmpty(hdDistrictId.Value))
            {
                userDto.idDistrict = Convert.ToInt32(hdDistrictId.Value);
            }

            ResponseDto response = objDistrictDL.InsertUpdateDeleteDistrict(userDto);
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