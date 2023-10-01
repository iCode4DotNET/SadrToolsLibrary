using System;
using System.Linq;

namespace SadrTools.Extensions
{
    public static class GenericExt
    {
        /// <summary>
        /// چک کردن موجود بودن آیتم در لیست
        /// </summary>
        /// <typeparam name="T">نوع داده</typeparam>
        /// <param name="source">آیتم</param>
        /// <param name="list">لیست</param>
        /// <returns></returns>
        public static bool In<T>(this T source, params T[] list)
        {
            if (source == null)
                throw new Exception(CommonConsts.Messages.Exception.InvalidObject);
            return list.Contains(source);
        }

        /// <summary>
        /// چک کردن موجود بودن یک آیتم در یک رنج
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">آیتم</param>
        /// <param name="lower">حد پایین</param>
        /// <param name="upper">حد بالا</param>
        /// <returns></returns>
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
        }

    }

}