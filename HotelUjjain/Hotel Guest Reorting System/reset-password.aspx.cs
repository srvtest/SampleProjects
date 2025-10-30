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
    public partial class reset_password : System.Web.UI.Page
    {
        public string idUser;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            idUser = Request.QueryString["idUser"];
            LoginDL objLoginDL = new LoginDL();
            UserDto userDto = new UserDto();
            userDto.idUser = Convert.ToInt32(idUser);
            userDto.password = txtPassword.Text;
            userDto.Newpassword = txtRepeatPassword.Text;
            ResponseDto response = objLoginDL.ResetPassword(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    Response.Redirect("login.aspx");
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