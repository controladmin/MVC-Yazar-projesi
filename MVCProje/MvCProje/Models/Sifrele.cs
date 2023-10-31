using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography; // MD% sınıfını kullanabilmek için ekledik
using System.Text; // sınıfını kullanabilmek için ekledik
using System.Web;
using System.Web.Helpers; // Crypto sınıfını kullanabilmek için ekledik

namespace MvCProje.Models
{
    public class Sifrele
    {
        public static string MD5Crypto(string sifre)
        {
            MD5 md5 = MD5.Create();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sifre));
            byte[] result = md5.Hash;
            StringBuilder _builder = new StringBuilder();
            for(int i=0;i<result.Length;i++)
            {
                _builder.Append(result[i].ToString("x2"));
            }
            return _builder.ToString();
        }
        public static string MD5Crypto1(string sifre)
        {
            return Crypto.Hash(sifre, "MD5");
        }
    }
}