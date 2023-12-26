using OpenQA.Selenium;
//strategy pattern
namespace trialOnSelenium {
    class FillSinglePersonMQs : ISubTask
    // class FillPersonalDetail : IWorkItems
    {
        public void ExecuteTheTask(ConfigDTO setting) {
            //public void ExecuteItems( ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='cm']")).SendKeys("177");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='kg']")).SendKeys("77");
        }

    }
}
