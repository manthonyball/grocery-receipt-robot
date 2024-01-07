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
            receiptCode = "010624 123219 1698 02809"
        };
        //////// end test case setting
         
        /////start testing  

        //start the job 
        try
        {
            AutomatedDrivers.GetInstanceDriver().Navigate().GoToUrl(Utility.GetURL());
            foreach (IWorkItems aJob in JobList.GetJobList())
                aJob.ExecuteItems(settings, projectData); 
        }
        catch (Exception e)
        {
            Utility.LogInfo("Exception found: " + e.Message);
            throw;
        }
        finally
        {
            AutomatedDrivers.TurnOffDeMachine();
        }
        Utility.LogInfo("--------------------------------------");
        Console.ReadKey();

    }
}