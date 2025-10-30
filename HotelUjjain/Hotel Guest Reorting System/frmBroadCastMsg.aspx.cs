using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmBroadCastMsg : System.Web.UI.Page
    {
        BroadCastMsgDL objStateDl = new BroadCastMsgDL();
        ResourceManager rm;
        CultureInfo ci;
        List<BroadCastMsgDto> lstBroadCastMsgDto = new List<BroadCastMsgDto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Session["Lang"] = this.Master.Language;
            }
            lbl1.Text = "BroadCast Message Details";
            lbl2.Text = "BroadCast Message";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.State);
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
            ResponseDto obj = objStateDl.GetBroadCastMsg();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<BroadCastMsgDto> userDto = (List<BroadCastMsgDto>)obj.Result;
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
                lbl4.Text = "Edit BroadCast Message";
                //BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdBroadCastID");
                ResponseDto response = objStateDl.GetBroadCastMsgById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    BroadCastMsgDto userDto = (BroadCastMsgDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtMsg.Text=userDto.Msg;
                        txtDisplayFrom.Text=userDto.DisplayFrom.ToString("yyyy-MM-dd");
                        txtDisplayTo.Text=userDto.DisplayTo.ToString("yyyy-MM-dd");
                        hdBroadCastMsgId.Value = Convert.ToString(userDto.BroadCastMsgId);
                        chkme.Checked = userDto.bActive;
                        EnableDisableControl(true);
                        //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "ShowPopup('" + response.Message + "');", true);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdBroadCastID");
                if (hiddenField.Value != null)
                {
                    hdnId.Value = hiddenField.Value;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
                }
            }
            else if (e.CommandName == "View")
            {
                lbl4.Text = "View BroadCast Message";
                //BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdBroadCastID");
                ResponseDto response = objStateDl.GetBroadCastMsgById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    BroadCastMsgDto userDto = (BroadCastMsgDto)response.Result;
                    if (userDto != null)
                    {

                        ShowUserPanal(true);
                        txtMsg.Text = userDto.Msg;
                        txtDisplayFrom.Text = userDto.DisplayFrom.ToString("yyyy-MM-dd");
                        txtDisplayTo.Text = userDto.DisplayTo.ToString("yyyy-MM-dd");
                        hdBroadCastMsgId.Value = Convert.ToString(userDto.BroadCastMsgId);
                        chkme.Checked = userDto.bActive;
                        EnableDisableControl(false);
                        //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "ShowPopup('" + response.Message + "');", true);
                    }
                }
            }
        }

        private void EnableDisableControl(bool v)
        {
            txtMsg.Enabled = v;
            txtDisplayFrom.Enabled = v;
            txtDisplayTo.Enabled = v;
            chkme.Enabled = v;
            btnSubmit.Enabled = v;
        }

        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtMsg.Text = "";
            txtDisplayFrom.Text = "";
            txtDisplayTo.Text = "";
            hdBroadCastMsgId.Value = "";
            chkme.Checked = v;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lbl4.Text = "Add BroadCast Message";
            ShowUserPanal(true);
            EnableDisableControl(true);
        }

        
        protected void Button3_Click(object sender, EventArgs e)
        {
            BroadCastMsgDto userDto = new BroadCastMsgDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.BroadCastMsgId = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objStateDl.InsertUpdateDeleteBroadCastMsg(userDto);
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
            BroadCastMsgDto userDto = new BroadCastMsgDto();
            userDto.Msg=txtMsg.Text;
            userDto.DisplayFrom= Convert.ToDateTime(txtDisplayFrom.Text);
            userDto.DisplayTo= Convert.ToDateTime(txtDisplayTo.Text);
            userDto.bActive = chkme.Checked;
            if (!string.IsNullOrEmpty(hdBroadCastMsgId.Value))
            {
                userDto.BroadCastMsgId = Convert.ToInt32(hdBroadCastMsgId.Value);
            }

            ResponseDto response = objStateDl.InsertUpdateDeleteBroadCastMsg(userDto);
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