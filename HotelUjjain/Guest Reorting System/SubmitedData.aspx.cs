using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class SubmitedData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtfrom.Text = DateTime.Now.AddDays(-7).ToString("dd/MMM/yyyy");
                txtTo.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                btnsearch_Click(null, null);
            }
            string strFolderTemp;
            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
            foreach (var file in Directory.GetFiles(strFolderTemp.ToString()))
            {
                File.Delete(file);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
            guestFilterDto.FilterFromDate=Convert.ToDateTime(txtfrom.Text).ToString("dd/MMM/yyyy");
            guestFilterDto.FilterToDate = Convert.ToDateTime(txtTo.Text).ToString("dd/MMM/yyyy");

            ResponseDto obj = objuserDL.GetSubmitedGuestSummeryByHotelId(guestFilterDto);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                    if (userDto != null)
                    {
                        if (!chkShowReport.Checked)
                        {
                            userDto.RemoveAll(a => a.AddionalGuest == 0);

                        }
                            
                        rptGuest.DataSource = userDto;
                        rptGuest.DataBind();
                    }
                }
            }
        }

       

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnsubmitDate");
                string para = Convert.ToString(hiddenField.Value) + "$$"+ Convert.ToString(hiddenField.Value);


                Response.Redirect("ReportGuestDetail.aspx?para=" + UtilityFunction.Encrypt(para));
            }
        }

        protected void rptGuest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnAdd") as HiddenField;
                Button btn = e.Item.FindControl("btnDetails") as Button;
                if (hdnId.Value == "0")
                {
                    btn.Enabled = false;
                }
            }
        }


    }
}