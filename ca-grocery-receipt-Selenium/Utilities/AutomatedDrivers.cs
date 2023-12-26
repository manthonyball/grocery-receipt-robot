using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


public class AutomatedDrivers
{
    private static IWebDriver _driver;
    private static IJavaScriptExecutor _jsExecutor;
    private static WebDriverWait _pageWait;
    private static int timeOut_second_page = 5;
    private static int timeOut_second_global = 15;
    private static IWebDriver GetDriver()
    {
        ChromeOptions options = new ChromeOptions();
        // options.BinaryLocation = @"C:\TFS\seleniumDriver\ungoogled-chromium_97.0.4692.71-1.1_windows\chrome.exe";
        options.PageLoadStrategy = PageLoadStrategy.Normal; // since corpSite loads dynamically 
                                                            //options.PageLoadStrategy = PageLoadStrategy.Eager;
                                                            //options.AddArgument("headless"); //no GUI chrome is pop out; console will shown on console window
                                                            //options.EnableMobileEmulation("Galaxy S5"); // open chome mobile
                                                            //options.AddArguments("--disable-web-security");
                                                            //options.PlatformName = "Windows 10";
                                                            //options.BrowserVersion = "92"; 

        //InternetExplorerOptions op = new InternetExplorerOptions(); 
        //  op.IntroduceInstabilityByIgnoringProtectedModeSettings=true;
        //https://chromedriver.chromium.org/downloads 
        // using (IWebDriver driver = new InternetExplorerDriver(@"C:\TFS\seleniumDriver", op)) {
        // using (IWebDriver driver = new FirefoxDriver(@"C:\TFS\seleniumDriver")) {
        // using (IWebDriver driver = new EdgeDriver(@"C:\TFS\seleniumDriver\edgedriver_win64\")) {

        // return new ChromeDriver(@"C:\TFS\seleniumDriver", options);
        return new ChromeDriver(@"C:\TFS\seleniumDriver");
    }
    public static IWebDriver GetInstanceDriver()
    {
        if (_driver == null)
        {
            _driver = GetDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut_second_global);
        }
        return _driver;
    }
    public static WebDriverWait GetInstancePageWait()
    {
        if (_pageWait == null)
        {
            _pageWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut_second_page));
        }
        return _pageWait;
    }
    public static IJavaScriptExecutor GetInstanceJSExecutor()
    {
        if (_jsExecutor == null)
        {
            _jsExecutor = (IJavaScriptExecutor)_driver;
        }
        return _jsExecutor;
    }
}
/***
 
//install drivers
https://www.selenium.dev/documentation/webdriver/getting_started/install_drivers/
 
// setup for IWebDriver
//https://www.selenium.dev/documentation/webdriver/capabilities/shared/ 
 */
