using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class HotelMain : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionUpdate = false;
            if (Session["snsHotelId"] == null)
            {
                //HttpCookie reqCookies = Request.Cookies["hotelInfo"];
                //if (reqCookies != null)
                //{
                //    string rdata = reqCookies["RdataHotel"].ToString();
                //    string dData = UtilityFunction.Decrypt(rdata);
                //    string[] words = dData.Split('~');
                //    if (words.Count() == 4)
                //    {
                //        int strUserId = Convert.ToInt32(words[0]);
                //        string strUserName = words[1];
                //        string strHotelContact = words[2];
                //        string strHotelAddress = words[3];
                //        Session["snsHotelId"] = strUserId;
                //        Session["snsHotelName"] = strUserName;
                //        Session["snsHotelContact"] = strHotelContact;
                //        Session["snsHotelAddress"] = strHotelAddress;
                //        isSessionUpdate = true;
                //        //lblFullName.Text = strUserName;
                //    }
                //}
                //else
                //{
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now);
                Session.Clear();
                Response.Redirect("HotelLogin.aspx");
                //}
            }
            else
            {
                lblHotelNameMini.InnerText = (string)(Session["snsHotelName"]);
                lblHotelName.InnerText = (string)(Session["snsHotelName"]);
                hdnContact.Value= (string)(Session["snsHotelContact"]);
                hdnAddress.Value = (string)(Session["snsHotelAddress"]);
                txt_username.InnerText = (string)(Session["snsHotelName"]);
                Span1.InnerText = (string)(Session["snsHotelName"]);
                titName.Text = (string)(Session["snsHotelName"]);
            }
        }
    }
}