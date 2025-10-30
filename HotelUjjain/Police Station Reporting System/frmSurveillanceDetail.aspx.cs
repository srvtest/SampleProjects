using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class frmSurveillanceDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowDetail();    
            }
        }

        private void ShowDetail()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["idsurveillance"]))
            {
                string idsurveillance = Request.QueryString["idsurveillance"];
                idsurveillance = UtilityFunction.Decrypt(idsurveillance);
                Loadsurveillance(idsurveillance);

            }
        }

        private void Loadsurveillance(string idsurveillance)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.GetSurveillanceDetail(Convert.ToInt32(idsurveillance));
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    List<UserNotificationDto> lst = (List<UserNotificationDto>)response.Result;
                    foreach (var item in lst)
                    {
                        item.smessage = item.smessage.Replace("होटल", "होटल </br>");
                    }                                 
                    rptSurveillance.DataSource = lst;
                    rptSurveillance.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
                }
            }
        }

        protected void rptSurveillance_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                HiddenField hdnidGuestMaster = (HiddenField)e.Item.FindControl("hdnidGuestMaster");
                Response.Redirect("GuestInformation.aspx?idGuestMaster=" + UtilityFunction.Encrypt(Convert.ToString(hdnidGuestMaster.Value)));
            }
            else if (e.CommandName == "Action")
            {
                HiddenField hdnidUserNotification = (HiddenField)e.Item.FindControl("hdnidUserNotification");
                hdnIds.Value = hdnidUserNotification.Value;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "SaveGuestData();", true);
            }
        }

        protected void rptSurveillance_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                      e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIsRead") as HiddenField;
                Button btn = e.Item.FindControl("Button2") as Button;
                btn.Visible = !(Convert.ToString(hdnId.Value) == "True");

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.SetSurveillanceAction(Convert.ToInt32(hdnIds.Value));
            ShowDetail();
        }
    }
}