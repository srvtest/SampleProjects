using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DLUtility
    {
        public string SHA256Encryption(string strtext)
        {
            // Create a SHA256
            SHA256 sha256 = SHA256.Create();
            // ComputeHash - returns byte array
            byte[] _bytePassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(strtext));

            // Convert byte array to a string   
            int i;
            StringBuilder sbOutput = new StringBuilder(_bytePassword.Length);
            for (i = 0; i < _bytePassword.Length; i++)
            {
                //build string array from byte array
                sbOutput.Append(_bytePassword[i].ToString("X2"));//"X2" is used to convert byte array to string
            }
            return sbOutput.ToString();
        }
    }
}
