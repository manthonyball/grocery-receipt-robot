using Microsoft.Extensions.Configuration;
using System;

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

        ProjectDTO projectData = new ProjectDTO()
        {
            receiptCode = "122923 123219 1698 02809"
        };
        //////// end test case setting

        /////start testing  

        //start the job 
        AutomatedDrivers.GetInstanceDriver().Navigate().GoToUrl(Utility.GetURL());
        foreach (IWorkItems aJob in JobList.GetJobList())
            aJob.ExecuteItems(settings, projectData);

        Utility.LogInfo("--------------------------------------");
        Console.ReadKey();

    }
}