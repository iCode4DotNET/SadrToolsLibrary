using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SadrTools.Extensions
{
    public static class EnumExt
    {
        /// <summary>
        /// تمام مقادیر در قالب یک لیست
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<T> EnumToList<T>(this Enum value)
        {
            Type enumType = value.GetType();

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException(CommonConsts.Messages.Exception.InvalidObject);

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>();

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        /// <summary>
        /// توضیحات 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}