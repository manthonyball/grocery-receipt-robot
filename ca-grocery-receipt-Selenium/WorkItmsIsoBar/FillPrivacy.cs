using OpenQA.Selenium;
using System.Threading;
namespace VendorSelenium {
    class FillPrivacy : BaseWorkItem
    //class FillBrokerInfo : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            string privacyStatment = "//*[@id='form-health-declaration']/div/fieldset/div[6]/div//div[1]/label";
            var privacyStatments = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath(privacyStatment));
            foreach (var item in privacyStatments) {
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
                Thread.Sleep(10);
            }
        }
    }
}
