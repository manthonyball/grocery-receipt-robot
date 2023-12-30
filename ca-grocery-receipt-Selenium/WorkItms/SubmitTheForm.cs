using OpenQA.Selenium;
using System;
using System.Threading;
namespace WebpageWorker
{
    class SubmitTheForm : BaseWorkItem
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData)
        {
            /**************************************************************
            * submit
            **************************************************************/ 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
        }
    }
}