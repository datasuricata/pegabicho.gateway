using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace begabicho.shared.Helpers
{
    public static class UtilSecurity
    {
        ///// <summary>
        ///// inject user into object context
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="user"></param>
        //public static void UserInjector<T>(this T obj, User user)
        //{
        //    foreach (var x in obj.GetType().GetProperties())
        //        if (x.Name == "UserId")
        //            if (x.GetValue(obj) == null)
        //                x.SetValue(obj, user.Id);
        //}

        /// <summary>
        /// encrypt password with MD5 format encoding
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(this string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            var hash = (password += "2sg68kf-fh56g-19ilf3-xvsg4y8aew");
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(hash));
            var builder = new StringBuilder();
            foreach (var x in data)
                builder.Append(x.ToString("x2"));
            return builder.ToString().ToUpper();
        }
    }
}
