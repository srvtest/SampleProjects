using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;

namespace HotalManagment
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetHotalDetail();
            }
        }

        private void GetHotalDetail()
        {
            DL_HotalManagment objHotelManagment = new DL_HotalManagment();
            int HotelId = Convert.ToInt32(Session["UserId"]);
            DataSet ds= objHotelManagment.GetHotalById(HotelId);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    txtCheckoutTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["CheckOut"]);
                    txtLocationLink.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocationLink"]);    
                }
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotelManagment = new DL_HotalManagment();
            int HotelId = Convert.ToInt32(Session["UserId"]);
            hotelCls objHotelCls = new hotelCls();
            objHotelCls.Id = HotelId;
            objHotelCls.checkOut = txtCheckoutTime.Text;
            objHotelCls.LocationLink = txtLocationLink.Text;
            int  count= objHotelManagment.UpdateHotalById(objHotelCls);
            hdMessage.Value = "profile |";


            HttpCookie userInfo = new HttpCookie("travinitiesUserInfo");


            HttpCookie reqCookies = Request.Cookies["travinitiesUserInfo"];
            if (reqCookies != null)
            {
                string rdata = reqCookies["Rdata"].ToString();
                rdata = CommanClasses.Decrypt(rdata);
                Char delimiter = '~';
                String[] substrings = rdata.Split(delimiter);
                
                string str = Convert.ToString(Session["UserId"]) + "~" +
                    Convert.ToString(Session["UserName"]) + "~" +
                    Convert.ToString(Session["Type"]) + "~" +
                    Convert.ToString(Session["Message"]) + "~" +
                    Convert.ToString(Session["Hotelname"]) + "~" +
                    Convert.ToString(Session["Logo"]) + "~" +
                    Convert.ToString(Session["Address"]) + "~" +
                    Convert.ToString(substrings[7]) + "~" +
                    Convert.ToString(substrings[8]) + "~" +
                    Convert.ToString(txtLocationLink.Text);

                userInfo["Rdata"] = CommanClasses.Encrypt(str);
                userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                Response.Cookies.Add(userInfo);
            }



            

          
            hdMessage.Value += "Profile saved successfully";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        }


    }
}