using SadrTools.Extensions;
using System.IO;
using System;

namespace SadrTools.Utility;

public static class StringMethods
{
    /// <summary>
    ///  ساختن مسیر یک فایل در فولدر دلخواه با نام تاریخ روز
    /// </summary>
    /// <param name="directoryName">نام فولدر</param>
    public static string CreateTodayFileName(string directoryName)
    {
        string fileName = DateTime.Today.ToPersianDate('_');
        string currentDir = Directory.GetCurrentDirectory();
        string directory = Path.Combine(currentDir, directoryName);
        Directory.CreateDirectory(directory);
        return Path.Combine(directory, fileName + ".txt");
    }


    public static void LogDatabaseActivity(string log)
    {
        string line = "\n*-------------------------------*\n";
        log += line;
        var path = CreateTodayFileName("DbLog");
        log.ToFile(path);
    }


    /// <summary>
    /// تولید یک رشته رندوم - مناسب برای سالت
    /// </summary>
    /// <returns></returns>
    public static string GenerateSaltString()
    {
        // Random Number Generator (RNG)
        var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        byte[] buffer = new byte[512];
        rng.GetBytes(buffer);
        // string salt = BitConverter.ToString(buffer);
        string salt = buffer.BitToString();

        return salt;
    }
}
