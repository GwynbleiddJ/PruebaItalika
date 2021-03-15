using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Italika
{
    public enum Tipo
    {
        Trabajo,
        Deportiva,
        Infantil
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.CustomAttributes.Count() == 0)
            {
                return value.ToString();
            }
            else
            {
                var attribute = (DisplayAttribute)
                    fieldInfo.GetCustomAttribute(typeof(DisplayAttribute));
                return attribute.Name;
            }
        }
    }
}