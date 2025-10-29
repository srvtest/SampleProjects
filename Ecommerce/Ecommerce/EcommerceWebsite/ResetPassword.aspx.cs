using DataLayer;
using EntityLayer;
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
    public partial class ResetPassword : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UserName = Request.QueryString["UserName"];
                if (!string.IsNullOrEmpty(UserName))
                {
                    UserDL objUserDL = new UserDL();
                    string recData = CommonControl.Decrypt(UserName);
                    if (!objUserDL.ValidateUser(recData))
                    {
                        Response.Redirect("login.aspx", true);
                    }
                }
                else
                    Response.Redirect("login.aspx", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserName = Request.QueryString["UserName"];
            if (!string.IsNullOrEmpty(UserName))
            {
                string recData = CommonControl.Decrypt(UserName);
                UserDL objUserDL = new UserDL();
                CustomerCls objCustomerCls = new CustomerCls();
                objCustomerCls.Username = recData;
                objCustomerCls.Password = CommonControl.SHA256Encryption(txtPassword.Text.Trim());
                int response = objUserDL.ResetPassword(recData, CommonControl.SHA256Encryption(txtPassword.Text.Trim()));

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
                    //string ResetPasswordURL = ConfigurationManager.AppSettings["ResetPasswordURL"].ToString();
                    //string Url = ResetPasswordURL + "?UserName=" + CommonControl.Encrypt(txtUserName.Text.Trim());
                    string emailTo = recData;
                    string subject = "ChangedPassword";
                    // Code to send mail
                    string link = string.Empty;
                    //link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>");
                    keywordsToReplace.Add("##Vipul##", emailTo);

                    string body = GenrateMail("ChangedPassword");
                    //string str = CommonControl.SendEmail(txtUserName.Text.Trim(), "Forgot Password", "<br>You are almost there!. To complete the process, please click on the link below to set password." + "<br>" + "<a href=" + Url + ">" + Url + "</a>", host, fromMail, password);
                    CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }

                if (response > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                    lblMsg.Text = "Password set successfully";
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                    lblMsg.Text = "Password not set,Please try again";
                }

            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMsg.Text) && lblMsg.Text.Equals("Password set successfully"))
            {
                Response.Redirect("login.aspx",true);
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

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
            switch (mailType)
            {
                case "ChangedPassword":
                    contentFilePath = Server.MapPath("HTMLMail/PasswordChange.html");
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