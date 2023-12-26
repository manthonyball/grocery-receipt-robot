using OpenQA.Selenium;
using System.Linq;
/// <summary>
/// for iframe
/// https://stackoverflow.com/questions/53203417/ways-to-deal-with-document-under-iframe
/// </summary>
namespace trialOnSelenium {
    class FillFullfillmentForm : BaseWorkItem
    //class FillFullfillmentForm : IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //for vtop 
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("vtopEnrol")).Displayed);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='vtop-0-company']")).SendKeys("test company");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='vtop-0-membNo']")).SendKeys("0123456789123456"); 
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("select-day-vtop-0-label")).Displayed);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='select-day-vtop-0']")).SendKeys(setting.date2.Day.ToString());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='select-month-vtop-0']")).SendKeys(setting.date2.Month.ToString());
            if (setting.productCode == ProductEnum.Product.vtop
                  && setting.optionalBenefitItems.Any(b => b == OptionalBenefitEnum.OptionalBenefit.SMM)
                ) {
                // if SMM selected, need to declare dun have SMM be4
                var smmConfirmNvHaveIt = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='formTopupData']/div[2]/div[7]/div/div/div/div[1]/label[1]"));
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", smmConfirmNvHaveIt);
            }
            var fullfillment_confirm = AutomatedDrivers.GetInstanceDriver().FindElements(By.XPath("//*[@id='formTopupData']//label[@class='checkbox-inline']"));
            foreach (var item in fullfillment_confirm)
                AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", item);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='formTopupData']/div[2]/div[10]/button")).Click();

        }
    }
}
