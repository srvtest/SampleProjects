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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            AdminCls admin = new AdminCls();
            admin.Username = Convert.ToString(Session["UserName"]);
            admin.Password = CommanClasses.Encrypt(txtpassword.Text.Trim());
            admin.NewPassword = CommanClasses.Encrypt(txtNewPassword.Text.Trim());
            DataSet ds = objHotalManagment.ChangePassword(admin);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hdMessage .Value= ds.Tables[0].Rows[0]["sMsg"].ToString();
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                txtpassword.Text = "";
                txtNewPassword.Text = "";
                txtReInsertPassword.Text = "";
            }
        }
    }
}