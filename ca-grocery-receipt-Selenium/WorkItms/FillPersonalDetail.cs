using OpenQA.Selenium;

namespace trialOnSelenium {
    class FillPersonalDetail : BaseWorkItem
    // class FillPersonalDetail : IWorkItems
    {
        private JobDispensor _personalDetailTask;
        public FillPersonalDetail(JobDispensor subTask) {
            _personalDetailTask = subTask;
        }
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public   void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("form-personal-detail")).Displayed);
            _personalDetailTask.CompleteTheTask(setting);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='addressBlock']")).SendKeys("Test Address addressBlock");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("AddressDistrict")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-personal-detail']/div[1]/div[12]/div/select/option[2]")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("BankNumber")).SendKeys("003");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("BankAccountNumber")).SendKeys("123456789345678");

        }
    }
}
