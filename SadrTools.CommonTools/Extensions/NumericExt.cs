using System;

namespace SadrTools.Extensions
{
    public static class NumericExt
    {
        public static string GetFileSize(this long size)
        {
            if (size < 1024) { return (size).ToString("F0") + " bytes"; }
            if (size < Math.Pow(1024, 2)) { return (size / 1024).ToString("F0") + "KB"; }
            if (size < Math.Pow(1024, 3)) { return (size / Math.Pow(1024, 2)).ToString("F0") + "MB"; }
            if (size < Math.Pow(1024, 4)) { return (size / Math.Pow(1024, 3)).ToString("F0") + "GB"; }
            if (size < Math.Pow(1024, 5)) { return (size / Math.Pow(1024, 4)).ToString("F0") + "TB"; }
            if (size < Math.Pow(1024, 6)) { return (size / Math.Pow(1024, 5)).ToString("F0") + "PB"; }
            return (size / Math.Pow(1024, 6)).ToString("F0") + "EB";
        }

        public static double PercentageOf(this double number, double percent)
        {
            return (number * percent / 100);
        }

        public static int PercentageOf(this int number, double percent)
        {
            return (number * percent / 100).ToInt();
        }

        /// <summary>
        /// آیا این عدد ضریبی از هزار میباشد
        /// </summary>
        public static bool IsDivisibleByThousand(this int number)
        {
            return (number % 1000 == 0);
        }

    }

}
