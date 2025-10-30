using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entity
{
    public static class UtilityFunction
    {

        public static string ToXML(this object obj)
        {
            string xml = string.Empty;
            try
            {
                System.IO.TextWriter sw = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                xml = sw.ToString();
                sw.Close();
                return xml;
            }
            catch (Exception ex)
            {
                xml = ex.Message + Convert.ToString(ex.InnerException);
                return xml;
            }
        }
        public static string Decrypt(string encryptText)
        {
            if (!string.IsNullOrEmpty(encryptText))
            {
                string encryptionkey = "SAUW193BX628TD57";
                byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));
                PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
                using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
                {
                    using (MemoryStream mstrm = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                        {
                            byte[] plainText = new byte[encryptedData.Length];
                            int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                            return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                        }
                    }
                }
            }
            else
            {
                return "";
            }
        }
        public static string Encrypt(string inputText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }
        //public static string SendEmail(string emailTo, string suject, string body)
        //{
        //    try
        //    {
        //        //Reading sender Email credential from web.config file  

        //        string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
        //        string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
        //        string Pass = ConfigurationManager.AppSettings["Password"].ToString();

        //        //creating the object of MailMessage  
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
        //        mailMessage.To.Add(new MailAddress(emailTo));
        //        mailMessage.Subject = suject; //Subject of Email  
        //        mailMessage.Body = body; //body or message of Email  
        //        mailMessage.IsBodyHtml = true;

        //        string[] emails = emailTo.Split(',');

        //        foreach (string email in emails)
        //        {
        //            mailMessage.Bcc.Add(new MailAddress(email)); //Adding Multiple BCC email Id  
        //        }
        //        SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
        //        smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

        //        //network and security related credentials  

        //        smtp.EnableSsl = true;
        //        NetworkCredential NetworkCred = new NetworkCredential();
        //        NetworkCred.UserName = mailMessage.From.Address;
        //        NetworkCred.Password = Pass;
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = NetworkCred;
        //        smtp.Port = 587;
        //        //smtp.DeliveryMethod= SmtpDeliveryMethod.Network; 
        //        //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
        //        smtp.Send(mailMessage); //sending Email   
        //        return "Mail sent successfully.";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
        //    }
        //    return "";
        //}
        public static string SendSMS(string message, string numbers, string TemplateId)
        {
            string url = "http://sms.bulksmsind.in/v2/sendSMS?username=amanshivhare&message=" + message + "&sendername=FANTCL&smstype=TRANS&numbers=" + numbers + "&apikey=ad7c2f00-c152-43d5-8984-e62c353aeba5&peid=1201161743317422401&templateid=" + TemplateId + "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();
            return "";
        }
        public static DateTime CurrentDateTime()
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
            return indianTime;
        }
        public static T FromXML<T>(this string obj)
        {
            System.IO.TextReader sw = new StringReader(obj);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(sw);
        }
        public static List<T> BindListFromTable<T>(this DataTable dt)
        {
            List<T> lstItems = new List<T>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T item = (T)Activator.CreateInstance(typeof(T), new object[] { dt.Rows[i] });
                    lstItems.Add(item);
                }
                return lstItems;
            }
            catch (Exception)
            {
                return lstItems;
            }
        }
        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile, string password=null)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {

            }
        }
        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void DecryptFile(string inputFile, string outputFile, string password = null)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();

        }
        public static string Encrypt(this string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            //tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(this string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            //tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #region Send Email
        public static string SendEmail(String bcc, String Subj, string Message, string[] attachmentPath)
        {
            try
            {
                //Reading sender Email credential from web.config file  

                //string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                //string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
                //string Pass = ConfigurationManager.AppSettings["Password"].ToString();
                string host = ConfigurationManager.AppSettings["Host"].ToString();
                string fromMail = ConfigurationManager.AppSettings["FromMail"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                //creating the object of MailMessage  
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(fromMail); //From Email Id  
                mailMessage.To.Add(new MailAddress(bcc));
                mailMessage.Subject = Subj; //Subject of Email  
                mailMessage.Body = Message; //body or message of Email  
                mailMessage.IsBodyHtml = true;
                foreach (var item in attachmentPath)
                {
                    Attachment attachment = new Attachment(item);
                    mailMessage.Attachments.Add(attachment);
                }


                string[] bccid = bcc.Split(',');

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
