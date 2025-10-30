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
    public partial class frmStateMaster : System.Web.UI.Page
    {
        StateDL objStateDl = new StateDL();
        ResourceManager rm;
        CultureInfo ci;
        List<StateDto> lstStateDto = new List<StateDto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Session["Lang"] = this.Master.Language;
            }
            lbl1.Text = "State Details";
            lbl2.Text = "State";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                NavigationDL navigationDL = new NavigationDL();
                bool isAccess = navigationDL.UserNavigationAccess(Convert.ToInt32(Session["UserId"]), (int)Navigation.State);
                if (!isAccess)
                    Response.Redirect("dashboard.aspx");
                LoadGridData();
                BindAllDropdown();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "QuestionAddData();", true);
        }

        public void LoadGridData()
        {
            ResponseDto obj = objStateDl.GetState();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<StateDto> userDto = (List<StateDto>)obj.Result;
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
                lbl4.Text = "Edit State";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objStateDl.GetStateById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    StateDto userDto = (StateDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        txtStatename.Text = userDto.stateName;
                        ddlCountryId.SelectedValue = Convert.ToString(userDto.CountryID);
                        hdStateId.Value = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        EnableDisableControl(true);
                        //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "ShowPopup('" + response.Message + "');", true);
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
                lbl4.Text = "View State";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdId");
                ResponseDto response = objStateDl.GetStateById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    StateDto userDto = (StateDto)response.Result;
                    if (userDto != null)
                    {
                        
                        ShowUserPanal(true);
                        txtStatename.Text = userDto.stateName;
                        ddlCountryId.SelectedValue = Convert.ToString(userDto.CountryID);
                        hdStateId.Value = Convert.ToString(userDto.StateID);
                        chkme.Checked = userDto.bActive == 1 ? true : false;
                        EnableDisableControl(false);
                        //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "ShowPopup('" + response.Message + "');", true);
                    }
                }
            }
        }

        private void EnableDisableControl(bool v)
        {
            //pnlUser.Visible = v;
            //pnluserList.Visible = !v;
            ddlCountryId.Enabled = v;
            txtStatename.Enabled= v;
            chkme.Enabled= v;
            btnSubmit.Enabled= v;
        }

        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            txtStatename.Text = "";
            //txtCountryId.Text = "";
            hdStateId.Value = "";
            ddlCountryId.SelectedIndex = -1;
            chkme.Checked = v;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
            EnableDisableControl(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            lbl4.Text = "Add State";
            ShowUserPanal(true);
            BindAllDropdown();
            EnableDisableControl(true);
        }

        private void BindAllDropdown()
        {
            DataSet dsCountry = objStateDl.GetAllCountry();
            ddlCountryId.DataSource = dsCountry.Tables[0];
            ddlCountryId.DataTextField = "sName";
            ddlCountryId.DataValueField = "Id";
            ddlCountryId.DataBind();
            ddlCountryId.Items.Insert(0, new ListItem() { Text = "Select Country", Value = "0" });



            //DataSet dsState = objStateDl.GetAllState();
            //DataTable dtState = dsState.Tables[1];
            //DataView StateDv = new DataView(dtState);
            //lstStateDto = StateDv.ToTable().BindListFromTable<StateDto>();

        }

        //private void LoadString()
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
        //    rm = new ResourceManager("Hotel_Guest_Reporting_System.App_GlobalResources.Lang", Assembly.GetExecutingAssembly()); //we configure resource manages for mapping with resource files in App_GlobalResources folder.
        //    ci = Thread.CurrentThread.CurrentCulture;
        //    //lblStateName.Text = rm.GetString("StateName", ci);
        //}

        protected void RptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lblStateName = e.Item.FindControl("lblStateName") as Label;
                Label lblCountryName = e.Item.FindControl("lblCountryName") as Label;
                Label lblAction = e.Item.FindControl("lblAction") as Label;

                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
                rm = new ResourceManager("Hotel_Guest_Reporting_System.App_GlobalResources.Lang", Assembly.GetExecutingAssembly()); //we configure resource manages for mapping with resource files in App_GlobalResources folder.
                ci = Thread.CurrentThread.CurrentCulture;
                lblStateName.Text = rm.GetString("State Name", ci);
                lblCountryName.Text = rm.GetString("Country Name", ci);
                lblAction.Text = rm.GetString("Action", ci);
                lbl1.Text = rm.GetString("State Details", ci);
                lbl2.Text = rm.GetString("State", ci);
                lbl3.Text = rm.GetString("State", ci);
                lbl4.Text = rm.GetString("Edit State", ci);
                btnNew.Text = rm.GetString("New", ci);
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button Button1 = e.Item.FindControl("Button1") as Button;
                Button Button2 = e.Item.FindControl("Button2") as Button;
                Label lblsName = e.Item.FindControl("lblsName") as Label;
                Label lblCName = e.Item.FindControl("lblCName") as Label;
                string StateName = lblsName.Text;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
                rm = new ResourceManager("Hotel_Guest_Reporting_System.App_GlobalResources.Lang", Assembly.GetExecutingAssembly()); //we configure resource manages for mapping with resource files in App_GlobalResources folder.
                ci = Thread.CurrentThread.CurrentCulture;
                Button1.Text = rm.GetString("Edit", ci);
                Button2.Text = rm.GetString("Delete", ci);
                //lblsName.Text = rm.GetString(""+ lstStateDto.Where(x=>x.stateName == lblsName.Text).FirstOrDefault() + "", ci);
                // lblsName.Text = rm.GetString(StateName, ci);
                lblCName.Text = rm.GetString("India", ci);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            StateDto userDto = new StateDto();
            userDto.isDeleted = true;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                userDto.StateID = Convert.ToInt32(hdnId.Value);
            }

            ResponseDto response = objStateDl.InsertUpdateDeleteState(userDto);
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
            StateDto userDto = new StateDto();
            userDto.stateName = txtStatename.Text;
            userDto.CountryID = Convert.ToInt32(ddlCountryId.SelectedValue);
            userDto.bActive = Convert.ToInt16(chkme.Checked ? 1 : 0);
            if (!string.IsNullOrEmpty(hdStateId.Value))
            {
                userDto.StateID = Convert.ToInt32(hdStateId.Value);
            }

            ResponseDto response = objStateDl.InsertUpdateDeleteState(userDto);
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