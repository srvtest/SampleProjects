using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btmLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtpassword.Text))
            {
                AdminDL objAdminCls = new AdminDL();
                hdMessage.Value = "Login |";
                String pass = CommonControl.SHA256Encryption(txtpassword.Text);
                DataSet ds = objAdminCls.AdminLogin(txtUserName.Text, pass);
                if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    hdMessage.Value += "LoginSuccessfully";
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                    Session["UserId"] = ds.Tables[0].Rows[0][0];
                    Session["Name"] = ds.Tables[0].Rows[0]["sName"];
                    Session["UserName"] = ds.Tables[0].Rows[0]["Username"];
                    Session["Password"] = ds.Tables[0].Rows[0]["Password"];
                    Response.Redirect("Dashboard.aspx");

                }
                else
                {
                    hdMessage.Value += "No active user exist.";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "ClosePopup", "Errormsg();", true);
                  
                }
            }
        }
    }
}