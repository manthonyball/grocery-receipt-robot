using OpenQA.Selenium;
using System;
//strategy pattern
namespace trialOnSelenium {
    class FillMultiplePersonal : ISubTask
    // class FillPersonalDetail : IWorkItems
    {
        public void ExecuteTheTask(ConfigDTO setting) {
            //public void ExecuteItems( ConfigDTO setting, ProductDTO productSetting) {
            AutomatedDrivers.GetInstancePageWait().Until(d => d.FindElement(By.Id("form-personal-detail")).Displayed);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Surname-0")).SendKeys("Surname");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("GivenName-0")).SendKeys("GivenName");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("HKID-0")).SendKeys("A123456");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("HKIDCopy-0")).SendKeys("3");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Day-0")).SendKeys(setting.date2.Day.ToString());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Month-0")).SendKeys(setting.date2.Month.ToString());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("MobileNumber")).SendKeys("22334455");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Email")).SendKeys(setting.receiveMail);
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("AddressFlat")).SendKeys("Test Address Flat " + Utility.GetWeekInfoInEng(DateTime.Now));
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("AddressStreet")).SendKeys("test Street " + Utility.GetWeekInfoInEng(DateTime.Now));
            if (setting.numberOfInsured > 0) {
                for (int i = 1; i <= setting.numberOfInsured; i++) {
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Surname-" + i.ToString())).SendKeys(Utility.GetMonthEngName(i));
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("GivenName-" + i.ToString())).SendKeys(Utility.GetMonthEngName(i));
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("HKID-" + i.ToString())).SendKeys("A123456");
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("HKIDCopy-" + i.ToString())).SendKeys("3");
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Day-" + i.ToString())).SendKeys(setting.date2.Day.ToString());
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Month-" + i.ToString())).SendKeys(setting.date2.Month.ToString());
                }
            }
        }

    }
}
