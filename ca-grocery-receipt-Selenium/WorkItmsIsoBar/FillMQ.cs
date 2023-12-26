using OpenQA.Selenium;
using System.Threading;
namespace VendorSelenium {
    class FillMQ : BaseWorkItem
    //class FillBrokerInfo : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='form-health-declaration']/div/div/h2")));

            string suwString = "//*[@id='form-health-declaration']/div/fieldset//fieldset/div/div/div[1]/label[2]";

            var cleanCases = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath(suwString));
            foreach (var item in cleanCases) {
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
                Thread.Sleep(10);
            }

        }
    }
}
