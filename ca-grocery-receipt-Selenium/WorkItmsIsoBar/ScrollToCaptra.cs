using OpenQA.Selenium;
namespace VendorSelenium {
    class ScrollToCaptra : BaseWorkItem
    //class FillBrokerInfo : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            var captra = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-health-declaration']/div/fieldset/div[8]"));
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].scrollIntoView({ block: 'end',  behavior: 'smooth' });", captra);
        }
    }
}
