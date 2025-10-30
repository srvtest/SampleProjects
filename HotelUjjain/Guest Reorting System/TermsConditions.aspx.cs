using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class TermsConditions : System.Web.UI.Page
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
                        //ViewState["NoOfRoom"] = hotelDto.NoOfRoom;
                        lblEmailId.InnerText = hotelDto.EmailAddress;
                        lblName.InnerText = hotelDto.CityName + "," + hotelDto.DistrictName+"("+ hotelDto.stateName+")";
                    }
                }


            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}