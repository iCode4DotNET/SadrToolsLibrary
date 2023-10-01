using System.Globalization;
using System;

namespace SadrTools.Utility;

public static class DateMethods
{
    /// <summary>
    /// چندمین روز ماه
    /// </summary>
    /// <param name="dayNumber">شماره روز</param>
    /// <returns></returns>
    internal static string DayName(string dayNumber)
    {
        return dayNumber switch
        {
            "01" => "یکم",
            "02" => "دوم",
            "03" => "سوم",
            "04" => "چهارم",
            "05" => "پنجم",
            "06" => "ششم",
            "07" => "هفتم",
            "08" => "هشتم",
            "09" => "نهم",
            "10" => "دهم",
            "11" => "یازدهم",
            "12" => "دوازدهم",
            "13" => "سیزدهم",
            "14" => "چهاردهم",
            "15" => "پانزدهم",
            "16" => "شانزدهم",
            "17" => "هفدهم",
            "18" => "هجدهم",
            "19" => "نوزدهم",
            "20" => "بیستم",
            "21" => "بیست و یکم",
            "22" => "بیست و دوم",
            "23" => "بیست و سوم",
            "24" => "بیست و چهارم",
            "25" => "بیست و پنجم",
            "26" => "بیست و ششم",
            "27" => "بیست و هفتم",
            "28" => "بیست و هشتم",
            "29" => "بیست و نهم",
            "30" => "سی ام",
            "31" => "سی ویکم",
            _ => "",
        };
    }

    /// <summary>
    /// نام ماه فارسی
    /// </summary>
    /// <param name="monthNumber">شماره ماه</param>
    /// <returns></returns>
    internal static string MonthName(string monthNumber)
    {
        switch (monthNumber)
        {
            case "01":
                return "فروردين"; ;

            case "02":
                return "ارديبهشت";

            case "03":
                return "خرداد";

            case "04":
                return "تير";

            case "05":
                return "مرداد";

            case "06":
                return "شهريور";

            case "07":
                return "مهر";

            case "08":
                return "آبان";

            case "09":
                return "آذر";

            case "10":
                return "دی";

            case "11":
                return "بهمن";

            case "12":
                return "اسفند";

            default:
                return "";
        }
    }

    /// <summary>
    /// ساعت الان
    /// </summary>
    /// <param name="format">فرمت خروجی</param>
    /// <returns></returns>
    public static string Hour(string format = "hh:mm:ss")
    {
        return DateTime.Now.ToString(format);
    }

}
