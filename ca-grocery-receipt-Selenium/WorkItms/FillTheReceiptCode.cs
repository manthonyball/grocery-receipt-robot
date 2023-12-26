using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebpageWorker {
    class FillTheReceiptCode : BaseWorkItem 
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData ) {
            var (part1, part2, part3, part4) = GetParts(projectData.receiptCode);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_0")).SendKeys(part1);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_1")).SendKeys(part2);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_2")).SendKeys(part3);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_3")).SendKeys(part4);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        private (string, string, string, string) GetParts(string receiptCode)
        {
            var parts = receiptCode.Split(' ');
            return (parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
