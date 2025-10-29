using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Timers;
using EntityLayer;

namespace HotalManagment
{
    public partial class Main1 : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionUpdate = false;
            if (Session["UserId"] == null)
            {
                HttpCookie reqCookies = Request.Cookies["travinitiesUserInfo"];
                if (reqCookies != null)
                {
                    string rdata = reqCookies["Rdata"].ToString();
                    string dData = CommanClasses.Decrypt(rdata);
                    string[] words = dData.Split('~');
                    if (words.Count()==10)
                    {
                        int strUserId = Convert.ToInt32(words[0]);
                        string strUserName = words[1];
                        int strType = Convert.ToInt32(words[2]);
                        string strMessage = words[3];
                        string strHotelname = words[4];
                        string strLogo = words[5];
                        string strAddress = words[6];

                        Session["UserId"] = strUserId;
                        Session["UserName"] = strUserName;
                        Session["Type"] = strType;
                        Session["Message"] = strMessage;
                        Session["Hotelname"] = strHotelname;
                        Session["Logo"] = strLogo;
                        Session["Address"] = strAddress;
                        isSessionUpdate = true;
                        //Response.Redirect(Request.RawUrl);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                hotalName1.InnerText = (string)(Session["UserName"]);
            }
            if (!IsPostBack)
            {
                if (isSessionUpdate) Response.Redirect(Request.RawUrl); 


                //if (Session["UserId"] != null)
                //{
                //    hotalName1.InnerText = (string)(Session["UserName"]);
                //}
                //else
                //{
                //    HttpCookie reqCookies = Request.Cookies["userInfo"];
                //    if (reqCookies != null)
                //    {
                //        string rdata = reqCookies["Rdata"].ToString();
                //        string dData = CommanClasses.Decrypt(rdata);
                //        string[] words = dData.Split('~');
                //        if (words.Count() == 8)
                //        {
                //            int strUserId = Convert.ToInt32(words[0]);
                //            string strUserName = words[1];
                //            int strType = Convert.ToInt32(words[2]);
                //            string strMessage = words[3];
                //            string strHotelname = words[4];
                //            string strLogo = words[5];
                //            string strAddress = words[6];

                //            Session["UserId"] = strUserId;
                //            Session["UserName"] = strUserName;
                //            Session["Type"] = strType;
                //            Session["Message"] = strMessage;
                //            Session["Hotelname"] = strHotelname;
                //            Session["Logo"] = strLogo;
                //            Session["Address"] = strAddress;
                //            Response.Redirect(Request.RawUrl);
                //        }
                //    }
                //    else
                //    {
                //        Response.Redirect("Login.aspx");
                //    }
                //}

                hotalName1.InnerText = (string)(Session["UserName"]);
                idMessage.InnerText = Convert.ToString(Session["Message"]);
                if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
                {
                    //hotelName.InnerText = "Hotel Managment";
                    idHotel.Visible = true;
                    idBookingSource.Visible = true;
                    idBookingSourceType.Visible = true;

                    idPlan.Visible = true;
                    idPlanHotel.Visible = true;
                    //idLogo.Visible = true;
                    //idLogo.Attributes["class"] = "icon-home";

                    isAdmin1.Visible = false;
                    isAdmin2.Visible = false;
                    isAdmin3.Visible = false;
                    isAdmin1.Visible = false;
                    idsetting.Visible = true;

                    idRoomPlans.Visible = true;
                    //idChannelpartner.Visible = true;
                }
                else
                {
                    idReport.Visible = true;
                    idCategory.Visible = true;
                    idRateType.Visible = true;
                    idRooms.Visible = true;
                    idItem.Visible = false;
                    idHouseKeeping.Visible = false;
                    idBookingItem.Visible = true;
                    idTaxSlab.Visible = false;
                    idGSTSlab.Visible = false;
                    idPreBooking.Visible = true;
                    idRoomPlans.Visible = false;
                    idExpanseHead.Visible = false;
                    idExpanse.Visible = false;
                    idTransection.Visible = true;
                    idUpdateInventory.Visible = true;
                    if (Session["Hotelname"] != null && Session["Logo"] != null)
                    {
                        HotalName2.InnerText = Convert.ToString(Session["Hotelname"]);
                        string HotelLogo = ConfigurationManager.AppSettings["HotelLogo"].ToString();

                        imageLogo.Visible = true;
                        imageLogo.ImageUrl = HotelLogo.Replace(@"\\", @"\") + Convert.ToString(Session["Logo"]);
                        imgLogo1.Visible = true;
                        imgLogo1.ImageUrl = HotelLogo.Replace(@"\\", @"\") + Convert.ToString(Session["Logo"]);

                    }
                    idBooking.Visible = true;
                    // idEnquiry.Visible = true;
                    idExpressCheckout.Visible = true;
                    idsetting.Visible = false;

                }
               
            }
        }

        public void OnTimer(Object source, ElapsedEventArgs e)
        {
            int strUserId = 0;
            string strUserName = "";
            int strType = 0;
            string strMessage = "";
            string strHotelname = "";
            string strLogo = "";
            string strAddress = "";


            if (strUserId == 0)
                strUserId = (int)(Session["UserId"]);

            if (string.IsNullOrEmpty(strUserName))
                strUserName = (string)(Session["UserName"]);

            if (strType == 0)
                strType = (int)(Session["Type"]);

            if (string.IsNullOrEmpty(strMessage))
                strMessage = (string)(Session["Message"]);

            if (string.IsNullOrEmpty(strHotelname))
                strHotelname = (string)(Session["Hotelname"]);

            if (string.IsNullOrEmpty(strLogo))
                strLogo = (string)(Session["Logo"]);

            if (string.IsNullOrEmpty(strAddress))
                strAddress = (string)(Session["Address"]);

            //Session.Clear();
            //Session["UserId"] = strUserId;
            //Session["UserName"] = strUserName;
            //Session["Type"] = strType;
            //Session["Message"] = strMessage;
            //Session["Hotelname"] = strHotelname;
            //Session["Logo"] = strLogo;
            //Session["Address"] = strAddress;
        }
    }
}