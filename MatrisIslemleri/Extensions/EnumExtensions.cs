﻿using System.ComponentModel;
using System.Reflection;

namespace MatrisIslemleri.Extensions
{
    internal static class EnumExtensions
    {
        public static string DescriptionDegeriniBulma(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes != null && attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }
}
