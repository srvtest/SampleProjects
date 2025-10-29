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

namespace EcommerceWebsiteB2B
{
    public partial class verification : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request != null && Request.UrlReferrer != null)
                {
                    ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                }
                string Code = Request.QueryString["Username"].ToString();
                UserDL objUserDL = new UserDL();
                string verificationCode = CommonControl.Decrypt(Code);
                DataSet ds = objUserDL.GetVerificationCodeById(verificationCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    if (!string.IsNullOrEmpty(verificationCode))
                    {
                        if (objUserDL.UserVerification(verificationCode))
                        {
                            pnlFailed.Visible = false;
                            string EmailIdTo = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                            lblMessage.Text = "Your Email verified successfully.";
                            lblHMessage.Text = "Congratulation";

                            DataSet ds1 = objUserDL.GetAllClientMaster(GetCountryId());
                            string host = "", fromMail = "", password = "";
                            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                            {
                                host = Convert.ToString(ds1.Tables[0].Rows[0]["host"]);
                                fromMail = Convert.ToString(ds1.Tables[0].Rows[0]["fromEmail"]);
                                password = Convert.ToString(ds1.Tables[0].Rows[0]["password"]);
                            }
                            if (!string.IsNullOrEmpty(host) && !string.IsNullOrEmpty(fromMail) && !string.IsNullOrEmpty(password))
                            {
                                string URL = ConfigurationManager.AppSettings["RegistartionUrl"].ToString();
                                string Url = URL;
                                string emailTo = EmailIdTo;
                                string subject = "Registartion process";
                                string link = string.Empty;
                                link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>", Url.Trim());
                                keywordsToReplace.Add("##Name##", emailTo);
                                keywordsToReplace.Add("##Url##", Url);
                                string body = GenrateMail("Registartionprocess");
                                CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                            }

                            // Response.Redirect("login.aspx", true);
                        }
                        else
                        {
                            pnlSuccess.Visible = false;
                            lblMsg.Text = "Your Email verified links is Expired.";
                            lblHMsg.Text = "Error";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Your Email verified links is Expired.";
                        lblHMsg.Text = "Error";
                    }
                }
                else
                {
                    lblMsg.Text = "Your Email verified links is Expired.";
                    lblHMsg.Text = "Error";
                }

            }
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
            switch (mailType)
            {
                case "Registartionprocess":
                    contentFilePath = Server.MapPath("HTMLMail/Registartionprocess.html");
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
    }
}