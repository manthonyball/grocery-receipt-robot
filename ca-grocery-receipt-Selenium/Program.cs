using OpenQA.Selenium;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //////// start test case setting

        ConfigDTO setting = new ConfigDTO()
        {
            environment = 'P',
            gender = 'm',
            language = "en"
        };
        ProjectDTO projectConfig = new ProjectDTO()
        {
            receiptCode = "123456 124578 6521 23564"
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