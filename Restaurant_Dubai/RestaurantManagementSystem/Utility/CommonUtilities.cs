using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Utility
{ 
    public static class CommonEnums
    {
        public enum Roles
        {
            Admin = 1,
            RestaurantAdmin = 2,
            Staff = 3,
            Agent = 4
        }

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
        public static Object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }

    
        public static String SendEmail(string emailTo, string subject, string body)
        {
            try
            {
                string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                string Pass = ConfigurationManager.AppSettings["Password"].ToString();

                //var verifyUrl = "/User/" + emailFor + "/" + activationCode;
                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

                //var fromEmail = new MailAddress("dotnetawesome@gmail.com", "Dotnet Awesome");
                //var toEmail = new MailAddress(emailID);
                //var fromEmailPassword = "******"; // Replace with actual password

                //string subject = "";
                //string body = "";
                //if (emailFor == "VerifyAccount")
                //{
                //    subject = "Your account is successfully created!";
                //    body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                //        " successfully created. Please click on the below link to verify your account" +
                //        " <br/><br/><a href='" + link + "'>" + link + "</a> ";
                //}
                //else if (emailFor == "ResetPassword")
                //{
                //    subject = "Reset Password";
                //    body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
                //        "<br/><br/><a href=" + link + ">Reset Password link</a>";
                //}


                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FromEmailid, Pass)
                };

                using (var message = new MailMessage(FromEmailid, emailTo)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
                ////Reading sender Email credential from web.config file  

                //string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                //string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                //string Pass = ConfigurationManager.AppSettings["Password"].ToString();

                ////creating the object of MailMessage  
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
                //mailMessage.To.Add(new MailAddress(emailTo));
                //mailMessage.Subject = suject; //Subject of Email  
                //mailMessage.Body = body; //body or message of Email  
                //mailMessage.IsBodyHtml = true;

                //string[] emails = emailTo.Split(',');

                //foreach (string email in emails)
                //{
                //    mailMessage.Bcc.Add(new MailAddress(email)); //Adding Multiple BCC email Id  
                //}
                //SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                //smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

                ////network and security related credentials  

                //smtp.EnableSsl = true;
                //NetworkCredential NetworkCred = new NetworkCredential();
                //NetworkCred.UserName = mailMessage.From.Address;
                //NetworkCred.Password = Pass;
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 587;
                //smtp.Send(mailMessage); //sending Email   
                return ("Mail sent successfully.");
            }
            catch (Exception e)
            {
                return (e.Message.ToString());
            }
            // return "";
        }
        public static double Distance(double lat1, double lon1, double lat2, double lon2, string unit)
        {
            var radlat1 = Math.PI * lat1 / 180;
            var radlat2 = Math.PI * lat2 / 180;
            var theta = lon1 - lon2;
            var radtheta = Math.PI * theta / 180;
            var dist = Math.Sin(radlat1) * Math.Sin(radlat2) + Math.Cos(radlat1) * Math.Cos(radlat2) * Math.Cos(radtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            if (unit == "M")
            {
                dist = (dist * 1.609344) * 1000;
            }
            else
            {
                dist = (dist * 1.609344);
            }
            return dist;
        }

        public enum MessageType
        {
            success,
            danger,
            warning,
            info
        }

    }
    public static class CryptoEngine
    {
        public static string Encrypt(string input)
        {// how to call
         //Here key is of 128 bit  
         //Key should be either of 128 bit or of 192 bit  
         //  Ciphertext.Text = CryptoEngine.Encrypt(plaintext.Text, "sblw-3hn8-sqoy19");
         // decryptedtext.Text = CryptoEngine.Decrypt(Ciphertext.Text, "sblw-3hn8-sqoy19");
            string key = ConfigurationManager.AppSettings["CryptoFormat"].ToString();
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input)
        {
            // how to call 
            //Key shpuld be same for encryption and decryption  
            // decryptedtext.Text = CryptoEngine.Decrypt(Ciphertext.Text, "sblw-3hn8-sqoy19");
            string key = ConfigurationManager.AppSettings["CryptoFormat"].ToString();

            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
