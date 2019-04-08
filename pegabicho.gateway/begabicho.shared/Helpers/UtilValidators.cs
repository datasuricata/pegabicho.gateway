using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace begabicho.shared.Helpers
{
    public static class UtilValidators
    {
        public static double? IsDoubleUpdateable(double? prop1, double? prop2)
        {
            if (prop1 == 0 || prop2 == 0)
                return 0;
            if (!prop2.Equals(prop1))
                return prop2;
            return prop1;
        }

        public static decimal? IsDecimalUpdateable(decimal? prop1, decimal? prop2)
        {
            if (prop1 == 0 || prop2 == 0)
                return 0;
            if (!prop2.Equals(prop1))
                return prop2;
            return prop1;
        }

        public static int IsIntUpdateable(int prop1, int prop2)
        {
            if (prop2 == 0)
                return prop1;

            if (!prop2.Equals(prop1))
                return prop2;

            return prop1;
        }

        public static bool IsCpfValid(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }

        public static bool IsCnpjValid(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool IsUpdateable(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;

            return !obj2.Equals(obj1);
        }

        public static string IsStringUpdateable(string prop1, string prop2)
        {
            if (string.IsNullOrEmpty(prop1) || string.IsNullOrEmpty(prop2))
                return prop1;

            if (!prop2.ToUpper().Equals(prop1.ToUpper()))
                return prop2;

            return prop1;
        }

        public static DateTimeOffset IsDateUpdateable(DateTimeOffset date1, DateTimeOffset date2)
        {
            if (string.IsNullOrEmpty(date1.ToString()) || string.IsNullOrEmpty(date2.ToString()))
                return date1;

            if (!date2.Equals(date1))
                return date2;

            return date1;
        }

        public static Enum IsEnumUpdateable(Enum enum1, Enum enum2)
        {
            if (string.IsNullOrEmpty(GetEnumDescription(enum1)) || string.IsNullOrEmpty(GetEnumDescription(enum2)))
                return enum1;

            if (!enum2.Equals(enum1))
                return enum2;

            return enum1;
        }

        public static string GetEnumDescription(Enum value)
        {
            DisplayAttribute attribute = value.GetType()
           .GetField(value.ToString())
           .GetCustomAttributes(typeof(DisplayAttribute), false)
           .SingleOrDefault() as DisplayAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            var text = Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);

            text = text.Replace(".", "");

            return text;
        }

        public static string RemoveAccents(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        /// <summary>
        /// generic object validator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns></returns>
        public static T IsEntityUpdateable<T>(this T entity1, T entity2) //TODO make perfect
        {
            if (entity1 == null || entity2 == null)
                return entity1;

            if (!entity1.Equals(entity2))
                return entity2;

            return entity1;
        }
    }
}
