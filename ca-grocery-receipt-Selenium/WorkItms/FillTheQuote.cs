using OpenQA.Selenium;
using System;
using System.Linq;
using EC = SeleniumExtras.WaitHelpers;

/// <summary>
/// https://stackoverflow.com/questions/38673465/in-selenium-webdriver-expectedcondition-elementtobeclickable-is-not-waiting-unt
/// Wait<WebDriver> wait = new FluentWait<WebDriver>(driver)
///    .withTimeout(30, SECONDS)
///    .pollingEvery(5, SECONDS)
///    .ignoring(NoSuchElementException.class);
/// 
/// WebElement foo = wait.until(new Function<WebDriver, WebElement>() {
///  public WebElement apply(WebDriver driver) {
///    return (driver.findElements(By.id("progressbar")).size() == 0);
///  }
/// });
/// </summary>
namespace trialOnSelenium {
    class FillTheQuote : BaseWorkItem
    //class FillTheQuote: IWorkItems
    {
        private const string SCROLL_CONST = "arguments[0].scrollIntoView({ block: 'end',  behavior: 'smooth' });";
        //   private const string SCROLL_CONST_MIDDLE = "window.scrollTo(0,document.body.scrollHeight/2);";
        public override void ExecuteItems(ConfigDTO setting, ProductDTO productSetting) {
            //public  void ExecuteItems(IWebDriver driver, ref IJavaScriptExecutor executor, ref  WebDriverWait w, ConfigDTO setting, ProductDTO productSetting) {
            // timeout
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("headingMyself")));
            //quote input 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("age0")).SendKeys("33");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.ClassName("txtSe")).Click();
            string genderSelect_str = "//*[@id='headingMyself']/div/form/div[2]/select/option[" + (char.ToUpperInvariant(setting.gender) == char.ToUpperInvariant('M') ? "2" : "3") + "]";
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(genderSelect_str)).Click();
            //AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='collapse0']/ng-if/div[1]/div/div/div/lable/div[1]/div")).Displayed);

            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='test']")).Displayed); // the first minus sign

            var seePrice = AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("seePriceButtongtm"));// points can be stopped to select coverage 
            AutomatedDrivers.GetInstanceJSExecutor().ExecuteScript("arguments[0].click();", seePrice);

            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("quotation_price_form")).Displayed);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='leadForm']/div[2]/div[1]/div[2]/input")).SendKeys("bapartner");
            //AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Givenname")).SendKeys("tai man");
            //AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Email")).SendKeys("test@test.com");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("quotation_price_form_submit")).Click();

            if (setting.numberOfInsured > 0) {
                for (int i = 1; i <= setting.numberOfInsured; i++) {
                    DateTime myFamilymmbDOB = setting.date2.AddYears(-1 * i);
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("headingAddFamilyMember")).Click();
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("(//*[@id='heading']/h3/form/div[1]/select)[" + i.ToString() + "]")).Click();
                    if (i > 3)
                        AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("(//*[@id='heading']/h3/form/div[1]/select/option[contains(@value,'Child')])[" + i.ToString() + "]")).Click();
                    else
                        AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("(//*[@id='heading']/h3/form/div[1]/select/option[contains(@value,'Grandchild')])[" + i.ToString() + "]")).Click();

                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("age" + i)).SendKeys((setting.todayIs.Year - myFamilymmbDOB.Year).ToString());
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("(//*[@id='heading']/h3/form/div[1]/label)[" + i.ToString() + "]")).Click();
                    AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.XPath("//*[@id='heading']/h3/i[contains(@class, 'fa-minus')]")).Displayed);
                    // the minus sign in others insured
                    AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElements(By.XPath("//*[@id='heading']/h3/i[contains(@class, 'fa-minus')]")).Count == i);
                }
            }

            HandleBenefitSelection(setting);
            //AutomatedDrivers.GetInstancePageWait().Until(d => !d.FindElement(By.Id("quotation_price_form")).Displayed);
            //AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.ClassName("btn-buy-online")).Enabled);
            AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.ElementToBeClickable(By.ClassName("btn-buy-online")));
            AutomatedDrivers.GetInstanceDriver().FindElement(By.ClassName("btn-buy-online")).Click();
        }
        private void HandleBenefitSelection(ConfigDTO setting) {
            if (setting.optionalBenefitItems.Count > 0) {
                var productBenefitSupportList = Utility.GetProductSupportedBenefit(setting.productCode);
                foreach (var aBenefit in setting.optionalBenefitItems)
                    if (productBenefitSupportList.Any(bene => bene == aBenefit)) {
                        SelectTheBenefit(aBenefit);
                        System.Threading.Thread.Sleep(1000);
                    }
            }
        }
        private void SelectTheBenefit(OptionalBenefitEnum.OptionalBenefit item) {
            var targetLocation = "//*[@for='0--" + item.ToString() + "']";
           //var priceString = "//*[@id='pricebox']/div[1]/ng-if/div/div[2]/span[3]";
           //var ori_value = AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(priceString)).Text;
            try {
                AutomatedDrivers.GetInstancePageWait().Until(EC.ExpectedConditions.ElementToBeClickable((By.XPath(targetLocation))));
                AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(targetLocation)).Click();
            }
            catch (StaleElementReferenceException) {
                AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(targetLocation)).Click();
            }
            
        }
    }
}
