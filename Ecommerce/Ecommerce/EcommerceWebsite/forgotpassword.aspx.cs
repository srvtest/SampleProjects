using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgetpass_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            if (objUserDL.ValidateUser(txtUserName.Text.Trim()))
            {
                DataSet ds = objUserDL.GetAllClientMaster(GetCountryId());
                string host = "", fromMail = "", password = "";
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    host = Convert.ToString(ds.Tables[0].Rows[0]["host"]);
                    fromMail = Convert.ToString(ds.Tables[0].Rows[0]["fromEmail"]);
                    password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                }
               
                if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(fromMail) && !string.IsNullOrEmpty(password))
                {
                    string ResetPasswordURL = ConfigurationManager.AppSettings["ResetPasswordURL"].ToString();
                    string Url = ResetPasswordURL + "?UserName=" + CommonControl.Encrypt(txtUserName.Text.Trim());
                    string emailTo = txtUserName.Text.Trim();
                    string subject = "ForgotPassword";                    

                    // Code to send mail
                    string link = string.Empty;
                    link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>", Url.Trim());
                    keywordsToReplace.Add("##Vipul##", emailTo);
                    keywordsToReplace.Add("##Url##", Url);

                    string body = GenrateMail("ForgotPassword");
                    string str = CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                    lblMsg.Text = str;
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                    lblMsg.Text = "Host, From mail and Password not found.";
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMsg.Text = "User does not exist.";
            }
        }

        private int GetCountryId()
        {
            int value = 0;
            HttpCookie reqCookies = Request.Cookies["WebInfo"];
            if (reqCookies != null)
            {
                string rdata = reqCookies["idCountry"].ToString();
                value = Convert.ToInt32(CommonControl.Decrypt(rdata));
            }
            return value;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMsg.Text) && lblMsg.Text.Equals("Please check your email for set password"))
            {
                Response.Redirect("login.aspx");
            }
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
            switch (mailType)
            {
                case "ForgotPassword":
                    contentFilePath = Server.MapPath("HTMLMail/ForgotPassword.html");
                    //StreamReader reader = File.OpenText(path);
                    //contentFilePath = "~/";
                    break;
                default:
                    break;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.File.ReadAllText(contentFilePath));
            foreach (string keyword in keywordsToReplace)
            {
                sb.Replace(keyword, keywordsToReplace.Get(keyword));
            }
            return sb.ToString();
        }
    }
}