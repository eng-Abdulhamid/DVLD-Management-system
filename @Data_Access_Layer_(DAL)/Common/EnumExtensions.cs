using System;
using System.ComponentModel;
using System.Reflection;

namespace DVLD.DAL.Common
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null)
            {
                return value.ToString();
            }

            DescriptionAttribute attribute =
                Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}