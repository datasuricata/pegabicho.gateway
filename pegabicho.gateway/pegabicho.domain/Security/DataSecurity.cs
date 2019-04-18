using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Entities.Core.Users;
using System.Security.Cryptography;
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Security {
    public static class DataSecurity {

        public static AuthResponse InjectToken(this AuthResponse argument, string token) {
            argument.Token = token;
            return argument;
        }

        public static bool IsValid(User user, AuthPlataform plataform) {
            if (user == null)
                return false;

            switch (plataform) {
                case AuthPlataform.Client:
                    return false;
                case AuthPlataform.Customer:
                    return false;
                case AuthPlataform.Vitrine:
                    return false;
                case AuthPlataform.BackOffice:
                    return false;
                case AuthPlataform.Shadow:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// encrypt password with MD5 format encoding
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(this string password) {
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

        /// <summary>
        /// inject user into object context
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="user"></param>
        public static void InjectAccount<T>(this T obj, User user)
        {
            foreach (var x in obj.GetType().GetProperties())
                if (x.Name == "UserId")
                    if (x.GetValue(obj) == null)
                        x.SetValue(obj, user.Id);
        }
    }
}