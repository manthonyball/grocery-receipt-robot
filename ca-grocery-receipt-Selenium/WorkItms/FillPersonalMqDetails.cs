using OpenQA.Selenium;

namespace trialOnSelenium {
    class FillPersonalMqDetails : BaseWorkItem
    // class FillPersonalDetail : IWorkItems
    {
        private JobDispensor _personalDetailTask;
        public FillPersonalMqDetails(JobDispensor subTask) {
            _personalDetailTask = subTask;
        }
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public   void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("form-personal-detail")).Displayed);
            _personalDetailTask.CompleteTheTask(setting);
            AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath("//div[@class='row']/div[@class='col-xs-12']/button[@type='submit']"))[0].Click();
        }
    }
}
