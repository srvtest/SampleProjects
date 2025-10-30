using Entity;
using System;
using System.Collections.Generic;
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
    public partial class mainHome : System.Web.UI.MasterPage
    {
        ResourceManager rm;
        CultureInfo ci;

        public string Language
        {
            get
            {                
                return (string)Session["Lang"];
            }
            set
            {
                Session["Lang"] = value;
            }
        }
        public string baseUrl
        {
            get
            {
                return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionUpdate = false;
            if (Session["UserId"] == null)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    string rdata = reqCookies["Rdata"].ToString();
                    string dData = UtilityFunction.Decrypt(rdata);
                    string[] words = dData.Split('~');
                    if (words.Count() == 2)
                    {
                        int strUserId = Convert.ToInt32(words[0]);
                        string strUserName = words[1];
                        Session["UserId"] = strUserId;
                        Session["UserName"] = strUserName;
                        isSessionUpdate = true;
                        //lblFullName.Text = strUserName;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
               // lblName.Text = (string)(Session["UserName"]);
                lblFullName.Text = (string)(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                if (Language == null)
                {
                    Language = Request.UserLanguages[0];
                }
                else
                {
                    //ddLang.SelectedValue = Language;
                }
                if (isSessionUpdate) Response.Redirect(Request.RawUrl);
                //LoadString();

                //hotalName1.InnerText = (string)(Session["UserName"]);
                //idMessage.InnerText = Convert.ToString(Session["Message"]);
                //if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
                //{
                //    //hotelName.InnerText = "Hotel Managment";
                //    idHotel.Visible = true;
                //    idBookingSource.Visible = true;
                //    idBookingSourceType.Visible = true;

                //    idPlan.Visible = true;
                //    idPlanHotel.Visible = true;
                //    //idLogo.Visible = true;
                //    //idLogo.Attributes["class"] = "icon-home";

                //    isAdmin1.Visible = false;
                //    isAdmin2.Visible = false;
                //    isAdmin3.Visible = false;
                //    isAdmin1.Visible = false;
                //    idsetting.Visible = true;

                //    idRoomPlans.Visible = true;
                //}
                //else
                //{
                //    idReport.Visible = true;
                //    idCategory.Visible = true;
                //    idRateType.Visible = true;
                //    idRooms.Visible = true;
                //    idItem.Visible = true;
                //    idHouseKeeping.Visible = true;
                //    idBookingItem.Visible = true;
                //    idTaxSlab.Visible = true;
                //    idGSTSlab.Visible = true;
                //    idPreBooking.Visible = true;
                //    idRoomPlans.Visible = false;
                //    idExpanseHead.Visible = true;
                //    idExpanse.Visible = true;
                //    idTransection.Visible = true;
                //    idUpdateInventory.Visible = true;
                //    if (Session["Hotelname"] != null && Session["Logo"] != null)
                //    {
                //        HotalName2.InnerText = Convert.ToString(Session["Hotelname"]);
                //        string HotelLogo = ConfigurationManager.AppSettings["HotelLogo"].ToString();

                //        imageLogo.Visible = true;
                //        imageLogo.ImageUrl = HotelLogo.Replace(@"\\", @"\") + Convert.ToString(Session["Logo"]);
                //        imgLogo1.Visible = true;
                //        imgLogo1.ImageUrl = HotelLogo.Replace(@"\\", @"\") + Convert.ToString(Session["Logo"]);

                //    }
                //    idBooking.Visible = true;
                //    // idEnquiry.Visible = true;
                //    idExpressCheckout.Visible = true;
                //    idsetting.Visible = false;

                //}

            }

        }

        protected void ddLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Language = ddLang.SelectedValue;
            LoadString();
            Response.Redirect(Request.RawUrl);
        }
        private void LoadString()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Language.ToString());
            rm = new ResourceManager("Hotel_Guest_Reporting_System.App_GlobalResources.Lang", Assembly.GetExecutingAssembly()); //we configure resource manages for mapping with resource files in App_GlobalResources folder.
            ci = Thread.CurrentThread.CurrentCulture;

            lblFullName.Text = rm.GetString("Admin", ci);
        }
    }
}