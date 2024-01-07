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
    public char environment { get; set; }
    public char gender { get; set; }
    public string language { get; set; }
    public int _timeout_second { get; set; }
    public string driver_path { get; set; }
    public string logPath { get; set; }
    public string url { get; set; }
    public string fName { get; set; }
    public string lName { get; set; }
    public string phoneName { get; set; }
    public string email { get; set; }
}
