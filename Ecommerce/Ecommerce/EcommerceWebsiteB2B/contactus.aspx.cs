using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsiteB2B
{
    public partial class contactus : System.Web.UI.Page
    {
        string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            // string subject = txtSubject.Text;
            if (!IsPostBack)
            {
                GetMasterPageById();

                resetControl();
                //frmMasterPage.Style.Add("display", "none");
            }
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtEmail.Text = "";
           // txtPhoneNo.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
        }
        private void GetMasterPageById()
        {
            string Id = hdnContactUsId.Value;
            //HiddenField hdnAboutUsId = e.Item.FindControl("hdnAboutUsId") as HiddenField;
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetMasterPageById(Convert.ToInt16(Id));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                content = (ds.Tables[0].Rows[0]["sContent"]).ToString();
                lstContactUs.DataSource = ds.Tables[0];
                lstContactUs.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                string Pass = ConfigurationManager.AppSettings["Password"].ToString();
                string emailTo = txtEmail.Text;
                //creating the object of MailMessage  
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
                mailMessage.To.Add(new MailAddress(emailTo));
                mailMessage.Subject = txtSubject.Text; //Subject of Email  
                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendFormat("<html>");
                mailBody.AppendFormat("<title>");
                mailBody.AppendFormat("Hello");
                mailBody.AppendFormat("</title>");
                mailBody.AppendFormat("<body>");
                mailBody.AppendFormat("<p>");
                mailBody.AppendFormat(txtName.Text);
                mailBody.AppendFormat("</p>");
                mailBody.AppendFormat("<p>");
                mailBody.AppendFormat(txtEmail.Text);
                mailBody.AppendFormat("</p>");
                //mailBody.AppendFormat("<p>");
                //mailBody.AppendFormat(txtPhoneNo.Text);
                //mailBody.AppendFormat("</p>");
                mailBody.AppendFormat("<p>");
                mailBody.AppendFormat(txtMessage.Text);
                mailBody.AppendFormat("</p>");
                mailBody.AppendFormat("</body>");
                mailBody.AppendFormat("</html>");
                mailMessage.Body = Convert.ToString(mailBody); //body or message of Email  
                mailMessage.IsBodyHtml = true;
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
                smtp.Send(mailMessage);
                resetControl();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lstContactUs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string abc = content;
            string[] username = content.Split('/');
        }

        protected void lstContactUs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string abc = content;
            string[] username = content.Split('<','>','p','/','\r','\n',';');
        }
    }
}