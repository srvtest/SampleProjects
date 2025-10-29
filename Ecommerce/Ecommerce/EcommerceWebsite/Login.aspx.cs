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
    public partial class Login : System.Web.UI.Page
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
                Request.Url.GetLeftPart(UriPartial.Authority);
                //string abc = Request.Url.Query.ToString();
                //string[] username = abc.Split('=');
                //for (int i = 0; i <= 3; i++)
                //{
                //    if (username[0] == "")
                //    {
                //        //string user = CommonControl.Decrypt(username[1]);
                //        //Verificationrequest(user);
                //    }
                //    else if (username[0] != "")
                //    {
                //        string user = CommonControl.Decrypt(username[1]);
                //        Verificationrequest(user);
                //    }
                //}
            }
        }

        //private void Verificationrequest(string user)
        //{
        //    UserDL objUserDL = new UserDL();
        //    CustomerCls objCustomerCls = new CustomerCls();
        //    objCustomerCls.Username = user;
        //    objCustomerCls.isEmailVerified = "1";
        //    int ResponseData = objUserDL.VerifyCustomer(objCustomerCls);
        //    if (ResponseData > 0)
        //    {
        //        Session["CustomerId"] = CommonControl.Encrypt(Convert.ToString(ResponseData));
        //        Response.Redirect("Home");
        //    }
        //    else if (ResponseData == 0)
        //    {
        //        lblMessage.Text = "You are already registered. Please log in.";
        //    }
        //}

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
                    string Url = ResetPasswordURL + "?UserName-" + CommonControl.Encrypt(objCustomerCls.VerificationCode);
                    string emailTo = txtREmail.Text.Trim();
                    string subject = "Verification";
                    // Code to send mail
                    string link = string.Empty;
                    //link = string.Format("<a href=\"{0}\" target=\"_blank\">GET STARTED</a>", Url.Trim());
                    keywordsToReplace.Add("##Vipul##", emailTo);
                    keywordsToReplace.Add("##Url##", Url);
                    string body = GenrateMail("Verification");
                    string str = CommonControl.SendEmail(emailTo, subject, body, host, fromMail, password);
                }
                //Session["CustomerId"] = CommonControl.Encrypt(Convert.ToString(ResponseData));
                Response.Redirect("Home");
            }
            else if (ResponseData == 0)
            {
                lblMessage.Text = "You are already registered. Please log in.";
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserDL objUserDL = new UserDL();
            CustomerCls objCustomerCls = new CustomerCls();
            String pass = CommonControl.SHA256Encryption(txtlpassword.Text);
            objCustomerCls.Email = txtLEmail.Text.Trim();
            objCustomerCls.Password = pass;
            DataSet ds = objUserDL.LoginCustomer(objCustomerCls);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["idCustomer"]) == "0")
                {
                    lblMessage.Text = "Your email address or password is incorrect.";
                }
                else if (Convert.ToString(ds.Tables[0].Rows[0]["isEmailVerified"]) == "")
                {
                    lblMessage.Text = "Your email address is not Verified.";
                }
                else 
                {
                    Session["CustomerId"] = CommonControl.Encrypt(Convert.ToString(ds.Tables[0].Rows[0]["idCustomer"]));
                    this.Master.SetCountry(Convert.ToInt32(ds.Tables[0].Rows[0]["idCountry"]));
                    if (ViewState["PreviousPage"] != null)
                    {
                        Response.Redirect(Convert.ToString(ViewState["PreviousPage"]));
                    }
                    else
                    {
                        Response.Redirect("Home");
                    }
                }
            }
            else
            {
                lblMessage.Text = "Your email address or password is incorrect.";
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
            //if (!string.IsNullOrEmpty(lblMsg.Text) && lblMsg.Text.Equals("Password set successfully"))
            //{
            //    Response.Redirect("login.aspx", true);
            //}
        }

        private string GenrateMail(string mailType)
        {
            string contentFilePath = string.Empty;
            var path = "";
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