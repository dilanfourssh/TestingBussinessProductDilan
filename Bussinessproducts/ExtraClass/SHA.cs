using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bussinessproducts.ExtraClass
{
    public class SHA
    {
        public static string GenerateSHA256String(string inputString) // string type return method
        {
            byte[] hash = null; //create null byte array
            try
            {
                SHA256 sha256 = SHA256Managed.Create();// call sha256 object
                byte[] bytes = Encoding.UTF8.GetBytes(inputString); // get string to byte array
                hash = sha256.ComputeHash(bytes); //call HashAlgorithm with parameter byte array
            }
            catch (Exception)
            {
            }
            return GetStringFromHash(hash);//call method with parameter hash array return string

        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder(); // create object stringBuilder class it is defalt method
            try
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2")); //string should be formatted in Hexadecimal and plus result
                }
            }
            catch (Exception)
            {
            }
            return result.ToString(); //result is convert to normal string
        }
    }
}