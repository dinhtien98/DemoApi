using System.Security.Cryptography;
using System.Text;
using System;

namespace DemoApi.Commons
{
    public class Common
    {
        public string FullName
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Avatar
        {
            get; set;
        }
        public static string ComputeHmacSHA256(string plainText,string key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText)));
            }
        }
    }
}
