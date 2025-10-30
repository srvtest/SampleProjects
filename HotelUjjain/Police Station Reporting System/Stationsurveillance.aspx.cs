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
    public partial class Stationsurveillance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadsurveillance();
            }
        }

        private void Loadsurveillance()
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.GetSurveillanceTrace(Convert.ToInt32(Session["UserId"]));
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            SurveillanceDL surveillanceDL = new SurveillanceDL();
            ResponseDto response = surveillanceDL.SetSurveillanceAction(Convert.ToInt32(hdnIds.Value));
            Response.Redirect("Stationsurveillance.aspx");

        }
    }
}