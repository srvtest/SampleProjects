using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmUserMaster : System.Web.UI.Page
    {
        private static string _EncryptionKey;
        public static string EncryptionKey
        {
            get
            {
                if (_EncryptionKey == null || _EncryptionKey == string.Empty)
                {
                    _EncryptionKey = "H0t3l!Gu35t";
                }
                return _EncryptionKey;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "User Details";
            lbl2.Text = "User";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.User);
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
            userDL objuserDL = new userDL();
            ResponseDto obj = objuserDL.GetUserDetail();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<UserDto> userDto = (List<UserDto>)obj.Result;
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
            userDL objuserDL = new userDL();
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit User";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetUserDetailById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    UserDto userDto = (UserDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        BindUserRole(userDto.idUser);
                        txtName.Text = userDto.Name;
                        txtMobileNo.Text = userDto.MobileNumber;
                        txtUsername.Text = userDto.Username;                        
                        txtPassword.Text = userDto.password;
                        chkActive.Checked = userDto.bActive;
                        hdnUserId.Value = Convert.ToString(userDto.idUser);
                        ddlUserType.SelectedValue = userDto.UserType;
                        ddlUserType_SelectedIndexChanged(null, null);
                        EnableDisableControl(true);
                        txtUsername.Enabled = false;
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
                lbl4.Text = "View User";
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetUserDetailById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    UserDto userDto = (UserDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        BindUserRole(userDto.idUser);
                        txtName.Text = userDto.Name;
                        txtMobileNo.Text = userDto.MobileNumber;
                        txtUsername.Text = userDto.Username;
                        txtPassword.Text = userDto.password;
                        chkActive.Checked = userDto.bActive;
                        ddlUserType.SelectedValue = userDto.UserType;
                        ddlUserType_SelectedIndexChanged(null, null);
                        hdnUserId.Value = Convert.ToString(userDto.idUser);
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
            txtUsername.Enabled = v;
            txtPassword.Enabled = v;
            txtMobileNo.Enabled = v;
            chkActive.Enabled = v;
            btnSubmit.Enabled = v;
            ddlUserType.Enabled= v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            chkActive.Checked = false;
            hdnUserId.Value = "";
            ddlUserType.SelectedIndex = 0;
            ddlUserType_SelectedIndexChanged(null, null);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindUserRole(0);
            lbl4.Text = "Add User";
            EnableDisableControl(true);
        }

        public void BindUserRole(int idUser)
        {
            userDL objuserDL = new userDL();
            ResponseDto obj = objuserDL.GetUserRole(idUser);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<UserRightsDto> userRoleDto = (List<UserRightsDto>)obj.Result;
                    if (userRoleDto != null)
                    {
                        lstRole.DataSource = userRoleDto;
                        lstRole.DataTextField = "sRoleName";
                        lstRole.DataValueField = "idRole";
                        lstRole.DataBind();
                    }

                    for (int i = 0; i < userRoleDto.Count; i++)
                        if (userRoleDto[i].idUser > 0)
                            lstRole.Items[i].Selected = true;


                }
            }



        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            userDL objLoginDL = new userDL();
            UserDto userDto = new UserDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.idUser = Convert.ToInt32(hdnId.Value);
            }
            if (userDto.idUser != 1)
            {
                ResponseDto response = objLoginDL.InsertUpdatDeleteeUser(userDto);
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
            else
            {
                hdMessage.Value = "Admin user not Allow to delete.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedIndex==0)
            {
                txtUsername.Visible=true;
                lblUserName.Visible=true;
                divUser.Visible=true;
                txtPassword.Visible = true;
                lblPassword.Visible=true;
                divpass.Visible=true;
                txtMobileNo.Visible = false;
                lblMobileNo.Visible=false;
                divMobile.Visible=false;    
            }
            else
            {
                txtUsername.Visible = false;
                lblUserName.Visible = false;
                divUser.Visible = false;
                txtPassword.Visible = false;
                lblPassword.Visible = false;
                divpass.Visible = false;    
                txtMobileNo.Visible = true;
                lblMobileNo.Visible=true;   
                divMobile.Visible = true;   
            }
        }
         protected void Button4_Click(object sender, EventArgs e)
        {
            userDL objLoginDL = new userDL();
            UserDto userDto = new UserDto();
            userDto.Username = txtUsername.Text;
            userDto.password = txtPassword.Text;
            userDto.Name = txtName.Text;
            userDto.MobileNumber = txtMobileNo.Text;
            userDto.bActive = chkActive.Checked;
            userDto.UserType = ddlUserType.Text;
            if (!string.IsNullOrEmpty(hdnUserId.Value))
            {
                userDto.idUser = Convert.ToInt32(hdnUserId.Value);
            }
            userDto.rights = new List<UserRightsDto>();
            foreach (ListItem item in lstRole.Items)
            {
                if (item.Selected)
                {
                    userDto.rights.Add(new UserRightsDto { idRole = Convert.ToInt32(item.Value), idUser = userDto.idUser });
                }
            }
            ResponseDto response = objLoginDL.InsertUpdatDeleteeUser(userDto);
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