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
    public partial class frmEventLogs : System.Web.UI.Page
    {
        EventLogDL objCityDL = new EventLogDL();
        List<EventLogDto> userDto
        {
            get
            {
                return (List<EventLogDto>)Session["EventLog"];
            }
            set
            {
                Session["EventLog"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "EventLog Details";
            lbl2.Text = "EventLog";
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
            ResponseDto obj = objCityDL.GetEventLog();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    userDto = (List<EventLogDto>)obj.Result;
                }
            }
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "Update")
            //{
            //lbl4.Text = "Edit City";
            //BindStateDropdown();
            //HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
            //ResponseDto response = objCityDL.GetCityById(Convert.ToInt32(e.CommandArgument));
            //if (response != null)
            //{
            //    ErrorLogDto userDto = (ErrorLogDto)response.Result;
            //    if (userDto != null)
            //    {
            //        ShowUserPanal(true);
            //        txtCityname.Text = userDto.CityName;
            //        ddlStateId.SelectedValue = Convert.ToString(userDto.StateID);
            //        chkme.Checked = userDto.bActive == 1 ? true : false;
            //        hdCityId.Value = Convert.ToString(userDto.CityId);
            //        EnableDisableControl(true);
            //    }
            //}
            //}
            //else
            //if (e.CommandName == "Delete")
            //{
            //    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
            //    if (hiddenField.Value != null)
            //    {
            //        hdnId.Value = hiddenField.Value;
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionDeleteData();", true);
            //    }
            //}
            //else
            //if (e.CommandName == "View")
            //{
            //    lbl4.Text = "View ErrorLogs";
            //    //BindStateDropdown();
            //    HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
            //    ResponseDto response = objCityDL.GetErrorLogById(Convert.ToInt32(e.CommandArgument));
            //    if (response != null)
            //    {
            //        ErrorLogDto userDto = (ErrorLogDto)response.Result;
            //        if (userDto != null)
            //        {
            //            ShowUserPanal(true);
            //            TextBox1.Text = userDto.Method;
            //            TextBox2.Text = userDto.ErrorMessage;
            //            TextBox3.Text = userDto.ErrorType;
            //            TextBox4.Text = userDto.dtCreated.ToString("yyyy-MM-dd");
            //            hdErrorLogsId.Value = Convert.ToString(userDto.idErrorLog);
            //            EnableDisableControl(false);
            //        }
            //    }
            //}
        }
        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            //TextBox1.Enabled = v;
            //TextBox2.Enabled = v;
            //TextBox3.Enabled = v;
            //TextBox4.Enabled = v;
            //btnSubmit.Enabled = v;
            //btnNew.Enabled = v;
        }
        private void ShowUserPanal(bool v)
        {
            //pnlUser.Visible = v;
            pnluserList.Visible = !v;
            //TextBox1.Text = "";
            //TextBox2.Text = "";
            //TextBox3.Text = "";
            //TextBox4.Text = "";
            hdEventLogId.Value = "";
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ShowUserPanal(false);
        //    EnableDisableControl(false);
        //}

        //protected void btnNew_Click(object sender, EventArgs e)
        //{
        //    lbl4.Text = "Add EventLog";
        //    ShowUserPanal(true);
        //    //BindStateDropdown();
        //    EnableDisableControl(true);
        //}
        //private void BindStateDropdown()
        //{
        //    DataSet dsState = objCityDL.GetAllState();
        //    ddlStateId.DataSource = dsState.Tables[0];
        //    ddlStateId.DataTextField = "sName";
        //    ddlStateId.DataValueField = "Id";
        //    ddlStateId.DataBind();
        //    ddlStateId.Items.Insert(0, new ListItem() { Text = "Select State", Value = "0" });
        //    BindDistrictDropdown(0);
        //}

        //protected void ddlStateId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindDistrictDropdown(Convert.ToInt32(ddlStateId.SelectedValue));
        //}
        //private void BindDistrictDropdown(int StateId)
        //{
        //    if (StateId > 0)
        //    {
        //        DataSet dsDistrict = objCityDL.GetDistictByStateId(StateId);
        //        ddlDistrict.DataSource = dsDistrict.Tables[0];
        //        ddlDistrict.DataTextField = "sName";
        //        ddlDistrict.DataValueField = "Id";
        //        ddlDistrict.DataBind();
        //    }
        //    ddlDistrict.Items.Insert(0, new ListItem() { Text = "Select District", Value = "0" });
        //}
        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    EventLogDto userDto = new EventLogDto();
        //    userDto.isDeleted = true;
        //    if (!string.IsNullOrEmpty(hdnId.Value))
        //    {
        //        userDto.idEventLog = Convert.ToInt32(hdnId.Value);
        //    }

        //    ResponseDto response = objCityDL.InsertUpdateDeleteEventLog(userDto);
        //    if (response != null)
        //    {
        //        if (response.StatusCode == 0)
        //        {
        //            LoadGridData();
        //            hdMessage.Value = response.Message;
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //        else
        //        {
        //            hdMessage.Value = response.Message;
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //    }
        //}
        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    EventLogDto userDto = new EventLogDto();
        //    userDto.MethodName = TextBox1.Text;
        //    userDto.Parameter = TextBox2.Text;
        //    userDto.ProcName = TextBox3.Text;
        //    userDto.dtCreated = Convert.ToDateTime(TextBox4.Text);
        //    if (!string.IsNullOrEmpty(hdEventLogId.Value))
        //    {
        //        userDto.idEventLog = Convert.ToInt32(hdEventLogId.Value);
        //    }

        //    ResponseDto response = objCityDL.InsertUpdateDeleteEventLog(userDto);
        //    if (response != null)
        //    {
        //        if (response.StatusCode == 0)
        //        {
        //            LoadGridData();
        //            hdMessage.Value = response.Message;
        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //        else
        //        {
        //            hdMessage.Value = response.Message;
        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
        //        }
        //    }
        //}

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userDto != null)
            {
                RptUser.DataSource = userDto.Take(Convert.ToInt32(ddlFilter.SelectedValue));
                RptUser.DataBind();
            }
        }
    }
}