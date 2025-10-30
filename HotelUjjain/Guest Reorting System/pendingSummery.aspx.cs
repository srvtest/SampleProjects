using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Guest_Reporting_System
{
    public partial class pendingSummery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuestMasterDL objuserDL = new GuestMasterDL();
                ResponseDto obj = objuserDL.GetPandingGuestSummeryByHotelId(Convert.ToInt32(Session["snsHotelId"]));
                if (obj != null)
                {
                    if (obj.StatusCode == 0)
                    {
                        List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                        if (userDto != null)
                        {
                            rptGuest.DataSource = userDto;
                            rptGuest.DataBind();
                        }
                    }
                }
            }
            string strFolderTemp;
            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
            foreach (var file in Directory.GetFiles(strFolderTemp.ToString()))
            {
                File.Delete(file);
            }
        }


        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitData.aspx");
        }

        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddGuest.aspx");
        }

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnsubmitDate");
                Response.Redirect("pendingReport.aspx?submitdate=" + UtilityFunction.Encrypt(Convert.ToString(hiddenField.Value)));
            }
            if (e.CommandName == "Submit")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnsubmitDate");
                HiddenField hiddenField1 = (HiddenField)e.Item.FindControl("hdnEmailId");
                Response.Redirect("SubmitData.aspx?submitdate=" + UtilityFunction.Encrypt(Convert.ToString(hiddenField.Value))+"&EmailId=" + 
                    UtilityFunction.Encrypt(Convert.ToString(hiddenField1.Value)));
            }
        }

        protected void rptGuest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                         e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = e.Item.FindControl("Button2") as Button;
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnsubmitDate");
                //string submitdate = Request.QueryString["submitdate"];
                //submitdate = UtilityFunction.Decrypt(submitdate);
                if (Convert.ToDateTime(hiddenField.Value) <= DateTime.Now.AddDays(-2))
                {
                    btn.Enabled = false;
                    //GuestMasterDL objuserDL = new GuestMasterDL();
                    //GuestFilterDto guestFilterDto = new GuestFilterDto();
                    //guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
                    //guestFilterDto.SubmitDate = Convert.ToDateTime(hiddenField.Value);
                    //guestFilterDto.SubmitBy = "Submit by system";
                    //ResponseDto response = objuserDL.SubmitGuestData(guestFilterDto);
                }
            }
        }
    }
}