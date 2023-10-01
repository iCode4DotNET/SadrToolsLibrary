using SadrTools.Utility;
using System;

namespace SadrTools.Extensions
{
    public static class DateTimeExt
    {
        public static bool IsToday(this DateTime date)
        {
            var today = DateTime.Now.Date;
            return date.Year == today.Year && date.Month == today.Month && date.Day == today.Day;
        }


        /// <summary>
        /// تاریخ میلادی به شمسی
        /// </summary>
        /// <param name="date">تاریخ میلادی</param>
        /// <param name="seprator">جدا کننده</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToPersianDate(this DateTime date, char seprator = '/')
        {
            var pc = new System.Globalization.PersianCalendar();
            var year = pc.GetYear(date);
            var month = pc.GetMonth(date);
            var day = pc.GetDayOfMonth(date);
            return $"{year}{seprator}{month.ToString().PadLeft(2, '0')}{seprator}{day.ToString().PadLeft(2, '0')}";
        }

        /// <summary>
        /// تاریخ میلادی به عبارت فارسی و خوانای تاریخ شمسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static string ToPersianText(this DateTime date)
        {
            var persianDate = date.ToPersianDate();
            var year = persianDate.Substring(0, 4);
            var month = persianDate.Substring(5, 2);
            var day = persianDate.Substring(8, 2);

            day = DateMethods.DayName(day);
            month = DateMethods.MonthName(month);
            year = year.NumberToPersianText();

            return $"{day} {month} {CommonConsts.Names.Month} {CommonConsts.Names.Year} {year} ";

        }

        /// <summary>
        /// تاریخ میلادی به عبارت فارسی و خوانای تاریخ شمسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static string ToPersianTextFull(this DateTime date)
        {
            return $"{CommonConsts.Names.Today} {date.ToPersianDayOfWeek()} {date.ToPersianText()}";
        }

        /// <summary>
        /// تاریخ امروز به شمسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <param name="seprator">جدا کننده</param>
        /// <returns></returns>
        public static string Today(this DateTime date, char seprator = '/')
        {
            // Remove unused parameter 'date' if it is not part of a shipped public API"
            return DateTime.Now.ToPersianDate(seprator);
        }

        /// <summary>
        /// محاسبه چقدر از زمان مورد نظر گذشته است
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static string ToTimeAgo(this DateTime date)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double totalSec = ts.TotalSeconds;

            if (totalSec < 60)
                return ts.Seconds == 1 ? " یک ثانیه قبل " : ts.Seconds + " ثانیه قبل ";

            if (totalSec < 120)
                return " یک دقیقه قبل ";

            if (totalSec < 2700) // کمتر از 45 دقیقه
                return ts.Minutes + " دقیقه قبل ";

            if (totalSec < 5400) // کمتر از یک ساعت و نیم
                return " یک ساعت قبل ";

            if (totalSec < 86400) // کمتر از یک روز
                return ts.Hours + " ساعت قبل ";

            if (totalSec < 172800) // کمتر از 48 ساعت
                return " دیروز ";

            if (totalSec < 2592000) // کمتر از ماه
                return ts.Days + " روز قبل ";

            if (totalSec < 31104000) // کمتر از سال
            {
                var months = Math.Floor((double)ts.Days / 30).ToInt();
                return months <= 1 ? " یک ماه قبل " : months + " ماه قبل ";
            }
            var years = Math.Floor((double)ts.Days / 365).ToInt();
            return years <= 1 ? " یک سال قبل " : years + " سال قبل ";
        }

        /// <summary>
        /// آیا تاریخ فعلی بین این دو تاریخ قرار دارد؟
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <param name="fromDate">از تاریخ</param>
        /// <param name="toDate">تا تاریخ</param>
        /// <returns></returns>
        public static bool BetweenDate(this DateTime date, DateTime fromDate, DateTime toDate)
        {
            return date.Date.Ticks >= fromDate.Date.Ticks && date.Date.Ticks <= toDate.Date.Ticks;
        }

        /// <summary>
        /// مقایسه دو تاریخ به صورت جز به جز ( سال و ماه و روز )
        /// </summary>
        public static bool DateCompare(this DateTime date, DateTime secondDate)
        {
            return date.Year == secondDate.Year && date.Month == secondDate.Month && date.Day == secondDate.Day;
        }

        /// <summary>
        /// روز هفته فارسی
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static string ToPersianDayOfWeek(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return "جمعه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "يكشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهار شنبه";
                default:
                    return "";
            }
        }

        /// <summary>
        /// آیا تاریخ مورد نظر یک روز کاری میباشد؟
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static bool WorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Thursday && date.DayOfWeek != DayOfWeek.Friday;
        }


        /// <summary>
        /// آیا تاریخ مورد نظر آخر هفته میباشد؟
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Thursday || date.DayOfWeek == DayOfWeek.Friday;
        }

        /// <summary>
        /// فردای روز کاری!
        /// </summary>
        /// <param name="date">تاریخ</param>
        /// <returns></returns>
        public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.WorkingDay())
                nextDay = nextDay.AddDays(1);
            return nextDay;
        }

        /// <summary>
        /// برای تاریخ های انگلیسی
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string OrdinalSuffix(this DateTime datetime)
        {
            int day = datetime.Day;
            if (day % 100 >= 11 && day % 100 <= 13)
                return String.Concat(day, "th");
            switch (day % 10)
            {
                case 1:
                    return String.Concat(day, "st");
                case 2:
                    return String.Concat(day, "nd");
                case 3:
                    return String.Concat(day, "rd");
                default:
                    return String.Concat(day, "th");
            }
        }



        /// <summary>
        /// محاسبه سن
        /// </summary>
        public static byte CalculateAge(this DateTime date)
        {
            return (byte)(DateTime.Now.Year - date.Year);
        }

        /// <summary>
        /// تفاضل سال 
        /// </summary>
        public static byte CalculateDifferenceYear(this DateTime startDate, DateTime endDate)
        {
            return (byte)(endDate.Year - startDate.Year);
        }

        /// <summary>
        /// تفاضل ماه 
        /// </summary>
        public static int CalculateDifferenceMonth(this DateTime startDate, DateTime endDate)
        {
            return ((endDate.Year - startDate.Year) * 12) + (endDate.Month - startDate.Month);
        }

        /// <summary>
        /// تفاضل روز
        /// </summary>
        public static int CalculateDifferenceDay(this DateTime startDate, DateTime endDate)
        {
            var timeSpan = endDate - startDate;
            return timeSpan.Days;
        }

    }
}