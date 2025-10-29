using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblName.Text = Session["UserName"].ToString();
            hdUserId.Value = Session["UserId"].ToString();
            hdUserName.Value = Session["UserName"].ToString();
            hdCurrentPassword.Value = Session["Password"].ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //frmChangedPassword.Style.Add("display", "none");
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                AdminDL objAdmin = new AdminDL();
                AdminCls objAdminCls = new AdminCls();
                hdMessage.Value = "Change Password |";
                lblMess.Text = hdMessage.Value;
                objAdminCls.Username = Convert.ToString(hdUserName.Value);
                objAdminCls.idAdmin = Convert.ToInt32(hdUserId.Value);
                objAdminCls.Password = CommonControl.SHA256Encryption(txtPassword.Text);
                string CurrentPassword = CommonControl.SHA256Encryption(txtCurrentPassword.Text);
                objAdminCls.ConfirmPassword = CommonControl.SHA256Encryption(txtConfirmPassword.Text);
                int Respon = 0;
                if (hdCurrentPassword.Value == CurrentPassword)
                {
                    Respon = objAdmin.AdminChangePassword(objAdminCls);
                }
                else
                {
                    Respon = 0;
                }
                
                if (Respon > 0)
                {
                    hdMessage.Value += "Change Passwordh Successfully";
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
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