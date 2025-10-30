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
    public partial class frmRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Role Details";
            lbl2.Text = "Role";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.Role);
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
            RoleDL objRoleDL = new RoleDL();
            ResponseDto obj = objRoleDL.GetRoleDetail();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<RoleDto> userDto = (List<RoleDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptRole.DataSource = userDto;
                        RptRole.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void RptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RoleDL objuserDL = new RoleDL();
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Role";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetRoleById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    RoleDto userDto = (RoleDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtName.Text = userDto.sName;
                        chkActive.Checked = userDto.bActive;
                        hdnUserId.Value = Convert.ToString(userDto.idRole);
                        EnableDisableControl(true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                if (hiddenField.Value != null)
                {
                    hdnId.Value = hiddenField.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "View Role";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetRoleById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    RoleDto userDto = (RoleDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtName.Text = userDto.sName;
                        chkActive.Checked = userDto.bActive;
                        hdnUserId.Value = Convert.ToString(userDto.idRole);
                        EnableDisableControl(false);
                    }
                }
            }
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            txtName.Enabled = v;
            chkActive.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtName.Text = "";
            chkActive.Checked = false;
            hdnUserId.Value = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            lbl4.Text = "Add Role";
            EnableDisableControl(true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            RoleDL objRoleDL = new RoleDL();
            RoleDto userDto = new RoleDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idRole = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objRoleDL.InsertUpdatDeleteeRole(userDto);
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
            RoleDL objRoleDL = new RoleDL();
            RoleDto roleDto = new RoleDto();
            roleDto.sName = txtName.Text;
            roleDto.bActive = chkActive.Checked;
            if (!string.IsNullOrEmpty(hdnUserId.Value))
                roleDto.idRole = Convert.ToInt32(hdnUserId.Value);
            ResponseDto response = objRoleDL.InsertUpdatDeleteeRole(roleDto);
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