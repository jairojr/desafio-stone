using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Stone.Utils
{
    public static class EnumExtension
    {

        public static T ObterEnum<T>(string valor) where T : struct
        {
            T valorEnum;
            if (Enum.TryParse<T>(valor.ToString(), out valorEnum))
            {
                return valorEnum;
            }

            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description.ToLower() == valor.ToLower())
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == valor)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }
    }
}
