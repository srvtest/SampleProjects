using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoginDL objLoginDL = new LoginDL();
            UserDto userDto = new UserDto();
            userDto.Username = txtUsername.Text;
            ResponseDto response = objLoginDL.ForgotPassword(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    UserDto obj = (UserDto)response.Result;
                    Response.Redirect("changepassword.aspx" + "?idUser=" + obj.idUser);
                    //hdMessage.Value += response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                }
                else
                {
                    //hdMessage.Value += response.Message;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                }
            }
        }
    }
}