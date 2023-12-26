using OpenQA.Selenium;
using System.Threading;

namespace trialOnSelenium {
    class FillTCs : BaseWorkItem
    //class FillTCs : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public  void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            var tAndC = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath("//*[@id='form-health-declaration']//label[@class='checkbox-inline']"));
            foreach (var item in tAndC) {
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
                Thread.Sleep(10);
            }
        }
    }
}
