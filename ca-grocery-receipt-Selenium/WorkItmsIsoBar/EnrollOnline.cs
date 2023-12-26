using OpenQA.Selenium;
using System.Threading;
using EC = SeleniumExtras.WaitHelpers;

namespace VendorSelenium {
    class EnrollOnline : BaseWorkItem
    //class FillTheQuote: IWorkItems
    {
        //https://www.selenium.dev/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_Support_UI_ExpectedConditions.htm
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            var SCROLL_CONST = "arguments[0].scrollIntoView({ block: 'end',  behavior: 'smooth'});";
            var JUST_SCROLL_500_PX_CONST = "window.scrollBy(0, 500);";

            var SCROLL_SLEEP_CONST = 1400;

            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-acknowledgement']/div/div[3]/div/div[1]/label")).Click();

            //Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
            AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.VisibilityOfAllElementsLocatedBy((By.XPath("//*[@id='form-acknowledgement']/div/div[4]/button"))));
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-acknowledgement']/div/div[4]/button")).Click();

            var continueEnrolBtn_str = "//*[@id='form-online-quote-summary']/div[3]/div[1]";
            var continueEnrolBtn = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(continueEnrolBtn_str));
            //Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.VisibilityOfAllElementsLocatedBy((By.XPath(continueEnrolBtn_str))));

            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(SCROLL_CONST, continueEnrolBtn);
            AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.VisibilityOfAllElementsLocatedBy((By.XPath("//*[@id='form-acknowledgement']/div/div[4]/button"))));

            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(JUST_SCROLL_500_PX_CONST);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-online-quote-summary']/div[3]/div[1]/button")).Click();

            var occupationSelection = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='employment-status-0']"));
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(SCROLL_CONST, occupationSelection);

            var employmentStatus = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='employment-status-0']"));
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(SCROLL_CONST, employmentStatus);
            Thread.Sleep(SCROLL_SLEEP_CONST);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='employment-status-0']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='employment-status-0']/option[2]")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-occupations']/div/div[4]/button")).Click();

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='identity-card-0']")).SendKeys("A123456");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='hkid-0']")).SendKeys("3");

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='select-day-0']")).SendKeys("3");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='select-month-0']")).SendKeys("3");

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='cm-0']")).SendKeys("177");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='kg-0']")).SendKeys("77");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='address1']")).SendKeys("Test address1");

            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript(JUST_SCROLL_500_PX_CONST);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-personal-details']/div/fieldset/fieldset[1]/div[5]/div/select")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-personal-details']/div/fieldset/fieldset[1]/div[5]/div/select/option[2]")).Click();

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='form-personal-details']/div/fieldset/fieldset[2]/div[2]/div[1]/select")).SendKeys("003");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(" //*[@id='bank-account']")).SendKeys("123");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='form-personal-details']/div/div[2]/button")).Click();
        }
    }
}
