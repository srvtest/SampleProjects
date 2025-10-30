using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HotelMasterDL objuserDL = new HotelMasterDL();
                ResponseDto response = objuserDL.GetHotelById(Convert.ToInt32(Session["snsHotelId"]));
                if (response != null)
                {
                    HotelMasterDto hotelDto = (HotelMasterDto)response.Result;
                    if (hotelDto != null)
                    {
                        ViewState["NoOfRoom"] = hotelDto.NoOfRoom;
                        lblValidUpTo.InnerText = hotelDto.ValidUpto.ToString("dd-MMMM-yyyy");
                    }
                }               
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
            guestFilterDto.SubmitDate = DateTime.Now;
            ResponseDto response = objuserDL.SubmitGuestData(guestFilterDto);
            if (response.StatusCode == 0)
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }

        }

        protected void btnStandard_Click(object sender, EventArgs e)
        {
            string sURL = string.Empty;

            if (Convert.ToInt32(ViewState["NoOfRoom"]) <= 10)
            {
                sURL = ConfigurationManager.AppSettings["propertyTypeAll2500"].ToString();
            }
            else if (Convert.ToInt32(ViewState["NoOfRoom"]) <= 35)
            {
                sURL = ConfigurationManager.AppSettings["propertyHotel3500"].ToString();
            }
            else
            {
                sURL = ConfigurationManager.AppSettings["propertyHotel5500"].ToString();
            }
            Response.Redirect(sURL, true);
        }
    }
}