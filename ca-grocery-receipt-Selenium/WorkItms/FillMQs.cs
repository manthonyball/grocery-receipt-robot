using OpenQA.Selenium;
using System.Threading;

namespace trialOnSelenium {
    class FillMQs : BaseWorkItem
    //class FillMQs : IWorkItems
    {
        private string _suwIdentifier;
        public FillMQs(string identifier) {
            _suwIdentifier = identifier;
        }
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='form-health-declaration']//h2")));

            string suwString = "//label[@class='radio-inline']/input[starts-with(@name,'" + _suwIdentifier + "') and @value='0']";

            var cleanCases = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath(suwString));
            foreach (var item in cleanCases) {
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
                Thread.Sleep(10);
            }

        }
    }
}
