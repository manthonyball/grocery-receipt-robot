using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

public static class AutomatedDrivers
{
    private static IWebDriver _driver;
    private static IJavaScriptExecutor _jsExecutor;
    private static WebDriverWait _pageWait;
    private const int timeOut_second_page = 5;
    private const int timeOut_second_global = 15;
    private const int polling_interval_ms = 250;
    private static string driver_path;
    public static void ConfigureDriver(ConfigDTO config)
    {
        driver_path = config.driver_path;
    }
    private static IWebDriver GetDriver()
    {
        ChromeOptions options = new ChromeOptions();
        
        //use specific profile
       // options.AddArgument("user-data-dir=C:/Users/xw20/AppData/Local/Google/Chrome/User Data/Profile 2");

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

        return new ChromeDriver(driver_path, options);
        //return new ChromeDriver(@"C:\TFS\seleniumDriver");
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
            _pageWait = new WebDriverWait(GetInstanceDriver(), TimeSpan.FromSeconds(timeOut_second_page));

        _pageWait.PollingInterval = TimeSpan.FromMilliseconds(polling_interval_ms);
        return _pageWait;
    }
    public static void TurnOffDeMachine()
    {
        Utility.LogInfo("Turning off the machine...");
        if (_driver is not null)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeOut_second_page));
            _driver.Close();
            _driver.Quit();
        }
        Utility.LogInfo("Done");
    }
    public static IJavaScriptExecutor GetInstanceJSExecutor()
    {
        if (_jsExecutor == null)
        {
            _jsExecutor = (IJavaScriptExecutor)GetInstanceDriver();
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
