using System;

public class ConfigDTO
{
    public DateTime _todayIs = DateTime.Now;
    public DateTime todayIs => _todayIs;
    public char environment { get; set; }
    public char gender { get; set; }
    public string language { get; set; }
    public int _timeout_second { get; set; }
    public string driver_path { get; set; }
    public string logPath { get; set; }
    public string url { get; set; }
}
