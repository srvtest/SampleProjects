using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class subscribePlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MobileNo = Request.QueryString["MobileNo"];
            HotelMasterDL objHotelDL = new HotelMasterDL();
            ResponseDto res = objHotelDL.GetHotelByMobileNumber(MobileNo);
            if (res != null)
            {
                HotelMasterDto hotelDto = (HotelMasterDto)res.Result;
                if (hotelDto != null)
                {
                    lblHotelName.Text = hotelDto.HotelName;
                    lblMobileNo.Text = hotelDto.Contact;
                    lblNoRoom.Text = Convert.ToString(hotelDto.NoOfRoom);
                    ViewState["NoOfRoom"] = hotelDto.NoOfRoom;
                    if (hotelDto.NoOfRoom <= 10)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel2500Value"].ToString();
                    }
                    else if (hotelDto.NoOfRoom <= 35)
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel3500Value"].ToString();
                    }
                    else
                    {
                        lblSubAmount.InnerText = ConfigurationManager.AppSettings["propertyHotel5500Value"].ToString();
                    }
                }
            }
        }

        protected void btnStandard_Click(object sender, EventArgs e)
        {
            string sURL = string.Empty;
            //if (Convert.ToString(ViewState["PropertyType"]).ToUpper() == "HOTEL")
            //{
            //    sURL = ConfigurationManager.AppSettings["propertyHotel5500"].ToString();
            //    Response.Redirect(sURL, true);
            //}
            //else
            //{
            //    sURL = ConfigurationManager.AppSettings["propertyTypeAll2500"].ToString();
            //    Response.Redirect(sURL, true);
            //}
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

        protected void btnBasic_Click(object sender, EventArgs e)
        {
            string sURL = string.Empty;
            if (Convert.ToString(ViewState["PropertyType"]).ToUpper() == "HOTEL")
            {
                sURL = ConfigurationManager.AppSettings["propertyHotel3500"].ToString();
                Response.Redirect(sURL, true);
            }
            else
            {
                sURL = ConfigurationManager.AppSettings["propertyTypeAllTest"].ToString();
                Response.Redirect(sURL, true);
            }
        }

    }
}