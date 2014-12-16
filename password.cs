using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Security.Cryptography;

/// <summary>
///passwordHelp 的摘要说明
/// </summary>
/// 

namespace Common
{
    public class passwordHelp
    {
        public passwordHelp()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            data = MD5.Create().ComputeHash(data);
            return GetString(data);
        }
        private static string GetString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int b in data)
            {
                sb.Append(String.Format("{0:X}", b).PadLeft(2, '0'));
            }
            return sb.ToString();
        }
    }
}
