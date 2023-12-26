using OpenQA.Selenium;

namespace trialOnSelenium {
    class ScrollToCaptra : BaseWorkItem {
        private string _divIdentifier;
        public ScrollToCaptra(string identifier) {
            _divIdentifier = identifier;
        }
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            var cancellationRights_paragraph = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-health-declaration']/div[" + _divIdentifier + "]"));
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].scrollIntoView({ block: 'end',  behavior: 'smooth' });", cancellationRights_paragraph);
        }
    }
}
