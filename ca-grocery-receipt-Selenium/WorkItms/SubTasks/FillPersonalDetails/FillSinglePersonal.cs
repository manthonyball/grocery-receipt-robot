using OpenQA.Selenium;

namespace trialOnSelenium {
    class FillSinglePersonal : ISubTask
    // class FillPersonalDetail : IWorkItems
    {
        public void ExecuteTheTask(ConfigDTO setting) {
            //public void ExecuteItems( ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("form-personal-detail")).Displayed);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='last-name']")).SendKeys("GivenName");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='name']")).SendKeys("name");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='identity-card']")).SendKeys("A123456");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='hkid']")).SendKeys("3");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='select-day']")).SendKeys(setting.date2.Day.ToString());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='select-month']")).SendKeys(setting.date2.Month.ToString());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='tel']")).SendKeys("22334455");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='email']")).SendKeys(setting.receiveMail);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='address1']")).SendKeys("Test Address Flat");

        }
    }
}
