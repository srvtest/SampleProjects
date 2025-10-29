using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using EntityLayer;
using DataLayer;

namespace HotalManagment
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static string SendEmail(String bcc, String Subj, string Message)
        {
            try
            {
                //Reading sender Email credential from web.config file  

                string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                string Pass = ConfigurationManager.AppSettings["Password"].ToString();

                //creating the object of MailMessage  
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
                mailMessage.Subject = Subj; //Subject of Email  
                mailMessage.Body = Message; //body or message of Email  
                mailMessage.IsBodyHtml = true;

                string[] bccid = bcc.Split(',');

                foreach (string bccEmailId in bccid)
                {
                    mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id  
                }
                SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

                //network and security related credentials  

                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = Pass;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage); //sending Email   
                return "Please check your email for set password";
            }
            catch (Exception e)
            {
                return e.Message.ToString();

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            int response = objHotalManagment.ConfirmationUserForForgotPassword(txtUsername.Text.Trim());
            if (response > 0)
            {
                string ResetPasswordURL = ConfigurationManager.AppSettings["ResetPasswordURL"].ToString();
                string Url = ResetPasswordURL + "?UserName="  + CommanClasses.Encrypt(txtUsername.Text.Trim());               
                string str = SendEmail(txtUsername.Text.Trim(), "Forgot Password", "<br>You are almost there!. To complete the process, please click on the link below to set password." + "<br>" + "<a href=" + Url + ">Click</a>");
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = str;
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "ShowMessageForm();", true);
                lblMessage.Text = "User not exists..";
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMessage.Text) && lblMessage.Text.Equals("Please check your email for set password"))
            {
                Response.Redirect("login.aspx");
            }
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MessageModel", "$('#MessageModel').modal('hide');", true);
        }
    }
}