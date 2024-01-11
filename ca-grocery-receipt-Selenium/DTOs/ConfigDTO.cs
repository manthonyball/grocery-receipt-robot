using System;
public record ConfigDTO(char environment,
    char gender,
    string language,
    int _timeout_second,
    string driver_path,
    string logPath,
    string url,
    string fName,
    string lName,
    string phoneName,
    string email
    );

public class ConfigDTO_OldWay
{
    public DateTime _todayIs = DateTime.Now;
    public DateTime todayIs => _todayIs;
    public char environment { get; init; }
    public char gender { get; init; }
    public string language { get; init; }
    public int _timeout_second { get; init; }
    public string driver_path { get; init; }
    public string logPath { get; init; }
    public string url { get; init; }
    public string fName { get; init; }
    public string lName { get; init; }
    public string phoneName { get; init; }
    public string email { get; init; }
}
