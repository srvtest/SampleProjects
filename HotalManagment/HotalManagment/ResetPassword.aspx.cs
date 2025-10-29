using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataLayer;
using System.Data;

namespace HotalManagment
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string UserName = Request.QueryString["UserName"];
            if (!string.IsNullOrEmpty(UserName))
            {
                string recData = CommanClasses.Decrypt(UserName);
                DL_HotalManagment objHotalManagment = new DL_HotalManagment();
                AdminCls admin = new AdminCls();
                admin.Username = recData;
                admin.Password = CommanClasses.Encrypt(txtPassword.Text.Trim());
                int response = objHotalManagment.ForgotPassword(admin);
                if (response > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                    lblMessage.Text = "Password set successfully";
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                    lblMessage.Text = "Password not set,Please try again";
                }

            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMessage.Text) && lblMessage.Text.Equals("Password set successfully"))
            {
                Response.Redirect("login.aspx");
            }
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MessageModel", "$('#MessageModel').modal('hide');", true);
        }
    }
}