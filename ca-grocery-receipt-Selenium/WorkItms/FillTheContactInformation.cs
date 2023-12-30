using OpenQA.Selenium;
using System;
using System.Threading;
namespace WebpageWorker
{
    class FillTheContactInformation : BaseWorkItem
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData)
        {
            /**************************************************************
            * contact information
            **************************************************************/

            // is notified services provided? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_914991_396044']")).Click(); // yes
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_374912")).SendKeys("Anthony");//First name  
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_374913")).SendKeys("Lam");//Last name  

            var _element = AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_374914")); //phone number
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].setAttribute('value', '4375991673')", _element);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_374915")).SendKeys("fatball21@hotmail.com");//email
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_374914")).SendKeys(" ");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            /**************************************************************
            * submit
            **************************************************************/
            //submit 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

        }
    }
}