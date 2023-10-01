using SadrTools.Utility;
using System;
using System.Text;

namespace SadrTools.Extensions;

public static class ExceptionExt
{
    /// <summary>
    /// جزییات یک خطا
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static string GetDetails(this Exception ex)
    {
        var sb = new StringBuilder();

        sb.AppendLine("Data : ");

        sb.AppendLine(ex.Data.ToString());

        sb.AppendLine("InnerException :");

        sb.AppendLine(ex.InnerException != null ? ex.InnerException.ToString() : "");

        sb.AppendLine("Message : ");

        sb.AppendLine(ex.Message);

        sb.AppendLine("Source : ");

        sb.AppendLine(ex.Source);

        sb.AppendLine("StackTrace : ");

        sb.AppendLine(ex.StackTrace);

        return sb.ToString();

    }


    /// <summary>
    /// ثبت خطاها
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="form"> فرم جاری</param>
    public static void LogToTextFile(this Exception ex)
    {
        var sb = new StringBuilder();

        sb.AppendLine(" -------------------- " + DateMethods.Hour() + "-----------------------");

        sb.AppendLine("User : ");
        sb.AppendLine(CommonConsts.Application.LoginName);
        sb.AppendLine();

        sb.AppendLine(ex.GetDetails());

        string path = StringMethods.CreateTodayFileName("LogFiles");

        sb.ToString().ToFile(path);

    }


    /// <summary>
    /// ثبت خطاها
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="form"> فرم جاری</param>
    public static void LogToTextFile(this Exception ex, string methodName)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(" -------------------- " + DateMethods.Hour() + "-----------------------");

        sb.AppendLine("Method : ");
        sb.AppendLine(methodName);
        sb.AppendLine();

        sb.AppendLine("User : ");
        sb.AppendLine(CommonConsts.Application.LoginName);
        sb.AppendLine();

        sb.AppendLine(ex.GetDetails());

        string path = StringMethods.CreateTodayFileName("LogFiles");

        sb.ToString().ToFile(path);

    }
}