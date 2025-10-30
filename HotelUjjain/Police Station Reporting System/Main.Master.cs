using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionUpdate = false;
            if (Session["snsHotelId"] == null)
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
                    lblHotelNameMini.InnerText = (string)(Session["UserName"]);
                    lblHotelName.InnerText = (string)(Session["UserName"]);
                    txt_username.InnerText = (string)(Session["UserName"]);
                    Span1.InnerText = (string)(Session["UserName"]);
                    titName.Text = (string)(Session["UserName"]);
                }
                else
                {
                    Response.Redirect("PolicestationLogin.aspx");
                }
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now);
                //Session.Clear();
                //Response.Redirect("PolicestationLogin.aspx");
            }
            else
            {
                lblHotelNameMini.InnerText = (string)(Session["UserName"]);
                lblHotelName.InnerText = (string)(Session["UserName"]);
                txt_username.InnerText = (string)(Session["UserName"]);
                Span1.InnerText = (string)(Session["UserName"]);
                titName.Text = (string)(Session["UserName"]);
            }
        }
    }
}