using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class HotelLogin : System.Web.UI.Page
    {
        private int MobileOTP = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDL objLoginDL = new LoginDL();
            UserDto userDto = new UserDto();
            userDto.Username = txtUserName.Text;
            userDto.password = txtPassword.Text;
            ResponseDto response = objLoginDL.ValidateUserLogin(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    UserDto user = (UserDto)response.Result;
                    if (user != null)
                    {
                        Session["UserId"] = user.idUser;
                        Session["UserName"] = user.Name;
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        string str = Convert.ToString(Session["UserId"]) + "~" +
                                Convert.ToString(Session["UserName"]);

                        userInfo["Rdata"] = UtilityFunction.Encrypt(str);
                        userInfo.Expires.Add(new TimeSpan(20, 0, 0));
                        Response.Cookies.Add(userInfo);

                        Response.Redirect("Dashboard.aspx");
                    }
                }
                else
                {

                }
            }
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            Random generator = new Random(); 
            MobileOTP= generator.Next(100000, 1000000);
        }
    }
}