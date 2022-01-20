using System;
using System.Globalization;
namespace SadrTools.CommonTools.Utility
{
    public static class DateMethods
    {
        /// <summary>
        /// تبدیل به تاریخ شمسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <param name="seprator">جدا کننده</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToPersianDate(DateTime date, char seprator = '/')
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            return $"{year}{seprator}{month.ToString().PadLeft(2, '0')}{seprator}{day.ToString().PadLeft(2, '0')}";
        }
    }
}
