using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HotalManagment
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    lblUsername.Text = (string)(Session["UserName"]);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["Type"]!=null && Convert.ToInt32(Session["Type"]) == 1)
                {
                    hotelName.InnerText = "Hotel Managment";
                    idHotel.Visible = true;
                    idBookingSource.Visible = true;
                    idBookingSourceType.Visible = true;
                    idBookingType.Visible = true;
                    idBusinessSource.Visible = true;
                    idGSTSlab.Visible = true;
                    idLogo.Visible = true;
                    idLogo.Attributes["class"] = "icon-home";
                   
                }
                else
                {
                   
                    idCategory.Visible = true;
                    idRateType.Visible = true;
                    idRooms.Visible = true;
                    idItem.Visible = true;
                    idHouseKeeping.Visible = true;
                    idBookingItem.Visible = true;
                    if (Session["Hotelname"] != null && Session["Logo"] != null)
                    {
                        hotelName.InnerText = Convert.ToString(Session["Hotelname"]);
                        string HotelLogo = ConfigurationManager.AppSettings["HotelLogo"].ToString();
                       
                        imageLogo.Visible = true;
                        imageLogo.ImageUrl= HotelLogo.Replace(@"\\",@"\") + Convert.ToString(Session["Logo"]);
                        
                    }
                    idBooking.Visible = true;
                    idEnquiry.Visible = true;
                }
            }
        }
    }
}