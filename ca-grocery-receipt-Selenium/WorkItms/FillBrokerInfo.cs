using OpenQA.Selenium;
using System.Threading;

namespace trialOnSelenium {
    class FillBrokerInfo : BaseWorkItem
    //class FillBrokerInfo : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.ClassName("text-enlarged")));

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("broker-agent-code")).SendKeys("ba001");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("broker-agent-name")).SendKeys("auto test");

            Thread.Sleep(100);
        }
    }
}
