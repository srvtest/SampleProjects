using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataLayer
{
    public static class UtilityFunctionDL
    {
        #region Send Email
        public static string SendEmail(String ToEmail, String Subj, string Message, string[] attachmentPath,string cc,string host, string fromMail, string password,string Con)
        {
            SendEmailDto obj = new SendEmailDto();
            try
            {
                //Reading sender Email credential from web.config file  

                //string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                //string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                //string Pass = ConfigurationManager.AppSettings["Password"].ToString();
              
                //creating the object of MailMessage  
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromMail); //From Email Id  
                mailMessage.To.Add(new MailAddress(ToEmail));
                mailMessage.CC.Add(new MailAddress(cc));
                mailMessage.Subject = Subj; //Subject of Email  
                mailMessage.Body = Message; //body or message of Email  
                mailMessage.IsBodyHtml = true;
                foreach (var item in attachmentPath)
                {
                    Attachment attachment = new Attachment(item);
                    mailMessage.Attachments.Add(attachment);
                }


                string[] bccid = ToEmail.Split(',');

                foreach (string bccEmailId in bccid)
                {
                    mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id  
                }
                SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                smtp.Host = host;              //host of emailaddress for example smtp.gmail.com etc  

                //network and security related credentials  

                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage); //sending Email
                
                /////
                ///
                obj.ToEmailId = ToEmail;
                obj.Subject = Subj;
                obj.Message = Message;
                SendEmailDL objuserDL = new SendEmailDL();
                ResponseDto response = objuserDL.InsertUpdateDeleteSendEmail(obj, Con);
                if (response != null)
                {
                    SendEmailDto hotelDto = (SendEmailDto)response.Result;
                    if (hotelDto != null)
                    {
                    }
                }
                ///


                return "Please check your email.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();

            }

        }
        #endregion
    }
}
