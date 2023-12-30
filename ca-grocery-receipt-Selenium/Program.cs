using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                                          .AddJsonFile("appsettings.json")
                                          .AddEnvironmentVariables()
                                          .Build();

        var settings = config.GetRequiredSection("ConfigDTOSetting").Get<ConfigDTO>();
        AutomatedDrivers.ConfigureDriver(settings);
        Utility.Configure(settings);

        //////// start test case setting

        ProjectDTO projectConfig = new ProjectDTO()
        {
            receiptCode = "122623 165625 1698 02809"
        };
        //////// end test case setting

        /////start testing  

        //start the job 
        AutomatedDrivers.GetInstanceDriver().Navigate().GoToUrl(Utility.GetURL());
        foreach (IWorkItems aJob in JobList.GetJobList())
            aJob.ExecuteItems(settings, projectConfig);

        Utility.LogInfo("--------------------------------------");
        Console.ReadKey();

    }
}