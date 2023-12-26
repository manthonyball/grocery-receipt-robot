using OpenQA.Selenium;
using System.Threading;
using EC = SeleniumExtras.WaitHelpers;

namespace VendorSelenium {
    class FillTheQuote : BaseWorkItem
    //class FillTheQuote: IWorkItems
    {
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            var SCROLL_CONST = "arguments[0].scrollIntoView({ block: 'end',  behavior: 'smooth' ,inline: 'end'});";
            var JUST_SCROLL_500_PX_CONST = "window.scrollBy(0, 700);";
            var SCROLL_SLEEP_CONST = 1500;

            // timeout
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[1]")));
            //quote input 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[2]/ng-include[1]/div/label/div/div[1]/div[1]/select")).SendKeys("33");
            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[2]/ng-include[1]/div/label/div/div[1]/div[2]/select")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[2]/ng-include[1]/div/label/div/div[1]/div[2]/select/option[" + (char.ToUpperInvariant(setting.gender) == char.ToUpperInvariant('M') ? "3" : "2") + "]")).Click();
            //  AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[2]/ng-include[1]/div/label/div/div[1]/div[2]/select")).SendKeys("male");


            // AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[4]/button")).Click();
            AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.ElementToBeClickable((By.XPath("//*[@id='form-insurance-quote']/div/div[4]/button"))));
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-insurance-quote']/div/div[4]/button")).Click();

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("name-1")).SendKeys("Tai Man");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("last-name-1")).SendKeys("Chan");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("tel-1")).SendKeys("12345678");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("email-1")).SendKeys(setting.receiveMail);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='quotation_price_form_submit']")).Click();

            // var corePlan = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='0-CIA-CIA1']/parent::div"));
            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(JUST_SCROLL_500_PX_CONST);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='0-CIA-CIA1']/parent::div")).Click();
            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-quote-coverage-CIA']/div/div[4]/button")).Click();
            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-quote-coverage-CIB']/div/div[4]/button")).Click();

            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-quote-coverage-CIC']/div/div[4]/button")).Click();

        }
    }
}
