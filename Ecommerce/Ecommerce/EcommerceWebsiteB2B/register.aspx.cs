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

namespace EcommerceWebsiteB2B
{
    public partial class register : System.Web.UI.Page
    {
        NameValueCollection keywordsToReplace = new NameValueCollection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    if (Request != null && Request.UrlReferrer != null)
                    {
                        ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                    }
                    Request.Url.GetLeftPart(UriPartial.Authority);
                }
            }
        }

        protected void btnrSubmit_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerCls objCustomerCls = new CustomerCls();
            String pass = CommonControl.SHA256Encryption(txtRPassword.Text);
            objCustomerCls.sName = txtRname.Text.Trim();
            objCustomerCls.Email = txtREmail.Text.Trim();
            objCustomerCls.Password = pass;
            objCustomerCls.VerificationCode = Convert.ToString(Guid.NewGuid());
            // string VerificationCode = Convert.ToString(Guid.NewGuid());
            objCustomerCls.idCountry = GetCountryId();
            int ResponseData = objUserDL.RegisterCustomer(objCustomerCls);
            if (ResponseData > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "ShowMessage", "showAlertMessage('success','You registered successfully.');", true);
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
                    string ResetPasswordURL = ConfigurationManager.AppSettings["VerificationURL"].ToString();
                    string Url = ResetPasswordURL + "?UserName=" + CommonControl.Encrypt(objCustomerCls.VerificationCode);
                    string emailTo = txtREmail.Text.Trim();
                    string subject = "Verification";
                    // Code to send mail
                    string link = string.Empty;
                    //link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>", Url.Trim());
                    keywordsToReplace.Add("##Name##", emailTo);
                    keywordsToReplace.Add("##Url##", Url);
                    string body = GenrateMail("Verification");
                    string str = CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }
                //Session["CustomerId"] = CommonControl.Encrypt(Convert.ToString(ResponseData));
                if (Convert.ToInt16(hdnCheckbox.Value) == 1)
                {
                    this.Master.SubscribeEmail(txtREmail.Text.Trim());
                }
                Response.Redirect("~/index.aspx");
            }
            else if (ResponseData == 0)
            {
                lblMessage.Text = "You are already registered. Please log in.";
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
            switch (mailType)
            {
                case "Verification":
                    contentFilePath = Server.MapPath("HTMLMail/Verification.html");
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