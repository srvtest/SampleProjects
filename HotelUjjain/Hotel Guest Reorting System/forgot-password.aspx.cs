using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System
{
    public partial class forgot_password : System.Web.UI.Page
    {
        string host = "", fromMail = "", password = "";
        //public string baseUrl
        //{
        //    get
        //    {
        //        return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoginDL objLoginDL = new LoginDL();
            UserDto userDto = new UserDto();
            userDto.Username = txtUserName.Text;
            ResponseDto response = objLoginDL.ForgotPassword(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    UserDto obj = (UserDto)response.Result;
                    Response.Redirect("reset-password.aspx" + "?idUser=" + obj.idUser);
                    hdMessage.Value += response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                }
                else
                {
                    hdMessage.Value += response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                }
            }
        }
    }
}