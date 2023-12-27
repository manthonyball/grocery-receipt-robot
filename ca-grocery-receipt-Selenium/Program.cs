using OpenQA.Selenium;
using System;

class Program
{
    static void Main(string[] args)
    {
        //////// start test case setting

        ConfigDTO setting = new ConfigDTO()
        {
            environment = 'P',
            gender = 'm',
            language = "en",
            _timeout_second = 1
        };
        ProjectDTO projectConfig = new ProjectDTO()
        {
            receiptCode = "122623 165025 1698 02809"
        };
        //////// end test case setting

        /////start testing  

        //start the job
        using (IWebDriver driver = AutomatedDrivers.GetInstanceDriver())
        {
            driver.Navigate().GoToUrl(Utility.GetURL());
            foreach (IWorkItems aJob in JobList.GetJobList())
                aJob.ExecuteItems(setting, projectConfig);

            Utility.LogInfo("--------------------------------------");
            Console.ReadKey();
        }
    }
}