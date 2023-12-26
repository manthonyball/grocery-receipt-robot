using OpenQA.Selenium;
using System.Threading;

namespace trialOnSelenium {
    class ReviewMember : BaseWorkItem
    //class ReviewMember : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            // public  void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            // AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("step1-next-button")).Displayed);
            Thread.Sleep(1500);
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("js-next-step1")).Enabled);
            //AutomatedDrivers.GetInstancePageWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("step1-next-button")));

            //AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("js-next-step1")).Click();
            var part1_next = AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("js-next-step1"));
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", part1_next);
            // AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='section1']//div[@id='step1-next-button']")).Click();
            // AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("js-next-step1")).Click();

        }
    }
}
