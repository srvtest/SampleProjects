using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmRoleNavigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Role Navigation Details";
            lbl2.Text = "Role Navigation";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {

                LoadGridData();
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RoleNavigationDL objLoginDL = new RoleNavigationDL();
            RoleNavigationDto userDto = new RoleNavigationDto();
            //userDto.Username = txtUsername.Text;
            //userDto.password = txtPassword.Text;
            //userDto.Name = txtName.Text;
            //userDto.bActive = chkActive.Checked;
            //if (!string.IsNullOrEmpty(hdnUserId.Value))
            //{
            //    userDto.idUser = Convert.ToInt32(hdnUserId.Value);
            //}

            ResponseDto response = objLoginDL.InsertUpdateDeleteRoleNavigation(userDto);
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
            RoleNavigationDL objuserDL = new RoleNavigationDL();
            ResponseDto obj = objuserDL.GetRoleNavigation();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<RoleNavigationDto> userDto = (List<RoleNavigationDto>)obj.Result;
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
            RoleNavigationDL objuserDL = new RoleNavigationDL();
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Role Navigation";
                HiddenField hdnUserId = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetRoleNavigationById(Convert.ToInt32(hdnUserId.Value));
                if (response != null)
                {
                    RoleNavigationDto userDto = (RoleNavigationDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        //txtName.Text = userDto.Name;
                        //chkActive.Checked = userDto.bActive;
                        //hdnUserId.Value = Convert.ToString(userDto.idUser);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hduserId");
                RoleNavigationDL objLoginDL = new RoleNavigationDL();
                RoleNavigationDto userDto = new RoleNavigationDto();
                userDto.isDeleted = true;
                if (!string.IsNullOrEmpty(hiddenField.Value))
                {
                    userDto.idRoleNavigation = Convert.ToInt32(hiddenField.Value);
                }

                ResponseDto response = objLoginDL.InsertUpdateDeleteRoleNavigation(userDto);
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
            //txtName.Text = "";
            //txtPassword.Text = "";
            //txtUsername.Text = "";
            //chkActive.Checked = false;
            //hdnUserId.Value = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            lbl4.Text = "Add Role Navigation";
        }
    }
}