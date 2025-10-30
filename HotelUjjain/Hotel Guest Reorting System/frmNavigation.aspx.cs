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
    public partial class frmNavigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "Navigation Details";
            lbl2.Text = "Navigation";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.Navigation);
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
            NavigationDL objuserDL = new NavigationDL();
            ResponseDto obj = objuserDL.GetNavigation();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<NavigationDto> userDto = (List<NavigationDto>)obj.Result;
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
            NavigationDL objuserDL = new NavigationDL();
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit Navigation";
                HiddenField hduserId = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetNavigationById(Convert.ToInt32(hduserId.Value));
                if (response != null)
                {
                    NavigationDto navigationDto = (NavigationDto)response.Result;
                    if (navigationDto != null)
                    {
                        ShowUserPanal(true);
                        //txtName.Text = userDto.Name;
                        //chkActive.Checked = userDto.bActive;
                        BindNavigationRole(navigationDto.idNavigation);
                        hdNavNewId.Value = Convert.ToString(navigationDto.idNavigation);
                        txtlabel.Text = Convert.ToString(navigationDto.Label);
                        txtroute.Text = Convert.ToString(navigationDto.Route);
                        txticon.Text = Convert.ToString(navigationDto.Icon);
                        txtparentid.Text = Convert.ToString(navigationDto.parentId);
                        txtsortorder.Text = Convert.ToString(navigationDto.SortOrder);
                        txtDescription.Text = Convert.ToString(navigationDto.Description);
                        chkbActive.Checked = navigationDto.bActive;
                        EnableDisableControl(true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hduserId = (HiddenField)e.Item.FindControl("hduserId");
                if (hduserId.Value != null)
                {
                    hdnId.Value = hduserId.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "Edit Navigation";
                HiddenField hduserId = (HiddenField)e.Item.FindControl("hduserId");
                ResponseDto response = objuserDL.GetNavigationById(Convert.ToInt32(hduserId.Value));
                if (response != null)
                {
                    NavigationDto navigationDto = (NavigationDto)response.Result;
                    if (navigationDto != null)
                    {
                        ShowUserPanal(true);
                        //txtName.Text = userDto.Name;
                        //chkActive.Checked = userDto.bActive;
                        BindNavigationRole(navigationDto.idNavigation);
                        hdNavNewId.Value = Convert.ToString(navigationDto.idNavigation);
                        txtlabel.Text = Convert.ToString(navigationDto.Label);
                        txtroute.Text = Convert.ToString(navigationDto.Route);
                        txticon.Text = Convert.ToString(navigationDto.Icon);
                        txtparentid.Text = Convert.ToString(navigationDto.parentId);
                        txtsortorder.Text = Convert.ToString(navigationDto.SortOrder);
                        txtDescription.Text = Convert.ToString(navigationDto.Description);
                        chkbActive.Checked = navigationDto.bActive;
                        EnableDisableControl(false);
                    }
                }
            }
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            txtlabel.Enabled = v;
            txtroute.Enabled = v;
            txticon.Enabled = v;
            txtparentid.Enabled = v;
            txtsortorder.Enabled = v;
            txtDescription.Enabled = v;
            chkbActive.Enabled = v;
            btnSubmit.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtlabel.Text = "";
            hdNavNewId.Value = "";
            txtroute.Text = "";
            txticon.Text = "";
            txtparentid.Text = "";
            txtsortorder.Text = "";
            txtDescription.Text = "";
            chkbActive.Checked = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            hdNavNewId.Value = "0";
            BindNavigationRole(0);
            lbl4.Text = "Add Navigation";
            EnableDisableControl(true);
        }

        public void BindNavigationRole(int idNavigation)
        {
            NavigationDL objuserDL = new NavigationDL();
            ResponseDto obj = objuserDL.GetNavigationRole(idNavigation);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<RoleNavigationDto> userRoleDto = (List<RoleNavigationDto>)obj.Result;
                    if (userRoleDto != null)
                    {
                        lstRole.DataSource = userRoleDto;
                        lstRole.DataTextField = "sRoleName";
                        lstRole.DataValueField = "idRole";
                        lstRole.DataBind();
                        lstRole.Style.Add(HtmlTextWriterStyle.Height, (userRoleDto.Count * 20) +"px");
                    }

                    for (int i = 0; i < userRoleDto.Count; i++)
                        if (userRoleDto[i].idNavigation > 0)
                            lstRole.Items[i].Selected = true;
                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            NavigationDL objLoginDL = new NavigationDL();
            NavigationDto navigationDto = new NavigationDto();
            navigationDto.roles = new List<RoleNavigationDto>();
            navigationDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                navigationDto.idNavigation = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objLoginDL.InsertUpdateDeleteNavigation(navigationDto);
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
            NavigationDL objLoginDL = new NavigationDL();
            NavigationDto userDto = new NavigationDto();
            userDto.Label = txtlabel.Text;
            userDto.Route = txtroute.Text;
            userDto.Icon = txticon.Text;
            userDto.SortOrder = txtsortorder.Text;
            userDto.parentId = Convert.ToInt32(txtparentid.Text);
            userDto.Description = txtDescription.Text;
            userDto.bActive = chkbActive.Checked;
            if (!string.IsNullOrEmpty(hdNavNewId.Value))
            {
                userDto.idNavigation = Convert.ToInt32(hdNavNewId.Value);
            }
            userDto.roles = new List<RoleNavigationDto>();
            foreach (ListItem item in lstRole.Items)
            {
                if (item.Selected)
                {
                    userDto.roles.Add(new RoleNavigationDto { idRole = Convert.ToInt32(item.Value), idNavigation = Convert.ToInt32(hdNavNewId.Value) });
                }
            }
            ResponseDto response = objLoginDL.InsertUpdateDeleteNavigation(userDto);
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