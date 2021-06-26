using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BugTracker
{
    class Hash
    {
        //hash function
        public static string StringtoSha256hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //string to bytearray - hashed
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                //back to string
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
    }
}
