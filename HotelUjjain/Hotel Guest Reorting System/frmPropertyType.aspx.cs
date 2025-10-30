using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmPropertyType : System.Web.UI.Page
    {
        PropertyTypeDL objPropertyTypeDL = new PropertyTypeDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Property Type Details";
            lbl2.Text = "Property Type";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.PropertyType);
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
            ResponseDto obj = objPropertyTypeDL.GetPropertyType();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<PropertyTypeDto> userDto = (List<PropertyTypeDto>)obj.Result;
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
                lbl4.Text = "Edit Property Type";
               // BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objPropertyTypeDL.GetPropertyTypeById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    PropertyTypeDto userDto = (PropertyTypeDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtPropertyType.Text = userDto.PropertyType;
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        hdPropertyTypeId.Value = Convert.ToString(userDto.idProperty);
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
                lbl4.Text = "View Property Type";
                // BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objPropertyTypeDL.GetPropertyTypeById(Convert.ToInt32(e.CommandArgument));
                if (response != null)
                {
                    PropertyTypeDto userDto = (PropertyTypeDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtPropertyType.Text = userDto.PropertyType;
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        hdPropertyTypeId.Value = Convert.ToString(userDto.idProperty);
                        EnableDisableControl(false);
                    }
                }
            }
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;            
            txtPropertyType.Enabled = v;
            chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtPropertyType.Text = "";
            hdPropertyTypeId.Value = "";
            chkme.Checked= v;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lbl4.Text = "Add Property Type";
            ShowUserPanal(true);
            EnableDisableControl(true);
            //BindAllDropdown();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            PropertyTypeDto userDto = new PropertyTypeDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idProperty = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objPropertyTypeDL.InsertUpdateDeletePropertyType(userDto);
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
            PropertyTypeDto userDto = new PropertyTypeDto();
            userDto.PropertyType = txtPropertyType.Text;
            userDto.bActive = Convert.ToInt16(chkme.Checked ? 1 : 0);
            if (!string.IsNullOrEmpty(hdPropertyTypeId.Value))
            {
                userDto.idProperty = Convert.ToInt32(hdPropertyTypeId.Value);
            }

            ResponseDto response = objPropertyTypeDL.InsertUpdateDeletePropertyType(userDto);
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