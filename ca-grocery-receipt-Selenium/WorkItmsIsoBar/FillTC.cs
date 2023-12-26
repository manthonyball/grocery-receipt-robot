using OpenQA.Selenium;
using System.Threading;
namespace VendorSelenium {
    class FillTC : BaseWorkItem
    //class FillBrokerInfo : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            string tc = "//*[@id='form-health-declaration']/div/fieldset/div[5]//div/div[1]/label";
            var tcList = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath(tc));
            foreach (var item in tcList) {
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
                Thread.Sleep(10);
            }
        }
    }
}
