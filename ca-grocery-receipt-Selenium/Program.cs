using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

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
            var jobList = JobList.GetJobList();
            if (jobList.Any())
                foreach (IWorkItems aJob in jobList)
                    aJob.ExecuteItems(settings, projectData);
            else
                Utility.LogInfo("No job to run");
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