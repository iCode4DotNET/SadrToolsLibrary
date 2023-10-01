using System.Collections;
using System;
using SadrTools.CommonConsts;

namespace SadrTools.Extensions
{
    public static class ObjectExt
    {

        public static byte ToByte(this object obj)
        {
            bool isParsed = byte.TryParse(obj.ToString(), out byte number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToInt);
        }

        public static short ToShort(this object obj)
        {
            bool isParsed = short.TryParse(obj.ToString(), out short number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToInt);
        }

        public static int ToInt(this object obj)
        {
            bool isParsed = int.TryParse(obj.ToString(), out int number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToInt);
        }

        public static long ToLong(this object obj)
        {
            bool isParsed = long.TryParse(obj.ToString(), out long number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToInt);
        }

        public static float ToFloat(this object obj)
        {
            bool isParsed = float.TryParse(obj.ToString(), out float number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToFloat);
        }

        public static double ToDouble(this object obj)
        {
            bool isParsed = double.TryParse(obj.ToString(), out double number);
            if (isParsed)
                return number;
            throw new Exception(Messages.Exception.ToFloat);
        }

        public static ArrayList GetPeroperties(this object obj)
        {
            System.Reflection.PropertyInfo[] PropertyInfos;
            ArrayList Result = new ArrayList();
            Type AType = obj.GetType();
            PropertyInfos = AType.GetProperties();
            for (int i = 0; i < PropertyInfos.Length; i++)
            {
                Result.Add(PropertyInfos[i]);
            }
            return Result;
        }
    }
}