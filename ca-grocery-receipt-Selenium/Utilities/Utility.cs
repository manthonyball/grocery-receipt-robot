using System;
using System.IO;


public static class Utility
{
    private static string _logPath = @"C:\TFS\WriteLines.txt";
    private static string _URL = "";
    /// <summary>
    /// this is the only method that is called from outside to initialize the private variables in utility
    /// </summary>
    /// <param name="config"></param>
    ///     
    public static void Configure(ConfigDTO config)
    {
        _logPath = config.logPath;
        _URL = config.url;
    }
     
    #region "project specific"
    public static void LogInfo(string i) => File.AppendAllText(_logPath, i + "," + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + Environment.NewLine);

    public static string GetURL() => _URL;

    #endregion

    #region "Generic"

    public static int GetYearIn2Digi() => DateTime.Now.Year % 100;

    public static string GetMonthEngName(int i)
    {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        return new DateTime(DateTime.Now.Year, i, 1).ToString("MMMM", ci);
    }

    public static string GetWeekInfoInEng(DateTime date)
    {
        switch (GetOne2FiveFromDate(date))
        {
            case 1:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-One";
            case 2:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Two";
            case 3:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Three";
            case 4:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Four";
            case 5:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Five";
            default:
                return "master";
        }
    }
    private static int GetOne2FiveFromDate(DateTime date)
    {
        date = date.Date;
        DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
        DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
        if (firstMonthMonday > date)
        {
            firstMonthDay = firstMonthDay.AddMonths(-1);
            firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
        }
        return (date - firstMonthMonday).Days / 7 + 1;
    }

    #endregion
}