using illumiyaFramework.Entities;
using illumiyaFramework.Enums;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace illumiyaFramework.Crypto
{
    public static class Crypto
    {
        private const string EncryptionKey = "A2L9A11LEAR2021";
        private const string EncryptionSplitter = "#^#";

        public static string CheckSum(string input)
        {
            var checkSum = string.Empty;
            try
            {
                // step 1, calculate MD5 hash from input
                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                checkSum = sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return checkSum;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "";

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cipherText;
        }

        public const int OWNER_TOKEN_KEYS_COUNT = 3;
        public static string EncryptOwherToken(int id, string name)
        {
            try
            {
                var cipherText = new StringBuilder();
                cipherText.Append(EncryptionSplitter);
                cipherText.Append(id);
                cipherText.Append(EncryptionSplitter);
                cipherText.Append(name);

                var encryptedKey = Encrypt(cipherText.ToString());
                return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(encryptedKey));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DecryptOwherToken(string cipherText, out OwherToken owherToken)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cipherText))
                {

                    var encryptedKey = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(cipherText));
                    var encrypted = Decrypt(encryptedKey);
                    if (string.IsNullOrEmpty(encrypted)) { throw new FormatException("cipherText cannot be Decrypted"); }
                    var split = encrypted.Split(EncryptionSplitter);
                    if (split.Length == OWNER_TOKEN_KEYS_COUNT)
                    {
                        owherToken = new OwherToken()
                        {
                            UserId = int.Parse(split[1]),
                            Name = split[2]
                        };
                    }
                    else { throw new Exception($"DecryptOwherToken failed, split.Length is {split.Length},it is not equle to encrypted key items"); }
                }
                else { owherToken = null; }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
