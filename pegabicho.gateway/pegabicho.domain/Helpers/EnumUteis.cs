using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace pegabicho.domain.Helpers {
    public static class EnumUteis {
        public static string EnumDisplay(this Enum value) {
            DisplayAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
